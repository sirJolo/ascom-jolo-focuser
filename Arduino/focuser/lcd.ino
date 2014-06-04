/*void lcdWelcome() {
  lcd.setCursor(0,0);
  lcd.print("# Jolo Focuser #");
  lcd.setCursor(0,1);
  lcd.print("# firmware 2.0 #");
}

void lcdStart() {
  timer.every(500, lcdUpdate);
}

void lcdUpdate() {
  String LCD_LINE1 = "mmmmmum   pppppp";
  String LCD_LINE2 = "tttttC hh% ddddd";  
  
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print(lcdReplace(LCD_LINE1));
  lcd.setCursor(0,1);
  lcd.print(lcdReplace(LCD_LINE2));
}


String lcdReplace(String original) {
  original.replace("ttttt", formatFloat(currentTemp, 5, 1)); 
  original.replace("pppppp", formatLong(stepper.currentPosition(), 6)); 
  original.replace("mmmmm", formatFloat(stepper.currentPosition() / 301.7, 5, 2)); 
  original.replace("hh", formatLong(currentHum, 2)); 
  if(original.indexOf("ddddd") != -1) {
    original.replace("ddddd", formatFloat(dewPoint(currentTemp, currentHum), 5, 1)); 
  }
  return original;
}*/
