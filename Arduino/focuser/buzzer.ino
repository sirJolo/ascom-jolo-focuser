void initializeBuzzer() {
  pinMode(BUZZER_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
  silent = false;
}  

void buzz(byte buzzTime, byte buzzCount) {
  if(ctx.buzzer && !silent) timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
}

void unlockBuzz() {silent = false;}
