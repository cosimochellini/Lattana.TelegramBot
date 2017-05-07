using System;
using System.Collections.Generic;
using System.IO;
using Google.Api.Gax.Grpc;
using RestSharp.Extensions;
using Telegram.Bot;
using Google.Cloud.Speech.V1;
using Google.Apis.Auth.OAuth2;



namespace TelegramBotDemo.Manager
{
    public static class VoiceManager
    {
        public static bool SaveVoice(string fileId, TelegramBotClient boot, string fileName)
        {
            var file = boot.GetFileAsync(fileId);
            var byteArray = file.Result.FileStream.ReadAsBytes();
            File.WriteAllBytes(fileName + ".ogg", byteArray);
            return true;

        }


        public static byte[] FileIdToByteArray(string fileId, TelegramBotClient boot, string fileName)
        {
            var file = boot.GetFileAsync(fileId);
            var byteArray = file.Result.FileStream.ReadAsBytes();
            var ciao = ConvertByteArrayToText(byteArray);

            return byteArray;

        }


        public static string ConvertByteArrayToText(byte[] voiceFile)
        {

            //var credential = GoogleCredential.GetApplicationDefaultAsync();

            //var audio = RecognitionAudio.FromBytes(voiceFile);
            //var client = SpeechClient.Create();
            //var config = new RecognitionConfig
            //{
            //    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
            //    SampleRateHertz = 16000,
            //    LanguageCode = LanguageCodes.Italian.Italy,
            //    SpeechContexts = { new List<SpeechContext>()},
            //    ProfanityFilter = true,
            //    MaxAlternatives = 4

            //};

            //try
            //{
            //    var response = client.Recognize(config, audio);
            //    Console.WriteLine(response);
            //    return response.Results.ToString();


            //}
            //catch (Exception ex)
            //{
            //    return "errore";
            //}


            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.OggOpus,
                SampleRateHertz = 16000,
                LanguageCode = "it",
            }, RecognitionAudio.FromFile("AwADBAADxgADSWsZUPl8Yx53M6r7Ag.ogg"));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return "ciao";

        }
    }
}







