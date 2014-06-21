// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver. 1.3 08-11-2013
// ver. 1.4 11-11-2013
// ver. 1.5 - production
// ver. 2.0 - production 2014.05
// 
// 
#include <stdlib.h>
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <AccelStepper.h>
#include <Bounce.h>
#include <Timer.h>

#define DEVICE_RESPONSE "Jolo primary focuser"
#define FIRMWARE "2.0"

// EEPROM addresses
#define FOCUSER_POS_START 900
#define STEPPER_SPEED_ADD 3      
#define PROPERTY_ADDR 800
#define PROP_STEPPER_SPEED PROPERTY_ADDR+1
#define PROP_DUTY_CYCLE_RUN PROPERTY_ADDR+2
#define PROP_DUTY_CYCLE_STOP PROPERTY_ADDR+3
#define PROP_ACC_AUTO PROPERTY_ADDR+5
#define PROP_ACC_MAN PROPERTY_ADDR+7
#define PROP_BUZZER_ON PROPERTY_ADDR+9
#define PROP_LCD_LINE1 PROPERTY_ADDR+10
#define PROP_LCD_LINE2 PROPERTY_ADDR+30


// Encoder config
#define ENCODER_A_PIN 8
#define ENCODER_B_PIN 7
Bounce aButton = Bounce( ENCODER_A_PIN, 30 ); 
Bounce bButton = Bounce( ENCODER_B_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 4
#define BUZZER_ON true      // config
#define BUZ_LED_PIN 13

// Temperature sensor config
#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR_PIN 2
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Stepper config
#define STEPPER_ACC 2500          // config up/down
#define MANUAL_STEPPER_ACC 600    // config up/down
#define STEPPER_PWM_PIN 11
#define MSI2_PIN A5
#define MSI1_PIN A4

Timer timer;

// Global vars
AccelStepper stepper;
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
byte sensorType = 0;                 // 0-none, 1-DS8120, 2-DHT11, 3-DHT22
float currentTemp;                   // Current cached temperature  
float currentHum;                    // Current cached humidity
float currentDewpoint;               // Current cached dew point temperature
String inputString;                  // Serial input command string (terminated with \n)

int tempCycleEvent;
int buzzCycleEvent;

long maxFocuserPos = 1000000;        // Maximum focuser position

void loop() 
{
  stepper.run();
  checkStepper();

  doButtonsCheck();
  
  if( stepper.distanceToGo() == 0) {timer.update();}
}






