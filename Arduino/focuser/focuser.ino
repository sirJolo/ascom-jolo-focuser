// ASCOM focuser arduino sketch
// ascom-jolo-focuser Google code project
// 
// Author: jolo drjolo@gmail.com
//
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <AccelStepper.h>
#include <PWM.h>

#define DEVICE_RESPONSE "Jolo primary focuser"

// EEPROM addresses
#define FOCUSER_POS_START 900
#define MANUAL_STEP_ADD 4        
#define STEPPER_SPEED_ADD 3      
#define DUTY_CYCLE_ADDR 2  
#define STEPPER_PWM_MAX 100
#define STEPPER_PWM_PIN 10

// Encoder config
#define encoderPinA 3
#define encoderPinB 4
#define encoderButtonPin 5

// Buzzer pin
#define BUZZER_PIN 10
#define BUZZ_LONG 500
#define BUZZ_SHORT 50

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

byte buzzes = 0;
int buzz_time = 0;
unsigned long buzz_stop = 0;
unsigned long buzz_start = 0;


void loop() 
{
  // Stepper loop
  stepper.run();

  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(BUZZ_SHORT, 1);
    pwmWrite(STEPPER_PWM_PIN, EEPROM.read(DUTY_CYCLE_ADDR) * (STEPPER_PWM_MAX/100));
    if(EEPROM.read(DUTY_CYCLE_ADDR) == 0) stepper.disableOutputs();
  }
  
  // Buzzer call
  doBuzz();

  // Temperature read loop
  if(sensorConnected && tempRequestMilis != 0 && tempRequestMilis < millis()) requestTemp();  
  if(sensorConnected && tempReadMilis != 0 && tempReadMilis < millis()) readTemp();  
}

