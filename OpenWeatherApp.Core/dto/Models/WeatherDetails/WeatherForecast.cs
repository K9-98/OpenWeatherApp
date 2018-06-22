using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.DTO.Models.WeatherDetails
{
    public class WeatherForecast
    {
        public int Dt { get; set; }
        public Coords Coord { get; set; }
        public int Visibility { get; set; }
        public List<WeatherItem> Weather { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
        public Main Main { get; set; }
        public Clouds Clouds { get; set; }
        public int Id { get; set; }
        public Sys Sys { get; set; }
        public string Base { get; set; }
        public Wind Wind { get; set; }
    }
}
