#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include "DHT.h"
float cont = 0.0;
#define DHTPIN 2
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE, 15);

void setup() {
  Serial.begin(115200);
  WiFi.begin("Calori", "coxinha100");
  while (WiFi.status() != WL_CONNECTED) {
 
    delay(500);
    Serial.println("..........");
 
  }
 Serial.println("conectar");
}
 
void loop() {
 
 if(WiFi.status()== WL_CONNECTED){
 
   HTTPClient http;
   int u = dht.readHumidity();
    int t = dht.readTemperature();
    if (isnan(t) || isnan(u)) 
    {
      Serial.println("Failed to read from DHT");
    }else
    {
       http.begin("http://weatherstationalert.somee.com/api/weatherstations");
       http.addHeader("Content-Type", "application/json");
       int httpCode = http.POST("{\"setor\":0,\"pluviosidade\":0,\"Temperatura\": "+ String(t) +",\"Umidade\": "+ String(u) +"}");
       String payload = http.getString();
       cont += 0.5;
       Serial.print(httpCode); 
       Serial.println(payload);
     
       http.end();
    }

 
 }else{
 
    Serial.println("Erro de Internet");   
 
 }
 
  delay(60000);  //Send a request every 30 seconds
 
}
