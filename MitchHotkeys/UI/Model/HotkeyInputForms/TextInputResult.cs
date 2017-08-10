using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.UI.Model.HotkeyInputForms
{
    public class TextInputResult
    {
        public bool Cancelled { get; set; }
        public string Input { get; set; }
    }
}
