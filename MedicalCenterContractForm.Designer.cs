namespace PadraInsurancePrescription
{
    partial class MedicalCenterContractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalCenterContractForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.center_label = new System.Windows.Forms.Label();
            this.center_checkbox = new System.Windows.Forms.CheckBox();
            this.clear_label = new System.Windows.Forms.Label();
            this.id_lable = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.center_textbox = new System.Windows.Forms.TextBox();
            this.specific_id_checkbox = new System.Windows.Forms.CheckBox();
            this.specific_id_textbox = new System.Windows.Forms.TextBox();
            this.EP_specific_id = new System.Windows.Forms.ErrorProvider(this.components);
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_specific_id)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 3;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.Controls.Add(this.center_label, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.center_checkbox, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.clear_label, 2, 0);
            this.main_tableLayoutPanel.Controls.Add(this.id_lable, 0, 2);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.center_textbox, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.specific_id_checkbox, 2, 2);
            this.main_tableLayoutPanel.Controls.Add(this.specific_id_textbox, 1, 2);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 4;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(855, 207);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // center_label
            // 
            this.center_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.center_label.AutoSize = true;
            this.center_label.Location = new System.Drawing.Point(455, 28);
            this.center_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.center_label.Name = "center_label";
            this.center_label.Size = new System.Drawing.Size(210, 55);
            this.center_label.TabIndex = 44;
            this.center_label.Text = "مرکز درمانی انتخاب شده :";
            this.center_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // center_checkbox
            // 
            this.center_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.center_checkbox.AutoSize = true;
            this.center_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.center_checkbox.Enabled = false;
            this.center_checkbox.Location = new System.Drawing.Point(3, 31);
            this.center_checkbox.Name = "center_checkbox";
            this.center_checkbox.Size = new System.Drawing.Size(187, 49);
            this.center_checkbox.TabIndex = 4;
            this.center_checkbox.Tag = "0";
            this.center_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.center_checkbox.UseVisualStyleBackColor = true;
            this.center_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // clear_label
            // 
            this.clear_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clear_label.AutoSize = true;
            this.clear_label.Location = new System.Drawing.Point(6, 0);
            this.clear_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.clear_label.Name = "clear_label";
            this.clear_label.Size = new System.Drawing.Size(181, 28);
            this.clear_label.TabIndex = 42;
            this.clear_label.Text = "پاک کردن اطلاعات";
            this.clear_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clear_label.Visible = false;
            // 
            // id_lable
            // 
            this.id_lable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_lable.AutoSize = true;
            this.id_lable.Location = new System.Drawing.Point(455, 83);
            this.id_lable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.id_lable.Name = "id_lable";
            this.id_lable.Size = new System.Drawing.Size(394, 55);
            this.id_lable.TabIndex = 1;
            this.id_lable.Text = "شناسه اختصاصی مرکز درمانی در صندوق های بیمه :";
            this.id_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.save_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(199, 144);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 9, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 69);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // cancel_button
            // 
            this.cancel_button.AutoSize = true;
            this.cancel_button.CausesValidation = false;
            this.cancel_button.Location = new System.Drawing.Point(28, 6);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(6);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(84, 48);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // save_button
            // 
            this.save_button.AutoSize = true;
            this.save_button.CausesValidation = false;
            this.save_button.Location = new System.Drawing.Point(124, 6);
            this.save_button.Margin = new System.Windows.Forms.Padding(6);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(86, 48);
            this.save_button.TabIndex = 2;
            this.save_button.Text = "ذخیره";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // center_textbox
            // 
            this.center_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.center_textbox.Enabled = false;
            this.center_textbox.Location = new System.Drawing.Point(203, 34);
            this.center_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.center_textbox.MaxLength = 250;
            this.center_textbox.Name = "center_textbox";
            this.center_textbox.Size = new System.Drawing.Size(236, 43);
            this.center_textbox.TabIndex = 0;
            this.center_textbox.Tag = "0";
            this.center_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // specific_id_checkbox
            // 
            this.specific_id_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specific_id_checkbox.AutoSize = true;
            this.specific_id_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specific_id_checkbox.Enabled = false;
            this.specific_id_checkbox.Location = new System.Drawing.Point(3, 86);
            this.specific_id_checkbox.Name = "specific_id_checkbox";
            this.specific_id_checkbox.Size = new System.Drawing.Size(187, 49);
            this.specific_id_checkbox.TabIndex = 5;
            this.specific_id_checkbox.Tag = "1";
            this.specific_id_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specific_id_checkbox.UseVisualStyleBackColor = true;
            this.specific_id_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // specific_id_textbox
            // 
            this.specific_id_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.specific_id_textbox.Enabled = false;
            this.specific_id_textbox.Location = new System.Drawing.Point(203, 89);
            this.specific_id_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.specific_id_textbox.MaxLength = 20;
            this.specific_id_textbox.Name = "specific_id_textbox";
            this.specific_id_textbox.Size = new System.Drawing.Size(236, 43);
            this.specific_id_textbox.TabIndex = 1;
            this.specific_id_textbox.Tag = "1";
            this.specific_id_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // EP_specific_id
            // 
            this.EP_specific_id.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_specific_id.ContainerControl = this;
            this.EP_specific_id.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_specific_id.Icon")));
            this.EP_specific_id.RightToLeft = true;
            // 
            // MedicalCenterContractForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(855, 216);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MedicalCenterContractForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_specific_id)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.ErrorProvider EP_specific_id;
        private System.Windows.Forms.TextBox specific_id_textbox;
        private System.Windows.Forms.Label id_lable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label clear_label;
        private System.Windows.Forms.CheckBox specific_id_checkbox;
        private System.Windows.Forms.Label center_label;
        private System.Windows.Forms.CheckBox center_checkbox;
        private System.Windows.Forms.TextBox center_textbox;
    }
}