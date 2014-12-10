// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver. Carbon8 10.12.2014
// 
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <JoloAccelStepper.h>
#include <Timer.h>

#define DEVICE_RESPONSE "Jolo Carbon8 focuser"
#define FIRMWARE "2.2"

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
#define PROP_MAX_FOC_POS PROPERTY_ADDR+30
#define PROP_PWM6 PROPERTY_ADDR+50
#define PROP_PWM9 PROPERTY_ADDR+51
#define PROP_PWM10 PROPERTY_ADDR+52
#define PROP_STEP_SIZE PROPERTY_ADDR+53

// EXT
#define PWM_PIN6 6
#define PWM_PIN9 9
#define PWM_PIN10 10
#define ADC_PIN A1

// Buzzer config
#define BUZZER_PIN 4
#define BUZ_LED_PIN 13

// Temperature sensor config
#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR_PIN 2
dht DHT;

// Stepper config
#define STEPPER_PWM_PIN 11
JoloAccelStepper stepper = JoloAccelStepper(AccelStepper::FUNCTION, A5, A4, A3, A2);  
  
Timer timer;

// Global vars
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
byte sensorType = 0;                 // 0-none, 1-DS8120, 2-DHT11, 3-DHT22
float currentTemp;                   // Current cached temperature  
float currentHum;                    // Current cached humidity
float currentDewpoint;               // Current cached dew point temperature
byte heaterPWM = 0;                  // Calculated PWM on hum
String inputString;                  // Serial input command string (terminated with \n)

int tempCycleEvent;
int buzzCycleEvent;

long maxFocuserPos = 1000000;        // Maximum focuser position

void loop() 
{
  stepper.run();
  checkStepper();

  timer.update();
}






