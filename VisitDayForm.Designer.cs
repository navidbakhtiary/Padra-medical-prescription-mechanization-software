namespace PadraInsurancePrescription
{
    partial class VisitDayForm
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
            this.day_cbx = new System.Windows.Forms.ComboBox();
            this.day_label = new System.Windows.Forms.Label();
            this.set_button = new System.Windows.Forms.Button();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.main_tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // day_cbx
            // 
            this.day_cbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.day_cbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.day_cbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.day_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day_cbx.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.day_cbx.FormattingEnabled = true;
            this.day_cbx.Location = new System.Drawing.Point(115, 18);
            this.day_cbx.Name = "day_cbx";
            this.day_cbx.Size = new System.Drawing.Size(91, 35);
            this.day_cbx.TabIndex = 0;
            this.day_cbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.general_KeyPress);
            // 
            // day_label
            // 
            this.day_label.AutoSize = true;
            this.day_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.day_label.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.day_label.ForeColor = System.Drawing.Color.White;
            this.day_label.Location = new System.Drawing.Point(212, 15);
            this.day_label.Name = "day_label";
            this.day_label.Size = new System.Drawing.Size(214, 41);
            this.day_label.TabIndex = 47;
            this.day_label.Text = "روز ویزیت(تاریخ انجام خدمت):";
            this.day_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // set_button
            // 
            this.set_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.set_button.Font = new System.Drawing.Font("B Roya", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.set_button.Location = new System.Drawing.Point(20, 18);
            this.set_button.Name = "set_button";
            this.set_button.Size = new System.Drawing.Size(89, 35);
            this.set_button.TabIndex = 1;
            this.set_button.Text = "مقداردهی";
            this.set_button.UseVisualStyleBackColor = true;
            this.set_button.Click += new System.EventHandler(this.set_button_Click);
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 5;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.main_tableLayoutPanel.Controls.Add(this.set_button, 3, 1);
            this.main_tableLayoutPanel.Controls.Add(this.day_cbx, 2, 1);
            this.main_tableLayoutPanel.Controls.Add(this.day_label, 1, 1);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 3;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(436, 68);
            this.main_tableLayoutPanel.TabIndex = 48;
            // 
            // VisitDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(436, 68);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisitDayForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعیین روز انجام خدمت";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisitDayForm_FormClosing);
            this.Load += new System.EventHandler(this.VisitDayForm_Load);
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox day_cbx;
        private System.Windows.Forms.Label day_label;
        private System.Windows.Forms.Button set_button;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
    }
}