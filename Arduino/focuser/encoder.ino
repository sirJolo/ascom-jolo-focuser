void doButtonsCheck() {
  if ( outButton.update() ) {
    if ( outButton.read() == LOW) {
      stepper.setAcceleration(MANUAL_STEPPER_ACC);
      moveStepper(maxFocuserPos, true);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
    }
  }

  if ( inButton.update() ) {
    if ( inButton.read() == LOW) {
       stepper.setAcceleration(MANUAL_STEPPER_ACC);
       moveStepper(0, true);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
    }
  }
}










