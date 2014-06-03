void buzz(byte buzzTime, byte buzzCount) {
  if(BUZZER_ON) buzzCycleEvent = timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
  timer.oscillate(BUZ_LED_PIN, buzzTime, LOW, buzzCount);
}
