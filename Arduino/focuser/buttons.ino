void initializeButtons() {
  pinMode(BUTTON_A_PIN, INPUT); 
  pinMode(BUTTON_B_PIN, INPUT); 
  // turn on pullup resistors
  digitalWrite(BUTTON_A_PIN, HIGH);
  digitalWrite(BUTTON_B_PIN, HIGH);
}

void doButtonsCheck() {
  if ( aButton.update() ) {
    if ( aButton.read() == LOW) {
      stepper.setAcceleration((int) (ctx.acc / 3));
      analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100));
      moveStepper(ctx.maxPos);
      positionSaved = false;
    }
    else
    {
      stepper.setAcceleration(ctx.acc * 6);
      stepper.stop();
      timer.after(1000, checkStepper);
      //tempCycleEvent = timer.after(TEMP_CYCLE, readTemp);
    }
  }

  if ( bButton.update() ) {
    if ( bButton.read() == LOW) {
       stepper.setAcceleration((int) (ctx.acc / 3));
       analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100));
       moveStepper(0);
       positionSaved = false;
    }
    else
    {
      stepper.setAcceleration(ctx.acc * 6);
      stepper.stop();
      timer.after(1000, checkStepper);
      //tempCycleEvent = timer.after(TEMP_CYCLE, readTemp);
    }
  }
}
