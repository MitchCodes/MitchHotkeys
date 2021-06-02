using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models.Delegates;

namespace MitchHotkeys.Logic.Models {
    public class HotkeyInputCallbacks {

        public TextInputRequestDelegate TextResultRequestCallback { get; set; }
        public TextInputRequestDelegate TextResultRequestOnTopCallback { get; set; }
        public FileSaveInputRequestDelegate FileSaveRequestCallback { get; set; }
        public DisplayInfoRequest DisplayInfoRequestCallback { get; set; }
        public ShowOnTop ShowMainFormOnTop { get; set; }
        public ShowOnTop StopMainFormOnTop { get; set; }
        public GetCurrentForegroundWindowDelegate GetForegroundWindowCallback { get; set; }
        public SetCurrentForegroundWindowDelegate SetForegroundWindowCallback { get; set; }
        public GetMainForm GetMainForm { get; set; }

        public HotkeyInputCallbacks() {
        }


    }
}
