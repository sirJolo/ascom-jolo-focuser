void writeByte(word address, byte value) {
  if(readByte(address) != value) EEPROM.write(address, value);
}

word readByte(word address) {
  return EEPROM.read(address);   
}

void writeWord(word address, word value) {
  if(readWord(address) != value) {
    EEPROM.write(address, lowByte(value)); 
    EEPROM.write(address + 1, highByte(value)); 
  }
}

word readWord(word address) {
  return word(EEPROM.read(address + 1), EEPROM.read(address));   
}

long readLong(word address) {
  word lowWord = readWord(address);
  word highWord = readWord(address + 2);
  return lowWord + highWord * 65536;
}

void writeLong(word address, long value) {
  word lowWord = value % 65536;
  word highWord = value / 65536;
  writeWord(address, lowWord);
  writeWord(address + 2, highWord);
}

int stringToNumber(String thisString) {
  int i, value = 0, length;
  length = thisString.length();
  for(i=0; i<length; i++) {
    value = (10*value) + thisString.charAt(i)-(int) '0';
  }
  return value;
}

long stringToLong(String thisString) {
  long value = 0;
  int i, length;
  length = thisString.length();
  for(i=0; i<length; i++) {
    value = (10*value) + thisString.charAt(i)-(int) '0';
  }
  return value;
}

String formatFloat(float value, byte length, byte precision) {
  char tmp [length+1];
  dtostrf(value, length, precision, tmp);  
  return String(tmp);
}

String formatLong(long value, byte length) {
  char tmp [length+1];
  dtostrf(value, length, 0, tmp);  
  return String(tmp);
}

int readAnalogAvg(byte pin, byte count) {
  long sum = 0;
  for(byte i = 0; i < count; i++) sum += analogRead(pin);
  return (sum / count); 
}


