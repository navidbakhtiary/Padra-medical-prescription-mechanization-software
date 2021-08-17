namespace PadraInsurancePrescription
{
    partial class DoctorControl
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
            this.id_text = new System.Windows.Forms.TextBox();
            this.family_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.doctor_grid = new System.Windows.Forms.DataGridView();
            this.d_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_medical_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_family_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_degree_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_field_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_national_code_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_province_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_city_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_home_address_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_home_phone_numbers_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_mobile_numbers_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_secretary_names_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_secretary_phone_numbers_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_medicine_degree_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_medicine_field_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_province_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_home_city_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tDoctorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.degree_comboBox = new System.Windows.Forms.ComboBox();
            this.tMedicineDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.search_button = new System.Windows.Forms.Button();
            this.tDoctorTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TDoctorTableAdapter();
            this.tMedicineDegreeTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TMedicineDegreeTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctor_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDoctorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicineDegreeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel.Controls.Add(this.delete_button, 5, 7);
            this.tableLayoutPanel.Controls.Add(this.id_text, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.family_text, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.doctor_grid, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 5, 6);
            this.tableLayoutPanel.Controls.Add(this.new_button, 5, 5);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.degree_comboBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.search_button, 4, 1);
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
            this.delete_button.Location = new System.Drawing.Point(3, 193);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(162, 34);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.d_delete_doctor_Click);
            // 
            // id_text
            // 
            this.id_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_text.Location = new System.Drawing.Point(373, 29);
            this.id_text.MaxLength = 10;
            this.id_text.Name = "id_text";
            this.id_text.Size = new System.Drawing.Size(170, 20);
            this.id_text.TabIndex = 3;
            // 
            // family_text
            // 
            this.family_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.family_text.Location = new System.Drawing.Point(373, 3);
            this.family_text.MaxLength = 250;
            this.family_text.Name = "family_text";
            this.family_text.Size = new System.Drawing.Size(170, 20);
            this.family_text.TabIndex = 1;
            // 
            // name_text
            // 
            this.name_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_text.Location = new System.Drawing.Point(703, 3);
            this.name_text.MaxLength = 250;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(154, 20);
            this.name_text.TabIndex = 0;
            // 
            // doctor_grid
            // 
            this.doctor_grid.AllowUserToAddRows = false;
            this.doctor_grid.AllowUserToDeleteRows = false;
            this.doctor_grid.AutoGenerateColumns = false;
            this.doctor_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.doctor_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.doctor_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctor_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d_select_column,
            this.d_id_column,
            this.d_medical_id_column,
            this.d_name_column,
            this.d_family_name_column,
            this.gender_name,
            this.d_degree_name_column,
            this.d_field_name_column,
            this.d_national_code_column,
            this.d_province_name_column,
            this.d_city_name_column,
            this.d_home_address_column,
            this.d_home_phone_numbers_column,
            this.d_mobile_numbers_column,
            this.d_secretary_names_column,
            this.d_secretary_phone_numbers_column,
            this.gender_id,
            this.d_medicine_degree_column,
            this.d_medicine_field_column,
            this.d_province_id_column,
            this.d_home_city_column,
            this.d_description_column});
            this.tableLayoutPanel.SetColumnSpan(this.doctor_grid, 5);
            this.doctor_grid.DataSource = this.tDoctorBindingSource;
            this.doctor_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doctor_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.doctor_grid.Location = new System.Drawing.Point(171, 76);
            this.doctor_grid.MultiSelect = false;
            this.doctor_grid.Name = "doctor_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.doctor_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.doctor_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.doctor_grid, 5);
            this.doctor_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.doctor_grid.ShowCellErrors = false;
            this.doctor_grid.ShowCellToolTips = false;
            this.doctor_grid.Size = new System.Drawing.Size(792, 411);
            this.doctor_grid.TabIndex = 5;
            this.doctor_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.doctor_grid_DataBindingComplete);
            // 
            // d_select_column
            // 
            this.d_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.d_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.d_select_column.FalseValue = "false";
            this.d_select_column.Frozen = true;
            this.d_select_column.HeaderText = "";
            this.d_select_column.IndeterminateValue = "false";
            this.d_select_column.MinimumWidth = 30;
            this.d_select_column.Name = "d_select_column";
            this.d_select_column.TrueValue = "true";
            this.d_select_column.Width = 30;
            // 
            // d_id_column
            // 
            this.d_id_column.DataPropertyName = "id";
            this.d_id_column.HeaderText = "شناسه";
            this.d_id_column.Name = "d_id_column";
            this.d_id_column.ReadOnly = true;
            this.d_id_column.Width = 67;
            // 
            // d_medical_id_column
            // 
            this.d_medical_id_column.DataPropertyName = "medical_id";
            this.d_medical_id_column.HeaderText = "شماره نظام پزشکی";
            this.d_medical_id_column.Name = "d_medical_id_column";
            this.d_medical_id_column.ReadOnly = true;
            this.d_medical_id_column.Width = 131;
            // 
            // d_name_column
            // 
            this.d_name_column.DataPropertyName = "name";
            this.d_name_column.HeaderText = "نام";
            this.d_name_column.Name = "d_name_column";
            this.d_name_column.ReadOnly = true;
            this.d_name_column.Width = 47;
            // 
            // d_family_name_column
            // 
            this.d_family_name_column.DataPropertyName = "family_name";
            this.d_family_name_column.HeaderText = "نام خانوادگی";
            this.d_family_name_column.Name = "d_family_name_column";
            this.d_family_name_column.ReadOnly = true;
            this.d_family_name_column.Width = 98;
            // 
            // gender_name
            // 
            this.gender_name.DataPropertyName = "gender_name";
            this.gender_name.HeaderText = "جنسیت";
            this.gender_name.Name = "gender_name";
            this.gender_name.ReadOnly = true;
            this.gender_name.Width = 70;
            // 
            // d_degree_name_column
            // 
            this.d_degree_name_column.DataPropertyName = "degree_name";
            this.d_degree_name_column.HeaderText = "مدرک پزشکی";
            this.d_degree_name_column.Name = "d_degree_name_column";
            this.d_degree_name_column.ReadOnly = true;
            this.d_degree_name_column.Width = 101;
            // 
            // d_field_name_column
            // 
            this.d_field_name_column.DataPropertyName = "field_name";
            this.d_field_name_column.HeaderText = "رشته پزشکی";
            this.d_field_name_column.Name = "d_field_name_column";
            this.d_field_name_column.ReadOnly = true;
            this.d_field_name_column.Width = 102;
            // 
            // d_national_code_column
            // 
            this.d_national_code_column.DataPropertyName = "national_code";
            this.d_national_code_column.HeaderText = "شماره ملی";
            this.d_national_code_column.Name = "d_national_code_column";
            this.d_national_code_column.ReadOnly = true;
            this.d_national_code_column.Width = 86;
            // 
            // d_province_name_column
            // 
            this.d_province_name_column.DataPropertyName = "province_name";
            this.d_province_name_column.HeaderText = "استان محل سکونت";
            this.d_province_name_column.Name = "d_province_name_column";
            this.d_province_name_column.ReadOnly = true;
            this.d_province_name_column.Width = 129;
            // 
            // d_city_name_column
            // 
            this.d_city_name_column.DataPropertyName = "city_name";
            this.d_city_name_column.HeaderText = "شهر محل سکونت";
            this.d_city_name_column.Name = "d_city_name_column";
            this.d_city_name_column.ReadOnly = true;
            this.d_city_name_column.Width = 123;
            // 
            // d_home_address_column
            // 
            this.d_home_address_column.DataPropertyName = "home_address";
            this.d_home_address_column.HeaderText = "آدرس";
            this.d_home_address_column.Name = "d_home_address_column";
            this.d_home_address_column.ReadOnly = true;
            this.d_home_address_column.Width = 64;
            // 
            // d_home_phone_numbers_column
            // 
            this.d_home_phone_numbers_column.DataPropertyName = "home_phone_numbers";
            this.d_home_phone_numbers_column.HeaderText = "شماره تلفن";
            this.d_home_phone_numbers_column.Name = "d_home_phone_numbers_column";
            this.d_home_phone_numbers_column.ReadOnly = true;
            this.d_home_phone_numbers_column.Width = 89;
            // 
            // d_mobile_numbers_column
            // 
            this.d_mobile_numbers_column.DataPropertyName = "mobile_numbers";
            this.d_mobile_numbers_column.HeaderText = "شماره تلفن همراه";
            this.d_mobile_numbers_column.Name = "d_mobile_numbers_column";
            this.d_mobile_numbers_column.ReadOnly = true;
            this.d_mobile_numbers_column.Width = 122;
            // 
            // d_secretary_names_column
            // 
            this.d_secretary_names_column.DataPropertyName = "secretary_names";
            this.d_secretary_names_column.HeaderText = "نام منشی ها";
            this.d_secretary_names_column.Name = "d_secretary_names_column";
            this.d_secretary_names_column.ReadOnly = true;
            this.d_secretary_names_column.Width = 93;
            // 
            // d_secretary_phone_numbers_column
            // 
            this.d_secretary_phone_numbers_column.DataPropertyName = "secretary_phone_numbers";
            this.d_secretary_phone_numbers_column.HeaderText = "شماره تماس منشی ها";
            this.d_secretary_phone_numbers_column.Name = "d_secretary_phone_numbers_column";
            this.d_secretary_phone_numbers_column.ReadOnly = true;
            this.d_secretary_phone_numbers_column.Width = 141;
            // 
            // gender_id
            // 
            this.gender_id.DataPropertyName = "gender_id";
            this.gender_id.HeaderText = "شناسه جنسیت";
            this.gender_id.Name = "gender_id";
            this.gender_id.ReadOnly = true;
            this.gender_id.Visible = false;
            this.gender_id.Width = 107;
            // 
            // d_medicine_degree_column
            // 
            this.d_medicine_degree_column.DataPropertyName = "medicine_degree";
            this.d_medicine_degree_column.HeaderText = "شناسه مدرک ";
            this.d_medicine_degree_column.Name = "d_medicine_degree_column";
            this.d_medicine_degree_column.ReadOnly = true;
            this.d_medicine_degree_column.Visible = false;
            this.d_medicine_degree_column.Width = 102;
            // 
            // d_medicine_field_column
            // 
            this.d_medicine_field_column.DataPropertyName = "medicine_field";
            this.d_medicine_field_column.HeaderText = "شناسه رشته";
            this.d_medicine_field_column.Name = "d_medicine_field_column";
            this.d_medicine_field_column.ReadOnly = true;
            this.d_medicine_field_column.Visible = false;
            this.d_medicine_field_column.Width = 99;
            // 
            // d_province_id_column
            // 
            this.d_province_id_column.DataPropertyName = "province_id";
            this.d_province_id_column.HeaderText = "شناسه استان";
            this.d_province_id_column.Name = "d_province_id_column";
            this.d_province_id_column.ReadOnly = true;
            this.d_province_id_column.Visible = false;
            // 
            // d_home_city_column
            // 
            this.d_home_city_column.DataPropertyName = "home_city";
            this.d_home_city_column.HeaderText = "شناسه شهر";
            this.d_home_city_column.Name = "d_home_city_column";
            this.d_home_city_column.ReadOnly = true;
            this.d_home_city_column.Visible = false;
            this.d_home_city_column.Width = 94;
            // 
            // d_description_column
            // 
            this.d_description_column.DataPropertyName = "description";
            this.d_description_column.HeaderText = "توضیحات";
            this.d_description_column.Name = "d_description_column";
            this.d_description_column.ReadOnly = true;
            this.d_description_column.Width = 86;
            // 
            // tDoctorBindingSource
            // 
            this.tDoctorBindingSource.DataMember = "TDoctor";
            this.tDoctorBindingSource.DataSource = this.pIPDataSet;
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
            this.edit_button.Location = new System.Drawing.Point(3, 152);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(162, 35);
            this.edit_button.TabIndex = 7;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.d_edit_button_Click);
            // 
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(3, 111);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(162, 35);
            this.new_button.TabIndex = 6;
            this.new_button.Text = "ایجاد پزشک جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.d_new_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(863, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "نام :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(863, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "مدرک پزشکی :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(549, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 23;
            this.label1.Text = "نام خانوادگی :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(549, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 27);
            this.label4.TabIndex = 25;
            this.label4.Text = "شماره نظام پزشکی :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // degree_comboBox
            // 
            this.degree_comboBox.BackColor = System.Drawing.Color.White;
            this.degree_comboBox.DataSource = this.tMedicineDegreeBindingSource;
            this.degree_comboBox.DisplayMember = "name";
            this.degree_comboBox.DropDownHeight = 300;
            this.degree_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.degree_comboBox.FormattingEnabled = true;
            this.degree_comboBox.IntegralHeight = false;
            this.degree_comboBox.Location = new System.Drawing.Point(703, 29);
            this.degree_comboBox.Name = "degree_comboBox";
            this.degree_comboBox.Size = new System.Drawing.Size(154, 21);
            this.degree_comboBox.TabIndex = 2;
            this.degree_comboBox.ValueMember = "id";
            // 
            // tMedicineDegreeBindingSource
            // 
            this.tMedicineDegreeBindingSource.DataMember = "TMedicineDegree";
            this.tMedicineDegreeBindingSource.DataSource = this.pIPDataSet;
            // 
            // search_button
            // 
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(297, 29);
            this.search_button.Name = "search_button";
            this.tableLayoutPanel.SetRowSpan(this.search_button, 2);
            this.search_button.Size = new System.Drawing.Size(70, 27);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.d_search_button_Click);
            // 
            // tDoctorTableAdapter
            // 
            this.tDoctorTableAdapter.ClearBeforeFill = true;
            // 
            // tMedicineDegreeTableAdapter
            // 
            this.tMedicineDegreeTableAdapter.ClearBeforeFill = true;
            // 
            // DoctorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "DoctorControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(966, 589);
            this.Tag = "پزشک ها";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctor_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDoctorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicineDegreeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView doctor_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox family_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.ComboBox degree_comboBox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.BindingSource tDoctorBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.TDoctorTableAdapter tDoctorTableAdapter;
        private System.Windows.Forms.BindingSource tMedicineDegreeBindingSource;
        private PIPDataSetTableAdapters.TMedicineDegreeTableAdapter tMedicineDegreeTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_medical_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_family_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_degree_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_field_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_national_code_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_province_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_city_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_home_address_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_home_phone_numbers_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_mobile_numbers_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_secretary_names_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_secretary_phone_numbers_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_medicine_degree_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_medicine_field_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_province_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_home_city_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_description_column;
    }
}
