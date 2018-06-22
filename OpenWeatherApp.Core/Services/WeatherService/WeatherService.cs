using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenWeatherApp.Core.dto.Models;
using OpenWeatherApp.Core.DTO.Models.WeatherDetails;

namespace OpenWeatherApp.Core.Services {
        public class WeatherService : IWeatherService {

            private  WeatherForecast forecast;
            private List<ListItem> listItems;

            private readonly String http = "http://api.openweathermap.org/data/2.5/weather?q=";
            private readonly String apiKey = "&appid=899bd1483a8079be478209575b2d8b05";
            private static HttpClient client = new HttpClient();

            public async Task<bool> GetWeather(string city) {
                var uri = http + city + apiKey;
            try {
                var response = await client.GetStringAsync(uri);
                forecast = JsonConvert.DeserializeObject<WeatherForecast>(response);
                return true;
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
                
            }

            public string GetCityName() {
                return "Weather in "+forecast.Name+", "+forecast.Sys.Country;
            }

            public string GetTemperature() {
                return $"{forecast.Main.Temp - 273.15}°C";
            }

            public string GetIcon() {
                return "http://openweathermap.org/img/w/"+forecast.Weather[0].Icon+".png";
            }

            public string GetTimeFetched() {
                DateTime date = (new DateTime(1970,1,1,2,0,0)).AddMilliseconds((double)forecast.Dt*1000L);
                return $"Got at {date:yyyy/MM/dd HH:mm tt}";
            }

            public string GetWeatherDesc() {
                return forecast.Weather[0].Description;
            }

        public List<ListItem> GetForecastList() {
            listItems = new List<ListItem>();
            PopulateList();
            return listItems;
        }

        private void PopulateList() {
            listItems.Add(new ListItem("Wind",GetWind()));
            listItems.Add(new ListItem("Clouds",GetCloud()));
            listItems.Add(new ListItem("Pressure",GetPressure()));
            listItems.Add(new ListItem("Humidity",GetHumidity()));
            listItems.Add(new ListItem("Sunrise",GetSunrise()));
            listItems.Add(new ListItem("Sunset",GetSunset()));
            listItems.Add(new ListItem("Geo Coords", GetCoords()));
        }

            public string GetWind() {
            var windspeed = forecast.Wind.Speed;
            var windDeg = forecast.Wind.Deg;
            var windRating = GetWindSpeedDetails(windspeed);
            var windDirection = GetWindDegDetails(windDeg);
            return $"{windRating} {windspeed}m\\s \n{windDirection} ({windDeg})";
            }

            public string GetCloud() {
                return forecast.Weather[0].Main;
            }

            public string GetPressure() {
                return $"{forecast.Main.Pressure} h.p.a";
            }

            public string GetHumidity() {
                return $"{forecast.Main.Humidity}%";
            }

            public string GetSunrise() {
                DateTime time = (new DateTime(1970, 1, 1, 2, 0, 0)).AddMilliseconds((forecast.Sys.Sunrise) * 1000L);
                return $"{time:HH:mm tt}";
            }

            public string GetSunset() {
                DateTime time = (new DateTime(1970, 1, 1, 2, 0, 0)).AddMilliseconds((forecast.Sys.Sunset) * 1000L);
                return $"{time:HH:mm tt}";
        }

            public string GetCoords() {
            return $"[{forecast.Coord.Lat:N2}:{forecast.Coord.Lon:N2}]";
            }

        public string GetWindDegDetails(double windDeg) {
                string windDirection = "";
                if (windDeg == 0 || windDeg == 360) {
                    windDirection = "North";
                } else if (windDeg > 0 && windDeg < 45) {
                    windDirection = "North North-East";
                } else if (windDeg == 45) {
                    windDirection = "North-East";
                } else if (windDeg > 45 && windDeg < 90) {
                    windDirection = "East North-East";
                } else if (windDeg == 90) {
                    windDirection = "East";
                } else if (windDeg > 90 && windDeg < 135) {
                    windDirection = "East South-East";
                } else if (windDeg == 135) {
                    windDirection = "South-East";
                } else if (windDeg > 135 && windDeg < 180) {
                    windDirection = "South South-East";
                } else if (windDeg == 180) {
                    windDirection = "South";
                } else if (windDeg > 180 && windDeg < 225) {
                    windDirection = "South South-West";
                } else if (windDeg == 225) {
                    windDirection = "South-West";
                } else if (windDeg > 225 && windDeg < 270) {
                    windDirection = "West South-West";
                } else if (windDeg == 270) {
                    windDirection = "West";
                } else if (windDeg > 270 && windDeg < 315) {
                    windDirection = "West North-West";
                } else if (windDeg == 315) {
                    windDirection = "North-West";
                } else if (windDeg > 315 && windDeg < 360) {
                    windDirection = "West North-West";
                }

                return windDirection;
            }

            public string GetWindSpeedDetails(double windSpeed) {

                string windRating = "";

                if (windSpeed < 0.3) {
                    windRating = "Calm";
                } else if (windSpeed >= 0.3 && windSpeed < 1.6) {
                    windRating = "Light Air";
                } else if (windSpeed >= 1.6 && windSpeed < 3.4) {
                    windRating = "Light Breeze";
                } else if (windSpeed >= 3.4 && windSpeed < 5.5) {
                    windRating = "Gentle Breeze";
                } else if (windSpeed >= 5.5 && windSpeed < 8) {
                    windRating = "Moderate Breeze";
                } else if (windSpeed >= 8 && windSpeed < 10.8) {
                    windRating = "Fresh Breeze";
                } else if (windSpeed >= 10.8 && windSpeed < 13.9) {
                    windRating = "Strong Breeze";
                } else if (windSpeed >= 13.9 && windSpeed < 17.2) {
                    windRating = "High Wind";
                } else if (windSpeed >= 17.2 && windSpeed < 20.8) {
                    windRating = "Gale";
                } else if (windSpeed >= 20.8 && windSpeed < 24.5) {
                    windRating = "Severe Gale";
                } else if (windSpeed >= 24.5 && windSpeed < 28.5) {
                    windRating = "Storm";
                } else if (windSpeed >= 28.5 && windSpeed < 32.7) {
                    windRating = "Violent Storm";
                } else if (windSpeed >= 32.7) {
                    windRating = "Hurricane Force";
                }

                return windRating;
            }

       
    }
    }
