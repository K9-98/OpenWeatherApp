using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.Services.TextToSpeechService
{
    public class TextToSpeechService:ITextToSpeechService
    {
        public async void TextToSpeech(string text) {
            await CrossTextToSpeech.Current.Speak(text);
        }
    }
}
