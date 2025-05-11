#include "TSL2591Sensor.h"

TSL2591Sensor::TSL2591Sensor()  {
    sensor = SQM_TSL2591(2691);
    status = SensorStatus(Disconnected);
}

void TSL2591Sensor::begin() {
    Serial.println("Tentative de connexion au capteur TSL2591.");
    if (!sensor.begin()) {
        Serial.println("Erreur de connexion au capteur TSL2591 !");
        status = Error; // Statut mis à jour en cas d'erreur
    } else {
        Serial.println("Capteur TSL2591 initialisé avec succès !");
        status = Connected; // Statut mis à jour en cas d'erreur
    }

    /*// Configuration NTP
    configTime(0, 0, "pool.ntp.org", "time.nist.gov");
    Serial.println("Connexion au serveur NTP...");
    delay(2000); // Attente pour la synchronisation initiale*/
}

void TSL2591Sensor::configure(sensorConfig config){
    sensor.config = config;
}

float TSL2591Sensor::getFullLuminosity() {
    uint32_t lum = sensor.getFullLuminosity();
    return static_cast<float>(lum); // Conversion si nécessaire
}

float TSL2591Sensor::getInfraredLuminosity() {
    return static_cast<float>(sensor.ir); // Luminosité infrarouge
}

float TSL2591Sensor::getVisibleLuminosity() {
    return static_cast<float>(sensor.vis); // Luminosité visible
}

float TSL2591Sensor::getMPSAS() {
    return sensor.mpsas; // Magnitude par seconde d'arc au carré
}

float TSL2591Sensor::getDMPSAS() {
    return sensor.dmpsas; // Delta magnitude
}

uint16_t TSL2591Sensor::getIntegrationValue() {
    return sensor.integrationValue; // Temps d'intégration en ms
}

uint8_t TSL2591Sensor::getGainValue() {
    return sensor.gainValue; // Valeur du gain
}

uint16_t TSL2591Sensor::getNIter() {
    return sensor.niter; // Nombre d'itérations
}

float TSL2591Sensor::getLux() {
    return sensor.lux; // Mesure en lux
}

String TSL2591Sensor::getTimestamp() {
    struct tm timeinfo;
    if (!getLocalTime(&timeinfo)) {
        Serial.println("Impossible d'obtenir l'heure NTP");
        return "Non synchronisé";
    }
    char timestamp[50];
    strftime(timestamp, 50, "%Y-%m-%d %H:%M:%S", &timeinfo);
    return String(timestamp);
}

String TSL2591Sensor::toJSON() {
    String timestamp = getTimestamp();
    String jsonString;

    if(status != Connected) {
        StaticJsonDocument<100> doc;

        doc["timestamp"] = timestamp;
        doc["error"] = "Unable to get sensor datas";
        serializeJson(doc, jsonString);
    } else {
        sensor.takeReading();

        // Génération du JSON
        StaticJsonDocument<500> doc;
        doc["timestamp"] = timestamp;
        doc["fullLuminosity"] = getFullLuminosity();
        doc["infraredLuminosity"] = getInfraredLuminosity();
        doc["visibleLuminosity"] = getVisibleLuminosity();
        doc["mpsas"] = getMPSAS(); // Magnitude
        doc["dmpsas"] = getDMPSAS(); // Delta magnitude
        doc["integrationValue"] = getIntegrationValue(); // Temps d'intégration
        doc["gainValue"] = getGainValue(); // Valeur de gain
        doc["niter"] = getNIter(); // Nombre d'itérations
        doc["lux"] = getLux(); // Mesure en lux

        serializeJson(doc, jsonString);
    }
    return jsonString;
}

void TSL2591Sensor::setCalibrationTemperature(float temperature) {
    sensor.setTemperature(temperature);
}

SensorStatus TSL2591Sensor::getStatus() {
    return status; // Retourne le statut actuel du capteur
}