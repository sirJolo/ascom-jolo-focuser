<<<<<<< HEAD
=======
ver 2.0 production
==================
 - EXT connector extended 
 - PCB redesigned a little and fixed
 - encoder support removed from Arduino sketch
 - 'Connection timeout for message #' bug fixed

>>>>>>> Production_20_RC1
ver 1.5 production
==================
Changelog:
 - encoder support removed
 - PWM stepper duty cycle control switched to Arduino native
 - Eagle project for PCB and reference schematic added (for fixed version wait for 1.6)
 - Reference solution uses L298 stepper driver and some of Arduino pins are now externally available for additional options. Driver implementation will be in 2.0

ver 1.4
==================
Changelog:
 - max focuser position now is 1,000,000
 - driver backslash control removed - noone uses it
 - buzzer turned off by default, can be turned on with BUZZER_ON flag
 - stepper now controlled with half step by default. Please change stepper speed (200%) and step size (50%) in driver settings
 - manual control now with two buttons that perform accelerated motion. Buttons connected to ENCODER_A_PIN and ENCODER_B_PIN
 - MANUAL_FOCUS_MODE added, default to 1 - control with button, NOT encoder
 - STEPPER_ACC increased to 2500
 - MANUAL_STEPPER_ACC for manual button control. Default is 600
 - STEPPER_PWM_FREQ changed to 1000Hz

ascom-jolo-focuser
==================
ASCOM absolute focuser developed using Arduino Nano board and Visual Studio 2008 for ASCOM driver. Uses DS1820 temperature sensor for temperature focus compensation and rotary encoder for manual focus change. Buzzer can be connected to indicate some user interactions, so there is no need to pay attention on any blinking LEDs. Communication with PC is performed over USB cable using Arduino Nano built in UART converter. RS commands set was chosen to implement ASCOM IFocus2 interface with minimum effort, so it is not compatibile with other focuser standards (like Robofocus) that have too much RS communication overhead.
Compiled microcontroller code is 18KB large, so it will not fit into boards with 16KB chip (like Arduino Nano version lower than 3.0). Code size can be shrinked by eliminating 3rd party libraries and making custom implementations.
