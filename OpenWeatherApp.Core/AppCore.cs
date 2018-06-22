using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using OpenWeatherApp.Core.Services;
using OpenWeatherApp.Core.Services.SharedPreferenceService;
using OpenWeatherApp.Core.Services.TextToSpeechService;
using OpenWeatherApp.Core.ViewModels;

namespace OpenWeatherApp.Core {
    public class AppCore : MvxApplication
    {
        public override void Initialize() {

            Mvx.LazyConstructAndRegisterSingleton<IWeatherService, WeatherService>();
            Mvx.LazyConstructAndRegisterSingleton<ISharedPreferenceService, SharedPreferenceService>();
            Mvx.LazyConstructAndRegisterSingleton<ITextToSpeechService, TextToSpeechService>();
            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}
