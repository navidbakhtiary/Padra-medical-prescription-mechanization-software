namespace PadraInsurancePrescription
{
    partial class MedicineDegreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicineDegreeForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.description_checkbox = new System.Windows.Forms.CheckBox();
            this.clear_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
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
            this.EP_name = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_description = new System.Windows.Forms.ErrorProvider(this.components);
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_description)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 3;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Controls.Add(this.description_checkbox, 2, 3);
            this.main_tableLayoutPanel.Controls.Add(this.clear_label, 2, 0);
            this.main_tableLayoutPanel.Controls.Add(this.name_label, 0, 2);
            this.main_tableLayoutPanel.Controls.Add(this.name_textbox, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.id_textbox, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.id_lable, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.main_tableLayoutPanel.Controls.Add(this.description_label, 0, 3);
            this.main_tableLayoutPanel.Controls.Add(this.description_textbox, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.id_checkbox, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.name_checkbox, 2, 2);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 6;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(603, 344);
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
            this.description_checkbox.Location = new System.Drawing.Point(3, 123);
            this.description_checkbox.Name = "description_checkbox";
            this.description_checkbox.Size = new System.Drawing.Size(240, 91);
            this.description_checkbox.TabIndex = 7;
            this.description_checkbox.Tag = "2";
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
            this.clear_label.Size = new System.Drawing.Size(234, 28);
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
            this.name_label.Location = new System.Drawing.Point(528, 74);
            this.name_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(33, 46);
            this.name_label.TabIndex = 32;
            this.name_label.Text = "نام :";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_textbox
            // 
            this.name_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.name_textbox.Enabled = false;
            this.name_textbox.Location = new System.Drawing.Point(252, 80);
            this.name_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.name_textbox.MaxLength = 250;
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(264, 34);
            this.name_textbox.TabIndex = 1;
            this.name_textbox.Tag = "1";
            this.name_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // id_textbox
            // 
            this.id_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.id_textbox.Enabled = false;
            this.id_textbox.Location = new System.Drawing.Point(252, 34);
            this.id_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.id_textbox.MaxLength = 250;
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.Size = new System.Drawing.Size(264, 34);
            this.id_textbox.TabIndex = 0;
            this.id_textbox.Tag = "0";
            this.id_textbox.Leave += new System.EventHandler(this.textbox_control_Leave);
            // 
            // id_lable
            // 
            this.id_lable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.id_lable.AutoSize = true;
            this.id_lable.Location = new System.Drawing.Point(528, 28);
            this.id_lable.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.id_lable.Name = "id_lable";
            this.id_lable.Size = new System.Drawing.Size(52, 46);
            this.id_lable.TabIndex = 1;
            this.id_lable.Text = "شناسه :";
            this.id_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.save_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(252, 223);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 9, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(264, 69);
            this.flowLayoutPanel1.TabIndex = 34;
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
            this.save_button.Location = new System.Drawing.Point(140, 6);
            this.save_button.Margin = new System.Windows.Forms.Padding(6);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(100, 48);
            this.save_button.TabIndex = 3;
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
            this.description_label.Location = new System.Drawing.Point(528, 120);
            this.description_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.description_label.Name = "description_label";
            this.description_label.Size = new System.Drawing.Size(69, 97);
            this.description_label.TabIndex = 22;
            this.description_label.Text = "توضیحات :";
            this.description_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // description_textbox
            // 
            this.description_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.description_textbox.Enabled = false;
            this.description_textbox.Location = new System.Drawing.Point(252, 126);
            this.description_textbox.Margin = new System.Windows.Forms.Padding(6);
            this.description_textbox.MaxLength = 1000;
            this.description_textbox.Multiline = true;
            this.description_textbox.Name = "description_textbox";
            this.description_textbox.Size = new System.Drawing.Size(264, 85);
            this.description_textbox.TabIndex = 2;
            this.description_textbox.Tag = "2";
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
            this.id_checkbox.Location = new System.Drawing.Point(3, 31);
            this.id_checkbox.Name = "id_checkbox";
            this.id_checkbox.Size = new System.Drawing.Size(240, 40);
            this.id_checkbox.TabIndex = 5;
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
            this.name_checkbox.Location = new System.Drawing.Point(3, 77);
            this.name_checkbox.Name = "name_checkbox";
            this.name_checkbox.Size = new System.Drawing.Size(240, 40);
            this.name_checkbox.TabIndex = 6;
            this.name_checkbox.Tag = "1";
            this.name_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.name_checkbox.UseVisualStyleBackColor = true;
            this.name_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // EP_name
            // 
            this.EP_name.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_name.ContainerControl = this;
            this.EP_name.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_name.Icon")));
            this.EP_name.RightToLeft = true;
            // 
            // EP_description
            // 
            this.EP_description.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_description.ContainerControl = this;
            this.EP_description.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_description.Icon")));
            this.EP_description.RightToLeft = true;
            // 
            // MedicineDegreeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(603, 348);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MedicineDegreeForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_description)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox id_textbox;
        private System.Windows.Forms.Label id_lable;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label description_label;
        private System.Windows.Forms.TextBox description_textbox;
        private System.Windows.Forms.ErrorProvider EP_name;
        private System.Windows.Forms.ErrorProvider EP_description;
        private System.Windows.Forms.Label clear_label;
        private System.Windows.Forms.CheckBox id_checkbox;
        private System.Windows.Forms.CheckBox description_checkbox;
        private System.Windows.Forms.CheckBox name_checkbox;
    }
}