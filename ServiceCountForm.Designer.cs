namespace PadraInsurancePrescription
{
    partial class ServiceCountForm
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
            this.count_lbl = new System.Windows.Forms.Label();
            this.submit_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.count_numUD = new System.Windows.Forms.NumericUpDown();
            this.allow_chk = new System.Windows.Forms.CheckBox();
            this.main_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count_numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // count_lbl
            // 
            this.count_lbl.AutoSize = true;
            this.count_lbl.BackColor = System.Drawing.Color.Transparent;
            this.count_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.count_lbl.Font = new System.Drawing.Font("B Roya", 12F);
            this.count_lbl.ForeColor = System.Drawing.Color.Black;
            this.count_lbl.Location = new System.Drawing.Point(222, 110);
            this.count_lbl.Name = "count_lbl";
            this.count_lbl.Size = new System.Drawing.Size(212, 25);
            this.count_lbl.TabIndex = 6;
            this.count_lbl.Text = "تعداد دفعات انجام خدمت :";
            this.count_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // submit_btn
            // 
            this.submit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.submit_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submit_btn.Location = new System.Drawing.Point(116, 138);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(100, 35);
            this.submit_btn.TabIndex = 7;
            this.submit_btn.Text = "ثبت";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_btn.AutoSize = true;
            this.cancel_btn.Location = new System.Drawing.Point(222, 138);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(100, 35);
            this.cancel_btn.TabIndex = 9;
            this.cancel_btn.Text = "انصراف";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 2;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.main_tableLayoutPanel.Controls.Add(this.submit_btn, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.cancel_btn, 0, 2);
            this.main_tableLayoutPanel.Controls.Add(this.count_lbl, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.count_numUD, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.allow_chk, 0, 0);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 4;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(437, 250);
            this.main_tableLayoutPanel.TabIndex = 10;
            // 
            // count_numUD
            // 
            this.count_numUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.count_numUD.Enabled = false;
            this.count_numUD.Location = new System.Drawing.Point(127, 112);
            this.count_numUD.Margin = new System.Windows.Forms.Padding(2);
            this.count_numUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.count_numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.count_numUD.Name = "count_numUD";
            this.count_numUD.Size = new System.Drawing.Size(90, 20);
            this.count_numUD.TabIndex = 10;
            this.count_numUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.count_numUD.ThousandsSeparator = true;
            this.count_numUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // allow_chk
            // 
            this.allow_chk.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.allow_chk, 2);
            this.allow_chk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allow_chk.Font = new System.Drawing.Font("B Roya", 12F);
            this.allow_chk.Location = new System.Drawing.Point(3, 3);
            this.allow_chk.Name = "allow_chk";
            this.allow_chk.Size = new System.Drawing.Size(431, 104);
            this.allow_chk.TabIndex = 11;
            this.allow_chk.Text = "در صورت فعال کردن این گزینه امکان تغییر تعداد دفعات انجام خدمت میسر می شود. برای " +
    "خدماتی مانند ویزیت پزشکی، خدمات سرپایی پزشکان و دندانپزشکان و خدمات پاراکلینیک ا" +
    "ین مقدار باید 1 باشد. ";
            this.allow_chk.UseVisualStyleBackColor = true;
            this.allow_chk.CheckedChanged += new System.EventHandler(this.allow_chk_CheckedChanged);
            // 
            // ServiceCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 250);
            this.ControlBox = false;
            this.Controls.Add(this.main_tableLayoutPanel);
            this.MinimizeBox = false;
            this.Name = "ServiceCountForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعیین تعداد دفعات انجام خدمت";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.count_numUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label count_lbl;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown count_numUD;
        private System.Windows.Forms.CheckBox allow_chk;
    }
}