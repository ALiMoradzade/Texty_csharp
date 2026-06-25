namespace Texty.Edit
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.White;
            this.buttonClear.Enabled = false;
            this.buttonClear.ForeColor = System.Drawing.Color.Red;
            this.buttonClear.Location = new System.Drawing.Point(268, 11);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(30, 22);
            this.buttonClear.TabIndex = 70;
            this.buttonClear.Text = "❌";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.White;
            this.buttonNext.ForeColor = System.Drawing.Color.Black;
            this.buttonNext.Location = new System.Drawing.Point(100, 40);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(30, 22);
            this.buttonNext.TabIndex = 69;
            this.buttonNext.Text = "▼";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Visible = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.BackColor = System.Drawing.Color.White;
            this.buttonPrevious.ForeColor = System.Drawing.Color.Black;
            this.buttonPrevious.Location = new System.Drawing.Point(136, 40);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(30, 22);
            this.buttonPrevious.TabIndex = 68;
            this.buttonPrevious.Text = "▲";
            this.buttonPrevious.UseVisualStyleBackColor = false;
            this.buttonPrevious.Visible = false;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 45);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(82, 13);
            this.labelResult.TabIndex = 67;
            this.labelResult.Text = "Result: 00 of 00";
            this.labelResult.Visible = false;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.White;
            this.buttonFind.Enabled = false;
            this.buttonFind.ForeColor = System.Drawing.Color.Black;
            this.buttonFind.Image = ((System.Drawing.Image)(resources.GetObject("buttonFind.Image")));
            this.buttonFind.Location = new System.Drawing.Point(232, 12);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(30, 22);
            this.buttonFind.TabIndex = 62;
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Text: ";
            // 
            // textBoxProvider
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.Color.Black;
            this.textBox.Location = new System.Drawing.Point(52, 12);
            this.textBox.MaxLength = 3;
            this.textBox.Name = "textBoxProvider";
            this.textBox.Size = new System.Drawing.Size(174, 22);
            this.textBox.TabIndex = 58;
            this.textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 48);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 74);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FindForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Text";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    }
}