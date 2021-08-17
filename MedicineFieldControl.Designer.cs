namespace PadraInsurancePrescription
{
    partial class MedicineFieldControl
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
            this.p_search_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.name_text = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.medicine_field_grid = new System.Windows.Forms.DataGridView();
            this.f_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.f_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineFieldBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.medicineFieldTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.MedicineFieldTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            this.p_search_flowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicine_field_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineFieldBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 517F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel.Controls.Add(this.p_search_flowLayoutPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.medicine_field_grid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.new_button, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 1, 4);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(723, 393);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // p_search_flowLayoutPanel
            // 
            this.tableLayoutPanel.SetColumnSpan(this.p_search_flowLayoutPanel, 2);
            this.p_search_flowLayoutPanel.Controls.Add(this.label2);
            this.p_search_flowLayoutPanel.Controls.Add(this.name_text);
            this.p_search_flowLayoutPanel.Controls.Add(this.search_button);
            this.p_search_flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_search_flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.p_search_flowLayoutPanel.Name = "p_search_flowLayoutPanel";
            this.p_search_flowLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.p_search_flowLayoutPanel.Size = new System.Drawing.Size(717, 44);
            this.p_search_flowLayoutPanel.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(606, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "عنوان رشته پزشکی :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_text
            // 
            this.name_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_text.Location = new System.Drawing.Point(454, 5);
            this.name_text.MaxLength = 250;
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(146, 20);
            this.name_text.TabIndex = 0;
            // 
            // search_button
            // 
            this.search_button.AutoSize = true;
            this.search_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search_button.Location = new System.Drawing.Point(378, 5);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(70, 27);
            this.search_button.TabIndex = 1;
            this.search_button.Text = "جستجو";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // medicine_field_grid
            // 
            this.medicine_field_grid.AllowUserToAddRows = false;
            this.medicine_field_grid.AllowUserToDeleteRows = false;
            this.medicine_field_grid.AutoGenerateColumns = false;
            this.medicine_field_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.medicine_field_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.medicine_field_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicine_field_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.f_select_column,
            this.f_id_column,
            this.f_name_column,
            this.f_description_column});
            this.medicine_field_grid.DataSource = this.medicineFieldBindingSource;
            this.medicine_field_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medicine_field_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.medicine_field_grid.Location = new System.Drawing.Point(209, 53);
            this.medicine_field_grid.MultiSelect = false;
            this.medicine_field_grid.Name = "medicine_field_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.medicine_field_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.medicine_field_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.medicine_field_grid, 7);
            this.medicine_field_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.medicine_field_grid.ShowCellErrors = false;
            this.medicine_field_grid.ShowCellToolTips = false;
            this.medicine_field_grid.Size = new System.Drawing.Size(511, 303);
            this.medicine_field_grid.TabIndex = 2;
            this.medicine_field_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.medicine_field_grid_DataBindingComplete);
            // 
            // f_select_column
            // 
            this.f_select_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue;
            this.f_select_column.DefaultCellStyle = dataGridViewCellStyle2;
            this.f_select_column.FalseValue = "false";
            this.f_select_column.Frozen = true;
            this.f_select_column.HeaderText = "";
            this.f_select_column.IndeterminateValue = "false";
            this.f_select_column.MinimumWidth = 30;
            this.f_select_column.Name = "f_select_column";
            this.f_select_column.TrueValue = "true";
            this.f_select_column.Width = 30;
            // 
            // f_id_column
            // 
            this.f_id_column.DataPropertyName = "id";
            this.f_id_column.HeaderText = "شناسه";
            this.f_id_column.Name = "f_id_column";
            this.f_id_column.ReadOnly = true;
            this.f_id_column.Width = 67;
            // 
            // f_name_column
            // 
            this.f_name_column.DataPropertyName = "name";
            this.f_name_column.HeaderText = "عنوان";
            this.f_name_column.Name = "f_name_column";
            this.f_name_column.ReadOnly = true;
            this.f_name_column.Width = 65;
            // 
            // f_description_column
            // 
            this.f_description_column.DataPropertyName = "description";
            this.f_description_column.HeaderText = "توضیحات";
            this.f_description_column.Name = "f_description_column";
            this.f_description_column.ReadOnly = true;
            this.f_description_column.Width = 86;
            // 
            // medicineFieldBindingSource
            // 
            this.medicineFieldBindingSource.DataMember = "MedicineField";
            this.medicineFieldBindingSource.DataSource = this.pIPDataSet;
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
            this.new_button.Location = new System.Drawing.Point(3, 83);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(200, 35);
            this.new_button.TabIndex = 3;
            this.new_button.Text = "ایجاد رشته پزشکی جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_button.AutoSize = true;
            this.edit_button.Location = new System.Drawing.Point(3, 124);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(200, 35);
            this.edit_button.TabIndex = 4;
            this.edit_button.Text = "ویرایش انتخاب شده ها";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delete_button.AutoSize = true;
            this.delete_button.Location = new System.Drawing.Point(3, 165);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(200, 35);
            this.delete_button.TabIndex = 5;
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
            // medicineFieldTableAdapter
            // 
            this.medicineFieldTableAdapter.ClearBeforeFill = true;
            // 
            // MedicineFieldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "MedicineFieldControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(723, 393);
            this.Tag = "رشته های پزشکی";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.p_search_flowLayoutPanel.ResumeLayout(false);
            this.p_search_flowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicine_field_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineFieldBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView medicine_field_grid;
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
        private System.Windows.Forms.BindingSource medicineFieldBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.MedicineFieldTableAdapter medicineFieldTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn f_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn f_description_column;
        private System.Windows.Forms.FlowLayoutPanel p_search_flowLayoutPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Button search_button;
    }
}
