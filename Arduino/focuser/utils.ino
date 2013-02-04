// Current focuser position storage
void saveFocuserPos(word newPos) {
  writeWord(getSaveFocuserPosAddress() + 1, newPos);
}

word readFocuserPos() {
  return readWord(getReadFocuserPosAddress() + 1);
}


void writeWord(word address, word value) {
  EEPROM.write(address, lowByte(value)); 
  EEPROM.write(address + 1, highByte(value)); 
}

word readWord(word address) {
  return word(EEPROM.read(address + 1), EEPROM.read(address));   
}


int stringToNumber(String thisString) {
  int i, value = 0, length;
  length = thisString.length();
  for(i=0; i<length; i++) {
    value = (10*value) + thisString.charAt(i)-(int) '0';
  }
  return value;
}


// Simple EEPROM wear leveling
int getSaveFocuserPosAddress() {
  for(byte x = 0; x < 30; x++) {
    int address = FOCUSER_POS_START + 3*x;
    if(EEPROM.read(address) == 0) {
      EEPROM.write(address, 0xFF);
      return address;
    }
  } 
  // Array is full, erase it and start from 0 - takes about 100ms
  for(byte x = 0; x < 30; x++) EEPROM.write(FOCUSER_POS_START + 3*x, 0);
  EEPROM.write(FOCUSER_POS_START, 0xFF);
  return FOCUSER_POS_START;
}

int getReadFocuserPosAddress() {
  for(byte x = 0; x < 30; x++) {
    int address = FOCUSER_POS_START + 3*x;
    if(EEPROM.read(address) == 0) return FOCUSER_POS_START + 3 * (x-1);
  }
}

void debug(String message) {
  Serial.print(message);
  Serial.print('\n');
}


