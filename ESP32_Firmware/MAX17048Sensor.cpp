#include "MAX17048Sensor.h"
#include "Config.h"

MAX17048Sensor::MAX17048Sensor() : maxlipo(), status(Disconnected) {}

void MAX17048Sensor::begin() {
    if (!maxlipo.begin()) {
        Serial.println(F("Couldnt find Adafruit MAX17048?\nMake sure a battery is plugged in!"));
        status = Error; // Statut mis à jour en cas d'erreur
    } else {
        Serial.println("MAX17048 initialisé avec succès !");
        status = Connected; // Statut mis à jour en cas d'erreur
    }

    /*// Configuration NTP
    configTime(0, 0, "pool.ntp.org", "time.nist.gov");
    Serial.println("Connexion au serveur NTP...");
    delay(2000); // Attente pour la synchronisation NTP*/
}

String MAX17048Sensor::getChipID() {
    return (status == Connected) ? String(maxlipo.getChipID()) : "";
}

float MAX17048Sensor::getBattVoltage() {
    float cellVoltage = maxlipo.cellVoltage();
    return (status == Connected && !isnan(cellVoltage)) ? cellVoltage : -42.0; // Converti en hPa
}

float MAX17048Sensor::getBattPercent() {
    float cellPercent = maxlipo.cellPercent();
    return (status == Connected && !isnan(cellPercent)) ? cellPercent : -42.0;
}

float MAX17048Sensor::getBattChargeRate() {
    float chargeRate = maxlipo.chargeRate();
    return (status == Connected && !isnan(chargeRate)) ? chargeRate : -42.0;
}

String MAX17048Sensor::getBattAlerts() {
    String alerts = "{";
    if (maxlipo.isActiveAlert()) {
        uint8_t status_flags = maxlipo.getAlertStatus();
      
        if (status_flags & MAX1704X_ALERTFLAG_SOC_CHANGE) {
            alerts += "\"SOC_Change\":1,";
            maxlipo.clearAlertFlag(MAX1704X_ALERTFLAG_SOC_CHANGE); // clear the alert
        } else {
            alerts += "\"SOC_Change\":0,";
        }
        if (status_flags & MAX1704X_ALERTFLAG_SOC_LOW) {
            alerts += "\"SOC_Low\":1,";
            maxlipo.clearAlertFlag(MAX1704X_ALERTFLAG_SOC_LOW); // clear the alert
        } else {
            alerts += "\"SOC_Low\":0,";
        }
        if (status_flags & MAX1704X_ALERTFLAG_VOLTAGE_RESET) {
            alerts += "\"Voltage_reset\":1,";
            maxlipo.clearAlertFlag(MAX1704X_ALERTFLAG_VOLTAGE_RESET); // clear the alert
        } else {
            alerts += "\"Voltage_reset\":0,";
        }
        if (status_flags & MAX1704X_ALERTFLAG_VOLTAGE_LOW) {
            alerts += "\"Voltage_low\":1,";
            maxlipo.clearAlertFlag(MAX1704X_ALERTFLAG_VOLTAGE_LOW); // clear the alert
        } else {
            alerts += "\"Voltage_low\":0,";
        }
        if (status_flags & MAX1704X_ALERTFLAG_VOLTAGE_HIGH) {
            alerts += "\"Voltage_high\":1,";
            maxlipo.clearAlertFlag(MAX1704X_ALERTFLAG_VOLTAGE_HIGH); // clear the alert
        } else {
            alerts += "\"Voltage_high\":0,";
        }
        if (status_flags & MAX1704X_ALERTFLAG_RESET_INDICATOR) {
            alerts += "\"Reset_Indicator\":1,";
            maxlipo.clearAlertFlag(MAX1704X_ALERTFLAG_RESET_INDICATOR); // clear the alert
        } else {
            alerts += "\"Reset_Indicator\":0";
        }
    }
    alerts += "}";
    return alerts;
}

String MAX17048Sensor::getTimestamp() {
    struct tm timeinfo;
    if (!getLocalTime(&timeinfo)) {
        Serial.println("Impossible d'obtenir l'heure NTP");
        return "Non synchronisé";
    }
    char timestamp[50];
    strftime(timestamp, 50, "%Y-%m-%d %H:%M:%S", &timeinfo);
    return String(timestamp);
}

String MAX17048Sensor::toJSON() {
    // Appelle la méthode getTimestamp() pour récupérer l'horodatage
    String timestamp = getTimestamp();

    // Génération du JSON
    StaticJsonDocument<400> doc;
    doc["timestamp"] = timestamp;
    doc["chipId"] = getChipID();
    doc["voltage"] = getBattVoltage();
    doc["percent"] = getBattPercent();
    doc["(dis)chargeRate"] = getBattChargeRate();
    doc["alerts"] = getBattAlerts();
    String jsonString;
    serializeJson(doc, jsonString);
    return jsonString;
}

SensorStatus MAX17048Sensor::getStatus() {
    return status; // Retourne le statut actuel du capteur
}
