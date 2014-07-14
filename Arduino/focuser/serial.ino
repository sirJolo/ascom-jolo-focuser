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
    case 'O': digitalWrite(OPTO_PIN, stringToNumber(param)); break;
    case 'o': answer += digitalRead(OPTO_PIN); break;
    case 'L': saveLCDScreens(param); break;
    case 'l': answer += printLCDScreens(); break;
    case 'K': writeByte(PROP_LCD_OFF_DURING_MOVE, stringToNumber(param)); break;
    case 'k': answer += readByte(PROP_LCD_OFF_DURING_MOVE); break;
    case 'M': writeWord(PROP_STEP_SIZE, stringToNumber(param)); break;
    case 'm': answer += readWord(PROP_STEP_SIZE); break;
    case 'q': answer += printMonitor(); break;
    
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
  String ret = String(stepper.currentPosition());
  ret += ":";
  stepper.run();
  ret += stepper.distanceToGo();
  ret += ":";
  stepper.run();
  ret += formatFloat(currentTemp, 5, 1);
  ret += ":";
  stepper.run();
  ret += formatLong(currentHum, 3);
  stepper.run();
  ret += ":";
  stepper.run();
  ret += formatFloat(currentDewpoint, 5, 1);
  ret += ":";
  stepper.run();
  ret += String(readPWM(PROP_PWM6));
  ret += ":";
  stepper.run();
  ret += String(readPWM(PROP_PWM9));
  ret += ":";
  stepper.run();
  ret += String(readPWM(PROP_PWM10));
  ret += ":";
  stepper.run();
  ret += readAnalogAvg(ADC_PIN, 3);
  ret += ":";
  stepper.run();
  ret += String(digitalRead(OPTO_PIN));
  stepper.run();
  return ret;
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

void saveLCDScreens(String param) {
  // "3:4:0:1"
  writeByte(PROP_LCD_SCREEN_0, stringToNumber(param.substring(0,1)));
  writeByte(PROP_LCD_SCREEN_1, stringToNumber(param.substring(2,3)));
  writeByte(PROP_LCD_SCREEN_2, stringToNumber(param.substring(4,5)));
  writeByte(PROP_LCD_SCREEN_3, stringToNumber(param.substring(6)));
}

String printLCDScreens() {
  String ret = String(readByte(PROP_LCD_SCREEN_0));
  ret += ":";
  ret += readByte(PROP_LCD_SCREEN_1);
  ret += ":";
  ret += readByte(PROP_LCD_SCREEN_2);
  ret += ":";
  ret += readByte(PROP_LCD_SCREEN_3);
  return ret;
}

