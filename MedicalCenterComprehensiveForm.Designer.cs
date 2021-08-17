namespace PadraInsurancePrescription
{
    partial class MedicalCenterComprehensiveForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalCenterComprehensiveForm));
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.center_grid = new System.Windows.Forms.DataGridView();
            this.m_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.m_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_national_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_province_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_city_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_type_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.other_lbl = new System.Windows.Forms.Label();
            this.title_lbl = new System.Windows.Forms.Label();
            this.month_val_lbl = new System.Windows.Forms.Label();
            this.year_val_lbl = new System.Windows.Forms.Label();
            this.center_id_val_lbl = new System.Windows.Forms.Label();
            this.name_val_lbl = new System.Windows.Forms.Label();
            this.insurance_val_lbl = new System.Windows.Forms.Label();
            this.city_val_lbl = new System.Windows.Forms.Label();
            this.type_val_lbl = new System.Windows.Forms.Label();
            this.province_val_lbl = new System.Windows.Forms.Label();
            this.month_lbl = new System.Windows.Forms.Label();
            this.year_lbl = new System.Windows.Forms.Label();
            this.center_id_lbl = new System.Windows.Forms.Label();
            this.name_lbl = new System.Windows.Forms.Label();
            this.insurance_lbl = new System.Windows.Forms.Label();
            this.type_lbl = new System.Windows.Forms.Label();
            this.province_lbl = new System.Windows.Forms.Label();
            this.city_lbl = new System.Windows.Forms.Label();
            this.title_txt = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.generate_button = new System.Windows.Forms.Button();
            this.EP_name = new System.Windows.Forms.ErrorProvider(this.components);
            this.tMedicalCenterTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TMedicalCenterTableAdapter();
            this.main_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.center_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalCenterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_name)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 7;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 276F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.main_tableLayoutPanel.Controls.Add(this.center_grid, 4, 1);
            this.main_tableLayoutPanel.Controls.Add(this.other_lbl, 4, 0);
            this.main_tableLayoutPanel.Controls.Add(this.title_lbl, 1, 10);
            this.main_tableLayoutPanel.Controls.Add(this.month_val_lbl, 2, 8);
            this.main_tableLayoutPanel.Controls.Add(this.year_val_lbl, 2, 7);
            this.main_tableLayoutPanel.Controls.Add(this.center_id_val_lbl, 2, 6);
            this.main_tableLayoutPanel.Controls.Add(this.name_val_lbl, 2, 4);
            this.main_tableLayoutPanel.Controls.Add(this.insurance_val_lbl, 2, 5);
            this.main_tableLayoutPanel.Controls.Add(this.city_val_lbl, 2, 2);
            this.main_tableLayoutPanel.Controls.Add(this.type_val_lbl, 2, 3);
            this.main_tableLayoutPanel.Controls.Add(this.province_val_lbl, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.month_lbl, 1, 8);
            this.main_tableLayoutPanel.Controls.Add(this.year_lbl, 1, 7);
            this.main_tableLayoutPanel.Controls.Add(this.center_id_lbl, 1, 6);
            this.main_tableLayoutPanel.Controls.Add(this.name_lbl, 1, 4);
            this.main_tableLayoutPanel.Controls.Add(this.insurance_lbl, 1, 5);
            this.main_tableLayoutPanel.Controls.Add(this.type_lbl, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.province_lbl, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.city_lbl, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.title_txt, 2, 10);
            this.main_tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 5, 10);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 11;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(962, 429);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // center_grid
            // 
            this.center_grid.AllowUserToAddRows = false;
            this.center_grid.AllowUserToDeleteRows = false;
            this.center_grid.AutoGenerateColumns = false;
            this.center_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.center_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.center_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.m_select_column,
            this.m_id_column,
            this.m_national_id_column,
            this.m_name_column,
            this.m_province_name_column,
            this.m_city_name_column,
            this.m_type_name_column,
            this.m_address_column,
            this.m_phone_numbers_column,
            this.m_mobile_numbers_column,
            this.m_anwserable_names_column,
            this.m_description_column,
            this.m_type_id_column,
            this.m_city_id_column,
            this.m_province_id_column});
            this.main_tableLayoutPanel.SetColumnSpan(this.center_grid, 2);
            this.center_grid.DataSource = this.tMedicalCenterBindingSource;
            this.center_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.center_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.center_grid.Location = new System.Drawing.Point(26, 33);
            this.center_grid.MultiSelect = false;
            this.center_grid.Name = "center_grid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.center_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.center_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.main_tableLayoutPanel.SetRowSpan(this.center_grid, 9);
            this.center_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.center_grid.ShowCellErrors = false;
            this.center_grid.ShowCellToolTips = false;
            this.center_grid.Size = new System.Drawing.Size(470, 309);
            this.center_grid.TabIndex = 83;
            this.center_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.center_grid_DataBindingComplete);
            // 
            // m_select_column
            // 
            this.m_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.m_select_column.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.m_id_column.Width = 70;
            // 
            // m_national_id_column
            // 
            this.m_national_id_column.DataPropertyName = "national_id";
            this.m_national_id_column.HeaderText = "شناسه ملی";
            this.m_national_id_column.Name = "m_national_id_column";
            this.m_national_id_column.ReadOnly = true;
            this.m_national_id_column.Width = 94;
            // 
            // m_name_column
            // 
            this.m_name_column.DataPropertyName = "name";
            this.m_name_column.HeaderText = "نام";
            this.m_name_column.Name = "m_name_column";
            this.m_name_column.ReadOnly = true;
            this.m_name_column.Width = 51;
            // 
            // m_province_name_column
            // 
            this.m_province_name_column.DataPropertyName = "province_name";
            this.m_province_name_column.HeaderText = "استان";
            this.m_province_name_column.Name = "m_province_name_column";
            this.m_province_name_column.ReadOnly = true;
            this.m_province_name_column.Width = 66;
            // 
            // m_city_name_column
            // 
            this.m_city_name_column.DataPropertyName = "city_name";
            this.m_city_name_column.HeaderText = "شهر";
            this.m_city_name_column.Name = "m_city_name_column";
            this.m_city_name_column.ReadOnly = true;
            this.m_city_name_column.Width = 59;
            // 
            // m_type_name_column
            // 
            this.m_type_name_column.DataPropertyName = "clinic_type_name";
            this.m_type_name_column.HeaderText = "نوع مرکز";
            this.m_type_name_column.Name = "m_type_name_column";
            this.m_type_name_column.ReadOnly = true;
            this.m_type_name_column.Width = 86;
            // 
            // m_address_column
            // 
            this.m_address_column.DataPropertyName = "address";
            this.m_address_column.HeaderText = "آدرس";
            this.m_address_column.Name = "m_address_column";
            this.m_address_column.ReadOnly = true;
            this.m_address_column.Width = 71;
            // 
            // m_phone_numbers_column
            // 
            this.m_phone_numbers_column.DataPropertyName = "phone_numbers";
            this.m_phone_numbers_column.HeaderText = "شماره های تلفن ثابت";
            this.m_phone_numbers_column.Name = "m_phone_numbers_column";
            this.m_phone_numbers_column.ReadOnly = true;
            this.m_phone_numbers_column.Width = 150;
            // 
            // m_mobile_numbers_column
            // 
            this.m_mobile_numbers_column.DataPropertyName = "mobile_numbers";
            this.m_mobile_numbers_column.HeaderText = "شماره های تلفن همراه";
            this.m_mobile_numbers_column.Name = "m_mobile_numbers_column";
            this.m_mobile_numbers_column.ReadOnly = true;
            this.m_mobile_numbers_column.Width = 154;
            // 
            // m_anwserable_names_column
            // 
            this.m_anwserable_names_column.DataPropertyName = "anwserable_names";
            this.m_anwserable_names_column.HeaderText = "نام های افراد مسئول";
            this.m_anwserable_names_column.Name = "m_anwserable_names_column";
            this.m_anwserable_names_column.ReadOnly = true;
            this.m_anwserable_names_column.Width = 142;
            // 
            // m_description_column
            // 
            this.m_description_column.DataPropertyName = "description";
            this.m_description_column.HeaderText = "توضیحات";
            this.m_description_column.Name = "m_description_column";
            this.m_description_column.ReadOnly = true;
            this.m_description_column.Width = 87;
            // 
            // m_type_id_column
            // 
            this.m_type_id_column.DataPropertyName = "clinic_type";
            this.m_type_id_column.HeaderText = "clinic_type";
            this.m_type_id_column.Name = "m_type_id_column";
            this.m_type_id_column.ReadOnly = true;
            this.m_type_id_column.Visible = false;
            this.m_type_id_column.Width = 132;
            // 
            // m_city_id_column
            // 
            this.m_city_id_column.DataPropertyName = "city";
            this.m_city_id_column.HeaderText = "city";
            this.m_city_id_column.Name = "m_city_id_column";
            this.m_city_id_column.ReadOnly = true;
            this.m_city_id_column.Visible = false;
            this.m_city_id_column.Width = 68;
            // 
            // m_province_id_column
            // 
            this.m_province_id_column.DataPropertyName = "province";
            this.m_province_id_column.HeaderText = "province";
            this.m_province_id_column.Name = "m_province_id_column";
            this.m_province_id_column.ReadOnly = true;
            this.m_province_id_column.Visible = false;
            this.m_province_id_column.Width = 113;
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
            // other_lbl
            // 
            this.other_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.other_lbl.AutoSize = true;
            this.other_lbl.BackColor = System.Drawing.Color.Transparent;
            this.main_tableLayoutPanel.SetColumnSpan(this.other_lbl, 2);
            this.other_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.other_lbl.ForeColor = System.Drawing.Color.Black;
            this.other_lbl.Location = new System.Drawing.Point(29, 0);
            this.other_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.other_lbl.Name = "other_lbl";
            this.other_lbl.Size = new System.Drawing.Size(464, 30);
            this.other_lbl.TabIndex = 82;
            this.other_lbl.Text = "سایر مراکز مرتبط";
            this.other_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title_lbl
            // 
            this.title_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title_lbl.AutoSize = true;
            this.title_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.title_lbl.Location = new System.Drawing.Point(762, 345);
            this.title_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(174, 84);
            this.title_lbl.TabIndex = 80;
            this.title_lbl.Text = "تعیین عنوان اصلی مرکز در گزارش:";
            this.title_lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // month_val_lbl
            // 
            this.month_val_lbl.AutoSize = true;
            this.month_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.month_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.month_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.month_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.month_val_lbl.Location = new System.Drawing.Point(519, 275);
            this.month_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.month_val_lbl.Name = "month_val_lbl";
            this.month_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.month_val_lbl.TabIndex = 79;
            this.month_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // year_val_lbl
            // 
            this.year_val_lbl.AutoSize = true;
            this.year_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.year_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.year_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.year_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.year_val_lbl.Location = new System.Drawing.Point(519, 240);
            this.year_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.year_val_lbl.Name = "year_val_lbl";
            this.year_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.year_val_lbl.TabIndex = 78;
            this.year_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // center_id_val_lbl
            // 
            this.center_id_val_lbl.AutoSize = true;
            this.center_id_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.center_id_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.center_id_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.center_id_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.center_id_val_lbl.Location = new System.Drawing.Point(519, 205);
            this.center_id_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.center_id_val_lbl.Name = "center_id_val_lbl";
            this.center_id_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.center_id_val_lbl.TabIndex = 76;
            this.center_id_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name_val_lbl
            // 
            this.name_val_lbl.AutoSize = true;
            this.name_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.name_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.name_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.name_val_lbl.Location = new System.Drawing.Point(519, 135);
            this.name_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name_val_lbl.Name = "name_val_lbl";
            this.name_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.name_val_lbl.TabIndex = 74;
            this.name_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // insurance_val_lbl
            // 
            this.insurance_val_lbl.AutoSize = true;
            this.insurance_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.insurance_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insurance_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.insurance_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.insurance_val_lbl.Location = new System.Drawing.Point(519, 170);
            this.insurance_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.insurance_val_lbl.Name = "insurance_val_lbl";
            this.insurance_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.insurance_val_lbl.TabIndex = 73;
            this.insurance_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // city_val_lbl
            // 
            this.city_val_lbl.AutoSize = true;
            this.city_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.city_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.city_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.city_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.city_val_lbl.Location = new System.Drawing.Point(519, 65);
            this.city_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.city_val_lbl.Name = "city_val_lbl";
            this.city_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.city_val_lbl.TabIndex = 72;
            this.city_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // type_val_lbl
            // 
            this.type_val_lbl.AutoSize = true;
            this.type_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.type_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.type_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.type_val_lbl.Location = new System.Drawing.Point(519, 100);
            this.type_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.type_val_lbl.Name = "type_val_lbl";
            this.type_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.type_val_lbl.TabIndex = 71;
            this.type_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // province_val_lbl
            // 
            this.province_val_lbl.AutoSize = true;
            this.province_val_lbl.BackColor = System.Drawing.Color.Transparent;
            this.province_val_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.province_val_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.province_val_lbl.ForeColor = System.Drawing.Color.Navy;
            this.province_val_lbl.Location = new System.Drawing.Point(519, 30);
            this.province_val_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.province_val_lbl.Name = "province_val_lbl";
            this.province_val_lbl.Size = new System.Drawing.Size(231, 35);
            this.province_val_lbl.TabIndex = 69;
            this.province_val_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // month_lbl
            // 
            this.month_lbl.AutoSize = true;
            this.month_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.month_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.month_lbl.Location = new System.Drawing.Point(762, 275);
            this.month_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.month_lbl.Name = "month_lbl";
            this.month_lbl.Size = new System.Drawing.Size(174, 35);
            this.month_lbl.TabIndex = 68;
            this.month_lbl.Text = "ماه عملکرد:";
            this.month_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // year_lbl
            // 
            this.year_lbl.AutoSize = true;
            this.year_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.year_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.year_lbl.Location = new System.Drawing.Point(762, 240);
            this.year_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.year_lbl.Name = "year_lbl";
            this.year_lbl.Size = new System.Drawing.Size(174, 35);
            this.year_lbl.TabIndex = 67;
            this.year_lbl.Text = "سال عملکرد:";
            this.year_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // center_id_lbl
            // 
            this.center_id_lbl.AutoSize = true;
            this.center_id_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.center_id_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.center_id_lbl.Location = new System.Drawing.Point(762, 205);
            this.center_id_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.center_id_lbl.Name = "center_id_lbl";
            this.center_id_lbl.Size = new System.Drawing.Size(174, 35);
            this.center_id_lbl.TabIndex = 66;
            this.center_id_lbl.Text = "شناسه سازمانی مرکز:";
            this.center_id_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.name_lbl.Location = new System.Drawing.Point(762, 135);
            this.name_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(174, 35);
            this.name_lbl.TabIndex = 64;
            this.name_lbl.Text = "نام مرکز درمانگاهی:";
            this.name_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // insurance_lbl
            // 
            this.insurance_lbl.AutoSize = true;
            this.insurance_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insurance_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.insurance_lbl.Location = new System.Drawing.Point(762, 170);
            this.insurance_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.insurance_lbl.Name = "insurance_lbl";
            this.insurance_lbl.Size = new System.Drawing.Size(174, 35);
            this.insurance_lbl.TabIndex = 63;
            this.insurance_lbl.Text = "سازمان بیمه گر:";
            this.insurance_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // type_lbl
            // 
            this.type_lbl.AutoSize = true;
            this.type_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.type_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.type_lbl.Location = new System.Drawing.Point(762, 100);
            this.type_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.type_lbl.Name = "type_lbl";
            this.type_lbl.Size = new System.Drawing.Size(174, 35);
            this.type_lbl.TabIndex = 62;
            this.type_lbl.Text = "نوع مرکز درمانگاهی:";
            this.type_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // province_lbl
            // 
            this.province_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.province_lbl.AutoSize = true;
            this.province_lbl.BackColor = System.Drawing.Color.Transparent;
            this.province_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.province_lbl.ForeColor = System.Drawing.Color.Black;
            this.province_lbl.Location = new System.Drawing.Point(762, 30);
            this.province_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.province_lbl.Name = "province_lbl";
            this.province_lbl.Size = new System.Drawing.Size(174, 35);
            this.province_lbl.TabIndex = 42;
            this.province_lbl.Text = "استان:";
            this.province_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // city_lbl
            // 
            this.city_lbl.AutoSize = true;
            this.city_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.city_lbl.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.city_lbl.Location = new System.Drawing.Point(762, 65);
            this.city_lbl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.city_lbl.Name = "city_lbl";
            this.city_lbl.Size = new System.Drawing.Size(174, 35);
            this.city_lbl.TabIndex = 40;
            this.city_lbl.Text = "شهرستان:";
            this.city_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // title_txt
            // 
            this.title_txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title_txt.Location = new System.Drawing.Point(519, 351);
            this.title_txt.Margin = new System.Windows.Forms.Padding(6);
            this.title_txt.MaxLength = 20;
            this.title_txt.Name = "title_txt";
            this.title_txt.Size = new System.Drawing.Size(231, 34);
            this.title_txt.TabIndex = 2;
            this.title_txt.Tag = "1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancel_button);
            this.flowLayoutPanel1.Controls.Add(this.generate_button);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(38, 351);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(22, 0, 9, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(255, 72);
            this.flowLayoutPanel1.TabIndex = 61;
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
            this.cancel_button.TabIndex = 15;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // generate_button
            // 
            this.generate_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.generate_button.AutoSize = true;
            this.generate_button.CausesValidation = false;
            this.generate_button.Location = new System.Drawing.Point(140, 6);
            this.generate_button.Margin = new System.Windows.Forms.Padding(6);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(100, 48);
            this.generate_button.TabIndex = 14;
            this.generate_button.Text = "تولید گزارش";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // EP_name
            // 
            this.EP_name.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_name.ContainerControl = this;
            this.EP_name.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_name.Icon")));
            this.EP_name.RightToLeft = true;
            // 
            // tMedicalCenterTableAdapter
            // 
            this.tMedicalCenterTableAdapter.ClearBeforeFill = true;
            // 
            // MedicalCenterComprehensiveForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(962, 429);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MedicalCenterComprehensiveForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "انتخاب مراکز درمانگاهی برای تولید گزارش جامع عملکرد";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.center_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalCenterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_name)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.TextBox title_txt;
        private System.Windows.Forms.ErrorProvider EP_name;
        private System.Windows.Forms.Label city_lbl;
        private System.Windows.Forms.Label province_lbl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.Label month_val_lbl;
        private System.Windows.Forms.Label year_val_lbl;
        private System.Windows.Forms.Label center_id_val_lbl;
        private System.Windows.Forms.Label name_val_lbl;
        private System.Windows.Forms.Label insurance_val_lbl;
        private System.Windows.Forms.Label city_val_lbl;
        private System.Windows.Forms.Label type_val_lbl;
        private System.Windows.Forms.Label province_val_lbl;
        private System.Windows.Forms.Label month_lbl;
        private System.Windows.Forms.Label year_lbl;
        private System.Windows.Forms.Label center_id_lbl;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Label insurance_lbl;
        private System.Windows.Forms.Label type_lbl;
        private System.Windows.Forms.Label other_lbl;
        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.BindingSource tMedicalCenterBindingSource;
        private PIPDataSetTableAdapters.TMedicalCenterTableAdapter tMedicalCenterTableAdapter;
        private System.Windows.Forms.DataGridView center_grid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn m_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_national_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_province_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_city_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn m_type_name_column;
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