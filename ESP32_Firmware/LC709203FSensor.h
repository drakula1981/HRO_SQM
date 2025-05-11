#ifndef LC709203FSensor_H
#define LC709203FSensor_H

#include <Adafruit_LC709203F.h>
#include <ArduinoJson.h>
#include <time.h> // Bibliothèque pour NTP
#include "SensorStatus.h"

class LC709203FSensor {
private:
    Adafruit_LC709203F maxlipo;
    SensorStatus status;

public:
    LC709203FSensor(); // Constructeur

    void begin(); // Méthode pour initialiser le capteur
    String getChipID(); // Méthode pour obtenir l'identifiant I2C du circuit
    float getBattVoltage(); // Méthode pour obtenir la tension delivrée par la batterie
    float getBattPercent(); // Méthode pour obtenir le pourcentage de batterie restante
    void  setAlarmVoltage(float alarm); // Méthode pour définir la seuil de tension de batterie pour declencher l'alarme
    String toJSON(); // Sérialisation JSON automatique avec timestamp
    String getTimestamp(); // Récupération du timestamp
    SensorStatus getStatus(); // Obtenir le statut
};

#endif
