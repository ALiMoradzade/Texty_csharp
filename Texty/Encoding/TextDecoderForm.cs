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

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            string code;
            TextEncodingConverter.Encoding codeEncoding;

            if (textBoxCode.Text.All(character => char.IsWhiteSpace(character)))
            {
                return;
            }
            else if (comboBox1.SelectedItem == null)
            {
                textBox1.Text = "Please, select an encoding";
                return;
            }

            code = textBoxCode.Text;
            codeEncoding = (TextEncodingConverter.Encoding)comboBox1.SelectedItem;

            if (!TextEncodingConverter.IsCodeBaseCorrect(code, codeEncoding))
            {
                textBox1.Text = "Please, enter a valid code or encoding";
                return;
            }
            else if (!TextEncodingConverter.IsCodeLengthCorrect(code, codeEncoding))
            {
                textBox1.Text = "The value is out of range (0 – 0x0010FFFF)";
                return;
            }

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
