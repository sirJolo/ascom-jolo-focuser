void initializeSerial() {
  // Initialize serial
  Serial.begin(9600);
  Serial.setTimeout(2000);

  inputString = "";
}  

// Interrupt serial event
void serialEvent() {
  while (Serial.available() > 0) {
    char inChar = (char)Serial.read(); 
    if (inChar == '\n') {
      serialCommand(inputString); 
      inputString = "";
    } 
    else {
      inputString += inChar;
    }
  }  
}

// COMMAND SET
// R - move to new position                            R:1:13444
// P,p - set, get position                             P:1:3344    p:1
// i - get in move                                     i:1
// H - halt motor
// B,b - set, get buzzer on                            J:1         j
// t - get temperature                                 t:0
// d - get dewpoint                                    d:0
// h - get humidity                                    h:0
// Q,q - set, get PWM                                  B:3:90      b:1
// F,f - set, get digi IO                              F:3:1       f:0
// a - get ADC                                         a:1
// q - get monitoring values                           q
// C - save config                                     C:<speed>:<acc man>:<acc auto>:<step size>:<pwm stop>:<pwm man>:<max pos>: and for stepper #2...

void serialCommand(String command) {
  String param = command.substring(2); 
  String answer = String(command.charAt(0));
  answer += ":";

  switch(command.charAt(0)) {
    case '#': answer += DEVICE_RESPONSE; buzz(500, 1); break;
    case 'R': moveStepper(param); break;
    case 'P': setCurPos(param); break;
    case 'p': answer += deviceStatus.stepperPos[(byte) stringToNumber(param.substring(0,1))]; break;
    case 'i': answer += (deviceStatus.stepperMove[(byte) stringToNumber(param.substring(0,1))]) ?  "1" : "0"; break;
    case 'H': haltStepper(param); break;
    case 'B': writeByte(PROP_BUZZER_ON, stringToNumber(param)); break;  //TODO - copy to slave
    case 'b': answer += readByte(PROP_BUZZER_ON); break;   
    case 'C': sendConfig(param); break;    
   
    default: answer += " error"; buzz(100, 3);
  }
  Serial.print(answer);
  Serial.print('\n');
}

void sendConfig(String param) {  //<speed>:<acc man>:<acc auto>:<step size>:<pwm stop>:<pwm man>:<max pos>: and for stepper #2...
  byte counter = 0;
  byte lastIndex = 0;
  for (byte i = 0; i < param.length(); i++) {
    if (param.substring(i, i+1) == ":") {
      dispatchConfig(counter, stringToLong(param.substring(lastIndex, i)));
      lastIndex = i + 1;
      counter++;
    }
    if (i == param.length() - 1) {
      dispatchConfig(counter, stringToLong(param.substring(lastIndex, i)));
    }
  }
}

void dispatchConfig(byte index, long value) {
  deviceCommand.value = value;
  deviceCommand.device = (index > 7) ? 2 : 1;
  deviceCommand.command = commandMap[index % 7];
  sendCommand();
}

void moveStepper(String param) { //R:1:13444
  deviceCommand.command = 1; 
  deviceCommand.device = (byte) stringToNumber(param.substring(0,1));
  deviceCommand.value = stringToLong(param.substring(2));
  sendCommand();
}

void setCurPos(String param) { //P:1:3344
  deviceCommand.command = 9; 
  deviceCommand.device = (byte) stringToNumber(param.substring(0,1));
  deviceCommand.value = stringToLong(param.substring(2));  
  sendCommand();
}

void haltStepper(String param) {
  deviceCommand.command = 2; 
  deviceCommand.device = (byte) stringToNumber(param.substring(0,1));
  deviceCommand.value = 0;  
  sendCommand();  
}

String printTemp() {
  
}

/*
// Serial commands subroutines
String printTemp() {
  if(sensorType > 0) {
    return formatFloat(currentTemp, 5, 1);
  } else {
    return "false"; 
  }  
}

String printMonitor() {      // pos, togo, temp, hum, dew, pwms, adc, opto
  stepper.run();
  Serial.print(stepper.currentPosition());
  Serial.print(":");
  Serial.print(stepper.distanceToGo());
  Serial.print(":");
  stepper.run();
  Serial.print(currentTemp);
  Serial.print(":");
  Serial.print(currentHum);
  Serial.print(":");
  stepper.run();
  Serial.print(currentDewpoint);
  Serial.print(":");
  Serial.print(readPWM(PROP_PWM6));
  Serial.print(":");
  stepper.run();
  Serial.print(readPWM(PROP_PWM9));
  Serial.print(":");
  Serial.print(readPWM(PROP_PWM10));
  Serial.print(":");
  stepper.run();
  Serial.print(readAnalogAvg(ADC_PIN, 3));
  Serial.print(":");
  Serial.print(digitalRead(OPTO_PIN));
  return String();
}

void setPWM(String param) {
  byte pwm = stringToNumber(param.substring(2));
  switch(param.charAt(0)) {
   case '6': writeByte(PROP_PWM6, pwm); break;
   case '9': writeByte(PROP_PWM9, pwm); break;
   case '0': writeByte(PROP_PWM10, pwm); break;
  }
  updatePWM();
}

String printPWM(String param) {
  switch(param.charAt(0)) {
    case '6': return String(readPWM(PROP_PWM6)); break;
    case '9': return String(readPWM(PROP_PWM9)); break;
    case '0': return String(readPWM(PROP_PWM10)); break;
  }
}

*/

