void initializeExt() {
  
  // PWM init
  pinMode(PWM1_PIN, OUTPUT);
  digitalWrite(PWM1_PIN, LOW);
  pinMode(PWM2_PIN, OUTPUT);
  digitalWrite(PWM2_PIN, LOW);
  pinMode(PWM3_PIN, OUTPUT);
  digitalWrite(PWM3_PIN, LOW);
  
  // ADC pin
  pinMode(ADC_PIN, INPUT);
}  

void updatePWM() {
  calculateHeaterPWM();
  updatePWMPin(PWM1_PIN, ctx.pwm1);
  updatePWMPin(PWM2_PIN, ctx.pwm2);
  updatePWMPin(PWM3_PIN, ctx.pwm3);
}

void updatePWMPin(byte pin, byte value) {
  analogWrite(pin, map(((value == 255) ? sensor.heaterPWM : value), 0, 100, 0, 255));
}

String readPWM(byte value) {
  return formatLong(((value == 255) ? sensor.heaterPWM : value), 3);
}


