namespace MitchHotkeys.Logic.Models
{
    public enum HotkeyTypeEnum
    {
        PlayAudio = 0,
        StopAudioDevice = 1,
        StopAudioAllDevices = 2,
        ToggleAudio = 3,
        RunFile = 4,
        RunBatchSilently = 5,
        ChangeAudioVolume = 6,
        StepUpAudioVolume = 7,
        StepDownAudioVolume = 8,
        DownloadYouTubeVideo = 9,
        StartRecordingInputDevice = 10,
        StopRecordingInputDevice = 11,
        SaveInputDeviceRecordingToFile = 12,
        SaveInputDeviceRecordingToMemory = 13,
        PlayInputDeviceRecordingFromMemory = 14,
        AutoTuneDevicePassthrough = 15,
        DevicePassthrough = 16
    }
}
