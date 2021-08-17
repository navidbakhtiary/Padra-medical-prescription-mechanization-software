namespace PadraInsurancePrescription
{
    partial class ClinicPartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicPartForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.description_checkbox = new System.Windows.Forms.CheckBox();
            this.clear_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.clinic_type_label = new System.Windows.Forms.Label();
            this.tag_label = new System.Windows.Forms.Label();
            this.tag_textbox = new System.Windows.Forms.TextBox();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.id_textbox = new System.Windows.Forms.TextBox();
            this.id_lable = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.description_label = new System.Windows.Forms.Label();
            this.description_textbox = new System.Windows.Forms.TextBox();
            this.id_checkbox = new System.Windows.Forms.CheckBox();
            this.name_checkbox = new System.Windows.Forms.CheckBox();
            this.clinic_type_checkbox = new System.Windows.Forms.CheckBox();
            this.tag_checkbox = new System.Windows.Forms.CheckBox();
            this.clinic_type_combobox = new System.Windows.Forms.ComboBox();
            this.EP_name = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_clinic_type = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_description = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_tag = new System.Windows.Forms.ErrorProvider(this.components);
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_clinic_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_description)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_tag)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 3;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Controls.Add(this.description_checkbox, 2, 5);
            this.main_tableLayoutPanel.Controls.Add(this.clear_label, 2, 0);
            this.main_tableLayoutPanel.Controls.Add(this.name_label, 0, 2);
            this.main_tableLayoutPanel.Controls.Add(this.clinic_type_label, 0, 3);
            this.main_tableLayoutPanel.Controls.Add(this.tag_label, 0, 4);
            this.main_tableLayoutPanel.Controls.Add(this.tag_textbox, 1, 4);
            this.main_tableLayoutPanel.Controls.Add(this.name_textbox, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.id_textbox, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.id_lable, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.main_tableLayoutPanel.Controls.Add(this.description_label, 0, 5);
            this.main_tableLayoutPanel.Controls.Add(this.description_textbox, 1, 5);
            this.main_tableLayoutPanel.Controls.Add(this.id_checkbox, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.name_checkbox, 2, 2);
            this.main_tableLayoutPanel.Controls.Add(this.clinic_type_checkbox, 2, 3);
            this.main_tableLayoutPanel.Controls.Add(this.tag_checkbox, 2, 4);
            this.main_tableLayoutPanel.Controls.Add(this.clinic_type_combobox, 1, 3);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 7;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(633, 508);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // description_checkbox
            // 
            this.description_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description_checkbox.AutoSize = true;
            this.description_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.description_checkbox.Enabled = false;
            this.description_checkbox.Location = new System.Drawing.Point(3, 273);
            this.description_checkbox.Name = "description_checkbox";
            this.description_checkbox.Size = new System.Drawing.Size(193, 91);
            this.description_checkbox.TabIndex = 21;
            this.description_checkbox.TabStop = false;
            this.description_checkbox.Tag = "4";
            this.description_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.description_checkbox.UseVisualStyleBackColor = true;
            this.description_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
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
            this.clear_label.Size = new System.Drawing.Size(187, 49);
            this.clear_label.TabIndex = 40;
            this.clear_label.Text = "پاک کردن اطلاعات";
            this.clear_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clear_label.Visible = false;
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.ForeColor = System.Drawing.Color.Black;
            this.name_label.Location = new System.Drawing.Point(481, 104);
            this.name_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(88, 55);
            this.name_label.TabIndex = 32;
            this.name_label.Tag = "1";
            this.name_label.Text = "نام بخش :";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clinic_type_label
            // 
            this.clinic_type_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clinic_type_label.AutoSize = true;
            this.clinic_type_label.BackColor = System.Drawing.Color.Transparent;
            this.clinic_type_label.ForeColor = System.Drawing.Color.Black;
            this.clinic_type_label.Location = new System.Drawing.Point(481, 159);
            this.clinic_type_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.clinic_type_label.Name = "clinic_type_label";
            this.clinic_type_label.Size = new System.Drawing.Size(146, 56);
            this.clinic_type_label.TabIndex = 31;
            this.clinic_type_label.Tag = "2";
            this.clinic_type_label.Text = "نوع مرکز درمانی :";
            this.clinic_type_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tag_label
            // 
            this.tag_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tag_label.AutoSize = true;
            this.tag_label.BackColor = System.Drawing.Color.Transparent;
            this.tag_label.ForeColor = System.Drawing.Color.Black;
            this.tag_label.Location = new System.Drawing.Point(481, 215);
            this.tag_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tag_label.Name = "tag_label";
            this.tag_label.Size = new System.Drawing.Size(128, 55);
            this.tag_label.TabIndex = 28;
            this.tag_label.Tag = "3";
            this.tag_label.Text = "عنوان انگلیسی :";
            this.tag_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tag_textbox
            // 
            this.tag_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tag_textbox.Enabled = false;
            this.tag_textbox.Location = new System.Drawing.Point(205, 221);
            this.tag_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.tag_textbox.MaxLength = 100;
            this.tag_textbox.Name = "tag_textbox";
            this.tag_textbox.Size = new System.Drawing.Size(264, 43);
            this.tag_textbox.TabIndex = 3;
            this.tag_textbox.Tag = "3";
            this.tag_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // name_textbox
            // 
            this.name_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_textbox.Enabled = false;
            this.name_textbox.Location = new System.Drawing.Point(205, 110);
            this.name_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.name_textbox.MaxLength = 250;
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(264, 43);
            this.name_textbox.TabIndex = 1;
            this.name_textbox.Tag = "1";
            this.name_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // id_textbox
            // 
            this.id_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_textbox.Enabled = false;
            this.id_textbox.Location = new System.Drawing.Point(205, 55);
            this.id_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.id_textbox.MaxLength = 250;
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.Size = new System.Drawing.Size(264, 43);
            this.id_textbox.TabIndex = 0;
            this.id_textbox.TabStop = false;
            this.id_textbox.Tag = "0";
            this.id_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // id_lable
            // 
            this.id_lable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_lable.AutoSize = true;
            this.id_lable.Location = new System.Drawing.Point(481, 49);
            this.id_lable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.id_lable.Name = "id_lable";
            this.id_lable.Size = new System.Drawing.Size(70, 55);
            this.id_lable.TabIndex = 1;
            this.id_lable.Tag = "0";
            this.id_lable.Text = "شناسه :";
            this.id_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.save_button);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(205, 373);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 9, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(264, 149);
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
            this.cancel_button.TabIndex = 6;
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
            this.save_button.TabIndex = 5;
            this.save_button.Text = "ذخیره";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // description_label
            // 
            this.description_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description_label.AutoSize = true;
            this.description_label.BackColor = System.Drawing.Color.Transparent;
            this.description_label.ForeColor = System.Drawing.Color.Black;
            this.description_label.Location = new System.Drawing.Point(481, 270);
            this.description_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(95, 97);
            this.description_label.TabIndex = 22;
            this.description_label.Tag = "4";
            this.description_label.Text = "توضیحات :";
            this.description_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // description_textbox
            // 
            this.description_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.description_textbox.Enabled = false;
            this.description_textbox.Location = new System.Drawing.Point(205, 276);
            this.description_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.description_textbox.MaxLength = 1000;
            this.description_textbox.Multiline = true;
            this.description_textbox.Name = "description_textbox";
            this.description_textbox.Size = new System.Drawing.Size(264, 85);
            this.description_textbox.TabIndex = 4;
            this.description_textbox.Tag = "4";
            this.description_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // id_checkbox
            // 
            this.id_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_checkbox.AutoSize = true;
            this.id_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.id_checkbox.Enabled = false;
            this.id_checkbox.Location = new System.Drawing.Point(3, 52);
            this.id_checkbox.Name = "id_checkbox";
            this.id_checkbox.Size = new System.Drawing.Size(193, 49);
            this.id_checkbox.TabIndex = 12;
            this.id_checkbox.TabStop = false;
            this.id_checkbox.Tag = "0";
            this.id_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.id_checkbox.UseVisualStyleBackColor = true;
            this.id_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // name_checkbox
            // 
            this.name_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_checkbox.AutoSize = true;
            this.name_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name_checkbox.Enabled = false;
            this.name_checkbox.Location = new System.Drawing.Point(3, 107);
            this.name_checkbox.Name = "name_checkbox";
            this.name_checkbox.Size = new System.Drawing.Size(193, 49);
            this.name_checkbox.TabIndex = 14;
            this.name_checkbox.TabStop = false;
            this.name_checkbox.Tag = "1";
            this.name_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name_checkbox.UseVisualStyleBackColor = true;
            this.name_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // clinic_type_checkbox
            // 
            this.clinic_type_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clinic_type_checkbox.AutoSize = true;
            this.clinic_type_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clinic_type_checkbox.Enabled = false;
            this.clinic_type_checkbox.Location = new System.Drawing.Point(3, 162);
            this.clinic_type_checkbox.Name = "clinic_type_checkbox";
            this.clinic_type_checkbox.Size = new System.Drawing.Size(193, 50);
            this.clinic_type_checkbox.TabIndex = 15;
            this.clinic_type_checkbox.TabStop = false;
            this.clinic_type_checkbox.Tag = "2";
            this.clinic_type_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.clinic_type_checkbox.UseVisualStyleBackColor = true;
            this.clinic_type_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // tag_checkbox
            // 
            this.tag_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tag_checkbox.AutoSize = true;
            this.tag_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tag_checkbox.Enabled = false;
            this.tag_checkbox.Location = new System.Drawing.Point(3, 218);
            this.tag_checkbox.Name = "tag_checkbox";
            this.tag_checkbox.Size = new System.Drawing.Size(193, 49);
            this.tag_checkbox.TabIndex = 19;
            this.tag_checkbox.TabStop = false;
            this.tag_checkbox.Tag = "3";
            this.tag_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tag_checkbox.UseVisualStyleBackColor = true;
            this.tag_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // clinic_type_combobox
            // 
            this.clinic_type_combobox.DisplayMember = "name";
            this.clinic_type_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clinic_type_combobox.DropDownHeight = 300;
            this.clinic_type_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clinic_type_combobox.Enabled = false;
            this.clinic_type_combobox.FormattingEnabled = true;
            this.clinic_type_combobox.IntegralHeight = false;
            this.clinic_type_combobox.Location = new System.Drawing.Point(203, 165);
            this.clinic_type_combobox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.clinic_type_combobox.Name = "clinic_type_combobox";
            this.clinic_type_combobox.Size = new System.Drawing.Size(268, 44);
            this.clinic_type_combobox.TabIndex = 2;
            this.clinic_type_combobox.Tag = "2";
            this.clinic_type_combobox.ValueMember = "id";
            this.clinic_type_combobox.SelectedIndexChanged += new System.EventHandler(this.combobox_control_SelectedIndexChanged);
            // 
            // EP_name
            // 
            this.EP_name.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_name.ContainerControl = this;
            this.EP_name.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_name.Icon")));
            this.EP_name.RightToLeft = true;
            // 
            // EP_clinic_type
            // 
            this.EP_clinic_type.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_clinic_type.ContainerControl = this;
            this.EP_clinic_type.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_clinic_type.Icon")));
            this.EP_clinic_type.RightToLeft = true;
            // 
            // EP_description
            // 
            this.EP_description.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_description.ContainerControl = this;
            this.EP_description.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_description.Icon")));
            this.EP_description.RightToLeft = true;
            // 
            // EP_tag
            // 
            this.EP_tag.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_tag.ContainerControl = this;
            this.EP_tag.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_tag.Icon")));
            this.EP_tag.RightToLeft = true;
            // 
            // ClinicPartForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 500);
            this.ClientSize = new System.Drawing.Size(633, 508);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "ClinicPartForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_clinic_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_description)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_tag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox id_textbox;
        private System.Windows.Forms.Label id_lable;
        private System.Windows.Forms.TextBox tag_textbox;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label clinic_type_label;
        private System.Windows.Forms.Label tag_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.TextBox description_textbox;
        private System.Windows.Forms.ErrorProvider EP_name;
        private System.Windows.Forms.ErrorProvider EP_clinic_type;
        private System.Windows.Forms.ErrorProvider EP_description;
        private System.Windows.Forms.Label clear_label;
        private System.Windows.Forms.CheckBox id_checkbox;
        private System.Windows.Forms.CheckBox description_checkbox;
        private System.Windows.Forms.CheckBox name_checkbox;
        private System.Windows.Forms.CheckBox clinic_type_checkbox;
        private System.Windows.Forms.CheckBox tag_checkbox;
        private System.Windows.Forms.ErrorProvider EP_tag;
        private System.Windows.Forms.ComboBox clinic_type_combobox;
    }
}