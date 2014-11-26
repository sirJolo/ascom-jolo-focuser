void initializeBuzzer() {
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
}  

void buzz(byte buzzTime, byte buzzCount) {
  if(readByte(PROP_BUZZER_ON) != 0) timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
}
