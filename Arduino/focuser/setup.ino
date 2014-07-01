// Initialization routine
void setup() 
{
  initializeSerial();
  initializeBuzzer();
  initializeProperties();
  initializeButtons();
  initializeSensors();
  initializeStepper();
  initializeExt();
  initializeLCD();

  buzz(50, 2);
}


