// Current focuser position storage
void saveFocuserPos(word newPos) {
  int focuserPosAddress = getSaveFocuserPosAddress();
  Serial.print("new foc save addr ");
  Serial.print(focuserPosAddress);
  Serial.print("\n");
  EEPROM.write(focuserPosAddress + 1, lowByte(newPos)); 
  EEPROM.write(focuserPosAddress + 2, highByte(newPos)); 
}

word readFocuserPos() {
  int focuserPosAddress = getReadFocuserPosAddress();
  Serial.print("new foc read addr ");
  Serial.print(focuserPosAddress);
  Serial.print("\n");
  return word(EEPROM.read(focuserPosAddress + 2), EEPROM.read(focuserPosAddress + 1)); 
}


// Convert string to number
long stringToNumber(String value) {
  char charValue[value.length()];
  value.toCharArray(charValue, value.length());  
  return atol(charValue);
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
  // Array is full, erase it and start from 0 - takes about 330ms
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
