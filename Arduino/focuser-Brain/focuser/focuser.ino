// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver 3.0 - device control unit
// 
#include <OneWire.h>
#include <DallasTemperature.h>
#include <AccelStepper.h>
#include <dht.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <Timer.h>
#include <Wire.h>

#define DEVICE_RESPONSE "Jolo primary focuser"
#define FIRMWARE "3.0"

#define DEBUG true

// EEPROM addresses --------------------------------------------------------------------------//
#define FOCUSER1_POS_START 1000
#define FOCUSER2_POS_START 2000
int FocusersADDR[] = {FOCUSER1_POS_START, FOCUSER2_POS_START};
#define CONFIG_VERSION "ls1"
#define CONFIG_START 900

// Stepper config ----------------------------------------------------------------------------//
#define STEPPER1_PWM_PIN 9
#define STEPPER2_PWM_PIN 10
AccelStepper motors[] = { AccelStepper(forward1Step, backward1Step),
                          AccelStepper(forward2Step, backward2Step)}; 

struct StepperCtx {
  boolean posSaved; long maxPos; int pps; int accMan; int accAuto;
  byte pwmStop; byte pwmRun; byte pwmPin;
  int EEPROMstart; byte curStep; boolean reversed;
};

StepperCtx stepper1, stepper2;
StepperCtx steppers[] = {stepper1, stepper2};

// DC motor config ---------------------------------------------------------------------------//
#define DCMOTOR_PWM_PIN 9
#define DCMOTOR_CW_PIN 10
#define DCMOTOR_CCW_PIN 11

struct {
  byte pwm; byte dir; int time; boolean moving;
} dcMotor;

// ADC -----------------------------------------------------------------------------------------//
#define Vin_PIN A6
#define Vreg_PIN A8
#define Itot_PIN A7

struct {
  int Vreg; int Cust; int Vin; int Itot; float Ah; float Wh; int vregs[5]; int vins[5]; int itots[5]; byte cycle;
} powerStatus = {
  0, 0, 0, 0, 0.0, 0.0, {0,0,0}, {0,0,0}, {0,0,0}, 0
};

// PWM config ----------------------------------------------------------------------------------//
#define PWM1_PIN 3
#define PWM2_PIN 5
#define PWM3_PIN 6
#define PWM4_PIN 11
byte pwmPins[] = {PWM1_PIN, PWM2_PIN, PWM3_PIN, PWM4_PIN};
byte pwmValues[] = {0,0,0,0};

// Buzzer config -------------------------------------------------------------------------------//
#define BUZZER_PIN 13

// Temperature sensor config -------------------------------------------------------------------//
struct TempSensor {
  byte sensorType; float currentTemp; float currentHum;                   
  float currentDewpoint; byte heaterPWM; byte sensorPin;
};

#define TEMP_SENSOR1_PIN 9
#define TEMP_SENSOR2_PIN 10
#define TEMP_SENSOR3_PIN 11
OneWire oneWire(TEMP_SENSOR1_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;
dht DHT;
  
// Properties config --------------------------------------------------------------------------//
struct {
  char ver[4];
  int stepperSpeed[2]; byte pwmRun[2]; byte pwmStop[2]; int acc[2];
  byte buzzer; long maxPos[2];
} ctx = {
  CONFIG_VERSION,
  {100,100}, {100,100}, {0,0}, {400,400},
  1, {1000000,1000000}
};

// Other -------------------------------------------------------------------------------------//
Timer timer;

// Global vars -------------------------------------------------------------------------------//
TempSensor tempSensors[3];
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






