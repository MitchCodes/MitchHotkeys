using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.MiddleTier.Model
{
    public interface IHotkeyEvents
    {
        void HotkeyTriggered();
        void Load();
        void Dispose();
    }
}
