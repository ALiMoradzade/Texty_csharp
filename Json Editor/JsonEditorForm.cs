using Json_Editor.Filter;
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
        Formatting JsonFormatting;

        public JsonEditorForm()
        {
            InitializeComponent();

            JsonFormatting = Formatting.None;
        }

        private void JsonEditorForm_Resize(object sender, EventArgs e)
        {
            int width = (Width - 15) / 2;
            if (width > 0)
            {
                textBox1.Size = new Size(width, textBox1.Height);
                treeView1.Size = new Size(width, textBox1.Height);
            }
        }

        private Formatting JsonFormatChecker(string json)
        {
            JToken token = JToken.Parse(json);

            if (json == token.ToString(Formatting.Indented)) return Formatting.Indented;
            else if (json == token.ToString(Formatting.None)) return Formatting.None;
            return Formatting.None;
        }

        private bool IsValidJson(string json)
        {
            try
            {
                JToken.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        #region Message Box
        private static DialogResult MessageBoxInvalidJsonText()
        {
            var r = MessageBox.Show("The provided text is not valid JSON",
                                    "Invalid JSON",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            return r;
        }

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

        private static DialogResult MessageBoxJsonAlreadyBeautifyied()
        {
            var r = MessageBox.Show("The JSON is already beautified",
                                    "JSON Beautified",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            return r;
        }

        private static DialogResult MessageBoxJsonBeautifiedSuccessful()
        {
            var r = MessageBox.Show("The JSON was beautified successfully",
                                    "JSON Beautified",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            return r;
        }

        private static DialogResult MessageBoxJsonAlreadyMinified()
        {
            var r = MessageBox.Show("The JSON is already minified",
                                    "JSON Minified",
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

        private static DialogResult MessageBoxInvalidJsonArray(string json)
        {
            var r = MessageBox.Show($"The selected node is a {json}.\r\nPlease, select a JArray to apply a filter",
                                    "Cannot Filter",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
            return r;
        }

        private static DialogResult MessageBoxJsonArrayReplaceSuccessful()
        {
            var r = MessageBox.Show("The JSON array was filtered successfully",
                                    "Filter Applied",
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
                    string json = await streamReader.ReadToEndAsync();
                    if (!IsValidJson(json))
                    {
                        MessageBoxInvalidJsonText();
                        return;
                    }

                    textBox1.Text = json;
                    JsonFormatting = JsonFormatChecker(json);
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
        private void beautifyJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            if (JsonFormatChecker(textBox1.Text) == Formatting.Indented)
            {
                MessageBoxJsonAlreadyBeautifyied();
                return;
            }

            textBox1.Text = JToken.Parse(textBox1.Text).ToString(Formatting.Indented);
            JsonFormatting = Formatting.Indented;
            MessageBoxJsonBeautifiedSuccessful();
        }

        private void minifyJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            if (JsonFormatChecker(textBox1.Text) == Formatting.None)
            {
                MessageBoxJsonAlreadyBeautifyied();
                return;
            }

            textBox1.Text = JToken.Parse(textBox1.Text).ToString(Formatting.None);
            JsonFormatting = Formatting.None;
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

        #region Right Click TextBox
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }
        #endregion

        #region Right Click TreeView
        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;

            filterSelectedJArrayToolStripMenuItem.Enabled = !(node is null);
        }

        private void filterSelectedJArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            JToken jToken = JToken.Parse(textBox1.Text);

            string[] properties = node.FullPath.Split('\\').Skip(1).ToArray();
            foreach (string property in properties)
            {
                if (int.TryParse(property, out int index)) jToken = jToken[index];
                else jToken = jToken[property];
            }

            if (!(jToken is JArray jArray))
            {
                MessageBoxInvalidJsonArray(jToken.GetType().Name);
                return;
            }

            JsonArrayFilterForm form = new JsonArrayFilterForm(jArray);
            if (form.ShowDialog() == DialogResult.OK)
            {
                JToken root = JToken.Parse(textBox1.Text);

                JArray servers = (JArray)root.SelectToken($"$.{string.Join(".", properties)}");
                servers.ReplaceAll(form.FilteredJArray);

                textBox1.Text = root.ToString(JsonFormatting);

                MessageBoxJsonArrayReplaceSuccessful();
            }
        }
        #endregion


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) return;

            JsonTreeConverter jsonTreeConverter = new JsonTreeConverter(textBox1.Text);

            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(jsonTreeConverter.Result);
        }
    }
}
