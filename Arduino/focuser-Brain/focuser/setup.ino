// Initialization routine
void setup() 
{
  initializeSerial();
  initializeBuzzer();
  initializeProperties();
  initializeSensors();
  initializeExt();
  initializeADCs();
  initializeStepper(1);
  initializeStepper(0);
  intializeDCmotor();
  
  buzz(50, 2);
}


