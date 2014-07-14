void initializeStepper() {
  stepper.setMaxSpeed(readWord(PROP_STEPPER_SPEED));
  stepper.setAcceleration(readWord(PROP_ACC_AUTO));
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_STOP)/100));
  maxFocuserPos = readLong(PROP_MAX_FOC_POS);
}


void checkStepper() {
  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(20, 1);
    analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_STOP)/100));
  }
}

void moveStepper(long newPos) {
  if(newPos != stepper.currentPosition()) {
    if(newPos < 0 || newPos > maxFocuserPos) {
      buzz(100, 2);
    }
    else
    {
      analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_RUN)/100));
      stepper.moveTo(newPos);
      positionSaved = false;
      lcdUpdateLCD(" FOCUSER MOVING ", "                ");
    }
  }
}
