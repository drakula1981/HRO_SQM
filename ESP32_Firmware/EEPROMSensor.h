#ifndef EEPROMSensor_H
#define EEPROMSensor_H

#define EEPROM_SQM_CAL_INDEX_C       1
#define EEPROM_SQM_CAL_INDEX_F       3
#define EEPROM_TEMP_CAL_INDEX_C      7
#define EEPROM_TEMP_CAL_INDEX_F      8 
#define EEPROM_AUTO_TEMP_INDEX_C     14

#define EEPROM_DF                    23 

#include <EEPROM.h>
#include <ArduinoJson.h>

class EEPROMSensor {
private:
    const float tempCalOffsetDefault = 0.0;
    const float sqmCalOffsetDefault = 0.0;
public:
    // Initialiser l'EEPROM
    void begin();

    // Méthodes pour lire les données de l'EEPROM
    float getSQMCalOffset();
    float getTempCalOffset();
    boolean getAutoTempCal();
    float getDFCal();

    // Méthodes pour écrire des données dans l'EEPROM
    void setSQMCalOffset(float offset);
    void setTempCalOffset(float offset);
    void setAutoTempCal(boolean autoCal);
    void setDFCal(float dfCal);

    // Sérialiser toutes les données en JSON
    String toJSON();
};

#endif
