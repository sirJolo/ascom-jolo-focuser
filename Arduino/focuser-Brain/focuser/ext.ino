void initializeExt() {
  expander.begin(0x20);
  expander.pinMode(0, OUTPUT);
  expander.pinMode(1, OUTPUT);
  expander.pinMode(2, OUTPUT);
  expander.pinMode(3, OUTPUT);
  expander.pinMode(4, OUTPUT);
  expander.pinMode(5, OUTPUT);
  expander.pinMode(6, OUTPUT);
  expander.pinMode(7, OUTPUT);
  expander.clear();
}  

void updatePWMPin(byte pin, int addr) {
  byte value = readByte(addr);
  if(value == 255) value = 0;
  analogWrite(pin, map(value, 0, 100, 0, 255));
}
