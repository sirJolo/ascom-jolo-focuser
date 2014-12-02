void initializeTWI() {
  Wire.begin(I2C_ADDR);  
  Wire.onRequest(requestEvent);
  Wire.onReceive(receiveEvent);
}

void requestEvent() {
  for (byte i = 0; i < 2; i++) {
    DeviceStatus.stepperPos[i] = motors[i].motor.currentPosition();
    DeviceStatus.stepperMove[i] = (motors[i].motor.distanceToGo() != 0) ? true : false;
    DeviceStatus.adc6 = analogRead(A6); 
    DeviceStatus.adc7 - analogRead(A7);
  }
  Wire.write((byte*) &DeviceStatus, sizeof DeviceStatus);
}

// devices
// 1,2 - steppers
// 11,12,13,14 - PWMs

// commands
// 0 - proceed
// 1 - stepper move
// 2 - stepper halt
// 3 - stepper acc
// 4 - stepper auto acc
// 5 - stepper pwm stop
// 6 - stepper pwm run
// 7 - stepper speed
// 8 - stepper max foc pos
// 9 - stepper cur pos

void receiveEvent(int howMany)
{
  if (howMany < sizeof DeviceCommand) return;
  byte* p = (byte*) &DeviceCommand;
  for (byte i = 0; i < sizeof DeviceCommand; i++) *p++ = Wire.read(); 
  commandDispatched = false;
  dispatchCommand();
}

void dispatchCommand() {
  if(DeviceCommand.device < 10) {
    stepperCommand();
  } else if (DeviceCommand.device < 20) {
    pwmCommand();
  }  
}

void stepperCommand() {
  if(!commandDispatched) {
    byte index = DeviceCommand.device - 1;
    switch(DeviceCommand.command) {
      case '1': moveStepper(index, DeviceCommand.value); break;
      case '2': motors[index].motor.stop(); break;
      case '3': motors[index].accMan = DeviceCommand.value; break;
      case '4': motors[index].accAuto = DeviceCommand.value; break;
      case '5': motors[index].pwmStop = DeviceCommand.value; break;
      case '6': motors[index].pwmRun = DeviceCommand.value; break;
      case '7': motors[index].pps = DeviceCommand.value; break;
      case '8': motors[index].maxPos = DeviceCommand.value; break;
      case '9': motors[index].motor.setCurrentPosition(DeviceCommand.value); break;
    } 
    commandDispatched = true;
  }
}

void pwmCommand() {
  if(!commandDispatched) {
    byte index = DeviceCommand.device - 11;
    DeviceStatus.pwmValues[index] = (byte) DeviceCommand.value;
    analogWrite(pwmPins[index], DeviceStatus.pwmValues[index]);
    commandDispatched = true;
  }
}
