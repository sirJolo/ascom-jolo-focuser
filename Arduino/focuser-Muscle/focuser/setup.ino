// Initialization routine
void setup() 
{
  initializeExt();
  initializeTWI();
  
  motors[0].motor = stepper1;
  motors[1].motor = stepper2;
  motors[0].pwmPin = STEPPER1_PWM_PIN;
  motors[1].pwmPin = STEPPER2_PWM_PIN;
  motors[0].EEPROMstart = FOCUSER1_POS_START;
  motors[1].EEPROMstart = FOCUSER2_POS_START;  
  initializeStepper(0);
  initializeStepper(1);
}

