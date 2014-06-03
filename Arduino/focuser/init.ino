// Initialization routine
void setup() 
{
  InitTimersSafe();

  // LCD init
  lcd.begin(16,2); 
  lcdWelcome();
  timer.after(2000,lcdStart);
  

  // Initialize encoder 
  pinMode(ENCODER_A_PIN, INPUT); 
  pinMode(ENCODER_B_PIN, INPUT); 
  // turn on pullup resistors
  digitalWrite(ENCODER_A_PIN, HIGH);
  digitalWrite(ENCODER_B_PIN, HIGH);

  // Buzzer init
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
  
  // OPT init
  pinMode(A0, OUTPUT);
  digitalWrite(A0, LOW);
  
  // EXT init
  pinMode(A1, INPUT);
  
  // Initialize serial
  Serial.begin(9600);
  Serial.setTimeout(2000);

  // Initialize temperature sensor
  sensors.begin(); 
  boolean sensorConnected = sensors.getAddress(insideThermometer, 0);
  if(sensorConnected) {
    sensors.setResolution(insideThermometer, 10);
    sensors.setWaitForConversion(false);
    sensorType=1;
  } else {
    int chk = DHT.read11(TEMP_SENSOR_PIN);
    if(chk == DHTLIB_OK) {
      sensorType = 2;
    } else {
      chk = DHT.read22(TEMP_SENSOR_PIN);
      if(chk == DHTLIB_OK) {
        sensorType = 3;
      }
    }
  }
  if(sensorType > 0) tempCycleEvent = timer.after(2000, requestTemp);

  // Initialize stepper motor
  stepper = AccelStepper(AccelStepper::HALF4WIRE, A5, A4, A3, A2);  
  stepper.setMaxSpeed(readWord(STEPPER_SPEED_ADD));
  stepper.setAcceleration(STEPPER_ACC);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  
  SetPinFrequencySafe(STEPPER_PWM_PIN, STEPPER_PWM_FREQ);
  pwmWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));

  inputString = "";
}

