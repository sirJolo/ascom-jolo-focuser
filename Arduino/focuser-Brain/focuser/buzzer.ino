void initializeBuzzer() {
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
}  

void buzz(byte buzzTime, byte buzzCount) {
  if(readByte(ctx.buzzer) != 0) timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
}
