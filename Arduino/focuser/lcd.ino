void updateLcd() {
  char tempBuf[5];
  dtostrf(currentTemp, 5, 1, tempBuf);
  
  //char posBuf[6];
  //sprintf(posBuf, "%6d", stepper.currentPosition());
  
  String line1 = String(LCD_LINE_1);
  line1.replace("<ttt>", String(tempBuf));
  String line2 = String(LCD_LINE_2);
  line2.replace("<pppp>", String(stepper.currentPosition()));
  
  lcd.setCursor(0,0);
  lcd.print(line1);
  lcd.setCursor(0,1);
  lcd.print(line2);
}


