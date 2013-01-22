#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <Stepper.h>

#define MANUAL_STEP_ADD 104        // EEPROM address of encoder tick stepper steps
#define STEPPER_SPEED_ADD 103      // EEPROM address of stepper speed in RPMs
#define STEPS 400                  // Stepper steps for one shaft rotation (including internal gear if available)
#define SINGLE_MOVE_STEPS 20       // Stepper steps during one single motion

#define encoder0PinA  2
#define encoder0PinB  4

// Data wire is plugged into pin 2 on the Arduino
#define ONE_WIRE_BUS 2
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

Stepper stepper(STEPS, 8, 9, 10, 11);

byte focuserPositionPointer;
word currentFocuserPosition;
word newFocuserPosition;

void setup() 
{
  // put your setup code here, to run once:
  initialize();
}

void loop() 
{
  // Move stepper in some not so large step chunks
  if(currentFocuserPosition != newFocuserPosition) {
    boolean last_step = false;
    int steps = newFocuserPosition - currentFocuserPosition;
    if(steps > SINGLE_MOVE_STEPS) {
      steps = SINGLE_MOVE_STEPS;
    }
    else if (steps < -SINGLE_MOVE_STEPS) {
      steps = -SINGLE_MOVE_STEPS;
    }
    else {
      last_step = true;
    }    
    stepper.step(steps);
    currentFocuserPosition += steps;
    if(last_step) saveFocuserPos(currentFocuserPosition);
  }
}


// Interrupt sourced serial event
void serialEvent()
{
  if(Serial.available() > 2) {
    char buffer[10];
    byte len = Serial.readBytesUntil('\n', buffer, 10);
    
    
    if(len > 3) {
      String command = String(buffer).substring(2);
      switch(buffer[0]) {
        case 't':    // Read temperature
          printTemp();
          break;
        case 'p':    // Return current position
          printCurrentPosition();
          break;
        case 'h':    // Halt focuser
          halt();   
          break;
        case 'm':    // Move focuser to new position
          moveTo(stringToNumber(command)); 
          break;
        case 's':
          printSettings();
          break;
        case 'S':
          EEPROM.write(STEPPER_SPEED_ADD, stringToNumber(command));
          stepper.setSpeed(buffer[1]);
          break;
        case 'M':
          EEPROM.write(MANUAL_STEP_ADD, stringToNumber(command));
          break;
        default:
          Serial.print("ERR");       
      }
     Serial.print('\n'); 
    }
  }  
}

// Serial commands routines
void printTemp() {
  sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperatures. For 9 bit res it takes 94ms
  float tempC = sensors.getTempC(insideThermometer);
  Serial.print(tempC, 1);  
}

void printCurrentPosition() {
  Serial.print(currentFocuserPosition);
}

void moveTo(word focuserPosition) {
  newFocuserPosition = focuserPosition;
}

void halt() {
  newFocuserPosition = currentFocuserPosition;
  saveFocuserPos(currentFocuserPosition);
}


// Manual encoder routine
void doEncoder() {
  /* If pinA and pinB are both high or both low, it is spinning
   * forward. If they're different, it's going backward.
   *
   * For more information on speeding up this process, see
   * [Reference/PortManipulation], specifically the PIND register.
   */
  if (digitalRead(encoder0PinA) == digitalRead(encoder0PinB)) {
    moveTo(currentFocuserPosition + EEPROM.read(MANUAL_STEP_ADD));
  } else {
    moveTo(currentFocuserPosition - EEPROM.read(MANUAL_STEP_ADD));
  }
}


// Returns focuser state and settings in one string
String printSettings() {
  Serial.print("M:" + EEPROM.read(MANUAL_STEP_ADD));
  Serial.print(",S:" + EEPROM.read(STEPPER_SPEED_ADD));
  Serial.print(",P:" + currentFocuserPosition);
  Serial.print(",T:");
  printTemp();
  Serial.print('\n');
}

// Current focuser position storage
void saveFocuserPos(word newPos) {
  EEPROM.write(focuserPositionPointer, lowByte(newPos)); 
  EEPROM.write(focuserPositionPointer + 1, highByte(newPos)); 
}
word readFocuserPos() {
  return word(EEPROM.read(focuserPositionPointer + 1), EEPROM.read(focuserPositionPointer)); 
}


// Convert string to number
long stringToNumber(String value) {
  char charValue[value.length()];
  value.toCharArray(charValue, value.length());  
  return atol(charValue);
}


// Initialization routine
void initialize()
{
  if(EEPROM.read(101) != 100)
  {
    // Do it here only once
    EEPROM.write(MANUAL_STEP_ADD, 16);
    EEPROM.write(STEPPER_SPEED_ADD, 100);
    EEPROM.write(101, 100);
    focuserPositionPointer = 0;
    EEPROM.write(102, focuserPositionPointer); //Pointer to current focuser position storage point
    saveFocuserPos(0);
  } 
  // We rotate focuser pointer storage place to avoid EEPROM damage after 100 000 cycles (0...100)
  focuserPositionPointer = EEPROM.read(101);
  word tempFocus = readFocuserPos();
  focuserPositionPointer += 2;
  if(focuserPositionPointer > 98) focuserPositionPointer = 0;
  EEPROM.write(101, focuserPositionPointer);
  saveFocuserPos(tempFocus);
  currentFocuserPosition = newFocuserPosition = tempFocus;
  
  // Initialize serial
  Serial.begin(9600);
  
  // Initialize temperature sensor
  sensors.begin(); // IC Default 9 bit. 
  sensors.getAddress(insideThermometer, 0);
  sensors.setResolution(insideThermometer, 9);
  
  // Initialize stepper motor
  stepper.setSpeed(20);
  
  pinMode(encoder0PinA, INPUT); 
  digitalWrite(encoder0PinA, HIGH);       // turn on pullup resistor
  pinMode(encoder0PinB, INPUT); 
  digitalWrite(encoder0PinB, HIGH);       // turn on pullup resistor

  attachInterrupt(0, doEncoder, CHANGE);  // encoder pin on interrupt 0 - pin 2
}
