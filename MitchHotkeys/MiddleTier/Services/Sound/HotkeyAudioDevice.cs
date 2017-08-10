using MitchHotkeys.MiddleTier.Model.Sound;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.MiddleTier.Services.Sound
{
    public class HotkeyAudioDevice
    {
        private int _audioDeviceId;
        private string _audioDeviceName;
        private AudioPlaybackEngine _associatedEngine;
        private List<AudioRecorder> _recorders;
        private List<AudioPassthroughSettings> _passthroughs;


        public HotkeyAudioDevice()
        {
            Recorders = new List<AudioRecorder>();
            Passthroughs = new List<AudioPassthroughSettings>();
        }

        public int AudioDeviceId
        {
            get { return _audioDeviceId; }
            set { _audioDeviceId = value; }
        }

        public string AudioDeviceName
        {
            get { return _audioDeviceName; }
            set { _audioDeviceName = value; }
        }

        public AudioPlaybackEngine AssociatedEngine
        {
            get
            {
                if (_associatedEngine == null)
                {
                    _associatedEngine = new AudioPlaybackEngine(44100, 2, AudioDeviceId);
                }
                return _associatedEngine;
            }
        }

        public List<AudioRecorder> Recorders
        {
            get { return _recorders; }
            set { _recorders = value; }
        }

        public List<AudioPassthroughSettings> Passthroughs
        {
            get { return _passthroughs; }
            set { _passthroughs = value; }
        }
    }
}
