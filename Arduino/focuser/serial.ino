// Interrupt serial event
void serialEvent() {
  while (Serial.available()) {
    char inChar = (char)Serial.read(); 
    if (inChar == '\n') {
      serialCommand(inputString);
    } 
    inputString += inChar;
  }  
}
  
void serialCommand(String command) {
  String param = String(command).substring(3);
  switch(command.charAt(1)) {
    case '#':
      Serial.print("*\n");
      break;
    case 'T':    // Read temperature
      printTemp();
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
      moveStepper(stringToNumber(param)); 
      break;
    case 'S':
      saveStepperSpeed(stringToNumber(param));
      break;
    case 'D':
      saveDutyCycle(stringToNumber(param));
      break;
    default:
      Serial.print("ERR:");      
      Serial.print(command); 
      Serial.print('\n');
  }
  
  inputString = "";
}
  

// Serial commands subroutines
void requestTemp() {
  if(sensorConnected) {
    sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperature. For 10 bit res it takes 188ms
    tempReadMilis = millis() + 188;
    tempRequestMilis = 0;
  } else {
    Serial.print("T:false\n"); 
  }  
}

void readTemp() {
  currentTemp = sensors.getTempC(insideThermometer);
  tempRequestMilis = millis() + TEMP_CYCLE;
  tempReadMilis = 0;
}

void printTemp() {
  Serial.print("T:");
  Serial.print(currentTemp, 1);  
  Serial.print('\n'); 
}

void printCurrentPosition() {
  word pos = focuserPosition + stepper.stepsLeft();
  Serial.print("P:");
  Serial.print(pos);
  Serial.print('\n'); 
}

void printInMoveStatus() {
  Serial.print("I:");
  if(stepper.stepsLeft() == 0) 
    Serial.print("false");
  else
    Serial.print("true");
  Serial.print('\n'); 
}

void moveStepper(word newPos) {
  newFocuserPosition = newPos;
  stepper.step(newFocuserPosition - focuserPosition);
  Serial.print("M\n");
}

void halt() {
  stepper.halt();
  Serial.print("H\n");
}

void saveStepperSpeed(byte stepperSpeed) {
  EEPROM.write(STEPPER_SPEED_ADD, stepperSpeed);
  stepper.setSpeed(EEPROM.read(STEPPER_SPEED_ADD));
  Serial.print("S\n");
}

void saveDutyCycle(byte dutyCycle) {
  EEPROM.write(DUTY_CYCLE_ADDR, dutyCycle);
  Serial.print("D\n");
}


