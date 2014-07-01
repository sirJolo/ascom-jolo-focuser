void initializeSerial() {
  // Initialize serial
  Serial.begin(9600);
  Serial.setTimeout(2000);

  inputString = "";
  if(DEBUG) {
    Serial.print(millis());
    Serial.println(" - serial initialized....");
  }
}  

// Interrupt serial event
void serialEvent() {
  while (Serial.available() > 0) {
    char inChar = (char)Serial.read(); 
    if (inChar == '\n') {
      serialCommand(inputString); 
      inputString = "";
    } 
    else {
      inputString += inChar;
    }
  }  
}

void serialCommand(String command) {
  String param = command.substring(2); 

  switch(command.charAt(0)) {
  case '#':
    Serial.print(DEVICE_RESPONSE);
    buzz(500, 1);
    break;
  case 'T':    // Read temperature
    printTemp();
    break;
  case 'V':    // Read monitor
    printMonitor();
    break;
  case 'P':    // Return current position
    printCurrentPosition();
    break;
  case 'H':    // Halt focuser
    halt();   
    break;
  case 'I':
    printInMoveStatus();
    break;
  case 'M':    // Move focuser to new position
    moveStepper(stringToLong(param)); 
    Serial.print("M");
    break;
  case 'A':
    printADC();
    break;
  case 'N':
    setPWM(param);
    break;
  case 'K':
    readPWM(param);
    break;
  case 'O':
    setOpto(stringToNumber(param));
    break;
  case 'S':
    saveStepperSpeed(stringToNumber(param));
    break;
  case 'D':
    saveDutyCycle(stringToNumber(param));
    break;
  case 'E':
    saveDutyCycleRun(stringToNumber(param));
    break;
  case 'F':
    saveAccAuto(stringToNumber(param));
    break;
  case 'G':
    saveAccManual(stringToNumber(param));
    break;
  case 'J':
    saveBuzzerOn(stringToNumber(param));
    break;
  case 'R':
    saveCurrentPos(stringToLong(param));
    break;
  case 'C':
    saveLCD1(param);
    break;
  case 'B':
    saveLCD2(param);
    break;
  case 'Q':
    saveStepSize(stringToNumber(param));
    break;
  case 'X':
    maxFocuserPos = stringToLong(param);
    Serial.print("X");
    break;
  default:
    Serial.print("ERR:");      
    Serial.print(byte(command.charAt(1)), DEC); 
    buzz(100, 3);
  }
  Serial.print('\n');
}

// Serial commands subroutines
void printTemp() {
  if(sensorType > 0) {
    Serial.print("T:");
    Serial.print(currentTemp, 1);  
  } 
  else {
    Serial.print("T:false"); 
  }  
}

void printMonitor() {      // Position, temp, hum, dewpoint
  if(sensorType > 0) {
    Serial.print("V:");
    Serial.print(currentTemp, 1); 
    Serial.print(":");
    currentHum = 76;
    Serial.print(currentHum, 0);  
    Serial.print(":");
    currentDewpoint = 16.7;
    Serial.print(currentDewpoint, 1);
  } 
  else {
    Serial.print("V:false"); 
  }  
}

void printADC() {
  Serial.print("A:");
  Serial.print(analogRead(ADC_PIN));
}

void setPWM(String param) {
  byte pwm = stringToNumber(param.substring(2));
  switch(param.charAt(0)) {
   case '6': writeByte(PROP_PWM6, pwm); break;
   case '9': writeByte(PROP_PWM9, pwm); break;
   case '0': writeByte(PROP_PWM10, pwm); break;
  }
  updatePWM();
  Serial.print("N");
}

void readPWM(String param) {
  Serial.print("K:");
  switch(param.charAt(0)) {
    case '6': Serial.print(readByte(PROP_PWM6)); break;
    case '9': Serial.print(readByte(PROP_PWM9)); break;
    case '0': Serial.print(readByte(PROP_PWM10)); break;
  }
}

void setOpto(byte value) {
  digitalWrite(OPTO_PIN, value);
  Serial.print("O");
}
  
void printCurrentPosition() {
  Serial.print("P:");
  Serial.print(stepper.currentPosition());
}

void printInMoveStatus() {
  Serial.print("I:");
  if(stepper.distanceToGo() == 0) 
    Serial.print("false");
  else
    Serial.print("true");
}

void halt() {
  stepper.stop();
  Serial.print("H");
}

void saveCurrentPos(long newPos) {
  stepper.setCurrentPosition(newPos);
  positionSaved = true;
  saveFocuserPos(newPos);
  Serial.print("R");
}

void saveStepperSpeed(word stepperSpeed) {
  writeWord(PROP_STEPPER_SPEED, stepperSpeed);
  stepper.setMaxSpeed(readWord(PROP_STEPPER_SPEED));
  Serial.print("S");
}

void saveDutyCycle(byte dutyCycle) {
  if(dutyCycle > 100) dutyCycle = 100;
  writeByte(PROP_DUTY_CYCLE_STOP, dutyCycle);
  Serial.print("D");
}

void saveDutyCycleRun(byte dutyCycle) {
  if(dutyCycle > 100) dutyCycle = 100;
  writeByte(PROP_DUTY_CYCLE_RUN, dutyCycle);
  Serial.print("E");
}  

void saveAccAuto(int acc) {
  writeWord(PROP_ACC_AUTO, acc);
  Serial.print("F");
}  

void saveAccManual(int acc) {
  writeWord(PROP_ACC_MAN, acc);
  Serial.print("G");
}  

void saveBuzzerOn(byte param) {
  writeByte(PROP_BUZZER_ON, param);
  Serial.print("J");
}

void saveLCD1(String param) {
  char oldValue[17], newValue[17];
  EepromUtil::eeprom_read_string(PROP_LCD_LINE1, oldValue, 17);
  if(strcmp(oldValue, newValue) != 0) {
    param.toCharArray(newValue, 17);
    EepromUtil::eeprom_write_string(PROP_LCD_LINE1, newValue);   
  }
  Serial.print("C");
}

void saveLCD2(String param) {
  char oldValue[17], newValue[17];
  EepromUtil::eeprom_read_string(PROP_LCD_LINE2, oldValue, 17);
  if(strcmp(oldValue, newValue) != 0) {
    param.toCharArray(newValue, 17);
    EepromUtil::eeprom_write_string(PROP_LCD_LINE2, newValue);   
  }
  Serial.print("B");
}

void saveStepSize(int step) {
  writeWord(PROP_STEP_SIZE, step);
  Serial.print("Q");
}
