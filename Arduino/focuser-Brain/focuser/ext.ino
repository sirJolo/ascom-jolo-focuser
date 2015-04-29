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
}  

void updatePWM() {
  for(byte i = 0; i < 4; i++) {
    analogWrite(pwmPins[i], map(pwmValues[i], 0, 100, 0, 255));
  }
}

