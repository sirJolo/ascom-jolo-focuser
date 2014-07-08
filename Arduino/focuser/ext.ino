void initializeExt() {
  // OPT init
  pinMode(OPTO_PIN, OUTPUT);
  digitalWrite(OPTO_PIN, LOW);
  
  // PWM init
  pinMode(PWM_PIN6, OUTPUT);
  digitalWrite(PWM_PIN6, LOW);
  pinMode(PWM_PIN9, OUTPUT);
  digitalWrite(PWM_PIN9, LOW);
  pinMode(PWM_PIN10, OUTPUT);
  digitalWrite(PWM_PIN10, LOW);
  
  // ADC pin
  pinMode(ADC_PIN, INPUT);
  
  // EXT init
  pinMode(12, INPUT);
}  

void updatePWM() {
  calculateHeaterPWM();
  updatePWMPin(PWM_PIN6, map(readByte(PROP_PWM6), 0, 100, 0, 255));
  updatePWMPin(PWM_PIN9, map(readByte(PROP_PWM9), 0, 100, 0, 255));
  updatePWMPin(PWM_PIN10, map(readByte(PROP_PWM10), 0, 100, 0, 255));
}

void updatePWMPin(byte pin, byte value) {
  if(value == 255) value = heaterPWM;
  analogWrite(pin, value);
}
