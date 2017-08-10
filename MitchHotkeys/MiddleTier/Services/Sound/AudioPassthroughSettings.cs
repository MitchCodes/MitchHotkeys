using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models.Sound;
using MitchHotkeys.MiddleTier.Services.HotkeyTypes;

namespace MitchHotkeys.MiddleTier.Services.Sound {
    public class AudioPassthroughSettings {
        public HotkeyAudioDevice InputDevice { get; set; }
        public HotkeyAudioDevice OutputDevice { get; set; }
        public AutoTuneSettings AutoTuneSettings { get; set; }
        public DevicePassthroughHotkey AssociatedHotkey { get; set; }
        public AudioPassthrough AudioPassthrough { get; set; }
    }
}
