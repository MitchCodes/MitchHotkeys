using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.UI.Model.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.UI.Services
{
    public class ValidationService
    {
        private static ValidationService _instance;

        public static ValidationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ValidationService();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private ValidationService()
        {

        }


        public ValidationResult Validate(Hotkey hotkey)
        {
            ValidationResult result = new ValidationResult();

            result.Status = ValidationResultStatus.Success; // success until error

            try
            {
                if (hotkey.KeyEnum == System.Windows.Forms.Keys.None)
                {
                    result.Errors.Add(new ValidationException("Need to choose a key for the hotkey"));
                    result.Status = ValidationResultStatus.Error;
                }

                switch (hotkey.CommandEnum)
                {
                    case HotkeyTypeEnum.ChangeAudioVolume:
                    case HotkeyTypeEnum.StepUpAudioVolume:
                    case HotkeyTypeEnum.StepDownAudioVolume:
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Output);
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData3, result, AudioDeviceType.Output);
                        }
                        ValidateAudioVolumeHotkeys(hotkey, result);
                        break;
                    case HotkeyTypeEnum.DownloadYouTubeVideo:
                    case HotkeyTypeEnum.StopAudioAllDevices:
                        ValidateHotkeysWithNoData(hotkey, result);
                        break;
                    case HotkeyTypeEnum.PlayAudio:
                    case HotkeyTypeEnum.ToggleAudio:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData1) || !File.Exists(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("Need to have a valid file as the audio file"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            if (new System.IO.FileInfo(hotkey.ExtraData1).Length > 10485760)
                            {
                                result.Errors.Add(new ValidationException("File sizes for audio cannot exceed 10mb"));
                                result.Status = ValidationResultStatus.Error;
                            }
                        }
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter at least the first audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Output);
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData3, result, AudioDeviceType.Output);
                        }
                        if (hotkey.AdditionalExtraData != null && hotkey.AdditionalExtraData.ContainsKey((int)HotkeyAdditionalDataType.DeviceThree) && !String.IsNullOrWhiteSpace(hotkey.AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]))
                        {
                            ValidateStringIsDeviceName(hotkey.AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree], result, AudioDeviceType.Output);
                        }
                        break;
                    case HotkeyTypeEnum.RunBatchSilently:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData1) || !File.Exists(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("Need to have a valid file as the batch file"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        break;
                    case HotkeyTypeEnum.RunFile:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData1) || !File.Exists(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("Need to have a valid file as the file to run"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        break;
                    case HotkeyTypeEnum.StopAudioDevice:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Output);
                        }
                        break;
                    case HotkeyTypeEnum.StartRecordingInputDevice:
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("No need to enter the data for ExtraData1"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Input);
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            int temp = 0;
                            if (!int.TryParse(hotkey.ExtraData3, out temp))
                            {
                                result.Errors.Add(new ValidationException("You must enter a number in the seconds to record"));
                                result.Status = ValidationResultStatus.Error;
                                break;
                            }
                            if (temp < 2)
                            {
                                result.Errors.Add(new ValidationException("You must record at least 2 seconds"));
                                result.Status = ValidationResultStatus.Error;
                            }
                        }
                        break;
                    case HotkeyTypeEnum.StopRecordingInputDevice:
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("No need to enter the data for ExtraData1"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Input);
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            result.Errors.Add(new ValidationException("No need to enter the data for ExtraData3"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        break;
                    case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("Need to enter in the path for the wav file to save to"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(hotkey.ExtraData1)))
                            {
                                result.Errors.Add(new ValidationException("Invalid directory to save the wav file to"));
                                result.Status = ValidationResultStatus.Error;
                            }
                            if (Path.GetExtension(hotkey.ExtraData1).ToLower() != ".wav")
                            {
                                result.Errors.Add(new ValidationException("Must save the file as a wav file"));
                                result.Status = ValidationResultStatus.Error;
                            }
                        }
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Input);
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            result.Errors.Add(new ValidationException("No need to enter the data for ExtraData3"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        break;
                    case HotkeyTypeEnum.SaveInputDeviceRecordingToMemory:
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("No need to enter data in for ExtraData1"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            result.Errors.Add(new ValidationException("No need to enter data in for ExtraData3"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary input audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Input);
                        }
                        break;
                    case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary input audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData1, result, AudioDeviceType.Input);
                        }

                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary output audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Output);
                        }

                        if (!String.IsNullOrWhiteSpace(hotkey.ExtraData3))
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData3, result, AudioDeviceType.Output);
                        }
                        break;
                    case HotkeyTypeEnum.DevicePassthrough:
                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData1))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary input audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData1, result, AudioDeviceType.Input);
                        }

                        if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
                        {
                            result.Errors.Add(new ValidationException("Need to enter the primary output audio device"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        else
                        {
                            ValidateStringIsDeviceName(hotkey.ExtraData2, result, AudioDeviceType.Output);
                        }

                        string startOnText = hotkey.GetAdditionalData(HotkeyAdditionalDataType.ExtraData4);
                        if (String.IsNullOrWhiteSpace(startOnText))
                        {
                            result.Errors.Add(new ValidationException("Need to enter true or false for if it should start on"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        if (startOnText != "true" && startOnText != "false")
                        {
                            result.Errors.Add(new ValidationException("Need to enter either true or false in lowercase for whether it should start on"));
                            result.Status = ValidationResultStatus.Error;
                        }
                        break;
                }
            } catch (Exception e)
            {
                result.Status = ValidationResultStatus.Error;
                ValidationException ex = new ValidationException(e.Message);
                result.Errors.Add(ex);
            }

            return result;
        }

        #region private functions
        private void ValidateAudioVolumeHotkeys(Hotkey hotkey, ValidationResult result)
        {
            float audioChange = 0.0f;
            if (!float.TryParse(hotkey.ExtraData1, out audioChange))
            {
                result.Errors.Add(new ValidationException("Cannot convert " + hotkey.ExtraData1 + " to a float. Must be a valid number"));
                result.Status = ValidationResultStatus.Error;
            }

            switch (hotkey.CommandEnum)
            {
                case HotkeyTypeEnum.ChangeAudioVolume:
                    if (audioChange < 0)
                    {
                        result.Errors.Add(new ValidationException("Cannot change volume to less than 0"));
                        result.Status = ValidationResultStatus.Error;
                    }
                    if (audioChange > 3)
                    {
                        result.Errors.Add(new ValidationException("Cannot change volume to more than 3 (300%)"));
                        result.Status = ValidationResultStatus.Error;
                    }
                    break;
                case HotkeyTypeEnum.StepUpAudioVolume:
                case HotkeyTypeEnum.StepDownAudioVolume:
                    if (audioChange < -1.5)
                    {
                        result.Errors.Add(new ValidationException("Cannot change volume in a step more than 150%"));
                        result.Status = ValidationResultStatus.Error;
                    }
                    if (audioChange > 1.5)
                    {
                        result.Errors.Add(new ValidationException("Cannot change volume in a step more than 150%"));
                        result.Status = ValidationResultStatus.Error;
                    }
                    break;
            }

            if (String.IsNullOrWhiteSpace(hotkey.ExtraData2))
            {
                result.Errors.Add(new ValidationException("Must select at least the first audio device to affect"));
                result.Status = ValidationResultStatus.Error;
            }
        }


        private void ValidateHotkeysWithNoData(Hotkey hotkey, ValidationResult result)
        {
            if (!String.IsNullOrEmpty(hotkey.ExtraData1) || !String.IsNullOrEmpty(hotkey.ExtraData2) || !String.IsNullOrEmpty(hotkey.ExtraData3) || hotkey.AdditionalExtraData.Count > 0)
            {
                result.Errors.Add(new ValidationException("This hotkey does not need any extra data. Please delete any extra data"));
                result.Status = ValidationResultStatus.Error;
            }
        }

        private void ValidateStringIsDeviceName(string deviceName, ValidationResult result, AudioDeviceType deviceType = AudioDeviceType.Both)
        {
            bool deviceExists = MainAudio.Instance.DeviceExists(deviceName, deviceType);

            if (!deviceExists)
            {
                result.Errors.Add(new ValidationException("This selected device does not exist"));
                result.Status = ValidationResultStatus.Error;
            }
        }
        #endregion

    }
}
