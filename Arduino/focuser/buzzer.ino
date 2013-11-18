void doBuzz() {
  if(buzzes > 0)
  {
    unsigned long curTime = millis();
    if(curTime > buzz_start && digitalRead(BUZZER_PIN) == LOW) {
      if(BUZZER_ON) digitalWrite(BUZZER_PIN, HIGH);
      digitalWrite(BUZ_LED_PIN, HIGH);
    }
    if(curTime > buzz_stop && digitalRead(BUZZER_PIN) == HIGH)
    {
      if(BUZZER_ON) digitalWrite(BUZZER_PIN, LOW);
      digitalWrite(BUZ_LED_PIN, LOW);
      buzzes--;
      if(buzzes > 0) {
        buzz_start = curTime + buzz_time;
        buzz_stop = buzz_start + buzz_time; 
      }
    }
  }
}

void buzz(byte buzzTime, byte buzzCount) {
  buzzes = buzzCount;
  buzz_time = buzzTime;
  buzz_start = millis();
  buzz_stop = buzz_start + buzz_time;
  digitalWrite(BUZZER_PIN, LOW);
}
