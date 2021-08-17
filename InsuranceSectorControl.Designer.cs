namespace PadraInsurancePrescription
{
    partial class InsuranceSectorControl
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
            this.search_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.new_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.sector_grid = new System.Windows.Forms.DataGridView();
            this.name_text = new System.Windows.Forms.TextBox();
            this.tag_text = new System.Windows.Forms.TextBox();
            this.id_text = new System.Windows.Forms.TextBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ins_text = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.insuranceSectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.insuranceSectorTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.InsuranceSectorTableAdapter();
            this.s_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.s_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_tag_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_insurance_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_report_order_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_logo_image_column = new System.Windows.Forms.DataGridViewImageColumn();
            this.s_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_allow_modify_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.s_insurance_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sector_grid)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceSectorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(297, 29);
            this.search_button.Name = "search_button";
            this.tableLayoutPanel.SetRowSpan(this.search_button, 2);
            this.search_button.Size = new System.Drawing.Size(70, 23);
            this.search_button.TabIndex = 4;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
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
            // new_button
            // 
            this.new_button.AutoSize = true;
            this.new_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.new_button.Location = new System.Drawing.Point(3, 110);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(162, 35);
            this.new_button.TabIndex = 6;
            this.new_button.Text = "ایجاد صندوق بیمه ای جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
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
            // sector_grid
            // 
            this.sector_grid.AllowUserToAddRows = false;
            this.sector_grid.AllowUserToDeleteRows = false;
            this.sector_grid.AutoGenerateColumns = false;
            this.sector_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sector_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sector_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sector_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.s_select_column,
            this.s_id_column,
            this.s_name_column,
            this.s_tag_column,
            this.s_insurance_name_column,
            this.s_report_order_column,
            this.s_logo_image_column,
            this.s_description_column,
            this.s_allow_modify_column,
            this.s_insurance_column});
            this.tableLayoutPanel.SetColumnSpan(this.sector_grid, 5);
            this.sector_grid.DataSource = this.insuranceSectorBindingSource;
            this.sector_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sector_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.sector_grid.Location = new System.Drawing.Point(171, 75);
            this.sector_grid.MultiSelect = false;
            this.sector_grid.Name = "sector_grid";
            this.sector_grid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sector_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.sector_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.sector_grid, 5);
            this.sector_grid.RowTemplate.Height = 100;
            this.sector_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.sector_grid.ShowCellErrors = false;
            this.sector_grid.ShowCellToolTips = false;
            this.sector_grid.Size = new System.Drawing.Size(792, 411);
            this.sector_grid.TabIndex = 5;
            this.sector_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.sector_grid_DataBindingComplete);
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
            // tag_text
            // 
            this.tag_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tag_text.Location = new System.Drawing.Point(373, 3);
            this.tag_text.MaxLength = 250;
            this.tag_text.Name = "tag_text";
            this.tag_text.Size = new System.Drawing.Size(170, 20);
            this.tag_text.TabIndex = 1;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(549, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 26);
            this.label3.TabIndex = 26;
            this.label3.Text = "سازمان بیمه گر :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ins_text
            // 
            this.ins_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ins_text.Location = new System.Drawing.Point(373, 29);
            this.ins_text.MaxLength = 250;
            this.ins_text.Name = "ins_text";
            this.ins_text.Size = new System.Drawing.Size(170, 20);
            this.ins_text.TabIndex = 27;
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
            this.tableLayoutPanel.Controls.Add(this.ins_text, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 5, 7);
            this.tableLayoutPanel.Controls.Add(this.id_text, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.tag_text, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.sector_grid, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 5, 6);
            this.tableLayoutPanel.Controls.Add(this.new_button, 5, 5);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 1);
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
            // insuranceSectorBindingSource
            // 
            this.insuranceSectorBindingSource.DataMember = "InsuranceSector";
            this.insuranceSectorBindingSource.DataSource = this.pIPDataSet;
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.EnforceConstraints = false;
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // insuranceSectorTableAdapter
            // 
            this.insuranceSectorTableAdapter.ClearBeforeFill = true;
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
            this.s_select_column.ReadOnly = true;
            this.s_select_column.TrueValue = "true";
            this.s_select_column.Width = 30;
            // 
            // s_id_column
            // 
            this.s_id_column.DataPropertyName = "id";
            this.s_id_column.HeaderText = "شناسه";
            this.s_id_column.Name = "s_id_column";
            this.s_id_column.ReadOnly = true;
            this.s_id_column.Width = 67;
            // 
            // s_name_column
            // 
            this.s_name_column.DataPropertyName = "name";
            this.s_name_column.HeaderText = "نام صندوق";
            this.s_name_column.Name = "s_name_column";
            this.s_name_column.ReadOnly = true;
            this.s_name_column.Width = 90;
            // 
            // s_tag_column
            // 
            this.s_tag_column.DataPropertyName = "tag";
            this.s_tag_column.HeaderText = "برچسب انگلیسی";
            this.s_tag_column.Name = "s_tag_column";
            this.s_tag_column.ReadOnly = true;
            this.s_tag_column.Width = 117;
            // 
            // s_insurance_name_column
            // 
            this.s_insurance_name_column.DataPropertyName = "insurance_name";
            this.s_insurance_name_column.HeaderText = "سازمان بیمه ای";
            this.s_insurance_name_column.Name = "s_insurance_name_column";
            this.s_insurance_name_column.ReadOnly = true;
            this.s_insurance_name_column.Width = 114;
            // 
            // s_report_order_column
            // 
            this.s_report_order_column.DataPropertyName = "report_order";
            this.s_report_order_column.HeaderText = "شماره ردیف در گزارش ها";
            this.s_report_order_column.Name = "s_report_order_column";
            this.s_report_order_column.ReadOnly = true;
            this.s_report_order_column.Width = 110;
            // 
            // s_logo_image_column
            // 
            this.s_logo_image_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.s_logo_image_column.DataPropertyName = "logo_image";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.s_logo_image_column.DefaultCellStyle = dataGridViewCellStyle3;
            this.s_logo_image_column.HeaderText = "لوگو/آرم";
            this.s_logo_image_column.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.s_logo_image_column.MinimumWidth = 100;
            this.s_logo_image_column.Name = "s_logo_image_column";
            this.s_logo_image_column.ReadOnly = true;
            this.s_logo_image_column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.s_logo_image_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // s_description_column
            // 
            this.s_description_column.DataPropertyName = "description";
            this.s_description_column.HeaderText = "توضیحات";
            this.s_description_column.Name = "s_description_column";
            this.s_description_column.ReadOnly = true;
            this.s_description_column.Width = 86;
            // 
            // s_allow_modify_column
            // 
            this.s_allow_modify_column.DataPropertyName = "allow_modify";
            this.s_allow_modify_column.HeaderText = "allow_modify";
            this.s_allow_modify_column.Name = "s_allow_modify_column";
            this.s_allow_modify_column.ReadOnly = true;
            this.s_allow_modify_column.Visible = false;
            this.s_allow_modify_column.Width = 105;
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
            // InsuranceSectorControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "InsuranceSectorControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(966, 589);
            this.Tag = "پزشک ها";
            ((System.ComponentModel.ISupportInitialize)(this.sector_grid)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insuranceSectorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.BindingSource insuranceSectorBindingSource;
        private PIPDataSetTableAdapters.InsuranceSectorTableAdapter insuranceSectorTableAdapter;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TextBox ins_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.TextBox tag_text;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.DataGridView sector_grid;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn s_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_tag_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_report_order_column;
        private System.Windows.Forms.DataGridViewImageColumn s_logo_image_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_description_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn s_allow_modify_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_insurance_column;
    }
}
