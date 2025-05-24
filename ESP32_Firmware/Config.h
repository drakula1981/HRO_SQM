// Config.h 
// User specific configuration for SQM
// 
// Copyright (c) 2019 Roman Hujer   http://hujer.net
//
#ifndef CONFIG_H
#define CONFIG_H

#define SERIAL_BAUD 115200    //Serial port baud Default is 115200

// Select only one your display
#define SH1106_ON  // SH1106  1.3"  128x64 OLED display is default
#define SSD1306_OFF // SSD1306 0.96" 128x64 OLED display 

#define EXTENDET_INFO_ON  // Two extended Startup info screen
 
#define EXTENDET_PROTOCOL_OFF  // My Extender protocol for weather info (Disable when is project compilation Big)

#define SQM_CAL_OFFSET  -1.0  // default SQM Calibration offset but priority is in EEPROM stored value
#define TEMP_CAL_OFFSET 0.0   // default Temperature Calibration offset but priority is in EEPROM stored value

#define BME_I2C_ADDRESS 0x77  //Default I2C for BME280 sensor 

#define CONFIG_MBEDTLS_LEGACY_API_SUPPORT

#define AP_DEFAULT_SSID "HRO_SQM_49290"
#define AP_DEFAULT_PASS "please_change_me_!"

#define JWT_SECRET "m498mQYeGfQFbetX6BfirQA6hqFo8Hbmk"

#define WIFI_DEFAULT_SSID "drakulaNetworkFbx"
#define WIFI_DEFAULT_PASS "@699510CD6D04#EC#955E0BD7EA6D@"

//#define WIFI_DEFAULT_SSID "TP-Link_0ADB"
//#define WIFI_DEFAULT_PASS "30745055"
#endif
