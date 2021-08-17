namespace PadraInsurancePrescription
{
    partial class ReportListUserRowsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.rows_numUD = new System.Windows.Forms.NumericUpDown();
            this.main_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rows_numUD)).BeginInit();
            this.SuspendLayout();
            // 
            // count_lbl
            // 
            this.count_lbl.AutoSize = true;
            this.count_lbl.BackColor = System.Drawing.Color.Transparent;
            this.count_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.count_lbl.ForeColor = System.Drawing.Color.Black;
            this.count_lbl.Location = new System.Drawing.Point(202, 123);
            this.count_lbl.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.count_lbl.Name = "count_lbl";
            this.count_lbl.Size = new System.Drawing.Size(180, 41);
            this.count_lbl.TabIndex = 6;
            this.count_lbl.Text = "تعداد ردیف ها در هر صفحه :";
            this.count_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // submit_btn
            // 
            this.submit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.submit_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.submit_btn.Location = new System.Drawing.Point(104, 170);
            this.submit_btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(84, 45);
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
            this.cancel_btn.Location = new System.Drawing.Point(202, 170);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(90, 45);
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
            this.main_tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.main_tableLayoutPanel.Controls.Add(this.submit_btn, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.cancel_btn, 0, 2);
            this.main_tableLayoutPanel.Controls.Add(this.count_lbl, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.rows_numUD, 1, 1);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 4;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(389, 243);
            this.main_tableLayoutPanel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.main_tableLayoutPanel.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 123);
            this.label1.TabIndex = 11;
            this.label1.Text = "هر اندازه تعداد ردیف ها افزایش داده شود ، ردیف های به صورت پیوسته بیشتر می شوند و" +
    " ردیف \"مجموع در صفحه\" بعد از تعداد ردیف تعیین شده نمایش داده خواهد شد.  ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rows_numUD
            // 
            this.rows_numUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rows_numUD.Location = new System.Drawing.Point(104, 127);
            this.rows_numUD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rows_numUD.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.rows_numUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rows_numUD.Name = "rows_numUD";
            this.rows_numUD.Size = new System.Drawing.Size(88, 34);
            this.rows_numUD.TabIndex = 10;
            this.rows_numUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rows_numUD.ThousandsSeparator = true;
            this.rows_numUD.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ReportListUserRowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(389, 243);
            this.ControlBox = false;
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MinimizeBox = false;
            this.Name = "ReportListUserRowsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعیین تعداد ردیف های قابل نمایش در هر صفحه";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rows_numUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label count_lbl;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown rows_numUD;
        private System.Windows.Forms.Label label1;
    }
}