void initializeLCD() {
  lcd.begin(16,2);   
  lcd.home();  
  lcd.print("Jolo Focuser 2.1");
  lcd.setCursor(0,1);
  lcd.print("   2014-07-12   ");
  
  lcdCycleEvent = timer.every(LCD_REFRESH, lcdUpdateQuick);
}

//    1234567890123456
//01  000123  12.345mm
//02  Temp:     -12.4C
//11  000123  12.345mm
//12  100%-12.3/-18.7C
//21  PWM  6    9   10
//22    100% 100% 100%
//31  ADC=1024   3.45V
//32  OPTO:H   345677s
  
void lcdUpdateQuick() {
  if(readLong(PROP_LCD_SCREEN_0) == 0) return;            // all 4 screens are 0, so do not display
  while(readByte(PROP_LCD_SCREEN_0 + LCDscreen) == 0) {   // rotate through displays with 0 display time
    LCDscreen++;
    if(LCDscreen == 4) LCDscreen = 0;
  }
  switch (LCDscreen) {
   case 0: 
     displayScreen0(); 
     if(lcdCycle == 0) lcdCycle = (1000 / LCD_REFRESH) * readByte(PROP_LCD_SCREEN_0);
     break; 
   case 1: 
     displayScreen1(); 
     if(lcdCycle == 0) lcdCycle = (1000 / LCD_REFRESH) * readByte(PROP_LCD_SCREEN_1);
     break; 
   case 2: 
     displayScreen2(); 
     if(lcdCycle == 0) lcdCycle = (1000 / LCD_REFRESH) * readByte(PROP_LCD_SCREEN_2);
     break; 
   case 3: 
     displayScreen3(readAnalogAvg(ADC_PIN, 3)); 
     if(lcdCycle == 0) lcdCycle = (1000 / LCD_REFRESH) * readByte(PROP_LCD_SCREEN_3);
     break; 
  }
  lcdCycle--;
  if(lcdCycle <= 0) {
    LCDscreen++;
    lcdCycle = 0;
  }
  if(LCDscreen >= 4) LCDscreen = 0;
}

void displayScreen0() {
  String line1 = formatLong(stepper.currentPosition(), 6) + "  " + formatFloat(((float) stepper.currentPosition() * readWord(PROP_STEP_SIZE) / 10000), 6, 3) + "mm";
  String line2 = "Temp:     " + formatFloat(currentTemp, 5, 1) + "C";
  lcdUpdateLCD(line1, line2);
}

void displayScreen1() {
  String line1 = formatLong(stepper.currentPosition(), 6) + "  " + formatFloat(((float) stepper.currentPosition() * readWord(PROP_STEP_SIZE) / 10000), 6, 3) + "mm";
  String line2 = formatLong(currentHum, 3) + "%" + formatFloat(currentDewpoint, 5, 1) + "/" + formatFloat(currentTemp, 5, 1) + "C";
  lcdUpdateLCD(line1, line2);
}

void displayScreen2() {
  String line1 = "PWM  6    9   10";
  String line2 = "  " + readPWM(PROP_PWM6) + "% " + readPWM(PROP_PWM9) + "% " + readPWM(PROP_PWM10) + "%";
  lcdUpdateLCD(line1, line2);
}

void displayScreen3(int adcValue) {
  float adcScaled = 0.00488 * adcValue;
  String line1 = "ADC=" + formatLong(adcValue, 4) + "   " + formatFloat(adcScaled, 4, 2) + "V";
  String line2 = "OPTO:" + String(digitalRead(OPTO_PIN)) + "   " + formatLong(millis()/1000, 6) + "s";
  lcdUpdateLCD(line1, line2);
}

void lcdUpdateLCD(String line1, String line2) {
  stepper.run();
  lcd.setCursor(0,0);
  for(byte i = 0; i < 16; i++) {
    stepper.run();
    lcd.print(line1.charAt(i));  
  }  
  stepper.run();
  lcd.setCursor(0,1);
  for(byte i = 0; i < 16; i++) {
    stepper.run();
    lcd.print(line2.charAt(i));  
  }    
}

String readPWM(int addr) {
  byte pwm = readByte(addr);
  if(pwm == 255) pwm = heaterPWM;
  return formatLong(pwm, 3);
}
