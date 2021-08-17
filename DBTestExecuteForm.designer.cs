namespace PadraInsurancePrescription
{
    partial class DBTestExecuteForm
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
            this.select_button = new System.Windows.Forms.Button();
            this.insert_button = new System.Windows.Forms.Button();
            this.test_dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.test_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(63, 25);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(75, 23);
            this.select_button.TabIndex = 0;
            this.select_button.Text = "Get Data";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // insert_button
            // 
            this.insert_button.Location = new System.Drawing.Point(144, 25);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(75, 23);
            this.insert_button.TabIndex = 1;
            this.insert_button.Text = "Add Data";
            this.insert_button.UseVisualStyleBackColor = true;
            this.insert_button.Click += new System.EventHandler(this.insert_button_Click);
            // 
            // test_dataGridView
            // 
            this.test_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.test_dataGridView.Location = new System.Drawing.Point(27, 68);
            this.test_dataGridView.Name = "test_dataGridView";
            this.test_dataGridView.Size = new System.Drawing.Size(232, 150);
            this.test_dataGridView.TabIndex = 2;
            // 
            // DBTestExecuteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.test_dataGridView);
            this.Controls.Add(this.insert_button);
            this.Controls.Add(this.select_button);
            this.MaximizeBox = false;
            this.Name = "DBTestExecuteForm";
            this.Text = "ConnectionTest";
            ((System.ComponentModel.ISupportInitialize)(this.test_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.Button insert_button;
        private System.Windows.Forms.DataGridView test_dataGridView;
    }
}