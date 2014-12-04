void intializeDCmotor() {
  stopDCMotor();
  
  dcMotor.moving = false;
  dcMotor.time = 0;
  dcMotor.pwm = 0;
  dcMotor.dir = 1;
}

void runDCMotor() {
  analogWrite(DCMOTOR_PWM_PIN, dcMotor.pwm);
  digitalWrite(DCMOTOR_CW_PIN, dcMotor.dir);
  digitalWrite(DCMOTOR_CCW_PIN, !dcMotor.dir);
  dcMotorEvent = timer.after(dcMotor.time, stopDCMotor);
}

void stopDCMotor() {
  timer.stop(dcMotorEvent);
  analogWrite(DCMOTOR_PWM_PIN, 0);
  digitalWrite(DCMOTOR_CW_PIN, LOW);
  digitalWrite(DCMOTOR_CCW_PIN, LOW);  
}
