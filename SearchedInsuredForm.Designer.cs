namespace PadraInsurancePrescription
{
    partial class SearchedInsuredForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.insured_grid = new System.Windows.Forms.DataGridView();
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
            this.ins_title_label = new System.Windows.Forms.Label();
            this.sec_title_label = new System.Windows.Forms.Label();
            this.insurance_label = new System.Windows.Forms.Label();
            this.seqeunce_label = new System.Windows.Forms.Label();
            this.tInsuredTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TInsuredTableAdapter();
            this.main_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insured_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tInsuredBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 2;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.Controls.Add(this.insured_grid, 0, 3);
            this.main_tableLayoutPanel.Controls.Add(this.ins_title_label, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.sec_title_label, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.insurance_label, 0, 1);
            this.main_tableLayoutPanel.Controls.Add(this.seqeunce_label, 0, 2);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 4;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(1054, 353);
            this.main_tableLayoutPanel.TabIndex = 0;
            // 
            // insured_grid
            // 
            this.insured_grid.AllowUserToAddRows = false;
            this.insured_grid.AllowUserToDeleteRows = false;
            this.insured_grid.AutoGenerateColumns = false;
            this.insured_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.insured_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insured_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.main_tableLayoutPanel.SetColumnSpan(this.insured_grid, 2);
            this.insured_grid.DataSource = this.tInsuredBindingSource;
            this.insured_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insured_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.insured_grid.Location = new System.Drawing.Point(-14, 77);
            this.insured_grid.MultiSelect = false;
            this.insured_grid.Name = "insured_grid";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.insured_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.insured_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.insured_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.insured_grid.ShowCellErrors = false;
            this.insured_grid.ShowCellToolTips = false;
            this.insured_grid.Size = new System.Drawing.Size(1065, 273);
            this.insured_grid.TabIndex = 9;
            this.insured_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.insured_grid_DataBindingComplete);
            // 
            // i_sequence_column
            // 
            this.i_sequence_column.DataPropertyName = "sequence";
            this.i_sequence_column.HeaderText = "شناسه";
            this.i_sequence_column.Name = "i_sequence_column";
            this.i_sequence_column.ReadOnly = true;
            this.i_sequence_column.Width = 70;
            // 
            // i_id_column
            // 
            this.i_id_column.DataPropertyName = "id";
            this.i_id_column.HeaderText = "شماره شناسایی دفترچه";
            this.i_id_column.Name = "i_id_column";
            this.i_id_column.ReadOnly = true;
            this.i_id_column.Width = 158;
            // 
            // i_name_column
            // 
            this.i_name_column.DataPropertyName = "name";
            this.i_name_column.HeaderText = "نام";
            this.i_name_column.Name = "i_name_column";
            this.i_name_column.ReadOnly = true;
            this.i_name_column.Width = 51;
            // 
            // i_family_name_column
            // 
            this.i_family_name_column.DataPropertyName = "family_name";
            this.i_family_name_column.HeaderText = "نام خانوادگی";
            this.i_family_name_column.Name = "i_family_name_column";
            this.i_family_name_column.ReadOnly = true;
            this.i_family_name_column.Width = 104;
            // 
            // i_national_code_column
            // 
            this.i_national_code_column.DataPropertyName = "national_code";
            this.i_national_code_column.HeaderText = "شماره ملی";
            this.i_national_code_column.Name = "i_national_code_column";
            this.i_national_code_column.ReadOnly = true;
            this.i_national_code_column.Width = 93;
            // 
            // i_ins_name_column
            // 
            this.i_ins_name_column.DataPropertyName = "ins_name";
            this.i_ins_name_column.HeaderText = "سازمان بیمه گر";
            this.i_ins_name_column.Name = "i_ins_name_column";
            this.i_ins_name_column.ReadOnly = true;
            this.i_ins_name_column.Width = 119;
            // 
            // i_sector_name_column
            // 
            this.i_sector_name_column.DataPropertyName = "sector_name";
            this.i_sector_name_column.HeaderText = "صندوق بیمه گر";
            this.i_sector_name_column.Name = "i_sector_name_column";
            this.i_sector_name_column.ReadOnly = true;
            this.i_sector_name_column.Width = 120;
            // 
            // i_exp_complete_column
            // 
            this.i_exp_complete_column.DataPropertyName = "exp_complete";
            this.i_exp_complete_column.HeaderText = "تاریخ اعتبار دفترچه";
            this.i_exp_complete_column.Name = "i_exp_complete_column";
            this.i_exp_complete_column.ReadOnly = true;
            this.i_exp_complete_column.Width = 137;
            // 
            // i_expiration_day_column
            // 
            this.i_expiration_day_column.DataPropertyName = "expiration_day";
            this.i_expiration_day_column.HeaderText = "expiration_day";
            this.i_expiration_day_column.Name = "i_expiration_day_column";
            this.i_expiration_day_column.ReadOnly = true;
            this.i_expiration_day_column.Visible = false;
            this.i_expiration_day_column.Width = 225;
            // 
            // i_expiration_month_column
            // 
            this.i_expiration_month_column.DataPropertyName = "expiration_month";
            this.i_expiration_month_column.HeaderText = "expiration_month";
            this.i_expiration_month_column.Name = "i_expiration_month_column";
            this.i_expiration_month_column.ReadOnly = true;
            this.i_expiration_month_column.Visible = false;
            this.i_expiration_month_column.Width = 257;
            // 
            // i_expiration_year_column
            // 
            this.i_expiration_year_column.DataPropertyName = "expiration_year";
            this.i_expiration_year_column.HeaderText = "expiration_year";
            this.i_expiration_year_column.Name = "i_expiration_year_column";
            this.i_expiration_year_column.ReadOnly = true;
            this.i_expiration_year_column.Visible = false;
            this.i_expiration_year_column.Width = 234;
            // 
            // i_insurance_sector_column
            // 
            this.i_insurance_sector_column.DataPropertyName = "insurance_sector";
            this.i_insurance_sector_column.HeaderText = "insurance_sector";
            this.i_insurance_sector_column.Name = "i_insurance_sector_column";
            this.i_insurance_sector_column.ReadOnly = true;
            this.i_insurance_sector_column.Visible = false;
            this.i_insurance_sector_column.Width = 256;
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
            // ins_title_label
            // 
            this.ins_title_label.AutoSize = true;
            this.ins_title_label.BackColor = System.Drawing.SystemColors.Control;
            this.ins_title_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ins_title_label.Location = new System.Drawing.Point(-11, 20);
            this.ins_title_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ins_title_label.Name = "ins_title_label";
            this.ins_title_label.Size = new System.Drawing.Size(918, 27);
            this.ins_title_label.TabIndex = 7;
            this.ins_title_label.Tag = "0";
            this.ins_title_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sec_title_label
            // 
            this.sec_title_label.AutoSize = true;
            this.sec_title_label.BackColor = System.Drawing.SystemColors.Control;
            this.sec_title_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sec_title_label.ForeColor = System.Drawing.Color.Black;
            this.sec_title_label.Location = new System.Drawing.Point(-11, 47);
            this.sec_title_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.sec_title_label.Name = "sec_title_label";
            this.sec_title_label.Size = new System.Drawing.Size(918, 27);
            this.sec_title_label.TabIndex = 8;
            this.sec_title_label.Tag = "1";
            this.sec_title_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // insurance_label
            // 
            this.insurance_label.AutoSize = true;
            this.insurance_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.insurance_label.Location = new System.Drawing.Point(919, 20);
            this.insurance_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.insurance_label.Name = "insurance_label";
            this.insurance_label.Size = new System.Drawing.Size(129, 27);
            this.insurance_label.TabIndex = 1;
            this.insurance_label.Tag = "0";
            this.insurance_label.Text = "سازمان بیمه گر:";
            this.insurance_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seqeunce_label
            // 
            this.seqeunce_label.AutoSize = true;
            this.seqeunce_label.BackColor = System.Drawing.Color.Transparent;
            this.seqeunce_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seqeunce_label.ForeColor = System.Drawing.Color.Black;
            this.seqeunce_label.Location = new System.Drawing.Point(919, 47);
            this.seqeunce_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.seqeunce_label.Name = "seqeunce_label";
            this.seqeunce_label.Size = new System.Drawing.Size(129, 27);
            this.seqeunce_label.TabIndex = 6;
            this.seqeunce_label.Tag = "1";
            this.seqeunce_label.Text = "صندوق بیمه گر فعال :";
            this.seqeunce_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tInsuredTableAdapter
            // 
            this.tInsuredTableAdapter.ClearBeforeFill = true;
            // 
            // SearchedInsuredForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 500);
            this.ClientSize = new System.Drawing.Size(1071, 363);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "SearchedInsuredForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "اطلاعات یکسان بیمه شده ها در صندوق های مختلف";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insured_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tInsuredBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Label seqeunce_label;
        private System.Windows.Forms.Label insurance_label;
        private System.Windows.Forms.Label ins_title_label;
        private System.Windows.Forms.Label sec_title_label;
        private System.Windows.Forms.BindingSource tInsuredBindingSource;
        private PIPDataSet pIPDataSet;
        private PIPDataSetTableAdapters.TInsuredTableAdapter tInsuredTableAdapter;
        private System.Windows.Forms.DataGridView insured_grid;
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