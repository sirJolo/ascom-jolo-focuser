// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver. Carbon8 10.12.2014
// 
#include <dht.h>
#include <EEPROM.h>
#include <AccelStepper.h>
#include <Timer.h>

#define DEVICE_RESPONSE "Jolo Carbon8 focuser"
#define FIRMWARE "2.2"


// EEPROM addresses
#define FOCUSER_POS_START 900

struct {
  int stepperSpeed;
  byte pwmRun;
  byte pwmStop;
  int acc;
  byte buzzer;
  long maxPos;
  byte pwm1;
  byte pwm2;
  byte pwm3;
} ctx;

struct {
  byte type;
  float temp;
  float hum;
  float dew;
  byte heaterPWM;
} sensor;

// EXT
#define PWM1_PIN 9
#define PWM2_PIN 10
#define PWM3_PIN 11
#define ADC_PIN A0

// Buzzer config
#define BUZZER_PIN 2
#define BUZ_LED_PIN 13

// Temperature sensor config
#define TEMP_CYCLE 3000      // config
#define TEMP_SENSOR_PIN 8
dht DHT;

// Stepper config
#define STEPPER_PWM_PIN 3
//AccelStepper stepper = AccelStepper(AccelStepper::FUNCTION, 5, 4, 6, 7); 
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, 4, 5, 6, 7);  
  
Timer timer;

// Global vars
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
String inputString;                  // Serial input command string (terminated with \n)

int tempCycleEvent;
int buzzCycleEvent;

void loop() 
{
  stepper.run();
  checkStepper();

  timer.update();
}






