namespace PadraInsurancePrescription
{
    partial class MedicineDegreeControl
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
            this.medicine_degree_grid = new System.Windows.Forms.DataGridView();
            this.d_select_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_description_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.new_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.refresh_grid_link = new System.Windows.Forms.LinkLabel();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicineDegreeTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.MedicineDegreeTableAdapter();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicine_degree_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDegreeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 646F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.medicine_degree_grid, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.new_button, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.edit_button, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.delete_button, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.refresh_grid_link, 1, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(862, 491);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // medicine_degree_grid
            // 
            this.medicine_degree_grid.AllowUserToAddRows = false;
            this.medicine_degree_grid.AllowUserToDeleteRows = false;
            this.medicine_degree_grid.AutoGenerateColumns = false;
            this.medicine_degree_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.medicine_degree_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.medicine_degree_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicine_degree_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d_select_column,
            this.d_id_column,
            this.d_name_column,
            this.d_description_column});
            this.medicine_degree_grid.DataSource = this.medicineDegreeBindingSource;
            this.medicine_degree_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medicine_degree_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.medicine_degree_grid.Location = new System.Drawing.Point(220, 29);
            this.medicine_degree_grid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.medicine_degree_grid.MultiSelect = false;
            this.medicine_degree_grid.Name = "medicine_degree_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.medicine_degree_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.medicine_degree_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableLayoutPanel.SetRowSpan(this.medicine_degree_grid, 7);
            this.medicine_degree_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.medicine_degree_grid.ShowCellErrors = false;
            this.medicine_degree_grid.ShowCellToolTips = false;
            this.medicine_degree_grid.Size = new System.Drawing.Size(638, 379);
            this.medicine_degree_grid.TabIndex = 0;
            this.medicine_degree_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.medicine_degree_grid_DataBindingComplete);
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
            this.d_id_column.Width = 81;
            // 
            // d_name_column
            // 
            this.d_name_column.DataPropertyName = "name";
            this.d_name_column.HeaderText = "عنوان";
            this.d_name_column.Name = "d_name_column";
            this.d_name_column.ReadOnly = true;
            this.d_name_column.Width = 80;
            // 
            // d_description_column
            // 
            this.d_description_column.DataPropertyName = "description";
            this.d_description_column.HeaderText = "توضیحات";
            this.d_description_column.Name = "d_description_column";
            this.d_description_column.ReadOnly = true;
            this.d_description_column.Width = 106;
            // 
            // medicineDegreeBindingSource
            // 
            this.medicineDegreeBindingSource.DataMember = "MedicineDegree";
            this.medicineDegreeBindingSource.DataSource = this.pIPDataSet;
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // new_button
            // 
            this.new_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.new_button.AutoSize = true;
            this.new_button.Location = new System.Drawing.Point(4, 67);
            this.new_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.new_button.Name = "new_button";
            this.new_button.Size = new System.Drawing.Size(208, 44);
            this.new_button.TabIndex = 4;
            this.new_button.Text = "ایجاد مدرک پزشکی جدید";
            this.new_button.UseVisualStyleBackColor = true;
            this.new_button.Click += new System.EventHandler(this.new_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edit_button.AutoSize = true;
            this.edit_button.Location = new System.Drawing.Point(4, 119);
            this.edit_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(208, 44);
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
            this.delete_button.Location = new System.Drawing.Point(4, 171);
            this.delete_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(208, 44);
            this.delete_button.TabIndex = 3;
            this.delete_button.Text = "حذف انتخاب شده ها";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // refresh_grid_link
            // 
            this.refresh_grid_link.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refresh_grid_link.AutoSize = true;
            this.refresh_grid_link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refresh_grid_link.Location = new System.Drawing.Point(4, 25);
            this.refresh_grid_link.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.refresh_grid_link.Name = "refresh_grid_link";
            this.refresh_grid_link.Size = new System.Drawing.Size(208, 38);
            this.refresh_grid_link.TabIndex = 12;
            this.refresh_grid_link.TabStop = true;
            this.refresh_grid_link.Text = "به روز رسانی جدول";
            this.refresh_grid_link.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.refresh_grid_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.refresh_grid_link_LinkClicked);
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
            // medicineDegreeTableAdapter
            // 
            this.medicineDegreeTableAdapter.ClearBeforeFill = true;
            // 
            // MedicineDegreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MedicineDegreeControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(862, 491);
            this.Tag = "مدارک پزشکی";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicine_degree_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineDegreeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.DataGridView medicine_degree_grid;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn d_select_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_description_column;
        private System.Windows.Forms.BindingSource medicineDegreeBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.MedicineDegreeTableAdapter medicineDegreeTableAdapter;
        private System.Windows.Forms.LinkLabel refresh_grid_link;
    }
}
