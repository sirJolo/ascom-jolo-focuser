// Interrupt serial event
void serialEvent()
{
  if(Serial.available() > 2) {
    char buffer[10];
    byte len = Serial.readBytesUntil('\n', buffer, 10);
   
    if(len > 3) {
      String command = String(buffer).substring(2);
      switch(buffer[0]) {
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
      }
     if(buffer[0] != 'T') Serial.print('\n');   // Temperature read is async and provides its own line ending
    }
  }  
}




// Serial commands subroutines
void requestTemp() {
  if(sensorConnected) {
    sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperature. For 10 bit res it takes 188ms
    tempReadMilis = millis() + 188;
  } else {
    Serial.print("T:false" + '\n'); 
  }
}

void printTemp() {
  Serial.print("T:");
  Serial.print(sensors.getTempC(insideThermometer), 1);  
  Serial.print('\n'); 
  tempReadMilis = 0;
}

void printCurrentPosition() {
  Serial.print("P:");
  Serial.print(currentFocuserPosition);
}

void printInMoveStatus() {
  Serial.print("I:");
  if(stepper.distanceToGo() == 0) 
    Serial.print("false");
  else
    Serial.print("true");
}

void moveStepper(word focuserPosition) {
  stepper.enableOutputs();
  stepper.moveTo(focuserPosition);
  Serial.print("M");
}

void halt() {
  stepper.stop();
  Serial.print("H");
}

void saveStepperSpeed(byte stepperSpeed) {
  EEPROM.write(STEPPER_SPEED_ADD, stepperSpeed);
  stepper.setMaxSpeed(EEPROM.read(STEPPER_SPEED_ADD) / 60 * STEPS);
  Serial.print("S");
}

