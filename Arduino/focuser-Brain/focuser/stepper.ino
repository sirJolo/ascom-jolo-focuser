void initializeStepper(byte index) {
  motors[index].setMaxSpeed(ctx.stepperSpeed[index]);
  motors[index].setAcceleration(ctx.accAuto[index]);
  motors[index].setCurrentPosition(readFocuserPos(steppers[index].EEPROMstart));
  motors[index].setMode(ctx.mode[index]);
  analogWrite(steppers[index].pwmPin, ctx.pwmStop[index]);
  steppers[index].posSaved = true;  
}


void checkStepper(byte index) {
  if(motors[index].distanceToGo() == 0 && !steppers[index].posSaved) {
    saveFocuserPos(abs(motors[index].currentPosition()), steppers[index].EEPROMstart);
    steppers[index].posSaved = true;
    buzz(20, 1);
    analogWrite(steppers[index].pwmPin, ctx.pwmStop[index]);
  }
}

void moveStepper(byte index, long newPos) {
  if(newPos != abs(motors[index].currentPosition())) {
    if(newPos < 0 || newPos > ctx.maxPos[index]) {
      buzz(100, 2);
    }
    else
    {
      analogWrite(steppers[index].pwmPin, ctx.pwmRun[index]);
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


