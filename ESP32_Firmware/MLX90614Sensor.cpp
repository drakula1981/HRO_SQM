#include "MLX90614Sensor.h"

MLX90614Sensor::MLX90614Sensor() : mlx(), status(Disconnected) {}

// Obtenir la température ambiante
// Obtenir la température ambiante
float MLX90614Sensor::getAmbientTemp() {
    return (status == Connected) ? mlx.readAmbientTempC() : -42.0;
}

// Obtenir la température de l'objet
float MLX90614Sensor::getSkyTemp() {
    return (status == Connected) ? mlx.readObjectTempC() : -42.0;
}

int MLX90614Sensor::GetQuarter(int month) {
    return (month + 2) / 3;
}

double MLX90614Sensor::ComputeTempCorrectionCoefficient(double ambiant, double skyTemp, int month) {
    double deltaTemp = (skyTemp / ambiant) * 10;

    double K1 = YearK1Values[month];
    
    double k1 = K1 / 100;
    double k2 = ambiant - (K2 + deltaTemp) / 10;
    double k3 = K3 / 100;
    double k4 = pow(exp(K4 / 1000 * ambiant), K5 / 100);
    double coef = round((k1 * k2 + k3 * k4) * 100) / 100;

    Serial.print("[ComputeTempCorrectionCoefficient] coef = ");
    Serial.println(coef);

    return coef;
}

double MLX90614Sensor::ComputeCloudCoveragePercent(double CorSkyTemperature, int month) {
    int quarter = GetQuarter(month);
    std::vector<int> quarterTempValues = YearTempValues[quarter];
    
    int temp_couvert = quarterTempValues[0];
    int temp_clair = quarterTempValues[1];

    double mapped_value = map(CorSkyTemperature, temp_clair, temp_couvert, 0, 100);

    if (mapped_value < 0) return 0;
    return (mapped_value > 100) ? 100 : mapped_value;
}

String MLX90614Sensor::getTimestamp() {
    struct tm timeinfo;
    if (!getLocalTime(&timeinfo)) {
        Serial.println("Impossible d'obtenir l'heure NTP");
        return "Non synchronisé";
    }
    char timestamp[50];
    strftime(timestamp, 50, "%Y-%m-%d %H:%M:%S", &timeinfo);
    return String(timestamp);
}

int MLX90614Sensor::getMonth() {
    struct tm timeinfo;
    if (getLocalTime(&timeinfo)) {
        return timeinfo.tm_mon + 1; // tm_mon commence à 0, donc on ajoute 1
    } else {
        Serial.println("Impossible d'obtenir le mois depuis l'horodatage.");
        return -1; // Valeur indicative d'erreur
    }
}

// Initialisation du capteur
void MLX90614Sensor::begin() {
    if (!mlx.begin()) {
        Serial.println("Erreur de connexion au MLX90614 !");
        status = Error;
    } else {
        Serial.println("MLX90614 initialisé avec succès !");
        status = Connected;
    }
    
    /*// Configuration du NTP
    configTime(0, 0, "pool.ntp.org", "time.nist.gov");
    Serial.println("Connexion au serveur NTP...");
    delay(2000); // Attente pour la synchronisation initiale */       
}    

String MLX90614Sensor::toJSON() {
    String timestamp = getTimestamp();
    int mois = getMonth();
    float ambient = mlx.readAmbientTempC();
    float skyTemp = mlx.readObjectTempC();
    String jsonString;    
    if(status != Connected) {
        StaticJsonDocument<100> doc;

        doc["timestamp"] = timestamp;
        doc["error"] = "Unable to get sensor datas";
        serializeJson(doc, jsonString);
    } else {
        if (mois > 0) {
            float coef= ComputeTempCorrectionCoefficient(ambient, skyTemp, mois);
            float temperature = skyTemp - coef;
            double cloudCover = ComputeCloudCoveragePercent(temperature, mois);
            DynamicJsonDocument doc(300);

            doc["timestamp"] = timestamp;
            doc["ambient"] = ambient;
            doc["sky"] = temperature;
            doc["cloudCoverture"] = cloudCover;
            
            serializeJson(doc, jsonString);
        } else {
            StaticJsonDocument<100> doc;

            doc["timestamp"] = timestamp;
            doc["error"] = "Unable to get current month";
            serializeJson(doc, jsonString);
        }
    }
    return jsonString;
}

SensorStatus MLX90614Sensor::getStatus() {
    return status; // Retourne le statut actuel du capteur
}
