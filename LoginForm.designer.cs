namespace PadraInsurancePrescription
{
    partial class LoginForm
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
            this.user_text = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.user_label = new System.Windows.Forms.Label();
            this.pass_label = new System.Windows.Forms.Label();
            this.main_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.center_label = new System.Windows.Forms.Label();
            this.error_label = new System.Windows.Forms.Label();
            this.main_tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // user_text
            // 
            this.user_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_text.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.user_text.Location = new System.Drawing.Point(26, 57);
            this.user_text.Margin = new System.Windows.Forms.Padding(7);
            this.user_text.MaxLength = 20;
            this.user_text.Name = "user_text";
            this.user_text.Size = new System.Drawing.Size(219, 39);
            this.user_text.TabIndex = 0;
            this.user_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.user_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.general_KeyPress);
            // 
            // login_button
            // 
            this.main_tableLayoutPanel.SetColumnSpan(this.login_button, 2);
            this.login_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_button.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.login_button.Location = new System.Drawing.Point(119, 163);
            this.login_button.Margin = new System.Windows.Forms.Padding(100, 7, 100, 7);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(125, 53);
            this.login_button.TabIndex = 2;
            this.login_button.Text = "ورود";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // pass_text
            // 
            this.pass_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_text.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pass_text.Location = new System.Drawing.Point(26, 110);
            this.pass_text.Margin = new System.Windows.Forms.Padding(7);
            this.pass_text.MaxLength = 20;
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(219, 39);
            this.pass_text.TabIndex = 1;
            this.pass_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass_text.UseSystemPasswordChar = true;
            this.pass_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.general_KeyPress);
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_label.Location = new System.Drawing.Point(255, 50);
            this.user_label.Name = "user_label";
            this.user_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.user_label.Size = new System.Drawing.Size(86, 53);
            this.user_label.TabIndex = 3;
            this.user_label.Text = "نام کاربری :";
            this.user_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pass_label
            // 
            this.pass_label.AutoSize = true;
            this.pass_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_label.Location = new System.Drawing.Point(255, 103);
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
            this.main_tableLayoutPanel.Controls.Add(this.label1, 2, 8);
            this.main_tableLayoutPanel.Controls.Add(this.logoPictureBox, 1, 8);
            this.main_tableLayoutPanel.Controls.Add(this.center_label, 1, 1);
            this.main_tableLayoutPanel.Controls.Add(this.user_label, 1, 4);
            this.main_tableLayoutPanel.Controls.Add(this.error_label, 1, 7);
            this.main_tableLayoutPanel.Controls.Add(this.pass_label, 1, 5);
            this.main_tableLayoutPanel.Controls.Add(this.login_button, 1, 6);
            this.main_tableLayoutPanel.Controls.Add(this.user_text, 2, 4);
            this.main_tableLayoutPanel.Controls.Add(this.pass_text, 2, 5);
            this.main_tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.main_tableLayoutPanel.Name = "main_tableLayoutPanel";
            this.main_tableLayoutPanel.RowCount = 10;
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.main_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.main_tableLayoutPanel.Size = new System.Drawing.Size(364, 320);
            this.main_tableLayoutPanel.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MidnightBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 253);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(227, 56);
            this.label1.TabIndex = 14;
            this.label1.Text = "نرم افزار ثبت و مکانیزاسیون اسناد پزشکی پادرا";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::PadraInsurancePrescription.Properties.Resources.padra_small_logo;
            this.logoPictureBox.Location = new System.Drawing.Point(255, 256);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(86, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 13;
            this.logoPictureBox.TabStop = false;
            // 
            // center_label
            // 
            this.center_label.AutoSize = true;
            this.center_label.BackColor = System.Drawing.Color.MidnightBlue;
            this.main_tableLayoutPanel.SetColumnSpan(this.center_label, 2);
            this.center_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.center_label.ForeColor = System.Drawing.Color.White;
            this.center_label.Location = new System.Drawing.Point(22, 20);
            this.center_label.Name = "center_label";
            this.center_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.center_label.Size = new System.Drawing.Size(319, 30);
            this.center_label.TabIndex = 6;
            this.center_label.Text = "شرکت پادرا گستر سنندج";
            this.center_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.main_tableLayoutPanel.SetColumnSpan(this.error_label, 2);
            this.error_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(22, 223);
            this.error_label.Name = "error_label";
            this.error_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.error_label.Size = new System.Drawing.Size(319, 30);
            this.error_label.TabIndex = 5;
            this.error_label.Text = "نام کاربری یا رمز عبور اشتباه است !";
            this.error_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error_label.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(364, 320);
            this.Controls.Add(this.main_tableLayoutPanel);
            this.Font = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اجازه ورود به حساب کاربری";
            this.main_tableLayoutPanel.ResumeLayout(false);
            this.main_tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox user_text;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label pass_label;
        private System.Windows.Forms.TableLayoutPanel main_tableLayoutPanel;
        private System.Windows.Forms.Label error_label;
        private System.Windows.Forms.Label center_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox logoPictureBox;
    }
}