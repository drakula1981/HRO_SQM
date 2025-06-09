#include "BME280Sensor.h"
#include "Config.h"

BME280Sensor::BME280Sensor() : bme(), status(Disconnected) {}

void BME280Sensor::begin() {
    if (!bme.begin(BME_I2C_ADDRESS)) { // Adresse I2C par défaut pour la plupart des BME280
        Serial.println("Erreur de connexion au BME280 !");
        status = Error; // Statut mis à jour en cas d'erreur
    } else {
        Serial.println("BME280 initialisé avec succès !");
        status = Connected; // Statut mis à jour en cas d'erreur
    }

    // Configuration NTP
    /*configTime(0, 0, "pool.ntp.org", "time.nist.gov");
    Serial.println("Connexion au serveur NTP...");
    delay(2000); // Attente pour la synchronisation NTP*/
}

float BME280Sensor::getTemperature(float cloudSensorTemp, float tempOffset) {
    float temp = -420.0;
    float somme = 0;
    float tempCorrectionCoef = 1.0;

    if (status == Connected) {
        for (uint8_t i = 0; i < nbMesures; i++) {
            somme += bme.readTemperature();
            delay(100);
        }
        temp = somme / nbMesures;
        //Serial.println("temp mesurée : " + String(temp));
        //Serial.println("cloudSensorTemp : " + String(cloudSensorTemp));
        //Serial.println("Ratio cloudSensorTemp*100/temp : " + String(cloudSensorTemp*100/temp));
        if(cloudSensorTemp*100/temp> 30) {
            //Serial.print("> 30, application du coef : ");
            tempCorrectionCoef = temp/cloudSensorTemp;
            //Serial.println(String(tempCorrectionCoef));
        }
        //Serial.println("temp retenue : " + String(round((temp/tempCorrectionCoef)*100)/100.0)+tempOffset);
    }
    return temp != -420.0 ? (round((temp/tempCorrectionCoef)*100)/100.0)+tempOffset : temp;
}

float BME280Sensor::getPressure() {
    float pres = -42.0;
    float somme = 0;
    if (status == Connected) {
        for (uint8_t i = 0; i < nbMesures; i++) {
            somme += bme.readPressure();
            delay(100);
        }
        pres = somme / nbMesures;
    }
    return pres != -42.0 ? (pres*PressCoef)/100.0F : pres;
    //return (status == Connected) ? (bme.readPressure()*PressCoef) / 100.0F : -42.0; // Converti en hPa
}

float BME280Sensor::getHumidity() {
    float hum = -42.0;
    float somme = 0;
    if (status == Connected) {
        for (uint8_t i = 0; i < nbMesures; i++) {
            somme += bme.readHumidity();
            delay(100);
        }
        hum = somme / nbMesures;
    }
    return hum != -42.0 ? hum*HumCoef : hum;
    //return (status == Connected) ? bme.readHumidity()*HumCoef : -42.0;
}

float BME280Sensor::getAltitude(float seaLevelPressure) {
    return (status == Connected) ? bme.readAltitude(seaLevelPressure) : -42.0;
}

String BME280Sensor::getTimestamp() {
    struct tm timeinfo;
    if (!getLocalTime(&timeinfo)) {
        Serial.println("Impossible d'obtenir l'heure NTP");
        return "Non synchronisé";
    }
    char timestamp[50];
    strftime(timestamp, 50, "%Y-%m-%d %H:%M:%S", &timeinfo);
    return String(timestamp);
}

String BME280Sensor::toJSON(float cloudSensorTemp, float tempOffset) {
    // Appelle la méthode getTimestamp() pour récupérer l'horodatage
    String timestamp = getTimestamp();
    
     // Génération du JSON
    StaticJsonDocument<200> doc;
    doc["timestamp"] = timestamp;
    doc["temperature"] = getTemperature(cloudSensorTemp, tempOffset);
    doc["pressure"] = ceil(getPressure());
    doc["humidity"] = ceil(getHumidity());
    doc["altitude"] = round(getAltitude()*100)/100.0;
    String jsonString;
    serializeJson(doc, jsonString);
    return jsonString;
}

SensorStatus BME280Sensor::getStatus() {
    return status; // Retourne le statut actuel du capteur
}
