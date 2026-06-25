using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texty.Edit
{
    public partial class FindForm : Form
    {
        private TextyForm mainForm;
        private List<int> foundList;
        private int currentIndex = 0;

        public FindForm(TextyForm form)
        {
            InitializeComponent();

            AcceptButton = buttonFind;

            mainForm = form;
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

        private void UpdateResultAndShow()
        {
            labelResult.Text = $"Result: {currentIndex + 1} of {foundList.Count}";
            mainForm.ShowFoundText(foundList[currentIndex], textBox.Text.Length);
        }

        private void ResetIndex()
        {
            currentIndex = 0;
        }

        private void ResultNotFound()
        {
            labelResult.Text = "DNS Not Found";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text)) SetFindAndClearButtonsEnable(false);
            else SetFindAndClearButtonsEnable(true);

            SetResultVisible(false);
            SetPreviousAndNextVisible(false);
            ResetIndex();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            mainForm.isTextChangesAppliedToFind = false;

            foundList = mainForm.FindText(textBox.Text);
            SetResultVisible(true);

            if (foundList.Count == 0)
            {
                ResultNotFound();
                SetPreviousAndNextVisible(false);
            }
            else // foundList.Length > 1
            {
                ResetIndex();
                UpdateResultAndShow();

                if (foundList.Count == 1) SetPreviousAndNextVisible(false);
                else SetPreviousAndNextVisible(true);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (mainForm.isTextChangesAppliedToFind)
            {
                SetResultVisible(false);
                SetPreviousAndNextVisible(false);
                ResetIndex();
                return;
            }
            currentIndex--;
            if (currentIndex < 0) currentIndex += foundList.Count;
            currentIndex %= foundList.Count;
            UpdateResultAndShow();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (mainForm.isTextChangesAppliedToFind)
            {
                SetResultVisible(false);
                SetPreviousAndNextVisible(false);
                ResetIndex();
                return;
            }
            currentIndex++;
            currentIndex %= foundList.Count;
            UpdateResultAndShow();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }
    }
}
