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
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <AccelStepper.h>
#include <PWM.h>
#include <Bounce.h>
#include <dht.h>
#include <LiquidCrystal.h>

#define DEVICE_RESPONSE "Jolo primary focuser"
#define FIRMWARE "2.0"

// EEPROM addresses
#define FOCUSER_POS_START 900
#define STEPPER_SPEED_ADD 3      
#define DUTY_CYCLE_ADDR 2  

// Encoder config
#define ENCODER_A_PIN 7
#define ENCODER_B_PIN 8
Bounce aButton = Bounce( ENCODER_A_PIN, 30 ); 
Bounce bButton = Bounce( ENCODER_B_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 4
#define BUZZ_LONG 800
#define BUZZ_SHORT 200
#define BUZZER_ON false
#define BUZ_LED_PIN 13

// Temperature sensor config (one wire protocol)
#define TEMP_CYCLE 3000
#define TEMP_SENSOR_PIN 2
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
// dht DHT;

// Stepper config
#define STEPPER_ACC 2500
#define MANUAL_STEPPER_ACC 600
#define STEPPER_PWM_FREQ 1000
#define STEPPER_PWM_PIN 11
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, A5, A4, A3, A2);

// LCD config (to EXT slot)
// LiquidCrystal lcd(3, 5, 6, 9, 10, 12);

// Global vars
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
unsigned long tempRequestMilis;      // Next temperature request time
unsigned long tempReadMilis;         // Next temperature read time (188ms after temperature read request) 
boolean sensorConnected;             // Flag indicates if temperature sensor is connected
float currentTemp;                   // Current cached temperature  
String inputString;                  // Serial input command string (terminated with \n)

byte buzzes = 0;                     // Number of buzzes to do 
int buzz_time = 0;                   // Next buzz period 
unsigned long buzz_stop = 0;         // Time for buzzer to next stop 
unsigned long buzz_start = 0;        // Time for buzzer to next start

long maxFocuserPos = 1000000;        // Maximum focuser position


void loop() 
{
  // Stepper loop
  stepper.run();

  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(BUZZ_SHORT, 1);
    pwmWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
    tempRequestMilis = millis() + 500;
  }

  // Temperature read loop
  if(sensorConnected && tempRequestMilis != 0 && tempRequestMilis < millis()) requestTemp();  
  if(sensorConnected && tempReadMilis != 0 && tempReadMilis < millis()) readTemp();  

  // Buzzer call
  doBuzz();

  // Manual control
  doButtonsCheck();
}






