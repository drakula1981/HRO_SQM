#include "WiFiManager.h"

#define EEPROM_WIFI_SSID_INDEX 0
#define EEPROM_WIFI_PASS_INDEX 100
#define EEPROM_SIZE 512

void WiFiManager::begin() {
    EEPROM.begin(EEPROM_SIZE);

    if (EEPROM.read(EEPROM_WIFI_SSID_INDEX) == 0) {
        if(dflt_ssid != "" && dflt_password != "") {
           Serial.println("No network configured. Trying to connect to default network...");   
           connectToDefaultWiFi(); 
        } else {
            Serial.println("No network configured. Starting up in AP mode...");
            startAccessPoint();
        }
    } else {
        Serial.println("Network connection stored...");
        connectToWiFi();
    }
    Serial.println("IP : " + WiFi.localIP().toString());
}

void WiFiManager::startAccessPoint() {
    WiFi.softAP(ap_ssid, ap_password);
    Serial.println("AP mode started. SSID: " + String(ap_ssid) + ", Key: " + String(ap_password));
}

void WifiEvent(WiFiEvent_t event) {
  if(event == ETHERNET_EVENT_DISCONNECTED) {
    WiFi.reconnect();
  }
}

void WiFiManager::connectToWiFi() {
    char ssid[32];
    char password[64];

    for (int i = 0; i < 32; i++) {
        ssid[i] = EEPROM.read(EEPROM_WIFI_SSID_INDEX + i);
    }
    ssid[31] = '\0';

    for (int i = 0; i < 64; i++) {
        password[i] = EEPROM.read(EEPROM_WIFI_PASS_INDEX + i);
    }
    password[63] = '\0';

    WiFi.onEvent(WifiEvent);
    WiFi.begin(ssid, password);

    int retryCount = 0;
    const int maxRetries = 5; // Nombre maximum de tentatives

    while (WiFi.status() != WL_CONNECTED && retryCount < maxRetries) {
        delay(1000);
        Serial.println("Trying to connect to Wifi Network " + String(ssid) + "...");
        retryCount++;
    }

    if (WiFi.status() == WL_CONNECTED) {
        Serial.println("Successfully connected to Wifi: " + String(ssid));
    } else {
        if(String(dflt_ssid) != "" && String(dflt_password) != "") {
           Serial.println("Unable to connect to Wifi network after " + String(maxRetries) + " attempts. Trying to connect to default network...");   
           connectToDefaultWiFi(); 
        } else {
            Serial.println("Unable to connect to Wifi network after " + String(maxRetries) + " attempts. Switching in AP mode...");
            startAccessPoint(); // Retour en mode Access Point
        }        
    }
}

void WiFiManager::connectToDefaultWiFi() {
    WiFi.onEvent(WifiEvent);
    WiFi.begin(dflt_ssid, dflt_password);

    int retryCount = 0;
    const int maxRetries = 5; // Nombre maximum de tentatives

    while (WiFi.status() != WL_CONNECTED && retryCount < maxRetries) {
        delay(1000);
        Serial.println("Trying to connect to Wifi Network " + String(dflt_ssid) + "...");
        retryCount++;
    }

    if (WiFi.status() == WL_CONNECTED) {
        Serial.println("Successfully connected to Wifi: " + String(dflt_ssid));
    } else {
        Serial.println("Unable to connect to Wifi network after " + String(maxRetries) + " attempts. Switching in AP mode...");
        startAccessPoint(); // Retour en mode Access Point
    }
}

void WiFiManager::setWiFiCredentials(String ssid, String password) {
    for (int i = 0; i < 32; i++) {
        EEPROM.write(EEPROM_WIFI_SSID_INDEX + i, i < ssid.length() ? ssid[i] : 0);
    }

    for (int i = 0; i < 64; i++) {
        EEPROM.write(EEPROM_WIFI_PASS_INDEX + i, i < password.length() ? password[i] : 0);
    }

    EEPROM.commit();
    Serial.println("WiFi Credentials successfully stored in EEPROM.");
}

String WiFiManager::getUniqueID() {
    uint64_t chipID = ESP.getEfuseMac(); // Récupérer l'adresse MAC unique de l'ESP32
    char id[20];
    sprintf(id, "%04X%08X", (uint16_t)(chipID >> 32), (uint32_t)chipID);
    return String(id);
}

String WiFiManager::toJSON() {
    StaticJsonDocument<200> doc;
    doc["mode"] = WiFi.getMode() == WIFI_AP ? "AccessPoint" : "Station";
    doc["status"] = WiFi.status() == WL_CONNECTED ? "Connected" : "Disconnected";
    if (WiFi.status() == WL_CONNECTED) {
        doc["ssid"] = WiFi.SSID();
        doc["ip"] = WiFi.localIP().toString();
    }

    String jsonString;
    serializeJson(doc, jsonString);
    return jsonString;
}
