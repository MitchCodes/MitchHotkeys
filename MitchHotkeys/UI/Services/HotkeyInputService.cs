using MitchHotkeys.UI.HotkeyInputForms;
using MitchHotkeys.UI.Model.HotkeyInputForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.Logic.Models;

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
