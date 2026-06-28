using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Json_Editor.Filter
{
    public partial class JsonArrayFilterForm : Form
    {
        JArray jsonArray;
        JArray filteredJsonArray;

        public JsonArrayFilterForm(JArray jArray)
        {
            InitializeComponent();

            jsonArray = jArray;

            List<string> availablePropertyNames = jArray.OfType<JObject>()
                                                        .SelectMany(obj => obj.Properties())
                                                        .Select(prop => prop.Name)
                                                        .Distinct()
                                                        .ToList();

            comboBox1.DataSource = availablePropertyNames;

            AcceptButton = buttonCount;
        }

        public JArray FilteredJArray { get => filteredJsonArray; }

        #region Right Click
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                int temp = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Remove(temp, textBox1.SelectionLength);
                textBox1.SelectionStart = temp;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }
        #endregion

        private void buttonCount_Click(object sender, EventArgs e)
        {
            JArray filteredJArray = new JArray(jsonArray.Where(token =>
            {
                JToken jToken = token[comboBox1.SelectedItem];
                if (jToken is null) return false;

                return string.Equals((string)jToken, textBox1.Text, StringComparison.OrdinalIgnoreCase);
            }));

            labelCount.Text = $"{filteredJArray.Count()} JObject found";
            labelCount.Visible = true;

            buttonApply.Enabled = true;

            filteredJsonArray = filteredJArray;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            labelCount.Visible = false;
            buttonApply.Enabled = false;
            if (comboBox1.SelectedItem is null) buttonCount.Enabled = false;
            else buttonCount.Enabled = true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
