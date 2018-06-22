using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.DTO.Models.WeatherDetails
{
    public class WeatherItem
    {
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Main { get; set; }
        public int Id { get; set; }
    }
}
