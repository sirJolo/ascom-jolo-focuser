void initializeADCs() {
  powerStatus.Ah = 0.0;
  powerStatus.Wh = 0.0;
  adcCycleEvent = timer.every(200, readADCs);
}

void readADCs() {
  powerStatus.Vin = analogRead(Vin_PIN);
  powerStatus.Itot = analogRead(Itot_PIN);
  powerStatus.Ah += powerStatus.Itot;
  powerStatus.Wh += powerStatus.Itot * powerStatus.Vin;
}
