// Initialization routine
void setup() 
{
  if(EEPROM.read(101) != 100)
  {
    // Do it here only once
    EEPROM.write(MANUAL_STEP_ADD, 16);
    EEPROM.write(STEPPER_SPEED_ADD, 100);
    EEPROM.write(DUTY_CYCLE_ADDR, 0);
    EEPROM.write(FOCUSER_POINTER_ADD, 0);        //Pointer to current focuser position storage value
    saveFocuserPos(0);
    EEPROM.write(101, 100);      // Dont do this block any more
  } 
  // We rotate focuser pointer storage place to avoid EEPROM damage after 100 000 cycles (0...100)
  byte focuserPositionPointer = EEPROM.read(FOCUSER_POINTER_ADD);
  currentFocuserPosition = readFocuserPos();
  focuserPositionPointer += 2;
  if(focuserPositionPointer > 98) focuserPositionPointer = 0;
  EEPROM.write(FOCUSER_POINTER_ADD, focuserPositionPointer);
  saveFocuserPos(currentFocuserPosition);
  
  // Initialize serial
  Serial.begin(9600);
  Serial.setTimeout(2000);
  
  // Initialize temperature sensor
  sensors.begin(); 
  sensorConnected = sensors.getAddress(insideThermometer, 0);
  if(sensorConnected) {
    sensors.setResolution(insideThermometer, 10);
    sensors.setWaitForConversion(false);
    tempReadMilis = 0;
  }
  
  // Initialize stepper motor
  stepper.setMaxSpeed(EEPROM.read(STEPPER_SPEED_ADD) / 60 * STEPS);
  stepper.setAcceleration(STEPPER_ACCELERATION);
  stepper.disableOutputs();
  stepper.setCurrentPosition(currentFocuserPosition);
  
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
