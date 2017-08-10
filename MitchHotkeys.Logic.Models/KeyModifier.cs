using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.Logic.Models {
    public enum KeyModifier {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        WinKey = 8,
        CtrlAlt = 3,
        CtrlShift = 6,
        AltShift = 5,
        CtrlWinKey = 10,
        CtrlAltShift = 7
    }
}
