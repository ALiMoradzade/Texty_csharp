using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Texty.Edit
{
    public partial class ReplaceForm : Form
    {
        private string[][] escapeSequences = new string[][]
        {
            new string[] { "\\a", "\a" },
            new string[] { "\\b", "\b" },
            new string[] { "\\f", "\f" },
            new string[] { "\\n", "\n" },
            new string[] { "\\r", "\r" },
            new string[] { "\\t", "\t" },
            new string[] { "\\v", "\v" }
        };
        private TextyForm mainForm;
        private List<int> foundList;
        private int currentIndex = 0;

        public ReplaceForm(TextyForm form)
        {
            InitializeComponent();

            AcceptButton = buttonFind;

            mainForm = form;
        }

        public string Old
        {
            get
            {
                string old = textBoxOld.Text;
                if (checkBox1.Checked) old = ReplaceAllEscapeSequences(old);
                return old;
            }
        }

        public string New
        {
            get
            {
                string @new = textBoxNew.Text;
                if (checkBox1.Checked) @new = ReplaceAllEscapeSequences(@new);
                return @new;
            }
        }

        private string ReplaceAllEscapeSequences(string text)
        {
            for (int i = 0; i < escapeSequences.Length; i++)
            {
                string[] escapeSequence = escapeSequences[i];
                if (text.Contains(escapeSequence[0]))
                {
                    text = text.Replace(escapeSequence[0], escapeSequence[1]);
                }
            }
            return text;
        }

        private void SetFindAndClearButtonsEnable(bool visible)
        {
            buttonFind.Enabled = visible;
            buttonClear.Enabled = visible;
        }

        private void SetResultVisible(bool visible)
        {
            labelResult.Visible = visible;
        }

        private void SetPreviousAndNextVisible(bool visible)
        {
            buttonPrevious.Visible = visible;
            buttonNext.Visible = visible;
        }

        private void SetReplaceAndReplaceAllEnable()
        {
            if (!string.IsNullOrEmpty(textBoxOld.Text) && !string.IsNullOrEmpty(textBoxNew.Text))
            {
                buttonReplace.Enabled = true;
                buttonReplaceAll.Enabled = true;
            }
            else
            {
                buttonReplace.Enabled = false;
                buttonReplaceAll.Enabled = false;
            }
        }

        private void SetReplaceAndReplaceAllEnable(bool enable)
        {
            buttonReplace.Enabled = enable;
            buttonReplaceAll.Enabled = enable;
        }

        private void UpdateResult()
        {
            labelResult.Text = $"Result: {currentIndex + 1} of {foundList.Count}";
        }

        private void ResetIndex()
        {
            currentIndex = 0;
        }

        private void ResultNotFound()
        {
            labelResult.Text = "Text Not Found";
        }

        private void ResetFindResults()
        {
            SetResultVisible(false);
            SetPreviousAndNextVisible(false);
            ResetIndex();
        }

        private void Next()
        {
            currentIndex++;
            currentIndex %= foundList.Count;
        }

        private void Previous()
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex += foundList.Count;
            currentIndex %= foundList.Count;
        }

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxOld.Text)) SetFindAndClearButtonsEnable(false);
            else SetFindAndClearButtonsEnable(true);

            ResetFindResults();

            SetReplaceAndReplaceAllEnable();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            mainForm.isTextChangesAppliedToFind = false;

            foundList = mainForm.FindText(Old);
            SetResultVisible(true);

            if (foundList.Count == 0)
            {
                ResultNotFound();
                SetPreviousAndNextVisible(false);
            }
            else // foundList.Length > 1
            {
                ResetIndex();
                UpdateResult();
                mainForm.ShowFoundText(foundList[currentIndex], textBoxOld.Text.Length);

                if (foundList.Count == 1) SetPreviousAndNextVisible(false);
                else SetPreviousAndNextVisible(true);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (mainForm.isTextChangesAppliedToFind)
            {
                ResetFindResults();
                SetReplaceAndReplaceAllEnable(false);
                return;
            }
            Next();

            UpdateResult();
            mainForm.ShowFoundText(foundList[currentIndex], textBoxOld.Text.Length);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (mainForm.isTextChangesAppliedToFind)
            {
                ResetFindResults();
                SetReplaceAndReplaceAllEnable(false);
                return;
            }
            Previous();

            UpdateResult();
            mainForm.ShowFoundText(foundList[currentIndex], textBoxOld.Text.Length);
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if (mainForm.isTextChangesAppliedToFind)
            {
                ResetFindResults();
                SetReplaceAndReplaceAllEnable(false);
                return;
            }

            mainForm.ReplaceText(foundList[currentIndex], Old, New);
            foundList.RemoveAt(currentIndex);
            int difference = Math.Abs(textBoxOld.Text.Length - textBoxNew.Text.Length);
            foundList = foundList.Select(index => index + difference).ToList();

            buttonNext.PerformClick();
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {
            if (mainForm.isTextChangesAppliedToFind)
            {
                ResetFindResults();
                SetReplaceAndReplaceAllEnable(false);
                return;
            }
            mainForm.ReplaceAllText(Old, New);

            MessageBox.Show($"{foundList.Count} occurrence(s) of {textBoxOld.Text} were replaced successfully",
                            "Replace All Complete",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            
            foundList.Clear();
            ResetFindResults();
            SetReplaceAndReplaceAllEnable(false);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxOld.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxOld.Paste();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBoxNew.Copy();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBoxNew.Paste();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxOld.Clear();
        }

    }
}
