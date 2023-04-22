using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Assistant
{
    public class SpeechSynthesis
    {
        public void SpeakString(string textToBeSpoken)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Speak(textToBeSpoken);
            return;
        }
    }
}
