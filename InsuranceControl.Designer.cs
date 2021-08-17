namespace PadraInsurancePrescription
{
    partial class InsuranceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.delete_button = new System.Windows.Forms.Button();
            this.id_text = new System.Windows.Forms.TextBox();
            this.tag_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.insurance_grid = new System.Windows.Forms.DataGridView();
            this.insuranceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.search_button = new System.Windows.Forms.Button();
            this.insuranceTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.InsuranceTableAdapter();
            this.i_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.i_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_tag_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_national_code_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_logo_image_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.i_boss_sentence_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_organization_sentence_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_allow_modify_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.i_separate_cd_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.i_separate_report_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insurance_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel.Controls.Add(this.delete_button, 5, 7);
            this.tableLayoutPanel.Controls.Add(this.id_text, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.tag_text, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.insurance_grid, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 5, 6);
            this.tableLayoutPanel.Controls.Add(this.new_button, 5, 5);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.search_button, 3, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(966, 589);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // delete_button
            // 
            this.delete_button.AutoSize = true;
            this.delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete_button.Location = new System.Drawing.Point(3, 192);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(162, 34);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // id_text
            // 
            this.id_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_text.Location = new System.Drawing.Point(703, 29);
            this.id_text.MaxLength = 10;
            this.id_text.Name = "id_text";
            this.id_text.Size = new System.Drawing.Size(134, 20);
            this.id_text.TabIndex = 3;
            // 
            // tag_text
            // 
            this.tag_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tag_text.Location = new System.Drawing.Point(373, 3);
            this.tag_text.MaxLength = 250;
            this.tag_text.Name = "tag_text";
            this.tag_text.Size = new System.Drawing.Size(170, 20);
            this.tag_text.TabIndex = 1;
            // 
            // name_text
            // 
            this.name_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_text.Location = new System.Drawing.Point(703, 3);
            this.name_text.MaxLength = 250;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(134, 20);
            this.name_text.TabIndex = 0;
            // 
            // insurance_grid
            // 
            this.insurance_grid.AllowUserToAddRows = false;
            this.insurance_grid.AllowUserToDeleteRows = false;
            this.insurance_grid.AutoGenerateColumns = false;
            this.insurance_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.insurance_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.insurance_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insurance_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.i_select_column,
            this.i_id_column,
            this.i_name_column,
            this.i_tag_column,
            this.i_national_code_column,
            this.i_logo_image_column,
            this.i_boss_sentence_column,
            this.i_organization_sentence_column,
            this.i_description_column,
            this.i_allow_modify_column,
            this.i_separate_cd_column,
            this.i_separate_report_column});
            this.tableLayoutPanel.SetColumnSpan(this.insurance_grid, 5);
            this.insurance_grid.DataSource = this.insuranceBindingSource;
            this.insurance_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insurance_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.insurance_grid.Location = new System.Drawing.Point(171, 75);
            this.insurance_grid.MultiSelect = false;
            this.insurance_grid.Name = "insurance_grid";
            this.insurance_grid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.insurance_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.insurance_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.insurance_grid, 5);
            this.insurance_grid.RowTemplate.Height = 100;
            this.insurance_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.insurance_grid.ShowCellErrors = false;
            this.insurance_grid.ShowCellToolTips = false;
            this.insurance_grid.Size = new System.Drawing.Size(792, 411);
            this.insurance_grid.TabIndex = 5;
            this.insurance_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.insurance_grid_DataBindingComplete);
            // 
            // insuranceBindingSource
            // 
            this.insuranceBindingSource.DataMember = "Insurance";
            this.insuranceBindingSource.DataSource = this.pIPDataSet;
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.EnforceConstraints = false;
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // edit_button
            // 
            this.edit_button.AutoSize = true;
            this.edit_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit_button.Location = new System.Drawing.Point(3, 151);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(162, 35);
            this.edit_button.TabIndex = 7;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(3, 110);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(162, 35);
            this.new_button.TabIndex = 6;
            this.new_button.Text = "ایجاد بیمه جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(843, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "نام :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(549, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 26);
            this.label1.TabIndex = 23;
            this.label1.Text = "برچسب انگلیسی :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(843, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 26);
            this.label4.TabIndex = 25;
            this.label4.Text = "شناسه :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search_button
            // 
            this.search_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(373, 29);
            this.search_button.Name = "search_button";
            this.tableLayoutPanel.SetRowSpan(this.search_button, 2);
            this.search_button.Size = new System.Drawing.Size(70, 23);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // insuranceTableAdapter
            // 
            this.insuranceTableAdapter.ClearBeforeFill = true;
            // 
            // i_select_column
            // 
            this.i_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.i_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.i_select_column.FalseValue = "false";
            this.i_select_column.Frozen = true;
            this.i_select_column.HeaderText = "";
            this.i_select_column.IndeterminateValue = "false";
            this.i_select_column.MinimumWidth = 30;
            this.i_select_column.Name = "i_select_column";
            this.i_select_column.ReadOnly = true;
            this.i_select_column.TrueValue = "true";
            this.i_select_column.Width = 30;
            // 
            // i_id_column
            // 
            this.i_id_column.DataPropertyName = "id";
            this.i_id_column.HeaderText = "شناسه";
            this.i_id_column.Name = "i_id_column";
            this.i_id_column.ReadOnly = true;
            this.i_id_column.Width = 67;
            // 
            // i_name_column
            // 
            this.i_name_column.DataPropertyName = "name";
            this.i_name_column.HeaderText = "نام";
            this.i_name_column.Name = "i_name_column";
            this.i_name_column.ReadOnly = true;
            this.i_name_column.Width = 47;
            // 
            // i_tag_column
            // 
            this.i_tag_column.DataPropertyName = "tag";
            this.i_tag_column.HeaderText = "برچسب انگلیسی";
            this.i_tag_column.Name = "i_tag_column";
            this.i_tag_column.ReadOnly = true;
            this.i_tag_column.Width = 117;
            // 
            // i_national_code_column
            // 
            this.i_national_code_column.DataPropertyName = "national_code";
            this.i_national_code_column.HeaderText = "شناسه ملی";
            this.i_national_code_column.Name = "i_national_code_column";
            this.i_national_code_column.ReadOnly = true;
            this.i_national_code_column.Width = 88;
            // 
            // i_logo_image_column
            // 
            this.i_logo_image_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.i_logo_image_column.DataPropertyName = "logo_image";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.NullValue = "بدون عکس";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.i_logo_image_column.DefaultCellStyle = dataGridViewCellStyle3;
            this.i_logo_image_column.HeaderText = "لوگو/آرم";
            this.i_logo_image_column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.i_logo_image_column.MinimumWidth = 100;
            this.i_logo_image_column.Name = "i_logo_image_column";
            this.i_logo_image_column.ReadOnly = true;
            this.i_logo_image_column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.i_logo_image_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // i_boss_sentence_column
            // 
            this.i_boss_sentence_column.DataPropertyName = "boss_sentence";
            this.i_boss_sentence_column.HeaderText = "جمله معرفی ریاست/مدیر";
            this.i_boss_sentence_column.Name = "i_boss_sentence_column";
            this.i_boss_sentence_column.ReadOnly = true;
            this.i_boss_sentence_column.Width = 145;
            // 
            // i_organization_sentence_column
            // 
            this.i_organization_sentence_column.DataPropertyName = "organization_sentence";
            this.i_organization_sentence_column.HeaderText = "جمله معرفی سازمان بیمه گر";
            this.i_organization_sentence_column.Name = "i_organization_sentence_column";
            this.i_organization_sentence_column.ReadOnly = true;
            this.i_organization_sentence_column.Width = 127;
            // 
            // i_description_column
            // 
            this.i_description_column.DataPropertyName = "description";
            this.i_description_column.HeaderText = "توضیحات";
            this.i_description_column.Name = "i_description_column";
            this.i_description_column.ReadOnly = true;
            this.i_description_column.Width = 86;
            // 
            // i_allow_modify_column
            // 
            this.i_allow_modify_column.DataPropertyName = "allow_modify";
            this.i_allow_modify_column.HeaderText = "allow_modify";
            this.i_allow_modify_column.Name = "i_allow_modify_column";
            this.i_allow_modify_column.ReadOnly = true;
            this.i_allow_modify_column.Visible = false;
            this.i_allow_modify_column.Width = 105;
            // 
            // i_separate_cd_column
            // 
            this.i_separate_cd_column.DataPropertyName = "separate_cd";
            this.i_separate_cd_column.HeaderText = "separate_cd";
            this.i_separate_cd_column.Name = "i_separate_cd_column";
            this.i_separate_cd_column.ReadOnly = true;
            this.i_separate_cd_column.Visible = false;
            this.i_separate_cd_column.Width = 104;
            // 
            // i_separate_report_column
            // 
            this.i_separate_report_column.DataPropertyName = "separate_report";
            this.i_separate_report_column.HeaderText = "separate_report";
            this.i_separate_report_column.Name = "i_separate_report_column";
            this.i_separate_report_column.ReadOnly = true;
            this.i_separate_report_column.Visible = false;
            this.i_separate_report_column.Width = 129;
            // 
            // InsuranceControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "InsuranceControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(966, 589);
            this.Tag = "پزشک ها";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insurance_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView insurance_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tag_text;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.BindingSource insuranceBindingSource;
        private PIPDataSetTableAdapters.InsuranceTableAdapter insuranceTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn i_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_tag_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_national_code_column;
        private System.Windows.Forms.DataGridViewImageColumn i_logo_image_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_boss_sentence_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_organization_sentence_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_description_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn i_allow_modify_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn i_separate_cd_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn i_separate_report_column;
    }
}
