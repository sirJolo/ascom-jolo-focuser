// Interrupt manual encoder routine
void doEncoder() {
  delay(2);
  if (digitalRead(encoderPinA) == digitalRead(encoderPinB)) {
    //moveStepper(EEPROM.read(MANUAL_STEP_ADD));
  } else {
    //moveStepper(EEPROM.read(MANUAL_STEP_ADD));
  }
}


