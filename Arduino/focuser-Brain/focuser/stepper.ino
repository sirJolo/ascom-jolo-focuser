void initializeStepper(byte index) {
  steppers[index].maxPos = 1000000;
  steppers[index].pwmStop = 0;
  steppers[index].pwmRun = 100;
  steppers[index].pps = 100;
  steppers[index].accMan = 100;
  steppers[index].accAuto = 100;
  steppers[index].curStep = 0;  //only used for unipolar move control
  steppers[index].reversed = false;
  
  motors[index].setMaxSpeed(steppers[index].pps);
  motors[index].setAcceleration(steppers[index].accAuto);
  motors[index].setCurrentPosition(readFocuserPos(steppers[index].EEPROMstart));
  analogWrite(steppers[index].pwmPin, steppers[index].pwmStop);
  steppers[index].posSaved = true;  
}


void checkStepper(byte index) {
  if(motors[index].distanceToGo() == 0 && !steppers[index].posSaved) {
    saveFocuserPos(abs(motors[index].currentPosition()), steppers[index].EEPROMstart);
    steppers[index].posSaved = true;
    buzz(20, 1);
    analogWrite(steppers[index].pwmPin, steppers[index].pwmStop);
  }
}

void moveStepper(byte index, long newPos) {
  if(newPos != abs(motors[index].currentPosition())) {
    if(newPos < 0 || newPos > steppers[index].maxPos) {
      buzz(100, 2);
    }
    else
    {
      analogWrite(steppers[index].pwmPin, steppers[index].pwmRun);
      motors[index].moveTo(newPos);
      steppers[index].posSaved = false;
    }
  }
}


//long adjustSign(long value, byte index) {
 // if(steppers[index].reversed) {
  //   return (0 - value);
  //} else {
  //   return value;
  //}    
//}

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
