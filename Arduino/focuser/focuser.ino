// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
//
// Author: jolo drjolo@gmail.com
// ver. AstroHub 2.9.0
//
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <AccelStepper.h>
#include <Timer.h>
#include <Bounce.h>

#define DEVICE_RESPONSE "Jolo Carbon8 focuser"
#define FIRMWARE "2.9.0"


// EEPROM addresses
#define FOCUSER_POS_START 900
#define CONFIG_VERSION "ls1"
#define CONFIG_START 800

struct {
  int stepperSpeed; byte pwmRun; byte pwmStop; int acc;
  byte buzzer; long maxPos; byte pwm1; byte pwm2; byte pwm3;
  byte stepperMode;     // 0 - unipolar, 1 - bipolar
  // This is for mere detection if they are your settings
  char version_of_program[4];
} ctx = {
  200, 100, 0, 800,
  1, 10000, 0, 0, 0,
  1,
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
#define PWM1_PIN 9
#define PWM2_PIN 10
#define PWM3_PIN 11
#define PWM3_PIN 12
#define ADC_PIN A3

// Buttons
#define BUTTON_A_PIN A0
#define BUTTON_B_PIN A1
Bounce aButton = Bounce( BUTTON_A_PIN, 30 );
Bounce bButton = Bounce( BUTTON_B_PIN, 30 );

// Buzzer config
#define BUZZER_PIN 30

// Temperature sensor config
#define TEMP_CYCLE 5000      // config
#define TEMP_SENSOR_PIN 5
#define SENSOR_DHT22 3
#define SENSOR_DS1820 1
dht DHT;

// Stepper config
#define STEPPER_PWM_PIN 46
AccelStepper stepper = AccelStepper(AccelStepper::HALF4WIRE, A7, A6, A9, A8);

Timer timer;

// Global vars
boolean positionSaved;               // Flag indicates if stepper position was saved as new focuser position
String inputString;                  // Serial input command string (terminated with \n)

int tempCycleEvent;
bool silent;                         // Do not buzz when using buttons for focusing, its annoying

void loop()
{
  stepper.run();
  checkStepper();
  doButtonsCheck();

  timer.update();
}







