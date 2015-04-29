void initializeSerial() {
  // Initialize serial
  Serial.begin(19200);
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

void serialCommand(String command) {
  String param = command.substring(2); 
  String answer = String(command.charAt(0));
  answer += ":";

  switch(command.charAt(0)) {
    case '#': answer += DEVICE_RESPONSE; buzz(500, 1); break;
    case 'R': moveStepper(param); break;
    case 'P': setCurPos(param); break;
    case 'H': haltStepper(param); break;
    case 'B': writeByte(ctx.buzzer, stringToNumber(param)); saveConfig(); break; 
    case 'b': answer += readByte(ctx.buzzer); break;  
    //case 'p': answer += deviceStatus.stepperPos[(byte) stringToNumber(param.substring(0,1))]; break;
    //case 'i': answer += (deviceStatus.stepperMove[(byte) stringToNumber(param.substring(0,1))]) ?  "1" : "0"; break;
 
    default: answer += " error"; buzz(100, 3);
  }
  Serial.print(answer);
  Serial.print('\n');
}


void moveStepper(String param) { //R:1:13444
  byte index = param.charAt(0) - '0';
  long newPos = stringToLong(param.substring(2));
  moveStepper(index, newPos);
}

void setCurPos(String param) { //P:1:3344
  byte index = param.charAt(0) - '0';
  motors[index].setCurrentPosition(stringToLong(param.substring(2)));
  saveFocuserPos(abs(motors[index].currentPosition()), steppers[index].EEPROMstart);
  steppers[index].posSaved = true;
  analogWrite(steppers[index].pwmPin, steppers[index].pwmStop);  
}

void haltStepper(String param) {
  byte index = param.charAt(0) - '0';
  motors[index].stop();
  saveFocuserPos(abs(motors[index].currentPosition()), steppers[index].EEPROMstart);
}

String printTemp() {
  
}

void setPWM(String param) {
  byte index = param.charAt(0) - '0';
  byte pwm = stringToNumber(param.substring(2));
  pwmValues[index] = pwm;
  updatePWM();
}

String printPWM(String param) {
  byte index = param.charAt(0) - '0';
  return String(pwmValues[index]);
}

void printPowers() {
  Serial.print(powerStatus.Vreg);
  Serial.print(":");
  Serial.print(powerStatus.Cust);
  Serial.print(":");
  Serial.print(powerStatus.Vin);
  Serial.print(":");
  Serial.print(powerStatus.Itot);
  Serial.print(":");
  Serial.print(powerStatus.Ah);
  Serial.print(":");
  Serial.print(powerStatus.Wh);
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





*/

