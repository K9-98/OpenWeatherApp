using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenWeatherApp.Core.dto.Models;
using OpenWeatherApp.Core.DTO.Models.WeatherDetails;

namespace OpenWeatherApp.Core.Services {
    public interface IWeatherService
    {
        Task<bool> GetWeather(string city);
        string GetCityName();
        string GetTemperature();
        string GetIcon();
        string GetTimeFetched();
        string GetWeatherDesc();
        string GetWind();
        string GetCloud();
        string GetPressure();
        string GetHumidity();
        string GetSunrise();
        string GetSunset();
        string GetCoords();
        List<ListItem> GetForecastList();
    }
}
