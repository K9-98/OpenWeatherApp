using MvvmCross.Core.ViewModels;
using OpenWeatherApp.Core.dto.Models;
using OpenWeatherApp.Core.Services;
using OpenWeatherApp.Core.Services.TextToSpeechService;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.ViewModels
{
    public class WeatherDetailsViewModel : MvxViewModel {

        IWeatherService _weatherService;
        ITextToSpeechService _textToSpeechService;
        private string _cityName;
        private string _temperature;
        private string _icon;
        private string _timeFetched;
        private string _weatherDesc;
        private List<ListItem> _listItems;


        private string _wind;
        private string _clouds;
        private string _pressure;
        private string _humidity;
        private string _sunrise;
        private string _sunset;
        private string _coords;

        public WeatherDetailsViewModel(IWeatherService weatherService,ITextToSpeechService textToSpeechService) {
            _weatherService = weatherService;
            _textToSpeechService = textToSpeechService;
            OnInit();
        }

        public void OnInit() {
            City = _weatherService.GetCityName();
            Temperature = _weatherService.GetTemperature();
            Icon = _weatherService.GetIcon();
            TimeFetched = _weatherService.GetTimeFetched();
            WeatherDesc = _weatherService.GetWeatherDesc();
            ListItems = _weatherService.GetForecastList();
        }

        public string City {
            get => _cityName;
            set => SetProperty(ref _cityName, value);
        }

        public string Temperature {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }

        public string Icon {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public string TimeFetched {
            get => _timeFetched;
            set => SetProperty(ref _timeFetched, value);
        }

        public string WeatherDesc {
            get => _weatherDesc;
            set => SetProperty(ref _weatherDesc, value);
        }

        public List<ListItem> ListItems {
            get => _listItems;
            set => SetProperty(ref _listItems, value);
        }

        public string Wind {
            get => _wind;
            set => SetProperty(ref _wind, value);
        }

        public string Clouds {
            get => _clouds;
            set => SetProperty(ref _clouds, value);
        }

        public string Pressure {
            get => _pressure;
            set => SetProperty(ref _pressure, value);
        }

        public string Humidity {
            get => _humidity;
            set => SetProperty(ref _humidity, value);
        }

        public string Sunrise {
            get => _sunrise;
            set => SetProperty(ref _sunrise, value);
        }

        public string Sunset {
            get => _sunset;
            set => SetProperty(ref _sunset, value);
        }

        public string Coords {
            get => _coords;
            set => SetProperty(ref _coords, value);
        }

        private MvxCommand _textToSpeechCommand;
        public IMvxCommand TextToSpeechCommand {
            get {
                _textToSpeechCommand = _textToSpeechCommand ?? new MvxCommand(TextToSpeech);
                return _textToSpeechCommand;
            }
        }

        public void TextToSpeech() {
            var text = City+". "
                +TimeFetched+". The forecast for today is "
                +WeatherDesc+" with a temperature of "+Temperature;
            _textToSpeechService.TextToSpeech(text);
        }
    }
}
