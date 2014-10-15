// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver. 1.3 08-11-2013
// ver. 1.4 11-11-2013
// ver. 1.5 - production
// ver. 2.0 - production 2014.05
// ver. 2.1 - production LCD 2014.07
// 
#include <OneWire.h>
#include <DallasTemperature.h>
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <AccelStepper.h>
#include <Bounce.h>
#include <Timer.h>
#include "SoftI2CMaster.h"
#include <LiquidCrystal_I2C.h>

#define DEVICE_RESPONSE "Jolo primary focuser"
#define FIRMWARE "2.1"

#define DEBUG true

// EEPROM addresses
#define FOCUSER_POS_START 900
#define PROPERTY_ADDR 700
#define PROP_STEPPER_SPEED PROPERTY_ADDR+1
#define PROP_DUTY_CYCLE_RUN PROPERTY_ADDR+3
#define PROP_DUTY_CYCLE_STOP PROPERTY_ADDR+5
#define PROP_ACC_AUTO PROPERTY_ADDR+10
#define PROP_ACC_MAN PROPERTY_ADDR+15
#define PROP_BUZZER_ON PROPERTY_ADDR+20
#define PROP_LCD_SCREEN_0 PROPERTY_ADDR+25
#define PROP_LCD_SCREEN_1 PROPERTY_ADDR+26
#define PROP_LCD_SCREEN_2 PROPERTY_ADDR+27
#define PROP_LCD_SCREEN_3 PROPERTY_ADDR+28
#define PROP_MAX_FOC_POS PROPERTY_ADDR+30
#define PROP_PWM6 PROPERTY_ADDR+50
#define PROP_PWM9 PROPERTY_ADDR+51
#define PROP_PWM10 PROPERTY_ADDR+52
#define PROP_STEP_SIZE PROPERTY_ADDR+53
#define PROP_LCD_OFF_DURING_MOVE PROPERTY_ADDR+55

// EXT
#define OPTO_PIN A0
#define PWM_PIN6 6
#define PWM_PIN9 9
#define PWM_PIN10 10
#define ADC_PIN A1

// LCD
#define LCD_REFRESH 500
LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);

// Encoder config
#define ENCODER_A_PIN 8
#define ENCODER_B_PIN 7
Bounce aButton = Bounce( ENCODER_A_PIN, 30 ); 
Bounce bButton = Bounce( ENCODER_B_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 4
#define BUZ_LED_PIN 13

// Temperature sensor config
#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR_PIN 2
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
dht DHT;

// Stepper config
#define STEPPER_PWM_PIN 11
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, A5, A4, A3, A2);  
//AccelStepper stepper = AccelStepper(AccelStepper::DRIVER, A3, A2);  
  
Timer timer;

// Global vars
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
byte sensorType = 0;                 // 0-none, 1-DS8120, 2-DHT11, 3-DHT22
float currentTemp;                   // Current cached temperature  
float currentHum;                    // Current cached humidity
float currentDewpoint;               // Current cached dew point temperature
byte heaterPWM = 0;                  // Calculated PWM on hum
byte LCDscreen = 0;                  // Current LCD screen
byte lcdCycle = 0;
String inputString;                  // Serial input command string (terminated with \n)

int tempCycleEvent;
int buzzCycleEvent;
int lcdCycleEvent;

long maxFocuserPos = 1000000;        // Maximum focuser position

void loop() 
{
  stepper.run();
  checkStepper();

  doButtonsCheck();
  
  timer.update();
}






