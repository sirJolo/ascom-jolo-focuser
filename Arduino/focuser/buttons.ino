void initializeButtons() {
  pinMode(BUTTON_A_PIN, INPUT_PULLUP); 
  pinMode(BUTTON_B_PIN, INPUT_PULLUP); 
}

void doButtonsCheck() {
  if ( aButton.update() ) {
    if ( aButton.read() == LOW) {
      stepper.setAcceleration((int) (ctx.acc / 5));
      analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100));
      moveStepper(ctx.maxPos);
      positionSaved = false;
    }
    else
    {
      silent = true;
      stepper.setAcceleration(ctx.acc * 3);
      stepper.stop();
      timer.after(1000, unlockBuzz);
    }
  }

  if ( bButton.update() ) {
    if ( bButton.read() == LOW) {
       stepper.setAcceleration((int) (ctx.acc / 5));
       analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100));
       moveStepper(0);
       positionSaved = false;
    }
    else
    {
      silent = true;
      stepper.setAcceleration(ctx.acc * 3);
      stepper.stop();
      timer.after(1000, unlockBuzz);
    }
  }
}

