using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Linq;
using System.Collections.Generic;



namespace Virtual_Assistant
{
    public class VoiceRecognition
    {
        private ChatGPT _chatGpt = new ChatGPT();
        public SpeechRecognitionEngine recognizer;
        public VoiceRecognition()
        {
            initRecognizer();
        }

        private void initRecognizer()
        {
            recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            recognizer.LoadGrammar(new DictationGrammar());
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private async void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
            _chatGpt.invokeChatGpt(e.Result.Text);
        }
    }
}
