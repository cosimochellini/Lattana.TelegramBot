using System;
using System.IO;
using Google.Api.Gax.Grpc;
using Google.Cloud.Speech.V1;
using Grpc.Core;
using RestSharp.Extensions;

namespace Telegram.Bot.Examples.Echo.Manager
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


        private static string ConvertByteArrayToText(byte[] voiceFile)
        {

            var audio = RecognitionAudio.FromBytes(voiceFile);

            var client = SpeechClient.Create();
            var config = new RecognitionConfig
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.OggOpus,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.Italian.Italy
            };
            var response = client.Recognize(config, audio, CallSettings.FromCallCredentials(CallCredentials.Compose()));
            Console.WriteLine(response);
            return response.ToString();

        }


    }
}







