// Initialization routine
void setup() 
{
  initializeBuzzer();
  initializeProperties();
  initializeButtons();
  initializeSensors();
  initializeStepper();
  initializeExt();
  initializeSerial();

  buzz(50, 2);
}


void initializeExt() {
  // OPT init
  pinMode(A0, OUTPUT);
  digitalWrite(A0, LOW);
  
  // EXT init
  pinMode(3, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  pinMode(9, INPUT);
  pinMode(10, INPUT);
  pinMode(12, INPUT);
  pinMode(A1, INPUT);
}  
