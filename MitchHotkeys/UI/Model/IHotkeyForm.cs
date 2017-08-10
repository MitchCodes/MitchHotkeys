using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.UI.Model.Validation;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.UI.Model
{
    public interface IHotkeyForm
    {
        Hotkey Hotkey { get; set; }
        ValidationResult Validate(Hotkey hotkey);
    }
}
