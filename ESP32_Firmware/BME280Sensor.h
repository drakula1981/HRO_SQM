#ifndef BME280Sensor_H
#define BME280Sensor_H

#include <Adafruit_BME280.h>
#include <ArduinoJson.h>
#include <time.h> // Bibliothèque pour NTP
#include "SensorStatus.h"

class BME280Sensor {
private:
    Adafruit_BME280 bme;
    SensorStatus status;
    const uint8_t nbMesures = 10;

    const float HumCoef = 2.025;//10.409090909;
    const float PressCoef = 1.016080402;

public:
    BME280Sensor(); // Constructeur

    void begin(); // Méthode pour initialiser le capteur
    float getTemperature(float cloudSensorTemp, float tempOffset); // Méthode pour obtenir la température
    float getPressure(); // Méthode pour obtenir la pression
    float getHumidity(); // Méthode pour obtenir l'humidité
    float getAltitude(float seaLevelPressure = 1013.25); // Altitude optionnelle
    String toJSON(float cloudSensorTemp, float tempOffset); // Sérialisation JSON automatique avec timestamp
    String getTimestamp(); // Récupération du timestamp
    SensorStatus getStatus(); // Obtenir le statut
};

#endif
