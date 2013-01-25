// Interrupt manual encoder routine
void doEncoder() {
  /* If pinA and pinB are both high or both low, it is spinning
   * forward. If they're different, it's going backward.
   *
   * For more information on speeding up this process, see
   * [Reference/PortManipulation], specifically the PIND register.
   */
  if (digitalRead(encoder0PinA) == digitalRead(encoder0PinB)) {
    moveStepper(stepper.currentPosition() + EEPROM.read(MANUAL_STEP_ADD));
  } else {
    moveStepper(stepper.currentPosition() - EEPROM.read(MANUAL_STEP_ADD));
  }
}


