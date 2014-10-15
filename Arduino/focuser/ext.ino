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
  updatePWMPin(PWM_PIN6, PROP_PWM6);
  updatePWMPin(PWM_PIN9, PROP_PWM9);
  updatePWMPin(PWM_PIN10, PROP_PWM10);
}

void updatePWMPin(byte pin, int addr) {
  byte value = readByte(addr);
  if(value == 255) value = heaterPWM;
  analogWrite(pin, map(value, 0, 100, 0, 255));
}
