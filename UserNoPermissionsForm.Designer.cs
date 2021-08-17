namespace PadraInsurancePrescription
{
    partial class UserNoPermissionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pIPDataSet = new PadraInsurancePrescription.PIPDataSet();
            this.tUserPermissionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tUserPermissionsTableAdapter = new PadraInsurancePrescription.PIPDataSetTableAdapters.TUserPermissionsTableAdapter();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.permission_grid = new System.Windows.Forms.DataGridView();
            this.center_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.center_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_names_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medical_id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ins_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sector_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month_name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_title_label = new System.Windows.Forms.Label();
            this.sec_title_label = new System.Windows.Forms.Label();
            this.user_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tUserPermissionsBindingSource)).BeginInit();
            this.main_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.permission_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // pIPDataSet
            // 
            this.pIPDataSet.CaseSensitive = true;
            this.pIPDataSet.DataSetName = "PIPDataSet";
            this.pIPDataSet.EnforceConstraints = false;
            this.pIPDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tUserPermissionsBindingSource
            // 
            this.tUserPermissionsBindingSource.DataMember = "TUserPermissions";
            this.tUserPermissionsBindingSource.DataSource = this.pIPDataSet;
            // 
            // tUserPermissionsTableAdapter
            // 
            this.tUserPermissionsTableAdapter.ClearBeforeFill = true;
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main_tableLayoutPanel.ColumnCount = 4;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Controls.Add(this.label1, 1, 0);
            this.main_tableLayoutPanel.Controls.Add(this.permission_grid, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.user_title_label, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.sec_title_label, 2, 2);
            this.main_tableLayoutPanel.Controls.Add(this.user_label, 1, 1);
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, -10);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(6);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 5;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(770, 341);
            this.main_tableLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(50, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(694, 60);
            this.label1.TabIndex = 10;
            this.label1.Tag = "0";
            this.label1.Text = "مشخصات مراکز، بخش هاو پزشکانی که برای کاربر فعال قابل دسترس نمی باشند.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // permission_grid
            // 
            this.permission_grid.AllowUserToAddRows = false;
            this.permission_grid.AllowUserToDeleteRows = false;
            this.permission_grid.AutoGenerateColumns = false;
            this.permission_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.permission_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.permission_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.center_id_column,
            this.center_name_column,
            this.part_name_column,
            this.doctor_names_column,
            this.medical_id_column,
            this.ins_name_column,
            this.sector_name_column,
            this.year_column,
            this.month_name_column});
            this.main_tableLayoutPanel.SetColumnSpan(this.permission_grid, 2);
            this.permission_grid.DataSource = this.tUserPermissionsBindingSource;
            this.permission_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permission_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.permission_grid.Location = new System.Drawing.Point(47, 117);
            this.permission_grid.MultiSelect = false;
            this.permission_grid.Name = "permission_grid";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.permission_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.permission_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.permission_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.permission_grid.ShowCellErrors = false;
            this.permission_grid.ShowCellToolTips = false;
            this.permission_grid.Size = new System.Drawing.Size(700, 200);
            this.permission_grid.TabIndex = 9;
            this.permission_grid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.permission_grid_DataBindingComplete);
            // 
            // center_id_column
            // 
            this.center_id_column.DataPropertyName = "center_id";
            this.center_id_column.HeaderText = "شناسه مرکز";
            this.center_id_column.Name = "center_id_column";
            this.center_id_column.ReadOnly = true;
            this.center_id_column.Width = 102;
            // 
            // center_name_column
            // 
            this.center_name_column.DataPropertyName = "center_name";
            this.center_name_column.HeaderText = "نام مرکز";
            this.center_name_column.Name = "center_name_column";
            this.center_name_column.Width = 83;
            // 
            // part_name_column
            // 
            this.part_name_column.DataPropertyName = "part_name";
            this.part_name_column.HeaderText = "نام بخش";
            this.part_name_column.Name = "part_name_column";
            this.part_name_column.Width = 83;
            // 
            // doctor_names_column
            // 
            this.doctor_names_column.DataPropertyName = "doctor_names";
            this.doctor_names_column.HeaderText = "نام و نام خانوادگی پزشک";
            this.doctor_names_column.Name = "doctor_names_column";
            this.doctor_names_column.ReadOnly = true;
            this.doctor_names_column.Width = 172;
            // 
            // medical_id_column
            // 
            this.medical_id_column.DataPropertyName = "medical_id";
            this.medical_id_column.HeaderText = "شماره نظام پزشکی";
            this.medical_id_column.Name = "medical_id_column";
            this.medical_id_column.Width = 137;
            // 
            // ins_name_column
            // 
            this.ins_name_column.DataPropertyName = "ins_name";
            this.ins_name_column.HeaderText = "سازمان بیمه گر";
            this.ins_name_column.Name = "ins_name_column";
            this.ins_name_column.Width = 119;
            // 
            // sector_name_column
            // 
            this.sector_name_column.DataPropertyName = "sector_name";
            this.sector_name_column.HeaderText = "صندوق بیمه گر";
            this.sector_name_column.Name = "sector_name_column";
            this.sector_name_column.Width = 120;
            // 
            // year_column
            // 
            this.year_column.DataPropertyName = "year";
            this.year_column.HeaderText = "سال عملکرد";
            this.year_column.Name = "year_column";
            this.year_column.ReadOnly = true;
            this.year_column.Width = 102;
            // 
            // month_name_column
            // 
            this.month_name_column.DataPropertyName = "month_name";
            this.month_name_column.HeaderText = "ماه عملکرد";
            this.month_name_column.Name = "month_name_column";
            this.month_name_column.Width = 96;
            // 
            // user_title_label
            // 
            this.user_title_label.AutoSize = true;
            this.user_title_label.BackColor = System.Drawing.SystemColors.Control;
            this.user_title_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_title_label.Location = new System.Drawing.Point(50, 60);
            this.user_title_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.user_title_label.Name = "user_title_label";
            this.user_title_label.Size = new System.Drawing.Size(488, 27);
            this.user_title_label.TabIndex = 7;
            this.user_title_label.Tag = "0";
            this.user_title_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sec_title_label
            // 
            this.sec_title_label.AutoSize = true;
            this.sec_title_label.BackColor = System.Drawing.SystemColors.Control;
            this.sec_title_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sec_title_label.ForeColor = System.Drawing.Color.Black;
            this.sec_title_label.Location = new System.Drawing.Point(50, 87);
            this.sec_title_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.sec_title_label.Name = "sec_title_label";
            this.sec_title_label.Size = new System.Drawing.Size(488, 27);
            this.sec_title_label.TabIndex = 8;
            this.sec_title_label.Tag = "1";
            this.sec_title_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_label.Location = new System.Drawing.Point(550, 60);
            this.user_label.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(194, 27);
            this.user_label.TabIndex = 1;
            this.user_label.Tag = "0";
            this.user_label.Text = "کاربر فعال :";
            this.user_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserNoPermissionsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(500, 500);
            this.ClientSize = new System.Drawing.Size(787, 320);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Roya", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "UserNoPermissionsForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "دسترسی های غیر مجاز برای کاربر";
            ((System.ComponentModel.ISupportInitialize)(this.pIPDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tUserPermissionsBindingSource)).EndInit();
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.permission_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PIPDataSet pIPDataSet;
        private System.Windows.Forms.BindingSource tUserPermissionsBindingSource;
        private PIPDataSetTableAdapters.TUserPermissionsTableAdapter tUserPermissionsTableAdapter;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView permission_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn center_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn center_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_names_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn medical_id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn ins_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn sector_name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn year_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn month_name_column;
        private System.Windows.Forms.Label user_title_label;
        private System.Windows.Forms.Label sec_title_label;
        private System.Windows.Forms.Label user_label;

    }
}