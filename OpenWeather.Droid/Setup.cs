using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using OpenWeatherApp.Core;

namespace OpenWeather.Droid {
    class Setup : MvxAndroidSetup {
        public Setup(Context applicationContext) : base(applicationContext) { }

        protected override IMvxApplication CreateApp() => new AppCore();
    }
}