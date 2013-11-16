void doButtonsCheck() {
  if ( aButton.update() ) {
    if ( aButton.read() == LOW) {
      stepper.setAcceleration(MANUAL_STEPPER_ACC);
      moveStepper(maxFocuserPos, true);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
    }
  }

  if ( bButton.update() ) {
    if ( bButton.read() == LOW) {
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










