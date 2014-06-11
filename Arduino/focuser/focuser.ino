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
#define DUTY_CYCLE_ADDR 2  

// Encoder config
<<<<<<< HEAD
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
=======
#define ENCODER_A_PIN 8
#define ENCODER_B_PIN 7
Bounce aButton = Bounce( ENCODER_A_PIN, 30 ); 
Bounce bButton = Bounce( ENCODER_B_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 4
#define BUZZER_ON true      // config
>>>>>>> Production_20_RC1
#define BUZ_LED_PIN 13

// Temperature sensor config
#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR_PIN 2
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Stepper config
<<<<<<< HEAD
#define STEPPER_ACC 2500
#define MANUAL_STEPPER_ACC 600
#define STEPPER_PWM_PIN 6
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, A3, A4, A1, A5);
=======
#define STEPPER_ACC 2500          // config up/down
#define MANUAL_STEPPER_ACC 600    // config up/down
#define STEPPER_PWM_PIN 11
#define MSI2_PIN A5
#define MSI1_PIN A4

Timer timer;
>>>>>>> Production_20_RC1

// Global vars
AccelStepper stepper;
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
byte sensorType = 0;                 // 0-none, 1-DS8120, 2-DHT11, 3-DHT22
float currentTemp;                   // Current cached temperature  
float currentHum;                    // Current cached humidity
float currentDewpoint;               // Current cached dew point temperature
String inputString;                  // Serial input command string (terminated with \n)

<<<<<<< HEAD
byte buzzes = 0;                     // Number of buzzes to do 
int buzz_time = 0;                   // Next buzz period 
unsigned long buzz_next_action = 0;  // Time to next buzz action change
=======
int tempCycleEvent;
int buzzCycleEvent;
>>>>>>> Production_20_RC1

long maxFocuserPos = 1000000;        // Maximum focuser position

<<<<<<< HEAD

=======
>>>>>>> Production_20_RC1
void loop() 
{
  stepper.run();
  checkStepper();

<<<<<<< HEAD
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
=======
>>>>>>> Production_20_RC1
  doButtonsCheck();
  
  if( stepper.distanceToGo() == 0) {timer.update();}
}






