﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.MiddleTier.Factories;
using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.Misc;
using MitchHotkeys.UI.Model;
using MitchHotkeys.UI.Model.Validation;
using MitchHotkeys.UI.Services;

namespace MitchHotkeys
{
    public partial class HotkeyEditForm : Form, IHotkeyForm
    {
        public Hotkey Hotkey { get; set; }

        public HotkeyEditForm()
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(GlobalHotkeyService.KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));
        }

        public HotkeyEditForm(Hotkey hotkey)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(GlobalHotkeyService.KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            cbCommand.SelectedItem = (HotkeyTypeEnum) hotkey.Command;
            cbModifier.SelectedItem = (GlobalHotkeyService.KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;
            tbExtraData1.Text = hotkey.ExtraData1;
            tbExtraData2.Text = hotkey.ExtraData2;
            tbExtraData3.Text = hotkey.ExtraData3;

            ChangeLabels(hotkey);
            ChangeEnabled(hotkey);
        }

        private void HotkeyEditForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int command = (int)((HotkeyTypeEnum)cbCommand.SelectedValue);
            Hotkey tempHotkey = HotkeyTypeFactory.GetHotkeyType(command);
            tempHotkey.Command = command;
            tempHotkey.Modifier = (int)((GlobalHotkeyService.KeyModifier)cbModifier.SelectedValue);
            tempHotkey.Key = (int)((Keys)cbKey.SelectedValue);
            tempHotkey.ExtraData1 = tbExtraData1.Text;
            tempHotkey.ExtraData2 = tbExtraData2.Text;
            tempHotkey.ExtraData3 = tbExtraData3.Text;
            ValidationResult result = Validate(tempHotkey);
            if (result.HasErrors())
            {
                MessageBox.Show("Errors: " + result.CommaDelimErrors());
            }
            else
            {
                Hotkey = tempHotkey;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void ChangeLabels(Hotkey hotkey)
        {
            switch ((HotkeyTypeEnum)hotkey.Command)
            {
                case HotkeyTypeEnum.DownloadYouTubeVideo:
                    lblED1.Text = "";
                    lblED2.Text = "";
                    lblED3.Text = "";
                    break;
            }
        }

        private void ChangeEnabled(Hotkey hotkey)
        {
            switch ((HotkeyTypeEnum)hotkey.Command)
            {
                case HotkeyTypeEnum.DownloadYouTubeVideo:
                    tbExtraData1.Enabled = false;
                    tbExtraData2.Enabled = false;
                    tbExtraData3.Enabled = false;
                    break;
            }
        }

        public ValidationResult Validate(Hotkey hotkey)
        {
            return ValidationService.Instance.Validate(hotkey);
        }
    }
}