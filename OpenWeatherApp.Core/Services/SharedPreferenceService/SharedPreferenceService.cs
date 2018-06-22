using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace OpenWeatherApp.Core.Services.SharedPreferenceService {
    public class SharedPreferenceService:ISharedPreferenceService
    {
        private static ISettings Settings => CrossSettings.Current;

        public string SharedPrefs {
            get => Settings.GetValueOrDefault(nameof(SharedPrefs), string.Empty);
            set => Settings.AddOrUpdateValue(nameof(SharedPrefs), value);
        }

    }
}
