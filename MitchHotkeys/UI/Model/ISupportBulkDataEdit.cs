using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.UI.Model
{
    public interface ISupportBulkDataEdit
    {
        bool EditHotkeyData1 { get; set; }
        bool EditHotkeyData2 { get; set; }
        bool EditHotkeyData3 { get; set; }
        bool EditHotkeyData4 { get; set; }
    }
}
