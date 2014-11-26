void initializeTWI() {
  Wire.begin(I2C_ADDR);  
  Wire.onRequest(requestEvent);
  Wire.onReceive(receiveEvent);
}

void requestEvent() {
  for (byte i = 0; i < 2; i++) {
    DeviceStatus.stepperPos[i] = stepper[i].currentPosition();
    DeviceStatus.stepperMove[i] = (stepper[i].distanceToGo() != 0) ? true : false;
  }
  Wire.write((byte*) &DeviceStatus, sizeof DeviceStatus);
}

// devices
// 1,2 - steppers
// 11,12,13,14 - PWMs
// 21,22,23,24,25,26 - PCFs

// commands
// 1 - stepper move
// 2 - stepper halt
// 3 - stepper man acc
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
}

void dispatchCommand() {
  
}
