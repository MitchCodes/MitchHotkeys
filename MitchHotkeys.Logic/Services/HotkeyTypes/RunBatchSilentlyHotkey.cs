using System.Diagnostics;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class RunBatchSilentlyHotkey : Hotkey
    {
        // extra data 1: file path
        public override void HotkeyTriggered()
        {
            Process myProcess = new Process();
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "cmd.exe";
            myProcess.StartInfo.Arguments = "/c " + ExtraData1;
            myProcess.EnableRaisingEvents = true;
            //myProcess.Exited += new EventHandler(process_Exited);
            myProcess.Start();
            myProcess.WaitForExit();
            int ExitCode = myProcess.ExitCode;
        }

        
        public override void Load()
        {
        }

        public override void Dispose()
        {
        }
    }
}
