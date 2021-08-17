namespace PadraInsurancePrescription
{
    partial class ProvinceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProvinceForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.id_textbox = new System.Windows.Forms.TextBox();
            this.id_lable = new System.Windows.Forms.Label();
            this.name_lable = new System.Windows.Forms.Label();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.name_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.name_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 2;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.Controls.Add(this.id_textbox, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.id_lable, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.name_lable, 0, 2);
            this.main_tableLayoutPanel.Controls.Add(this.name_textbox, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 5;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(392, 224);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // id_textbox
            // 
            this.id_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.id_textbox.Enabled = false;
            this.id_textbox.Location = new System.Drawing.Point(20, 34);
            this.id_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.id_textbox.MaxLength = 250;
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.Size = new System.Drawing.Size(264, 43);
            this.id_textbox.TabIndex = 0;
            this.id_textbox.Tag = "0";
            // 
            // id_lable
            // 
            this.id_lable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_lable.AutoSize = true;
            this.id_lable.Location = new System.Drawing.Point(296, 28);
            this.id_lable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.id_lable.Name = "id_lable";
            this.id_lable.Size = new System.Drawing.Size(70, 55);
            this.id_lable.TabIndex = 1;
            this.id_lable.Text = "شناسه :";
            this.id_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_lable
            // 
            this.name_lable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_lable.AutoSize = true;
            this.name_lable.BackColor = System.Drawing.Color.Transparent;
            this.name_lable.ForeColor = System.Drawing.Color.Black;
            this.name_lable.Location = new System.Drawing.Point(296, 83);
            this.name_lable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name_lable.Name = "name_lable";
            this.name_lable.Size = new System.Drawing.Size(90, 55);
            this.name_lable.TabIndex = 6;
            this.name_lable.Text = "نام استان :";
            this.name_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_textbox
            // 
            this.name_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.name_textbox.Location = new System.Drawing.Point(20, 89);
            this.name_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.name_textbox.MaxLength = 250;
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(264, 43);
            this.name_textbox.TabIndex = 1;
            this.name_textbox.Tag = "1";
            this.name_textbox.Leave += new System.EventHandler(this.text_control_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.save_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 144);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 9, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(264, 69);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_button.AutoSize = true;
            this.cancel_button.CausesValidation = false;
            this.cancel_button.Location = new System.Drawing.Point(28, 6);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(6);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(100, 48);
            this.cancel_button.TabIndex = 3;
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
            this.save_button.Location = new System.Drawing.Point(140, 6);
            this.save_button.Margin = new System.Windows.Forms.Padding(6);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(100, 48);
            this.save_button.TabIndex = 2;
            this.save_button.Text = "ذخیره";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // name_errorProvider
            // 
            this.name_errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.name_errorProvider.ContainerControl = this;
            this.name_errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("name_errorProvider.Icon")));
            this.name_errorProvider.RightToLeft = true;
            // 
            // ProvinceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(392, 216);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 265);
            this.MinimumSize = new System.Drawing.Size(410, 265);
            this.Name = "ProvinceForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.name_errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Label name_lable;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ErrorProvider name_errorProvider;
        private System.Windows.Forms.TextBox id_textbox;
        private System.Windows.Forms.Label id_lable;
    }
}