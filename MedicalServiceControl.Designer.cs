namespace PadraInsurancePrescription
{
    partial class MedicalServiceControl
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
            this.import_button = new System.Windows.Forms.Button();
            this.export_button = new System.Windows.Forms.Button();
            this.copy_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.code_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.service_grid = new System.Windows.Forms.DataGridView();
            this.s_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.s_sequence_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_national_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_category_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_sub_category_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_insurance_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_sector_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_k_factor_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_professional_k_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_technical_k_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_shortcut_code_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_start_date_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_category_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_insurance_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_insurance_sector_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tMedicalServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.edit_button = new System.Windows.Forms.Button();
            this.new_button = new System.Windows.Forms.Button();
            this.name_label = new System.Windows.Forms.Label();
            this.category_label = new System.Windows.Forms.Label();
            this.code_label = new System.Windows.Forms.Label();
            this.category_combobox = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.tMedicalServiceTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TMedicalServiceTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.service_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel.Controls.Add(this.import_button, 5, 10);
            this.tableLayoutPanel.Controls.Add(this.export_button, 5, 9);
            this.tableLayoutPanel.Controls.Add(this.copy_button, 5, 6);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 5, 7);
            this.tableLayoutPanel.Controls.Add(this.code_text, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.service_grid, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 5, 8);
            this.tableLayoutPanel.Controls.Add(this.new_button, 5, 5);
            this.tableLayoutPanel.Controls.Add(this.name_label, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.category_label, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.code_label, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.category_combobox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.search_button, 2, 2);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 13;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(932, 476);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // import_button
            // 
            this.import_button.AutoSize = true;
            this.import_button.BackColor = System.Drawing.Color.Blue;
            this.import_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.import_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.import_button.Location = new System.Drawing.Point(2, 263);
            this.import_button.Margin = new System.Windows.Forms.Padding(2);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(246, 33);
            this.import_button.TabIndex = 26;
            this.import_button.Text = "دریافت اطلاعات جدید از فایل ";
            this.import_button.UseVisualStyleBackColor = false;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // export_button
            // 
            this.export_button.AutoSize = true;
            this.export_button.BackColor = System.Drawing.Color.Blue;
            this.export_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.export_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.export_button.Location = new System.Drawing.Point(2, 228);
            this.export_button.Margin = new System.Windows.Forms.Padding(2);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(246, 31);
            this.export_button.TabIndex = 25;
            this.export_button.Text = "ذخیره اطلاعات موارد انتخاب شده در فایل";
            this.export_button.UseVisualStyleBackColor = false;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // copy_button
            // 
            this.copy_button.AutoSize = true;
            this.copy_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copy_button.Location = new System.Drawing.Point(2, 141);
            this.copy_button.Margin = new System.Windows.Forms.Padding(2);
            this.copy_button.Name = "copy_button";
            this.copy_button.Size = new System.Drawing.Size(246, 25);
            this.copy_button.TabIndex = 24;
            this.copy_button.Text = "ایجاد نسخه جدید از خدمات انتخاب شده";
            this.copy_button.UseVisualStyleBackColor = true;
            this.copy_button.Click += new System.EventHandler(this.copy_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.AutoSize = true;
            this.delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delete_button.Location = new System.Drawing.Point(2, 170);
            this.delete_button.Margin = new System.Windows.Forms.Padding(2);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(246, 25);
            this.delete_button.TabIndex = 8;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // code_text
            // 
            this.code_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.code_text.Location = new System.Drawing.Point(695, 51);
            this.code_text.Margin = new System.Windows.Forms.Padding(2);
            this.code_text.MaxLength = 10;
            this.code_text.Name = "code_text";
            this.code_text.Size = new System.Drawing.Size(147, 20);
            this.code_text.TabIndex = 1;
            // 
            // name_text
            // 
            this.name_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_text.Location = new System.Drawing.Point(695, 2);
            this.name_text.Margin = new System.Windows.Forms.Padding(2);
            this.name_text.MaxLength = 500;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(147, 20);
            this.name_text.TabIndex = 0;
            // 
            // service_grid
            // 
            this.service_grid.AllowUserToAddRows = false;
            this.service_grid.AllowUserToDeleteRows = false;
            this.service_grid.AutoGenerateColumns = false;
            this.service_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.service_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.service_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.service_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_select_column,
            this.s_sequence_column,
            this.s_national_id_column,
            this.s_name_column,
            this.s_category_name_column,
            this.s_sub_category_name_column,
            this.s_insurance_name_column,
            this.s_sector_name_column,
            this.s_k_factor_column,
            this.s_professional_k_column,
            this.s_technical_k_column,
            this.s_shortcut_code_column,
            this.s_start_date_column,
            this.s_description_column,
            this.s_category_column,
            this.sub_category,
            this.s_insurance_column,
            this.s_insurance_sector_column});
            this.tableLayoutPanel.SetColumnSpan(this.service_grid, 5);
            this.service_grid.DataSource = this.tMedicalServiceBindingSource;
            this.service_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.service_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.service_grid.Location = new System.Drawing.Point(252, 85);
            this.service_grid.Margin = new System.Windows.Forms.Padding(2);
            this.service_grid.MultiSelect = false;
            this.service_grid.Name = "service_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.service_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.service_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.service_grid, 8);
            this.service_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.service_grid.ShowCellErrors = false;
            this.service_grid.ShowCellToolTips = false;
            this.service_grid.Size = new System.Drawing.Size(678, 248);
            this.service_grid.TabIndex = 5;
            this.service_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.service_grid_DataBindingComplete);
            // 
            // s_select_column
            // 
            this.s_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.s_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.s_select_column.FalseValue = "false";
            this.s_select_column.Frozen = true;
            this.s_select_column.HeaderText = "";
            this.s_select_column.IndeterminateValue = "false";
            this.s_select_column.MinimumWidth = 30;
            this.s_select_column.Name = "s_select_column";
            this.s_select_column.TrueValue = "true";
            this.s_select_column.Width = 30;
            // 
            // s_sequence_column
            // 
            this.s_sequence_column.DataPropertyName = "sequence";
            this.s_sequence_column.HeaderText = "شناسه";
            this.s_sequence_column.Name = "s_sequence_column";
            this.s_sequence_column.ReadOnly = true;
            this.s_sequence_column.Width = 67;
            // 
            // s_national_id_column
            // 
            this.s_national_id_column.DataPropertyName = "national_id";
            this.s_national_id_column.HeaderText = "شناسه ملی";
            this.s_national_id_column.Name = "s_national_id_column";
            this.s_national_id_column.ReadOnly = true;
            this.s_national_id_column.Width = 81;
            // 
            // s_name_column
            // 
            this.s_name_column.DataPropertyName = "name";
            this.s_name_column.HeaderText = "نام";
            this.s_name_column.Name = "s_name_column";
            this.s_name_column.ReadOnly = true;
            this.s_name_column.Width = 47;
            // 
            // s_category_name_column
            // 
            this.s_category_name_column.DataPropertyName = "category_name";
            this.s_category_name_column.HeaderText = "نوع خدمت";
            this.s_category_name_column.Name = "s_category_name_column";
            this.s_category_name_column.ReadOnly = true;
            this.s_category_name_column.Width = 80;
            // 
            // s_sub_category_name_column
            // 
            this.s_sub_category_name_column.DataPropertyName = "sub_category_name";
            this.s_sub_category_name_column.HeaderText = "نوع فرعی خدمت";
            this.s_sub_category_name_column.Name = "s_sub_category_name_column";
            this.s_sub_category_name_column.ReadOnly = true;
            this.s_sub_category_name_column.Width = 110;
            // 
            // s_insurance_name_column
            // 
            this.s_insurance_name_column.DataPropertyName = "insurance_name";
            this.s_insurance_name_column.HeaderText = "شرکت بیمه";
            this.s_insurance_name_column.Name = "s_insurance_name_column";
            this.s_insurance_name_column.ReadOnly = true;
            this.s_insurance_name_column.Width = 85;
            // 
            // s_sector_name_column
            // 
            this.s_sector_name_column.DataPropertyName = "sector_name";
            this.s_sector_name_column.HeaderText = "صندوق بیمه";
            this.s_sector_name_column.Name = "s_sector_name_column";
            this.s_sector_name_column.ReadOnly = true;
            this.s_sector_name_column.Width = 89;
            // 
            // s_k_factor_column
            // 
            this.s_k_factor_column.DataPropertyName = "k_factor";
            this.s_k_factor_column.HeaderText = "ضریب K";
            this.s_k_factor_column.Name = "s_k_factor_column";
            this.s_k_factor_column.ReadOnly = true;
            this.s_k_factor_column.Width = 78;
            // 
            // s_professional_k_column
            // 
            this.s_professional_k_column.DataPropertyName = "professional_k";
            this.s_professional_k_column.HeaderText = "ضریب K حرفه ای";
            this.s_professional_k_column.Name = "s_professional_k_column";
            this.s_professional_k_column.ReadOnly = true;
            this.s_professional_k_column.Width = 110;
            // 
            // s_technical_k_column
            // 
            this.s_technical_k_column.DataPropertyName = "technical_k";
            this.s_technical_k_column.HeaderText = "ضریب K فنی";
            this.s_technical_k_column.Name = "s_technical_k_column";
            this.s_technical_k_column.ReadOnly = true;
            this.s_technical_k_column.Width = 82;
            // 
            // s_shortcut_code_column
            // 
            this.s_shortcut_code_column.DataPropertyName = "shortcut_code";
            this.s_shortcut_code_column.HeaderText = "شماره میانبر";
            this.s_shortcut_code_column.Name = "s_shortcut_code_column";
            this.s_shortcut_code_column.ReadOnly = true;
            this.s_shortcut_code_column.Width = 90;
            // 
            // s_start_date_column
            // 
            this.s_start_date_column.DataPropertyName = "start_date";
            this.s_start_date_column.HeaderText = "تاریخ اضافه شدن خدمت";
            this.s_start_date_column.Name = "s_start_date_column";
            this.s_start_date_column.ReadOnly = true;
            this.s_start_date_column.Width = 119;
            // 
            // s_description_column
            // 
            this.s_description_column.DataPropertyName = "description";
            this.s_description_column.HeaderText = "توضیحات";
            this.s_description_column.Name = "s_description_column";
            this.s_description_column.ReadOnly = true;
            this.s_description_column.Width = 86;
            // 
            // s_category_column
            // 
            this.s_category_column.DataPropertyName = "category";
            this.s_category_column.HeaderText = "category";
            this.s_category_column.Name = "s_category_column";
            this.s_category_column.Visible = false;
            this.s_category_column.Width = 95;
            // 
            // sub_category
            // 
            this.sub_category.DataPropertyName = "sub_category";
            this.sub_category.HeaderText = "sub_category";
            this.sub_category.Name = "sub_category";
            this.sub_category.ReadOnly = true;
            this.sub_category.Visible = false;
            this.sub_category.Width = 130;
            // 
            // s_insurance_column
            // 
            this.s_insurance_column.DataPropertyName = "insurance";
            this.s_insurance_column.HeaderText = "insurance";
            this.s_insurance_column.Name = "s_insurance_column";
            this.s_insurance_column.ReadOnly = true;
            this.s_insurance_column.Visible = false;
            this.s_insurance_column.Width = 103;
            // 
            // s_insurance_sector_column
            // 
            this.s_insurance_sector_column.DataPropertyName = "insurance_sector";
            this.s_insurance_sector_column.HeaderText = "insurance_sector";
            this.s_insurance_sector_column.Name = "s_insurance_sector_column";
            this.s_insurance_sector_column.Visible = false;
            this.s_insurance_sector_column.Width = 156;
            // 
            // tMedicalServiceBindingSource
            // 
            this.tMedicalServiceBindingSource.DataMember = "TMedicalService";
            this.tMedicalServiceBindingSource.DataSource = this.pIPDataSet;
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
            this.edit_button.Location = new System.Drawing.Point(2, 199);
            this.edit_button.Margin = new System.Windows.Forms.Padding(2);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(246, 25);
            this.edit_button.TabIndex = 7;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(2, 111);
            this.new_button.Margin = new System.Windows.Forms.Padding(2);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(246, 26);
            this.new_button.TabIndex = 6;
            this.new_button.Text = "ایجاد خدمت جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // name_label
            // 
            this.name_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.Transparent;
            this.name_label.ForeColor = System.Drawing.Color.Black;
            this.name_label.Location = new System.Drawing.Point(846, 0);
            this.name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(54, 24);
            this.name_label.TabIndex = 4;
            this.name_label.Text = "نام خدمت :";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // category_label
            // 
            this.category_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.category_label.AutoSize = true;
            this.category_label.BackColor = System.Drawing.Color.Transparent;
            this.category_label.ForeColor = System.Drawing.Color.Black;
            this.category_label.Location = new System.Drawing.Point(846, 24);
            this.category_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.category_label.Name = "category_label";
            this.category_label.Size = new System.Drawing.Size(58, 25);
            this.category_label.TabIndex = 4;
            this.category_label.Text = "نوع خدمت :";
            this.category_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // code_label
            // 
            this.code_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.code_label.AutoSize = true;
            this.code_label.BackColor = System.Drawing.Color.Transparent;
            this.code_label.ForeColor = System.Drawing.Color.Black;
            this.code_label.Location = new System.Drawing.Point(846, 49);
            this.code_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.code_label.Name = "code_label";
            this.code_label.Size = new System.Drawing.Size(53, 27);
            this.code_label.TabIndex = 23;
            this.code_label.Text = "کد خدمت :";
            this.code_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // category_combobox
            // 
            this.category_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.category_combobox.BackColor = System.Drawing.Color.White;
            this.category_combobox.DisplayMember = "id";
            this.category_combobox.DropDownHeight = 300;
            this.category_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.category_combobox.FormattingEnabled = true;
            this.category_combobox.IntegralHeight = false;
            this.category_combobox.Location = new System.Drawing.Point(695, 26);
            this.category_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.category_combobox.Name = "category_combobox";
            this.category_combobox.Size = new System.Drawing.Size(147, 21);
            this.category_combobox.TabIndex = 2;
            this.category_combobox.ValueMember = "id";
            // 
            // search_button
            // 
            this.search_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(634, 51);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(52, 23);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // tMedicalServiceTableAdapter
            // 
            this.tMedicalServiceTableAdapter.ClearBeforeFill = true;
            // 
            // MedicalServiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MedicalServiceControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(932, 476);
            this.Tag = "پزشک ها";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.service_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView service_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.TextBox code_text;
        private System.Windows.Forms.Label category_label;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label code_label;
        private System.Windows.Forms.ComboBox category_combobox;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button copy_button;
        private System.Windows.Forms.BindingSource tMedicalServiceBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.TMedicalServiceTableAdapter tMedicalServiceTableAdapter;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn s_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_sequence_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_national_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_category_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_sub_category_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_sector_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_k_factor_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_professional_k_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_technical_k_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_shortcut_code_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_start_date_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_description_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_category_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_sector_column;
    }
}
