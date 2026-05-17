using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Texty.Encoding.CharacterDecoderForm;

namespace Texty.Encoding
{
    public partial class TextDecoderForm : Form
    {
        public TextDecoderForm()
        {
            InitializeComponent();
            
            comboBox1.DataSource = Enum.GetValues(typeof(TextEncodingConverter.Encoding));
            comboBox1.SelectedIndex = -1;
        }

        public bool isCodeEmpty()
        {
            return textBoxCode.Text.All(character => char.IsWhiteSpace(character));
        }

        public bool isEncodingSelected()
        {
            return comboBox1.SelectedIndex != -1;
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            if (isCodeEmpty()) return;
            else if (!isEncodingSelected())
            {
                textBox1.Text = "Please, select an encoding";
                return;
            }
            
            var codeEncoding = (TextEncodingConverter.Encoding)comboBox1.SelectedItem;

            TextEncodingConverter converter = new TextEncodingConverter();
            converter.Decode(textBoxCode.Text, codeEncoding);
            textBox1.Text = converter.Text;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxCode.Paste();
        }

    }
}
