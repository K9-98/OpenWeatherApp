using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using OpenWeatherApp.Core.ViewModels;

namespace OpenWeather.Droid.Views {
    [Activity(Label = "WeatherDetailsView", Theme = "@style/WeatherAppTitle")]
    public class WeatherDetailsView : MvxActivity<WeatherDetailsViewModel> {

        TextView weatherHeader;
        MvxImageView weatherIcon;
        TextView date;
        TextView temperature;
        TextView weatherDesc;
        MvxListView weatherDetailsList;
        Button speechBtn;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_weather_details);
            weatherHeader = FindViewById<TextView>(Resource.Id.weatherHeader);
            weatherIcon = FindViewById<MvxImageView>(Resource.Id.weatherIcon);
            date = FindViewById<TextView>(Resource.Id.date);
            temperature = FindViewById<TextView>(Resource.Id.temperature);
            weatherDesc = FindViewById<TextView>((Resource.Id.forecast));
            weatherDetailsList = FindViewById<MvxListView>(Resource.Id.weatherListView);
            speechBtn = FindViewById<Button>(Resource.Id.speak);

            var set = this.CreateBindingSet<WeatherDetailsView, WeatherDetailsViewModel>();
            set.Bind(weatherHeader).For(v => v.Text).To(vm => vm.City);
            set.Bind(weatherIcon).For(v=>v.ImageUrl).To(vm => vm.Icon);
            set.Bind(temperature).For(v => v.Text).To(vm => vm.Temperature);
            set.Bind(date).For(v => v.Text).To(vm => vm.TimeFetched);
            set.Bind(weatherDesc).For(v => v.Text).To(vm => vm.WeatherDesc);
            set.Bind(weatherDetailsList).For(v => v.ItemsSource).To(vm => vm.ListItems);
            set.Bind(speechBtn).To(vm => vm.TextToSpeechCommand);
            set.Apply();

        }
    }
}