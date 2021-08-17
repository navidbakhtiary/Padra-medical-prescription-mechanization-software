namespace PadraInsurancePrescription
{
    partial class ProvinceCityControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.city_grid = new System.Windows.Forms.DataGridView();
            this.c_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_province_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.c_search_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c_name_search = new System.Windows.Forms.TextBox();
            this.c_search_button = new System.Windows.Forms.Button();
            this.c_edit_button = new System.Windows.Forms.Button();
            this.province_grid = new System.Windows.Forms.DataGridView();
            this.p_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provinceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.c_new_button = new System.Windows.Forms.Button();
            this.c_delete_button = new System.Windows.Forms.Button();
            this.p_new_button = new System.Windows.Forms.Button();
            this.p_edit_button = new System.Windows.Forms.Button();
            this.p_delete_button = new System.Windows.Forms.Button();
            this.p_cities_button = new System.Windows.Forms.Button();
            this.p_search_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.province_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.p_name_search = new System.Windows.Forms.TextBox();
            this.p_search_button = new System.Windows.Forms.Button();
            this.error_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provinceTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.ProvinceTableAdapter();
            this.tCityTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TCityTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.city_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.c_search_flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.province_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).BeginInit();
            this.p_search_flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 742F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel.Controls.Add(this.city_grid, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.c_search_flowLayoutPanel, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.c_edit_button, 1, 12);
            this.tableLayoutPanel.Controls.Add(this.province_grid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.c_new_button, 1, 11);
            this.tableLayoutPanel.Controls.Add(this.c_delete_button, 1, 13);
            this.tableLayoutPanel.Controls.Add(this.p_new_button, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.p_edit_button, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.p_delete_button, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.p_cities_button, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.p_search_flowLayoutPanel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 19;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(897, 772);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // city_grid
            // 
            this.city_grid.AllowUserToAddRows = false;
            this.city_grid.AllowUserToDeleteRows = false;
            this.city_grid.AutoGenerateColumns = false;
            this.city_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.city_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.city_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.city_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_select_column,
            this.c_id_column,
            this.c_name_column,
            this.c_province_name_column});
            this.city_grid.DataSource = this.tCityBindingSource;
            this.city_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.city_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.city_grid.Location = new System.Drawing.Point(158, 432);
            this.city_grid.MultiSelect = false;
            this.city_grid.Name = "city_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.city_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.city_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.city_grid, 6);
            this.city_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.city_grid.ShowCellErrors = false;
            this.city_grid.ShowCellToolTips = false;
            this.city_grid.Size = new System.Drawing.Size(736, 332);
            this.city_grid.TabIndex = 17;
            this.city_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.city_grid_DataBindingComplete);
            // 
            // c_select_column
            // 
            this.c_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.c_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.c_select_column.FalseValue = "false";
            this.c_select_column.Frozen = true;
            this.c_select_column.HeaderText = "";
            this.c_select_column.IndeterminateValue = "false";
            this.c_select_column.MinimumWidth = 30;
            this.c_select_column.Name = "c_select_column";
            this.c_select_column.TrueValue = "true";
            this.c_select_column.Width = 30;
            // 
            // c_id_column
            // 
            this.c_id_column.DataPropertyName = "id";
            this.c_id_column.HeaderText = "شناسه";
            this.c_id_column.Name = "c_id_column";
            this.c_id_column.ReadOnly = true;
            this.c_id_column.Width = 67;
            // 
            // c_name_column
            // 
            this.c_name_column.DataPropertyName = "name";
            this.c_name_column.HeaderText = "نام شهر";
            this.c_name_column.Name = "c_name_column";
            this.c_name_column.Width = 74;
            // 
            // c_province_name_column
            // 
            this.c_province_name_column.DataPropertyName = "province_name";
            this.c_province_name_column.HeaderText = "استان";
            this.c_province_name_column.Name = "c_province_name_column";
            this.c_province_name_column.ReadOnly = true;
            this.c_province_name_column.Width = 63;
            // 
            // tCityBindingSource
            // 
            this.tCityBindingSource.DataMember = "TCity";
            this.tCityBindingSource.DataSource = this.pIPDataSet;
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.EnforceConstraints = false;
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // c_search_flowLayoutPanel
            // 
            this.tableLayoutPanel.SetColumnSpan(this.c_search_flowLayoutPanel, 2);
            this.c_search_flowLayoutPanel.Controls.Add(this.label1);
            this.c_search_flowLayoutPanel.Controls.Add(this.label3);
            this.c_search_flowLayoutPanel.Controls.Add(this.c_name_search);
            this.c_search_flowLayoutPanel.Controls.Add(this.c_search_button);
            this.c_search_flowLayoutPanel.Location = new System.Drawing.Point(4, 382);
            this.c_search_flowLayoutPanel.Name = "c_search_flowLayoutPanel";
            this.c_search_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.c_search_flowLayoutPanel.Size = new System.Drawing.Size(890, 43);
            this.c_search_flowLayoutPanel.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(818, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "شهرها";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(763, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 33);
            this.label3.TabIndex = 12;
            this.label3.Text = "نام شهر :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c_name_search
            // 
            this.c_name_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.c_name_search.Location = new System.Drawing.Point(611, 5);
            this.c_name_search.MaxLength = 250;
            this.c_name_search.Name = "c_name_search";
            this.c_name_search.Size = new System.Drawing.Size(146, 20);
            this.c_name_search.TabIndex = 11;
            // 
            // c_search_button
            // 
            this.c_search_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.c_search_button.AutoSize = true;
            this.c_search_button.Location = new System.Drawing.Point(535, 5);
            this.c_search_button.Name = "c_search_button";
            this.c_search_button.Size = new System.Drawing.Size(70, 27);
            this.c_search_button.TabIndex = 13;
            this.c_search_button.Text = "جستجو";
            this.c_search_button.UseVisualStyleBackColor = true;
            this.c_search_button.Click += new System.EventHandler(this.c_search_button_Click);
            // 
            // c_edit_button
            // 
            this.c_edit_button.AutoSize = true;
            this.c_edit_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_edit_button.Location = new System.Drawing.Point(3, 503);
            this.c_edit_button.Name = "c_edit_button";
            this.c_edit_button.Size = new System.Drawing.Size(149, 35);
            this.c_edit_button.TabIndex = 14;
            this.c_edit_button.Text = "ویرایش انتخاب شده ها";
            this.c_edit_button.UseVisualStyleBackColor = true;
            this.c_edit_button.Click += new System.EventHandler(this.c_edit_button_Click);
            // 
            // province_grid
            // 
            this.province_grid.AllowUserToAddRows = false;
            this.province_grid.AllowUserToDeleteRows = false;
            this.province_grid.AllowUserToResizeRows = false;
            this.province_grid.AutoGenerateColumns = false;
            this.province_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.province_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.province_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.province_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_select_column,
            this.p_id_column,
            this.p_name_column});
            this.province_grid.DataSource = this.provinceBindingSource;
            this.province_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.province_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.province_grid.Location = new System.Drawing.Point(158, 53);
            this.province_grid.MultiSelect = false;
            this.province_grid.Name = "province_grid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.province_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.province_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.province_grid, 7);
            this.province_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.province_grid.ShowCellErrors = false;
            this.province_grid.ShowCellToolTips = false;
            this.province_grid.Size = new System.Drawing.Size(736, 303);
            this.province_grid.TabIndex = 0;
            this.province_grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.province_grid_CurrentCellDirtyStateChanged);
            this.province_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.province_grid_DataBindingComplete);
            // 
            // p_select_column
            // 
            this.p_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.NullValue = false;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            this.p_select_column.DefaultCellStyle = dataGridViewCellStyle5;
            this.p_select_column.FalseValue = "false";
            this.p_select_column.Frozen = true;
            this.p_select_column.HeaderText = "";
            this.p_select_column.IndeterminateValue = "false";
            this.p_select_column.MinimumWidth = 30;
            this.p_select_column.Name = "p_select_column";
            this.p_select_column.TrueValue = "true";
            this.p_select_column.Width = 30;
            // 
            // p_id_column
            // 
            this.p_id_column.DataPropertyName = "id";
            this.p_id_column.Frozen = true;
            this.p_id_column.HeaderText = "شناسه";
            this.p_id_column.Name = "p_id_column";
            this.p_id_column.ReadOnly = true;
            this.p_id_column.Width = 67;
            // 
            // p_name_column
            // 
            this.p_name_column.DataPropertyName = "name";
            this.p_name_column.HeaderText = "نام استان";
            this.p_name_column.Name = "p_name_column";
            this.p_name_column.ReadOnly = true;
            this.p_name_column.Width = 80;
            // 
            // provinceBindingSource
            // 
            this.provinceBindingSource.DataMember = "Province";
            this.provinceBindingSource.DataSource = this.pIPDataSet;
            // 
            // c_new_button
            // 
            this.c_new_button.AutoSize = true;
            this.c_new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_new_button.Location = new System.Drawing.Point(3, 462);
            this.c_new_button.Name = "c_new_button";
            this.c_new_button.Size = new System.Drawing.Size(149, 35);
            this.c_new_button.TabIndex = 8;
            this.c_new_button.Text = "ایجاد شهر جدید";
            this.c_new_button.UseVisualStyleBackColor = true;
            this.c_new_button.Click += new System.EventHandler(this.c_new_button_Click);
            // 
            // c_delete_button
            // 
            this.c_delete_button.AutoSize = true;
            this.c_delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_delete_button.Location = new System.Drawing.Point(3, 544);
            this.c_delete_button.Name = "c_delete_button";
            this.c_delete_button.Size = new System.Drawing.Size(149, 35);
            this.c_delete_button.TabIndex = 7;
            this.c_delete_button.Text = "حذف انتخاب شده ها";
            this.c_delete_button.UseVisualStyleBackColor = true;
            this.c_delete_button.Click += new System.EventHandler(this.c_delete_button_Click);
            // 
            // p_new_button
            // 
            this.p_new_button.AutoSize = true;
            this.p_new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_new_button.Location = new System.Drawing.Point(3, 124);
            this.p_new_button.Name = "p_new_button";
            this.p_new_button.Size = new System.Drawing.Size(149, 35);
            this.p_new_button.TabIndex = 4;
            this.p_new_button.Text = "ایجاد استان جدید";
            this.p_new_button.UseVisualStyleBackColor = true;
            this.p_new_button.Click += new System.EventHandler(this.p_new_button_Click);
            // 
            // p_edit_button
            // 
            this.p_edit_button.AutoSize = true;
            this.p_edit_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_edit_button.Location = new System.Drawing.Point(3, 165);
            this.p_edit_button.Name = "p_edit_button";
            this.p_edit_button.Size = new System.Drawing.Size(149, 35);
            this.p_edit_button.TabIndex = 5;
            this.p_edit_button.Text = "ویرایش انتخاب شده";
            this.p_edit_button.UseVisualStyleBackColor = true;
            this.p_edit_button.Click += new System.EventHandler(this.p_edit_button_Click);
            // 
            // p_delete_button
            // 
            this.p_delete_button.AutoSize = true;
            this.p_delete_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_delete_button.Location = new System.Drawing.Point(3, 206);
            this.p_delete_button.Name = "p_delete_button";
            this.p_delete_button.Size = new System.Drawing.Size(149, 35);
            this.p_delete_button.TabIndex = 3;
            this.p_delete_button.Text = "حذف انتخاب شده ها";
            this.p_delete_button.UseVisualStyleBackColor = true;
            this.p_delete_button.Click += new System.EventHandler(this.p_delete_province_Click);
            // 
            // p_cities_button
            // 
            this.p_cities_button.AutoSize = true;
            this.p_cities_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_cities_button.Location = new System.Drawing.Point(3, 83);
            this.p_cities_button.Name = "p_cities_button";
            this.p_cities_button.Size = new System.Drawing.Size(149, 35);
            this.p_cities_button.TabIndex = 9;
            this.p_cities_button.Text = "مشاهده شهرها";
            this.p_cities_button.UseVisualStyleBackColor = true;
            this.p_cities_button.Click += new System.EventHandler(this.p_cities_button_Click);
            // 
            // p_search_flowLayoutPanel
            // 
            this.tableLayoutPanel.SetColumnSpan(this.p_search_flowLayoutPanel, 2);
            this.p_search_flowLayoutPanel.Controls.Add(this.province_label);
            this.p_search_flowLayoutPanel.Controls.Add(this.label2);
            this.p_search_flowLayoutPanel.Controls.Add(this.p_name_search);
            this.p_search_flowLayoutPanel.Controls.Add(this.p_search_button);
            this.p_search_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_search_flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.p_search_flowLayoutPanel.Name = "p_search_flowLayoutPanel";
            this.p_search_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.p_search_flowLayoutPanel.Size = new System.Drawing.Size(891, 44);
            this.p_search_flowLayoutPanel.TabIndex = 15;
            // 
            // province_label
            // 
            this.province_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.province_label.BackColor = System.Drawing.Color.Blue;
            this.province_label.ForeColor = System.Drawing.Color.White;
            this.province_label.Location = new System.Drawing.Point(819, 2);
            this.province_label.Name = "province_label";
            this.province_label.Size = new System.Drawing.Size(65, 33);
            this.province_label.TabIndex = 2;
            this.province_label.Text = "استان ها";
            this.province_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(757, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "نام استان :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_name_search
            // 
            this.p_name_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_name_search.Location = new System.Drawing.Point(605, 5);
            this.p_name_search.MaxLength = 250;
            this.p_name_search.Name = "p_name_search";
            this.p_name_search.Size = new System.Drawing.Size(146, 20);
            this.p_name_search.TabIndex = 3;
            // 
            // p_search_button
            // 
            this.p_search_button.AutoSize = true;
            this.p_search_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_search_button.Location = new System.Drawing.Point(529, 5);
            this.p_search_button.Name = "p_search_button";
            this.p_search_button.Size = new System.Drawing.Size(70, 27);
            this.p_search_button.TabIndex = 10;
            this.p_search_button.Text = "جستجو";
            this.p_search_button.UseVisualStyleBackColor = true;
            this.p_search_button.Click += new System.EventHandler(this.p_search_button_Click);
            // 
            // error_tooltip
            // 
            this.error_tooltip.AutoPopDelay = 5000;
            this.error_tooltip.InitialDelay = 200;
            this.error_tooltip.ReshowDelay = 100;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.NullValue = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewCheckBoxColumn1.FalseValue = "false";
            this.dataGridViewCheckBoxColumn1.Frozen = true;
            this.dataGridViewCheckBoxColumn1.HeaderText = "";
            this.dataGridViewCheckBoxColumn1.IndeterminateValue = "false";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 30;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.TrueValue = "true";
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "شناسه";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 67;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "نام استان";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.Frozen = true;
            this.dataGridViewCheckBoxColumn2.HeaderText = "";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 25;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn3.HeaderText = "شناسه";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn4.HeaderText = "نام شهر";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "province_name";
            this.dataGridViewTextBoxColumn5.HeaderText = "استان";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // provinceTableAdapter
            // 
            this.provinceTableAdapter.ClearBeforeFill = true;
            // 
            // tCityTableAdapter
            // 
            this.tCityTableAdapter.ClearBeforeFill = true;
            // 
            // ProvinceCityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ProvinceCityControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(897, 772);
            this.Tag = "استان ها و شهرها";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.city_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.c_search_flowLayoutPanel.ResumeLayout(false);
            this.c_search_flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.province_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).EndInit();
            this.p_search_flowLayoutPanel.ResumeLayout(false);
            this.p_search_flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView province_grid;
        private System.Windows.Forms.Label province_label;
        private System.Windows.Forms.Button p_new_button;
        private System.Windows.Forms.Button p_edit_button;
        private System.Windows.Forms.Button c_new_button;
        private System.Windows.Forms.Button p_delete_button;
        private System.Windows.Forms.Button c_delete_button;
        private System.Windows.Forms.Button p_cities_button;
        private System.Windows.Forms.ToolTip error_tooltip;
        private System.Windows.Forms.Button c_edit_button;
        private System.Windows.Forms.BindingSource provinceBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.ProvinceTableAdapter provinceTableAdapter;
        private System.Windows.Forms.FlowLayoutPanel p_search_flowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel c_search_flowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_name_search;
        private System.Windows.Forms.Button c_search_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox p_name_search;
        private System.Windows.Forms.Button p_search_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView city_grid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name_column;
        private System.Windows.Forms.BindingSource tCityBindingSource;
        private PIPDataSetTableAdapters.TCityTableAdapter tCityTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_province_name_column;
    }
}
