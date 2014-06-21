void initializeProperties() {
  if(EEPROM.read(PROPERTY_ADDR) == 125) {
    // properties initialized :)
  } else {
    EepromUtil::eeprom_erase_all();
    EEPROM.write(PROP_STEPPER_SPEED, 100);    
    EEPROM.write(PROP_DUTY_CYCLE_RUN, 100);    
    EEPROM.write(PROP_DUTY_CYCLE_STOP, 0);    
    writeWord(PROP_ACC_AUTO, 2500);  
    writeWord(PROP_ACC_MAN, 600); 
    char buf[16];
    strcpy(buf, "Jolo Focuser 2.1");
    EepromUtil::eeprom_write_string(PROP_LCD_LINE1, buf);
    strcpy(buf, "pppppp  T:tttttC");
    EepromUtil::eeprom_write_string(PROP_LCD_LINE2, buf);
    EEPROM.write(PROP_BUZZER_ON, 1); 
    EEPROM.write(PROPERTY_ADDR, 125);
  }
}

