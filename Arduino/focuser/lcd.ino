void initializeLCD() {
  lcd.begin(16,2);   
  lcd.home();  
  lcd.print("Jolo Focuser 2.1");
  lcd.setCursor(0,1);
  lcd.print("   2014-07-10   ");
  
  lcdCycleEvent = timer.every(LCD_REFRESH, lcdUpdateQuick);
  if(DEBUG) {
    Serial.print(millis());
    Serial.println(" - LCD initialized");
  }
}

// pppppp - position steps, pp.ppp - position mm
// ttt.t - temp, hhh - humidity, ddd.d - dew point
// pw6 - pwm pin 6, pw9, pw0 - similar
// a.aa - ADC rescaled to 5V

void lcdUpdateQuick() {
  // dont clear, write char by char, make sure template has whitespaces, run stepper
  char buf[20];
  stepper.run();
  EepromUtil::eeprom_read_string(PROP_LCD_LINE1, buf, 17);
  String line = replaceLCD(String(buf));
  lcd.setCursor(0,0);
  for(byte i = 0; i < 16; i++) {
    stepper.run();
    lcd.print(line.charAt(i));    
  }
  stepper.run();
  EepromUtil::eeprom_read_string(PROP_LCD_LINE2, buf, 17);
  line = replaceLCD(String(buf));
  lcd.setCursor(0,1);
  for(byte i = 0; i < 16; i++) {
    stepper.run();
    lcd.print(line.charAt(i));    
  }
}

String replaceLCD(String line) {
  if(line.indexOf("pppppp") > -1) {
    line.replace("pppppp", formatLong(stepper.currentPosition(), 6));
  }
  if(line.indexOf("pp.ppp") > -1) {
    line.replace("pp.ppp", formatFloat(((float) stepper.currentPosition() * readWord(PROP_STEP_SIZE) / 10000), 6, 3));
  }
  if(line.indexOf("ttt.t") > -1) {
    line.replace("ttt.t", formatFloat(currentTemp, 5, 1));
  }
  if(line.indexOf("hhh") > -1) {
    line.replace("hhh", formatLong(currentHum, 3));
  }
  if(line.indexOf("ddd.d") > -1) {
    line.replace("ddd.d", formatFloat(currentDewpoint, 5, 1));
  }
  return line;
}
