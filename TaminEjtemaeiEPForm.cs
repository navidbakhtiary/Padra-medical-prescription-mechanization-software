using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class TaminEjtemaeiEPForm : Form
    {
        PGSDialog pgs_dialog;
        string t_str;
        TextBox t_box;
        string t_int_str;
        bool is_correct;

        public int aadi_vis_count, aadi_ser_count, aadi_tot_count, aadi_vis_ins, aadi_ser_ins, aadi_tot_ins;
        public int khas_vis_count, khas_ser_count, khas_tot_count, khas_vis_ins, khas_ser_ins, khas_tot_ins;
        public int total_count, total_ins;

        public TaminEjtemaeiEPForm()//checked
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.sub_data);
            pgs_dialog = new PGSDialog(this);
        }

        public bool showForm()
        {
            this.ShowDialog();
            return is_correct;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            aadi_vis_count = int.Parse(aadi_vis_count_txt.Text.Replace(",", ""));
            aadi_ser_count = int.Parse(aadi_ser_count_txt.Text.Replace(",", ""));
            aadi_tot_count = int.Parse(aadi_tot_count_txt.Text.Replace(",", ""));
            aadi_vis_ins = int.Parse(aadi_vis_ins_txt.Text.Replace(",", ""));
            aadi_ser_ins = int.Parse(aadi_ser_ins_txt.Text.Replace(",", ""));
            aadi_tot_ins = int.Parse(aadi_tot_ins_txt.Text.Replace(",", ""));
            khas_vis_count = int.Parse(khas_vis_count_txt.Text.Replace(",", ""));
            khas_ser_count = int.Parse(khas_ser_count_txt.Text.Replace(",", ""));
            khas_tot_count = int.Parse(khas_tot_count_txt.Text.Replace(",", ""));
            khas_vis_ins = int.Parse(khas_vis_ins_txt.Text.Replace(",", ""));
            khas_ser_ins = int.Parse(khas_ser_ins_txt.Text.Replace(",", ""));
            khas_tot_ins = int.Parse(khas_tot_ins_txt.Text.Replace(",", ""));
            total_count = int.Parse(total_count_txt.Text.Replace(",", ""));
            total_ins = int.Parse(total_ins_txt.Text.Replace(",", ""));
            bool has_error = false;
            bool is_aadi_empty = true;
            is_correct=false;
            if ((aadi_vis_count > 0 && aadi_vis_ins > 0) || (aadi_ser_count > 0 && aadi_ser_ins > 0))
            {
                if (aadi_tot_count > 0 && aadi_tot_ins > 0)
                {
                    if (aadi_tot_count == aadi_vis_count + aadi_ser_count && aadi_tot_ins == aadi_vis_ins + aadi_ser_ins)
                    {
                        is_aadi_empty = false;
                    }
                    else
                    {
                        has_error = true;
                    }
                }
                else
                {
                    has_error = true;
                }
            }
            bool is_khas_empty = true;
            if ((khas_vis_count > 0 && khas_vis_ins > 0) || (khas_ser_count > 0 && khas_ser_ins > 0))
            {
                if (khas_tot_count > 0 && khas_tot_ins > 0)
                {
                    if (khas_tot_count == khas_vis_count + khas_ser_count && khas_tot_ins == khas_vis_ins + khas_ser_ins)
                    {
                        is_khas_empty = false;
                    }
                    else
                    {
                        has_error = true;
                    }
                }
                else
                {
                    has_error = true;
                }
            }
            if (!(is_aadi_empty && is_khas_empty))
            {
                if (total_count == aadi_vis_count + aadi_ser_count + khas_vis_count + khas_ser_count &&
                    total_ins == aadi_vis_ins + aadi_ser_ins + khas_vis_ins + khas_ser_ins)
                {
                    is_correct = true;
                }
                else
                {
                    has_error = true;
                }
            }
            else if(total_count>0 && total_ins>0)
            {
                is_correct = true;
            }
            else
            {
                has_error = true;
            }

            if (!has_error)
            {
                this.Close();
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_tamin_ep_form_invalid_numbers);
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)//checked
        {
            is_correct = false;
            this.Close();
        }

        private void number_textbox_Enter(object sender, EventArgs e)
        {
            t_box = (TextBox)sender;
            t_str = t_box.Text;
            t_int_str = t_str.Replace(",","");
            t_box.Select();
            t_box.SelectionStart = t_box.Text.Length;
            t_box.SelectionLength = 0;
        }

        private void number_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = true;
                t_int_str = t_int_str.Remove(t_int_str.Length - 1);
                if (t_int_str == "") { t_int_str = "0"; }
                t_str = t_int_str;
                t_box.Text = (int.Parse(t_int_str)).ToString("N0");
                t_box.SelectionStart = t_box.Text.Length;
                t_box.SelectionLength = 0;
            }
            else if (e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = false;
            }
            else if (t_box.Text.Length < t_box.MaxLength)
            {
                e.Handled = true;
                if (Char.IsDigit(e.KeyChar))
                {
                    t_int_str = (t_int_str == "0") ? e.KeyChar.ToString() : t_int_str + e.KeyChar;
                    t_str = t_int_str;
                    t_box.Text = (int.Parse(t_int_str)).ToString("N0");
                }
            }
        }
        private void aadi_count_txt_Leave(object sender, EventArgs e)
        {
            aadi_tot_count_txt.Text =
                (int.Parse(aadi_vis_count_txt.Text.Replace(",", "")) +
                int.Parse(aadi_ser_count_txt.Text.Replace(",", ""))).ToString("N0");
        }
        private void aadi_ins_txt_Leave(object sender, EventArgs e)
        {
            aadi_tot_ins_txt.Text =
                (int.Parse(aadi_vis_ins_txt.Text.Replace(",", "")) +
                int.Parse(aadi_ser_ins_txt.Text.Replace(",", ""))).ToString("N0");
        }
        private void khas_count_txt_Leave(object sender, EventArgs e)
        {
            khas_tot_count_txt.Text =
                (int.Parse(khas_vis_count_txt.Text.Replace(",", "")) +
                int.Parse(khas_ser_count_txt.Text.Replace(",", ""))).ToString("N0");
        }
        private void khas_ins_txt_Leave(object sender, EventArgs e)
        {
            khas_tot_ins_txt.Text =
                (int.Parse(khas_vis_ins_txt.Text.Replace(",", "")) +
                int.Parse(khas_ser_ins_txt.Text.Replace(",", ""))).ToString("N0");
        }
        private void count_txt_Leave(object sender, EventArgs e)
        {
            total_count_txt.Text =
                (int.Parse(aadi_tot_count_txt.Text.Replace(",", "")) +
                int.Parse(khas_tot_count_txt.Text.Replace(",", ""))).ToString("N0");
        }
        private void ins_txt_Leave(object sender, EventArgs e)
        {
            total_ins_txt.Text =
                (int.Parse(aadi_tot_ins_txt.Text.Replace(",", "")) +
                int.Parse(khas_tot_ins_txt.Text.Replace(",", ""))).ToString("N0");
        }

        private void finals_txt_Leave(object sender, EventArgs e)
        {
            t_box = (TextBox)sender;
            t_str = t_box.Text;
            t_int_str = t_str.Replace(",", "");
            t_box.Text = int.Parse(t_int_str).ToString("N0");
        }
        

    }
}
