using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherApp.Core.Services.TextToSpeechService
{
    public interface ITextToSpeechService
    {
       void TextToSpeech(string text);
    }
}
