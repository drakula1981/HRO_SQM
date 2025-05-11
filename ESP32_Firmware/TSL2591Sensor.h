#ifndef TSL2591Sensor_H
#define TSL2591Sensor_H

#include <ArduinoJson.h>
#include "SQM_TSL2591.h"
#include <time.h> // Pour la gestion NTP
#include "SensorStatus.h"

class TSL2591Sensor {
private:
    SQM_TSL2591 sensor;
    SensorStatus status;

public:
    TSL2591Sensor(); // Constructeur avec un ID optionnel

    void begin(); // Initialisation du capteur
    float getFullLuminosity(); // Luminosité totale
    float getInfraredLuminosity(); // Luminosité infrarouge
    float getVisibleLuminosity(); // Luminosité visible
    float getMPSAS(); // Magnitude par seconde d'arc au carré
    float getDMPSAS(); // Delta magnitude
    uint16_t getIntegrationValue(); // Temps d'intégration
    uint8_t getGainValue(); // Valeur du gain
    uint16_t getNIter(); // Nombre d'itérations
    float getLux(); // Lux (luminosité mesurée)
    void configure(sensorConfig config);
    String toJSON(); // Sérialisation JSON avec timestamp
    String getTimestamp(); // Récupération de l'horodatage
    void setCalibrationTemperature(float temperature);
    SensorStatus getStatus(); // Obtenir le statut
};

#endif
