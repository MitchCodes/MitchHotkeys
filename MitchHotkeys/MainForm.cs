using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.MiddleTier;
using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.Misc;
using System.Windows.Forms.Integration;

namespace MitchHotkeys
{
    public partial class MainForm : Form
    {
        private MainLogic ml = null;
        private bool GroupLoaded { get; set; }
        public MainForm()
        {
            InitializeComponent();
            GroupLoaded = false;
            btnConfigure.Enabled = false;
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                //GlobalHotkeyService.KeyModifier modifier = (GlobalHotkeyService.KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int key = (((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                int modifier = ((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.


                MainLogic.Instance.TriggerHotkey(key, modifier, id);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ml = MainLogic.Instance;
            ml.MainFormHandle = this.Handle;
            ml.DoStartup();
            cbGroups.DataSource = ml.HotkeyGroups;
            cbGroups.DisplayMember = "Name";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ml.DoCleanup();
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            if (GroupLoaded) {
                if (Constants.UseXaml) {
                    //GroupConfiguration grpConfig = new GroupConfiguration(MainLogic.Instance.Hotkeys);
                } else {
                    HotkeyConfigurationForm configForm = new HotkeyConfigurationForm(MainLogic.Instance.Hotkeys);
                    DialogResult result = configForm.ShowDialog();
                }
                
                
            }
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            int highestId = 0;
            foreach (HotkeyGroup currentGroup in ml.HotkeyGroups)
            {
                if (currentGroup.Id > highestId)
                {
                    highestId = currentGroup.Id;
                }
            }
            int newId = highestId + 1;
            GroupEditForm groupEditForm = new GroupEditForm(newId);
            if (groupEditForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool found = ml.HotkeyGroups.Any(currentGroup => currentGroup.Name == groupEditForm.Group.Name);

                if (!found)
                {
                    ml.HotkeyGroups.Add(groupEditForm.Group);
                    ml.UpdateHotkeyGroups();
                }
            }
        }

        private void btnLoadGroup_Click(object sender, EventArgs e)
        {
            ml.UnloadAllCurrentHotkeys();
            HotkeyGroup selectedGroup = (HotkeyGroup)cbGroups.SelectedItem;
            ml.GetHotkeysForGroup(selectedGroup);
            GroupLoaded = true;
            btnConfigure.Enabled = true;
            btnConfigure.Text = "Configure " + selectedGroup.Name;
            ml.CurrentGroup = selectedGroup;
            lblStatus.Text = "Loaded hotkeys for " + selectedGroup.Name;
        }
    }
}
