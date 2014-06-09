void initializeStepper() {
  stepper = AccelStepper(AccelStepper::HALF4WIRE, A5, A4, A3, A2);  
  stepper.setMaxSpeed(readWord(STEPPER_SPEED_ADD));
  stepper.setAcceleration(STEPPER_ACC);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
}


void checkStepper() {
  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(20, 1);
    analogWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
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
      stepper.moveTo(newPos);
      positionSaved = false;
    }
  }
}
