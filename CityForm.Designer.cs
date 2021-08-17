namespace PadraInsurancePrescription
{
    partial class CityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CityForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.id_textbox = new System.Windows.Forms.TextBox();
            this.id_lable = new System.Windows.Forms.Label();
            this.name_lable = new System.Windows.Forms.Label();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.province_label = new System.Windows.Forms.Label();
            this.province_combobox = new System.Windows.Forms.ComboBox();
            this.provinceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.name_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.province_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.provinceTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.ProvinceTableAdapter();
            this.main_tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.name_errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.province_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 4;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.main_tableLayoutPanel.Controls.Add(this.id_textbox, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.id_lable, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.name_lable, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.name_textbox, 2, 3);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 2, 4);
            this.main_tableLayoutPanel.Controls.Add(this.province_label, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.province_combobox, 2, 2);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 6;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(413, 290);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // id_textbox
            // 
            this.id_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_textbox.Enabled = false;
            this.id_textbox.Location = new System.Drawing.Point(68, 34);
            this.id_textbox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.id_textbox.MaxLength = 250;
            this.id_textbox.Name = "id_textbox";
            this.id_textbox.Size = new System.Drawing.Size(264, 34);
            this.id_textbox.TabIndex = 0;
            this.id_textbox.Tag = "0";
            // 
            // id_lable
            // 
            this.id_lable.AutoSize = true;
            this.id_lable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_lable.Location = new System.Drawing.Point(340, 28);
            this.id_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.id_lable.Name = "id_lable";
            this.id_lable.Size = new System.Drawing.Size(59, 46);
            this.id_lable.TabIndex = 1;
            this.id_lable.Text = "شناسه:";
            this.id_lable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name_lable
            // 
            this.name_lable.AutoSize = true;
            this.name_lable.BackColor = System.Drawing.Color.Transparent;
            this.name_lable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_lable.ForeColor = System.Drawing.Color.Black;
            this.name_lable.Location = new System.Drawing.Point(340, 107);
            this.name_lable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name_lable.Name = "name_lable";
            this.name_lable.Size = new System.Drawing.Size(59, 46);
            this.name_lable.TabIndex = 6;
            this.name_lable.Text = "نام شهر :";
            this.name_lable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name_textbox
            // 
            this.name_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_textbox.Location = new System.Drawing.Point(68, 113);
            this.name_textbox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.name_textbox.MaxLength = 250;
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(264, 34);
            this.name_textbox.TabIndex = 2;
            this.name_textbox.Tag = "2";
            this.name_textbox.Leave += new System.EventHandler(this.text_control_Leave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.save_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(68, 159);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 10, 0);
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
            // province_label
            // 
            this.province_label.AutoSize = true;
            this.province_label.BackColor = System.Drawing.Color.Transparent;
            this.province_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.province_label.ForeColor = System.Drawing.Color.Black;
            this.province_label.Location = new System.Drawing.Point(340, 74);
            this.province_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.province_label.Name = "province_label";
            this.province_label.Size = new System.Drawing.Size(59, 33);
            this.province_label.TabIndex = 11;
            this.province_label.Text = "استان :";
            this.province_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // province_combobox
            // 
            this.province_combobox.DataSource = this.provinceBindingSource;
            this.province_combobox.DisplayMember = "name";
            this.province_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.province_combobox.FormattingEnabled = true;
            this.province_combobox.Location = new System.Drawing.Point(68, 80);
            this.province_combobox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.province_combobox.Name = "province_combobox";
            this.province_combobox.Size = new System.Drawing.Size(264, 35);
            this.province_combobox.TabIndex = 1;
            this.province_combobox.Tag = "1";
            this.province_combobox.ValueMember = "id";
            this.province_combobox.SelectedIndexChanged += new System.EventHandler(this.combobox_control_SelectedIndexChanged);
            // 
            // provinceBindingSource
            // 
            this.provinceBindingSource.DataMember = "Province";
            this.provinceBindingSource.DataSource = this.pIPDataSet;
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.EnforceConstraints = false;
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // name_errorProvider
            // 
            this.name_errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.name_errorProvider.ContainerControl = this;
            this.name_errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("name_errorProvider.Icon")));
            this.name_errorProvider.RightToLeft = true;
            // 
            // province_errorProvider
            // 
            this.province_errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.province_errorProvider.ContainerControl = this;
            this.province_errorProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("province_errorProvider.Icon")));
            this.province_errorProvider.RightToLeft = true;
            // 
            // provinceTableAdapter
            // 
            this.provinceTableAdapter.ClearBeforeFill = true;
            // 
            // CityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(413, 290);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "CityForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.name_errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.province_errorProvider)).EndInit();
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
        private System.Windows.Forms.Label province_label;
        private System.Windows.Forms.ComboBox province_combobox;
        private System.Windows.Forms.ErrorProvider province_errorProvider;
        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.BindingSource provinceBindingSource;
        private PIPDataSetTableAdapters.ProvinceTableAdapter provinceTableAdapter;
    }
}