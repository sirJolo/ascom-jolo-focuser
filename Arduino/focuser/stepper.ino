void initializeStepper() {
  ctx.stepperSpeed = 100;
  ctx.pwmRun = 100;
  ctx.pwmStop = 0;
  ctx.acc = 500;
  ctx.buzzer = 1;
  ctx.maxPos = 1000000;
  ctx.pwm1 = ctx.pwm2 = ctx.pwm3 = 0;  
  
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
      analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100));
      stepper.moveTo(newPos);
      positionSaved = false;
    }
  }
}
