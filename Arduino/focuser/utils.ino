void saveFocuserPos(long newPos) {
  writeLong(getSaveFocuserPosAddress() + 1, newPos);
}

long readFocuserPos() {
  return readLong(getReadFocuserPosAddress() + 1);
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


// Simple EEPROM wear leveling
int getSaveFocuserPosAddress() {
  for(byte x = 0; x < 20; x++) {
    int address = FOCUSER_POS_START + 5*x;
    if(EEPROM.read(address) == 0) {
      EEPROM.write(address, 0xFF);
      return address;
    }
  } 
  // Array is full, erase it and start from 0 - takes about 100ms
  for(byte x = 0; x < 20; x++) EEPROM.write(FOCUSER_POS_START + 5*x, 0);
  EEPROM.write(FOCUSER_POS_START, 0xFF);
  return FOCUSER_POS_START;
}

int getReadFocuserPosAddress() {
  for(byte x = 0; x < 20; x++) {
    int address = FOCUSER_POS_START + 5*x;
    if(EEPROM.read(address) == 0) return FOCUSER_POS_START + 5 * (x-1);
  }
}


