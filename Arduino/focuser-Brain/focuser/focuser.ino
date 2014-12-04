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
#define Vin_PIN A6
#define Itot_PIN A7

// DC motor
#define DCMOTOR_PWM_PIN 9
#define DCMOTOR_CW_PIN 10
#define DCMOTOR_CCW_PIN 11

// Buzzer config
#define BUZZER_PIN 13

// Temperature sensor config
struct TempSensor {
  byte sensorType;                    
  float currentTemp;                  
  float currentHum;                   
  float currentDewpoint;               
  byte heaterPWM;                     
  byte sensorPin;
};

#define TEMP_SENSOR1_PIN 9
#define TEMP_SENSOR2_PIN 10
#define TEMP_SENSOR3_PIN 11
OneWire oneWire(TEMP_SENSOR1_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
dht DHT;
  
Timer timer;
byte configCommandMap[] = {7,3,4,0,5,6,8};

struct DeviceStatusStruct {
  long stepperPos[2];
  boolean stepperMove[2];
  byte pwmValues[4];
  int Vreg;
  int Cust;
};

struct {
  byte pwm; byte dir; int time; boolean moving;
} dcMotor;

struct {
  int Vreg; int Cust; int Vin; int Itot; float Ah; float Wh;
} powerStatus;

struct DeviceCommandStruct {
  byte command; byte device; long value;
};


// Global vars
TempSensor tempSensors[3];
String inputString;                  

int tempCycleEvent;
int buzzCycleEvent;
int statusCycleEvent;
int adcCycleEvent;
int dcMotorEvent;

DeviceCommandStruct deviceCommand;
DeviceStatusStruct deviceStatus;

void loop() 
{
  timer.update();
}






