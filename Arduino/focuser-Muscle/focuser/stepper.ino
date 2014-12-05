void initializeStepper(byte index) {
  motors[index].maxPos = 1000000;
  motors[index].pwmStop = 0;
  motors[index].pwmRun = 100;
  motors[index].pps = 100;
  motors[index].accMan = 100;
  motors[index].accAuto = 100;
  motors[index].curStep = 0;  //only used for unipolar move control
  motors[index].reversed = false;
  
  motors[index].motor.setMaxSpeed(motors[index].pps);
  motors[index].motor.setAcceleration(motors[index].accAuto);
  motors[index].motor.setCurrentPosition(adjustSign(readFocuserPos(motors[index].EEPROMstart), index));
  analogWrite(motors[index].pwmPin, motors[index].pwmStop);
  motors[index].posSaved = true;
}


void checkStepper(byte index) {
  if(motors[index].motor.distanceToGo() == 0 && !motors[index].posSaved) {
    saveFocuserPos(abs(motors[index].motor.currentPosition()), motors[index].EEPROMstart);
    motors[index].posSaved = true;
    buzz(20, 1);
    analogWrite(motors[index].pwmPin, motors[index].pwmStop);
  }
}

void moveStepper(byte index, long newPos) {
  if(newPos != abs(motors[index].motor.currentPosition())) {
    if(newPos < 0 || newPos > motors[index].maxPos) {
      buzz(100, 2);
    }
    else
    {
      analogWrite(motors[index].pwmPin, motors[index].pwmRun);
      motors[index].motor.moveTo(adjustSign(newPos, index));
      motors[index].posSaved = false;
    }
  }
}

long adjustSign(long value, byte index) {
  if(motors[index].reversed) {
     return (0 - value);
  } else {
     return value;
  }    
}

void forward1Step() {
  // do forward unipolar 1 stuff
}

void backward1Step() {
  // do backward unipolar 1 stuff
}

void forward2Step() {
  // do forward unipolar 2 stuff
}

void backward2Step() {
  // do backward unipolar 2 stuff
}
