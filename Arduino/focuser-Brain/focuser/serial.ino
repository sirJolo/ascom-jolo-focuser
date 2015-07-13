void initializeSerial() {
  // Initialize serial
  Serial.begin(19200);
  Serial.setTimeout(2000);

  inputString.reserve(15);
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
// M - set motor mode (uni / bi)                       M:1:0
// i - get in move                                     i:1
// H - halt motor
// B,b - set, get buzzer on                            B:1         b
// u - get powers
// s - get sensors
// Q,q - set, get PWM                                  B:3:90      b:1


void serialCommand(String command) {
  String param = command.substring(2); 
  String answer;
  answer.reserve(120);
  answer = String(command.charAt(0));
  answer += ":";

  switch(command.charAt(0)) {
    case '#': answer += DEVICE_RESPONSE; buzz(500, 1); break;
    case 'R': moveStepper(param); break;
    case 'P': setCurPos(param); break;
    case 'M': setStepperMode(param); break;
    case 'H': haltStepper(param); break;
    case 'B': writeByte(ctx.buzzer, stringToNumber(param)); saveConfig(); break; 
    case 'b': answer += readByte(ctx.buzzer); break;  
    case 'u': answer += printPowers(); break;
    case 's': answer += printSensors(); break;
    case 'Q': setPWM(param); break;
    case 'q': answer += getPWM(param); break;
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
  analogWrite(steppers[index].pwmPin, ctx.pwmStop[index]);  
}

void setStepperMode(String param) {
  byte index = param.charAt(0) - '0';
  motors[index].setMode(stringToLong(param.substring(2)));
}

void haltStepper(String param) {
  byte index = param.charAt(0) - '0';
  motors[index].stop();
  saveFocuserPos(abs(motors[index].currentPosition()), steppers[index].EEPROMstart);
}


void setPWM(String param) {
  byte index = param.charAt(0) - '0';
  byte pwm = stringToNumber(param.substring(2));
  pwmValues[index] = pwm;
  updatePWM();
}

String getPWM(String param) {
  byte index = param.charAt(0) - '0';
  return String(pwmValues[index]);
}

String printSensors() {
  String buf; buf.reserve(100); buf = "";
  for(byte i = 0; i < 3; i++) {
    buf += tempSensors[i].sensorType + ":";
    buf += String(tempSensors[i].currentTemp, 1) + ":";
    buf += String(tempSensors[i].currentHum, 0) + ":";
    buf += String(tempSensors[i].currentDewpoint, 1) + ":";
    buf += tempSensors[i].heaterPWM;
    if (i<2) buf += ":";
  } 
  return buf;
}

String printPowers() {
  String buf; buf.reserve(40); buf = "";
  buf += String(powerStatus.Vreg) + ":";
  buf += String(powerStatus.Cust) + ":";
  buf += String(powerStatus.Vin) + ":";
  buf += String(powerStatus.Itot); + ":";
  buf += String(powerStatus.Ah, 1) + ":";
  buf += String(powerStatus.Wh, 1);
  return buf;
}



