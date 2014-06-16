void initializeStepper() {
  stepper = AccelStepper(AccelStepper::HALF4WIRE, A5, A4, A3, A2);  
  //stepper = AccelStepper(AccelStepper::DRIVER, A3, A2);  
  stepper.setMaxSpeed(readWord(STEPPER_SPEED_ADD));
  stepper.setAcceleration(STEPPER_ACC);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  pinMode(MSI1_PIN, OUTPUT);
  digitalWrite(MSI1_PIN, LOW);
  pinMode(MSI2_PIN, OUTPUT);
  digitalWrite(MSI2_PIN, HIGH);
}


void checkStepper() {
  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(20, 1);
    analogWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
    //analogWrite(STEPPER_PWM_PIN, (255 - 255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
    tempCycleEvent = timer.after(TEMP_CYCLE, requestTemp);
  }
}

void moveStepper(long newPos) {
  if(newPos != stepper.currentPosition()) {
    if(newPos < 0 || newPos > maxFocuserPos) {
      buzz(100, 2);
    }
    else
    {
      timer.stop(tempCycleEvent);
      analogWrite(STEPPER_PWM_PIN, 255);
      //analogWrite(STEPPER_PWM_PIN, 0);
      stepper.moveTo(newPos);
      positionSaved = false;
    }
  }
}
