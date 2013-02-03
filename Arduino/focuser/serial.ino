// Interrupt serial event
void serialEvent() {
  while (Serial.available() > 0) {
    char inChar = (char)Serial.read(); 
    if (inChar == '\n') 
      serialCommand(inputString); 
    else
      inputString += inChar;
  }  
}
  
void serialCommand(String command) {
  String param = String(command).substring(2);
  switch(command.charAt(0)) {
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
      Serial.print(byte(command.charAt(1)), DEC); 
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
  }
}

void readTemp() {
  currentTemp = sensors.getTempC(insideThermometer);
  tempRequestMilis = millis() + TEMP_CYCLE;
  tempReadMilis = 0;
}

void printTemp() {
  if(sensorConnected) {
    Serial.print("T:");
    Serial.print(currentTemp, 1);  
    Serial.print('\n');
  } else {
    Serial.print("T:false\n"); 
  }  
}

void printCurrentPosition() {
  Serial.print("P:");
  Serial.print(stepper.currentPosition());
  Serial.print('\n'); 
}

void printInMoveStatus() {
  Serial.print("I:");
  if(stepper.distanceToGo() == 0) 
    Serial.print("false");
  else
    Serial.print("true");
  Serial.print('\n'); 
}

void moveStepper(word newPos) {
  stepper.moveTo(newPos);
  positionSaved = false;
  Serial.print("M\n");
}

void halt() {
  stepper.stop();
  Serial.print("H\n");
}

void saveStepperSpeed(byte stepperSpeed) {
  EEPROM.write(STEPPER_SPEED_ADD, stepperSpeed);
  stepper.setMaxSpeed(EEPROM.read(STEPPER_SPEED_ADD));
  Serial.print("S\n");
}

void saveDutyCycle(byte dutyCycle) {
  EEPROM.write(DUTY_CYCLE_ADDR, dutyCycle);
  Serial.print("D\n");
}


