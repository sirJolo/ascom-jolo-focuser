// Initialization routine
void setup() 
{ 
  loadConfig();
  initializeSerial();
  initializeBuzzer();
  initializeSensors();
  initializeStepper();
  initializeExt();
  initializeButtons();

  buzz(50, 2);
}



