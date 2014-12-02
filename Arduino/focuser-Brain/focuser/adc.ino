void initializeADCs() {
  powerStatus.energy = 0;
  adcCycleEvent = timer.every(200, readADCs);
}

void readADCs() {
  powerStatus.Vin = analogRead(Vin_PIN);
  powerStatus.Vreg = analogRead(Vreg_PIN);
  powerStatus.Cust = analogRead(Cust_PIN);
  powerStatus.Itot = analogRead(Itot_PIN);
  powerStatus.energy += powerStatus.Itot;
}
