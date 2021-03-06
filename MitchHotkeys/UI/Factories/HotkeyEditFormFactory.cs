﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.UI.CustomHotkeyEditForm;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.UI.Factories
{
    public class HotkeyEditFormFactory
    {
        public static Form GetHotkeyEditForm(int command, Hotkey hotkey = null, bool bulkEdit = false)
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
                case HotkeyTypeEnum.ESpeak:
                    return new HotkeyEditAudioForm(hotkey, bulkEdit);
                case HotkeyTypeEnum.StartRecordingInputDevice:
                case HotkeyTypeEnum.StopRecordingInputDevice:
                case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                case HotkeyTypeEnum.SaveInputDeviceRecordingToMemory:
                    return new HotkeyEditAudioInputForm(hotkey, bulkEdit);
                case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                case HotkeyTypeEnum.DevicePassthrough:
                    return new HotkeyEditAudioInputOutputForm(hotkey, bulkEdit);
                case HotkeyTypeEnum.RunFile:
                case HotkeyTypeEnum.RunBatchSilently:
                    return new HotkeyEditFileBrowseForm(hotkey);
                case HotkeyTypeEnum.AutoTuneDevicePassthrough:
                    return new HotkeyEditAudioAutoTunePassthroughForm(hotkey);
            }
            return new HotkeyEditForm(hotkey, bulkEdit);
        }
    }
}
