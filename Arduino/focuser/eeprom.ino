void saveFocuserPos(long newPos) {
  writeLong(getSaveFocuserPosAddress() + 1, newPos);
}

long readFocuserPos() {
  return readLong(getReadFocuserPosAddress() + 1);
}

void writeByte(word address, byte value) {
  if(readByte(address) != value) EEPROM.write(address, value);
}

word readByte(word address) {
  return EEPROM.read(address);   
}

void writeWord(word address, word value) {
  if(readWord(address) != value) {
    EEPROM.write(address, lowByte(value)); 
    EEPROM.write(address + 1, highByte(value)); 
  }
}

word readWord(word address) {
  return word(EEPROM.read(address + 1), EEPROM.read(address));   
}

long readLong(word address) {
  word lowWord = readWord(address);
  word highWord = readWord(address + 2);
  return lowWord + highWord * 65536;
}

boolean writeLong(word address, long value) {
  word lowWord = value % 65536;
  word highWord = value / 65536;
  writeWord(address, lowWord);
  writeWord(address + 2, highWord);
}

// Simple EEPROM wear leveling
int getSaveFocuserPosAddress() {
  for(byte x = 0; x < 20; x++) {
    int address = FOCUSER_POS_START + 5*x;
    if(EEPROM.read(address) == 0) {
      EEPROM.write(address, 0xFF);
      return address;
    }
  } 
  // Array is full, erase it and start from 0 - takes about 100ms
  for(byte x = 0; x < 100; x++) EEPROM.write(FOCUSER_POS_START + 5*x, 0);
  EEPROM.write(FOCUSER_POS_START, 0xFF);
  return FOCUSER_POS_START;
}

int getReadFocuserPosAddress() {
  for(byte x = 0; x < 20; x++) {
    int address = FOCUSER_POS_START + 5*x;
    if(EEPROM.read(address) == 0) return (address - 5);
  }
}


void loadConfig() {
  // To make sure there are settings, and they are YOURS!
  // If nothing is found it will use the default ctx.
  if (//EEPROM.read(CONFIG_START + sizeof(settings) - 1) == ctx.version_of_program[3] // this is '\0'
      EEPROM.read(CONFIG_START + sizeof(ctx) - 2) == ctx.version_of_program[2] &&
      EEPROM.read(CONFIG_START + sizeof(ctx) - 3) == ctx.version_of_program[1] &&
      EEPROM.read(CONFIG_START + sizeof(ctx) - 4) == ctx.version_of_program[0])
  { // reads settings from EEPROM
    for (unsigned int t=0; t<sizeof(ctx); t++)
      *((char*)&ctx + t) = EEPROM.read(CONFIG_START + t);
  } else {
    // settings aren't valid! will overwrite with default settings
    saveConfig();
  }
}

void saveConfig() {
  for (unsigned int t=0; t<sizeof(ctx); t++)
  { // writes to EEPROM
    EEPROM.write(CONFIG_START + t, *((char*)&ctx + t));
    // and verifies the data
    if (EEPROM.read(CONFIG_START + t) != *((char*)&ctx + t))
    {
      // error writing to EEPROM
    }
  }
}
