namespace PadraInsurancePrescription
{
    partial class MedicalServiceTariffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MedicalServiceTariffForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.EP_service_tab = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_service = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_alias = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_end_date = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_description = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_start_date = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_public = new System.Windows.Forms.ErrorProvider(this.components);
            this.main_tabControl = new System.Windows.Forms.TabControl();
            this.service_tab = new System.Windows.Forms.TabPage();
            this.service_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.s_service_grid = new System.Windows.Forms.DataGridView();
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
            this.s_start_date_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_category_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sub_category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_insurance_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_insurance_sector_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tMedicalServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.s_selected_textbox = new System.Windows.Forms.TextBox();
            this.s_code_text = new System.Windows.Forms.TextBox();
            this.s_name_text = new System.Windows.Forms.TextBox();
            this.s_name_label = new System.Windows.Forms.Label();
            this.s_category_label = new System.Windows.Forms.Label();
            this.code_label = new System.Windows.Forms.Label();
            this.s_category_combobox = new System.Windows.Forms.ComboBox();
            this.s_search_button = new System.Windows.Forms.Button();
            this.info_tab = new System.Windows.Forms.TabPage();
            this.info_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.i_start_date_masked = new System.Windows.Forms.MaskedTextBox();
            this.i_insurance_combobox = new System.Windows.Forms.ComboBox();
            this.i_sector_checkbox = new System.Windows.Forms.CheckBox();
            this.i_sector_label = new System.Windows.Forms.Label();
            this.i_sector_combobox = new System.Windows.Forms.ComboBox();
            this.i_description_checkbox = new System.Windows.Forms.CheckBox();
            this.i_clear_label = new System.Windows.Forms.Label();
            this.i_end_date_label = new System.Windows.Forms.Label();
            this.i_degree_combobox = new System.Windows.Forms.ComboBox();
            this.i_alias_label = new System.Windows.Forms.Label();
            this.i_insurance_label = new System.Windows.Forms.Label();
            this.i_degree_label = new System.Windows.Forms.Label();
            this.i_start_date_label = new System.Windows.Forms.Label();
            this.i_alias_textbox = new System.Windows.Forms.TextBox();
            this.i_sequence_textbox = new System.Windows.Forms.TextBox();
            this.i_sequence_label = new System.Windows.Forms.Label();
            this.i_description_label = new System.Windows.Forms.Label();
            this.i_description_textbox = new System.Windows.Forms.TextBox();
            this.i_sequence_checkbox = new System.Windows.Forms.CheckBox();
            this.i_alias_checkbox = new System.Windows.Forms.CheckBox();
            this.i_insurance_checkbox = new System.Windows.Forms.CheckBox();
            this.i_degree_checkbox = new System.Windows.Forms.CheckBox();
            this.i_start_date_checkbox = new System.Windows.Forms.CheckBox();
            this.i_end_date_checkbox = new System.Windows.Forms.CheckBox();
            this.i_end_date_masked = new System.Windows.Forms.MaskedTextBox();
            this.k_value_tab = new System.Windows.Forms.TabPage();
            this.k_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.k_search_button = new System.Windows.Forms.Button();
            this.k_private_grid = new System.Windows.Forms.DataGridView();
            this.k_pri_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.k_pri_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_prof_value_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_tec_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_year_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_third_value_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_ins_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_sector_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_start_date_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pri_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.k_private_lbl = new System.Windows.Forms.Label();
            this.k_public_grid = new System.Windows.Forms.DataGridView();
            this.k_pub_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.k_pu_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_professional_value_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_technical_value_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_year_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_third_value_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_insurance_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_insurance_sector_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_start_date_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_pu_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_public_lbl = new System.Windows.Forms.Label();
            this.k_year_cbx = new System.Windows.Forms.ComboBox();
            this.k_year_lbl = new System.Windows.Forms.Label();
            this.tariff_tab = new System.Windows.Forms.TabPage();
            this.tariff_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.private_discount_label = new System.Windows.Forms.Label();
            this.private_discount_checkbox = new System.Windows.Forms.CheckBox();
            this.public_discount_checkbox = new System.Windows.Forms.CheckBox();
            this.public_discount_textbox = new System.Windows.Forms.TextBox();
            this.public_discount_label = new System.Windows.Forms.Label();
            this.private_pat_sha_label = new System.Windows.Forms.Label();
            this.private_ins_sha_label = new System.Windows.Forms.Label();
            this.private_k_label = new System.Windows.Forms.Label();
            this.private_ins_per_label = new System.Windows.Forms.Label();
            this.private_pat_per_label = new System.Windows.Forms.Label();
            this.private_ins_sha_checkbox = new System.Windows.Forms.CheckBox();
            this.private_pat_per_checkbox = new System.Windows.Forms.CheckBox();
            this.private_k_checkbox = new System.Windows.Forms.CheckBox();
            this.private_pat_sha_checkbox = new System.Windows.Forms.CheckBox();
            this.private_ins_per_checkbox = new System.Windows.Forms.CheckBox();
            this.private_k_textbox = new System.Windows.Forms.TextBox();
            this.private_ins_sha_textbox = new System.Windows.Forms.TextBox();
            this.private_ins_per_textbox = new System.Windows.Forms.TextBox();
            this.private_pat_per_textbox = new System.Windows.Forms.TextBox();
            this.private_pat_sha_textbox = new System.Windows.Forms.TextBox();
            this.private_total_textbox = new System.Windows.Forms.TextBox();
            this.public_k_textbox = new System.Windows.Forms.TextBox();
            this.public_ins_per_textbox = new System.Windows.Forms.TextBox();
            this.public_pat_per_textbox = new System.Windows.Forms.TextBox();
            this.public_ins_per_checkbox = new System.Windows.Forms.CheckBox();
            this.public_ins_per_label = new System.Windows.Forms.Label();
            this.private_total_label = new System.Windows.Forms.Label();
            this.public_ins_sha_label = new System.Windows.Forms.Label();
            this.public_pat_per_label = new System.Windows.Forms.Label();
            this.public_k_label = new System.Windows.Forms.Label();
            this.public_ins_sha_textbox = new System.Windows.Forms.TextBox();
            this.public_total_textbox = new System.Windows.Forms.TextBox();
            this.public_total_label = new System.Windows.Forms.Label();
            this.public_pat_sha_label = new System.Windows.Forms.Label();
            this.public_pat_sha_textbox = new System.Windows.Forms.TextBox();
            this.public_total_checkbox = new System.Windows.Forms.CheckBox();
            this.public_pat_sha_checkbox = new System.Windows.Forms.CheckBox();
            this.public_ins_sha_checkbox = new System.Windows.Forms.CheckBox();
            this.public_pat_per_checkbox = new System.Windows.Forms.CheckBox();
            this.public_k_checkbox = new System.Windows.Forms.CheckBox();
            this.private_total_checkbox = new System.Windows.Forms.CheckBox();
            this.private_discount_textbox = new System.Windows.Forms.TextBox();
            this.t_clear_label = new System.Windows.Forms.Label();
            this.form_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttons_flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.EP_degree = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_info_tab = new System.Windows.Forms.ErrorProvider(this.components);
            this.EP_tariff_tab = new System.Windows.Forms.ErrorProvider(this.components);
            this.kValueTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.KValueTableAdapter();
            this.tMedicalServiceTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TMedicalServiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EP_service_tab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_alias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_end_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_description)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_start_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_public)).BeginInit();
            this.main_tabControl.SuspendLayout();
            this.service_tab.SuspendLayout();
            this.service_tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s_service_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalServiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.info_tab.SuspendLayout();
            this.info_tableLayout.SuspendLayout();
            this.k_value_tab.SuspendLayout();
            this.k_tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k_private_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kValueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_public_grid)).BeginInit();
            this.tariff_tab.SuspendLayout();
            this.tariff_tableLayout.SuspendLayout();
            this.form_tableLayout.SuspendLayout();
            this.buttons_flowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_degree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_info_tab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_tariff_tab)).BeginInit();
            this.SuspendLayout();
            // 
            // EP_service_tab
            // 
            this.EP_service_tab.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_service_tab.ContainerControl = this;
            this.EP_service_tab.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_service_tab.Icon")));
            this.EP_service_tab.RightToLeft = true;
            // 
            // EP_service
            // 
            this.EP_service.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_service.ContainerControl = this;
            this.EP_service.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_service.Icon")));
            this.EP_service.RightToLeft = true;
            // 
            // EP_alias
            // 
            this.EP_alias.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_alias.ContainerControl = this;
            this.EP_alias.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_alias.Icon")));
            this.EP_alias.RightToLeft = true;
            // 
            // EP_end_date
            // 
            this.EP_end_date.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_end_date.ContainerControl = this;
            this.EP_end_date.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_end_date.Icon")));
            this.EP_end_date.RightToLeft = true;
            // 
            // EP_description
            // 
            this.EP_description.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_description.ContainerControl = this;
            this.EP_description.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_description.Icon")));
            this.EP_description.RightToLeft = true;
            // 
            // EP_start_date
            // 
            this.EP_start_date.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_start_date.ContainerControl = this;
            this.EP_start_date.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_start_date.Icon")));
            this.EP_start_date.RightToLeft = true;
            // 
            // EP_public
            // 
            this.EP_public.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_public.ContainerControl = this;
            this.EP_public.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_public.Icon")));
            this.EP_public.RightToLeft = true;
            // 
            // main_tabControl
            // 
            this.main_tabControl.Controls.Add(this.service_tab);
            this.main_tabControl.Controls.Add(this.info_tab);
            this.main_tabControl.Controls.Add(this.k_value_tab);
            this.main_tabControl.Controls.Add(this.tariff_tab);
            this.main_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tabControl.Location = new System.Drawing.Point(2, 2);
            this.main_tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.main_tabControl.Multiline = true;
            this.main_tabControl.Name = "main_tabControl";
            this.main_tabControl.RightToLeftLayout = true;
            this.main_tabControl.SelectedIndex = 0;
            this.main_tabControl.ShowToolTips = true;
            this.main_tabControl.Size = new System.Drawing.Size(701, 510);
            this.main_tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.main_tabControl.TabIndex = 5;
            // 
            // service_tab
            // 
            this.service_tab.AutoScroll = true;
            this.service_tab.Controls.Add(this.service_tableLayout);
            this.service_tab.Location = new System.Drawing.Point(4, 36);
            this.service_tab.Margin = new System.Windows.Forms.Padding(2);
            this.service_tab.Name = "service_tab";
            this.service_tab.Padding = new System.Windows.Forms.Padding(2);
            this.service_tab.Size = new System.Drawing.Size(693, 470);
            this.service_tab.TabIndex = 2;
            this.service_tab.Text = "انتخاب خدمت";
            this.service_tab.UseVisualStyleBackColor = true;
            // 
            // service_tableLayout
            // 
            this.service_tableLayout.AutoScroll = true;
            this.service_tableLayout.AutoSize = true;
            this.service_tableLayout.ColumnCount = 6;
            this.service_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.service_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.service_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.service_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.service_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.service_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.service_tableLayout.Controls.Add(this.s_service_grid, 1, 7);
            this.service_tableLayout.Controls.Add(this.s_selected_textbox, 1, 5);
            this.service_tableLayout.Controls.Add(this.s_code_text, 2, 3);
            this.service_tableLayout.Controls.Add(this.s_name_text, 2, 1);
            this.service_tableLayout.Controls.Add(this.s_name_label, 1, 1);
            this.service_tableLayout.Controls.Add(this.s_category_label, 1, 2);
            this.service_tableLayout.Controls.Add(this.code_label, 1, 3);
            this.service_tableLayout.Controls.Add(this.s_category_combobox, 2, 2);
            this.service_tableLayout.Controls.Add(this.s_search_button, 3, 3);
            this.service_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.service_tableLayout.Location = new System.Drawing.Point(2, 2);
            this.service_tableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.service_tableLayout.Name = "service_tableLayout";
            this.service_tableLayout.RowCount = 8;
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.service_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.service_tableLayout.Size = new System.Drawing.Size(689, 466);
            this.service_tableLayout.TabIndex = 2;
            // 
            // s_service_grid
            // 
            this.s_service_grid.AllowUserToAddRows = false;
            this.s_service_grid.AllowUserToDeleteRows = false;
            this.s_service_grid.AutoGenerateColumns = false;
            this.s_service_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.s_service_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.s_service_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.s_start_date_column,
            this.s_description_column,
            this.s_category_column,
            this.sub_category,
            this.s_insurance_column,
            this.s_insurance_sector_column});
            this.service_tableLayout.SetColumnSpan(this.s_service_grid, 4);
            this.s_service_grid.DataSource = this.tMedicalServiceBindingSource;
            this.s_service_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s_service_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.s_service_grid.Location = new System.Drawing.Point(41, 189);
            this.s_service_grid.Margin = new System.Windows.Forms.Padding(2);
            this.s_service_grid.MultiSelect = false;
            this.s_service_grid.Name = "s_service_grid";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.s_service_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.s_service_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.s_service_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.s_service_grid.ShowCellErrors = false;
            this.s_service_grid.ShowCellToolTips = false;
            this.s_service_grid.Size = new System.Drawing.Size(631, 353);
            this.s_service_grid.TabIndex = 25;
            this.s_service_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.s_service_grid_DataBindingComplete);
            // 
            // s_select_column
            // 
            this.s_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.s_select_column.DataPropertyName = "checkbox_column";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.s_select_column.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.s_sequence_column.Width = 70;
            // 
            // s_national_id_column
            // 
            this.s_national_id_column.DataPropertyName = "national_id";
            this.s_national_id_column.HeaderText = "شناسه ملی";
            this.s_national_id_column.Name = "s_national_id_column";
            this.s_national_id_column.Width = 94;
            // 
            // s_name_column
            // 
            this.s_name_column.DataPropertyName = "name";
            this.s_name_column.HeaderText = "نام";
            this.s_name_column.Name = "s_name_column";
            this.s_name_column.Width = 51;
            // 
            // s_category_name_column
            // 
            this.s_category_name_column.DataPropertyName = "category_name";
            this.s_category_name_column.HeaderText = "نوع خدمت";
            this.s_category_name_column.Name = "s_category_name_column";
            this.s_category_name_column.ReadOnly = true;
            this.s_category_name_column.Width = 95;
            // 
            // s_sub_category_name_column
            // 
            this.s_sub_category_name_column.DataPropertyName = "sub_category_name";
            this.s_sub_category_name_column.HeaderText = "نوع فرعی خدمت";
            this.s_sub_category_name_column.Name = "s_sub_category_name_column";
            this.s_sub_category_name_column.ReadOnly = true;
            this.s_sub_category_name_column.Width = 126;
            // 
            // s_insurance_name_column
            // 
            this.s_insurance_name_column.DataPropertyName = "insurance_name";
            this.s_insurance_name_column.HeaderText = "شرکت بیمه";
            this.s_insurance_name_column.Name = "s_insurance_name_column";
            // 
            // s_sector_name_column
            // 
            this.s_sector_name_column.DataPropertyName = "sector_name";
            this.s_sector_name_column.HeaderText = "صندوق بیمه";
            this.s_sector_name_column.Name = "s_sector_name_column";
            this.s_sector_name_column.Width = 101;
            // 
            // s_k_factor_column
            // 
            this.s_k_factor_column.DataPropertyName = "k_factor";
            this.s_k_factor_column.HeaderText = "ضریب K";
            this.s_k_factor_column.Name = "s_k_factor_column";
            this.s_k_factor_column.Width = 89;
            // 
            // s_professional_k_column
            // 
            this.s_professional_k_column.DataPropertyName = "professional_k";
            this.s_professional_k_column.HeaderText = "K حرفه ای";
            this.s_professional_k_column.Name = "s_professional_k_column";
            this.s_professional_k_column.Width = 98;
            // 
            // s_technical_k_column
            // 
            this.s_technical_k_column.DataPropertyName = "technical_k";
            this.s_technical_k_column.HeaderText = "K فنی";
            this.s_technical_k_column.Name = "s_technical_k_column";
            this.s_technical_k_column.Width = 72;
            // 
            // s_start_date_column
            // 
            this.s_start_date_column.DataPropertyName = "start_date";
            this.s_start_date_column.HeaderText = "تاریخ اضافه شدن خدمت";
            this.s_start_date_column.Name = "s_start_date_column";
            this.s_start_date_column.Width = 169;
            // 
            // s_description_column
            // 
            this.s_description_column.DataPropertyName = "description";
            this.s_description_column.HeaderText = "توضیحات";
            this.s_description_column.Name = "s_description_column";
            this.s_description_column.Width = 87;
            // 
            // s_category_column
            // 
            this.s_category_column.DataPropertyName = "category";
            this.s_category_column.HeaderText = "category";
            this.s_category_column.Name = "s_category_column";
            this.s_category_column.Visible = false;
            this.s_category_column.Width = 114;
            // 
            // sub_category
            // 
            this.sub_category.DataPropertyName = "sub_category";
            this.sub_category.HeaderText = "sub_category";
            this.sub_category.Name = "sub_category";
            this.sub_category.ReadOnly = true;
            this.sub_category.Visible = false;
            this.sub_category.Width = 157;
            // 
            // s_insurance_column
            // 
            this.s_insurance_column.DataPropertyName = "insurance";
            this.s_insurance_column.HeaderText = "insurance";
            this.s_insurance_column.Name = "s_insurance_column";
            this.s_insurance_column.ReadOnly = true;
            this.s_insurance_column.Visible = false;
            this.s_insurance_column.Width = 124;
            // 
            // s_insurance_sector_column
            // 
            this.s_insurance_sector_column.DataPropertyName = "insurance_sector";
            this.s_insurance_sector_column.HeaderText = "insurance_sector";
            this.s_insurance_sector_column.Name = "s_insurance_sector_column";
            this.s_insurance_sector_column.Visible = false;
            this.s_insurance_sector_column.Width = 190;
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
            // s_selected_textbox
            // 
            this.service_tableLayout.SetColumnSpan(this.s_selected_textbox, 4);
            this.s_selected_textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s_selected_textbox.Location = new System.Drawing.Point(61, 144);
            this.s_selected_textbox.Margin = new System.Windows.Forms.Padding(15, 2, 22, 2);
            this.s_selected_textbox.MaxLength = 10;
            this.s_selected_textbox.Name = "s_selected_textbox";
            this.s_selected_textbox.ReadOnly = true;
            this.s_selected_textbox.Size = new System.Drawing.Size(598, 34);
            this.s_selected_textbox.TabIndex = 24;
            // 
            // s_code_text
            // 
            this.s_code_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.s_code_text.Location = new System.Drawing.Point(427, 97);
            this.s_code_text.Margin = new System.Windows.Forms.Padding(2);
            this.s_code_text.MaxLength = 10;
            this.s_code_text.Name = "s_code_text";
            this.s_code_text.Size = new System.Drawing.Size(164, 34);
            this.s_code_text.TabIndex = 2;
            // 
            // s_name_text
            // 
            this.s_name_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.s_name_text.Location = new System.Drawing.Point(427, 17);
            this.s_name_text.Margin = new System.Windows.Forms.Padding(2);
            this.s_name_text.MaxLength = 500;
            this.s_name_text.Name = "s_name_text";
            this.s_name_text.Size = new System.Drawing.Size(164, 34);
            this.s_name_text.TabIndex = 0;
            // 
            // s_name_label
            // 
            this.s_name_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.s_name_label.AutoSize = true;
            this.s_name_label.BackColor = System.Drawing.Color.Transparent;
            this.s_name_label.ForeColor = System.Drawing.Color.Black;
            this.s_name_label.Location = new System.Drawing.Point(598, 15);
            this.s_name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.s_name_label.Name = "s_name_label";
            this.s_name_label.Size = new System.Drawing.Size(74, 40);
            this.s_name_label.TabIndex = 4;
            this.s_name_label.Text = "نام خدمت :";
            this.s_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // s_category_label
            // 
            this.s_category_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.s_category_label.AutoSize = true;
            this.s_category_label.BackColor = System.Drawing.Color.Transparent;
            this.s_category_label.ForeColor = System.Drawing.Color.Black;
            this.s_category_label.Location = new System.Drawing.Point(595, 55);
            this.s_category_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.s_category_label.Name = "s_category_label";
            this.s_category_label.Size = new System.Drawing.Size(77, 40);
            this.s_category_label.TabIndex = 4;
            this.s_category_label.Text = "نوع خدمت :";
            this.s_category_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // code_label
            // 
            this.code_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.code_label.AutoSize = true;
            this.code_label.BackColor = System.Drawing.Color.Transparent;
            this.code_label.ForeColor = System.Drawing.Color.Black;
            this.code_label.Location = new System.Drawing.Point(595, 95);
            this.code_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.code_label.Name = "code_label";
            this.code_label.Size = new System.Drawing.Size(77, 40);
            this.code_label.TabIndex = 23;
            this.code_label.Text = "کد خدمت :";
            this.code_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // s_category_combobox
            // 
            this.s_category_combobox.BackColor = System.Drawing.Color.White;
            this.s_category_combobox.DisplayMember = "id";
            this.s_category_combobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.s_category_combobox.DropDownHeight = 300;
            this.s_category_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.s_category_combobox.FormattingEnabled = true;
            this.s_category_combobox.IntegralHeight = false;
            this.s_category_combobox.Location = new System.Drawing.Point(427, 57);
            this.s_category_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.s_category_combobox.Name = "s_category_combobox";
            this.s_category_combobox.Size = new System.Drawing.Size(164, 35);
            this.s_category_combobox.TabIndex = 1;
            this.s_category_combobox.ValueMember = "id";
            // 
            // s_search_button
            // 
            this.s_search_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.s_search_button.AutoSize = true;
            this.s_search_button.Location = new System.Drawing.Point(325, 97);
            this.s_search_button.Margin = new System.Windows.Forms.Padding(2);
            this.s_search_button.Name = "s_search_button";
            this.s_search_button.Size = new System.Drawing.Size(98, 36);
            this.s_search_button.TabIndex = 3;
            this.s_search_button.Text = "جستجو";
            this.s_search_button.UseVisualStyleBackColor = true;
            this.s_search_button.Click += new System.EventHandler(this.s_search_button_Click);
            // 
            // info_tab
            // 
            this.info_tab.Controls.Add(this.info_tableLayout);
            this.info_tab.Location = new System.Drawing.Point(4, 36);
            this.info_tab.Margin = new System.Windows.Forms.Padding(2);
            this.info_tab.Name = "info_tab";
            this.info_tab.Padding = new System.Windows.Forms.Padding(2);
            this.info_tab.Size = new System.Drawing.Size(693, 470);
            this.info_tab.TabIndex = 0;
            this.info_tab.Text = "اطلاعات تعرفه";
            this.info_tab.UseVisualStyleBackColor = true;
            // 
            // info_tableLayout
            // 
            this.info_tableLayout.AutoScroll = true;
            this.info_tableLayout.ColumnCount = 3;
            this.info_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.info_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.info_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.info_tableLayout.Controls.Add(this.i_start_date_masked, 1, 6);
            this.info_tableLayout.Controls.Add(this.i_insurance_combobox, 1, 3);
            this.info_tableLayout.Controls.Add(this.i_sector_checkbox, 2, 4);
            this.info_tableLayout.Controls.Add(this.i_sector_label, 0, 4);
            this.info_tableLayout.Controls.Add(this.i_sector_combobox, 1, 4);
            this.info_tableLayout.Controls.Add(this.i_description_checkbox, 2, 8);
            this.info_tableLayout.Controls.Add(this.i_clear_label, 2, 0);
            this.info_tableLayout.Controls.Add(this.i_end_date_label, 0, 7);
            this.info_tableLayout.Controls.Add(this.i_degree_combobox, 1, 5);
            this.info_tableLayout.Controls.Add(this.i_alias_label, 0, 2);
            this.info_tableLayout.Controls.Add(this.i_insurance_label, 0, 3);
            this.info_tableLayout.Controls.Add(this.i_degree_label, 0, 5);
            this.info_tableLayout.Controls.Add(this.i_start_date_label, 0, 6);
            this.info_tableLayout.Controls.Add(this.i_alias_textbox, 1, 2);
            this.info_tableLayout.Controls.Add(this.i_sequence_textbox, 1, 1);
            this.info_tableLayout.Controls.Add(this.i_sequence_label, 0, 1);
            this.info_tableLayout.Controls.Add(this.i_description_label, 0, 8);
            this.info_tableLayout.Controls.Add(this.i_description_textbox, 1, 8);
            this.info_tableLayout.Controls.Add(this.i_sequence_checkbox, 2, 1);
            this.info_tableLayout.Controls.Add(this.i_alias_checkbox, 2, 2);
            this.info_tableLayout.Controls.Add(this.i_insurance_checkbox, 2, 3);
            this.info_tableLayout.Controls.Add(this.i_degree_checkbox, 2, 5);
            this.info_tableLayout.Controls.Add(this.i_start_date_checkbox, 2, 6);
            this.info_tableLayout.Controls.Add(this.i_end_date_checkbox, 2, 7);
            this.info_tableLayout.Controls.Add(this.i_end_date_masked, 1, 7);
            this.info_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.info_tableLayout.Location = new System.Drawing.Point(2, 2);
            this.info_tableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.info_tableLayout.Name = "info_tableLayout";
            this.info_tableLayout.RowCount = 9;
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.info_tableLayout.Size = new System.Drawing.Size(689, 466);
            this.info_tableLayout.TabIndex = 21;
            // 
            // i_start_date_masked
            // 
            this.i_start_date_masked.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_start_date_masked.Location = new System.Drawing.Point(365, 242);
            this.i_start_date_masked.Margin = new System.Windows.Forms.Padding(2);
            this.i_start_date_masked.Mask = "0000/00/00";
            this.i_start_date_masked.Name = "i_start_date_masked";
            this.i_start_date_masked.RejectInputOnFirstFailure = true;
            this.i_start_date_masked.ResetOnSpace = false;
            this.i_start_date_masked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.i_start_date_masked.Size = new System.Drawing.Size(201, 34);
            this.i_start_date_masked.TabIndex = 11;
            this.i_start_date_masked.Tag = "6";
            this.i_start_date_masked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.i_start_date_masked.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.i_start_date_masked.Leave += new System.EventHandler(this.i_date_masked_Leave);
            // 
            // i_insurance_combobox
            // 
            this.i_insurance_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_insurance_combobox.DisplayMember = "name";
            this.i_insurance_combobox.DropDownHeight = 300;
            this.i_insurance_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.i_insurance_combobox.Enabled = false;
            this.i_insurance_combobox.FormattingEnabled = true;
            this.i_insurance_combobox.IntegralHeight = false;
            this.i_insurance_combobox.Location = new System.Drawing.Point(366, 115);
            this.i_insurance_combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.i_insurance_combobox.Name = "i_insurance_combobox";
            this.i_insurance_combobox.Size = new System.Drawing.Size(199, 35);
            this.i_insurance_combobox.TabIndex = 8;
            this.i_insurance_combobox.Tag = "3";
            this.i_insurance_combobox.ValueMember = "id";
            this.i_insurance_combobox.SelectedIndexChanged += new System.EventHandler(this.i_insurance_combobox_SelectedIndexChanged);
            // 
            // i_sector_checkbox
            // 
            this.i_sector_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_sector_checkbox.AutoSize = true;
            this.i_sector_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_sector_checkbox.Enabled = false;
            this.i_sector_checkbox.Location = new System.Drawing.Point(2, 156);
            this.i_sector_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_sector_checkbox.Name = "i_sector_checkbox";
            this.i_sector_checkbox.Size = new System.Drawing.Size(359, 39);
            this.i_sector_checkbox.TabIndex = 17;
            this.i_sector_checkbox.Tag = "4";
            this.i_sector_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_sector_checkbox.UseVisualStyleBackColor = true;
            this.i_sector_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_sector_label
            // 
            this.i_sector_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_sector_label.AutoSize = true;
            this.i_sector_label.BackColor = System.Drawing.Color.Transparent;
            this.i_sector_label.ForeColor = System.Drawing.Color.Black;
            this.i_sector_label.Location = new System.Drawing.Point(572, 154);
            this.i_sector_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_sector_label.Name = "i_sector_label";
            this.i_sector_label.Size = new System.Drawing.Size(113, 43);
            this.i_sector_label.TabIndex = 42;
            this.i_sector_label.Tag = "4";
            this.i_sector_label.Text = "صندوق بیمه :";
            this.i_sector_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_sector_combobox
            // 
            this.i_sector_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_sector_combobox.DisplayMember = "name";
            this.i_sector_combobox.DropDownHeight = 300;
            this.i_sector_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.i_sector_combobox.Enabled = false;
            this.i_sector_combobox.FormattingEnabled = true;
            this.i_sector_combobox.IntegralHeight = false;
            this.i_sector_combobox.Location = new System.Drawing.Point(366, 158);
            this.i_sector_combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.i_sector_combobox.Name = "i_sector_combobox";
            this.i_sector_combobox.Size = new System.Drawing.Size(199, 35);
            this.i_sector_combobox.TabIndex = 9;
            this.i_sector_combobox.Tag = "4";
            this.i_sector_combobox.ValueMember = "id";
            this.i_sector_combobox.SelectedIndexChanged += new System.EventHandler(this.i_combobox_SelectedIndexChanged);
            // 
            // i_description_checkbox
            // 
            this.i_description_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_description_checkbox.AutoSize = true;
            this.i_description_checkbox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.i_description_checkbox.Enabled = false;
            this.i_description_checkbox.Location = new System.Drawing.Point(2, 327);
            this.i_description_checkbox.Margin = new System.Windows.Forms.Padding(2, 11, 2, 2);
            this.i_description_checkbox.Name = "i_description_checkbox";
            this.i_description_checkbox.Size = new System.Drawing.Size(359, 270);
            this.i_description_checkbox.TabIndex = 21;
            this.i_description_checkbox.Tag = "8";
            this.i_description_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_description_checkbox.UseVisualStyleBackColor = true;
            this.i_description_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_clear_label
            // 
            this.i_clear_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_clear_label.AutoSize = true;
            this.i_clear_label.Location = new System.Drawing.Point(4, 0);
            this.i_clear_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_clear_label.Name = "i_clear_label";
            this.i_clear_label.Size = new System.Drawing.Size(355, 27);
            this.i_clear_label.TabIndex = 40;
            this.i_clear_label.Text = "پاک شدن اطلاعات؟";
            this.i_clear_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_clear_label.Visible = false;
            // 
            // i_end_date_label
            // 
            this.i_end_date_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_end_date_label.AutoSize = true;
            this.i_end_date_label.BackColor = System.Drawing.Color.Transparent;
            this.i_end_date_label.ForeColor = System.Drawing.Color.Black;
            this.i_end_date_label.Location = new System.Drawing.Point(572, 278);
            this.i_end_date_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_end_date_label.Name = "i_end_date_label";
            this.i_end_date_label.Size = new System.Drawing.Size(113, 38);
            this.i_end_date_label.TabIndex = 39;
            this.i_end_date_label.Tag = "7";
            this.i_end_date_label.Text = "تاریخ پایان تعرفه :";
            this.i_end_date_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_degree_combobox
            // 
            this.i_degree_combobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_degree_combobox.DisplayMember = "name";
            this.i_degree_combobox.DropDownHeight = 300;
            this.i_degree_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.i_degree_combobox.Enabled = false;
            this.i_degree_combobox.FormattingEnabled = true;
            this.i_degree_combobox.IntegralHeight = false;
            this.i_degree_combobox.Location = new System.Drawing.Point(366, 201);
            this.i_degree_combobox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.i_degree_combobox.Name = "i_degree_combobox";
            this.i_degree_combobox.Size = new System.Drawing.Size(199, 35);
            this.i_degree_combobox.TabIndex = 10;
            this.i_degree_combobox.Tag = "5";
            this.i_degree_combobox.ValueMember = "id";
            this.i_degree_combobox.SelectedIndexChanged += new System.EventHandler(this.i_combobox_SelectedIndexChanged);
            // 
            // i_alias_label
            // 
            this.i_alias_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_alias_label.AutoSize = true;
            this.i_alias_label.BackColor = System.Drawing.Color.Transparent;
            this.i_alias_label.ForeColor = System.Drawing.Color.Black;
            this.i_alias_label.Location = new System.Drawing.Point(572, 69);
            this.i_alias_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_alias_label.Name = "i_alias_label";
            this.i_alias_label.Size = new System.Drawing.Size(113, 42);
            this.i_alias_label.TabIndex = 32;
            this.i_alias_label.Tag = "2";
            this.i_alias_label.Text = "نام مستعار :";
            this.i_alias_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_insurance_label
            // 
            this.i_insurance_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_insurance_label.AutoSize = true;
            this.i_insurance_label.BackColor = System.Drawing.Color.Transparent;
            this.i_insurance_label.ForeColor = System.Drawing.Color.Black;
            this.i_insurance_label.Location = new System.Drawing.Point(572, 111);
            this.i_insurance_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_insurance_label.Name = "i_insurance_label";
            this.i_insurance_label.Size = new System.Drawing.Size(113, 43);
            this.i_insurance_label.TabIndex = 31;
            this.i_insurance_label.Tag = "3";
            this.i_insurance_label.Text = "شرکت بیمه :";
            this.i_insurance_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_degree_label
            // 
            this.i_degree_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_degree_label.AutoSize = true;
            this.i_degree_label.BackColor = System.Drawing.Color.Transparent;
            this.i_degree_label.ForeColor = System.Drawing.Color.Black;
            this.i_degree_label.Location = new System.Drawing.Point(572, 197);
            this.i_degree_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_degree_label.Name = "i_degree_label";
            this.i_degree_label.Size = new System.Drawing.Size(113, 43);
            this.i_degree_label.TabIndex = 30;
            this.i_degree_label.Tag = "5";
            this.i_degree_label.Text = "درجه پزشکی :";
            this.i_degree_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_start_date_label
            // 
            this.i_start_date_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_start_date_label.AutoSize = true;
            this.i_start_date_label.BackColor = System.Drawing.Color.Transparent;
            this.i_start_date_label.ForeColor = System.Drawing.Color.Black;
            this.i_start_date_label.Location = new System.Drawing.Point(572, 240);
            this.i_start_date_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_start_date_label.Name = "i_start_date_label";
            this.i_start_date_label.Size = new System.Drawing.Size(113, 38);
            this.i_start_date_label.TabIndex = 28;
            this.i_start_date_label.Tag = "6";
            this.i_start_date_label.Text = "تاریخ شروع تعرفه :";
            this.i_start_date_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_alias_textbox
            // 
            this.i_alias_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_alias_textbox.Enabled = false;
            this.i_alias_textbox.Location = new System.Drawing.Point(367, 73);
            this.i_alias_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.i_alias_textbox.MaxLength = 500;
            this.i_alias_textbox.Name = "i_alias_textbox";
            this.i_alias_textbox.Size = new System.Drawing.Size(197, 34);
            this.i_alias_textbox.TabIndex = 7;
            this.i_alias_textbox.Tag = "2";
            this.i_alias_textbox.Leave += new System.EventHandler(this.i_textbox_control_Leave);
            // 
            // i_sequence_textbox
            // 
            this.i_sequence_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_sequence_textbox.Enabled = false;
            this.i_sequence_textbox.Location = new System.Drawing.Point(367, 31);
            this.i_sequence_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.i_sequence_textbox.MaxLength = 250;
            this.i_sequence_textbox.Name = "i_sequence_textbox";
            this.i_sequence_textbox.Size = new System.Drawing.Size(197, 34);
            this.i_sequence_textbox.TabIndex = 6;
            this.i_sequence_textbox.Tag = "1";
            // 
            // i_sequence_label
            // 
            this.i_sequence_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_sequence_label.AutoSize = true;
            this.i_sequence_label.Location = new System.Drawing.Point(572, 27);
            this.i_sequence_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.i_sequence_label.Name = "i_sequence_label";
            this.i_sequence_label.Size = new System.Drawing.Size(113, 42);
            this.i_sequence_label.TabIndex = 1;
            this.i_sequence_label.Tag = "1";
            this.i_sequence_label.Text = "شناسه :";
            this.i_sequence_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // i_description_label
            // 
            this.i_description_label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_description_label.AutoSize = true;
            this.i_description_label.BackColor = System.Drawing.Color.Transparent;
            this.i_description_label.ForeColor = System.Drawing.Color.Black;
            this.i_description_label.Location = new System.Drawing.Point(572, 323);
            this.i_description_label.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            this.i_description_label.Name = "i_description_label";
            this.i_description_label.Size = new System.Drawing.Size(113, 276);
            this.i_description_label.TabIndex = 22;
            this.i_description_label.Tag = "8";
            this.i_description_label.Text = "توضیحات :";
            this.i_description_label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // i_description_textbox
            // 
            this.i_description_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_description_textbox.Enabled = false;
            this.i_description_textbox.Location = new System.Drawing.Point(367, 320);
            this.i_description_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.i_description_textbox.MaxLength = 1000;
            this.i_description_textbox.Multiline = true;
            this.i_description_textbox.Name = "i_description_textbox";
            this.i_description_textbox.Size = new System.Drawing.Size(197, 275);
            this.i_description_textbox.TabIndex = 13;
            this.i_description_textbox.Tag = "8";
            this.i_description_textbox.Leave += new System.EventHandler(this.i_textbox_control_Leave);
            // 
            // i_sequence_checkbox
            // 
            this.i_sequence_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_sequence_checkbox.AutoSize = true;
            this.i_sequence_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_sequence_checkbox.Enabled = false;
            this.i_sequence_checkbox.Location = new System.Drawing.Point(2, 29);
            this.i_sequence_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_sequence_checkbox.Name = "i_sequence_checkbox";
            this.i_sequence_checkbox.Size = new System.Drawing.Size(359, 38);
            this.i_sequence_checkbox.TabIndex = 14;
            this.i_sequence_checkbox.Tag = "1";
            this.i_sequence_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_sequence_checkbox.UseVisualStyleBackColor = true;
            this.i_sequence_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_alias_checkbox
            // 
            this.i_alias_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_alias_checkbox.AutoSize = true;
            this.i_alias_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_alias_checkbox.Enabled = false;
            this.i_alias_checkbox.Location = new System.Drawing.Point(2, 71);
            this.i_alias_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_alias_checkbox.Name = "i_alias_checkbox";
            this.i_alias_checkbox.Size = new System.Drawing.Size(359, 38);
            this.i_alias_checkbox.TabIndex = 15;
            this.i_alias_checkbox.Tag = "2";
            this.i_alias_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_alias_checkbox.UseVisualStyleBackColor = true;
            this.i_alias_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_insurance_checkbox
            // 
            this.i_insurance_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_insurance_checkbox.AutoSize = true;
            this.i_insurance_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_insurance_checkbox.Enabled = false;
            this.i_insurance_checkbox.Location = new System.Drawing.Point(2, 113);
            this.i_insurance_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_insurance_checkbox.Name = "i_insurance_checkbox";
            this.i_insurance_checkbox.Size = new System.Drawing.Size(359, 39);
            this.i_insurance_checkbox.TabIndex = 16;
            this.i_insurance_checkbox.Tag = "3";
            this.i_insurance_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_insurance_checkbox.UseVisualStyleBackColor = true;
            this.i_insurance_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_degree_checkbox
            // 
            this.i_degree_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_degree_checkbox.AutoSize = true;
            this.i_degree_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_degree_checkbox.Enabled = false;
            this.i_degree_checkbox.Location = new System.Drawing.Point(2, 199);
            this.i_degree_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_degree_checkbox.Name = "i_degree_checkbox";
            this.i_degree_checkbox.Size = new System.Drawing.Size(359, 39);
            this.i_degree_checkbox.TabIndex = 18;
            this.i_degree_checkbox.Tag = "5";
            this.i_degree_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_degree_checkbox.UseVisualStyleBackColor = true;
            this.i_degree_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_start_date_checkbox
            // 
            this.i_start_date_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_start_date_checkbox.AutoSize = true;
            this.i_start_date_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_start_date_checkbox.Enabled = false;
            this.i_start_date_checkbox.Location = new System.Drawing.Point(2, 242);
            this.i_start_date_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_start_date_checkbox.Name = "i_start_date_checkbox";
            this.i_start_date_checkbox.Size = new System.Drawing.Size(359, 34);
            this.i_start_date_checkbox.TabIndex = 19;
            this.i_start_date_checkbox.Tag = "6";
            this.i_start_date_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_start_date_checkbox.UseVisualStyleBackColor = true;
            this.i_start_date_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_end_date_checkbox
            // 
            this.i_end_date_checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_end_date_checkbox.AutoSize = true;
            this.i_end_date_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_end_date_checkbox.Enabled = false;
            this.i_end_date_checkbox.Location = new System.Drawing.Point(2, 280);
            this.i_end_date_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.i_end_date_checkbox.Name = "i_end_date_checkbox";
            this.i_end_date_checkbox.Size = new System.Drawing.Size(359, 34);
            this.i_end_date_checkbox.TabIndex = 20;
            this.i_end_date_checkbox.Tag = "7";
            this.i_end_date_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.i_end_date_checkbox.UseVisualStyleBackColor = true;
            this.i_end_date_checkbox.CheckedChanged += new System.EventHandler(this.clear_checkboxes_CheckedChanged);
            // 
            // i_end_date_masked
            // 
            this.i_end_date_masked.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.i_end_date_masked.Location = new System.Drawing.Point(365, 280);
            this.i_end_date_masked.Margin = new System.Windows.Forms.Padding(2);
            this.i_end_date_masked.Mask = "0000/00/00";
            this.i_end_date_masked.Name = "i_end_date_masked";
            this.i_end_date_masked.RejectInputOnFirstFailure = true;
            this.i_end_date_masked.ResetOnSpace = false;
            this.i_end_date_masked.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.i_end_date_masked.Size = new System.Drawing.Size(201, 34);
            this.i_end_date_masked.TabIndex = 12;
            this.i_end_date_masked.Tag = "7";
            this.i_end_date_masked.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.i_end_date_masked.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.i_end_date_masked.Leave += new System.EventHandler(this.i_date_masked_Leave);
            // 
            // k_value_tab
            // 
            this.k_value_tab.Controls.Add(this.k_tableLayout);
            this.k_value_tab.Location = new System.Drawing.Point(4, 36);
            this.k_value_tab.Name = "k_value_tab";
            this.k_value_tab.Size = new System.Drawing.Size(693, 470);
            this.k_value_tab.TabIndex = 5;
            this.k_value_tab.Text = "مقدار K";
            this.k_value_tab.UseVisualStyleBackColor = true;
            // 
            // k_tableLayout
            // 
            this.k_tableLayout.AutoScroll = true;
            this.k_tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.k_tableLayout.ColumnCount = 5;
            this.k_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.k_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.k_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.k_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 412F));
            this.k_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.k_tableLayout.Controls.Add(this.k_search_button, 3, 1);
            this.k_tableLayout.Controls.Add(this.k_private_grid, 1, 8);
            this.k_tableLayout.Controls.Add(this.k_private_lbl, 1, 6);
            this.k_tableLayout.Controls.Add(this.k_public_grid, 1, 4);
            this.k_tableLayout.Controls.Add(this.k_public_lbl, 1, 3);
            this.k_tableLayout.Controls.Add(this.k_year_cbx, 2, 1);
            this.k_tableLayout.Controls.Add(this.k_year_lbl, 1, 1);
            this.k_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.k_tableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.k_tableLayout.Name = "k_tableLayout";
            this.k_tableLayout.RowCount = 9;
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.k_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.k_tableLayout.Size = new System.Drawing.Size(693, 470);
            this.k_tableLayout.TabIndex = 3;
            // 
            // k_search_button
            // 
            this.k_search_button.AutoSize = true;
            this.k_search_button.Location = new System.Drawing.Point(400, 23);
            this.k_search_button.Name = "k_search_button";
            this.k_search_button.Size = new System.Drawing.Size(70, 37);
            this.k_search_button.TabIndex = 100;
            this.k_search_button.Text = "جستجو";
            this.k_search_button.UseVisualStyleBackColor = true;
            this.k_search_button.Click += new System.EventHandler(this.k_search_button_Click);
            // 
            // k_private_grid
            // 
            this.k_private_grid.AllowUserToAddRows = false;
            this.k_private_grid.AllowUserToDeleteRows = false;
            this.k_private_grid.AutoGenerateColumns = false;
            this.k_private_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.k_private_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.k_private_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.k_pri_select_column,
            this.k_pri_id_column,
            this.k_pri_name_column,
            this.k_pri_prof_value_column,
            this.k_pri_tec_column,
            this.k_pri_year_column,
            this.k_pri_third_value_column,
            this.k_pri_ins_column,
            this.k_pri_sector_column,
            this.k_pri_start_date_column,
            this.k_pri_description_column});
            this.k_tableLayout.SetColumnSpan(this.k_private_grid, 3);
            this.k_private_grid.DataSource = this.kValueBindingSource;
            this.k_private_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_private_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.k_private_grid.Location = new System.Drawing.Point(63, 345);
            this.k_private_grid.Margin = new System.Windows.Forms.Padding(2);
            this.k_private_grid.MultiSelect = false;
            this.k_private_grid.Name = "k_private_grid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.k_private_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.k_private_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.k_private_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.k_private_grid.ShowCellErrors = false;
            this.k_private_grid.ShowCellToolTips = false;
            this.k_private_grid.Size = new System.Drawing.Size(608, 123);
            this.k_private_grid.TabIndex = 99;
            this.k_private_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.k_private_grid_DataBindingComplete);
            // 
            // k_pri_select_column
            // 
            this.k_pri_select_column.Frozen = true;
            this.k_pri_select_column.HeaderText = "";
            this.k_pri_select_column.MinimumWidth = 30;
            this.k_pri_select_column.Name = "k_pri_select_column";
            this.k_pri_select_column.Width = 30;
            // 
            // k_pri_id_column
            // 
            this.k_pri_id_column.DataPropertyName = "id";
            this.k_pri_id_column.HeaderText = "شناسه";
            this.k_pri_id_column.Name = "k_pri_id_column";
            this.k_pri_id_column.ReadOnly = true;
            this.k_pri_id_column.Width = 70;
            // 
            // k_pri_name_column
            // 
            this.k_pri_name_column.DataPropertyName = "name";
            this.k_pri_name_column.HeaderText = "نام";
            this.k_pri_name_column.Name = "k_pri_name_column";
            this.k_pri_name_column.Width = 51;
            // 
            // k_pri_prof_value_column
            // 
            this.k_pri_prof_value_column.DataPropertyName = "professional_value";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.k_pri_prof_value_column.DefaultCellStyle = dataGridViewCellStyle3;
            this.k_pri_prof_value_column.HeaderText = "مقدار حرفه ای(ریال)";
            this.k_pri_prof_value_column.Name = "k_pri_prof_value_column";
            this.k_pri_prof_value_column.Width = 147;
            // 
            // k_pri_tec_column
            // 
            this.k_pri_tec_column.DataPropertyName = "technical_value";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.k_pri_tec_column.DefaultCellStyle = dataGridViewCellStyle4;
            this.k_pri_tec_column.HeaderText = "مقدار فنی(ریال)";
            this.k_pri_tec_column.Name = "k_pri_tec_column";
            this.k_pri_tec_column.Width = 121;
            // 
            // k_pri_year_column
            // 
            this.k_pri_year_column.DataPropertyName = "year";
            this.k_pri_year_column.HeaderText = "سال تعرفه";
            this.k_pri_year_column.Name = "k_pri_year_column";
            this.k_pri_year_column.Width = 91;
            // 
            // k_pri_third_value_column
            // 
            this.k_pri_third_value_column.DataPropertyName = "third_value";
            this.k_pri_third_value_column.HeaderText = "مقدار سوم";
            this.k_pri_third_value_column.Name = "k_pri_third_value_column";
            this.k_pri_third_value_column.Width = 92;
            // 
            // k_pri_ins_column
            // 
            this.k_pri_ins_column.DataPropertyName = "insurance";
            this.k_pri_ins_column.HeaderText = "سازمان بیمه گر";
            this.k_pri_ins_column.Name = "k_pri_ins_column";
            this.k_pri_ins_column.Width = 119;
            // 
            // k_pri_sector_column
            // 
            this.k_pri_sector_column.DataPropertyName = "insurance_sector";
            this.k_pri_sector_column.HeaderText = "صندوق بیمه ای";
            this.k_pri_sector_column.Name = "k_pri_sector_column";
            this.k_pri_sector_column.Width = 119;
            // 
            // k_pri_start_date_column
            // 
            this.k_pri_start_date_column.DataPropertyName = "start_date";
            this.k_pri_start_date_column.HeaderText = "تاریخ اجرا";
            this.k_pri_start_date_column.Name = "k_pri_start_date_column";
            this.k_pri_start_date_column.Width = 90;
            // 
            // k_pri_description_column
            // 
            this.k_pri_description_column.DataPropertyName = "description";
            this.k_pri_description_column.HeaderText = "توضیحات";
            this.k_pri_description_column.Name = "k_pri_description_column";
            this.k_pri_description_column.Width = 87;
            // 
            // kValueBindingSource
            // 
            this.kValueBindingSource.DataMember = "KValue";
            this.kValueBindingSource.DataSource = this.pIPDataSet;
            // 
            // k_private_lbl
            // 
            this.k_private_lbl.AutoSize = true;
            this.k_private_lbl.BackColor = System.Drawing.Color.Blue;
            this.k_tableLayout.SetColumnSpan(this.k_private_lbl, 3);
            this.k_private_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_private_lbl.ForeColor = System.Drawing.Color.White;
            this.k_private_lbl.Location = new System.Drawing.Point(63, 303);
            this.k_private_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.k_private_lbl.Name = "k_private_lbl";
            this.k_private_lbl.Size = new System.Drawing.Size(608, 40);
            this.k_private_lbl.TabIndex = 98;
            this.k_private_lbl.Text = "مقدار K برای تعرفه های بخش خصوصی";
            this.k_private_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // k_public_grid
            // 
            this.k_public_grid.AllowUserToAddRows = false;
            this.k_public_grid.AllowUserToDeleteRows = false;
            this.k_public_grid.AutoGenerateColumns = false;
            this.k_public_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.k_public_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.k_public_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.k_pub_select_column,
            this.k_pu_id_column,
            this.k_pu_name_column,
            this.k_pu_professional_value_column,
            this.k_pu_technical_value_column,
            this.k_pu_year_column,
            this.k_pu_third_value_column,
            this.k_pu_insurance_column,
            this.k_pu_insurance_sector_column,
            this.k_pu_start_date_column,
            this.k_pu_description_column});
            this.k_tableLayout.SetColumnSpan(this.k_public_grid, 3);
            this.k_public_grid.DataSource = this.kValueBindingSource;
            this.k_public_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_public_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.k_public_grid.Location = new System.Drawing.Point(63, 125);
            this.k_public_grid.Margin = new System.Windows.Forms.Padding(2);
            this.k_public_grid.MultiSelect = false;
            this.k_public_grid.Name = "k_public_grid";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.k_public_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.k_public_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.k_public_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.k_public_grid.ShowCellErrors = false;
            this.k_public_grid.ShowCellToolTips = false;
            this.k_public_grid.Size = new System.Drawing.Size(608, 156);
            this.k_public_grid.TabIndex = 97;
            this.k_public_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.k_public_grid_DataBindingComplete);
            // 
            // k_pub_select_column
            // 
            this.k_pub_select_column.Frozen = true;
            this.k_pub_select_column.HeaderText = "";
            this.k_pub_select_column.MinimumWidth = 30;
            this.k_pub_select_column.Name = "k_pub_select_column";
            this.k_pub_select_column.Width = 30;
            // 
            // k_pu_id_column
            // 
            this.k_pu_id_column.DataPropertyName = "id";
            this.k_pu_id_column.HeaderText = "شناسه";
            this.k_pu_id_column.Name = "k_pu_id_column";
            this.k_pu_id_column.ReadOnly = true;
            this.k_pu_id_column.Width = 70;
            // 
            // k_pu_name_column
            // 
            this.k_pu_name_column.DataPropertyName = "name";
            this.k_pu_name_column.HeaderText = "نام";
            this.k_pu_name_column.Name = "k_pu_name_column";
            this.k_pu_name_column.Width = 51;
            // 
            // k_pu_professional_value_column
            // 
            this.k_pu_professional_value_column.DataPropertyName = "professional_value";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.k_pu_professional_value_column.DefaultCellStyle = dataGridViewCellStyle6;
            this.k_pu_professional_value_column.HeaderText = "مقدار حرفه ای(ریال)";
            this.k_pu_professional_value_column.Name = "k_pu_professional_value_column";
            this.k_pu_professional_value_column.Width = 147;
            // 
            // k_pu_technical_value_column
            // 
            this.k_pu_technical_value_column.DataPropertyName = "technical_value";
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.k_pu_technical_value_column.DefaultCellStyle = dataGridViewCellStyle7;
            this.k_pu_technical_value_column.HeaderText = "مقدار فنی(ریال)";
            this.k_pu_technical_value_column.Name = "k_pu_technical_value_column";
            this.k_pu_technical_value_column.Width = 121;
            // 
            // k_pu_year_column
            // 
            this.k_pu_year_column.DataPropertyName = "year";
            this.k_pu_year_column.HeaderText = "سال تعرفه";
            this.k_pu_year_column.Name = "k_pu_year_column";
            this.k_pu_year_column.Width = 91;
            // 
            // k_pu_third_value_column
            // 
            this.k_pu_third_value_column.DataPropertyName = "third_value";
            this.k_pu_third_value_column.HeaderText = "مقدار سوم";
            this.k_pu_third_value_column.Name = "k_pu_third_value_column";
            this.k_pu_third_value_column.Width = 92;
            // 
            // k_pu_insurance_column
            // 
            this.k_pu_insurance_column.DataPropertyName = "insurance";
            this.k_pu_insurance_column.HeaderText = "سازمان بیمه گر";
            this.k_pu_insurance_column.Name = "k_pu_insurance_column";
            this.k_pu_insurance_column.Width = 119;
            // 
            // k_pu_insurance_sector_column
            // 
            this.k_pu_insurance_sector_column.DataPropertyName = "insurance_sector";
            this.k_pu_insurance_sector_column.HeaderText = "صندوق بیمه ای";
            this.k_pu_insurance_sector_column.Name = "k_pu_insurance_sector_column";
            this.k_pu_insurance_sector_column.Width = 119;
            // 
            // k_pu_start_date_column
            // 
            this.k_pu_start_date_column.DataPropertyName = "start_date";
            this.k_pu_start_date_column.HeaderText = "تاریخ اجرا";
            this.k_pu_start_date_column.Name = "k_pu_start_date_column";
            this.k_pu_start_date_column.Width = 90;
            // 
            // k_pu_description_column
            // 
            this.k_pu_description_column.DataPropertyName = "description";
            this.k_pu_description_column.HeaderText = "توضیحات";
            this.k_pu_description_column.Name = "k_pu_description_column";
            this.k_pu_description_column.Width = 87;
            // 
            // k_public_lbl
            // 
            this.k_public_lbl.AutoSize = true;
            this.k_public_lbl.BackColor = System.Drawing.Color.Blue;
            this.k_tableLayout.SetColumnSpan(this.k_public_lbl, 3);
            this.k_public_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_public_lbl.ForeColor = System.Drawing.Color.White;
            this.k_public_lbl.Location = new System.Drawing.Point(63, 83);
            this.k_public_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.k_public_lbl.Name = "k_public_lbl";
            this.k_public_lbl.Size = new System.Drawing.Size(608, 40);
            this.k_public_lbl.TabIndex = 96;
            this.k_public_lbl.Text = "مقدار K برای تعرفه های دولتی";
            this.k_public_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // k_year_cbx
            // 
            this.k_year_cbx.DisplayMember = "name";
            this.k_year_cbx.DropDownHeight = 300;
            this.k_year_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.k_year_cbx.FormattingEnabled = true;
            this.k_year_cbx.IntegralHeight = false;
            this.k_year_cbx.Location = new System.Drawing.Point(476, 24);
            this.k_year_cbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.k_year_cbx.Name = "k_year_cbx";
            this.k_year_cbx.Size = new System.Drawing.Size(94, 35);
            this.k_year_cbx.TabIndex = 80;
            this.k_year_cbx.Tag = "3";
            this.k_year_cbx.ValueMember = "id";
            // 
            // k_year_lbl
            // 
            this.k_year_lbl.AutoSize = true;
            this.k_year_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.k_year_lbl.Location = new System.Drawing.Point(577, 20);
            this.k_year_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.k_year_lbl.Name = "k_year_lbl";
            this.k_year_lbl.Size = new System.Drawing.Size(92, 43);
            this.k_year_lbl.TabIndex = 79;
            this.k_year_lbl.Tag = "9";
            this.k_year_lbl.Text = "سال تعرفه :";
            this.k_year_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tariff_tab
            // 
            this.tariff_tab.AutoScroll = true;
            this.tariff_tab.Controls.Add(this.tariff_tableLayout);
            this.tariff_tab.Location = new System.Drawing.Point(4, 36);
            this.tariff_tab.Margin = new System.Windows.Forms.Padding(2);
            this.tariff_tab.Name = "tariff_tab";
            this.tariff_tab.Padding = new System.Windows.Forms.Padding(2);
            this.tariff_tab.Size = new System.Drawing.Size(693, 470);
            this.tariff_tab.TabIndex = 4;
            this.tariff_tab.Text = "هزینه های خدمت";
            this.tariff_tab.UseVisualStyleBackColor = true;
            // 
            // tariff_tableLayout
            // 
            this.tariff_tableLayout.AutoScroll = true;
            this.tariff_tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tariff_tableLayout.ColumnCount = 3;
            this.tariff_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tariff_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tariff_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tariff_tableLayout.Controls.Add(this.private_discount_label, 0, 10);
            this.tariff_tableLayout.Controls.Add(this.private_discount_checkbox, 2, 10);
            this.tariff_tableLayout.Controls.Add(this.public_discount_checkbox, 2, 3);
            this.tariff_tableLayout.Controls.Add(this.public_discount_textbox, 1, 3);
            this.tariff_tableLayout.Controls.Add(this.public_discount_label, 0, 3);
            this.tariff_tableLayout.Controls.Add(this.private_pat_sha_label, 0, 9);
            this.tariff_tableLayout.Controls.Add(this.private_ins_sha_label, 0, 11);
            this.tariff_tableLayout.Controls.Add(this.private_k_label, 0, 14);
            this.tariff_tableLayout.Controls.Add(this.private_ins_per_label, 0, 13);
            this.tariff_tableLayout.Controls.Add(this.private_pat_per_label, 0, 12);
            this.tariff_tableLayout.Controls.Add(this.private_ins_sha_checkbox, 2, 11);
            this.tariff_tableLayout.Controls.Add(this.private_pat_per_checkbox, 2, 12);
            this.tariff_tableLayout.Controls.Add(this.private_k_checkbox, 2, 14);
            this.tariff_tableLayout.Controls.Add(this.private_pat_sha_checkbox, 2, 9);
            this.tariff_tableLayout.Controls.Add(this.private_ins_per_checkbox, 2, 13);
            this.tariff_tableLayout.Controls.Add(this.private_k_textbox, 1, 14);
            this.tariff_tableLayout.Controls.Add(this.private_ins_sha_textbox, 1, 11);
            this.tariff_tableLayout.Controls.Add(this.private_ins_per_textbox, 1, 13);
            this.tariff_tableLayout.Controls.Add(this.private_pat_per_textbox, 1, 12);
            this.tariff_tableLayout.Controls.Add(this.private_pat_sha_textbox, 1, 9);
            this.tariff_tableLayout.Controls.Add(this.private_total_textbox, 1, 8);
            this.tariff_tableLayout.Controls.Add(this.public_k_textbox, 1, 7);
            this.tariff_tableLayout.Controls.Add(this.public_ins_per_textbox, 1, 6);
            this.tariff_tableLayout.Controls.Add(this.public_pat_per_textbox, 1, 5);
            this.tariff_tableLayout.Controls.Add(this.public_ins_per_checkbox, 2, 6);
            this.tariff_tableLayout.Controls.Add(this.public_ins_per_label, 0, 6);
            this.tariff_tableLayout.Controls.Add(this.private_total_label, 0, 8);
            this.tariff_tableLayout.Controls.Add(this.public_ins_sha_label, 0, 4);
            this.tariff_tableLayout.Controls.Add(this.public_pat_per_label, 0, 5);
            this.tariff_tableLayout.Controls.Add(this.public_k_label, 0, 7);
            this.tariff_tableLayout.Controls.Add(this.public_ins_sha_textbox, 1, 4);
            this.tariff_tableLayout.Controls.Add(this.public_total_textbox, 1, 1);
            this.tariff_tableLayout.Controls.Add(this.public_total_label, 0, 1);
            this.tariff_tableLayout.Controls.Add(this.public_pat_sha_label, 0, 2);
            this.tariff_tableLayout.Controls.Add(this.public_pat_sha_textbox, 1, 2);
            this.tariff_tableLayout.Controls.Add(this.public_total_checkbox, 2, 1);
            this.tariff_tableLayout.Controls.Add(this.public_pat_sha_checkbox, 2, 2);
            this.tariff_tableLayout.Controls.Add(this.public_ins_sha_checkbox, 2, 4);
            this.tariff_tableLayout.Controls.Add(this.public_pat_per_checkbox, 2, 5);
            this.tariff_tableLayout.Controls.Add(this.public_k_checkbox, 2, 7);
            this.tariff_tableLayout.Controls.Add(this.private_total_checkbox, 2, 8);
            this.tariff_tableLayout.Controls.Add(this.private_discount_textbox, 1, 10);
            this.tariff_tableLayout.Controls.Add(this.t_clear_label, 2, 0);
            this.tariff_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tariff_tableLayout.Location = new System.Drawing.Point(2, 2);
            this.tariff_tableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.tariff_tableLayout.Name = "tariff_tableLayout";
            this.tariff_tableLayout.RowCount = 16;
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tariff_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tariff_tableLayout.Size = new System.Drawing.Size(689, 466);
            this.tariff_tableLayout.TabIndex = 2;
            // 
            // private_discount_label
            // 
            this.private_discount_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_discount_label.AutoSize = true;
            this.private_discount_label.BackColor = System.Drawing.Color.Transparent;
            this.private_discount_label.ForeColor = System.Drawing.Color.Black;
            this.private_discount_label.Location = new System.Drawing.Point(502, 398);
            this.private_discount_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_discount_label.Name = "private_discount_label";
            this.private_discount_label.Size = new System.Drawing.Size(183, 42);
            this.private_discount_label.TabIndex = 78;
            this.private_discount_label.Tag = "18";
            this.private_discount_label.Text = "تخفیف به بیمار خصوصی (ریال) :";
            this.private_discount_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_discount_checkbox
            // 
            this.private_discount_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_discount_checkbox.AutoSize = true;
            this.private_discount_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_discount_checkbox.Enabled = false;
            this.private_discount_checkbox.Location = new System.Drawing.Point(166, 412);
            this.private_discount_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_discount_checkbox.Name = "private_discount_checkbox";
            this.private_discount_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_discount_checkbox.TabIndex = 51;
            this.private_discount_checkbox.Tag = "18";
            this.private_discount_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_discount_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_discount_checkbox
            // 
            this.public_discount_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_discount_checkbox.AutoSize = true;
            this.public_discount_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_discount_checkbox.Enabled = false;
            this.public_discount_checkbox.Location = new System.Drawing.Point(166, 118);
            this.public_discount_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_discount_checkbox.Name = "public_discount_checkbox";
            this.public_discount_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_discount_checkbox.TabIndex = 42;
            this.public_discount_checkbox.Tag = "11";
            this.public_discount_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_discount_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_discount_textbox
            // 
            this.public_discount_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_discount_textbox.Enabled = false;
            this.public_discount_textbox.Location = new System.Drawing.Point(354, 108);
            this.public_discount_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_discount_textbox.MaxLength = 11;
            this.public_discount_textbox.Name = "public_discount_textbox";
            this.public_discount_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_discount_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_discount_textbox.TabIndex = 24;
            this.public_discount_textbox.Tag = "11";
            this.public_discount_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_discount_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_discount_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.public_discount_textbox.Leave += new System.EventHandler(this.public_discount_textbox_Leave);
            // 
            // public_discount_label
            // 
            this.public_discount_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_discount_label.AutoSize = true;
            this.public_discount_label.BackColor = System.Drawing.Color.Transparent;
            this.public_discount_label.ForeColor = System.Drawing.Color.Black;
            this.public_discount_label.Location = new System.Drawing.Point(502, 104);
            this.public_discount_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_discount_label.Name = "public_discount_label";
            this.public_discount_label.Size = new System.Drawing.Size(168, 42);
            this.public_discount_label.TabIndex = 72;
            this.public_discount_label.Tag = "11";
            this.public_discount_label.Text = "تخفیف به بیمار دولتی (ریال) :";
            this.public_discount_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_pat_sha_label
            // 
            this.private_pat_sha_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_pat_sha_label.AutoSize = true;
            this.private_pat_sha_label.BackColor = System.Drawing.Color.Transparent;
            this.private_pat_sha_label.ForeColor = System.Drawing.Color.Black;
            this.private_pat_sha_label.Location = new System.Drawing.Point(502, 356);
            this.private_pat_sha_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_pat_sha_label.Name = "private_pat_sha_label";
            this.private_pat_sha_label.Size = new System.Drawing.Size(157, 42);
            this.private_pat_sha_label.TabIndex = 70;
            this.private_pat_sha_label.Tag = "17";
            this.private_pat_sha_label.Text = "سهم بیمار خصوصی (ریال) :";
            this.private_pat_sha_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_ins_sha_label
            // 
            this.private_ins_sha_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_ins_sha_label.AutoSize = true;
            this.private_ins_sha_label.BackColor = System.Drawing.Color.Transparent;
            this.private_ins_sha_label.ForeColor = System.Drawing.Color.Black;
            this.private_ins_sha_label.Location = new System.Drawing.Point(502, 440);
            this.private_ins_sha_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_ins_sha_label.Name = "private_ins_sha_label";
            this.private_ins_sha_label.Size = new System.Drawing.Size(171, 42);
            this.private_ins_sha_label.TabIndex = 68;
            this.private_ins_sha_label.Tag = "19";
            this.private_ins_sha_label.Text = "سهم سازمان خصوصی (ریال) :";
            this.private_ins_sha_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_k_label
            // 
            this.private_k_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_k_label.AutoSize = true;
            this.private_k_label.BackColor = System.Drawing.Color.Transparent;
            this.private_k_label.ForeColor = System.Drawing.Color.Black;
            this.private_k_label.Location = new System.Drawing.Point(502, 566);
            this.private_k_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_k_label.Name = "private_k_label";
            this.private_k_label.Size = new System.Drawing.Size(120, 42);
            this.private_k_label.TabIndex = 67;
            this.private_k_label.Tag = "22";
            this.private_k_label.Text = "ضریب K خصوصی :";
            this.private_k_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_ins_per_label
            // 
            this.private_ins_per_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_ins_per_label.AutoSize = true;
            this.private_ins_per_label.BackColor = System.Drawing.Color.Transparent;
            this.private_ins_per_label.ForeColor = System.Drawing.Color.Black;
            this.private_ins_per_label.Location = new System.Drawing.Point(502, 524);
            this.private_ins_per_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_ins_per_label.Name = "private_ins_per_label";
            this.private_ins_per_label.Size = new System.Drawing.Size(174, 42);
            this.private_ins_per_label.TabIndex = 66;
            this.private_ins_per_label.Tag = "21";
            this.private_ins_per_label.Text = "درصد خصوصی سهم سازمان  :";
            this.private_ins_per_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_pat_per_label
            // 
            this.private_pat_per_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_pat_per_label.AutoSize = true;
            this.private_pat_per_label.BackColor = System.Drawing.Color.Transparent;
            this.private_pat_per_label.ForeColor = System.Drawing.Color.Black;
            this.private_pat_per_label.Location = new System.Drawing.Point(502, 482);
            this.private_pat_per_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_pat_per_label.Name = "private_pat_per_label";
            this.private_pat_per_label.Size = new System.Drawing.Size(160, 42);
            this.private_pat_per_label.TabIndex = 65;
            this.private_pat_per_label.Tag = "20";
            this.private_pat_per_label.Text = "درصد خصوصی سهم بیمار  :";
            this.private_pat_per_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_ins_sha_checkbox
            // 
            this.private_ins_sha_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_ins_sha_checkbox.AutoSize = true;
            this.private_ins_sha_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_ins_sha_checkbox.Enabled = false;
            this.private_ins_sha_checkbox.Location = new System.Drawing.Point(166, 454);
            this.private_ins_sha_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_ins_sha_checkbox.Name = "private_ins_sha_checkbox";
            this.private_ins_sha_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_ins_sha_checkbox.TabIndex = 52;
            this.private_ins_sha_checkbox.Tag = "19";
            this.private_ins_sha_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_ins_sha_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_pat_per_checkbox
            // 
            this.private_pat_per_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_pat_per_checkbox.AutoSize = true;
            this.private_pat_per_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_pat_per_checkbox.Enabled = false;
            this.private_pat_per_checkbox.Location = new System.Drawing.Point(166, 496);
            this.private_pat_per_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_pat_per_checkbox.Name = "private_pat_per_checkbox";
            this.private_pat_per_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_pat_per_checkbox.TabIndex = 53;
            this.private_pat_per_checkbox.Tag = "20";
            this.private_pat_per_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_pat_per_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_k_checkbox
            // 
            this.private_k_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_k_checkbox.AutoSize = true;
            this.private_k_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_k_checkbox.Enabled = false;
            this.private_k_checkbox.Location = new System.Drawing.Point(166, 580);
            this.private_k_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_k_checkbox.Name = "private_k_checkbox";
            this.private_k_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_k_checkbox.TabIndex = 55;
            this.private_k_checkbox.Tag = "22";
            this.private_k_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_k_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_pat_sha_checkbox
            // 
            this.private_pat_sha_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_pat_sha_checkbox.AutoSize = true;
            this.private_pat_sha_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_pat_sha_checkbox.Enabled = false;
            this.private_pat_sha_checkbox.Location = new System.Drawing.Point(166, 370);
            this.private_pat_sha_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_pat_sha_checkbox.Name = "private_pat_sha_checkbox";
            this.private_pat_sha_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_pat_sha_checkbox.TabIndex = 50;
            this.private_pat_sha_checkbox.Tag = "17";
            this.private_pat_sha_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_pat_sha_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_ins_per_checkbox
            // 
            this.private_ins_per_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_ins_per_checkbox.AutoSize = true;
            this.private_ins_per_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_ins_per_checkbox.Enabled = false;
            this.private_ins_per_checkbox.Location = new System.Drawing.Point(166, 538);
            this.private_ins_per_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_ins_per_checkbox.Name = "private_ins_per_checkbox";
            this.private_ins_per_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_ins_per_checkbox.TabIndex = 54;
            this.private_ins_per_checkbox.Tag = "21";
            this.private_ins_per_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_ins_per_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_k_textbox
            // 
            this.private_k_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_k_textbox.Enabled = false;
            this.private_k_textbox.Location = new System.Drawing.Point(354, 570);
            this.private_k_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_k_textbox.MaxLength = 9;
            this.private_k_textbox.Name = "private_k_textbox";
            this.private_k_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_k_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_k_textbox.TabIndex = 37;
            this.private_k_textbox.Tag = "22";
            this.private_k_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_k_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_k_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_float_textbox_KeyPress);
            this.private_k_textbox.Leave += new System.EventHandler(this.private_k_textbox_Leave);
            // 
            // private_ins_sha_textbox
            // 
            this.private_ins_sha_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_ins_sha_textbox.Enabled = false;
            this.private_ins_sha_textbox.Location = new System.Drawing.Point(354, 444);
            this.private_ins_sha_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_ins_sha_textbox.MaxLength = 11;
            this.private_ins_sha_textbox.Name = "private_ins_sha_textbox";
            this.private_ins_sha_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_ins_sha_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_ins_sha_textbox.TabIndex = 34;
            this.private_ins_sha_textbox.Tag = "19";
            this.private_ins_sha_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_ins_sha_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_ins_sha_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.private_ins_sha_textbox.Leave += new System.EventHandler(this.private_ins_sha_textbox_Leave);
            // 
            // private_ins_per_textbox
            // 
            this.private_ins_per_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_ins_per_textbox.Enabled = false;
            this.private_ins_per_textbox.Location = new System.Drawing.Point(354, 528);
            this.private_ins_per_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_ins_per_textbox.MaxLength = 6;
            this.private_ins_per_textbox.Name = "private_ins_per_textbox";
            this.private_ins_per_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_ins_per_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_ins_per_textbox.TabIndex = 36;
            this.private_ins_per_textbox.Tag = "21";
            this.private_ins_per_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_ins_per_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_ins_per_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_float_textbox_KeyPress);
            this.private_ins_per_textbox.Leave += new System.EventHandler(this.private_ins_per_textbox_Leave);
            // 
            // private_pat_per_textbox
            // 
            this.private_pat_per_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_pat_per_textbox.Enabled = false;
            this.private_pat_per_textbox.Location = new System.Drawing.Point(354, 486);
            this.private_pat_per_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_pat_per_textbox.MaxLength = 6;
            this.private_pat_per_textbox.Name = "private_pat_per_textbox";
            this.private_pat_per_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_pat_per_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_pat_per_textbox.TabIndex = 35;
            this.private_pat_per_textbox.Tag = "20";
            this.private_pat_per_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_pat_per_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_pat_per_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_float_textbox_KeyPress);
            this.private_pat_per_textbox.Leave += new System.EventHandler(this.private_pat_per_textbox_Leave);
            // 
            // private_pat_sha_textbox
            // 
            this.private_pat_sha_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_pat_sha_textbox.Enabled = false;
            this.private_pat_sha_textbox.Location = new System.Drawing.Point(354, 360);
            this.private_pat_sha_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_pat_sha_textbox.MaxLength = 11;
            this.private_pat_sha_textbox.Name = "private_pat_sha_textbox";
            this.private_pat_sha_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_pat_sha_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_pat_sha_textbox.TabIndex = 32;
            this.private_pat_sha_textbox.Tag = "17";
            this.private_pat_sha_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_pat_sha_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_pat_sha_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.private_pat_sha_textbox.Leave += new System.EventHandler(this.private_pat_sha_textbox_Leave);
            // 
            // private_total_textbox
            // 
            this.private_total_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_total_textbox.Enabled = false;
            this.private_total_textbox.Location = new System.Drawing.Point(354, 318);
            this.private_total_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_total_textbox.MaxLength = 11;
            this.private_total_textbox.Name = "private_total_textbox";
            this.private_total_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_total_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_total_textbox.TabIndex = 31;
            this.private_total_textbox.Tag = "16";
            this.private_total_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_total_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_total_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.private_total_textbox.Leave += new System.EventHandler(this.private_total_textbox_Leave);
            // 
            // public_k_textbox
            // 
            this.public_k_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_k_textbox.Enabled = false;
            this.public_k_textbox.Location = new System.Drawing.Point(354, 276);
            this.public_k_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_k_textbox.MaxLength = 9;
            this.public_k_textbox.Name = "public_k_textbox";
            this.public_k_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_k_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_k_textbox.TabIndex = 28;
            this.public_k_textbox.Tag = "15";
            this.public_k_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_k_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_k_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_float_textbox_KeyPress);
            this.public_k_textbox.Leave += new System.EventHandler(this.public_k_textbox_Leave);
            // 
            // public_ins_per_textbox
            // 
            this.public_ins_per_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_ins_per_textbox.Enabled = false;
            this.public_ins_per_textbox.Location = new System.Drawing.Point(354, 234);
            this.public_ins_per_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_ins_per_textbox.MaxLength = 6;
            this.public_ins_per_textbox.Name = "public_ins_per_textbox";
            this.public_ins_per_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_ins_per_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_ins_per_textbox.TabIndex = 27;
            this.public_ins_per_textbox.Tag = "14";
            this.public_ins_per_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_ins_per_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_ins_per_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_float_textbox_KeyPress);
            this.public_ins_per_textbox.Leave += new System.EventHandler(this.public_ins_per_textbox_Leave);
            // 
            // public_pat_per_textbox
            // 
            this.public_pat_per_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_pat_per_textbox.Enabled = false;
            this.public_pat_per_textbox.Location = new System.Drawing.Point(354, 192);
            this.public_pat_per_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_pat_per_textbox.MaxLength = 6;
            this.public_pat_per_textbox.Name = "public_pat_per_textbox";
            this.public_pat_per_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_pat_per_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_pat_per_textbox.TabIndex = 26;
            this.public_pat_per_textbox.Tag = "13";
            this.public_pat_per_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_pat_per_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_pat_per_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_float_textbox_KeyPress);
            this.public_pat_per_textbox.Leave += new System.EventHandler(this.public_pat_per_textbox_Leave);
            // 
            // public_ins_per_checkbox
            // 
            this.public_ins_per_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_ins_per_checkbox.AutoSize = true;
            this.public_ins_per_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_ins_per_checkbox.Enabled = false;
            this.public_ins_per_checkbox.Location = new System.Drawing.Point(166, 244);
            this.public_ins_per_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_ins_per_checkbox.Name = "public_ins_per_checkbox";
            this.public_ins_per_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_ins_per_checkbox.TabIndex = 45;
            this.public_ins_per_checkbox.Tag = "14";
            this.public_ins_per_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_ins_per_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_ins_per_label
            // 
            this.public_ins_per_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_ins_per_label.AutoSize = true;
            this.public_ins_per_label.BackColor = System.Drawing.Color.Transparent;
            this.public_ins_per_label.ForeColor = System.Drawing.Color.Black;
            this.public_ins_per_label.Location = new System.Drawing.Point(502, 230);
            this.public_ins_per_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_ins_per_label.Name = "public_ins_per_label";
            this.public_ins_per_label.Size = new System.Drawing.Size(155, 42);
            this.public_ins_per_label.TabIndex = 42;
            this.public_ins_per_label.Tag = "14";
            this.public_ins_per_label.Text = "درصد دولتی سهم سازمان :";
            this.public_ins_per_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // private_total_label
            // 
            this.private_total_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.private_total_label.AutoSize = true;
            this.private_total_label.BackColor = System.Drawing.Color.Transparent;
            this.private_total_label.ForeColor = System.Drawing.Color.Black;
            this.private_total_label.Location = new System.Drawing.Point(502, 314);
            this.private_total_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.private_total_label.Name = "private_total_label";
            this.private_total_label.Size = new System.Drawing.Size(149, 42);
            this.private_total_label.TabIndex = 39;
            this.private_total_label.Tag = "16";
            this.private_total_label.Text = "مبلغ کل خصوصی (ریال) :";
            this.private_total_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // public_ins_sha_label
            // 
            this.public_ins_sha_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_ins_sha_label.AutoSize = true;
            this.public_ins_sha_label.BackColor = System.Drawing.Color.Transparent;
            this.public_ins_sha_label.ForeColor = System.Drawing.Color.Black;
            this.public_ins_sha_label.Location = new System.Drawing.Point(502, 146);
            this.public_ins_sha_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_ins_sha_label.Name = "public_ins_sha_label";
            this.public_ins_sha_label.Size = new System.Drawing.Size(156, 42);
            this.public_ins_sha_label.TabIndex = 32;
            this.public_ins_sha_label.Tag = "12";
            this.public_ins_sha_label.Text = "سهم سازمان دولتی (ریال) :";
            this.public_ins_sha_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // public_pat_per_label
            // 
            this.public_pat_per_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_pat_per_label.AutoSize = true;
            this.public_pat_per_label.BackColor = System.Drawing.Color.Transparent;
            this.public_pat_per_label.ForeColor = System.Drawing.Color.Black;
            this.public_pat_per_label.Location = new System.Drawing.Point(502, 188);
            this.public_pat_per_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_pat_per_label.Name = "public_pat_per_label";
            this.public_pat_per_label.Size = new System.Drawing.Size(141, 42);
            this.public_pat_per_label.TabIndex = 31;
            this.public_pat_per_label.Tag = "13";
            this.public_pat_per_label.Text = "درصد دولتی سهم بیمار :";
            this.public_pat_per_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // public_k_label
            // 
            this.public_k_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_k_label.AutoSize = true;
            this.public_k_label.BackColor = System.Drawing.Color.Transparent;
            this.public_k_label.ForeColor = System.Drawing.Color.Black;
            this.public_k_label.Location = new System.Drawing.Point(502, 272);
            this.public_k_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_k_label.Name = "public_k_label";
            this.public_k_label.Size = new System.Drawing.Size(105, 42);
            this.public_k_label.TabIndex = 30;
            this.public_k_label.Tag = "15";
            this.public_k_label.Text = "ضریب K دولتی :";
            this.public_k_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // public_ins_sha_textbox
            // 
            this.public_ins_sha_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_ins_sha_textbox.Enabled = false;
            this.public_ins_sha_textbox.Location = new System.Drawing.Point(354, 150);
            this.public_ins_sha_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_ins_sha_textbox.MaxLength = 11;
            this.public_ins_sha_textbox.Name = "public_ins_sha_textbox";
            this.public_ins_sha_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_ins_sha_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_ins_sha_textbox.TabIndex = 25;
            this.public_ins_sha_textbox.Tag = "12";
            this.public_ins_sha_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_ins_sha_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_ins_sha_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.public_ins_sha_textbox.Leave += new System.EventHandler(this.public_ins_sha_textbox_Leave);
            // 
            // public_total_textbox
            // 
            this.public_total_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_total_textbox.Enabled = false;
            this.public_total_textbox.Location = new System.Drawing.Point(354, 24);
            this.public_total_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_total_textbox.MaxLength = 11;
            this.public_total_textbox.Name = "public_total_textbox";
            this.public_total_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_total_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_total_textbox.TabIndex = 22;
            this.public_total_textbox.Tag = "9";
            this.public_total_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_total_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_total_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.public_total_textbox.Leave += new System.EventHandler(this.public_total_textbox_Leave);
            // 
            // public_total_label
            // 
            this.public_total_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_total_label.AutoSize = true;
            this.public_total_label.Location = new System.Drawing.Point(502, 20);
            this.public_total_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_total_label.Name = "public_total_label";
            this.public_total_label.Size = new System.Drawing.Size(134, 42);
            this.public_total_label.TabIndex = 1;
            this.public_total_label.Tag = "9";
            this.public_total_label.Text = "مبلغ کل دولتی (ریال) :";
            this.public_total_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // public_pat_sha_label
            // 
            this.public_pat_sha_label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.public_pat_sha_label.AutoSize = true;
            this.public_pat_sha_label.BackColor = System.Drawing.Color.Transparent;
            this.public_pat_sha_label.ForeColor = System.Drawing.Color.Black;
            this.public_pat_sha_label.Location = new System.Drawing.Point(502, 62);
            this.public_pat_sha_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.public_pat_sha_label.Name = "public_pat_sha_label";
            this.public_pat_sha_label.Size = new System.Drawing.Size(142, 42);
            this.public_pat_sha_label.TabIndex = 6;
            this.public_pat_sha_label.Tag = "10";
            this.public_pat_sha_label.Text = "سهم بیمار دولتی (ریال) :";
            this.public_pat_sha_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // public_pat_sha_textbox
            // 
            this.public_pat_sha_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.public_pat_sha_textbox.Enabled = false;
            this.public_pat_sha_textbox.Location = new System.Drawing.Point(354, 66);
            this.public_pat_sha_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.public_pat_sha_textbox.MaxLength = 11;
            this.public_pat_sha_textbox.Name = "public_pat_sha_textbox";
            this.public_pat_sha_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.public_pat_sha_textbox.Size = new System.Drawing.Size(140, 34);
            this.public_pat_sha_textbox.TabIndex = 23;
            this.public_pat_sha_textbox.Tag = "10";
            this.public_pat_sha_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.public_pat_sha_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.public_pat_sha_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.public_pat_sha_textbox.Leave += new System.EventHandler(this.public_pat_sha_textbox_Leave);
            // 
            // public_total_checkbox
            // 
            this.public_total_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_total_checkbox.AutoSize = true;
            this.public_total_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_total_checkbox.Enabled = false;
            this.public_total_checkbox.Location = new System.Drawing.Point(166, 34);
            this.public_total_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_total_checkbox.Name = "public_total_checkbox";
            this.public_total_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_total_checkbox.TabIndex = 40;
            this.public_total_checkbox.Tag = "9";
            this.public_total_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_total_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_pat_sha_checkbox
            // 
            this.public_pat_sha_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_pat_sha_checkbox.AutoSize = true;
            this.public_pat_sha_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_pat_sha_checkbox.Enabled = false;
            this.public_pat_sha_checkbox.Location = new System.Drawing.Point(166, 76);
            this.public_pat_sha_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_pat_sha_checkbox.Name = "public_pat_sha_checkbox";
            this.public_pat_sha_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_pat_sha_checkbox.TabIndex = 41;
            this.public_pat_sha_checkbox.Tag = "10";
            this.public_pat_sha_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_pat_sha_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_ins_sha_checkbox
            // 
            this.public_ins_sha_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_ins_sha_checkbox.AutoSize = true;
            this.public_ins_sha_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_ins_sha_checkbox.Enabled = false;
            this.public_ins_sha_checkbox.Location = new System.Drawing.Point(166, 160);
            this.public_ins_sha_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_ins_sha_checkbox.Name = "public_ins_sha_checkbox";
            this.public_ins_sha_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_ins_sha_checkbox.TabIndex = 43;
            this.public_ins_sha_checkbox.Tag = "12";
            this.public_ins_sha_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_ins_sha_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_pat_per_checkbox
            // 
            this.public_pat_per_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_pat_per_checkbox.AutoSize = true;
            this.public_pat_per_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_pat_per_checkbox.Enabled = false;
            this.public_pat_per_checkbox.Location = new System.Drawing.Point(166, 202);
            this.public_pat_per_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_pat_per_checkbox.Name = "public_pat_per_checkbox";
            this.public_pat_per_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_pat_per_checkbox.TabIndex = 44;
            this.public_pat_per_checkbox.Tag = "13";
            this.public_pat_per_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_pat_per_checkbox.UseVisualStyleBackColor = true;
            // 
            // public_k_checkbox
            // 
            this.public_k_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.public_k_checkbox.AutoSize = true;
            this.public_k_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_k_checkbox.Enabled = false;
            this.public_k_checkbox.Location = new System.Drawing.Point(166, 286);
            this.public_k_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.public_k_checkbox.Name = "public_k_checkbox";
            this.public_k_checkbox.Size = new System.Drawing.Size(15, 14);
            this.public_k_checkbox.TabIndex = 46;
            this.public_k_checkbox.Tag = "15";
            this.public_k_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.public_k_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_total_checkbox
            // 
            this.private_total_checkbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.private_total_checkbox.AutoSize = true;
            this.private_total_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_total_checkbox.Enabled = false;
            this.private_total_checkbox.Location = new System.Drawing.Point(166, 328);
            this.private_total_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.private_total_checkbox.Name = "private_total_checkbox";
            this.private_total_checkbox.Size = new System.Drawing.Size(15, 14);
            this.private_total_checkbox.TabIndex = 49;
            this.private_total_checkbox.Tag = "16";
            this.private_total_checkbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.private_total_checkbox.UseVisualStyleBackColor = true;
            // 
            // private_discount_textbox
            // 
            this.private_discount_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.private_discount_textbox.Enabled = false;
            this.private_discount_textbox.Location = new System.Drawing.Point(354, 402);
            this.private_discount_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.private_discount_textbox.MaxLength = 11;
            this.private_discount_textbox.Name = "private_discount_textbox";
            this.private_discount_textbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.private_discount_textbox.Size = new System.Drawing.Size(140, 34);
            this.private_discount_textbox.TabIndex = 33;
            this.private_discount_textbox.Tag = "18";
            this.private_discount_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.private_discount_textbox.Enter += new System.EventHandler(this.tariff_textbox_Enter);
            this.private_discount_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tariff_int_textbox_KeyPress);
            this.private_discount_textbox.Leave += new System.EventHandler(this.private_discount_textbox_Leave);
            // 
            // t_clear_label
            // 
            this.t_clear_label.Location = new System.Drawing.Point(194, 0);
            this.t_clear_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.t_clear_label.Name = "t_clear_label";
            this.t_clear_label.Size = new System.Drawing.Size(149, 20);
            this.t_clear_label.TabIndex = 40;
            this.t_clear_label.Text = "پاک شدن اطلاعات؟";
            this.t_clear_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t_clear_label.Visible = false;
            // 
            // form_tableLayout
            // 
            this.form_tableLayout.ColumnCount = 1;
            this.form_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.form_tableLayout.Controls.Add(this.main_tabControl, 0, 0);
            this.form_tableLayout.Controls.Add(this.buttons_flowLayout, 0, 1);
            this.form_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.form_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.form_tableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.form_tableLayout.Name = "form_tableLayout";
            this.form_tableLayout.RowCount = 2;
            this.form_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.6815F));
            this.form_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.318498F));
            this.form_tableLayout.Size = new System.Drawing.Size(705, 567);
            this.form_tableLayout.TabIndex = 2;
            // 
            // buttons_flowLayout
            // 
            this.buttons_flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttons_flowLayout.Controls.Add(this.cancel_button);
            this.buttons_flowLayout.Controls.Add(this.save_button);
            this.buttons_flowLayout.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttons_flowLayout.Location = new System.Drawing.Point(253, 518);
            this.buttons_flowLayout.Margin = new System.Windows.Forms.Padding(4);
            this.buttons_flowLayout.Name = "buttons_flowLayout";
            this.buttons_flowLayout.Padding = new System.Windows.Forms.Padding(16, 0, 7, 0);
            this.buttons_flowLayout.Size = new System.Drawing.Size(199, 45);
            this.buttons_flowLayout.TabIndex = 10;
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cancel_button.AutoSize = true;
            this.cancel_button.CausesValidation = false;
            this.cancel_button.Location = new System.Drawing.Point(20, 4);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(4);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(74, 37);
            this.cancel_button.TabIndex = 59;
            this.cancel_button.Text = "انصراف";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // save_button
            // 
            this.save_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.save_button.AutoSize = true;
            this.save_button.CausesValidation = false;
            this.save_button.Location = new System.Drawing.Point(102, 4);
            this.save_button.Margin = new System.Windows.Forms.Padding(4);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(74, 37);
            this.save_button.TabIndex = 58;
            this.save_button.Text = "ذخیره";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // EP_degree
            // 
            this.EP_degree.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_degree.ContainerControl = this;
            this.EP_degree.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_degree.Icon")));
            this.EP_degree.RightToLeft = true;
            // 
            // EP_info_tab
            // 
            this.EP_info_tab.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_info_tab.ContainerControl = this;
            this.EP_info_tab.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_info_tab.Icon")));
            this.EP_info_tab.RightToLeft = true;
            // 
            // EP_tariff_tab
            // 
            this.EP_tariff_tab.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.EP_tariff_tab.ContainerControl = this;
            this.EP_tariff_tab.Icon = ((System.Drawing.Icon)(resources.GetObject("EP_tariff_tab.Icon")));
            this.EP_tariff_tab.RightToLeft = true;
            // 
            // kValueTableAdapter
            // 
            this.kValueTableAdapter.ClearBeforeFill = true;
            // 
            // tMedicalServiceTableAdapter
            // 
            this.tMedicalServiceTableAdapter.ClearBeforeFill = true;
            // 
            // MedicalServiceTariffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(705, 567);
            this.Controls.Add(this.form_tableLayout);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MedicalServiceTariffForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.MedicalServiceTariffForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.EP_service_tab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_alias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_end_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_description)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_start_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_public)).EndInit();
            this.main_tabControl.ResumeLayout(false);
            this.service_tab.ResumeLayout(false);
            this.service_tab.PerformLayout();
            this.service_tableLayout.ResumeLayout(false);
            this.service_tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s_service_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMedicalServiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.info_tab.ResumeLayout(false);
            this.info_tableLayout.ResumeLayout(false);
            this.info_tableLayout.PerformLayout();
            this.k_value_tab.ResumeLayout(false);
            this.k_tableLayout.ResumeLayout(false);
            this.k_tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.k_private_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kValueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.k_public_grid)).EndInit();
            this.tariff_tab.ResumeLayout(false);
            this.tariff_tableLayout.ResumeLayout(false);
            this.tariff_tableLayout.PerformLayout();
            this.form_tableLayout.ResumeLayout(false);
            this.buttons_flowLayout.ResumeLayout(false);
            this.buttons_flowLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_degree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_info_tab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EP_tariff_tab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider EP_service_tab;
        private System.Windows.Forms.ErrorProvider EP_service;
        private System.Windows.Forms.ErrorProvider EP_alias;
        private System.Windows.Forms.ErrorProvider EP_end_date;
        private System.Windows.Forms.ErrorProvider EP_description;
        private System.Windows.Forms.ErrorProvider EP_start_date;
        private System.Windows.Forms.ErrorProvider EP_public;
        private System.Windows.Forms.TableLayoutPanel form_tableLayout;
        private System.Windows.Forms.FlowLayoutPanel buttons_flowLayout;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TabControl main_tabControl;
        private System.Windows.Forms.TabPage info_tab;
        private System.Windows.Forms.TabPage service_tab;
        private System.Windows.Forms.TableLayoutPanel service_tableLayout;
        private System.Windows.Forms.TextBox s_selected_textbox;
        private System.Windows.Forms.TextBox s_code_text;
        private System.Windows.Forms.TextBox s_name_text;
        private System.Windows.Forms.Label s_name_label;
        private System.Windows.Forms.Label s_category_label;
        private System.Windows.Forms.Label code_label;
        private System.Windows.Forms.ComboBox s_category_combobox;
        private System.Windows.Forms.Button s_search_button;
        private System.Windows.Forms.TableLayoutPanel info_tableLayout;
        private System.Windows.Forms.MaskedTextBox i_start_date_masked;
        private System.Windows.Forms.ComboBox i_insurance_combobox;
        private System.Windows.Forms.CheckBox i_sector_checkbox;
        private System.Windows.Forms.Label i_sector_label;
        private System.Windows.Forms.ComboBox i_sector_combobox;
        private System.Windows.Forms.CheckBox i_description_checkbox;
        private System.Windows.Forms.Label i_clear_label;
        private System.Windows.Forms.Label i_end_date_label;
        private System.Windows.Forms.ComboBox i_degree_combobox;
        private System.Windows.Forms.Label i_alias_label;
        private System.Windows.Forms.Label i_insurance_label;
        private System.Windows.Forms.Label i_degree_label;
        private System.Windows.Forms.Label i_start_date_label;
        private System.Windows.Forms.TextBox i_alias_textbox;
        private System.Windows.Forms.TextBox i_sequence_textbox;
        private System.Windows.Forms.Label i_sequence_label;
        private System.Windows.Forms.Label i_description_label;
        private System.Windows.Forms.TextBox i_description_textbox;
        private System.Windows.Forms.CheckBox i_sequence_checkbox;
        private System.Windows.Forms.CheckBox i_alias_checkbox;
        private System.Windows.Forms.CheckBox i_insurance_checkbox;
        private System.Windows.Forms.CheckBox i_degree_checkbox;
        private System.Windows.Forms.CheckBox i_start_date_checkbox;
        private System.Windows.Forms.CheckBox i_end_date_checkbox;
        private System.Windows.Forms.MaskedTextBox i_end_date_masked;
        private System.Windows.Forms.ErrorProvider EP_degree;
        private System.Windows.Forms.ErrorProvider EP_info_tab;
        private System.Windows.Forms.ErrorProvider EP_tariff_tab;
        private System.Windows.Forms.TabPage k_value_tab;
        private System.Windows.Forms.TabPage tariff_tab;
        private System.Windows.Forms.TableLayoutPanel tariff_tableLayout;
        private System.Windows.Forms.Label private_discount_label;
        private System.Windows.Forms.CheckBox private_discount_checkbox;
        private System.Windows.Forms.CheckBox public_discount_checkbox;
        private System.Windows.Forms.TextBox public_discount_textbox;
        private System.Windows.Forms.Label public_discount_label;
        private System.Windows.Forms.Label private_pat_sha_label;
        private System.Windows.Forms.Label private_ins_sha_label;
        private System.Windows.Forms.Label private_k_label;
        private System.Windows.Forms.Label private_ins_per_label;
        private System.Windows.Forms.Label private_pat_per_label;
        private System.Windows.Forms.CheckBox private_ins_sha_checkbox;
        private System.Windows.Forms.CheckBox private_pat_per_checkbox;
        private System.Windows.Forms.CheckBox private_k_checkbox;
        private System.Windows.Forms.CheckBox private_pat_sha_checkbox;
        private System.Windows.Forms.CheckBox private_ins_per_checkbox;
        private System.Windows.Forms.TextBox private_k_textbox;
        private System.Windows.Forms.TextBox private_ins_sha_textbox;
        private System.Windows.Forms.TextBox private_ins_per_textbox;
        private System.Windows.Forms.TextBox private_pat_per_textbox;
        private System.Windows.Forms.TextBox private_pat_sha_textbox;
        private System.Windows.Forms.TextBox private_total_textbox;
        private System.Windows.Forms.TextBox public_k_textbox;
        private System.Windows.Forms.TextBox public_ins_per_textbox;
        private System.Windows.Forms.TextBox public_pat_per_textbox;
        private System.Windows.Forms.CheckBox public_ins_per_checkbox;
        private System.Windows.Forms.Label public_ins_per_label;
        private System.Windows.Forms.Label private_total_label;
        private System.Windows.Forms.Label public_ins_sha_label;
        private System.Windows.Forms.Label public_pat_per_label;
        private System.Windows.Forms.Label public_k_label;
        private System.Windows.Forms.TextBox public_ins_sha_textbox;
        private System.Windows.Forms.TextBox public_total_textbox;
        private System.Windows.Forms.Label public_total_label;
        private System.Windows.Forms.Label public_pat_sha_label;
        private System.Windows.Forms.TextBox public_pat_sha_textbox;
        private System.Windows.Forms.CheckBox public_total_checkbox;
        private System.Windows.Forms.CheckBox public_pat_sha_checkbox;
        private System.Windows.Forms.CheckBox public_ins_sha_checkbox;
        private System.Windows.Forms.CheckBox public_pat_per_checkbox;
        private System.Windows.Forms.CheckBox public_k_checkbox;
        private System.Windows.Forms.CheckBox private_total_checkbox;
        private System.Windows.Forms.TextBox private_discount_textbox;
        private System.Windows.Forms.Label t_clear_label;
        private System.Windows.Forms.TableLayoutPanel k_tableLayout;
        private System.Windows.Forms.ComboBox k_year_cbx;
        private System.Windows.Forms.Label k_year_lbl;
        private System.Windows.Forms.Label k_public_lbl;
        private System.Windows.Forms.Label k_private_lbl;
        private System.Windows.Forms.DataGridView k_public_grid;
        private System.Windows.Forms.BindingSource kValueBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.KValueTableAdapter kValueTableAdapter;
        private System.Windows.Forms.DataGridView k_private_grid;
        private System.Windows.Forms.Button k_search_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn k_pri_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_prof_value_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_tec_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_year_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_third_value_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_ins_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_sector_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_start_date_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pri_description_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn k_pub_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_professional_value_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_technical_value_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_year_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_third_value_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_insurance_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_insurance_sector_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_start_date_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_pu_description_column;
        private System.Windows.Forms.DataGridView s_service_grid;
        private System.Windows.Forms.BindingSource tMedicalServiceBindingSource;
        private PIPDataSetTableAdapters.TMedicalServiceTableAdapter tMedicalServiceTableAdapter;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn s_start_date_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_description_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_category_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sub_category;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_sector_column;
    }
}