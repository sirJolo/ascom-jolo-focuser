/* Arduino SoftI2C library. 
 *
 * This is a very fast and very light-weight software I2C-master library 
 * written in assembler. It is based on Peter Fleury's I2C software
 * library: http://homepage.hispeed.ch/peterfleury/avr-software.html
 *
 *
 * This Library is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This Library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with the Arduino I2cMaster Library.  If not, see
 * <http://www.gnu.org/licenses/>.
 */

/* In order to use the library, you need to define SDA_PIN, SCL_PIN,
 * SDA_PORT and SCL_PORT before including this file.  Have a look at
 * http://www.arduino.cc/en/Reference/PortManipulation for finding out
 * which values to use. For example, if you use digital pin 3 for
 * SDA and digital pin 13 for SCL you have to use the following
 * definitions: 
 * #define SDA_PIN 3 
 * #define SDA_PORT PORTB 
 * #define SCL_PIN 5
 * #define SCL_PORT PORTB
 *
 * You can also define the following constants (see also below):
 * - I2C_CPUFREQ, when changing CPU clock frequency dynamically
 * - I2C_FASTMODE = 1 meaning that the I2C bus allows speeds up to 400 kHz
 * - I2C_SLOWMODE = 1 meaning that the I2C bus will allow only up to 25 kHz 
 * - I2C_NOINTERRUPT = 1 in order to prohibit interrupts while 
 *   communicating (see below). This can be useful if you use the library 
 *   for communicationg with SMbus devices, which have timeouts.
 *   Note, however, that interrupts are disabledfrom issuing a start condition
 *   until issuing a stop condition. So use this option with care!
 * - I2C_TIMEOUT = 0..10000 mssec in order to return from the I2C functions
 *   in case of a I2C bus lockup (i.e., SCL constantly low). 0 means no timeout
 */

/* Changelog:
 * Version 1.1: 
 * - removed I2C_CLOCK_STRETCHING
 * - added I2C_TIMEOUT time in msec (0..10000) until timeout or 0 if no timeout
 * - changed i2c_init to return true iff both SDA and SCL are high
 * - changed interrupt disabling so that the previous IRQ state is retored
 * Version 1.0: basic functionality
 */
#ifndef _SOFTI2C_H
#define _SOFTI2C_H

#define SDA_PORT PORTD
#define SDA_PIN 3
#define SCL_PORT PORTD
#define SCL_PIN 5
#define I2C_TIMEOUT 100
#define I2C_NOINTERRUPT 0
#define I2C_SLOWMODE 0
#define I2C_FASTMODE 0
#define FAC 1
#define I2C_CPUFREQ (F_CPU/FAC)
 
#include <avr/io.h>
#include <Arduino.h>

// Init function. Needs to be called once in the beginning.
// Returns false if SDA or SCL are low, which probably means 
// a I2C bus lockup or that the lines are not pulled up.
boolean __attribute__ ((noinline)) i2c_init(void);

// Start transfer function: <addr> is the 8-bit I2C address (including the R/W
// bit). 
// Return: true if the slave replies with an "acknowledge", false otherwise
bool __attribute__ ((noinline)) i2c_start(uint8_t addr); 

// Similar to start function, but wait for an ACK! Be careful, this can 
// result in an infinite loop!
void  __attribute__ ((noinline)) i2c_start_wait(uint8_t addr);

// Repeated start function: After having claimed the bus with a start condition,
// you can address another or the same chip again without an intervening 
// stop condition.
// Return: true if the slave replies with an "acknowledge", false otherwise
bool __attribute__ ((noinline)) i2c_rep_start(uint8_t addr);

// Issue a stop condition, freeing the bus.
void __attribute__ ((noinline)) i2c_stop(void) asm("ass_i2c_stop");

// Write one byte to the slave chip that had been addressed
// by the previous start call. <value> is the byte to be sent.
// Return: true if the slave replies with an "acknowledge", false otherwise
bool __attribute__ ((noinline)) i2c_write(uint8_t value) asm("ass_i2c_write");

// Read one byte. If <last> is true, we send a NAK after having received 
// the byte in order to terminate the read sequence. 
uint8_t __attribute__ ((noinline)) i2c_read(bool last);

// You can set I2C_CPUFREQ independently of F_CPU if you 
// change the CPU frequency on the fly. If do not define it,
// it will use the value of F_CPU
#ifndef I2C_CPUFREQ
#define I2C_CPUFREQ F_CPU
#endif

// If I2C_FASTMODE is set to 1, then the highest possible frequency below 400kHz
// is selected. Be aware that not all slave chips may be able to deal with that!
#ifndef I2C_FASTMODE
#define I2C_FASTMODE 0
#endif

// If I2C_FASTMODE is not defined or defined to be 0, then you can set
// I2C_SLOWMODE to 1. In this case, the I2C frequency will not be higher 
// than 25KHz. This could be useful for problematic buses.
#ifndef I2C_SLOWMODE
#define I2C_SLOWMODE 0
#endif

// if I2C_NOINTERRUPT is 1, then the I2C routines are not interruptable.
// This is most probably only necessary if you are using a 1MHz system clock,
// you are communicating with a SMBus device, and you want to avoid timeouts.
// Be aware that the interrupt bit is enabled after each call. So the
// I2C functions should not be called in interrupt routines or critical regions.
#ifndef I2C_NOINTERRUPT
#define I2C_NOINTERRUPT 0
#endif

// I2C_TIMEOUT can be set to a value between 1 and 10000.
// If it is defined and nonzero, it leads to a timeout if the
// SCL is low longer than I2C_TIMEOUT milliseconds, i.e., max timeout is 10 sec
#ifndef I2C_TIMEOUT
#define I2C_TIMEOUT 0
#else 
#if I2C_TIMEOUT > 10000
#error I2C_TIMEOUT is too large
#endif
#endif

#define I2C_TIMEOUT_DELAY_LOOPS (I2C_CPUFREQ/1000UL)*I2C_TIMEOUT/4000UL
#if I2C_TIMEOUT_DELAY_LOOPS < 1
#define I2C_MAX_STRETCH 1
#else
#if I2C_TIMEOUT_DELAY_LOOPS > 60000UL
#define I2C_MAX_STRETCH 60000UL
#else
#define I2C_MAX_STRETCH I2C_TIMEOUT_DELAY_LOOPS
#endif
#endif

#if I2C_FASTMODE
#define I2C_DELAY_COUNTER (((I2C_CPUFREQ/400000L)/2-19)/3)
#else
#if I2C_SLOWMODE
#define I2C_DELAY_COUNTER (((I2C_CPUFREQ/25000L)/2-19)/3)
#else
#define I2C_DELAY_COUNTER (((I2C_CPUFREQ/100000L)/2-19)/3)
#endif
#endif

// Table of I2C bus speed in kbit/sec:
// CPU clock:           1MHz   2MHz    4MHz   8MHz   16MHz   20MHz
// Fast I2C mode          40     80     150    300     400     400
// Standard I2C mode      40     80     100    100     100     100
// Slow I2C mode          25     25      25     25      25      25     

// constants for reading & writing
#define I2C_READ    1
#define I2C_WRITE   0

// map the IO register back into the IO address space
#define SDA_DDR       	(_SFR_IO_ADDR(SDA_PORT) - 1)
#define SCL_DDR       	(_SFR_IO_ADDR(SCL_PORT) - 1)
#define SDA_OUT       	_SFR_IO_ADDR(SDA_PORT)
#define SCL_OUT       	_SFR_IO_ADDR(SCL_PORT)
#define SDA_IN		(_SFR_IO_ADDR(SDA_PORT) - 2)
#define SCL_IN		(_SFR_IO_ADDR(SCL_PORT) - 2)

#ifndef __tmp_reg__
#define __tmp_reg__ 0
#endif

#endif



