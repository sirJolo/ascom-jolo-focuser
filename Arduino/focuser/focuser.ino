// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver. APO130 18.07.2015
// 
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <AccelStepper.h>
#include <Timer.h>
#include <Bounce.h>

#define DEVICE_RESPONSE "Jolo Carbon8 focuser"
#define FIRMWARE "2.2"


// EEPROM addresses
#define FOCUSER_POS_START 900
#define CONFIG_VERSION "ls1"
#define CONFIG_START 800

struct {
  int stepperSpeed; byte pwmRun; byte pwmStop; int acc; 
  byte buzzer; long maxPos; byte pwm1; byte pwm2; byte pwm3;
 // This is for mere detection if they are your settings
  char version_of_program[4];
} ctx = {
  100, 100, 0, 500,
  1, 10000, 0,0,0,
  CONFIG_VERSION
};

struct {
  byte type;
  float temp;
  float hum;
  float dew;
  byte heaterPWM;
} sensor;

// EXT
#define PWM1_PIN 6
#define PWM2_PIN 9
#define PWM3_PIN 5
#define ADC_PIN A3

// Buttons
#define BUTTON_A_PIN 8
#define BUTTON_B_PIN 7
Bounce aButton = Bounce( BUTTON_A_PIN, 30 ); 
Bounce bButton = Bounce( BUTTON_B_PIN, 30 ); 

// Buzzer config
#define BUZZER_PIN 12
#define BUZ_LED_PIN 4

// Temperature sensor config
#define TEMP_CYCLE 5000      // config
#define TEMP_SENSOR_PIN 11
#define SENSOR_DHT22 3
#define SENSOR_DS1820 1
dht DHT;

// Stepper config
#define STEPPER_PWM_PIN 10
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, A2, 13, A1, A0);  
  
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
  doButtonsCheck();  

  timer.update();
}






