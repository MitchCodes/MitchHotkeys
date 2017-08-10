using MitchHotkeys.UI.HotkeyInputForms;
using MitchHotkeys.UI.Model.HotkeyInputForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.Logic;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Models.Delegates;

namespace MitchHotkeys.UI.Services
{
    public class HotkeyInputService
    {
        private static HotkeyInputService _instance;

        public static HotkeyInputService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HotkeyInputService();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        private HotkeyInputService()
        {
            MainLogic.Instance.InputCallbacks.TextResultRequestCallback += RequestTextInput;
            MainLogic.Instance.InputCallbacks.FileSaveRequestCallback += RequestFileSaveInput;
            MainLogic.Instance.InputCallbacks.DisplayInfoRequestCallback += RequestDisplayInfo;
        }

        public void RequestTextInput(string formText, TextInputResultDelegate result) {
            TextInputResult userResult = GetTextInput(formText);
            result(userResult.Cancelled, userResult.Input);
        }

        public void RequestFileSaveInput(string filter, string formText, TextInputResultDelegate result) {
            TextInputResult userResult = GetFileSaveInput(filter, formText);
            result(userResult.Cancelled, userResult.Input);
        }

        public void RequestDisplayInfo(string info) {
            DisplayDialogInfo(info);
        }


        public TextInputResult GetTextInput(string formText = "")
        {
            TextInputResult result = new TextInputResult();
            TextInput textInputForm = new TextInput();
            if (!string.IsNullOrWhiteSpace(formText))
            {
                textInputForm.Text = formText;
            }
            DialogResult formResult = textInputForm.ShowDialog();
            if (formResult == DialogResult.Cancel)
            {
                result.Cancelled = true;
                result.Input = "";
            }
            else
            {
                result.Cancelled = false;
                result.Input = textInputForm.InputText;
            }

            return result;
        }

        public TextInputResult GetFileSaveInput(string filter = "All Files (*.*)|*.*", string formText = "")
        {
            TextInputResult result = new TextInputResult();
            FileSaveInput fileSaveForm = new FileSaveInput();
            if (!string.IsNullOrWhiteSpace(formText))
            {
                fileSaveForm.Text = formText;
            }
            fileSaveForm.saveFileDialog1.Filter = filter;
            DialogResult formResult = fileSaveForm.ShowDialog();
            if (formResult == DialogResult.Cancel)
            {
                result.Cancelled = true;
                result.Input = "";
            }
            else
            {
                result.Cancelled = false;
                result.Input = fileSaveForm.InputText;
            }

            return result;
        }

        public void DisplayDialogInfo(string info)
        {
            DialogInfo dialogInfoForm = new DialogInfo();
            dialogInfoForm.label.Text = info;
            dialogInfoForm.ShowDialog();
        }
    }
}
