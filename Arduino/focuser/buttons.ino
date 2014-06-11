void initializeButtons() {
  pinMode(ENCODER_A_PIN, INPUT); 
  pinMode(ENCODER_B_PIN, INPUT); 
  // turn on pullup resistors
  digitalWrite(ENCODER_A_PIN, HIGH);
  digitalWrite(ENCODER_B_PIN, HIGH);
}

void doButtonsCheck() {
  if ( outButton.update() ) {
    if ( outButton.read() == LOW) {
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

  if ( inButton.update() ) {
    if ( inButton.read() == LOW) {
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










