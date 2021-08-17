namespace PadraInsurancePrescription
{
    partial class InsuredControl
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
            this.name_label = new System.Windows.Forms.Label();
            this.sector_label = new System.Windows.Forms.Label();
            this.insurance_label = new System.Windows.Forms.Label();
            this.delete_button = new System.Windows.Forms.Button();
            this.id_text = new System.Windows.Forms.TextBox();
            this.family_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.insured_grid = new System.Windows.Forms.DataGridView();
            this.i_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.i_sequence_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_family_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_national_code_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_ins_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_sector_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_exp_complete_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_expiration_day_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_expiration_month_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_expiration_year_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i_insurance_sector_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tInsuredBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.id_label = new System.Windows.Forms.Label();
            this.family_label = new System.Windows.Forms.Label();
            this.insurance_combobox = new System.Windows.Forms.ComboBox();
            this.sector_combobox = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.tInsuredTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TInsuredTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insured_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tInsuredBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel.Controls.Add(this.name_label, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.sector_label, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.insurance_label, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 4, 9);
            this.tableLayoutPanel.Controls.Add(this.id_text, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.family_text, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.insured_grid, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 4, 8);
            this.tableLayoutPanel.Controls.Add(this.new_button, 4, 7);
            this.tableLayoutPanel.Controls.Add(this.id_label, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.family_label, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.insurance_combobox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.sector_combobox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.search_button, 2, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 13;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(913, 576);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_label.ForeColor = System.Drawing.Color.Black;
            this.name_label.Location = new System.Drawing.Point(745, 80);
            this.name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(166, 40);
            this.name_label.TabIndex = 28;
            this.name_label.Text = "نام بیمه شده :";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sector_label
            // 
            this.sector_label.AutoSize = true;
            this.sector_label.BackColor = System.Drawing.Color.Transparent;
            this.sector_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sector_label.ForeColor = System.Drawing.Color.Black;
            this.sector_label.Location = new System.Drawing.Point(745, 40);
            this.sector_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sector_label.Name = "sector_label";
            this.sector_label.Size = new System.Drawing.Size(166, 40);
            this.sector_label.TabIndex = 27;
            this.sector_label.Text = "صندوق بیمه گر :";
            this.sector_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // insurance_label
            // 
            this.insurance_label.AutoSize = true;
            this.insurance_label.BackColor = System.Drawing.Color.Transparent;
            this.insurance_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insurance_label.ForeColor = System.Drawing.Color.Black;
            this.insurance_label.Location = new System.Drawing.Point(745, 0);
            this.insurance_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.insurance_label.Name = "insurance_label";
            this.insurance_label.Size = new System.Drawing.Size(166, 40);
            this.insurance_label.TabIndex = 26;
            this.insurance_label.Text = "سازمان بیمه گر :";
            this.insurance_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // delete_button
            // 
            this.delete_button.AutoSize = true;
            this.delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete_button.Location = new System.Drawing.Point(2, 309);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(202, 29);
            this.delete_button.TabIndex = 9;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.i_delete_insured_Click);
            // 
            // id_text
            // 
            this.id_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.id_text.Location = new System.Drawing.Point(536, 162);
            this.id_text.Margin = new System.Windows.Forms.Padding(2);
            this.id_text.MaxLength = 20;
            this.id_text.Name = "id_text";
            this.id_text.Size = new System.Drawing.Size(205, 20);
            this.id_text.TabIndex = 4;
            // 
            // family_text
            // 
            this.family_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.family_text.Location = new System.Drawing.Point(536, 122);
            this.family_text.Margin = new System.Windows.Forms.Padding(2);
            this.family_text.MaxLength = 250;
            this.family_text.Name = "family_text";
            this.family_text.Size = new System.Drawing.Size(205, 20);
            this.family_text.TabIndex = 3;
            // 
            // name_text
            // 
            this.name_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.name_text.Location = new System.Drawing.Point(536, 82);
            this.name_text.Margin = new System.Windows.Forms.Padding(2);
            this.name_text.MaxLength = 250;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(205, 20);
            this.name_text.TabIndex = 2;
            // 
            // insured_grid
            // 
            this.insured_grid.AllowUserToAddRows = false;
            this.insured_grid.AllowUserToDeleteRows = false;
            this.insured_grid.AutoGenerateColumns = false;
            this.insured_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.insured_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.insured_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insured_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.i_select_column,
            this.i_sequence_column,
            this.i_id_column,
            this.i_name_column,
            this.i_family_name_column,
            this.i_national_code_column,
            this.i_ins_name_column,
            this.i_sector_name_column,
            this.i_exp_complete_column,
            this.i_expiration_day_column,
            this.i_expiration_month_column,
            this.i_expiration_year_column,
            this.i_insurance_sector_column});
            this.tableLayoutPanel.SetColumnSpan(this.insured_grid, 4);
            this.insured_grid.DataSource = this.tInsuredBindingSource;
            this.insured_grid.Dock = System.Windows.Forms.DockStyle.Top;
            this.insured_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.insured_grid.Location = new System.Drawing.Point(208, 217);
            this.insured_grid.Margin = new System.Windows.Forms.Padding(2);
            this.insured_grid.MultiSelect = false;
            this.insured_grid.Name = "insured_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.insured_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.insured_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.insured_grid, 6);
            this.insured_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.insured_grid.ShowCellErrors = false;
            this.insured_grid.ShowCellToolTips = false;
            this.insured_grid.Size = new System.Drawing.Size(703, 339);
            this.insured_grid.TabIndex = 6;
            this.insured_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.insured_grid_DataBindingComplete);
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
            this.i_select_column.TrueValue = "true";
            this.i_select_column.Width = 30;
            // 
            // i_sequence_column
            // 
            this.i_sequence_column.DataPropertyName = "sequence";
            this.i_sequence_column.HeaderText = "شناسه";
            this.i_sequence_column.Name = "i_sequence_column";
            this.i_sequence_column.ReadOnly = true;
            this.i_sequence_column.Width = 67;
            // 
            // i_id_column
            // 
            this.i_id_column.DataPropertyName = "id";
            this.i_id_column.HeaderText = "شماره شناسایی دفترچه";
            this.i_id_column.Name = "i_id_column";
            this.i_id_column.ReadOnly = true;
            this.i_id_column.Width = 139;
            // 
            // i_name_column
            // 
            this.i_name_column.DataPropertyName = "name";
            this.i_name_column.HeaderText = "نام";
            this.i_name_column.Name = "i_name_column";
            this.i_name_column.ReadOnly = true;
            this.i_name_column.Width = 47;
            // 
            // i_family_name_column
            // 
            this.i_family_name_column.DataPropertyName = "family_name";
            this.i_family_name_column.HeaderText = "نام خانوادگی";
            this.i_family_name_column.Name = "i_family_name_column";
            this.i_family_name_column.ReadOnly = true;
            this.i_family_name_column.Width = 90;
            // 
            // i_national_code_column
            // 
            this.i_national_code_column.DataPropertyName = "national_code";
            this.i_national_code_column.HeaderText = "شماره ملی";
            this.i_national_code_column.Name = "i_national_code_column";
            this.i_national_code_column.ReadOnly = true;
            this.i_national_code_column.Width = 79;
            // 
            // i_ins_name_column
            // 
            this.i_ins_name_column.DataPropertyName = "ins_name";
            this.i_ins_name_column.HeaderText = "سازمان بیمه گر";
            this.i_ins_name_column.Name = "i_ins_name_column";
            this.i_ins_name_column.ReadOnly = true;
            this.i_ins_name_column.Width = 92;
            // 
            // i_sector_name_column
            // 
            this.i_sector_name_column.DataPropertyName = "sector_name";
            this.i_sector_name_column.HeaderText = "صندوق بیمه گر";
            this.i_sector_name_column.Name = "i_sector_name_column";
            this.i_sector_name_column.ReadOnly = true;
            this.i_sector_name_column.Width = 93;
            // 
            // i_exp_complete_column
            // 
            this.i_exp_complete_column.DataPropertyName = "exp_complete";
            this.i_exp_complete_column.HeaderText = "تاریخ اعتبار دفترچه";
            this.i_exp_complete_column.Name = "i_exp_complete_column";
            this.i_exp_complete_column.ReadOnly = true;
            this.i_exp_complete_column.Width = 127;
            // 
            // i_expiration_day_column
            // 
            this.i_expiration_day_column.DataPropertyName = "expiration_day";
            this.i_expiration_day_column.HeaderText = "expiration_day";
            this.i_expiration_day_column.Name = "i_expiration_day_column";
            this.i_expiration_day_column.ReadOnly = true;
            this.i_expiration_day_column.Visible = false;
            this.i_expiration_day_column.Width = 185;
            // 
            // i_expiration_month_column
            // 
            this.i_expiration_month_column.DataPropertyName = "expiration_month";
            this.i_expiration_month_column.HeaderText = "expiration_month";
            this.i_expiration_month_column.Name = "i_expiration_month_column";
            this.i_expiration_month_column.ReadOnly = true;
            this.i_expiration_month_column.Visible = false;
            this.i_expiration_month_column.Width = 211;
            // 
            // i_expiration_year_column
            // 
            this.i_expiration_year_column.DataPropertyName = "expiration_year";
            this.i_expiration_year_column.HeaderText = "expiration_year";
            this.i_expiration_year_column.Name = "i_expiration_year_column";
            this.i_expiration_year_column.ReadOnly = true;
            this.i_expiration_year_column.Visible = false;
            this.i_expiration_year_column.Width = 192;
            // 
            // i_insurance_sector_column
            // 
            this.i_insurance_sector_column.DataPropertyName = "insurance_sector";
            this.i_insurance_sector_column.HeaderText = "insurance_sector";
            this.i_insurance_sector_column.Name = "i_insurance_sector_column";
            this.i_insurance_sector_column.ReadOnly = true;
            this.i_insurance_sector_column.Visible = false;
            this.i_insurance_sector_column.Width = 209;
            // 
            // tInsuredBindingSource
            // 
            this.tInsuredBindingSource.DataMember = "TInsured";
            this.tInsuredBindingSource.DataSource = this.pIPDataSet;
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
            this.edit_button.Location = new System.Drawing.Point(2, 276);
            this.edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(202, 29);
            this.edit_button.TabIndex = 8;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.i_edit_button_Click);
            // 
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(2, 243);
            this.new_button.Margin = new System.Windows.Forms.Padding(2);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(202, 29);
            this.new_button.TabIndex = 7;
            this.new_button.Text = "ایجاد بیمه شده جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.i_new_button_Click);
            // 
            // id_label
            // 
            this.id_label.AutoSize = true;
            this.id_label.BackColor = System.Drawing.Color.Transparent;
            this.id_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.id_label.ForeColor = System.Drawing.Color.Black;
            this.id_label.Location = new System.Drawing.Point(745, 160);
            this.id_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.id_label.Name = "id_label";
            this.id_label.Size = new System.Drawing.Size(166, 40);
            this.id_label.TabIndex = 4;
            this.id_label.Text = "شناسه بیمه شده :";
            this.id_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // family_label
            // 
            this.family_label.AutoSize = true;
            this.family_label.BackColor = System.Drawing.Color.Transparent;
            this.family_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.family_label.ForeColor = System.Drawing.Color.Black;
            this.family_label.Location = new System.Drawing.Point(745, 120);
            this.family_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.family_label.Name = "family_label";
            this.family_label.Size = new System.Drawing.Size(166, 40);
            this.family_label.TabIndex = 23;
            this.family_label.Text = "نام خانوادگی بیمه شده :";
            this.family_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // insurance_combobox
            // 
            this.insurance_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.insurance_combobox.BackColor = System.Drawing.Color.White;
            this.insurance_combobox.DisplayMember = "id";
            this.insurance_combobox.DropDownHeight = 300;
            this.insurance_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.insurance_combobox.FormattingEnabled = true;
            this.insurance_combobox.IntegralHeight = false;
            this.insurance_combobox.Location = new System.Drawing.Point(536, 2);
            this.insurance_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.insurance_combobox.Name = "insurance_combobox";
            this.insurance_combobox.Size = new System.Drawing.Size(205, 21);
            this.insurance_combobox.TabIndex = 0;
            this.insurance_combobox.ValueMember = "id";
            this.insurance_combobox.SelectedIndexChanged += new System.EventHandler(this.insurance_combobox_SelectedIndexChanged);
            // 
            // sector_combobox
            // 
            this.sector_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sector_combobox.BackColor = System.Drawing.Color.White;
            this.sector_combobox.DisplayMember = "id";
            this.sector_combobox.DropDownHeight = 300;
            this.sector_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sector_combobox.FormattingEnabled = true;
            this.sector_combobox.IntegralHeight = false;
            this.sector_combobox.Location = new System.Drawing.Point(536, 42);
            this.sector_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.sector_combobox.Name = "sector_combobox";
            this.sector_combobox.Size = new System.Drawing.Size(205, 21);
            this.sector_combobox.TabIndex = 1;
            this.sector_combobox.ValueMember = "id";
            this.sector_combobox.SelectedIndexChanged += new System.EventHandler(this.sector_combobox_SelectedIndexChanged);
            // 
            // search_button
            // 
            this.search_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(464, 162);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(53, 26);
            this.search_button.TabIndex = 5;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.i_search_button_Click);
            // 
            // tInsuredTableAdapter
            // 
            this.tInsuredTableAdapter.ClearBeforeFill = true;
            // 
            // InsuredControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InsuredControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(913, 576);
            this.Tag = "بیمه شده ها";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insured_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tInsuredBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView insured_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.TextBox family_text;
        private System.Windows.Forms.Label id_label;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label family_label;
        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.ComboBox insurance_combobox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label sector_label;
        private System.Windows.Forms.Label insurance_label;
        private System.Windows.Forms.ComboBox sector_combobox;
        private System.Windows.Forms.BindingSource tInsuredBindingSource;
        private PIPDataSetTableAdapters.TInsuredTableAdapter tInsuredTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn i_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_sequence_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_family_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_national_code_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_ins_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_sector_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_exp_complete_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_expiration_day_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_expiration_month_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_expiration_year_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn i_insurance_sector_column;
    }
}
