using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.Logic;
using MitchHotkeys.Logic.Factories;
using MitchHotkeys.UI.Factories;
using MitchHotkeys.UI.Model;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Misc;

namespace MitchHotkeys
{
    public partial class HotkeyConfigurationForm : Form
    {
        private List<Hotkey> _removedHotkeys = new List<Hotkey>();
        private List<Hotkey> _addedHotkeys = new List<Hotkey>();
        public BindingList<Hotkey> Hotkeys { get; set; }
        public List<int> IDs { get; set; }

        public List<Hotkey> RemovedHotkeys
        {
            get { return _removedHotkeys; }
            set { _removedHotkeys = value; }
        }

        public List<Hotkey> AddedHotkeys
        {
            get { return _addedHotkeys; }
            set { _addedHotkeys = value; }
        }

        public HotkeyConfigurationForm(BindingList<Hotkey> keys)
        {
            InitializeComponent();
            cbAddType.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            SetupDatagrid();
            Hotkeys = keys;
            dgvHotkeys.DataSource = Hotkeys;
            IDs = new List<int>();
            foreach (Hotkey currentHotkey in Hotkeys)
            {
                IDs.Add(currentHotkey.ID);
            }
        }

        private void SetupDatagrid()
        {
            this.dgvHotkeys.DataSource = this.Hotkeys;
            this.dgvHotkeys.AutoGenerateColumns = false;
            this.dgvHotkeys.ReadOnly = true;
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHotkeys.Columns.Clear();
            this.dgvHotkeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "KeyEnum";
            this.dataGridViewTextBoxColumn6.HeaderText = "KeyEnum";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ModifierEnum";
            this.dataGridViewTextBoxColumn5.HeaderText = "ModifierEnum";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "CommandEnum";
            this.dataGridViewTextBoxColumn4.HeaderText = "CommandEnum";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ExtraData1";
            this.dataGridViewTextBoxColumn1.HeaderText = "ExtraData1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ExtraData2";
            this.dataGridViewTextBoxColumn2.HeaderText = "ExtraData2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ExtraData3";
            this.dataGridViewTextBoxColumn3.HeaderText = "ExtraData3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hotkeyBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int command = (int)((HotkeyTypeEnum)cbAddType.SelectedValue);
            Hotkey newHotkey = HotkeyTypeFactory.GetHotkeyType(command);
            newHotkey.Command = command;
            Form hotkeyEdit = HotkeyEditFormFactory.GetHotkeyEditForm(newHotkey.Command, newHotkey);
            IHotkeyForm hotkeyEditConv = null;
            if (hotkeyEdit is IHotkeyForm)
            {
                hotkeyEditConv = (IHotkeyForm)hotkeyEdit;
            }
            else
            {
                throw new Exception("Somehow the form doesn't cast to IHotkeyForm. Developer bad! Bad developer!");
            }
            DialogResult result = hotkeyEdit.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Hotkeys.Add(hotkeyEditConv.Hotkey);
                AddedHotkeys.Add(hotkeyEditConv.Hotkey);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHotkeys.SelectedRows.Count > 0)
            {
                Hotkey selectedHotkey = (Hotkey)dgvHotkeys.SelectedRows[0].DataBoundItem;
                if (selectedHotkey != null)
                {
                    Form hotkeyEdit = HotkeyEditFormFactory.GetHotkeyEditForm(selectedHotkey.Command, selectedHotkey);
                    IHotkeyForm hotkeyEditConv = null;
                    if (hotkeyEdit is IHotkeyForm)
                    {
                        hotkeyEditConv = (IHotkeyForm)hotkeyEdit;
                    }
                    else
                    {
                        throw new Exception("Somehow the form doesn't cast to IHotkeyForm. Developer bad! Bad developer!");
                    }
                    DialogResult result = hotkeyEdit.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        Hotkeys.Remove(selectedHotkey);
                        RemovedHotkeys.Add(selectedHotkey);
                        Hotkeys.Add(hotkeyEditConv.Hotkey);
                        AddedHotkeys.Add(hotkeyEditConv.Hotkey);
                    }
                }
            }
            
        }

        private void HotkeyConfigurationForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void HotkeyConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Hotkey currentHotkey in RemovedHotkeys)
            {
                try
                {
                    currentHotkey.Dispose();
                }
                catch (Exception)
                {
                    // ignored
                }
                
            }
            foreach (int currentInt in IDs)
            {
                GlobalHotkeyService.Instance.UnregisterHotKey(currentInt);
            }
            MainLogic.Instance.UpdateHotkeys();
            foreach (Hotkey currentHotkey in AddedHotkeys)
            {
                try
                {
                    currentHotkey.Load();
                }
                catch (Exception)
                {
                    // ignored
                }
                
            }
            foreach (Hotkey hotkey in Hotkeys)
            {
                GlobalHotkeyService.Instance.RegisterHotKey(hotkey);
            }
        }

        private void HotkeyConfigurationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
