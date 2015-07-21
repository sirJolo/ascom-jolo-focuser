void initializeStepper() {
  stepper.setMaxSpeed(ctx.stepperSpeed);
  stepper.setAcceleration(ctx.acc);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmStop/100));
}


void checkStepper() {
  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(20, 1);
    analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmStop/100));
  }
}

void moveStepper(long newPos) {
  if(newPos != stepper.currentPosition()) {
    if(newPos < 0 || newPos > ctx.maxPos) {
      buzz(100, 2);
    }
    else
    {
      //analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100));
      //stepper.setAcceleration(ctx.acc);
      stepper.moveTo(newPos);
      positionSaved = false;
    }
  }
}