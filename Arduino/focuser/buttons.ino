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
      analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_RUN)/100));
      moveStepper(maxFocuserPos);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
      analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_STOP)/100));
      tempCycleEvent = timer.after(TEMP_CYCLE, requestTemp);
    }
  }

  if ( bButton.update() ) {
    if ( bButton.read() == LOW) {
       stepper.setAcceleration(MANUAL_STEPPER_ACC);
       analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_RUN)/100));
       moveStepper(0);
    }
    else
    {
      stepper.setAcceleration(STEPPER_ACC);
      stepper.stop();
      analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_STOP)/100));
      tempCycleEvent = timer.after(TEMP_CYCLE, requestTemp);
    }
  }
}










