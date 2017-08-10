using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.UI.WPF.ViewModels {
    public class HotkeyViewModel {
        public int Modifier { get; set; }
        public int Key { get; set; }
        public int Command { get; set; }
        public string ExtraData1 { get; set; }
        public string ExtraData2 { get; set; }
        public string ExtraData3 { get; set; }
        public Dictionary<int, string> AdditionalExtraData { get; set; }
        public string Description { get; set; }
    }
}
