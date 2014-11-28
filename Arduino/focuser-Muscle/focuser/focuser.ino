// ASCOM focuser arduino sketch
// ascom-jolo-focuser github project
// 
// Author: jolo drjolo@gmail.com
// ver 3.0 - stepper control unit
// 
#include <Wire.h>
#include <EEPROM.h>
#include <EepromUtil.h>
#include <AccelStepper.h>
#include <Timer.h>
#include <PWM.h>

#define I2C_ADDR 30
#define BUZZER_PIN 13

// Stepper config
#define STEPPER1_PWM_PIN 9
#define STEPPER2_PWM_PIN 10

// PWM config
#define PWM1_PIN 3
#define PWM2_PIN 5
#define PWM3_PIN 6
#define PWM4_PIN 11

// Unipolar, probably L293 drivers (so we can have PWM)
//AccelStepper stepper1 = AccelStepper(forward1Step, backward1Step);  
//AccelStepper stepper2 = AccelStepper(forward2Step, backward2Step);  

// Bipolar A4988 drivers
AccelStepper stepper1 = AccelStepper(AccelStepper::DRIVER, 2, 4);  
AccelStepper stepper2 = AccelStepper(AccelStepper::DRIVER, 7, 8);  

// EEPROM addresses
#define FOCUSER1_POS_START 900
#define FOCUSER2_POS_START 800
#define PROP_BUZZER_ON 700  

// Global vars
Timer timer;

byte pwmPins[] = {PWM1_PIN, PWM2_PIN, PWM3_PIN, PWM4_PIN};
byte pwmValues[] = {0,0,0,0};
boolean commandDispatched = true;

struct StepperCtx {
  boolean posSaved;
  long maxPos;
  int pps;
  int accMan;
  int accAuto;
  byte pwmStop;
  byte pwmRun;
  AccelStepper motor;
  byte pwmPin;
  int EEPROMstart;
  byte curStep;
};

StepperCtx motor1, motor2;
StepperCtx motors[] = {motor1, motor2};

volatile struct {
  long stepperPos[2];
  boolean stepperMove[2];
  byte PWMs[4];
} DeviceStatus;

volatile struct {
  byte command;
  byte device;
  long value;
} DeviceCommand;


void loop() 
{
  motors[0].motor.run();
  motors[1].motor.run();
  checkStepper(0);
  checkStepper(1);
  
  timer.update();
}






