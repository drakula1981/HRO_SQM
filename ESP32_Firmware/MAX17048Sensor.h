#ifndef MAX17048Sensor_H
#define MAX17048Sensor_H

#include <Adafruit_MAX1704X.h>
#include <ArduinoJson.h>
#include <time.h> // Bibliothèque pour NTP
#include "SensorStatus.h"

class MAX17048Sensor {
private:
    Adafruit_MAX17048 maxlipo;
    SensorStatus status;

public:
    MAX17048Sensor(); // Constructeur

    void begin(); // Méthode pour initialiser le capteur
    String getChipID(); // Méthode pour obtenir l'identifiant I2C du circuit
    float getBattVoltage(); // Méthode pour obtenir la tension delivrée par la batterie
    float getBattPercent(); // Méthode pour obtenir le pourcentage de batterie restante
    float getBattChargeRate(); // Méthode pour obtenir le taux de charge/décharge
    String getBattAlerts(); // Méthode pour obtenir les différentes alertes émises par le circuit
    String toJSON(); // Sérialisation JSON automatique avec timestamp
    String getTimestamp(); // Récupération du timestamp
    SensorStatus getStatus(); // Obtenir le statut
};

#endif
