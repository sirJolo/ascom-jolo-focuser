void initializeButtons() {
  pinMode(ENCODER_A_PIN, INPUT); 
  pinMode(ENCODER_B_PIN, INPUT); 
  // turn on pullup resistors
  digitalWrite(ENCODER_A_PIN, HIGH);
  digitalWrite(ENCODER_B_PIN, HIGH);
}

void doButtonsCheck() {
  if ( aButton.update() ) {
    if ( aButton.read() == LOW) {
      stepper.setAcceleration(MANUAL_STEPPER_ACC);
      moveStepper(maxFocuserPos);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
      tempCycleEvent = timer.after(TEMP_CYCLE, requestTemp);
    }
  }

  if ( bButton.update() ) {
    if ( bButton.read() == LOW) {
       stepper.setAcceleration(MANUAL_STEPPER_ACC);
       moveStepper(0);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
      tempCycleEvent = timer.after(TEMP_CYCLE, requestTemp);
    }
  }
}










