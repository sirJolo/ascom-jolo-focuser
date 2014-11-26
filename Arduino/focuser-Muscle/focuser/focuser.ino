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
//AccelStepper stepper1 = AccelStepper(AccelStepper::HALF4WIRE, 2, 4, A0, A1);  
AccelStepper stepper1 = AccelStepper(AccelStepper::DRIVER, 2, 4);  
//AccelStepper stepper2 = AccelStepper(AccelStepper::HALF4WIRE, 7, 8, A2, A3);  
AccelStepper stepper2 = AccelStepper(AccelStepper::DRIVER, 7, 8);  

// EEPROM addresses
#define FOCUSER1_POS_START 900
#define FOCUSER2_POS_START 800

#define PROP_FOCUSER_OFFSET -200

#define PROP_STEPPER_SPEED PROP_FOCUSER_OFFSET+1
#define PROP_DUTY_CYCLE_RUN PROP_FOCUSER_OFFSET+3
#define PROP_DUTY_CYCLE_STOP PROP_FOCUSER_OFFSET+5
#define PROP_ACC_AUTO PROP_FOCUSER_OFFSET+10
#define PROP_ACC_MAN PROP_FOCUSER_OFFSET+15
#define PROP_BUZZER_ON PROP_FOCUSER_OFFSET+20
#define PROP_MAX_FOC_POS PROP_FOCUSER_OFFSET+30

// PWM config
#define PWM1_PIN 3
#define PWM2_PIN 5
#define PWM3_PIN 6
#define PWM4_PIN 11
  
Timer timer;

// Global vars
boolean positionSaved[2];
long maxFocuserPos[] = {1000000, 1000000};
int EEPROMaddrStart[] = {FOCUSER1_POS_START, FOCUSER2_POS_START}; 
AccelStepper stepper[] = {stepper1, stepper2};
byte stepperPWMPin[] = {STEPPER1_PWM_PIN, STEPPER2_PWM_PIN};

volatile struct {
  long stepperPos[2];
  boolean stepperMove[2];
  byte PWMs[4];
  byte PCFs[6];
} DeviceStatus;

volatile struct {
  byte command;
  byte device;
  long value;
} DeviceCommand;


void loop() 
{
  stepper[0].run();
  stepper[1].run();
  checkStepper(0);
  checkStepper(1);
  
  timer.update();
}






