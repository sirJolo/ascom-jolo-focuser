// Initialization routine
void setup() 
{
  initializeSerial();
  initializeTWI();
  initializeBuzzer();
  initializeProperties();
  initializeSensors();
  initializeExt();
  
  initializeSlave();
  
  buzz(50, 2);
}


