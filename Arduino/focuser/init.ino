// Initialization routine
void setup() 
{
  InitTimersSafe();

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
    tempRequestMilis = millis();
  }

  // Initialize stepper motor
  stepper.setMaxSpeed(readWord(STEPPER_SPEED_ADD));
  stepper.setAcceleration(STEPPER_ACC);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  pinMode(STEPPER_PWM_PIN, OUTPUT);
  SetPinFrequencySafe(STEPPER_PWM_PIN, STEPPER_PWM_FREQ);
  pwmWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));

  // Initialize encoder 
  pinMode(ENCODER_A_PIN, INPUT); 
  pinMode(ENCODER_B_PIN, INPUT); 
  pinMode(ENCODER_BUTTON_PIN, INPUT);
 // turn on pullup resistors
  digitalWrite(ENCODER_A_PIN, HIGH);
  digitalWrite(ENCODER_B_PIN, HIGH);
  digitalWrite(ENCODER_BUTTON_PIN, HIGH);

  // Buzzer init
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);

  inputString = "";
}

