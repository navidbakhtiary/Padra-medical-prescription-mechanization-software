namespace PadraInsurancePrescription
{
    partial class MedicalCenterControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.delete_button = new System.Windows.Forms.Button();
            this.national_id_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.medical_center_grid = new System.Windows.Forms.DataGridView();
            this.m_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_type_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_national_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_province_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_city_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_address_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_phone_numbers_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_mobile_numbers_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_anwserable_names_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_type_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_city_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_province_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tMedicalCenterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.type_comboBox = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.tMedicalCenterTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TMedicalCenterTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medical_center_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalCenterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 8;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.Controls.Add(this.delete_button, 6, 5);
            this.tableLayoutPanel.Controls.Add(this.national_id_text, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.medical_center_grid, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 6, 4);
            this.tableLayoutPanel.Controls.Add(this.new_button, 6, 3);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.type_comboBox, 5, 0);
            this.tableLayoutPanel.Controls.Add(this.search_button, 6, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(966, 589);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // delete_button
            // 
            this.delete_button.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.delete_button, 2);
            this.delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete_button.Location = new System.Drawing.Point(3, 162);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(210, 34);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.m_delete_doctor_Click);
            // 
            // national_id_text
            // 
            this.national_id_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.national_id_text.Location = new System.Drawing.Point(469, 3);
            this.national_id_text.MaxLength = 10;
            this.national_id_text.Name = "national_id_text";
            this.national_id_text.Size = new System.Drawing.Size(154, 20);
            this.national_id_text.TabIndex = 1;
            // 
            // name_text
            // 
            this.name_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_text.Location = new System.Drawing.Point(719, 3);
            this.name_text.MaxLength = 250;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(154, 20);
            this.name_text.TabIndex = 0;
            // 
            // medical_center_grid
            // 
            this.medical_center_grid.AllowUserToAddRows = false;
            this.medical_center_grid.AllowUserToDeleteRows = false;
            this.medical_center_grid.AutoGenerateColumns = false;
            this.medical_center_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.medical_center_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.medical_center_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medical_center_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_select_column,
            this.m_id_column,
            this.m_type_name_column,
            this.m_national_id_column,
            this.m_name_column,
            this.m_province_name_column,
            this.m_city_name_column,
            this.m_address_column,
            this.m_phone_numbers_column,
            this.m_mobile_numbers_column,
            this.m_anwserable_names_column,
            this.m_description_column,
            this.m_type_id_column,
            this.m_city_id_column,
            this.m_province_id_column});
            this.tableLayoutPanel.SetColumnSpan(this.medical_center_grid, 6);
            this.medical_center_grid.DataSource = this.tMedicalCenterBindingSource;
            this.medical_center_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medical_center_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.medical_center_grid.Location = new System.Drawing.Point(219, 46);
            this.medical_center_grid.MultiSelect = false;
            this.medical_center_grid.Name = "medical_center_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.medical_center_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.medical_center_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.medical_center_grid, 6);
            this.medical_center_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.medical_center_grid.ShowCellErrors = false;
            this.medical_center_grid.ShowCellToolTips = false;
            this.medical_center_grid.Size = new System.Drawing.Size(744, 411);
            this.medical_center_grid.TabIndex = 5;
            this.medical_center_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.medical_center_grid_DataBindingComplete);
            // 
            // m_select_column
            // 
            this.m_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.m_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_select_column.FalseValue = "false";
            this.m_select_column.Frozen = true;
            this.m_select_column.HeaderText = "";
            this.m_select_column.IndeterminateValue = "false";
            this.m_select_column.MinimumWidth = 30;
            this.m_select_column.Name = "m_select_column";
            this.m_select_column.TrueValue = "true";
            this.m_select_column.Width = 30;
            // 
            // m_id_column
            // 
            this.m_id_column.DataPropertyName = "id";
            this.m_id_column.HeaderText = "شناسه";
            this.m_id_column.Name = "m_id_column";
            this.m_id_column.ReadOnly = true;
            this.m_id_column.Width = 67;
            // 
            // m_type_name_column
            // 
            this.m_type_name_column.DataPropertyName = "clinic_type_name";
            this.m_type_name_column.HeaderText = "نوع مرکز";
            this.m_type_name_column.Name = "m_type_name_column";
            this.m_type_name_column.ReadOnly = true;
            this.m_type_name_column.Width = 78;
            // 
            // m_national_id_column
            // 
            this.m_national_id_column.DataPropertyName = "national_id";
            this.m_national_id_column.HeaderText = "شناسه ملی";
            this.m_national_id_column.Name = "m_national_id_column";
            this.m_national_id_column.ReadOnly = true;
            this.m_national_id_column.Width = 81;
            // 
            // m_name_column
            // 
            this.m_name_column.DataPropertyName = "name";
            this.m_name_column.HeaderText = "نام";
            this.m_name_column.Name = "m_name_column";
            this.m_name_column.ReadOnly = true;
            this.m_name_column.Width = 47;
            // 
            // m_province_name_column
            // 
            this.m_province_name_column.DataPropertyName = "province_name";
            this.m_province_name_column.HeaderText = "استان";
            this.m_province_name_column.Name = "m_province_name_column";
            this.m_province_name_column.ReadOnly = true;
            this.m_province_name_column.Width = 63;
            // 
            // m_city_name_column
            // 
            this.m_city_name_column.DataPropertyName = "city_name";
            this.m_city_name_column.HeaderText = "شهر";
            this.m_city_name_column.Name = "m_city_name_column";
            this.m_city_name_column.ReadOnly = true;
            this.m_city_name_column.Width = 57;
            // 
            // m_address_column
            // 
            this.m_address_column.DataPropertyName = "address";
            this.m_address_column.HeaderText = "آدرس";
            this.m_address_column.Name = "m_address_column";
            this.m_address_column.ReadOnly = true;
            this.m_address_column.Width = 64;
            // 
            // m_phone_numbers_column
            // 
            this.m_phone_numbers_column.DataPropertyName = "phone_numbers";
            this.m_phone_numbers_column.HeaderText = "شماره های تلفن ثابت";
            this.m_phone_numbers_column.Name = "m_phone_numbers_column";
            this.m_phone_numbers_column.ReadOnly = true;
            this.m_phone_numbers_column.Width = 108;
            // 
            // m_mobile_numbers_column
            // 
            this.m_mobile_numbers_column.DataPropertyName = "mobile_numbers";
            this.m_mobile_numbers_column.HeaderText = "شماره های تلفن همراه";
            this.m_mobile_numbers_column.Name = "m_mobile_numbers_column";
            this.m_mobile_numbers_column.ReadOnly = true;
            this.m_mobile_numbers_column.Width = 108;
            // 
            // m_anwserable_names_column
            // 
            this.m_anwserable_names_column.DataPropertyName = "anwserable_names";
            this.m_anwserable_names_column.HeaderText = "نام های افراد مسئول";
            this.m_anwserable_names_column.Name = "m_anwserable_names_column";
            this.m_anwserable_names_column.ReadOnly = true;
            this.m_anwserable_names_column.Width = 96;
            // 
            // m_description_column
            // 
            this.m_description_column.DataPropertyName = "description";
            this.m_description_column.HeaderText = "توضیحات";
            this.m_description_column.Name = "m_description_column";
            this.m_description_column.ReadOnly = true;
            this.m_description_column.Width = 86;
            // 
            // m_type_id_column
            // 
            this.m_type_id_column.DataPropertyName = "clinic_type";
            this.m_type_id_column.HeaderText = "clinic_type";
            this.m_type_id_column.Name = "m_type_id_column";
            this.m_type_id_column.ReadOnly = true;
            this.m_type_id_column.Visible = false;
            this.m_type_id_column.Width = 107;
            // 
            // m_city_id_column
            // 
            this.m_city_id_column.DataPropertyName = "city";
            this.m_city_id_column.HeaderText = "city";
            this.m_city_id_column.Name = "m_city_id_column";
            this.m_city_id_column.ReadOnly = true;
            this.m_city_id_column.Visible = false;
            this.m_city_id_column.Width = 57;
            // 
            // m_province_id_column
            // 
            this.m_province_id_column.DataPropertyName = "province";
            this.m_province_id_column.HeaderText = "province";
            this.m_province_id_column.Name = "m_province_id_column";
            this.m_province_id_column.ReadOnly = true;
            this.m_province_id_column.Visible = false;
            this.m_province_id_column.Width = 93;
            // 
            // tMedicalCenterBindingSource
            // 
            this.tMedicalCenterBindingSource.DataMember = "TMedicalCenter";
            this.tMedicalCenterBindingSource.DataSource = this.pIPDataSet;
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
            this.tableLayoutPanel.SetColumnSpan(this.edit_button, 2);
            this.edit_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edit_button.Location = new System.Drawing.Point(3, 122);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(210, 34);
            this.edit_button.TabIndex = 7;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.m_edit_button_Click);
            // 
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.new_button, 2);
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(3, 81);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(210, 35);
            this.new_button.TabIndex = 6;
            this.new_button.Text = "ایجاد مرکز جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.m_new_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(879, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "نام مرکز :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(379, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "نوع مرکز :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(629, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 33);
            this.label1.TabIndex = 23;
            this.label1.Text = "شناسه ملی :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // type_comboBox
            // 
            this.type_comboBox.DropDownHeight = 300;
            this.type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_comboBox.FormattingEnabled = true;
            this.type_comboBox.IntegralHeight = false;
            this.type_comboBox.Location = new System.Drawing.Point(219, 3);
            this.type_comboBox.Name = "type_comboBox";
            this.type_comboBox.Size = new System.Drawing.Size(154, 21);
            this.type_comboBox.TabIndex = 2;
            // 
            // search_button
            // 
            this.search_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(129, 3);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(70, 27);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.m_search_button_Click);
            // 
            // tMedicalCenterTableAdapter
            // 
            this.tMedicalCenterTableAdapter.ClearBeforeFill = true;
            // 
            // MedicalCenterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MedicalCenterControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(966, 589);
            this.Tag = "مراکز درمانی";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medical_center_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalCenterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView medical_center_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox national_id_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox type_comboBox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.BindingSource tMedicalCenterBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.TMedicalCenterTableAdapter tMedicalCenterTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_type_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_national_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_province_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_city_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_address_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_phone_numbers_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_mobile_numbers_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_anwserable_names_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_description_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_type_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_city_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_province_id_column;
    }
}
