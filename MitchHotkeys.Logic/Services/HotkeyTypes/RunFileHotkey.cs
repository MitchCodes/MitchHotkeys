using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class RunFileHotkey : Hotkey
    {
        // extra data 1: file path
        // extra data 2: command line args
        public override void HotkeyTriggered()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = ExtraData1;
            proc.StartInfo.Arguments = ExtraData2;
            proc.Start();
        }

        
        public override void Load()
        {
        }

        public override void Dispose()
        {
        }
    }
}
