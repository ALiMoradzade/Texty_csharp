using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Json_Editor
{
    public partial class JsonEditorForm : Form
    {
        public JsonEditorForm()
        {
            InitializeComponent();
        }

        #region Message Box
        private static DialogResult MessageBoxPropertyDoesntFound(string property)
        {
            var r = MessageBox.Show($"The JSON property \"{property}\" could not be found",
                                     "Property Not Found",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
            return r;
        }

        private static DialogResult MessageBoxPropertyRenameChoice(string oldProperty, string newProperty)
        {
            var r = MessageBox.Show($"Are you sure you want to rename the property \"{oldProperty}\" to \"{newProperty}\"?",
                                     "Rename Property",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Information,
                                     MessageBoxDefaultButton.Button2);
            return r;
        }

        private static DialogResult MessageBoxPropertyRenamedSuccessful()
        {
            var r = MessageBox.Show($"The property was renamed successfully",
                                     "Property Renamed",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
            return r;
        }

        private static DialogResult MessageBoxPropertyRemoveChoice(string property)
        {
            var r = MessageBox.Show($"Are you sure you want to remove the property \"{property}\"?",
                                     "Remove Property",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Information,
                                     MessageBoxDefaultButton.Button2);
            return r;
        }

        private static DialogResult MessageBoxPropertyRemovedSuccessful()
        {
            var r = MessageBox.Show($"The property was removed successfully",
                                     "Property Removed",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
            return r;
        }

        private static DialogResult MessageBoxJsonAlreadyIndented()
        {
            var r = MessageBox.Show("The JSON is already formatted",
                                    "JSON Formatted",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            return r;
        }

        private static DialogResult MessageBoxJsonIndentedSuccessful()
        {
            var r = MessageBox.Show("The JSON was formatted successfully",
                                    "JSON Formatted",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            return r;
        }

        private static DialogResult MessageBoxJsonAlreadyMinified()
        {
            var r = MessageBox.Show("The JSON is already formatted",
                                    "JSON Formatted",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            return r;
        }

        private static DialogResult MessageBoxJsonMinifiedSuccessful()
        {
            var r = MessageBox.Show("The JSON was minified successfully",
                                    "JSON Minified",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            return r;
        }
        #endregion

        #region File Tab
        private async void openJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamReader = new StreamReader(openFileDialog1.FileName))
                {
                    textBox1.Text = await streamReader.ReadToEndAsync();
                }
            }
        }

        private void saveAsJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Edit Tab
        private void indentedJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            JToken token = JToken.Parse(textBox1.Text);
            string indented = token.ToString(Formatting.Indented);

            if (textBox1.Text == indented)
            {
                MessageBoxJsonAlreadyIndented();
                return;
            }

            textBox1.Text = indented;
            MessageBoxJsonIndentedSuccessful();
        }

        private void minifyJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            JToken token = JToken.Parse(textBox1.Text);
            string minified = token.ToString(Formatting.None);

            if (textBox1.Text == minified)
            {
                MessageBoxJsonAlreadyMinified();
                return;
            }

            textBox1.Text = minified;
            MessageBoxJsonMinifiedSuccessful();
        }

        private void renamePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            RenamePropertyForm form = new RenamePropertyForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (!textBox1.Text.Contains(form.OldPropertyName))
                {
                    MessageBoxPropertyDoesntFound(form.OldPropertyName);
                    return;
                }

                if (MessageBoxPropertyRenameChoice(form.OldPropertyName, form.NewPropertyName) == DialogResult.Yes)
                {
                    textBox1.Text = textBox1.Text.Replace(form.OldPropertyName, form.NewPropertyName);
                    MessageBoxPropertyRenamedSuccessful();
                }
            }
        }

        private void removePropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            RemovePropertyForm form = new RemovePropertyForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (!textBox1.Text.Contains(form.PropertyName))
                {
                    MessageBoxPropertyDoesntFound(form.PropertyName);
                    return;
                }

                if (MessageBoxPropertyRemoveChoice(form.PropertyName) == DialogResult.Yes)
                {
                    textBox1.Lines = textBox1.Lines.Where(line => !line.Contains(form.PropertyName)).ToArray();
                    MessageBoxPropertyRemovedSuccessful();
                }
            }
        }
        #endregion

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }
    }
}
