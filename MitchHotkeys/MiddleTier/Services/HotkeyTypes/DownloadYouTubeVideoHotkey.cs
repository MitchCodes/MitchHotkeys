using System;
using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.UI.Services;
using MitchHotkeys.UI.Model.HotkeyInputForms;
using VideoLibrary;
using System.Reflection;
using System.IO;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class DownloadYouTubeVideoHotkey : Hotkey
    {
        private static string TempFileDirectory { get; set; }
        // extra data 1:
        // extra data 2:
        // extra data 3:
        public override void HotkeyTriggered()
        {
            TextInputResult youtubeLinkResult = HotkeyInputService.Instance.GetTextInput("YouTube Video Link");
            if (!youtubeLinkResult.Cancelled)
            {
                TextInputResult saveFileResult = HotkeyInputService.Instance.GetFileSaveInput("MP3 File (*.mp3)|*.mp3", "Converted File Location");
                if (!saveFileResult.Cancelled)
                {
                    TextInputResult seekTimeResult = HotkeyInputService.Instance.GetTextInput("Start Time (HH:mm:ss) (leave blank or 0 for beginning)");
                    if (!seekTimeResult.Cancelled)
                    {
                        TextInputResult durationTimeResult = HotkeyInputService.Instance.GetTextInput("Duration Time (HH:mm:ss) (leave blank or 0 for full)");
                        if (!durationTimeResult.Cancelled)
                        {
                            string youtubeLink = youtubeLinkResult.Input;
                            string saveFileLink = saveFileResult.Input;
                            string seekTime = seekTimeResult.Input;
                            string durationTime = durationTimeResult.Input;

                            YouTube youTube = YouTube.Default;
                            YouTubeVideo video = youTube.GetVideo(youtubeLink);
                            string saveVideoLink = TempFileDirectory + @"\" + video.FullName;
                            File.WriteAllBytes(TempFileDirectory + @"\" + video.FullName, video.GetBytes());

                            Convert(saveVideoLink, saveFileLink, seekTime, durationTime);

                            if (File.Exists(saveVideoLink))
                            {
                                File.Delete(saveVideoLink);
                            }

                            HotkeyInputService.Instance.DisplayDialogInfo("Finished.");
                        }
                    }
                }
            }
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
