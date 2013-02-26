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
#include <Bounce.h>

#define DEVICE_RESPONSE "Jolo primary focuser"

// EEPROM addresses
#define FOCUSER_POS_START 900
#define STEPPER_SPEED_ADD 3      
#define DUTY_CYCLE_ADDR 2  

// Encoder config
#define ENCODER_A_PIN 3
#define ENCODER_B_PIN 5
#define ENCODER_BUTTON_PIN 4
Bounce pushButton = Bounce( ENCODER_BUTTON_PIN, 20 ); 

// Buzzer config
#define BUZZER_PIN 11
#define BUZZ_LONG 400
#define BUZZ_SHORT 40

// Temperature sensor config (one wire protocol)
#define TEMP_CYCLE 3000
#define TEMP_SENSOR_PIN 7
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Stepper config
#define STEPPER_ACC 800
#define STEPPER_PWM_FREQ 2000
#define STEPPER_PWM_PIN 9
AccelStepper stepper = AccelStepper(AccelStepper::FULL4WIRE, A5, A3, 6, 2);

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

int manualStep = 16;                 // Manual focuser position change in steps 
word maxFocuserPos = 65000;          // Maximum focuser position

int encoderMode = 0;                 // Focus mode


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

  // Encoder check
  doEncoder();

  // Push  button check
  doPushButtonCheck();

}





