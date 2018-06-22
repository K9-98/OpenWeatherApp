using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;
using OpenWeather.Droid.Views;

namespace OpenWeather.Droid {
    [Activity(Label = "Open Weather App", MainLauncher = true, Theme = "@style/WeatherAppNoTitle")]
    public class SplashScreen : MvxSplashScreenActivity {

        public SplashScreen() : base(Resource.Layout.splash_screen) { }

        protected override void TriggerFirstNavigate() {
            StartActivity(typeof(MainView));
            base.TriggerFirstNavigate();
        }

        //protected override void OnCreate(Bundle bundle) {
        //    base.OnCreate(bundle);
        //    this.requestWindowFeature(Window.FEATURE_NO_TITLE);
        //}

    }
}

