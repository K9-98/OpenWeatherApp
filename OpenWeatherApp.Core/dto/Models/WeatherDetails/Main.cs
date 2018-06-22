using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.DTO.Models.WeatherDetails
{
    public class Main
    {
        public double Temp { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
    }
}
