/**************************************************************************/
/*!
    @file     SQM_TSL2591.h
    @author   gshau

    Forked from original Adafruit TSL2591 libraries
    @author   KT0WN (adafruit.com)
		@author   wbphelps (wm@usa.net)

    This is a library for the Adafruit TSL2591 breakout board
    This library works with the Adafruit TSL2591 breakout
    ----> https://www.adafruit.com/products/1980

    Check out the links above for our tutorials and wiring diagrams
    These chips use I2C to communicate

    Adafruit invests time and resources providing this open source code,
    please support Adafruit and open-source hardware by purchasing
    products from Adafruit!

    @section LICENSE

    Software License Agreement (BSD License)

    Copyright (c) 2014 Adafruit Industries
    All rights reserved.

    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:
    1. Redistributions of source code must retain the above copyright
    notice, this list of conditions and the following disclaimer.
    2. Redistributions in binary form must reproduce the above copyright
    notice, this list of conditions and the following disclaimer in the
    documentation and/or other materials provided with the distribution.
    3. Neither the name of the copyright holders nor the
    names of its contributors may be used to endorse or promote products
    derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS ''AS IS'' AND ANY
    EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
    WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
    DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER BE LIABLE FOR ANY
    DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
    (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
    LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
    ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
    (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
/**************************************************************************/

#ifndef _TSL2591_H_
#define _TSL2591_H_

#if ARDUINO >= 100
 #include <Arduino.h>
#else
 #include <WProgram.h>
#endif
#include <Adafruit_Sensor.h>
#include <Wire.h>

#define TSL2591_VISIBLE           (2)       // channel 0 - channel 1
#define TSL2591_INFRARED          (1)       // channel 1
#define TSL2591_FULLSPECTRUM      (0)       // channel 0

#define TSL2591_ADDR              (0x29)
#define TSL2591_READBIT           (0x01)

#define TSL2591_COMMAND_BIT       (0xA0)    // bits 7 and 5 for 'command normal'
#define TSL2591_CLEAR_BIT         (0x40)    // Clears any pending interrupt (write 1 to clear)
#define TSL2591_WORD_BIT          (0x20)    // 1 = read/write word (rather than byte)
#define TSL2591_BLOCK_BIT         (0x10)    // 1 = using block read/write

#define TSL2591_ENABLE_POWERON    (0x01)
#define TSL2591_ENABLE_POWEROFF   (0x00)
#define TSL2591_ENABLE_AEN        (0x02)
#define TSL2591_ENABLE_AIEN       (0x10)

#define TSL2591_CONTROL_RESET     (0x80)

//#define TSL2591_LUX_DF            (408.0F)

#define TSL2591_LUX_COEFB         (1.64F)  // CH0 coefficient
#define TSL2591_LUX_COEFC         (0.59F)  // CH1 coefficient A
#define TSL2591_LUX_COEFD         (0.86F)  // CH2 coefficient B

enum
{
  TSL2591_REGISTER_ENABLE           = 0x00,
  TSL2591_REGISTER_CONTROL          = 0x01,
  TSL2591_REGISTER_THRESHHOLDL_LOW  = 0x02,
  TSL2591_REGISTER_THRESHHOLDL_HIGH = 0x03,
  TSL2591_REGISTER_THRESHHOLDH_LOW  = 0x04,
  TSL2591_REGISTER_THRESHHOLDH_HIGH = 0x05,
  TSL2591_REGISTER_INTERRUPT        = 0x06,
  TSL2591_REGISTER_CRC              = 0x08,
  TSL2591_REGISTER_ID               = 0x0A,
  TSL2591_REGISTER_CHAN0_LOW        = 0x14,
  TSL2591_REGISTER_CHAN0_HIGH       = 0x15,
  TSL2591_REGISTER_CHAN1_LOW        = 0x16,
  TSL2591_REGISTER_CHAN1_HIGH       = 0x17
};

typedef enum
{
  TSL2591_INTEGRATIONTIME_100MS     = 0x00,
  TSL2591_INTEGRATIONTIME_200MS     = 0x01,
  TSL2591_INTEGRATIONTIME_300MS     = 0x02,
  TSL2591_INTEGRATIONTIME_400MS     = 0x03,
  TSL2591_INTEGRATIONTIME_500MS     = 0x04,
  TSL2591_INTEGRATIONTIME_600MS     = 0x05
}
tsl2591IntegrationTime_t;

typedef enum
{
  TSL2591_GAIN_LOW                  = 0x00,    // low gain (1x)
  TSL2591_GAIN_MED                  = 0x10,    // medium gain (25x)
  TSL2591_GAIN_HIGH                 = 0x20,    // medium gain (428x)
  TSL2591_GAIN_MAX                  = 0x30    // max gain (9876x)
}
tsl2591Gain_t;


typedef struct  {
  tsl2591Gain_t gain;
  tsl2591IntegrationTime_t time;
} sensorConfig;

typedef struct {
    float fullLuminositySlope     = 0.000705244123;
    float fullLuminosityIntercept = 0.9794303797;
    float irSlope                 = -0.001939421338;
    float irIntercept             = 1.05;
} temperatureCalibration;


class SQM_TSL2591 : public Adafruit_Sensor
{
 public:
  SQM_TSL2591(int32_t sensorID = -1);

  boolean   begin   ( void );
  void      enable  ( void );
  void      disable ( void );
  void      write8  ( uint8_t r, uint8_t v );
  uint16_t  read16  ( uint8_t reg );
  uint8_t   read8   ( uint8_t reg );

  void      setDF                     ( float df);
  float     getDF                     ( );
  float     calculateLux              ( uint16_t ch0, uint16_t ch1 );
  float     calculateLux2             ( uint16_t ch0, uint16_t ch1 );
  void      setGain                   ( tsl2591Gain_t gain );
  void      setTiming                 ( tsl2591IntegrationTime_t integration );
  void      setCalibrationOffset      ( float calibrationOffset);
  uint32_t  getFullLuminosity         ( );
  void      setTemperatureCalibration ( const temperatureCalibration &calibrationData);
  void      setTemperature            ( float temperature);
  void      resetTemperature          ( );

  tsl2591IntegrationTime_t getTiming();
  tsl2591Gain_t            getGain();

  void showConfig(void);
  uint16_t ir, full, vis;
  int niter;
  void takeReading(void);
  void configSensor(void);
  sensorConfig config;
  float integrationValue, gainValue;
  double mpsas, dmpsas;
  float lux; 
  bool verbose;

  void bumpGain(int bumpDirection);
  void bumpTime(int bumpDirection);

  /* Unified Sensor API Functions */
    bool getEvent  ( sensors_event_t* );
    void getSensor ( sensor_t* );

 private:
  tsl2591IntegrationTime_t _integration;
  tsl2591Gain_t _gain;
  int32_t _sensorID;
  float _calibrationOffset;
  temperatureCalibration _temperatureCalibration;
  float  TSL2591_LUX_DF;
  float _temperature;
  bool _hasTemperature = false;
  void calibrateReadingsForTemperature(uint16_t &ir, uint16_t &full);

  boolean _initialized;
};
#endif
