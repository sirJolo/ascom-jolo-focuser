// Initialization routine
void setup() 
{
  initializeSerial();
  initializeTWI();
  initializeBuzzer();
  initializeProperties();
  initializeSensors();
  initializeExt();
  initializeADCs();
  
  initializeSlave();
  
  buzz(50, 2);
}


