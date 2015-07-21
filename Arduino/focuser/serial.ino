void initializeSerial() {
  // Initialize serial
  Serial.begin(57600);
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
// R - move to new position
// P,p - set, get position
// i - get in move
// S,s - set, get stepper speed
// V,v - set, get acceleration
// W,w - set, get PWM motor run
// Z,z - set, get PWM motor stop
// H - halt motor
// J,j - set, get buzzer on
// X,x - set, get max focuser position
// t - get temperature
// d - get dewpoint
// h - get humidity
// B,b - set, get PWM
// a - get ADC
// q - get monitoring values

void serialCommand(String command) {
  String param = command.substring(2); 
  String answer = String(command.charAt(0));
  answer += ":";

  switch(command.charAt(0)) {
    case '#': answer += DEVICE_RESPONSE; buzz(500, 1); break;
    case 'R': stepper.setAcceleration(ctx.acc); analogWrite(STEPPER_PWM_PIN, (255 * ctx.pwmRun/100)); moveStepper(stringToLong(param)); break;
    case 'P': stepper.setCurrentPosition(stringToLong(param)); positionSaved = true; saveFocuserPos(stepper.currentPosition()); break;
    case 'p': answer += stepper.currentPosition(); break;
    case 'i': answer += (stepper.distanceToGo() != 0) ? "1" : "0"; break;
    case 'S': ctx.stepperSpeed = stringToNumber(param); stepper.setMaxSpeed(ctx.stepperSpeed); saveConfig(); break;
    case 's': answer += ctx.stepperSpeed; break;
    case 'V': ctx.acc = stringToNumber(param); saveConfig(); break;
    case 'v': answer += ctx.acc; break;
    case 'W': ctx.pwmRun = constrain(stringToNumber(param), 0, 100); saveConfig(); break;
    case 'w': answer += ctx.pwmRun; break;
    case 'Z': ctx.pwmStop = constrain(stringToNumber(param), 0, 100); saveConfig(); break;
    case 'z': answer += ctx.pwmStop; break;
    case 'H': stepper.stop(); break;
    case 'J': ctx.buzzer = stringToNumber(param); saveConfig(); break;
    case 'j': answer += ctx.buzzer; break;
    case 'X': ctx.maxPos = stringToLong(param); saveConfig(); break;
    case 'x': answer += ctx.maxPos; break;
    case 't': answer += printTemp(); break;
    case 'd': answer += sensor.dew; break;
    case 'h': answer += sensor.hum; break;
    case 'B': setPWM(param); saveConfig(); break;
    case 'b': answer += printPWM(param); break;
    case 'a': answer += readAnalogAvg(ADC_PIN, 3); break;
    case 'q': Serial.print(answer); answer = printMonitor(); break;
    
    default: answer += " error"; buzz(100, 3);
  }
  Serial.print(answer);
  Serial.print('\n');
}


// Serial commands subroutines
String printTemp() {
  if(sensor.type > 0) {
    return formatFloat(sensor.temp, 5, 1);
  } else {
    return "false"; 
  }  
}

String printMonitor() {      
  stepper.run();
  Serial.print(stepper.currentPosition());
  Serial.print(":");
  Serial.print(stepper.distanceToGo());
  Serial.print(":");
  stepper.run();
  Serial.print(sensor.temp);
  Serial.print(":");
  Serial.print(sensor.hum);
  Serial.print(":");
  stepper.run();
  Serial.print(sensor.dew);
  Serial.print(":");
  Serial.print(readPWM(ctx.pwm1));
  Serial.print(":");
  stepper.run();
  Serial.print(readPWM(ctx.pwm2));
  Serial.print(":");
  stepper.run();
  Serial.print(readAnalogAvg(ADC_PIN, 3));
  return String();
}

void setPWM(String param) {
  byte pwm = stringToNumber(param.substring(2));
  switch(param.charAt(0)) {
   case '1': ctx.pwm1 = pwm; break;
   case '2': ctx.pwm2 = pwm; break;
  }
  updatePWM();
}

String printPWM(String param) {
  switch(param.charAt(0)) {
    case '1': return String(readPWM(ctx.pwm1)); break;
    case '2': return String(readPWM(ctx.pwm2)); break;
  }
}


