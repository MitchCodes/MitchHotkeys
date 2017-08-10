using System;
using System.IO;
using System.Reflection;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using MitchHotkeys.Logic.Models;
using VideoLibrary;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class DownloadYouTubeVideoHotkey : Hotkey
    {
        private static string TempFileDirectory { get; set; }
        // extra data 1:
        // extra data 2:
        // extra data 3:
        public override void HotkeyTriggered()
        {
            MainLogic.Instance.InputCallbacks.TextResultRequestCallback("YouTube Video Link", (bool ytCancelled, string ytInput) => {
                if (!ytCancelled) {
                    MainLogic.Instance.InputCallbacks.FileSaveRequestCallback("MP3 File (*.mp3)|*.mp3","Converted File Location", (bool fileLocCancelled, string saveFileLoc) => {
                        if (!fileLocCancelled) {
                            MainLogic.Instance.InputCallbacks.TextResultRequestCallback("Start Time (HH:mm:ss) (leave blank or 0 for beginning)", (bool stCancelled, string startTime) => {
                                if (!stCancelled) {
                                    MainLogic.Instance.InputCallbacks.TextResultRequestCallback("Duration Time (HH:mm:ss) (leave blank or 0 for full)", (bool durTimeCancelled, string durTime) => {
                                        if (!durTimeCancelled) {
                                            string youtubeLink = ytInput;
                                            string saveFileLink = saveFileLoc;
                                            string seekTime = startTime;
                                            string durationTime = durTime;

                                            YouTube youTube = YouTube.Default;
                                            YouTubeVideo video = youTube.GetVideo(youtubeLink);
                                            string saveVideoLink = TempFileDirectory + @"\" + video.FullName;
                                            File.WriteAllBytes(TempFileDirectory + @"\" + video.FullName, video.GetBytes());

                                            Convert(saveVideoLink, saveFileLink, seekTime, durationTime);

                                            if (File.Exists(saveVideoLink)) {
                                                File.Delete(saveVideoLink);
                                            }

                                            MainLogic.Instance.InputCallbacks.DisplayInfoRequestCallback("Finished.");
                                        }
                                    });
                                }
                            });
                        }
                    });
                }
            });
        }

        private void GetTextInputResult(bool cancelled, string input) {
            
        }

        private void Convert(string inputFilePath, string outputFilePath, string seekTime, string durationTime)
        {
            if (File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            var inputFile = new MediaFile { Filename = inputFilePath };
            var outputFile = new MediaFile { Filename = outputFilePath };

            ConversionOptions conversionOptions = new ConversionOptions();

            if (!String.IsNullOrWhiteSpace(seekTime) && seekTime != "0")
            {
                TimeSpan seekTimeTimeSpan;
                if (TimeSpan.TryParse(seekTime, out seekTimeTimeSpan))
                {
                    conversionOptions.Seek = seekTimeTimeSpan;
                }
            }

            if (!String.IsNullOrWhiteSpace(durationTime) && durationTime != "0")
            {
                TimeSpan durationTimeTimeSpan;
                if (TimeSpan.TryParse(durationTime, out durationTimeTimeSpan))
                {
                    conversionOptions.MaxVideoDuration = durationTimeTimeSpan;
                }
            }

            using (Engine engine = new Engine())
            {
                engine.Convert(inputFile, outputFile, conversionOptions);
            }
            
        }


        public override void Load()
        {
            if (TempFileDirectory == null)
            {
                TempFileDirectory = "";
                lock (TempFileDirectory)
                {
                    string assemblyFileFolder = Path.GetDirectoryName((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
                    string ytdlFolder = assemblyFileFolder + @"\" + "ytdl";
                    if (!Directory.Exists(ytdlFolder))
                    {
                        Directory.CreateDirectory(ytdlFolder);
                    }
                    TempFileDirectory = assemblyFileFolder + @"\" + "ytdl" + @"\" + "temp";
                    if (!Directory.Exists(TempFileDirectory))
                    {
                        Directory.CreateDirectory(TempFileDirectory);
                    }
                }
            }
            
        }

        public override void Dispose()
        {

        }
    }
}
