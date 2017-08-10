using MitchHotkeys.Logic.Models.Sound;
using MitchHotkeys.Logic.Services.HotkeyTypes;

namespace MitchHotkeys.Logic.Services.Sound {
    public class AudioPassthroughSettings {
        public HotkeyAudioDevice InputDevice { get; set; }
        public HotkeyAudioDevice OutputDevice { get; set; }
        public AutoTuneSettings AutoTuneSettings { get; set; }
        public DevicePassthroughHotkey AssociatedHotkey { get; set; }
        public AudioPassthrough AudioPassthrough { get; set; }
    }
}
