void initializeStepper(byte index) {
  stepper[index].setMaxSpeed(readWord(EEPROMaddrStart[index] + PROP_STEPPER_SPEED));
  stepper[index].setAcceleration(readWord(EEPROMaddrStart[index] + PROP_ACC_AUTO));
  stepper[index].setCurrentPosition(readFocuserPos(EEPROMaddrStart[index]));
  analogWrite(stepperPWMPin[index], (255 * readByte(EEPROMaddrStart[index] + PROP_DUTY_CYCLE_STOP)/100));
  positionSaved[index] = true;
  maxFocuserPos[index] = readLong(EEPROMaddrStart[index] + PROP_MAX_FOC_POS);
}


void checkStepper(byte index) {
  if(stepper[index].distanceToGo() == 0 && !positionSaved[index]) {
    saveFocuserPos(stepper[index].currentPosition(), EEPROMaddrStart[index]);
    positionSaved[index] = true;
    buzz(20, 1);
    analogWrite(stepperPWMPin[index], (255 * readByte(EEPROMaddrStart[index] + PROP_DUTY_CYCLE_STOP)/100));
  }
}

void moveStepper(byte index, long newPos) {
  if(newPos != stepper[index].currentPosition()) {
    if(newPos < 0 || newPos > maxFocuserPos[index]) {
      buzz(100, 2);
    }
    else
    {
      analogWrite(stepperPWMPin[index], (255 * readByte(EEPROMaddrStart[index] + PROP_DUTY_CYCLE_RUN)/100));
      stepper[index].moveTo(newPos);
      positionSaved[index] = false;
    }
  }
}
