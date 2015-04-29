void initializeADCs() {
  powerStatus.Ah = 0.0;
  powerStatus.Wh = 0.0;
  adcCycleEvent = timer.every(200, readADCs);
}

void readADCs() {
  powerStatus.vins[powerStatus.cycle] = analogRead(Vin_PIN);
  powerStatus.vregs[powerStatus.cycle] = analogRead(Vreg_PIN);
  powerStatus.itots[powerStatus.cycle] = analogRead(Itot_PIN);
  powerStatus.cycle++;
  if(powerStatus.cycle > 4) powerStatus.cycle = 0;
  
  powerStatus.Vin = getMean(powerStatus.vins);
  powerStatus.Itot = getMean(powerStatus.itots);
  powerStatus.Vreg = getMean(powerStatus.vregs);
  powerStatus.Ah += powerStatus.Itot;
  powerStatus.Wh += powerStatus.Itot * powerStatus.Vin;
}

int getMean(int data[5]) {
  int sum = 0;
  for(byte i = 0; i < 5; i++) sum += data[i];
  return int (sum / 5);
}
