#include "LC709203FSensor.h"
#include "Config.h"

LC709203FSensor::LC709203FSensor() : maxlipo(), status(Disconnected) {}

void LC709203FSensor::begin() {
    if (!maxlipo.begin()) {
        Serial.println(F("Couldnt find Adafruit LC709203F?\nMake sure a battery is plugged in!"));
        status = Error; // Statut mis à jour en cas d'erreur
    } else {
        Serial.println("LC709203F initialisé avec succès !");
        status = Connected; // Statut mis à jour en cas d'erreur
    }

    /*// Configuration NTP
    configTime(0, 0, "pool.ntp.org", "time.nist.gov");
    Serial.println("Connexion au serveur NTP...");
    delay(2000); // Attente pour la synchronisation NTP*/
}

String LC709203FSensor::getChipID() {
    return (status == Connected) ? String(maxlipo.getICversion()) : "";
}

float LC709203FSensor::getBattVoltage() {
    float cellVoltage = maxlipo.cellVoltage();
    return (status == Connected && !isnan(cellVoltage)) ? cellVoltage : -42.0; // Converti en hPa
}

float LC709203FSensor::getBattPercent() {
    float cellPercent = maxlipo.cellPercent();
    return (status == Connected && !isnan(cellPercent)) ? cellPercent : -42.0;
}

void  LC709203FSensor::setAlarmVoltage(float alarm) {
    maxlipo.setAlarmVoltage(alarm);
}

String LC709203FSensor::getTimestamp() {
    struct tm timeinfo;
    if (!getLocalTime(&timeinfo)) {
        Serial.println("Impossible d'obtenir l'heure NTP");
        return "Non synchronisé";
    }
    char timestamp[50];
    strftime(timestamp, 50, "%Y-%m-%d %H:%M:%S", &timeinfo);
    return String(timestamp);
}

String LC709203FSensor::toJSON() {
    // Appelle la méthode getTimestamp() pour récupérer l'horodatage
    String timestamp = getTimestamp();

    // Génération du JSON
    StaticJsonDocument<400> doc;
    doc["timestamp"] = timestamp;
    doc["chipId"] = getChipID();
    doc["voltage"] = getBattVoltage();
    doc["percent"] = getBattPercent();
    doc["(dis)chargeRate"] = "";
    doc["alerts"] = "";
    String jsonString;
    serializeJson(doc, jsonString);
    return jsonString;
}

SensorStatus LC709203FSensor::getStatus() {
    return status; // Retourne le statut actuel du capteur
}
