void saveFocuserPos(long newPos) {
  writeLong(getSaveFocuserPosAddress() + 1, newPos);
}

long readFocuserPos() {
  return readLong(getReadFocuserPosAddress() + 1);
}

void writeWord(word address, word value) {
  EEPROM.write(address, lowByte(value)); 
  EEPROM.write(address + 1, highByte(value)); 
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

void requestTemp() {
  if(sensorConnected) {
    sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperature. For 10 bit res it takes 188ms
    tempReadMilis = millis() + 188;
    tempRequestMilis = 0;
  }
}

void readTemp() {
  currentTemp = sensors.getTempC(insideThermometer);
  tempRequestMilis = millis() + TEMP_CYCLE;
  tempReadMilis = 0;
}
