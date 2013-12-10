// Initialization routine
void setup() 
{
  // Initialize push buttons 
  pinMode(ENCODER_OUT_PIN, INPUT); 
  pinMode(ENCODER_IN_PIN, INPUT); 
  // Turn on pullup resistors
  digitalWrite(ENCODER_OUT_PIN, HIGH);
  digitalWrite(ENCODER_IN_PIN, HIGH);

  // Buzzer init
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
  
  // OPT init
  pinMode(A0, OUTPUT);
  digitalWrite(A0, LOW);
  
  // EXT init
  pinMode(7, INPUT);
  pinMode(8, INPUT);
  pinMode(9, INPUT);
  pinMode(10, INPUT);
  pinMode(A6, INPUT);
  pinMode(A7, INPUT);
  
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
    tempRequestMilis = millis() + 2000;
  }

  // Initialize stepper motor
  stepper.setMaxSpeed(readWord(STEPPER_SPEED_ADD));
  stepper.setAcceleration(STEPPER_ACC);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  pinMode(STEPPER_PWM_PIN, OUTPUT);
  analogWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
  
  inputString = "";
  buzz(BUZZ_LONG, 1);
}

