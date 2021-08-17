namespace PadraInsurancePrescription
{
    partial class PasswordForm
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
            this.check_button = new System.Windows.Forms.Button();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.pass_label = new System.Windows.Forms.Label();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.error_label = new System.Windows.Forms.Label();
            this.main_tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // check_button
            // 
            this.main_tableLayoutPanel.SetColumnSpan(this.check_button, 2);
            this.check_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.check_button.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.check_button.Location = new System.Drawing.Point(122, 80);
            this.check_button.Margin = new System.Windows.Forms.Padding(100, 7, 100, 7);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(122, 53);
            this.check_button.TabIndex = 2;
            this.check_button.Text = "تایید";
            this.check_button.UseVisualStyleBackColor = true;
            // 
            // pass_text
            // 
            this.pass_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_text.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pass_text.Location = new System.Drawing.Point(29, 27);
            this.pass_text.Margin = new System.Windows.Forms.Padding(7);
            this.pass_text.MaxLength = 20;
            this.pass_text.Name = "pass_text";
            this.pass_text.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pass_text.Size = new System.Drawing.Size(216, 39);
            this.pass_text.TabIndex = 1;
            this.pass_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass_text.UseSystemPasswordChar = true;
            this.pass_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.general_KeyPress);
            // 
            // pass_label
            // 
            this.pass_label.AutoSize = true;
            this.pass_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_label.Location = new System.Drawing.Point(255, 20);
            this.pass_label.Name = "pass_label";
            this.pass_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pass_label.Size = new System.Drawing.Size(86, 53);
            this.pass_label.TabIndex = 4;
            this.pass_label.Text = "کلمۀ عبور :";
            this.pass_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // main_tableLayoutPanel
            // 
            this.main_tableLayoutPanel.ColumnCount = 4;
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.main_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.main_tableLayoutPanel.Controls.Add(this.error_label, 1, 3);
            this.main_tableLayoutPanel.Controls.Add(this.pass_label, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.check_button, 1, 2);
            this.main_tableLayoutPanel.Controls.Add(this.pass_text, 2, 1);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 4;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(364, 184);
            this.main_tableLayoutPanel.TabIndex = 9;
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.error_label, 2);
            this.error_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(25, 140);
            this.error_label.Name = "error_label";
            this.error_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.error_label.Size = new System.Drawing.Size(316, 44);
            this.error_label.TabIndex = 5;
            this.error_label.Text = "رمز وارد شده اشتباه است !";
            this.error_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error_label.Visible = false;
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(364, 184);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "PasswordForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تایید کلمه عبور";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Label error_label;
    }
}