// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver 3.0 - device control unit
// 
#include <OneWire.h>
#include <DallasTemperature.h>
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <Timer.h>
#include <Wire.h>
#include <PCF8574.h>

#define STEPPER_CPU_ADDR 30
#define DEVICE_RESPONSE "Jolo primary focuser"
#define FIRMWARE "3.0"

#define DEBUG true

// OUTs config
PCF8574 expander;
#define PCF_OUT1_PIN 1
#define PCF_OUT2_PIN 2
#define PCF_OUT3_PIN 3
#define PCF_OUT4_PIN 4
#define PCF_OUT5_PIN 5
#define PCF_REG_PIN 6
#define PCF_OPTO_PIN 7
#define PCF_INTERNAL_PIN 8

// EEPROM addresses
#define PROPERTY_ADDR 700
#define PROP_BUZZER_ON PROPERTY_ADDR+20

// ADC
#define Vin_PIN A5
#define Vreg_PIN A6
#define Itot_PIN A7
#define Cust_PIN A4

// Buzzer config
#define BUZZER_PIN 13

// Temperature sensor config
struct TempSensor {
  byte sensorType;                     // 0-none, 1-DS8120, 2-DHT11, 3-DHT22
  float currentTemp;                   // Current cached temperature  
  float currentHum;                    // Current cached humidity
  float currentDewpoint;               // Current cached dew point temperature
  byte heaterPWM;                      // Calculated PWM on hum  
  byte sensorPin;
};

#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR1_PIN 9
#define TEMP_SENSOR2_PIN 10
#define TEMP_SENSOR3_PIN 11
OneWire oneWire(TEMP_SENSOR1_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
dht DHT;
  
Timer timer;
byte commandMap[] = {7,3,4,0,5,6,8};

struct DeviceStatusStruct {
  long stepperPos[2];
  boolean stepperMove[2];
  byte pwmValues[4];
  int adc6;
  int adc7;  
};

struct DeviceCommandStruct {
  byte command;
  byte device;
  long value;
};

struct {
  int Vin;
  int Vreg;
  int Itot;
  int Cust;
  long energy;
} powerStatus;


// Global vars
TempSensor tempSensors[3];
String inputString;                  // Serial input command string (terminated with \n)

int tempCycleEvent;
int buzzCycleEvent;
int statusCycleEvent;
int adcCycleEvent;

DeviceCommandStruct deviceCommand;
DeviceStatusStruct deviceStatus;

void loop() 
{
  timer.update();
}






