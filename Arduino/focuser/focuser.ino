// ASCOM focuser arduino sketch
// ascom-jolo-focuser Google code project
// 
// Author: jolo drjolo@gmail.com
//
// 2013-01-22  0.0.1  first version
//

#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <Stepper.h>

// EEPROM addresses
#define MANUAL_STEP_ADD 104        // EEPROM address of encoder tick stepper steps
#define STEPPER_SPEED_ADD 103      // EEPROM address of stepper speed in RPMs
#define STEPS 400                  // Stepper steps for one shaft rotation (including internal gear if available)
#define SINGLE_MOVE_STEPS 20       // Stepper steps during one single motion

// Temperature sensor config (one wire protocol)
#define TEMP_SENSOR_PIN 5
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Encoder config
#define encoder0PinA 2
#define encoder0PinB 4
#define encoderButtonPin 3

// Buzzer pin
#define BUZZER_PIN 10

// Stepper config
Stepper stepper(STEPS, 6, 7, 8, 9);

byte focuserPositionPointer;        
word currentFocuserPosition;
word newFocuserPosition;
unsigned long tempReadMilis;

void setup() 
{
  // put your setup code here, to run once:
  initialize();
}

void loop() 
{
  // Send temperature read if conversion time elapsed
  if(tempReadMilis != 0 && millis() > tempReadMilis) printTemp();
  
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


// Interrupt serial event
void serialEvent()
{
  if(Serial.available() > 2) {
    char buffer[10];
    byte len = Serial.readBytesUntil('\n', buffer, 10);
   
    if(len > 3) {
      String command = String(buffer).substring(2);
      switch(buffer[0]) {
        case 'T':    // Read temperature
          requestTemp();
          break;
        case 'P':    // Return current position
          printCurrentPosition();
          break;
        case 'H':    // Halt focuser
          halt();   
          break;
        case 'I':
          printInMoveStatus();
          break;
        case 'M':    // Move focuser to new position
          moveTo(stringToNumber(command)); 
          break;
        case 'A':
          printSettings();
          break;
        case 'S':
          saveStepperSpeed(stringToNumber(command));
          break;
        default:
          Serial.print("ERR:");      
          Serial.print(buffer); 
      }
     Serial.print('\n'); 
    }
  }  
}

// Serial commands subroutines
void requestTemp() {
  sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperature. For 10 bit res it takes 188ms
  tempReadMilis = millis() + 188;
}

void printTemp() {
  float tempC = sensors.getTempC(insideThermometer);
  Serial.print("T:");
  Serial.print(tempC, 1);  
  tempReadMilis = 0;
}

void printCurrentPosition() {
  Serial.print("P:");
  Serial.print(currentFocuserPosition);
}

void printInMoveStatus() {
  Serial.print("I:");
  if(newFocuserPosition == currentFocuserPosition) 
    Serial.print("false");
  else
    Serial.print("true");
}

void moveTo(word focuserPosition) {
  newFocuserPosition = focuserPosition;
  Serial.print("M");
}

void halt() {
  newFocuserPosition = currentFocuserPosition;
  saveFocuserPos(currentFocuserPosition);
  Serial.print("H");
}

void saveStepperSpeed(byte stepperSpeed) {
  EEPROM.write(STEPPER_SPEED_ADD, stepperSpeed);
  stepper.setSpeed(stepperSpeed);
  Serial.print("S");
}

// Interrupt manual encoder routine
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
  Serial.print(",");
  printCurrentPosition();
  Serial.print(",");
  printTemp();
  Serial.print(",");
  printInMoveStatus();
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
    EEPROM.write(102, 0);        //Pointer to current focuser position storage value
    saveFocuserPos(0);
    EEPROM.write(101, 100);      // Dont do this block any more
  } 
  // We rotate focuser pointer storage place to avoid EEPROM damage after 100 000 cycles (0...100)
  focuserPositionPointer = EEPROM.read(102);
  word tempFocus = readFocuserPos();
  focuserPositionPointer += 2;
  if(focuserPositionPointer > 98) focuserPositionPointer = 0;
  EEPROM.write(102, focuserPositionPointer);
  saveFocuserPos(tempFocus);
  currentFocuserPosition = newFocuserPosition = tempFocus;
  
  // Initialize serial
  Serial.begin(9600);
  
  // Initialize temperature sensor
  sensors.begin(); 
  sensors.getAddress(insideThermometer, 0);
  sensors.setResolution(insideThermometer, 10);
  sensors.setWaitForConversion(false);
  tempReadMilis = 0;
  
  // Initialize stepper motor
  stepper.setSpeed(EEPROM.read(STEPPER_SPEED_ADD));
  
  // Initialize encoder pins
  pinMode(encoder0PinA, INPUT); 
  digitalWrite(encoder0PinA, HIGH);       // turn on pullup resistor
  pinMode(encoder0PinB, INPUT); 
  digitalWrite(encoder0PinB, HIGH);       // turn on pullup resistor
  pinMode(encoderButtonPin, INPUT);
  digitalWrite(encoderButtonPin, HIGH);   // turn on pullup resistor
  
  // Buzzer init
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);

  attachInterrupt(0, doEncoder, CHANGE);  // encoder pin on interrupt 0 - pin 2
}
