namespace PadraInsurancePrescription
{
    partial class ClinicPartControl
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.search_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.type_comboBox = new System.Windows.Forms.ComboBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clinic_part_grid = new System.Windows.Forms.DataGridView();
            this.p_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_tag_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_clinic_type_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_clinic_type_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sClinicPartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.new_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sClinicPartTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.SClinicPartTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_part_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sClinicPartBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 6;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.search_button, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.type_comboBox, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.name_text, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.clinic_part_grid, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.new_button, 5, 3);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 5, 4);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 5, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 10;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(690, 393);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // search_button
            // 
            this.search_button.AutoSize = true;
            this.search_button.Location = new System.Drawing.Point(264, 2);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.tableLayoutPanel.SetRowSpan(this.search_button, 2);
            this.search_button.Size = new System.Drawing.Size(56, 23);
            this.search_button.TabIndex = 17;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(452, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "نوع مرکز :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // type_comboBox
            // 
            this.type_comboBox.BackColor = System.Drawing.Color.White;
            this.type_comboBox.DisplayMember = "name";
            this.type_comboBox.DropDownHeight = 300;
            this.type_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type_comboBox.FormattingEnabled = true;
            this.type_comboBox.IntegralHeight = false;
            this.type_comboBox.Location = new System.Drawing.Point(324, 2);
            this.type_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.type_comboBox.Name = "type_comboBox";
            this.type_comboBox.Size = new System.Drawing.Size(124, 21);
            this.type_comboBox.TabIndex = 15;
            this.type_comboBox.ValueMember = "id";
            // 
            // name_text
            // 
            this.name_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_text.Location = new System.Drawing.Point(511, 2);
            this.name_text.Margin = new System.Windows.Forms.Padding(2);
            this.name_text.MaxLength = 250;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(124, 20);
            this.name_text.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(639, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "نام بخش :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clinic_part_grid
            // 
            this.clinic_part_grid.AllowUserToAddRows = false;
            this.clinic_part_grid.AllowUserToDeleteRows = false;
            this.clinic_part_grid.AutoGenerateColumns = false;
            this.clinic_part_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clinic_part_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.clinic_part_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clinic_part_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_select_column,
            this.p_id_column,
            this.p_name_column,
            this.p_tag_column,
            this.p_clinic_type_name_column,
            this.p_description_column,
            this.p_clinic_type_id_column});
            this.tableLayoutPanel.SetColumnSpan(this.clinic_part_grid, 5);
            this.clinic_part_grid.DataSource = this.sClinicPartBindingSource;
            this.clinic_part_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clinic_part_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.clinic_part_grid.Location = new System.Drawing.Point(177, 40);
            this.clinic_part_grid.MultiSelect = false;
            this.clinic_part_grid.Name = "clinic_part_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.clinic_part_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.clinic_part_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.clinic_part_grid, 7);
            this.clinic_part_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.clinic_part_grid.ShowCellErrors = false;
            this.clinic_part_grid.ShowCellToolTips = false;
            this.clinic_part_grid.Size = new System.Drawing.Size(510, 303);
            this.clinic_part_grid.TabIndex = 0;
            this.clinic_part_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.clinic_part_grid_DataBindingComplete);
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
            this.p_id_column.HeaderText = "شناسه";
            this.p_id_column.Name = "p_id_column";
            this.p_id_column.ReadOnly = true;
            this.p_id_column.Width = 67;
            // 
            // p_name_column
            // 
            this.p_name_column.DataPropertyName = "name";
            this.p_name_column.HeaderText = "نام بخش";
            this.p_name_column.Name = "p_name_column";
            this.p_name_column.ReadOnly = true;
            this.p_name_column.Width = 76;
            // 
            // p_tag_column
            // 
            this.p_tag_column.DataPropertyName = "tag";
            this.p_tag_column.HeaderText = "عنوان انگلیسی";
            this.p_tag_column.Name = "p_tag_column";
            this.p_tag_column.ReadOnly = true;
            this.p_tag_column.Width = 108;
            // 
            // p_clinic_type_name_column
            // 
            this.p_clinic_type_name_column.DataPropertyName = "clinic_type_name";
            this.p_clinic_type_name_column.HeaderText = "نوع مرکز درمانی";
            this.p_clinic_type_name_column.Name = "p_clinic_type_name_column";
            this.p_clinic_type_name_column.ReadOnly = true;
            this.p_clinic_type_name_column.Width = 124;
            // 
            // p_description_column
            // 
            this.p_description_column.DataPropertyName = "description";
            this.p_description_column.HeaderText = "توضیحات";
            this.p_description_column.Name = "p_description_column";
            this.p_description_column.ReadOnly = true;
            this.p_description_column.Width = 86;
            // 
            // p_clinic_type_id_column
            // 
            this.p_clinic_type_id_column.DataPropertyName = "clinic_type_id";
            this.p_clinic_type_id_column.HeaderText = "clinic_type_id";
            this.p_clinic_type_id_column.Name = "p_clinic_type_id_column";
            this.p_clinic_type_id_column.ReadOnly = true;
            this.p_clinic_type_id_column.Visible = false;
            this.p_clinic_type_id_column.Width = 158;
            // 
            // sClinicPartBindingSource
            // 
            this.sClinicPartBindingSource.DataMember = "SClinicPart";
            this.sClinicPartBindingSource.DataSource = this.pIPDataSet;
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.EnforceConstraints = false;
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // new_button
            // 
            this.new_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.new_button.AutoSize = true;
            this.new_button.Location = new System.Drawing.Point(3, 70);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(168, 35);
            this.new_button.TabIndex = 4;
            this.new_button.Text = "ایجاد بخش جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_button.AutoSize = true;
            this.edit_button.Location = new System.Drawing.Point(3, 111);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(168, 35);
            this.edit_button.TabIndex = 5;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_button.AutoSize = true;
            this.delete_button.Location = new System.Drawing.Point(3, 152);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(168, 35);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.NullValue = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
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
            // sClinicPartTableAdapter
            // 
            this.sClinicPartTableAdapter.ClearBeforeFill = true;
            // 
            // ClinicPartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "ClinicPartControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(690, 393);
            this.Tag = "مدارک پزشکی";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clinic_part_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sClinicPartBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView clinic_part_grid;
        private System.Windows.Forms.Button new_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox type_comboBox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_tag_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_clinic_type_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_description_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_clinic_type_id_column;
        private System.Windows.Forms.BindingSource sClinicPartBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.SClinicPartTableAdapter sClinicPartTableAdapter;
    }
}
