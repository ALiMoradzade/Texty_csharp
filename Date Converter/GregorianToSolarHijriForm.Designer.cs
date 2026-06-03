namespace Texty.Date_Converter
{
    partial class GregorianToSolarHijriForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGregorianYear = new System.Windows.Forms.TextBox();
            this.textBoxGregorianMonth = new System.Windows.Forms.TextBox();
            this.textBoxGregorianDay = new System.Windows.Forms.TextBox();
            this.textBoxSolarHijriDay = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxSolarHijriMonth = new System.Windows.Forms.TextBox();
            this.textBoxSolarHijriYear = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonNowDateTime = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gregorian Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Solar Hijri Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Year";
            // 
            // textBoxGregorianYear
            // 
            this.textBoxGregorianYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGregorianYear.Location = new System.Drawing.Point(100, 25);
            this.textBoxGregorianYear.MaxLength = 4;
            this.textBoxGregorianYear.Name = "textBoxGregorianYear";
            this.textBoxGregorianYear.ShortcutsEnabled = false;
            this.textBoxGregorianYear.Size = new System.Drawing.Size(38, 22);
            this.textBoxGregorianYear.TabIndex = 1;
            this.textBoxGregorianYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGregorianYear_KeyPress);
            // 
            // textBoxGregorianMonth
            // 
            this.textBoxGregorianMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGregorianMonth.Location = new System.Drawing.Point(144, 25);
            this.textBoxGregorianMonth.MaxLength = 2;
            this.textBoxGregorianMonth.Name = "textBoxGregorianMonth";
            this.textBoxGregorianMonth.ShortcutsEnabled = false;
            this.textBoxGregorianMonth.Size = new System.Drawing.Size(23, 22);
            this.textBoxGregorianMonth.TabIndex = 2;
            this.textBoxGregorianMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGregorianYear_KeyPress);
            // 
            // textBoxGregorianDay
            // 
            this.textBoxGregorianDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGregorianDay.Location = new System.Drawing.Point(178, 25);
            this.textBoxGregorianDay.MaxLength = 2;
            this.textBoxGregorianDay.Name = "textBoxGregorianDay";
            this.textBoxGregorianDay.ShortcutsEnabled = false;
            this.textBoxGregorianDay.Size = new System.Drawing.Size(23, 22);
            this.textBoxGregorianDay.TabIndex = 3;
            this.textBoxGregorianDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGregorianYear_KeyPress);
            // 
            // textBoxSolarHijriDay
            // 
            this.textBoxSolarHijriDay.ContextMenuStrip = this.contextMenuStrip1;
            this.textBoxSolarHijriDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSolarHijriDay.Location = new System.Drawing.Point(178, 53);
            this.textBoxSolarHijriDay.MaxLength = 2;
            this.textBoxSolarHijriDay.Name = "textBoxSolarHijriDay";
            this.textBoxSolarHijriDay.ReadOnly = true;
            this.textBoxSolarHijriDay.Size = new System.Drawing.Size(23, 22);
            this.textBoxSolarHijriDay.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyDateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // copyDateToolStripMenuItem
            // 
            this.copyDateToolStripMenuItem.Name = "copyDateToolStripMenuItem";
            this.copyDateToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.copyDateToolStripMenuItem.Text = "Copy Date";
            this.copyDateToolStripMenuItem.Click += new System.EventHandler(this.copyDateToolStripMenuItem_Click);
            // 
            // textBoxSolarHijriMonth
            // 
            this.textBoxSolarHijriMonth.ContextMenuStrip = this.contextMenuStrip1;
            this.textBoxSolarHijriMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSolarHijriMonth.Location = new System.Drawing.Point(144, 53);
            this.textBoxSolarHijriMonth.MaxLength = 2;
            this.textBoxSolarHijriMonth.Name = "textBoxSolarHijriMonth";
            this.textBoxSolarHijriMonth.ReadOnly = true;
            this.textBoxSolarHijriMonth.Size = new System.Drawing.Size(23, 22);
            this.textBoxSolarHijriMonth.TabIndex = 5;
            // 
            // textBoxSolarHijriYear
            // 
            this.textBoxSolarHijriYear.ContextMenuStrip = this.contextMenuStrip1;
            this.textBoxSolarHijriYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSolarHijriYear.Location = new System.Drawing.Point(100, 53);
            this.textBoxSolarHijriYear.MaxLength = 4;
            this.textBoxSolarHijriYear.Name = "textBoxSolarHijriYear";
            this.textBoxSolarHijriYear.ReadOnly = true;
            this.textBoxSolarHijriYear.Size = new System.Drawing.Size(38, 22);
            this.textBoxSolarHijriYear.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Day";
            // 
            // buttonNowDateTime
            // 
            this.buttonNowDateTime.Location = new System.Drawing.Point(207, 12);
            this.buttonNowDateTime.Name = "buttonNowDateTime";
            this.buttonNowDateTime.Size = new System.Drawing.Size(64, 35);
            this.buttonNowDateTime.TabIndex = 4;
            this.buttonNowDateTime.Text = "Now Date Time";
            this.buttonNowDateTime.UseVisualStyleBackColor = true;
            this.buttonNowDateTime.Click += new System.EventHandler(this.buttonNowDateTime_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(207, 53);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 5;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // GregorianToSolarHijriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 88);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonNowDateTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSolarHijriDay);
            this.Controls.Add(this.textBoxSolarHijriMonth);
            this.Controls.Add(this.textBoxSolarHijriYear);
            this.Controls.Add(this.textBoxGregorianDay);
            this.Controls.Add(this.textBoxGregorianMonth);
            this.Controls.Add(this.textBoxGregorianYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GregorianToSolarHijriForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gregorian To Solar Hijri";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGregorianYear;
        private System.Windows.Forms.TextBox textBoxGregorianMonth;
        private System.Windows.Forms.TextBox textBoxGregorianDay;
        private System.Windows.Forms.TextBox textBoxSolarHijriDay;
        private System.Windows.Forms.TextBox textBoxSolarHijriMonth;
        private System.Windows.Forms.TextBox textBoxSolarHijriYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonNowDateTime;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyDateToolStripMenuItem;
    }
}