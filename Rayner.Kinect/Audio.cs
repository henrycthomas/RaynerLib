using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Rayner.Kinect
{
    public class AudioController
    {
        private Rayner.Kinect.Controller _controller;
        private SpeechRecognitionEngine _speechRecogniser;
        private SpeechSynthesizer _speechSynthesiser;

        public AudioController(Rayner.Kinect.Controller c)
        {
            Reset();
            _controller = c;
            _speechSynthesiser = new SpeechSynthesizer();
        }

        private void Reset()
        {
         
        }

        public void Speak(string oratory)
        {
            _speechSynthesiser.Speak(oratory);
        }

        private static RecognizerInfo GetKinectRecognizer()
        {
            Func<RecognizerInfo, bool> matchingFunc = r =>
            {
                string value;
                r.AdditionalInfo.TryGetValue("Kinect", out value);
                return "True".Equals(value, StringComparison.InvariantCultureIgnoreCase) && "en-US".Equals(r.Culture.Name, StringComparison.InvariantCultureIgnoreCase);
            };
            //return SpeechRecognitionEngine.InstalledRecognizers().Where(matchingFunc).FirstOrDefault();
            return SpeechRecognitionEngine.InstalledRecognizers().FirstOrDefault();
        }
        private SpeechRecognitionEngine CreateSpeechRecognizer(System.EventHandler<System.Speech.Recognition.SpeechRecognizedEventArgs> speechRecognised, EventHandler<SpeechHypothesizedEventArgs> speechHypothesised, EventHandler<SpeechRecognitionRejectedEventArgs> speechRejected, List<string> grammerEntries)
        {
            //set recognizer info
            RecognizerInfo ri = GetKinectRecognizer();
            //create instance of SRE
            SpeechRecognitionEngine sre;
            sre = new SpeechRecognitionEngine(ri.Id);

            //Now we need to add the words we want our program to recognise
            var grammar = new Choices(grammerEntries.ToArray());

            //set culture - language, country/region
            var gb = new GrammarBuilder { Culture = ri.Culture };
            gb.Append(grammar);

            //set up the grammar builder
            var g = new Grammar(gb);
            sre.LoadGrammar(g);

            //Set events for recognizing, hypothesising and rejecting speech
            sre.SpeechRecognized += speechRecognised;
            sre.SpeechHypothesized += speechHypothesised;
            sre.SpeechRecognitionRejected += speechRejected;
            return sre;
        }
        private SpeechRecognitionEngine CreateSpeechRecognizer(System.EventHandler<System.Speech.Recognition.SpeechRecognizedEventArgs> speechRecognised, EventHandler<SpeechHypothesizedEventArgs> speechHypothesised, EventHandler<SpeechRecognitionRejectedEventArgs> speechRejected, Grammar grammar)
        {
            //set recognizer info
            RecognizerInfo ri = GetKinectRecognizer();
            //create instance of SRE
            SpeechRecognitionEngine sre;
            sre = new SpeechRecognitionEngine(ri.Id);

            //Now we need to add the words we want our program to recognise
           // var grammar = new Choices(grammerEntries.ToArray());

            //set culture - language, country/region
            //var gb = new GrammarBuilder { Culture = ri.Culture };
            //gb.Append(grammar);

            //set up the grammar builder
            //var g = new Grammar(gb);
            sre.LoadGrammar(grammar);

            //Set events for recognizing, hypothesising and rejecting speech
            sre.SpeechRecognized += speechRecognised;
            sre.SpeechHypothesized += speechHypothesised;
            sre.SpeechRecognitionRejected += speechRejected;
            return sre;
        }
        public void StartSpeechRecognition(List<string> grammerEntries, System.EventHandler<System.Speech.Recognition.SpeechRecognizedEventArgs> speechRecognised, EventHandler<SpeechHypothesizedEventArgs> speechHypothesised, EventHandler<SpeechRecognitionRejectedEventArgs> speechRejected)
        {
            _speechRecogniser = CreateSpeechRecognizer(speechRecognised, speechHypothesised, speechRejected, grammerEntries);
            _controller.Sensor.Start();
            _controller.AudioSource.BeamAngleMode = BeamAngleMode.Adaptive;
            var audioStream = _controller.AudioSource.Start();
            _speechRecogniser.SetInputToAudioStream(audioStream, new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            _speechRecogniser.RecognizeAsync(RecognizeMode.Multiple);
            _controller.AudioSource.EchoCancellationMode = EchoCancellationMode.None;
            _controller.AudioSource.AutomaticGainControlEnabled = false;
        }
        public void StartSpeechRecognition(Grammar grammer, System.EventHandler<System.Speech.Recognition.SpeechRecognizedEventArgs> speechRecognised, EventHandler<SpeechHypothesizedEventArgs> speechHypothesised, EventHandler<SpeechRecognitionRejectedEventArgs> speechRejected)
        {
            _speechRecogniser = CreateSpeechRecognizer(speechRecognised, speechHypothesised, speechRejected, grammer);
            _controller.Sensor.Start();
            _controller.AudioSource.BeamAngleMode = BeamAngleMode.Adaptive;
            var audioStream = _controller.AudioSource.Start();
            _speechRecogniser.SetInputToAudioStream(audioStream, new SpeechAudioFormatInfo(EncodingFormat.Pcm, 16000, 16, 1, 32000, 2, null));
            _speechRecogniser.RecognizeAsync(RecognizeMode.Multiple);
            _controller.AudioSource.EchoCancellationMode = EchoCancellationMode.None;
            _controller.AudioSource.AutomaticGainControlEnabled = false;
        }
        public void StopSpeechRecognition()
        {
            _controller.AudioSource.Stop();
            _controller.Sensor.Stop();
        }
    }
}
