namespace PadraInsurancePrescription
{
    partial class PresDataParametersControl
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
            this.part_comboBox = new System.Windows.Forms.ComboBox();
            this.insurance_comboBox = new System.Windows.Forms.ComboBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.params_grid = new System.Windows.Forms.DataGridView();
            this.p_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_sequence_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_ctype_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_cpart_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_ins_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_sec_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_pvisit_date_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pid_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pserial_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_ppage_number_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pfunctor_doctor_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pname_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pfamily_name_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pexpiration_date_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pservice_date_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pprescriptor_doctor_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pservice_count_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_pservice_code_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_serial_include_id_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_id_exact_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_min_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_regex_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_code_exact_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_code_min_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_code_start_index_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_other_min_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_other_start_index_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_page_exact_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_page_min_length_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_id_page_from_end_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_id_page_start_index_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_clinic_part_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_clinic_type_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_insurance_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_insurance_sector_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tPresDataParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.type_lbl = new System.Windows.Forms.Label();
            this.ins_lbl = new System.Windows.Forms.Label();
            this.part_lbl = new System.Windows.Forms.Label();
            this.sec_lbl = new System.Windows.Forms.Label();
            this.type_comboBox = new System.Windows.Forms.ComboBox();
            this.sector_comboBox = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.tPresDataParametersTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TPresDataParametersTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.params_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPresDataParametersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel.Controls.Add(this.part_comboBox, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.insurance_comboBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 5, 7);
            this.tableLayoutPanel.Controls.Add(this.params_grid, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 5, 6);
            this.tableLayoutPanel.Controls.Add(this.new_button, 5, 5);
            this.tableLayoutPanel.Controls.Add(this.type_lbl, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.ins_lbl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.part_lbl, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.sec_lbl, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.type_comboBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.sector_comboBox, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.search_button, 4, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(966, 589);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // part_comboBox
            // 
            this.part_comboBox.BackColor = System.Drawing.Color.White;
            this.part_comboBox.DisplayMember = "id";
            this.part_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.part_comboBox.DropDownHeight = 300;
            this.part_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.part_comboBox.Enabled = false;
            this.part_comboBox.FormattingEnabled = true;
            this.part_comboBox.IntegralHeight = false;
            this.part_comboBox.Location = new System.Drawing.Point(373, 3);
            this.part_comboBox.Name = "part_comboBox";
            this.part_comboBox.Size = new System.Drawing.Size(170, 21);
            this.part_comboBox.TabIndex = 28;
            this.part_comboBox.ValueMember = "id";
            // 
            // insurance_comboBox
            // 
            this.insurance_comboBox.BackColor = System.Drawing.Color.White;
            this.insurance_comboBox.DisplayMember = "id";
            this.insurance_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insurance_comboBox.DropDownHeight = 300;
            this.insurance_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.insurance_comboBox.FormattingEnabled = true;
            this.insurance_comboBox.IntegralHeight = false;
            this.insurance_comboBox.Location = new System.Drawing.Point(687, 30);
            this.insurance_comboBox.Name = "insurance_comboBox";
            this.insurance_comboBox.Size = new System.Drawing.Size(170, 21);
            this.insurance_comboBox.TabIndex = 27;
            this.insurance_comboBox.ValueMember = "id";
            this.insurance_comboBox.SelectedIndexChanged += new System.EventHandler(this.insurance_combobox_SelectedIndexChanged);
            // 
            // delete_button
            // 
            this.delete_button.AutoSize = true;
            this.delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete_button.Location = new System.Drawing.Point(3, 194);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(162, 34);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.p_delete_doctor_Click);
            // 
            // params_grid
            // 
            this.params_grid.AllowUserToAddRows = false;
            this.params_grid.AllowUserToDeleteRows = false;
            this.params_grid.AutoGenerateColumns = false;
            this.params_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.params_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.params_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.params_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_select_column,
            this.p_sequence_column,
            this.p_ctype_name_column,
            this.p_cpart_name_column,
            this.p_ins_name_column,
            this.p_sec_name_column,
            this.p_pvisit_date_column,
            this.p_pid_column,
            this.p_pserial_column,
            this.p_ppage_number_column,
            this.p_pfunctor_doctor_column,
            this.p_pname_column,
            this.p_pfamily_name_column,
            this.p_pexpiration_date_column,
            this.p_pservice_date_column,
            this.p_pprescriptor_doctor_column,
            this.p_pservice_count_column,
            this.p_pservice_code_column,
            this.p_serial_include_id_column,
            this.p_id_exact_length_column,
            this.p_id_min_length_column,
            this.p_id_regex_column,
            this.p_id_code_exact_length_column,
            this.p_id_code_min_length_column,
            this.p_id_code_start_index_column,
            this.p_id_other_min_length_column,
            this.p_id_other_start_index_column,
            this.p_id_page_exact_length_column,
            this.p_id_page_min_length_column,
            this.p_id_page_from_end_column,
            this.p_id_page_start_index_column,
            this.p_clinic_part_column,
            this.p_clinic_type_column,
            this.p_insurance_column,
            this.p_insurance_sector_column});
            this.tableLayoutPanel.SetColumnSpan(this.params_grid, 5);
            this.params_grid.DataSource = this.tPresDataParametersBindingSource;
            this.params_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.params_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.params_grid.Location = new System.Drawing.Point(171, 77);
            this.params_grid.MultiSelect = false;
            this.params_grid.Name = "params_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.params_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.params_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.params_grid, 5);
            this.params_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.params_grid.ShowCellErrors = false;
            this.params_grid.ShowCellToolTips = false;
            this.params_grid.Size = new System.Drawing.Size(792, 411);
            this.params_grid.TabIndex = 5;
            this.params_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.params_grid_DataBindingComplete);
            // 
            // p_select_column
            // 
            this.p_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.p_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.p_select_column.FalseValue = "false";
            this.p_select_column.HeaderText = "";
            this.p_select_column.IndeterminateValue = "false";
            this.p_select_column.MinimumWidth = 30;
            this.p_select_column.Name = "p_select_column";
            this.p_select_column.TrueValue = "true";
            this.p_select_column.Width = 30;
            // 
            // p_sequence_column
            // 
            this.p_sequence_column.DataPropertyName = "sequence";
            this.p_sequence_column.HeaderText = "شناسه";
            this.p_sequence_column.Name = "p_sequence_column";
            this.p_sequence_column.ReadOnly = true;
            this.p_sequence_column.Width = 67;
            // 
            // p_ctype_name_column
            // 
            this.p_ctype_name_column.DataPropertyName = "c_type_name";
            this.p_ctype_name_column.HeaderText = "نوع مرکز";
            this.p_ctype_name_column.Name = "p_ctype_name_column";
            this.p_ctype_name_column.Width = 78;
            // 
            // p_cpart_name_column
            // 
            this.p_cpart_name_column.DataPropertyName = "c_part_name";
            this.p_cpart_name_column.HeaderText = "بخش درمانی";
            this.p_cpart_name_column.Name = "p_cpart_name_column";
            this.p_cpart_name_column.Width = 90;
            // 
            // p_ins_name_column
            // 
            this.p_ins_name_column.DataPropertyName = "ins_name";
            this.p_ins_name_column.HeaderText = "سازمان بیمه گر";
            this.p_ins_name_column.Name = "p_ins_name_column";
            this.p_ins_name_column.Width = 92;
            // 
            // p_sec_name_column
            // 
            this.p_sec_name_column.DataPropertyName = "sec_name";
            this.p_sec_name_column.HeaderText = "صندوق بیمه ای";
            this.p_sec_name_column.Name = "p_sec_name_column";
            this.p_sec_name_column.Width = 93;
            // 
            // p_pvisit_date_column
            // 
            this.p_pvisit_date_column.DataPropertyName = "p_visit_date";
            this.p_pvisit_date_column.FalseValue = "غیرفعال";
            this.p_pvisit_date_column.HeaderText = "تاریخ ویزیت";
            this.p_pvisit_date_column.Name = "p_pvisit_date_column";
            this.p_pvisit_date_column.TrueValue = "فعال";
            this.p_pvisit_date_column.Width = 74;
            // 
            // p_pid_column
            // 
            this.p_pid_column.DataPropertyName = "p_id";
            this.p_pid_column.FalseValue = "غیرفعال";
            this.p_pid_column.HeaderText = "شناسه بیمه شده";
            this.p_pid_column.Name = "p_pid_column";
            this.p_pid_column.TrueValue = "فعال";
            this.p_pid_column.Width = 68;
            // 
            // p_pserial_column
            // 
            this.p_pserial_column.DataPropertyName = "p_serial";
            this.p_pserial_column.FalseValue = "غیرفعال";
            this.p_pserial_column.HeaderText = "سریال نسخه";
            this.p_pserial_column.Name = "p_pserial_column";
            this.p_pserial_column.TrueValue = "فعال";
            this.p_pserial_column.Width = 72;
            // 
            // p_ppage_number_column
            // 
            this.p_ppage_number_column.DataPropertyName = "p_page_number";
            this.p_ppage_number_column.FalseValue = "غیرفعال";
            this.p_ppage_number_column.HeaderText = "شماره صفحه";
            this.p_ppage_number_column.Name = "p_ppage_number_column";
            this.p_ppage_number_column.TrueValue = "فعال";
            this.p_ppage_number_column.Width = 76;
            // 
            // p_pfunctor_doctor_column
            // 
            this.p_pfunctor_doctor_column.DataPropertyName = "p_functor_doctor";
            this.p_pfunctor_doctor_column.FalseValue = "غیرفعال";
            this.p_pfunctor_doctor_column.HeaderText = "پزشک انجام دهنده خدمت";
            this.p_pfunctor_doctor_column.Name = "p_pfunctor_doctor_column";
            this.p_pfunctor_doctor_column.TrueValue = "فعال";
            this.p_pfunctor_doctor_column.Width = 97;
            // 
            // p_pname_column
            // 
            this.p_pname_column.DataPropertyName = "p_name";
            this.p_pname_column.FalseValue = "غیرفعال";
            this.p_pname_column.HeaderText = "نام بیمه شده";
            this.p_pname_column.Name = "p_pname_column";
            this.p_pname_column.TrueValue = "فعال";
            this.p_pname_column.Width = 68;
            // 
            // p_pfamily_name_column
            // 
            this.p_pfamily_name_column.DataPropertyName = "p_family_name";
            this.p_pfamily_name_column.FalseValue = "غیرفعال";
            this.p_pfamily_name_column.HeaderText = "نام خانوادگی بیمه شده";
            this.p_pfamily_name_column.Name = "p_pfamily_name_column";
            this.p_pfamily_name_column.TrueValue = "فعال";
            this.p_pfamily_name_column.Width = 96;
            // 
            // p_pexpiration_date_column
            // 
            this.p_pexpiration_date_column.DataPropertyName = "p_expiration_date";
            this.p_pexpiration_date_column.FalseValue = "غیرفعال";
            this.p_pexpiration_date_column.HeaderText = "تاریخ انقضا";
            this.p_pexpiration_date_column.Name = "p_pexpiration_date_column";
            this.p_pexpiration_date_column.TrueValue = "فعال";
            this.p_pexpiration_date_column.Width = 71;
            // 
            // p_pservice_date_column
            // 
            this.p_pservice_date_column.DataPropertyName = "p_service_date";
            this.p_pservice_date_column.FalseValue = "غیرفعال";
            this.p_pservice_date_column.HeaderText = "تاریخ ارجاع";
            this.p_pservice_date_column.Name = "p_pservice_date_column";
            this.p_pservice_date_column.TrueValue = "فعال";
            this.p_pservice_date_column.Width = 73;
            // 
            // p_pprescriptor_doctor_column
            // 
            this.p_pprescriptor_doctor_column.DataPropertyName = "p_prescriptor_doctor";
            this.p_pprescriptor_doctor_column.FalseValue = "غیرفعال";
            this.p_pprescriptor_doctor_column.HeaderText = "پزشک ارجاع دهنده";
            this.p_pprescriptor_doctor_column.Name = "p_pprescriptor_doctor_column";
            this.p_pprescriptor_doctor_column.TrueValue = "فعال";
            this.p_pprescriptor_doctor_column.Width = 101;
            // 
            // p_pservice_count_column
            // 
            this.p_pservice_count_column.DataPropertyName = "p_service_count";
            this.p_pservice_count_column.FalseValue = "غیرفعال";
            this.p_pservice_count_column.HeaderText = "تعداد دفعات انجام خدمت";
            this.p_pservice_count_column.Name = "p_pservice_count_column";
            this.p_pservice_count_column.TrueValue = "فعال";
            this.p_pservice_count_column.Width = 95;
            // 
            // p_pservice_code_column
            // 
            this.p_pservice_code_column.DataPropertyName = "p_service_code";
            this.p_pservice_code_column.FalseValue = "غیرفعال";
            this.p_pservice_code_column.HeaderText = "کد خدمت";
            this.p_pservice_code_column.Name = "p_pservice_code_column";
            this.p_pservice_code_column.TrueValue = "فعال";
            this.p_pservice_code_column.Width = 53;
            // 
            // p_serial_include_id_column
            // 
            this.p_serial_include_id_column.DataPropertyName = "serial_include_id";
            this.p_serial_include_id_column.FalseValue = "خیر";
            this.p_serial_include_id_column.HeaderText = "سریال نسخه شامل شناسه است؟";
            this.p_serial_include_id_column.Name = "p_serial_include_id_column";
            this.p_serial_include_id_column.TrueValue = "بله";
            this.p_serial_include_id_column.Width = 136;
            // 
            // p_id_exact_length_column
            // 
            this.p_id_exact_length_column.DataPropertyName = "id_exact_length";
            this.p_id_exact_length_column.HeaderText = "تعداد کاراکتر سریال نسخه";
            this.p_id_exact_length_column.Name = "p_id_exact_length_column";
            this.p_id_exact_length_column.Width = 131;
            // 
            // p_id_min_length_column
            // 
            this.p_id_min_length_column.DataPropertyName = "id_min_length";
            this.p_id_min_length_column.HeaderText = "حداقل طول قسمت شناسه از سریال";
            this.p_id_min_length_column.Name = "p_id_min_length_column";
            this.p_id_min_length_column.Width = 150;
            // 
            // p_id_regex_column
            // 
            this.p_id_regex_column.DataPropertyName = "id_regex";
            this.p_id_regex_column.HeaderText = "استاندارد/فرمت شناسه";
            this.p_id_regex_column.Name = "p_id_regex_column";
            this.p_id_regex_column.Width = 137;
            // 
            // p_id_code_exact_length_column
            // 
            this.p_id_code_exact_length_column.DataPropertyName = "id_code_exact_length";
            this.p_id_code_exact_length_column.HeaderText = "تعداد کاراکتر قسمت شناسه";
            this.p_id_code_exact_length_column.Name = "p_id_code_exact_length_column";
            this.p_id_code_exact_length_column.Width = 127;
            // 
            // p_id_code_min_length_column
            // 
            this.p_id_code_min_length_column.DataPropertyName = "id_code_min_length";
            this.p_id_code_min_length_column.HeaderText = "حداقل تعداد کاراکتر قسمت شناسه";
            this.p_id_code_min_length_column.Name = "p_id_code_min_length_column";
            this.p_id_code_min_length_column.Width = 157;
            // 
            // p_id_code_start_index_column
            // 
            this.p_id_code_start_index_column.DataPropertyName = "id_code_start_index";
            this.p_id_code_start_index_column.HeaderText = "اندیس شروع قسمت شناسه";
            this.p_id_code_start_index_column.Name = "p_id_code_start_index_column";
            this.p_id_code_start_index_column.Width = 126;
            // 
            // p_id_other_min_length_column
            // 
            this.p_id_other_min_length_column.DataPropertyName = "id_other_min_length";
            this.p_id_other_min_length_column.HeaderText = "حداقل تعداد کاراکتر سایر بخش های سریال";
            this.p_id_other_min_length_column.Name = "p_id_other_min_length_column";
            this.p_id_other_min_length_column.Width = 153;
            // 
            // p_id_other_start_index_column
            // 
            this.p_id_other_start_index_column.DataPropertyName = "id_other_start_index";
            this.p_id_other_start_index_column.HeaderText = "اندیس شروع سایر بخش های سریال";
            this.p_id_other_start_index_column.Name = "p_id_other_start_index_column";
            this.p_id_other_start_index_column.Width = 149;
            // 
            // p_id_page_exact_length_column
            // 
            this.p_id_page_exact_length_column.DataPropertyName = "id_page_exact_length";
            this.p_id_page_exact_length_column.HeaderText = "تعداد کاراکتر شماره صفحه از سریال";
            this.p_id_page_exact_length_column.Name = "p_id_page_exact_length_column";
            this.p_id_page_exact_length_column.Width = 159;
            // 
            // p_id_page_min_length_column
            // 
            this.p_id_page_min_length_column.DataPropertyName = "id_page_min_length";
            this.p_id_page_min_length_column.HeaderText = "حداقل تعداد کاراکتر شماره صفحه از سریال";
            this.p_id_page_min_length_column.Name = "p_id_page_min_length_column";
            this.p_id_page_min_length_column.Width = 159;
            // 
            // p_id_page_from_end_column
            // 
            this.p_id_page_from_end_column.DataPropertyName = "id_page_from_end";
            this.p_id_page_from_end_column.FalseValue = "خیر";
            this.p_id_page_from_end_column.HeaderText = "آیا شماره صفحه در انتهای سریال است؟";
            this.p_id_page_from_end_column.Name = "p_id_page_from_end_column";
            this.p_id_page_from_end_column.TrueValue = "بله";
            this.p_id_page_from_end_column.Width = 141;
            // 
            // p_id_page_start_index_column
            // 
            this.p_id_page_start_index_column.DataPropertyName = "id_page_start_index";
            this.p_id_page_start_index_column.HeaderText = "اندیس شروع بخش شماره صفحه";
            this.p_id_page_start_index_column.Name = "p_id_page_start_index_column";
            this.p_id_page_start_index_column.Width = 154;
            // 
            // p_clinic_part_column
            // 
            this.p_clinic_part_column.DataPropertyName = "clinic_part";
            this.p_clinic_part_column.HeaderText = "clinic_part";
            this.p_clinic_part_column.Name = "p_clinic_part_column";
            this.p_clinic_part_column.Visible = false;
            this.p_clinic_part_column.Width = 105;
            // 
            // p_clinic_type_column
            // 
            this.p_clinic_type_column.DataPropertyName = "clinic_type";
            this.p_clinic_type_column.HeaderText = "clinic_type";
            this.p_clinic_type_column.Name = "p_clinic_type_column";
            this.p_clinic_type_column.Visible = false;
            this.p_clinic_type_column.Width = 107;
            // 
            // p_insurance_column
            // 
            this.p_insurance_column.DataPropertyName = "insurance";
            this.p_insurance_column.HeaderText = "insurance";
            this.p_insurance_column.Name = "p_insurance_column";
            this.p_insurance_column.Visible = false;
            this.p_insurance_column.Width = 103;
            // 
            // p_insurance_sector_column
            // 
            this.p_insurance_sector_column.DataPropertyName = "insurance_sector";
            this.p_insurance_sector_column.HeaderText = "insurance_sector";
            this.p_insurance_sector_column.Name = "p_insurance_sector_column";
            this.p_insurance_sector_column.Visible = false;
            this.p_insurance_sector_column.Width = 156;
            // 
            // tPresDataParametersBindingSource
            // 
            this.tPresDataParametersBindingSource.DataMember = "TPresDataParameters";
            this.tPresDataParametersBindingSource.DataSource = this.pIPDataSet;
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
            this.edit_button.Location = new System.Drawing.Point(3, 153);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(162, 35);
            this.edit_button.TabIndex = 7;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.p_edit_button_Click);
            // 
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(3, 112);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(162, 35);
            this.new_button.TabIndex = 6;
            this.new_button.Text = "ایجاد تنظیمات جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.p_new_button_Click);
            // 
            // type_lbl
            // 
            this.type_lbl.AutoSize = true;
            this.type_lbl.BackColor = System.Drawing.Color.Transparent;
            this.type_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.type_lbl.ForeColor = System.Drawing.Color.Black;
            this.type_lbl.Location = new System.Drawing.Point(863, 0);
            this.type_lbl.Name = "type_lbl";
            this.type_lbl.Size = new System.Drawing.Size(91, 27);
            this.type_lbl.TabIndex = 4;
            this.type_lbl.Text = "نوع مرکز درمانی :";
            this.type_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ins_lbl
            // 
            this.ins_lbl.AutoSize = true;
            this.ins_lbl.BackColor = System.Drawing.Color.Transparent;
            this.ins_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.ins_lbl.ForeColor = System.Drawing.Color.Black;
            this.ins_lbl.Location = new System.Drawing.Point(863, 27);
            this.ins_lbl.Name = "ins_lbl";
            this.ins_lbl.Size = new System.Drawing.Size(83, 27);
            this.ins_lbl.TabIndex = 4;
            this.ins_lbl.Text = "سازمان بیمه گر :";
            this.ins_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // part_lbl
            // 
            this.part_lbl.AutoSize = true;
            this.part_lbl.BackColor = System.Drawing.Color.Transparent;
            this.part_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.part_lbl.ForeColor = System.Drawing.Color.Black;
            this.part_lbl.Location = new System.Drawing.Point(549, 0);
            this.part_lbl.Name = "part_lbl";
            this.part_lbl.Size = new System.Drawing.Size(105, 27);
            this.part_lbl.TabIndex = 23;
            this.part_lbl.Text = "بخش درمانی از مرکز :";
            this.part_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sec_lbl
            // 
            this.sec_lbl.AutoSize = true;
            this.sec_lbl.BackColor = System.Drawing.Color.Transparent;
            this.sec_lbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.sec_lbl.ForeColor = System.Drawing.Color.Black;
            this.sec_lbl.Location = new System.Drawing.Point(549, 27);
            this.sec_lbl.Name = "sec_lbl";
            this.sec_lbl.Size = new System.Drawing.Size(82, 27);
            this.sec_lbl.TabIndex = 25;
            this.sec_lbl.Text = "صندوق بیمه ای :";
            this.sec_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // type_comboBox
            // 
            this.type_comboBox.BackColor = System.Drawing.Color.White;
            this.type_comboBox.DisplayMember = "id";
            this.type_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type_comboBox.DropDownHeight = 300;
            this.type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_comboBox.FormattingEnabled = true;
            this.type_comboBox.IntegralHeight = false;
            this.type_comboBox.Location = new System.Drawing.Point(687, 3);
            this.type_comboBox.Name = "type_comboBox";
            this.type_comboBox.Size = new System.Drawing.Size(170, 21);
            this.type_comboBox.TabIndex = 2;
            this.type_comboBox.ValueMember = "id";
            this.type_comboBox.SelectedIndexChanged += new System.EventHandler(this.type_comboBox_SelectedIndexChanged);
            // 
            // sector_comboBox
            // 
            this.sector_comboBox.BackColor = System.Drawing.Color.White;
            this.sector_comboBox.DisplayMember = "id";
            this.sector_comboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sector_comboBox.DropDownHeight = 300;
            this.sector_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sector_comboBox.Enabled = false;
            this.sector_comboBox.FormattingEnabled = true;
            this.sector_comboBox.IntegralHeight = false;
            this.sector_comboBox.Location = new System.Drawing.Point(373, 30);
            this.sector_comboBox.Name = "sector_comboBox";
            this.sector_comboBox.Size = new System.Drawing.Size(170, 21);
            this.sector_comboBox.TabIndex = 26;
            this.sector_comboBox.ValueMember = "id";
            // 
            // search_button
            // 
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(297, 30);
            this.search_button.Name = "search_button";
            this.tableLayoutPanel.SetRowSpan(this.search_button, 2);
            this.search_button.Size = new System.Drawing.Size(70, 27);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.p_search_button_Click);
            // 
            // tPresDataParametersTableAdapter
            // 
            this.tPresDataParametersTableAdapter.ClearBeforeFill = true;
            // 
            // PresDataParametersControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PresDataParametersControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(966, 589);
            this.Tag = "پزشک ها";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.params_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPresDataParametersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView params_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label type_lbl;
        private System.Windows.Forms.Label ins_lbl;
        private System.Windows.Forms.Label part_lbl;
        private System.Windows.Forms.Label sec_lbl;
        private System.Windows.Forms.ComboBox type_comboBox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.ComboBox part_comboBox;
        private System.Windows.Forms.ComboBox insurance_comboBox;
        private System.Windows.Forms.ComboBox sector_comboBox;
        private System.Windows.Forms.BindingSource tPresDataParametersBindingSource;
        private PIPDataSetTableAdapters.TPresDataParametersTableAdapter tPresDataParametersTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_sequence_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_ctype_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_cpart_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_ins_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_sec_name_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pvisit_date_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pid_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pserial_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_ppage_number_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pfunctor_doctor_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pname_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pfamily_name_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pexpiration_date_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pservice_date_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pprescriptor_doctor_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pservice_count_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_pservice_code_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_serial_include_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_exact_length_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_min_length_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_regex_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_code_exact_length_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_code_min_length_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_code_start_index_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_other_min_length_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_other_start_index_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_page_exact_length_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_page_min_length_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_id_page_from_end_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_page_start_index_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_clinic_part_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_clinic_type_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_insurance_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_insurance_sector_column;
    }
}
