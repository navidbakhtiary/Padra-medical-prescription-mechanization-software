namespace PadraInsurancePrescription
{
    partial class DBConnectionForm
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
            this.day_label = new System.Windows.Forms.Label();
            this.connect_button = new System.Windows.Forms.Button();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.other_textbox = new System.Windows.Forms.TextBox();
            this.security_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.db_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.server_textbox = new System.Windows.Forms.TextBox();
            this.main_tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // day_label
            // 
            this.day_label.AutoSize = true;
            this.day_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.day_label.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.day_label.ForeColor = System.Drawing.Color.Black;
            this.day_label.Location = new System.Drawing.Point(290, 15);
            this.day_label.Name = "day_label";
            this.day_label.Size = new System.Drawing.Size(146, 42);
            this.day_label.TabIndex = 47;
            this.day_label.Text = "آدرس بانک اطلاعاتی :";
            this.day_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // connect_button
            // 
            this.connect_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connect_button.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.connect_button.Location = new System.Drawing.Point(142, 186);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(142, 35);
            this.connect_button.TabIndex = 1;
            this.connect_button.Text = "ایجاد ارتباط";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.main_tableLayoutPanel.ColumnCount = 5;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.main_tableLayoutPanel.Controls.Add(this.label3, 1, 4);
            this.main_tableLayoutPanel.Controls.Add(this.other_textbox, 2, 4);
            this.main_tableLayoutPanel.Controls.Add(this.security_textbox, 2, 3);
            this.main_tableLayoutPanel.Controls.Add(this.label2, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.db_textbox, 2, 2);
            this.main_tableLayoutPanel.Controls.Add(this.label1, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.server_textbox, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.connect_button, 2, 5);
            this.main_tableLayoutPanel.Controls.Add(this.day_label, 1, 1);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.ForeColor = System.Drawing.Color.Black;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 7;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(446, 268);
            this.main_tableLayoutPanel.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(290, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 42);
            this.label3.TabIndex = 54;
            this.label3.Text = "سایر پارامترها :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // other_textbox
            // 
            this.other_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_tableLayoutPanel.SetColumnSpan(this.other_textbox, 2);
            this.other_textbox.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.other_textbox.Location = new System.Drawing.Point(31, 145);
            this.other_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.other_textbox.MaxLength = 250;
            this.other_textbox.Name = "other_textbox";
            this.other_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.other_textbox.Size = new System.Drawing.Size(252, 34);
            this.other_textbox.TabIndex = 53;
            this.other_textbox.Tag = "2";
            this.other_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // security_textbox
            // 
            this.security_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_tableLayoutPanel.SetColumnSpan(this.security_textbox, 2);
            this.security_textbox.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.security_textbox.Location = new System.Drawing.Point(31, 103);
            this.security_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.security_textbox.MaxLength = 250;
            this.security_textbox.Name = "security_textbox";
            this.security_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.security_textbox.Size = new System.Drawing.Size(252, 34);
            this.security_textbox.TabIndex = 52;
            this.security_textbox.Tag = "2";
            this.security_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(290, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 42);
            this.label2.TabIndex = 51;
            this.label2.Text = "تطابق امنیتی :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // db_textbox
            // 
            this.db_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_tableLayoutPanel.SetColumnSpan(this.db_textbox, 2);
            this.db_textbox.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.db_textbox.Location = new System.Drawing.Point(31, 61);
            this.db_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.db_textbox.MaxLength = 250;
            this.db_textbox.Name = "db_textbox";
            this.db_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.db_textbox.Size = new System.Drawing.Size(252, 34);
            this.db_textbox.TabIndex = 50;
            this.db_textbox.Tag = "2";
            this.db_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(290, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 42);
            this.label1.TabIndex = 49;
            this.label1.Text = "نام بانک اطلاعاتی :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // server_textbox
            // 
            this.server_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_tableLayoutPanel.SetColumnSpan(this.server_textbox, 2);
            this.server_textbox.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.server_textbox.Location = new System.Drawing.Point(31, 19);
            this.server_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.server_textbox.MaxLength = 250;
            this.server_textbox.Name = "server_textbox";
            this.server_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.server_textbox.Size = new System.Drawing.Size(252, 34);
            this.server_textbox.TabIndex = 48;
            this.server_textbox.Tag = "2";
            this.server_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // DBConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(446, 268);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBConnectionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "برقراری ارتباط با بانک اطلاعاتی";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label day_label;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.TextBox server_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox other_textbox;
        private System.Windows.Forms.TextBox security_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox db_textbox;
        private System.Windows.Forms.Label label1;
    }
}