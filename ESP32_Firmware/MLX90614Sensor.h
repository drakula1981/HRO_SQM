#ifndef MLX90614Sensor_H
#define MLX90614Sensor_H

#include <Adafruit_MLX90614.h>
#include <ArduinoJson.h>
#include <math.h>
#include <map>
#include <vector>
#include <time.h>
#include "SensorStatus.h"

class MLX90614Sensor {
private:
    Adafruit_MLX90614 mlx;
    SensorStatus status;

    std::map<int, std::vector<int>> YearTempValues = {
        {1, {0, -5}},
        {2, {0, -5}},
        {3, {5,  0}},
        {4, {0, -5}}
    };

    std::map<int, double> YearK1Values = {
        {1, 33}, {2, 33}, {3, 33}, {4, 55}, {5, 55}, {6, 66}, 
        {7, 66}, {8, 66}, {9, 66}, {10, 55}, {11, 33}, {12, 33}
    };

    double K2 = 0;
    double K3 = 4;
    double K4 = 100;
    double K5 = 100;
 
    int GetQuarter(int month);
    double ComputeTempCorrectionCoefficient(double ambiant, double skyTemp, int month);
    double ComputeCloudCoveragePercent(double CorSkyTemperature, int month);
    String getTimestamp();
    int getMonth();
public:
    // Constructeur
    MLX90614Sensor();
    // Méthode pour initialiser le capteur
    void begin();
    // Méthode pour obtenir la température ambiante
    float getAmbientTemp();
    // Méthode pour obtenir la température du ciel
    float getSkyTemp();
    // Méthode pour sérialiser les données en JSON
    String toJSON();
    SensorStatus getStatus(); // Obtenir le statut
};

#endif
