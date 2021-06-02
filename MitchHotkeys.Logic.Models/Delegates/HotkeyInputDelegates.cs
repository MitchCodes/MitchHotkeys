using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MitchHotkeys.Logic.Models.Delegates {
    public delegate void TextInputRequestDelegate(string formText, TextInputResultDelegate resultCallback);
    public delegate void FileSaveInputRequestDelegate(string filter, string formText, TextInputResultDelegate resultCallback);
    public delegate void DisplayInfoRequest(string info);
    public delegate void ShowOnTop();
    public delegate void TextInputResultDelegate(bool cancelled, string input);

    public delegate IntPtr GetCurrentForegroundWindowDelegate();

    public delegate bool SetCurrentForegroundWindowDelegate(IntPtr hWnd);

    public delegate Form GetMainForm();
}
