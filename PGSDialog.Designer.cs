namespace PadraInsurancePrescription
{
    partial class PGSDialog
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
            this.no_button = new System.Windows.Forms.Button();
            this.yes_button = new System.Windows.Forms.Button();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.message_box = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.ok_button = new System.Windows.Forms.Button();
            this.icon_picturebox = new System.Windows.Forms.PictureBox();
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // no_button
            // 
            this.no_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.no_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.no_button.Location = new System.Drawing.Point(19, 64);
            this.no_button.Margin = new System.Windows.Forms.Padding(4);
            this.no_button.Name = "no_button";
            this.no_button.Size = new System.Drawing.Size(115, 52);
            this.no_button.TabIndex = 1;
            this.no_button.Text = "خیر";
            this.no_button.UseVisualStyleBackColor = true;
            this.no_button.Visible = false;
            this.no_button.Click += new System.EventHandler(this.no_button_Click);
            // 
            // yes_button
            // 
            this.yes_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yes_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.yes_button.Location = new System.Drawing.Point(19, 4);
            this.yes_button.Margin = new System.Windows.Forms.Padding(4);
            this.yes_button.Name = "yes_button";
            this.yes_button.Size = new System.Drawing.Size(115, 52);
            this.yes_button.TabIndex = 0;
            this.yes_button.Text = "بله";
            this.yes_button.UseVisualStyleBackColor = true;
            this.yes_button.Visible = false;
            this.yes_button.Click += new System.EventHandler(this.yes_button_Click);
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 3;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.Controls.Add(this.message_box, 1, 0);
            this.main_tableLayoutPanel.Controls.Add(this.icon_picturebox, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 6;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(772, 333);
            this.main_tableLayoutPanel.TabIndex = 8;
            // 
            // message_box
            // 
            this.message_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message_box.BackColor = System.Drawing.Color.White;
            this.message_box.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.message_box.Location = new System.Drawing.Point(159, 13);
            this.message_box.Margin = new System.Windows.Forms.Padding(13, 13, 7, 7);
            this.message_box.Multiline = true;
            this.message_box.Name = "message_box";
            this.message_box.ReadOnly = true;
            this.main_tableLayoutPanel.SetRowSpan(this.message_box, 5);
            this.message_box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.message_box.Size = new System.Drawing.Size(494, 273);
            this.message_box.TabIndex = 4;
            this.message_box.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.yes_button);
            this.flowLayoutPanel1.Controls.Add(this.no_button);
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.ok_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 13);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 13, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.main_tableLayoutPanel.SetRowSpan(this.flowLayoutPanel1, 6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(138, 316);
            this.flowLayoutPanel1.TabIndex = 11;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancel_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cancel_button.Location = new System.Drawing.Point(19, 124);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(4);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(115, 52);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Visible = false;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // ok_button
            // 
            this.ok_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ok_button.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ok_button.Location = new System.Drawing.Point(19, 184);
            this.ok_button.Margin = new System.Windows.Forms.Padding(4);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(115, 52);
            this.ok_button.TabIndex = 3;
            this.ok_button.Text = "ملاحظه شد";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Visible = false;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // icon_picturebox
            // 
            this.icon_picturebox.Location = new System.Drawing.Point(670, 59);
            this.icon_picturebox.Margin = new System.Windows.Forms.Padding(21, 13, 4, 13);
            this.icon_picturebox.Name = "icon_picturebox";
            this.icon_picturebox.Size = new System.Drawing.Size(81, 81);
            this.icon_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon_picturebox.TabIndex = 12;
            this.icon_picturebox.TabStop = false;
            // 
            // PGSDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(130F, 130F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(772, 333);
            this.ControlBox = false;
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PGSDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پیغام";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_picturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button no_button;
        private System.Windows.Forms.Button yes_button;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.TextBox message_box;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.PictureBox icon_picturebox;
    }
}