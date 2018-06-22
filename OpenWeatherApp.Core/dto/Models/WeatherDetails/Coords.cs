using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.DTO.Models.WeatherDetails
{
    public class Coords
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

        public override string ToString() {
            return $"[{Lat:N2}:{Lon:N2}]";
        }
    }
}
