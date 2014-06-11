//
// Eeprom utilites library
//
// From http://playground.arduino.cc/Code/EepromUtil
//
#include <Arduino.h>
#include <EEPROM.h>

class EepromUtil {
  public:
    static void    eeprom_erase_all();
    static boolean eeprom_read_bytes(int startAddr, byte array[], int numBytes);
    static boolean eeprom_write_int(int addr, int value);
    static boolean eeprom_read_int(int addr, int* value);
    static boolean eeprom_write_string(int addr, char* string);
    static boolean eeprom_read_string(int addr, char* buffer, int bufSize);
    static boolean eeprom_write_bytes(int startAddr, const byte* array,
                                      int numBytes);

  private:
    static boolean eeprom_is_addr_ok(int addr);
};
