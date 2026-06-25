using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json_Editor
{
    public partial class RemovePropertyForm : Form
    {
        public RemovePropertyForm()
        {
            InitializeComponent();

            AcceptButton = buttonOK;
        }

        public string PropertyName { get => textBox1.Text; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) buttonOK.Enabled = false;
            else buttonOK.Enabled = true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
