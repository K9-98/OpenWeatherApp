using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.DTO.Models.WeatherDetails
{
    public class Sys
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public int Id { get; set; }
        public int Type { get; set; }
        public double Message { get; set; }

    }
}
