using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.MiddleTier.Model;

namespace MitchHotkeys
{
    public partial class GroupEditForm : Form
    {

        public HotkeyGroup Group { get; set; }
        public GroupEditForm(int newId)
        {
            InitializeComponent();
            Group = new HotkeyGroup();
            Group.Id = newId;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbGroupName.Text))
            {
                Group.Name = tbGroupName.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
