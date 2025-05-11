#ifndef WiFiManager_H
#define WiFiManager_H

#include <EEPROM.h>
#include <WiFi.h>
#include <ArduinoJson.h>
#include "Config.h"

class WiFiManager {
private:
    // Configuration WiFi
    const char* ap_ssid = AP_DEFAULT_SSID;
    const char* ap_password = AP_DEFAULT_PASS;

    const char* dflt_ssid = WIFI_DEFAULT_SSID;
    const char* dflt_password = WIFI_DEFAULT_PASS;
    void startAccessPoint(); // Démarrer en mode AP
    void connectToWiFi(); // Connexion au WiFi configuré
    void connectToDefaultWiFi(); // Connexion au WiFi par defaut
public:
    void begin(); // Initialisation du Wifi
    void setWiFiCredentials(String ssid, String password); // Sauvegarder les credentials
    String toJSON(); // Sérialiser l'état actuel en JSON
    String getUniqueID();
};

#endif