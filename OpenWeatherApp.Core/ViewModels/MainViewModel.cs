using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using OpenWeatherApp.Core.Services;
using OpenWeatherApp.Core.Services.SharedPreferenceService;
using System;

namespace OpenWeatherApp.Core.ViewModels {
    public class MainViewModel:MvxViewModel
    {
        private string _cityName;
        private MvxCommand _getWeatherCommand;
        private bool _loader;

        IWeatherService _weatherService;
        ISharedPreferenceService _sharedPreferenceService;
        IMvxNavigationService _navigationService;

       public MainViewModel(IWeatherService weatherService,IMvxNavigationService navigationService,ISharedPreferenceService sharedPreferenceService) {
            _weatherService = weatherService;
            _navigationService = navigationService;
            _sharedPreferenceService = sharedPreferenceService;

            var storedCity = _sharedPreferenceService.SharedPrefs;
            if (!string.IsNullOrEmpty(storedCity)) {
                CityName = storedCity;
            }

        }

        public string CityName {
            get => _cityName;
            set {
                SetProperty(ref _cityName, value);
            }
        }

        public bool Loader {
            get => _loader;
            set => SetProperty(ref _loader, value);
        }

        public IMvxCommand GetWeatherCommand {
            get {
                _getWeatherCommand = _getWeatherCommand ?? new MvxCommand(GetWeatherDetails);
                return _getWeatherCommand;
            }
        }

        public async void GetWeatherDetails() {
            Console.WriteLine("Button was clicked");
            Loader = true;
            var flag = await _weatherService.GetWeather(_cityName);
            if (flag) {
                _sharedPreferenceService.SharedPrefs = CityName;
                await _navigationService.Navigate<WeatherDetailsViewModel>();
            }
            Loader = false;

        }

    }
}
