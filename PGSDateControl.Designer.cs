namespace PadraInsurancePrescription
{
    partial class PGSDateControl
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
            this.p_exp_flow = new System.Windows.Forms.FlowLayoutPanel();
            this.p_exp_day_msk = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.p_exp_month_msk = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.p_exp_year_msk = new System.Windows.Forms.MaskedTextBox();
            this.p_exp_flow.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_exp_flow
            // 
            this.p_exp_flow.Controls.Add(this.p_exp_day_msk);
            this.p_exp_flow.Controls.Add(this.label9);
            this.p_exp_flow.Controls.Add(this.p_exp_month_msk);
            this.p_exp_flow.Controls.Add(this.label10);
            this.p_exp_flow.Controls.Add(this.p_exp_year_msk);
            this.p_exp_flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p_exp_flow.Location = new System.Drawing.Point(0, 0);
            this.p_exp_flow.Name = "p_exp_flow";
            this.p_exp_flow.Size = new System.Drawing.Size(198, 38);
            this.p_exp_flow.TabIndex = 63;
            this.p_exp_flow.WrapContents = false;
            // 
            // p_exp_day_msk
            // 
            this.p_exp_day_msk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.p_exp_day_msk.BeepOnError = true;
            this.p_exp_day_msk.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.p_exp_day_msk.Location = new System.Drawing.Point(160, 3);
            this.p_exp_day_msk.Mask = "99";
            this.p_exp_day_msk.Name = "p_exp_day_msk";
            this.p_exp_day_msk.ResetOnPrompt = false;
            this.p_exp_day_msk.ResetOnSpace = false;
            this.p_exp_day_msk.Size = new System.Drawing.Size(35, 22);
            this.p_exp_day_msk.TabIndex = 7;
            this.p_exp_day_msk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p_exp_day_msk.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(142, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 28);
            this.label9.TabIndex = 63;
            this.label9.Text = "/";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_exp_month_msk
            // 
            this.p_exp_month_msk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.p_exp_month_msk.BeepOnError = true;
            this.p_exp_month_msk.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.p_exp_month_msk.Location = new System.Drawing.Point(101, 3);
            this.p_exp_month_msk.Mask = "99";
            this.p_exp_month_msk.Name = "p_exp_month_msk";
            this.p_exp_month_msk.ResetOnPrompt = false;
            this.p_exp_month_msk.ResetOnSpace = false;
            this.p_exp_month_msk.Size = new System.Drawing.Size(35, 22);
            this.p_exp_month_msk.TabIndex = 8;
            this.p_exp_month_msk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p_exp_month_msk.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(83, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 28);
            this.label10.TabIndex = 65;
            this.label10.Text = "/";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p_exp_year_msk
            // 
            this.p_exp_year_msk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.p_exp_year_msk.BeepOnError = true;
            this.p_exp_year_msk.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.p_exp_year_msk.Location = new System.Drawing.Point(7, 3);
            this.p_exp_year_msk.Mask = "9999";
            this.p_exp_year_msk.Name = "p_exp_year_msk";
            this.p_exp_year_msk.ResetOnPrompt = false;
            this.p_exp_year_msk.ResetOnSpace = false;
            this.p_exp_year_msk.Size = new System.Drawing.Size(70, 22);
            this.p_exp_year_msk.TabIndex = 9;
            this.p_exp_year_msk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.p_exp_year_msk.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // PGSDateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.p_exp_flow);
            this.Name = "PGSDateControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(198, 38);
            this.p_exp_flow.ResumeLayout(false);
            this.p_exp_flow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel p_exp_flow;
        private System.Windows.Forms.MaskedTextBox p_exp_day_msk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox p_exp_month_msk;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox p_exp_year_msk;
    }
}
