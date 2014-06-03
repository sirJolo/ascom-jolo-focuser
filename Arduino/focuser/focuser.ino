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
#include <PWM.h>
#include <Bounce.h>
#include <dht.h>
#include <LiquidCrystal.h>
#include <Timer.h>

#define DEVICE_RESPONSE "Jolo primary focuser"
#define FIRMWARE "2.0"

// EEPROM addresses
#define FOCUSER_POS_START 900
#define STEPPER_SPEED_ADD 3      
#define DUTY_CYCLE_ADDR 2  
#define LCD_1_ADDR 100
#define LCD_2_ADDR 120

// Encoder config
#define ENCODER_A_PIN 7
#define ENCODER_B_PIN 8
Bounce aButton = Bounce( ENCODER_A_PIN, 30 ); 
Bounce bButton = Bounce( ENCODER_B_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 4
#define BUZZ_LONG 800
#define BUZZ_SHORT 200
#define BUZZER_ON true      // config
#define BUZ_LED_PIN 13

// Temperature sensor config
#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR_PIN 2
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
dht DHT;

// Stepper config
#define STEPPER_ACC 2500          // config up/down
#define MANUAL_STEPPER_ACC 600    // config up/down
#define STEPPER_PWM_FREQ 1000     // config run/hold
#define STEPPER_PWM_PIN 11

// LCD config (to EXT slot)
LiquidCrystal lcd(3, 5, 6, 9, 10, 12);
Timer timer;


// Global vars
AccelStepper stepper;
char lcd_1 [16];                     // LCD lines template
char lcd_2 [16];
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
  // Stepper loop
  stepper.run();

  if(stepper.distanceToGo() == 0 && !positionSaved) {
    saveFocuserPos(stepper.currentPosition());
    positionSaved = true;
    buzz(BUZZ_SHORT, 1);
    pwmWrite(STEPPER_PWM_PIN, (255 * EEPROM.read(DUTY_CYCLE_ADDR)/100));
    tempCycleEvent = timer.after(TEMP_CYCLE, requestTemp);
  }

  // Manual control
  doButtonsCheck();
  
  // Timer update
  timer.update();
}






