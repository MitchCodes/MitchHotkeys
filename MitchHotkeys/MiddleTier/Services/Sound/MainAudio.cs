using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier.Services.Sound
{


    public enum AudioDeviceType
    {
        Output = 0,
        Input = 1,
        Both = 2
    }
    public class MainAudio
    {

        private static MainAudio instance;

        private MainAudio()
        {
        }

        public static MainAudio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainAudio();
                    GetDevices();
                }
                return instance;
            }
        }

        public List<HotkeyAudioDevice> AudioOutputDevices { get; set; }
        public List<HotkeyAudioDevice> AudioInputDevices { get; set; }

        public static void GetDevices()
        {
            List<HotkeyAudioDevice> audioOutputDevicesList = new List<HotkeyAudioDevice>();
            for (int deviceId = 0; deviceId < WaveOut.DeviceCount; deviceId++)
            {
                WaveOutCapabilities capabilities = WaveOut.GetCapabilities(deviceId);
                HotkeyAudioDevice audioDevice = new HotkeyAudioDevice();
                audioDevice.AudioDeviceId = deviceId;
                audioDevice.AudioDeviceName = capabilities.ProductName;
                audioOutputDevicesList.Add(audioDevice);
            }
            Instance.AudioOutputDevices = audioOutputDevicesList;

            List<HotkeyAudioDevice> audioInputDevicesList = new List<HotkeyAudioDevice>();
            for (int deviceId = 0; deviceId < WaveIn.DeviceCount; deviceId++)
            {
                WaveInCapabilities capabilities = WaveIn.GetCapabilities(deviceId);
                HotkeyAudioDevice audioDevice = new HotkeyAudioDevice();
                audioDevice.AudioDeviceId = deviceId;
                audioDevice.AudioDeviceName = capabilities.ProductName;
                audioInputDevicesList.Add(audioDevice);
            }
            Instance.AudioInputDevices = audioInputDevicesList;
        }

        public HotkeyAudioDevice GetDevice(string deviceName, AudioDeviceType deviceType = AudioDeviceType.Output)
        {
            if (deviceType == AudioDeviceType.Output)
            {
                return AudioOutputDevices.FirstOrDefault(audioDevice => audioDevice.AudioDeviceName.Equals(deviceName));
            }
            else if (deviceType == AudioDeviceType.Input)
            {
                return AudioInputDevices.FirstOrDefault(audioDevice => audioDevice.AudioDeviceName.Equals(deviceName));
            }
            else if (deviceType == AudioDeviceType.Both)
            {
                throw new Exception("Cannot use device type of both to get one device");
            }
            return null;
        }

        public bool DeviceExists(string deviceName, AudioDeviceType deviceType = AudioDeviceType.Both)
        {
            bool hasDevice = false;
            HotkeyAudioDevice device = null;

            if ((deviceType == AudioDeviceType.Output || deviceType == AudioDeviceType.Both) && !hasDevice)
            {
                device = GetDevice(deviceName, AudioDeviceType.Output);
                if (device != null)
                {
                    hasDevice = true;
                }
            }
            

            if ((deviceType == AudioDeviceType.Input || deviceType == AudioDeviceType.Both) && !hasDevice)
            {
                device = GetDevice(deviceName, AudioDeviceType.Input);
                if (device != null)
                {
                    hasDevice = true;
                }
            }

            return hasDevice;
        }
    }
}
