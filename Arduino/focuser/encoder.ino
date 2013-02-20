/* returns change in encoder state (-1,0,1) */
int read_encoder()
{
  static int enc_states[] = {
    0,0,0,0,0,0,0,-1,0,0,0,1,0,0,0,0    };
  static byte old_AB = digitalRead(ENCODER_A_PIN) + 2*digitalRead(ENCODER_B_PIN);
  /**/
  old_AB <<= 2;                   //remember previous state
  byte new_AB = digitalRead(ENCODER_A_PIN) + 2*digitalRead(ENCODER_B_PIN);
  old_AB |= new_AB;              //add current state
  return ( enc_states[( old_AB & 0x0f )]);
}

void doEncoder() {
  int encoderPos = read_encoder();
  if(encoderPos == 0) return;
  if(encoderMode == 0) {
    
    moveStepper(stepper.currentPosition() + encoderPos * manualStep, true);
  }
  else
  {
    if(encoderPos < 0) {
      manualStep /= 2;
    }
    else
    {
      manualStep *= 2;
    }
    manualStep = min(manualStep, 256);
    manualStep = max(manualStep, 1);
    buzz(BUZZ_SHORT, calculateBeeps(manualStep)); 
  }
}


byte calculateBeeps(int steps) {
  byte beeps = 0;
  while(steps > 0) {
    beeps++;
    steps >>= 1;  
  }
  return beeps;
}


void doPushButtonCheck() {
  if ( pushButton.update() ) {
    if ( pushButton.read() == HIGH) {
      if(encoderMode == 1) {
        encoderMode = 0;  // Manual focus mode
        buzz(BUZZ_SHORT, 1);
      }
      else
      {
        encoderMode = 1;  // Manual focus step change mode
        buzz(BUZZ_SHORT, 2);
      }
    }
  }
}







