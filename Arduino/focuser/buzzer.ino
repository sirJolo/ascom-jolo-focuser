<<<<<<< HEAD
void buzz(int buzzTime, byte buzzCount) {
  buzzes = buzzCount;
  buzz_time = buzzTime;
  buzz_next_action = millis();
  digitalWrite(BUZZER_PIN, LOW);
  digitalWrite(BUZ_LED_PIN, LOW);
}

void doBuzz() {
  if(buzzes > 0) {
    unsigned long curTime = millis();
    if(curTime > buzz_next_action) {
      if(digitalRead(BUZ_LED_PIN) == LOW) {
       if(BUZZER_ON) digitalWrite(BUZZER_PIN, HIGH);
       digitalWrite(BUZ_LED_PIN, HIGH);
       buzz_next_action = curTime + buzz_time;
      } else {
       if(BUZZER_ON) digitalWrite(BUZZER_PIN, LOW); 
       digitalWrite(BUZ_LED_PIN, LOW);
       buzzes--;
       if(buzzes > 0) buzz_next_action = curTime + BUZZ_PAUSE;
      }
    }
  }  
=======
void initializeBuzzer() {
  pinMode(BUZZER_PIN, OUTPUT);
  pinMode(BUZ_LED_PIN, OUTPUT);
  digitalWrite(BUZZER_PIN, LOW);
  digitalWrite(BUZ_LED_PIN, LOW);
}  

void buzz(byte buzzTime, byte buzzCount) {
  if(readByte(PROP_BUZZER_ON) != 0) timer.oscillate(BUZZER_PIN, buzzTime, LOW, buzzCount);
  timer.oscillate(BUZ_LED_PIN, buzzTime, LOW, buzzCount);
>>>>>>> Production_20_RC1
}
