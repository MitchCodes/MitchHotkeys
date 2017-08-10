﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models.Delegates;

namespace MitchHotkeys.Logic.Models {
    public class HotkeyInputCallbacks {

        public TextInputRequestDelegate TextResultRequestCallback { get; set; }
        public FileSaveInputRequestDelegate FileSaveRequestCallback { get; set; }
        public DisplayInfoRequest DisplayInfoRequestCallback { get; set; }

        public HotkeyInputCallbacks() {
        }


    }
}
