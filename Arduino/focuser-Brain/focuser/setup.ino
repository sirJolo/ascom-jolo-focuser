// Initialization routine
void setup() 
{
  initializeSerial();
  initializeTWI();
  initializeBuzzer();
  initializeProperties();
  initializeSensors();
  initializeExt();
  
  buzz(50, 2);
}


