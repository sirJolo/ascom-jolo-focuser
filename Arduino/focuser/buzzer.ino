void buzz(byte buzzTime, byte buzzCount) {
  if(BUZZER_ON) timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
  timer.oscillate(BUZ_LED_PIN, buzzTime, LOW, buzzCount);
}
