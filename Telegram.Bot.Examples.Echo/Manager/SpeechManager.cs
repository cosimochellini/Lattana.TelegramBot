using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Google.Cloud.Speech.V1;
 
namespace Telegram.Bot.Examples.Echo.Manager
{
    public static class SpeechManager
    {
        public static object Rec(string filePath, int bitRate, RecognitionConfig.Types.AudioEncoding encoding)
        {
            var xx = RecognitionAudio.FromFile(filePath);
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = encoding,
                SampleRateHertz = bitRate,
                LanguageCode = "en",
            }, RecognitionAudio.FromFile(filePath));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return 0;
        }

        public static void Roar(string[] args)
        {
            try
            {
                var currentFolder = Directory.GetCurrentDirectory();

                var fileStream = File.OpenRead(Path.Combine(currentFolder,"prova.ogg"));
                var memoryStream = new MemoryStream();
                memoryStream.SetLength(fileStream.Length);
                fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                var baAudioFile = memoryStream.GetBuffer();
                HttpWebRequest hwrSpeechToText = null;
                hwrSpeechToText =
                            (HttpWebRequest)WebRequest.Create(
                                "https://www.google.com/speech-api/v2/recognize?output=json&lang=en-us&key=AIzaSyAYONPBoCPz0HQpzDcxo0d_U3CH4Ss_DJ4");
                hwrSpeechToText.Credentials = CredentialCache.DefaultCredentials;
                hwrSpeechToText.Method = "POST";
                hwrSpeechToText.ContentType = "audio/x-ogg; rate=44100";
                var stream = hwrSpeechToText.GetRequestStream();
                stream.Write(baAudioFile, 0, baAudioFile.Length);
                stream.Close();

                var hwrResponse = (HttpWebResponse)hwrSpeechToText.GetResponse();
                if (hwrResponse.StatusCode == HttpStatusCode.OK)
                {
                    var srResponse = new StreamReader(hwrResponse.GetResponseStream());
                    Console.WriteLine(srResponse.ReadToEnd());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
        
        public static int SyncRecognize(string filePath)
        {
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.OggOpus,
                SampleRateHertz = 16000,
                LanguageCode = "it-IT",
            }, RecognitionAudio.FromFile(filePath));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return 0;
        }

        // [START speech_sync_recognize]
        // [END speech_sync_recognize]

        /// <summary>
        /// Reads a list of phrases from stdin.
        /// </summary>
        static List<string> ReadPhrases()
        {
            Console.Write("Reading phrases from stdin.  Finish with blank line.\n> ");
            var phrases = new List<string>();
            string line = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(line))
            {
                phrases.Add(line.Trim());
                Console.Write("> ");
                line = Console.ReadLine();
            }
            return phrases;
        }

        private static object RecognizeWithContext(string filePath, IEnumerable<string> phrases)
        {
            var speech = SpeechClient.Create();
            var config = new RecognitionConfig()
            {
                SpeechContexts = { new SpeechContext() { Phrases = { phrases } } },
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "en"
            };
            var audio = IsStorageUri(filePath) ?
                RecognitionAudio.FromStorageUri(filePath) :
                RecognitionAudio.FromFile(filePath);
            var response = speech.Recognize(config, audio);
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return 0;
        }

        // [START speech_sync_recognize_gcs]
        static object SyncRecognizeGcs(string storageUri)
        {
            var speech = SpeechClient.Create();
            var response = speech.Recognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "it",
            }, RecognitionAudio.FromStorageUri(storageUri));
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return 0;
        }
        // [END speech_sync_recognize_gcs]

        // [START speech_async_recognize]
        public static object LongRunningRecognize(string filePath)
        {
            var speech = SpeechClient.Create();
            var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "it",
            }, RecognitionAudio.FromFile(filePath));
            longOperation = longOperation.PollUntilCompleted();
            var response = longOperation.Result;
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return 0;
        }
        // [END speech_async_recognize]

        // [START speech_async_recognize_gcs]
        static object AsyncRecognizeGcs(string storageUri)
        {
            var speech = SpeechClient.Create();
            var longOperation = speech.LongRunningRecognize(new RecognitionConfig()
            {
                Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = "en",
            }, RecognitionAudio.FromStorageUri(storageUri));
            longOperation = longOperation.PollUntilCompleted();
            var response = longOperation.Result;
            foreach (var result in response.Results)
            {
                foreach (var alternative in result.Alternatives)
                {
                    Console.WriteLine(alternative.Transcript);
                }
            }
            return 0;
        }
        // [END speech_async_recognize_gcs]

        /// <summary>
        /// Stream the content of the file to the API in 32kb chunks.
        /// </summary>
        // [START speech_streaming_recognize]
        static async Task<object> StreamingRecognizeAsync(string filePath)
        {
            var speech = SpeechClient.Create();
            var streamingCall = speech.StreamingRecognize();
            // Write the initial request with the config.
            await streamingCall.WriteAsync(
                new StreamingRecognizeRequest()
                {
                    StreamingConfig = new StreamingRecognitionConfig()
                    {
                        Config = new RecognitionConfig()
                        {
                            Encoding =
                            RecognitionConfig.Types.AudioEncoding.Linear16,
                            SampleRateHertz = 16000,
                            LanguageCode = "en",
                        },
                        InterimResults = true,
                    }
                });
            // Print responses as they arrive.
            Task printResponses = Task.Run(async () =>
            {
                while (await streamingCall.ResponseStream.MoveNext(
                    default(CancellationToken)))
                {
                    foreach (var result in streamingCall.ResponseStream
                        .Current.Results)
                    {
                        foreach (var alternative in result.Alternatives)
                        {
                            Console.WriteLine(alternative.Transcript);
                        }
                    }
                }
            });
            // Stream the file content to the API.  Write 2 32kb chunks per 
            // second.
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var buffer = new byte[32 * 1024];
                int bytesRead;
                while ((bytesRead = await fileStream.ReadAsync(
                    buffer, 0, buffer.Length)) > 0)
                {
                    await streamingCall.WriteAsync(
                        new StreamingRecognizeRequest()
                        {
                            AudioContent = Google.Protobuf.ByteString
                            .CopyFrom(buffer, 0, bytesRead),
                        });
                    await Task.Delay(500);
                };
            }
            await streamingCall.WriteCompleteAsync();
            await printResponses;
            return 0;
        }
        // [END speech_streaming_recognize]

        // [START speech_streaming_mic_recognize]
        //static async Task<object> StreamingMicRecognizeAsync(int seconds)
        //{
        //    if (NAudio.Wave.WaveIn.DeviceCount < 1)
        //    {
        //        Console.WriteLine("No microphone!");
        //        return -1;
        //    }
        //    var speech = SpeechClient.Create();
        //    var streamingCall = speech.StreamingRecognize();
        //    // Write the initial request with the config.
        //    await streamingCall.WriteAsync(
        //        new StreamingRecognizeRequest()
        //        {
        //            StreamingConfig = new StreamingRecognitionConfig()
        //            {
        //                Config = new RecognitionConfig()
        //                {
        //                    Encoding =
        //                    RecognitionConfig.Types.AudioEncoding.Linear16,
        //                    SampleRateHertz = 16000,
        //                    LanguageCode = "en",
        //                },
        //                InterimResults = true,
        //            }
        //        });
        //    // Print responses as they arrive.
        //    Task printResponses = Task.Run(async () =>
        //    {
        //        while (await streamingCall.ResponseStream.MoveNext(
        //            default(CancellationToken)))
        //        {
        //            foreach (var result in streamingCall.ResponseStream
        //                .Current.Results)
        //            {
        //                foreach (var alternative in result.Alternatives)
        //                {
        //                    Console.WriteLine(alternative.Transcript);
        //                }
        //            }
        //        }
        //    });
        //    // Read from the microphone and stream to API.
        //    object writeLock = new object();
        //    bool writeMore = true;
        //    var waveIn = new NAudio.Wave.WaveInEvent();
        //    waveIn.DeviceNumber = 0;
        //    waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
        //    waveIn.DataAvailable +=
        //        (object sender, NAudio.Wave.WaveInEventArgs args) =>
        //        {
        //            lock (writeLock)
        //            {
        //                if (!writeMore) return;
        //                streamingCall.WriteAsync(
        //                    new StreamingRecognizeRequest()
        //                    {
        //                        AudioContent = Google.Protobuf.ByteString
        //                            .CopyFrom(args.Buffer, 0, args.BytesRecorded)
        //                    }).Wait();
        //            }
        //        };
        //    waveIn.StartRecording();
        //    Console.WriteLine("Speak now.");
        //    await Task.Delay(TimeSpan.FromSeconds(seconds));
        //    // Stop recording and shut down.
        //    waveIn.StopRecording();
        //    lock (writeLock) writeMore = false;
        //    await streamingCall.WriteCompleteAsync();
        //    await printResponses;
        //    return 0;
        //}
        // [END speech_streaming_mic_recognize]

        static bool IsStorageUri(string s) => s.Substring(0, 4).ToLower() == "gs:/";

        //public static int Main(string[] args)
        //{
        //    return (int)Parser.Default.ParseArguments<
        //        SyncOptions, AsyncOptions,
        //        StreamingOptions, ListenOptions,
        //        RecOptions, SyncOptionsWithCreds,
        //        OptionsWithContext
        //        >(args).MapResult(
        //        (SyncOptions opts) => IsStorageUri(opts.FilePath) ?
        //            SyncRecognizeGcs(opts.FilePath) : SyncRecognize(opts.FilePath),
        //        (AsyncOptions opts) => IsStorageUri(opts.FilePath) ?
        //            AsyncRecognizeGcs(opts.FilePath) : LongRunningRecognize(opts.FilePath),
        //        (StreamingOptions opts) => StreamingRecognizeAsync(opts.FilePath).Result,
        //        (ListenOptions opts) => StreamingMicRecognizeAsync(opts.Seconds).Result,
        //        (RecOptions opts) => Rec(opts.FilePath, opts.BitRate, opts.Encoding),
        //        (SyncOptionsWithCreds opts) => SyncRecognizeWithCredentials(
        //            opts.FilePath, opts.CredentialsFilePath),
        //        (OptionsWithContext opts) => RecognizeWithContext(opts.FilePath, ReadPhrases()),
        //        errs => 1);
        //}
    }

}
