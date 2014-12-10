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
// R - move to new position
// P,p - set, get position
// i - get in move
// S,s - set, get stepper speed
// U,u - set, get manual acceleration
// V,v - set, get ASCOM acceleration
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
// O,o - set, get opto
// L,l - set, get LCD screens
// K,k - set, get LCD off during stepper move
// M,m - set, get stepper step (in 1/10um)
// q - get monitoring values

void serialCommand(String command) {
  String param = command.substring(2); 
  String answer = String(command.charAt(0));
  answer += ":";

  switch(command.charAt(0)) {
    case '#': answer += DEVICE_RESPONSE; buzz(500, 1); break;
    case 'R': stepper.setAcceleration(readWord(PROP_ACC_AUTO)); moveStepper(stringToLong(param)); break;
    case 'P': stepper.setCurrentPosition(stringToLong(param)); positionSaved = true; saveFocuserPos(stepper.currentPosition()); break;
    case 'p': answer += stepper.currentPosition(); break;
    case 'i': answer += (stepper.distanceToGo() != 0) ? "1" : "0"; break;
    case 'S': writeWord(PROP_STEPPER_SPEED, stringToNumber(param)); stepper.setMaxSpeed(readWord(PROP_STEPPER_SPEED)); break;
    case 's': answer += readWord(PROP_STEPPER_SPEED); break;
    case 'U': writeWord(PROP_ACC_MAN, stringToNumber(param)); break;
    case 'u': answer += readWord(PROP_ACC_MAN); break;
    case 'V': writeWord(PROP_ACC_AUTO, stringToNumber(param)); break;
    case 'v': answer += readWord(PROP_ACC_AUTO); break;
    case 'W': writeByte(PROP_DUTY_CYCLE_RUN, constrain(stringToNumber(param), 0, 100)); break;
    case 'w': answer += readByte(PROP_DUTY_CYCLE_RUN); break;
    case 'Z': writeByte(PROP_DUTY_CYCLE_STOP, constrain(stringToNumber(param), 0, 100)); break;
    case 'z': answer += readByte(PROP_DUTY_CYCLE_STOP); break;
    case 'H': stepper.stop(); break;
    case 'J': writeByte(PROP_BUZZER_ON, stringToNumber(param)); break;
    case 'j': answer += readByte(PROP_BUZZER_ON); break;
    case 'X': writeLong(PROP_MAX_FOC_POS, stringToLong(param)); maxFocuserPos = readLong(PROP_MAX_FOC_POS); break;
    case 'x': answer += readLong(PROP_MAX_FOC_POS); break;
    case 't': answer += printTemp(); break;
    case 'd': answer += formatFloat(currentDewpoint, 5, 1); break;
    case 'h': answer += formatLong(currentHum, 3); break;
    case 'B': setPWM(param); break;
    case 'b': answer += printPWM(param); break;
    case 'a': answer += readAnalogAvg(ADC_PIN, 3); break;
    case 'M': writeWord(PROP_STEP_SIZE, stringToNumber(param)); break;
    case 'm': answer += readWord(PROP_STEP_SIZE); break;
    case 'q': Serial.print(answer); answer = printMonitor(); break;
    
    default: answer += " error"; buzz(100, 3);
  }
  Serial.print(answer);
  Serial.print('\n');
}


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


