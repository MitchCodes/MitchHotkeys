using MitchHotkeys.MiddleTier.Services.HotkeyTypes;
using MitchHotkeys.MiddleTier.Services.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.MiddleTier.Model.Sound
{
    public class AudioPassthroughSettings
    {
        public HotkeyAudioDevice InputDevice { get; set; }
        public HotkeyAudioDevice OutputDevice { get; set; }
        public AutoTuneSettings AutoTuneSettings { get; set; }
        public DevicePassthroughHotkey AssociatedHotkey { get; set; }
        public AudioPassthrough AudioPassthrough { get; set; }
    }
}
