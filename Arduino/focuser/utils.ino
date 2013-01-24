// Current focuser position storage
void saveFocuserPos(word newPos) {
  EEPROM.write(EEPROM.read(FOCUSER_POINTER_ADD), lowByte(newPos)); 
  EEPROM.write(EEPROM.read(FOCUSER_POINTER_ADD) + 1, highByte(newPos)); 
}
word readFocuserPos() {
  return word(EEPROM.read(EEPROM.read(FOCUSER_POINTER_ADD) + 1), EEPROM.read(EEPROM.read(FOCUSER_POINTER_ADD))); 
}


// Convert string to number
long stringToNumber(String value) {
  char charValue[value.length()];
  value.toCharArray(charValue, value.length());  
  return atol(charValue);
}

