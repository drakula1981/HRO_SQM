#include "EEPROMSensor.h"

void EEPROM_writeQuad(byte i,byte *v) {
  EEPROM.write(i+0,*v); v++;
  EEPROM.write(i+1,*v); v++;
  EEPROM.write(i+2,*v); v++;
  EEPROM.write(i+3,*v);
}

// read 4 byte variable from EEPROM at position i (4 bytes)
void EEPROM_readQuad(int i,byte *v) {
  *v=EEPROM.read(i+0); v++;
  *v=EEPROM.read(i+1); v++;
  *v=EEPROM.read(i+2); v++;
  *v=EEPROM.read(i+3);  
}

// write 4 byte float into EEPROM at position i (4 bytes)
void EEPROM_writeFloat(byte i,float f) {
  EEPROM_writeQuad(i,(byte*)&f);
}

// read 4 byte float from EEPROM at position i (4 bytes)
float EEPROM_readFloat(byte i) {
  float f;
  EEPROM_readQuad(i,(byte*)&f);
  return f;
}

void EEPROMSensor::begin() {
    EEPROM.begin(512); // Initialise l'EEPROM avec une taille spécifique
}

// Lire l'offset de calibration SQM
float EEPROMSensor::getSQMCalOffset() {
    if (EEPROM.read(EEPROM_SQM_CAL_INDEX_C) == 'x') {
        return EEPROM_readFloat(EEPROM_SQM_CAL_INDEX_F);
    }else {
        setSQMCalOffset(sqmCalOffsetDefault);
    }
    return sqmCalOffsetDefault; // Valeur par défaut si non définie
}

// Lire l'offset de calibration de température
float EEPROMSensor::getTempCalOffset() {
    if (EEPROM.read(EEPROM_TEMP_CAL_INDEX_C) == 'T') {
        return EEPROM_readFloat(EEPROM_TEMP_CAL_INDEX_F);
    } else {
        setTempCalOffset(tempCalOffsetDefault);
    }
    return tempCalOffsetDefault; // Valeur par défaut si non définie
}

// Lire la calibration automatique
boolean EEPROMSensor::getAutoTempCal() {
    return EEPROM.read(EEPROM_AUTO_TEMP_INDEX_C) != 'N';
}

// Lire le DF calibration
float EEPROMSensor::getDFCal() {
    return EEPROM_readFloat(EEPROM_DF);
}

// Écrire l'offset de calibration SQM
void EEPROMSensor::setSQMCalOffset(float offset) {
    if (offset > 25 || offset < -25) return; // Vérification de la plage
    EEPROM.write(EEPROM_SQM_CAL_INDEX_C, 'x');
    EEPROM_writeFloat(EEPROM_SQM_CAL_INDEX_F, offset);
    EEPROM.commit(); // Sauvegarder les changements
}

// Écrire l'offset de calibration de température
void EEPROMSensor::setTempCalOffset(float offset) {
    if (offset > 50 || offset < -50) return; // Vérification de la plage
    EEPROM.write(EEPROM_TEMP_CAL_INDEX_C, 'T');
    EEPROM_writeFloat(EEPROM_TEMP_CAL_INDEX_F, offset);
    EEPROM.commit(); // Sauvegarder les changements
}

// Écrire la calibration automatique
void EEPROMSensor::setAutoTempCal(boolean autoCal) {
    EEPROM.write(EEPROM_AUTO_TEMP_INDEX_C, autoCal ? 'Y' : 'N');
    EEPROM.commit(); // Sauvegarder les changements
}

// Écrire le DF calibration
void EEPROMSensor::setDFCal(float dfCal) {
    EEPROM_writeFloat(EEPROM_DF, dfCal);
    EEPROM.commit(); // Sauvegarder les changements
}

// Sérialiser les données en JSON
String EEPROMSensor::toJSON() {
    StaticJsonDocument<300> doc;
    doc["sqmCalOffset"] = getSQMCalOffset();
    doc["tempCalOffset"] = getTempCalOffset();
    doc["autoTempCal"] = getAutoTempCal();
    doc["dfCal"] = getDFCal();
    String jsonString;
    serializeJson(doc, jsonString);
    return jsonString;
}
