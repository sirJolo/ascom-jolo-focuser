// AstroHub arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver 3.0 
// 
#include <OneWire.h>
#include <DallasTemperature.h>
#include <JoloAccelStepper.h>
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <Timer.h>
#include <Wire.h>

#define DEVICE_RESPONSE "Jolo AstroHub"
#define FIRMWARE "3.0"

#define DEBUG true

// EEPROM addresses --------------------------------------------------------------------------//
#define FOCUSER1_POS_START 1000
#define FOCUSER2_POS_START 2000
#define CONFIG_VERSION "ls1"
#define CONFIG_START 500

// Stepper config ----------------------------------------------------------------------------//
#define STEPPER1_PWM_PIN 46
#define STEPPER2_PWM_PIN 45
JoloAccelStepper motors[] = { JoloAccelStepper(JoloAccelStepper::FUNCTION, A6, A7, A8, A9, true),
                              JoloAccelStepper(JoloAccelStepper::FUNCTION, A10, A11, A12, A13, true)}; 

struct StepperCtx {
  boolean posSaved; int EEPROMstart; int pwmPin;
};

StepperCtx steppers[] = {{false, FOCUSER1_POS_START, STEPPER1_PWM_PIN}, {false, FOCUSER2_POS_START, STEPPER2_PWM_PIN}};

// DC motor config ---------------------------------------------------------------------------//
#define DCMOTOR_PWM_PIN 8
#define DCMOTOR_CW_PIN A4
#define DCMOTOR_CCW_PIN A5

struct {
  byte pwm; byte dir; int time; boolean moving;
} dcMotor;

// ADC -----------------------------------------------------------------------------------------//
#define Vin_PIN A2
#define Vreg_PIN A3
#define Itot_PIN A15

struct {
  int Vreg; int Cust; int Vin; int Itot; float Ah; float Wh; int vregs[5]; int vins[5]; int itots[5]; byte cycle;
} powerStatus = {
  0, 0, 0, 0, 0.0, 0.0, {0,0,0}, {0,0,0}, {0,0,0}, 0
};

// PWM config ----------------------------------------------------------------------------------//
#define PWM1_PIN 9
#define PWM2_PIN 10
#define PWM3_PIN 11
#define PWM4_PIN 12
byte pwmPins[] = {PWM1_PIN, PWM2_PIN, PWM3_PIN, PWM4_PIN};
byte pwmValues[] = {0,0,0,0};

// Buzzer config -------------------------------------------------------------------------------//
#define BUZZER_PIN 26

// Temperature sensor config -------------------------------------------------------------------//
struct TempSensor {
  byte sensorType; float currentTemp; float currentHum;                   
  float currentDewpoint; byte heaterPWM; byte sensorPin;
};

#define TEMP_SENSOR1_PIN 5
#define TEMP_SENSOR2_PIN 6
#define TEMP_SENSOR3_PIN 7
#define NO_SENSOR 0
#define DS_SENSOR 1
#define DHT_SENSOR 3
OneWire oneWire(TEMP_SENSOR1_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
dht DHT;

TempSensor tempSensors[] = {{0,0.0,0.0,0.0,0,0}, {0,0.0,0.0,0.0,0,0}, {0,0.0,0.0,0.0,0,0}};
  
// Properties config --------------------------------------------------------------------------//
struct {
  char ver[4];
  int stepperSpeed[2]; byte pwmRun[2]; byte pwmStop[2]; int accAuto[2]; int accMan[2];
  byte buzzer; long maxPos[2]; boolean reversed[2]; byte mode[2]; byte dcPWM;
} ctx = {
  CONFIG_VERSION,
  {100,100}, {100,100}, {0,0}, {400,400}, {200,200},
  1, {1000000,1000000}, {false, false}, {0,0}, 100
};

// Other -------------------------------------------------------------------------------------//
Timer timer;

// Global vars -------------------------------------------------------------------------------//
String inputString;                  

int tempCycleEvent;
int buzzCycleEvent;
int statusCycleEvent;
int adcCycleEvent;
int dcMotorEvent;

// MAIN  ------------------------------------------------------------------------------------//
void loop() 
{
  motors[0].run();
  motors[1].run();
  checkStepper(0);
  checkStepper(1);
  
  timer.update();
}






