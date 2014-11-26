void initializeProperties() {
  if(readByte(PROPERTY_ADDR) != 125) {
    EepromUtil::eeprom_erase_all();
    writeByte(PROP_BUZZER_ON, 1); 
    writeByte(PROPERTY_ADDR, 125);
  }
}

