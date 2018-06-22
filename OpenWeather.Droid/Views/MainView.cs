using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech;
using Android.Widget;
using Java.Util;
using MvvmCross.Droid.Views;
using OpenWeatherApp.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace OpenWeather.Droid.Views {
    [Activity(Label = "Open Weather App", Theme = "@style/WeatherAppTitle")]
    public class MainView : MvxActivity<MainViewModel> {

        EditText city_editText;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.view_main);
            var voiceButton = FindViewById<Button>(Resource.Id.voiceInput);
            city_editText = FindViewById<EditText>(Resource.Id.chosenCity);

            voiceButton.Click += delegate {
                SpeechToText();
            };

        }

        private void SpeechToText() {
            Intent intent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
            intent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
            intent.PutExtra(RecognizerIntent.ExtraLanguage, Locale.English);

            try {
                StartActivityForResult(intent,200);
            } catch (ActivityNotFoundException ex) {

                Console.WriteLine(ex);
            }

        }

        protected override void OnActivityResult(int requestCode,[GeneratedEnum] Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 200) {
                if (resultCode ==Result.Ok && data != null) {
                    List<string> result = new List<string>(data.GetStringArrayListExtra(RecognizerIntent.ExtraResults));
                    Console.WriteLine(result[0]);
                    city_editText.Text = result[0];
                }
            }
        }
    }
}