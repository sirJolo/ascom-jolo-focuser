// ASCOM focuser arduino sketch
// ascom-jolo-focuser Google code project
// 
// Author: jolo drjolo@gmail.com
// ver. 1.3 08-11-2013
// ver. 1.4 11-11-2013
// ver. 1.5 - production
// removed encoder
// add signal led
// 
// 
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <AccelStepper.h>
#include <Bounce.h>
#include <LiquidCrystal.h>
#include <Timer.h>

#define DEVICE_RESPONSE "Jolo primary focuser"

// LCD initialization
#define LCD_LINE_1 "Temperature <ttt>"
#define LCD_LINE_2 "Position <pppp>"
#define LCD_REFRESH_TIME 500
LiquidCrystal lcd(11, 12, 7, 8, 9, 10);
Timer timer;

// EEPROM addresses
#define FOCUSER_POS_START 900
#define STEPPER_SPEED_ADD 3      
#define DUTY_CYCLE_ADDR 2  

// Encoder config
#define ENCODER_OUT_PIN 4
#define ENCODER_IN_PIN 3
Bounce outButton = Bounce( ENCODER_OUT_PIN, 30 ); 
Bounce inButton = Bounce( ENCODER_IN_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 5
#define BUZZ_LONG 300
#define BUZZ_SHORT 50
#define BUZZ_PAUSE 50
#define BUZZER_ON true
#define BUZ_LED_PIN 13

// Temperature sensor config (one wire protocol)
#define TEMP_CYCLE 3000
#define TEMP_SENSOR_PIN 2
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Stepper config
#define STEPPER_ACC 2500
#define MANUAL_STEPPER_ACC 600
#define STEPPER_PWM_PIN 6
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, A3, A4, A1, A5);

// Global vars
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
unsigned long tempRequestMilis;      // Next temperature request time
unsigned long tempReadMilis;         // Next temperature read time (188ms after temperature read request) 
boolean sensorConnected;             // Flag indicates if temperature sensor is connected
float currentTemp;                   // Current cached temperature  
String inputString;                  // Serial input command string (terminated with \n)

byte buzzes = 0;                     // Number of buzzes to do 
int buzz_time = 0;                   // Next buzz period 
unsigned long buzz_next_action = 0;  // Time to next buzz action change

int manualStep = 16;                 // Manual focuser position change in steps 
long maxFocuserPos = 1000000;        // Maximum focuser position


void loop() 
{
  // Stepper loop
  stepper.run();

  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(BUZZ_SHORT, 1);
    analogWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
    tempRequestMilis = millis() + 500;
  }

  // Temperature read loop
  if(sensorConnected && tempRequestMilis != 0 && tempRequestMilis < millis()) requestTemp();  
  if(sensorConnected && tempReadMilis != 0 && tempReadMilis < millis()) readTemp();  

  // Buzzer call
  doBuzz();

  // Manual control
  doButtonsCheck();
  
  // Timer to update LCD
  timer.update();

}






