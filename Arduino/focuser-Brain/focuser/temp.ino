void initializeSensors() {
  initializeDallas(TEMP_SENSOR1_PIN, 0);
  initializeDHT(TEMP_SENSOR2_PIN, 1);
  initializeDHT(TEMP_SENSOR3_PIN, 2);
  
  if(isTempAvailable() > 0) tempCycleEvent = timer.after(2000, requestTemp);
}

void initializeDHT(byte pin, byte index) {
  tempSensors[index].sensorType = NO_SENSOR;
  int chk = DHT.read22(pin);  
  if(chk == DHTLIB_OK) tempSensors[index].sensorType = DHT_SENSOR;
  tempSensors[index].sensorPin = pin;
}

void initializeDallas(byte pin, byte index) {
  tempSensors[index].sensorType = NO_SENSOR;
  sensors.begin(); 
  boolean sensorConnected = sensors.getAddress(insideThermometer, 0);
  if(sensorConnected) {
    sensors.setResolution(insideThermometer, 10);
    sensors.setWaitForConversion(false);
    tempSensors[index].sensorType = DS_SENSOR;
  }
  tempSensors[index].sensorPin = pin;
}

boolean isTempAvailable() {
  return (tempSensors[0].sensorType != NO_SENSOR || tempSensors[1].sensorType != NO_SENSOR || tempSensors[2].sensorType != NO_SENSOR);  
}

void requestTemp() {
  if(tempSensors[0].sensorType == DS_SENSOR) {
    sensors.requestTemperaturesByAddress(insideThermometer); // Send the command to get temperature. For 10 bit res it takes 188ms
  }
  tempCycleEvent = timer.after(188, readTemp);
}

void readTemp() {
  for (byte i = 0; i < 3; i++) updateSensor(i);
  tempCycleEvent = timer.after(3000, requestTemp);
}

void updateSensor(byte index) {
  tempSensors[index].currentTemp = tempSensors[index].currentHum = tempSensors[index].currentDewpoint = 0.0;
  tempSensors[index].heaterPWM = 0;
  if(tempSensors[index].sensorType == DS_SENSOR) {
    tempSensors[index].currentTemp = sensors.getTempC(insideThermometer);
  }
  if(tempSensors[index].sensorType == DHT_SENSOR) {
    DHT.read22(tempSensors[index].sensorPin);
    tempSensors[index].currentTemp = DHT.temperature;
    tempSensors[index].currentHum = DHT.humidity;
    tempSensors[index].currentDewpoint = dewPointFast(tempSensors[index].currentTemp, tempSensors[index].currentHum);
    tempSensors[index].heaterPWM = map(constrain(tempSensors[index].currentHum, 50, 100), 50, 100, 0, 100);
  }    
}

// dewPoint function NOAA
// reference (1) : http://wahiduddin.net/calc/density_algorithms.htm
// reference (2) : http://www.colorado.edu/geography/weather_station/Geog_site/about.htm
//
double dewPoint(double celsius, double humidity)
{
	// (1) Saturation Vapor Pressure = ESGG(T)
	double RATIO = 373.15 / (273.15 + celsius);
	double RHS = -7.90298 * (RATIO - 1);
	RHS += 5.02808 * log10(RATIO);
	RHS += -1.3816e-7 * (pow(10, (11.344 * (1 - 1/RATIO ))) - 1) ;
	RHS += 8.1328e-3 * (pow(10, (-3.49149 * (RATIO - 1))) - 1) ;
	RHS += log10(1013.246);

        // factor -3 is to adjust units - Vapor Pressure SVP * humidity
	double VP = pow(10, RHS - 3) * humidity;

        // (2) DEWPOINT = F(Vapor Pressure)
	double T = log(VP/0.61078);   // temp var
	return (241.88 * T) / (17.558 - T);
}

// delta max = 0.6544 wrt dewPoint()
// 6.9 x faster than dewPoint()
// reference: http://en.wikipedia.org/wiki/Dew_point
double dewPointFast(double celsius, double humidity)
{
	double a = 17.271;
	double b = 237.7;
	double temp = (a * celsius) / (b + celsius) + log(humidity*0.01);
	double Td = (b * temp) / (a - temp);
	return Td;
}
