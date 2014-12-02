void initializeExt() {
  // PWM init
  pinMode(PWM1_PIN, OUTPUT);
  digitalWrite(PWM1_PIN, LOW);
  pinMode(PWM2_PIN, OUTPUT);
  digitalWrite(PWM2_PIN, LOW);
  pinMode(PWM3_PIN, OUTPUT);
  digitalWrite(PWM3_PIN, LOW);
  pinMode(PWM4_PIN, OUTPUT);
  digitalWrite(PWM4_PIN, LOW);
  
  DeviceStatus.pwmValues[0] = 0;
  DeviceStatus.pwmValues[1] = 0;
  DeviceStatus.pwmValues[2] = 0;
  DeviceStatus.pwmValues[3] = 0;
}  

void initializeBuzzer() {
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
}  

void buzz(byte buzzTime, byte buzzCount) {
  if(readByte(PROP_BUZZER_ON) != 0) timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
}
