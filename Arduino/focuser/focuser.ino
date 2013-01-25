// ASCOM focuser arduino sketch
// ascom-jolo-focuser Google code project
// 
// Author: jolo drjolo@gmail.com
//
// 2013-01-22  0.0.1  first version
// 2013-01-23  0.0.2  non blocking temp read, non blocking stepper
#include <OneWire.h>
#include <DallasTemperature.h>
#include <EEPROM.h>
#include <AccelStepper.h>

// EEPROM addresses
#define FOCUSER_POINTER_ADD 102
#define MANUAL_STEP_ADD 104        
#define STEPPER_SPEED_ADD 103      
#define DUTY_CYCLE_ADDR 105  

// Encoder config
#define encoder0PinA 2
#define encoder0PinB 4
#define encoderButtonPin 3

// Buzzer pin
#define BUZZER_PIN 10

// Temperature sensor config (one wire protocol)
#define TEMP_SENSOR_PIN 5
OneWire oneWire(TEMP_SENSOR_PIN);
DallasTemperature sensors(&oneWire);
DeviceAddress insideThermometer;

// Stepper config
#define STEPS 200                  // Stepper steps for one shaft rotation (including internal gear if available)
#define STEPPER_ACCELERATION 20
AccelStepper stepper(AccelStepper::FULL4WIRE, 6, 7, 8, 9);

word currentFocuserPosition;       
unsigned long tempReadMilis;
boolean sensorConnected;

void loop() 
{
  // Stepper loop
  stepper.run();

  if (stepper.distanceToGo() == 0) {
    if(currentFocuserPosition != stepper.currentPosition()) {
      currentFocuserPosition = stepper.currentPosition();
      saveFocuserPos(currentFocuserPosition);
    }
  }

  // Send temperature read if conversion time elapsed
  if(tempReadMilis != 0 && millis() > tempReadMilis) printTemp();  
}

