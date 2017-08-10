using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.HotkeyTypes;

namespace MitchHotkeys.Logic.Factories
{
    public class HotkeyTypeFactory
    {
        public static Hotkey GetHotkeyType(int command)
        {
            switch ((HotkeyTypeEnum)command)
            {
                case HotkeyTypeEnum.PlayAudio:
                    return new PlayAudioHotkey();
                case HotkeyTypeEnum.StopAudioDevice:
                    return new StopAudioDeviceHotkey();
                case HotkeyTypeEnum.StopAudioAllDevices:
                    return new StopAudioAllDevicesHotkey();
                case HotkeyTypeEnum.ToggleAudio:
                    return new ToggleAudioHotkey();
                case HotkeyTypeEnum.RunFile:
                    return new RunFileHotkey();
                case HotkeyTypeEnum.RunBatchSilently:
                    return new RunBatchSilentlyHotkey();
                case HotkeyTypeEnum.ChangeAudioVolume:
                    return new ChangeAudioVolumeHotkey();
                case HotkeyTypeEnum.StepDownAudioVolume:
                    return new StepDownAudioVolumeHotkey();
                case HotkeyTypeEnum.StepUpAudioVolume:
                    return new StepUpAudioVolumeHotkey();
                case HotkeyTypeEnum.DownloadYouTubeVideo:
                    return new DownloadYouTubeVideoHotkey();
                case HotkeyTypeEnum.StartRecordingInputDevice:
                    return new StartRecordingInputDeviceHotkey();
                case HotkeyTypeEnum.StopRecordingInputDevice:
                    return new StopRecordingInputDeviceHotkey();
                case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                    return new SaveInputDeviceRecordingToFile();
                case HotkeyTypeEnum.SaveInputDeviceRecordingToMemory:
                    return new SaveInputDeviceRecordingToMemory();
                case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                    return new PlayInputDeviceRecordingFromMemory();
                case HotkeyTypeEnum.AutoTuneDevicePassthrough:
                    return new AutoTuneDevicePassthroughHotkey();
                case HotkeyTypeEnum.DevicePassthrough:
                    return new DevicePassthroughHotkey();
            }
            return new Hotkey();
        }
    }
}
