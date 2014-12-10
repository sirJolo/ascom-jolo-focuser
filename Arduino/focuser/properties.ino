void initializeProperties() {
  if(readByte(PROPERTY_ADDR) != 125) {
    EepromUtil::eeprom_erase_all();
    writeByte(PROP_STEPPER_SPEED, 100);    
    writeByte(PROP_DUTY_CYCLE_RUN, 100);    
    writeByte(PROP_DUTY_CYCLE_STOP, 0);   
    writeByte(PROP_PWM6, 0);   
    writeByte(PROP_PWM9, 0);
    writeByte(PROP_PWM10, 0);
    writeWord(PROP_ACC_AUTO, 2500);  
    writeWord(PROP_ACC_MAN, 600);
    writeByte(PROP_BUZZER_ON, 1); 
    writeLong(PROP_MAX_FOC_POS, 1000000);
    writeByte(PROPERTY_ADDR, 125);
  }
}

