void initializeSerial() {
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


void serialCommand(String command) {
  String param = command.substring(2); 
  String answer = String(command.charAt(0));
  answer += ":";

  switch(command.charAt(0)) {
    case '#': answer += DEVICE_RESPONSE; buzz(500, 1); break;
    case 'R': moveStepper((byte) stringToNumber(param.substring(0,1)), stringToLong(param.substring(2))); break;
    case 'P': motors[(byte) stringToNumber(param.substring(0,1))].motor.setCurrentPosition(stringToLong(param.substring(2))); break;
    case 'p': answer += DeviceStatus.stepperPos[(byte) stringToNumber(param.substring(0,1))]; break;
    case 'i': answer += (DeviceStatus.stepperMove[(byte) stringToNumber(param.substring(0,1))]) ?  "1" : "0"; break;
    case 'H': motors[(byte) stringToNumber(param.substring(0,1))].motor.stop(); break;
     
   
    default: answer += " error"; buzz(100, 3);
  }
  Serial.print(answer);
  Serial.print('\n');
}
