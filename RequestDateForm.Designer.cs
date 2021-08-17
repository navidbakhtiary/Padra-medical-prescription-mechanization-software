namespace PadraInsurancePrescription
{
    partial class RequestDateForm
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
            this.set_button = new System.Windows.Forms.Button();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.date_masked = new System.Windows.Forms.MaskedTextBox();
            this.system_date_radio = new System.Windows.Forms.RadioButton();
            this.custom_date_radio = new System.Windows.Forms.RadioButton();
            this.main_tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // set_button
            // 
            this.set_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.set_button.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.set_button.Location = new System.Drawing.Point(20, 93);
            this.set_button.Name = "set_button";
            this.set_button.Size = new System.Drawing.Size(172, 32);
            this.set_button.TabIndex = 1;
            this.set_button.Text = "مقداردهی";
            this.set_button.UseVisualStyleBackColor = true;
            this.set_button.Click += new System.EventHandler(this.set_button_Click);
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 5;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.main_tableLayoutPanel.Controls.Add(this.date_masked, 3, 2);
            this.main_tableLayoutPanel.Controls.Add(this.set_button, 3, 3);
            this.main_tableLayoutPanel.Controls.Add(this.system_date_radio, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.custom_date_radio, 1, 2);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 5;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(436, 144);
            this.main_tableLayoutPanel.TabIndex = 48;
            // 
            // date_masked
            // 
            this.date_masked.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.date_masked.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold);
            this.date_masked.Location = new System.Drawing.Point(19, 54);
            this.date_masked.Margin = new System.Windows.Forms.Padding(2);
            this.date_masked.Mask = "0000/00/00";
            this.date_masked.Name = "date_masked";
            this.date_masked.RejectInputOnFirstFailure = true;
            this.date_masked.ResetOnSpace = false;
            this.date_masked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.date_masked.Size = new System.Drawing.Size(174, 34);
            this.date_masked.TabIndex = 50;
            this.date_masked.Tag = "6";
            this.date_masked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.date_masked.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // system_date_radio
            // 
            this.system_date_radio.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.system_date_radio, 2);
            this.system_date_radio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.system_date_radio.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.system_date_radio.Location = new System.Drawing.Point(198, 18);
            this.system_date_radio.Name = "system_date_radio";
            this.system_date_radio.Size = new System.Drawing.Size(228, 31);
            this.system_date_radio.TabIndex = 48;
            this.system_date_radio.TabStop = true;
            this.system_date_radio.Text = "بر اساس تاریخ کامپیوتر (تاریخ امروز)";
            this.system_date_radio.UseVisualStyleBackColor = true;
            this.system_date_radio.CheckedChanged += new System.EventHandler(this.system_date_radio_CheckedChanged);
            // 
            // custom_date_radio
            // 
            this.custom_date_radio.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.custom_date_radio, 2);
            this.custom_date_radio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.custom_date_radio.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.custom_date_radio.Location = new System.Drawing.Point(198, 55);
            this.custom_date_radio.Name = "custom_date_radio";
            this.custom_date_radio.Size = new System.Drawing.Size(228, 32);
            this.custom_date_radio.TabIndex = 49;
            this.custom_date_radio.TabStop = true;
            this.custom_date_radio.Text = "تعیین تاریخ دلخواه";
            this.custom_date_radio.UseVisualStyleBackColor = true;
            // 
            // RequestDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(436, 144);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestDateForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعیین تاریخ درخواست گزارش";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button set_button;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.RadioButton system_date_radio;
        private System.Windows.Forms.RadioButton custom_date_radio;
        private System.Windows.Forms.MaskedTextBox date_masked;
    }
}