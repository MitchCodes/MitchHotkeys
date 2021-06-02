using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class ESpeakHotkey : Hotkey
    {
        private HotkeyAudioDevice audioDevice;
        private HotkeyAudioDevice audioDeviceTwo;
        private HotkeyAudioDevice audioDeviceThree;
        private NAudio.Wave.ISampleProvider provider;
        private NAudio.Wave.ISampleProvider providerTwo;
        private NAudio.Wave.ISampleProvider providerThree;
        private SpeechSynthesizer speechSynthesizer;
        private List<string> files;
        // extra data 1: file path
        // extra data 2: device name
        // extra data 3: second device name
        public override void HotkeyTriggered()
        {
            if (audioDevice == null)
            {
                audioDevice = MainAudio.Instance.GetDevice(ExtraData2);
            }

            MainLogic.Instance.InputCallbacks.TextResultRequestOnTopCallback("Text",
                (bool speakCanceled, string speakInput) =>
                {
                    if (!speakCanceled)
                    {
                        try
                        {
                            string fileName = "tts_" + Guid.NewGuid() + ".wav";
                            if (speechSynthesizer == null)
                            {
                                speechSynthesizer = new SpeechSynthesizer();
                            }
                            speechSynthesizer.SetOutputToWaveFile(fileName);
                            speechSynthesizer.Speak(speakInput);
                            try
                            {
                                speechSynthesizer?.Dispose();
                            }
                            catch (Exception) { }
                            speechSynthesizer = null;
                            //var voices = speechSynthesizer.GetInstalledVoices();

                            files.Add(fileName);

                            CachedSound sound = new CachedSound(fileName);
                            provider = audioDevice.AssociatedEngine.PlaySound(sound);

                            if (!String.IsNullOrWhiteSpace(ExtraData3))
                            {
                                if (audioDeviceTwo == null)
                                {
                                    audioDeviceTwo = MainAudio.Instance.GetDevice(ExtraData3);
                                }

                                providerTwo = audioDeviceTwo.AssociatedEngine.PlaySound(sound);
                            }

                            if (AdditionalExtraData != null && AdditionalExtraData.ContainsKey((int)HotkeyAdditionalDataType.DeviceThree) && !String.IsNullOrWhiteSpace(AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]))
                            {
                                if (audioDeviceThree == null)
                                {
                                    audioDeviceThree = MainAudio.Instance.GetDevice(AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]);
                                }

                                providerThree = audioDeviceThree.AssociatedEngine.PlaySound(sound);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                });

        }


        public override void Load()
        {
            files = new List<string>();
        }

        public override void Dispose()
        {
            if (files != null)
            {
                foreach (string file in files)
                {
                    try
                    {
                        if (File.Exists(file))
                        {
                            File.Delete(file);
                        }
                    } catch (Exception) { }
                }
            }

            if (audioDevice != null && provider != null)
            {
                audioDevice.AssociatedEngine.StopSound(provider);
            }

            if (audioDeviceTwo != null && providerTwo != null)
            {
                audioDeviceTwo.AssociatedEngine.StopSound(providerTwo);
            }

            if (audioDeviceThree != null && providerThree != null)
            {
                audioDeviceThree.AssociatedEngine.StopSound(providerThree);
            }
        }
    }
}
