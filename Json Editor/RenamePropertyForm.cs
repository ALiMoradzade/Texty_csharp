using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Json_Editor
{
    public partial class RenamePropertyForm : Form
    {
        public RenamePropertyForm()
        {
            InitializeComponent();

            AcceptButton = buttonOK;
        }

        public string OldPropertyName { get => textBoxOld.Text; }
        public string NewPropertyName { get => textBoxNew.Text; }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOld.Text) || string.IsNullOrEmpty(textBoxNew.Text)) buttonOK.Enabled = false;
            else buttonOK.Enabled = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
