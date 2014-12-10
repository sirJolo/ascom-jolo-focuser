// Initialization routine
void setup() 
{
  initializeSerial();
  initializeBuzzer();
  initializeProperties();
  initializeSensors();
  initializeStepper();
  initializeExt();

  buzz(50, 2);
}


