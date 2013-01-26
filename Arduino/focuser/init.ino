// Initialization routine
void setup() 
{
  if(EEPROM.read(1) != 100)
  {
    // Do it here only once
    EEPROM.write(MANUAL_STEP_ADD, 16);
    EEPROM.write(STEPPER_SPEED_ADD, 100);
    EEPROM.write(DUTY_CYCLE_ADDR, 0);
    for(byte x = 0; x < 30; x++) EEPROM.write(FOCUSER_POS_START + 3*x, 0);
    saveFocuserPos(0);
    EEPROM.write(1, 100);      // Dont do this block any more
  } 
  
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
    currentTemp = -127;
    tempRequestMilis = millis() + TEMP_CYCLE;
  }
  
  // Initialize stepper motor
  stepper.setMaxSpeed(EEPROM.read(STEPPER_SPEED_ADD) / 60 * STEPS);
  stepper.setAcceleration(STEPPER_ACCELERATION);
  stepper.disableOutputs();
  stationaryFocuserPosition = readFocuserPos();
  stepper.setCurrentPosition(stationaryFocuserPosition);
  
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
