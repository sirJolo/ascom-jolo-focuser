void initializeTWI() {
  Wire.begin();  
  
  statusCycleEvent = timer.after(2000, readStatus);
}

void sendCommand() {
  Wire.beginTransmission(STEPPER_CPU_ADDR);
  Wire.write((byte*) &deviceCommand, sizeof deviceCommand);
  Wire.endTransmission();
}

void readStatus() {
  DeviceStatusStruct deviceRead;
  Wire.requestFrom(STEPPER_CPU_ADDR, sizeof deviceRead);
  byte* p = (byte*) &deviceRead;
  byte index = 0;
  while(Wire.available()) {
    *p++ = Wire.read();   
    index++;
  }
  if (index == sizeof deviceRead) deviceStatus = deviceRead;
  statusCycleEvent = timer.after(500, readStatus);
}
