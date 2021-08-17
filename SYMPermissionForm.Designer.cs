namespace PadraInsurancePrescription
{
    partial class SYMPermissionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SYMPermissionForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sector_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.month_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.year_lable = new System.Windows.Forms.Label();
            this.sector_lable = new System.Windows.Forms.Label();
            this.month_label = new System.Windows.Forms.Label();
            this.year_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.refresh_linkLabel = new System.Windows.Forms.LinkLabel();
            this.contract_status_label = new System.Windows.Forms.Label();
            this.contract_status_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 6;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.Controls.Add(this.contract_status_checkedListBox, 3, 3);
            this.main_tableLayoutPanel.Controls.Add(this.contract_status_label, 2, 3);
            this.main_tableLayoutPanel.Controls.Add(this.sector_checkedListBox, 4, 1);
            this.main_tableLayoutPanel.Controls.Add(this.month_checkedListBox, 2, 2);
            this.main_tableLayoutPanel.Controls.Add(this.year_lable, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.sector_lable, 3, 1);
            this.main_tableLayoutPanel.Controls.Add(this.month_label, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.year_checkedListBox, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 4, 4);
            this.main_tableLayoutPanel.Controls.Add(this.refresh_linkLabel, 0, 0);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 5;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(765, 479);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // sector_checkedListBox
            // 
            this.sector_checkedListBox.CheckOnClick = true;
            this.sector_checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sector_checkedListBox.FormattingEnabled = true;
            this.sector_checkedListBox.HorizontalScrollbar = true;
            this.sector_checkedListBox.Location = new System.Drawing.Point(18, 53);
            this.sector_checkedListBox.Name = "sector_checkedListBox";
            this.main_tableLayoutPanel.SetRowSpan(this.sector_checkedListBox, 2);
            this.sector_checkedListBox.Size = new System.Drawing.Size(278, 194);
            this.sector_checkedListBox.TabIndex = 14;
            this.sector_checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.sector_checkedListBox_ItemCheck);
            // 
            // month_checkedListBox
            // 
            this.month_checkedListBox.CheckOnClick = true;
            this.month_checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.month_checkedListBox.FormattingEnabled = true;
            this.month_checkedListBox.HorizontalScrollbar = true;
            this.month_checkedListBox.Location = new System.Drawing.Point(422, 153);
            this.month_checkedListBox.Name = "month_checkedListBox";
            this.main_tableLayoutPanel.SetRowSpan(this.month_checkedListBox, 2);
            this.month_checkedListBox.Size = new System.Drawing.Size(243, 244);
            this.month_checkedListBox.TabIndex = 13;
            this.month_checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.month_checkedListBox_ItemCheck);
            // 
            // year_lable
            // 
            this.year_lable.AutoSize = true;
            this.year_lable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.year_lable.Location = new System.Drawing.Point(672, 50);
            this.year_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.year_lable.Name = "year_lable";
            this.year_lable.Size = new System.Drawing.Size(79, 100);
            this.year_lable.TabIndex = 1;
            this.year_lable.Text = "سال :";
            this.year_lable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sector_lable
            // 
            this.sector_lable.AutoSize = true;
            this.sector_lable.BackColor = System.Drawing.Color.Transparent;
            this.sector_lable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sector_lable.ForeColor = System.Drawing.Color.Black;
            this.sector_lable.Location = new System.Drawing.Point(303, 50);
            this.sector_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sector_lable.Name = "sector_lable";
            this.sector_lable.Size = new System.Drawing.Size(112, 100);
            this.sector_lable.TabIndex = 6;
            this.sector_lable.Text = "صندوق بیمه گر :";
            this.sector_lable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // month_label
            // 
            this.month_label.AutoSize = true;
            this.month_label.BackColor = System.Drawing.Color.Transparent;
            this.month_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.month_label.ForeColor = System.Drawing.Color.Black;
            this.month_label.Location = new System.Drawing.Point(672, 150);
            this.month_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.month_label.Name = "month_label";
            this.main_tableLayoutPanel.SetRowSpan(this.month_label, 2);
            this.month_label.Size = new System.Drawing.Size(79, 250);
            this.month_label.TabIndex = 11;
            this.month_label.Text = "ماه :";
            this.month_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // year_checkedListBox
            // 
            this.year_checkedListBox.CheckOnClick = true;
            this.year_checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.year_checkedListBox.FormattingEnabled = true;
            this.year_checkedListBox.HorizontalScrollbar = true;
            this.year_checkedListBox.Location = new System.Drawing.Point(422, 53);
            this.year_checkedListBox.Name = "year_checkedListBox";
            this.year_checkedListBox.Size = new System.Drawing.Size(243, 94);
            this.year_checkedListBox.TabIndex = 12;
            this.year_checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.year_checkedListBox_ItemCheck);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.save_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 406);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 10, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(272, 67);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_button.AutoSize = true;
            this.cancel_button.CausesValidation = false;
            this.cancel_button.Location = new System.Drawing.Point(26, 6);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(100, 48);
            this.cancel_button.TabIndex = 4;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // save_button
            // 
            this.save_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.save_button.AutoSize = true;
            this.save_button.CausesValidation = false;
            this.save_button.Location = new System.Drawing.Point(134, 6);
            this.save_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(100, 48);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "ذخیره";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // refresh_linkLabel
            // 
            this.refresh_linkLabel.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.refresh_linkLabel, 6);
            this.refresh_linkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refresh_linkLabel.Location = new System.Drawing.Point(3, 0);
            this.refresh_linkLabel.Name = "refresh_linkLabel";
            this.refresh_linkLabel.Size = new System.Drawing.Size(759, 50);
            this.refresh_linkLabel.TabIndex = 15;
            this.refresh_linkLabel.TabStop = true;
            this.refresh_linkLabel.Text = "بارگذاری مجدد";
            this.refresh_linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.refresh_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.refresh_linkLabel_LinkClicked);
            // 
            // contract_status_label
            // 
            this.contract_status_label.AutoSize = true;
            this.contract_status_label.BackColor = System.Drawing.Color.Transparent;
            this.contract_status_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contract_status_label.ForeColor = System.Drawing.Color.Black;
            this.contract_status_label.Location = new System.Drawing.Point(303, 250);
            this.contract_status_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contract_status_label.Name = "contract_status_label";
            this.contract_status_label.Size = new System.Drawing.Size(112, 150);
            this.contract_status_label.TabIndex = 16;
            this.contract_status_label.Text = "وضعیت قرارداد مرکز با صندوق های بیمه گر :";
            this.contract_status_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // contract_status_checkedListBox
            // 
            this.contract_status_checkedListBox.CheckOnClick = true;
            this.contract_status_checkedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contract_status_checkedListBox.FormattingEnabled = true;
            this.contract_status_checkedListBox.HorizontalScrollbar = true;
            this.contract_status_checkedListBox.Location = new System.Drawing.Point(18, 253);
            this.contract_status_checkedListBox.Name = "contract_status_checkedListBox";
            this.contract_status_checkedListBox.Size = new System.Drawing.Size(278, 144);
            this.contract_status_checkedListBox.TabIndex = 17;
            this.contract_status_checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.contract_status_checkedListBox_ItemCheck);
            // 
            // SYMPermissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(765, 479);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "SYMPermissionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعیین مجوزهای دسترسی کاربران برای فعالیت بر روی نسخه ها";
            this.Activated += new System.EventHandler(this.SYMPermissionForm_Activated);
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Label sector_lable;
        private System.Windows.Forms.Label year_lable;
        private System.Windows.Forms.Label month_label;
        private System.Windows.Forms.CheckedListBox month_checkedListBox;
        private System.Windows.Forms.CheckedListBox year_checkedListBox;
        private System.Windows.Forms.CheckedListBox sector_checkedListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.LinkLabel refresh_linkLabel;
        private System.Windows.Forms.CheckedListBox contract_status_checkedListBox;
        private System.Windows.Forms.Label contract_status_label;
    }
}