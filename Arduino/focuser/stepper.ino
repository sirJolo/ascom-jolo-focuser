void initializeStepper() {
  stepper.setMaxSpeed(readWord(PROP_STEPPER_SPEED));
  stepper.setAcceleration(STEPPER_ACC);
  stepper.setCurrentPosition(readFocuserPos());
  positionSaved = true;
  analogWrite(STEPPER_PWM_PIN, (255 * readByte(PROP_DUTY_CYCLE_STOP)/100));
  //pinMode(MSI1_PIN, OUTPUT);
  //digitalWrite(MSI1_PIN, LOW);
  //pinMode(MSI2_PIN, OUTPUT);
  //digitalWrite(MSI2_PIN, HIGH);
  if(DEBUG) {
    Serial.print(millis());
    Serial.print(" - stepper initialized, position: ");
    Serial.println(stepper.currentPosition());
  }
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
    }
  }
}
