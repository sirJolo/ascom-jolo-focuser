// Initialization routine
void setup() 
{ 
  initializeSerial();
  initializeBuzzer();
  initializeSensors();
  initializeStepper();
  initializeExt();

  buzz(50, 2);
}


