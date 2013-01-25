// Interrupt serial event
void serialEvent()
{
  if(Serial.available() > 1) {
    char buffer[10];
    byte len = Serial.readBytesUntil('\n', buffer, 10);
   
    if(len > 0) {
      String command = String(buffer).substring(2);
      switch(buffer[0]) {
        case '#':
          Serial.print("*\n");
          break;
        case 'T':    // Read temperature
          requestTemp();
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
          moveStepper(stringToNumber(command)); 
          break;
        case 'S':
          saveStepperSpeed(stringToNumber(command));
          break;
        default:
          Serial.print("ERR:");      
          Serial.print(buffer); 
          Serial.print('\n');
      }
    }
  }  
}

// Serial commands subroutines
void requestTemp() {
  if(sensorConnected) {
    sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperature. For 10 bit res it takes 188ms
    tempReadMilis = millis() + 180;
  } else {
    Serial.print("T:false\n"); 
  }  
}

void printTemp() {
  Serial.print("T:");
  Serial.print(sensors.getTempC(insideThermometer), 3);  
  Serial.print('\n'); 
  tempReadMilis = 0;
}

void printCurrentPosition() {
  Serial.print("P:");
  Serial.print(currentFocuserPosition);
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

void moveStepper(word focuserPosition) {
  stepper.enableOutputs();
  stepper.moveTo(focuserPosition);
  Serial.print("M\n");
}

void halt() {
  stepper.stop();
  Serial.print("H\n");
}

void saveStepperSpeed(byte stepperSpeed) {
  EEPROM.write(STEPPER_SPEED_ADD, stepperSpeed);
  stepper.setMaxSpeed(EEPROM.read(STEPPER_SPEED_ADD) / 60 * STEPS);
  Serial.print("S\n");
}

