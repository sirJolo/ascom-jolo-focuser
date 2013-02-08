// ASCOM focuser arduino sketch
// ascom-jolo-focuser Google code project
// 
// Author: jolo drjolo@gmail.com
//
// 2013-01-22  0.0.1  first version
// 2013-01-23  0.0.2  non blocking temp read, non blocking stepper
// 2013-01-26  0.0.3  cached temp read, EEPROM wear leveling
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <AccelStepper.h>

#define DEVICE_RESPONSE "Jolo primary focuser"

// EEPROM addresses
#define FOCUSER_POS_START 900
#define MANUAL_STEP_ADD 4        
#define STEPPER_SPEED_ADD 3      
#define DUTY_CYCLE_ADDR 2  

// Encoder config
#define encoder0PinA 2
#define encoder0PinB 4
#define encoderButtonPin 3

// Buzzer pin
#define BUZZER_PIN 10

// Temperature sensor config (one wire protocol)
#define TEMP_CYCLE 3000
#define TEMP_SENSOR_PIN 5
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Stepper config
#define STEPPER_ACC 300
AccelStepper stepper = AccelStepper(AccelStepper::FULL4WIRE, 6, 7, 8, 9);

boolean positionSaved;   
unsigned long tempRequestMilis;
unsigned long tempReadMilis;
double currentTemp;
boolean sensorConnected;
String inputString;


void loop() 
{
  // Stepper loop
  stepper.run();

  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
  }

  // Temperature read loop
  if(sensorConnected && tempRequestMilis != 0 && tempRequestMilis < millis()) requestTemp();  
  if(sensorConnected && tempReadMilis != 0 && tempReadMilis < millis()) readTemp();  
}

