#ifndef SENSORSTATUS_H
#define SENSORSTATUS_H

enum SensorStatus {
    Connected,     // Capteur connecté et fonctionnel
    Disconnected,  // Capteur déconnecté ou inaccessible
    Error          // Erreur de communication ou de fonctionnement
};

#endif
