void initializeProperties() {
  if(readByte(PROPERTY_ADDR) == 125) {
    if(DEBUG) {
      Serial.print(millis());
      Serial.println(" - properties exist");    
    }
  } else {
    EepromUtil::eeprom_erase_all();
    writeByte(PROP_STEPPER_SPEED, 100);    
    writeByte(PROP_DUTY_CYCLE_RUN, 100);    
    writeByte(PROP_DUTY_CYCLE_STOP, 0);   
    writeByte(PROP_PWM6, 0);   
    writeByte(PROP_PWM9, 0);
    writeByte(PROP_PWM10, 0);
    writeWord(PROP_ACC_AUTO, 2500);  
    writeWord(PROP_ACC_MAN, 600); 
    char buf[16];
    strcpy(buf, "Jolo Focuser 2.1");
    EepromUtil::eeprom_write_string(PROP_LCD_LINE1, buf);
    strcpy(buf, "pppppp  T:tttttC");
    EepromUtil::eeprom_write_string(PROP_LCD_LINE2, buf);
    writeByte(PROP_BUZZER_ON, 1); 
    writeByte(PROPERTY_ADDR, 125);
    if(DEBUG) {
      Serial.print(millis());
      Serial.print(" - properties created at ");
      Serial.println(PROPERTY_ADDR);
    }    
  }
}

