#define Version "1.0.0"
#include "Config.h"

#include <WiFi.h>
#include <AsyncTCP.h>
#include <WiFiClientSecure.h>
#include <ESPAsyncWebServer.h>
#include <ArduinoJson.h>

#include "TSL2591Sensor.h"
#include "MLX90614Sensor.h"
#include "BME280Sensor.h"
#include "EEPROMSensor.h"
#include "WiFiManager.h"
#include "ArduinoJWT.h"
//#include "LC709203FSensor.h"

const char *secret = JWT_SECRET;
const char *root_ca =
  "-----BEGIN CERTIFICATE-----\n"
  "MIIEsDCCAxigAwIBAgIRAMDiZPkCUtVE3mUGBAQMdlYwDQYJKoZIhvcNAQELBQAw\n"
  "gaMxHjAcBgNVBAoTFW1rY2VydCBkZXZlbG9wbWVudCBDQTE8MDoGA1UECwwzTEFQ\n"
  "VE9QLUtKMTBVOU1WXFRyaXN0QExBUFRPUC1LSjEwVTlNViAoVHJpc3RhbiBSRVkp\n"
  "MUMwQQYDVQQDDDpta2NlcnQgTEFQVE9QLUtKMTBVOU1WXFRyaXN0QExBUFRPUC1L\n"
  "SjEwVTlNViAoVHJpc3RhbiBSRVkpMB4XDTI1MDQyNDEyMDY0MloXDTI3MDcyNDEy\n"
  "MDY0MlowZzEnMCUGA1UEChMebWtjZXJ0IGRldmVsb3BtZW50IGNlcnRpZmljYXRl\n"
  "MTwwOgYDVQQLDDNMQVBUT1AtS0oxMFU5TVZcVHJpc3RATEFQVE9QLUtKMTBVOU1W\n"
  "IChUcmlzdGFuIFJFWSkwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDH\n"
  "bX1JP67HyEvVGpvto8xzHm1P6AL8uw3+OuSGj+o2DvS+mYLobjHisVJuIGmR0wQD\n"
  "pQqPtzI2YlmbiNFpSWSq9dE7u4LHPxHaibIiUvrfLXfatEZ2DiTVg5XktZK3UPC+\n"
  "j/ZCgtlh/0E8HTXIBRZ+iZxR1691+gGSvductVLr+eBn4e+bbiC70MVhR5Q1Rgfo\n"
  "h+hTSA9NfWt1B54wpwpeQvy2LaWdUPwwmVFadOXdnHVKnBTdQYwjDODs9apv+CxS\n"
  "OTUV2T1MOEwSZYih4BzumFfSh5dNuTohHsJQbr2MAETBoz5f+eYy3NkBkSE4ZJ4u\n"
  "aZ3UALQpYktl73LCmD+PAgMBAAGjgZkwgZYwDgYDVR0PAQH/BAQDAgWgMBMGA1Ud\n"
  "JQQMMAoGCCsGAQUFBwMBMB8GA1UdIwQYMBaAFA5jfIdbNtwGsW73DAwSiJbrE1jQ\n"
  "ME4GA1UdEQRHMEWCF2h5cGVycmVkb2JzZXJ2YXRvcnkub3Jnggdocm9fc3Ftggls\n"
  "b2NhbGhvc3SHBH8AAAGHEAAAAAAAAAAAAAAAAAAAAAEwDQYJKoZIhvcNAQELBQAD\n"
  "ggGBABBtNXHxjwJn5RmHGT4wVMHN1qkkjpM17HhGrlVANl+nwi0FM/QutAWnYIvG\n"
  "5obouvbZZmi0GwY81xGcqC4cuIAP5djvxwCekdF/0S4wzIlQPW4Lk4nScFeHK4gy\n"
  "NS9JRT9/DKm2QMvGPFsIdgHJ6qbxEjmzAIHJuzLUUI8iRV9MrB8b3BmUQFnhPyvz\n"
  "XkjfuIWah6O6TE0LwFHW8WozRUnVGKgLWPCVMZXhQTAUrdxg+BKHO97/ZgWqZpoy\n"
  "yFm02vSvc3UnZl/Dn+pDFLaGUMxKRhW1isn2kRnMFRNge/G8oCRmK4QXITBJj9L6\n"
  "31SzdOEjATzR+lLR9ke66LZGvwB+HP1v76JuUV1RH9K1qGrQ4Aop5/ml34/0o6y/\n"
  "NWtz+g/oXzhTwu5TXPTHARIIPtR4TZf/63XhdGJqYncPk0hDAcxR/IfGWUjgA4bb\n"
  "qs0BDb0AcQUik5gaphwZeWtzePTcM680QGr+RUFFvR3y0o/JjxL1ZpPLfLwShuct\n"
  "ceZpdg==\n"
  "-----END CERTIFICATE-----\n";

// Déclaration du serveur HTTPS sécurisé
WiFiClientSecure secureClient;
// Création du serveur Async
AsyncWebServer server(80);

MLX90614Sensor mlxSensor;
BME280Sensor bmeSensor;
TSL2591Sensor tslSensor;
EEPROMSensor eepromSensor;
WiFiManager wifiManager;
//LC709203FSensor battSensor;

StaticJsonDocument<400> getSensorsStatus(BME280Sensor &bme, TSL2591Sensor &tsl, MLX90614Sensor &mlx) {
  StaticJsonDocument<400> doc;

  // Inclure les statuts des capteurs
  switch (bme.getStatus()) {
    case Connected:
      doc["BME280"] = "Connected";
      break;
    case Disconnected:
      doc["BME280"] = "Disconnected";
      break;
    case Error:
      doc["BME280"] = "Error";
      break;
  }

  switch (tsl.getStatus()) {
    case Connected:
      doc["TSL2591"] = "Connected";
      break;
    case Disconnected:
      doc["TSL2591"] = "Disconnected";
      break;
    case Error:
      doc["TSL2591"] = "Error";
      break;
  }

  switch (mlx.getStatus()) {
    case Connected:
      doc["MLX90614"] = "Connected";
      break;
    case Disconnected:
      doc["MLX90614"] = "Disconnected";
      break;
    case Error:
      doc["MLX90614"] = "Error";
      break;
  }

  /*switch (batt.getStatus()) {
    case Connected:
      doc["LC709203F"] = "Connected";
      break;
    case Disconnected:
      doc["LC709203F"] = "Disconnected";
      break;
    case Error:
      doc["LC709203F"] = "Error";
      break;
  }*/

  return doc;
}

// Générer un JWT
String generateJWT(String username) {
  // Créer l'objet JWT avec la clé secrète
  ArduinoJWT jwt(secret);

  // Définir le payload
  StaticJsonDocument<200> payload;
  String jsonString;
  payload["username"] = username;
  payload["role"] = "admin";          // Exemple : rôle de l'utilisateur
  payload["exp"] = millis() + 60000;  // Durée d'expiration : 1 minute (en millisecondes)

  serializeJson(payload, jsonString);
  // Générer le jeton signé avec la clé secrète
  String token = jwt.encodeJWT(jsonString);
  return token;
}

// Vérifier un JWT
bool verifyJWT(String token) {
  // Créer l'objet JWT avec la clé secrète
  ArduinoJWT jwt(secret);

  // Décoder et vérifier
  StaticJsonDocument<200> payload;
  String jsonString;
  if (!jwt.decodeJWT(token, jsonString)) {
    Serial.println("Token invalide ou signature incorrecte !");
    return false;
  }

  deserializeJson(payload, jsonString);

  // Vérifier l'expiration
  long exp = payload["exp"].as<long>();
  if (millis() > exp) {
    Serial.println("Token expiré !");
    return false;
  }

  return true;  // Jeton valide
}

String processRequest(String request) {
  //Serial.println("Requete " + request + "...");
  String jsonResponse;
  if (request.startsWith(ROUTE_AUTH)) {
    String userName = request.substring(5);
    String token;
    if (userName != "") {
      token = generateJWT(userName);
    } else {
      return "{\"message\":\"Nom d'utilisateur manquant\"}";
    }
    StaticJsonDocument<200> doc;
    doc["token"] = token;
    serializeJson(doc, jsonResponse);
  /*} else if (request == ROUTE_BATTERY) {
    jsonResponse = battSensor.toJSON();*/
  } else if (request == ROUTE_WEATHER) {
    jsonResponse = bmeSensor.toJSON(mlxSensor.getAmbientTemp(), eepromSensor.getTempCalOffset());
  } else if (request == ROUTE_CLOUD_COVER) {
    jsonResponse = mlxSensor.toJSON();
  } else if (request == ROUTE_CALIBRATION_DATAS) {
    jsonResponse = eepromSensor.toJSON();
  } else if (request == ROUTE_SKY_BRIGHTNESS) {
    tslSensor.setCalibrationTemperature(bmeSensor.getTemperature(mlxSensor.getAmbientTemp(), eepromSensor.getTempCalOffset()));
    jsonResponse = tslSensor.toJSON();
  } else if (request == ROUTE_IDENTIFICATION) {
    StaticJsonDocument<500> response;
    response["deviceName"] = "HRO SQM Meter v" + String(Version);
    response["deviceID"] = wifiManager.getUniqueID();  // Identifiant unique
    response["wifiStatus"] = WiFi.status() == WL_CONNECTED ? "Connected" : "Disconnected";

    // Ajouter les statuts des capteurs
    StaticJsonDocument<400> sensors = getSensorsStatus(bmeSensor, tslSensor, mlxSensor);
    response["sensors"] = sensors;
    serializeJson(response, jsonResponse);
  } else if (request.startsWith(ROUTE_REBOOT)) {
    String token = request.substring(8);
    if (!verifyJWT(token)) {
      return "{\"message\": \"Token invalide ou expiré\"}";
    }
    delay(500);  // Attendre un court instant avant de redémarrer
    ESP.restart();
    jsonResponse = "{\"message\": \"Rebooting...\"}";
  } else if (request == ROUTE_WIFI_STATUS) {
    jsonResponse = wifiManager.toJSON();
  } else if (request.startsWith(ROUTE_WIFI_CONFIG)) {
    String token = request.substring(12);
    if (!verifyJWT(token)) {
      return "{\"message\": \"Token invalide ou expiré\"}";
    }
    String newSsid = request.substring(12, request.lastIndexOf(" "));
    String newPwd = request.substring(request.lastIndexOf(" "));
    wifiManager.setWiFiCredentials(newSsid, newPwd);
    jsonResponse = "{\"message\":\"WiFi configured successfully.\"}";
  } else {
    jsonResponse = "{\"error\": \"Invalid request\"}";
  }
  return jsonResponse;
}

// Setup du serveur
void setup() {
  Serial.begin(SERIAL_BAUD);
  while (Serial)
    ;
  Serial.println("Intialisation...");

  // Charger le certificat CA
  //secureClient.setCACert(root_ca);
  // Initialisation WiFi
  wifiManager.begin();
  // Initialisation Cloud Watcher
  mlxSensor.begin();
  // Initialisation Capteur Environnemental
  bmeSensor.begin();
  // Initialisation Capteur Luminosité
  tslSensor.begin();
  sensorConfig cfg = { TSL2591_GAIN_MAX, TSL2591_INTEGRATIONTIME_600MS };
  tslSensor.configure(cfg);
  // Initialisation EEprom
  eepromSensor.begin();
  // Initialisation Manager batterie
  //battSensor.begin();

  configTime(0, 0, "pool.ntp.org", "time.nist.gov");
  delay(2000);  // Attente pour la synchronisation initiale
  Serial.println("Connecté au serveur NTP...");

  Serial.println("Déclaration des routes API...");
  // Route pour obtenir un jeton JWT (authentification par exemple)
  server.on(ROUTE_AUTH, HTTP_GET, [](AsyncWebServerRequest *request) {
    String username = "";
    if (request->hasParam("username", true)) {
      username = request->getParam("username", true)->value();
    } else {
      request->send(400, "application/json", "{\"message\":\"Nom d'utilisateur manquant\"}");
      return;
    }
    request->send(200, "application/json", processRequest(ROUTE_AUTH " " + username));
  });

  // Route GET pour obtenir les données JSON du detecteur de nuages
  server.on(ROUTE_CLOUD_COVER, HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_CLOUD_COVER));
  });

  // Route GET pour obtenir les données JSON du BME280
  server.on(ROUTE_WEATHER, HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_WEATHER));
  });

  server.on(ROUTE_SKY_BRIGHTNESS, HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_SKY_BRIGHTNESS));
  });

  // Route GET pour obtenir les données JSON du MAX17048
  /*server.on(ROUTE_BATTERY, HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_BATTERY));
  });*/

  // Route GET pour obtenir les données EEPROM
  server.on(ROUTE_CALIBRATION_DATAS, HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_CALIBRATION_DATAS));
  });

  // Route POST pour mettre à jour les données EEPROM
  server.on("/CalibrationDatas", HTTP_POST, [](AsyncWebServerRequest *request) {
    Serial.println("Requete Post CalibrationDatas...");
    if (!request->hasHeader("Authorization")) {
      request->send(401, "application/json", "{\"message\":\"Missing Token\"}");
      return;
    }

    // Récupérer le token dans l'en-tête Authorization
    String token = request->header("Authorization");
    token.replace("Bearer ", "");  // Supprimer le préfixe "Bearer "

    // Vérification du token
    if (!verifyJWT(token)) {
      request->send(403, "application/json", "{\"message\":\"Invalid or expired Token\"}");
      return;
    }

    // Récupérer le corps de la requête JSON
    String body = "";
    if (request->hasParam("body", true)) {
      body = request->getParam("body", true)->value();
    } else {
      request->send(400, "text/plain", "Invalid Json Datas !");
      return;
    }

    // Parse le JSON
    StaticJsonDocument<300> doc;
    DeserializationError error = deserializeJson(doc, body);
    if (error) {
      request->send(400, "text/plain", "Invalid JSON format !");
      return;
    }

    // Mettre à jour les données dans l'EEPROM
    if (doc.containsKey("sqmCalOffset")) {
      eepromSensor.setSQMCalOffset(doc["sqmCalOffset"]);
    }
    if (doc.containsKey("tempCalOffset")) {
      eepromSensor.setTempCalOffset(doc["tempCalOffset"]);
    }
    if (doc.containsKey("autoTempCal")) {
      eepromSensor.setAutoTempCal(doc["autoTempCal"]);
    }
    if (doc.containsKey("dfCal")) {
      eepromSensor.setDFCal(doc["dfCal"]);
    }

    // Répondre avec un message de confirmation
    request->send(200, "application/json", "{\"message\":\"EEPROM update successful\"}");
  });

  // Route POST pour redémarrer l'ESP32
  server.on(ROUTE_REBOOT, HTTP_POST, [](AsyncWebServerRequest *request) {
    if (!request->hasHeader("Authorization")) {
      request->send(401, "application/json", "{\"message\":\"Missing Token\"}");
      return;
    }

    // Récupérer le token dans l'en-tête Authorization
    String token = request->header("Authorization");
    token.replace("Bearer ", "");  // Supprimer le préfixe "Bearer "
    request->send(200, "application/json", processRequest(ROUTE_REBOOT " " + token));
  });

  // Route GET pour obtenir l'état WiFi
  server.on(ROUTE_WIFI_STATUS, HTTP_GET, [](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_WIFI_STATUS));
  });

  // Route POST pour configurer un WiFi
  server.on(ROUTE_WIFI_CONFIG, HTTP_POST, [](AsyncWebServerRequest *request) {
    if (!request->hasHeader("Authorization")) {
      request->send(401, "application/json", "{\"message\":\"Missing Token\"}");
      return;
    }

    // Récupérer le token dans l'en-tête Authorization
    String token = request->header("Authorization");
    token.replace("Bearer ", "");  // Supprimer le préfixe "Bearer "

    String body = "";
    if (request->hasParam("body", true)) {
      body = request->getParam("body", true)->value();
    } else {
      request->send(400, "text/plain", "Missing JSON Request body!");
      return;
    }

    StaticJsonDocument<200> doc;
    DeserializationError error = deserializeJson(doc, body);
    if (error) {
      request->send(400, "text/plain", "Invalid JSON format!");
      return;
    }

    if (doc.containsKey("ssid") && doc.containsKey("password")) {
      request->send(200, "application/json", processRequest(ROUTE_WIFI_CONFIG " " + token + " " + doc["ssid"].as<String>() + " " + doc["password"].as<String>()));
    } else {
      request->send(400, "text/plain", "Missing Wifi Parameters!");
    }
  });

  server.on(ROUTE_IDENTIFICATION, HTTP_GET, [&](AsyncWebServerRequest *request) {
    request->send(200, "application/json", processRequest(ROUTE_IDENTIFICATION));
  });

  Serial.println("Routes API déclarées...Démarrage serveur");
  // Démarrer le serveur
  server.begin();
}

void loop() {
  if (Serial.available()) {
    String request = Serial.readStringUntil('\n');
    Serial.println(processRequest(request));  // Utilisation de la méthode centrale
  }
}
