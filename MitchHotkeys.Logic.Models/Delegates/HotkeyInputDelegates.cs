using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.Logic.Models.Delegates {
    public delegate void TextInputRequestDelegate(string formText, TextInputResultDelegate resultCallback);
    public delegate void FileSaveInputRequestDelegate(string filter, string formText, TextInputResultDelegate resultCallback);
    public delegate void DisplayInfoRequest(string info);
    public delegate void TextInputResultDelegate(bool cancelled, string input);
}
