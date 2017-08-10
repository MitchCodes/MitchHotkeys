using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.HotkeyTypes;
using MitchHotkeys.UI.CustomHotkeyEditForm;

namespace MitchHotkeys.UI.Factories
{
    public class HotkeyEditFormFactory
    {
        public static Form GetHotkeyEditForm(int command, Hotkey hotkey = null)
        {
            switch ((HotkeyTypeEnum)command)
            {
                case HotkeyTypeEnum.PlayAudio:
                case HotkeyTypeEnum.StopAudioDevice:
                case HotkeyTypeEnum.ToggleAudio:
                case HotkeyTypeEnum.ChangeAudioVolume:
                case HotkeyTypeEnum.StepUpAudioVolume:
                case HotkeyTypeEnum.StepDownAudioVolume:
                case HotkeyTypeEnum.StopAudioAllDevices:
                    return new HotkeyEditAudioForm(hotkey);
                case HotkeyTypeEnum.StartRecordingInputDevice:
                case HotkeyTypeEnum.StopRecordingInputDevice:
                case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                case HotkeyTypeEnum.SaveInputDeviceRecordingToMemory:
                    return new HotkeyEditAudioInputForm(hotkey);
                case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                case HotkeyTypeEnum.DevicePassthrough:
                    return new HotkeyEditAudioInputOutputForm(hotkey);
                case HotkeyTypeEnum.RunFile:
                case HotkeyTypeEnum.RunBatchSilently:
                    return new HotkeyEditFileBrowseForm(hotkey);
                case HotkeyTypeEnum.AutoTuneDevicePassthrough:
                    return new HotkeyEditAudioAutoTunePassthroughForm(hotkey);
            }
            return new HotkeyEditForm(hotkey);
        }
    }
}
