using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PadraInsurancePrescription
{
    public partial class PGSDateControl : UserControl
    {
        char enter_char=(char)Keys.Enter;
        string sel_exp_day, sel_exp_month, sel_exp_year;
        int len_2 = 2, len_4 = 4;
        string temp_str;
        int temp_int;

        public PGSDateControl()
        {

            InitializeComponent();
        }

        public bool yearEvaluation(int input_year, out string output_year)
        {
            if (input_year >= 90 && input_year <= 99)
            {
                output_year = "13" + input_year.ToString();
                return true;
            }
            else if (input_year >= 0 && input_year <= 9)
            {
                output_year = "140" + input_year.ToString();
                return true;
            }
            else if (input_year >= 10 && input_year <= 89)
            {
                output_year = "14" + input_year.ToString();
                return true;
            }
            else if ((input_year >= 390 && input_year <= 399) || (input_year >= 400 && input_year <= 499))
            {
                output_year = "1" + input_year.ToString();
                return true;
            }
            else
            {
                output_year = "";
                return false;
            }
        }

        private void p_exp_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == enter_char)
            {
                //p_info_submit_btn.Select();
            }
        }
        private void p_exp_day_msk_TextChanged(object sender, EventArgs e)
        {
            if (p_exp_day_msk.Text.Length == len_2)
            {
                if (Regex.IsMatch(sel_exp_day = p_exp_day_msk.Text, PLConstants.reg_exact_day_of_date))
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        private void p_exp_day_msk_Leave(object sender, EventArgs e)
        {
            sel_exp_day = p_exp_day_msk.Text;
        }
        private void p_exp_month_msk_TextChanged(object sender, EventArgs e)
        {
            if (p_exp_month_msk.Text.Length == len_2)
            {
                if (Regex.IsMatch(sel_exp_month = p_exp_month_msk.Text, PLConstants.reg_exact_month_of_date))
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        private void p_exp_month_msk_Leave(object sender, EventArgs e)
        {
            sel_exp_month = p_exp_month_msk.Text;
        }
        private void p_exp_year_msk_Leave(object sender, EventArgs e)
        {
            temp_str = p_exp_year_msk.Text.Trim();
            if (int.TryParse(temp_str, out temp_int))
            {
                if (yearEvaluation(temp_int, out sel_exp_year))
                {
                    p_exp_year_msk.Text = sel_exp_year;
                }
            }
        }
        private void p_exp_flow_Leave(object sender, EventArgs e)
        {
            //if (Regex.IsMatch(sel_exp_day, PLConstants.reg_exact_day_of_date) && Regex.IsMatch(sel_exp_month, PLConstants.reg_exact_month_of_date) && Regex.IsMatch(sel_exp_year, PLConstants.reg_exact_year_of_date))
            //{
            //    if (p_arr_has_error[p_ind_exp_date])
            //    {
            //        p_arr_has_error[p_ind_exp_date] = false;
            //        p_i_err_cou--;
            //        p_exp_flow.BackColor = Color.Transparent;
            //        EP_p_exp.Clear();
            //    }
            //}
            //else
            //{
            //    if (!p_arr_has_error[p_ind_exp_date])
            //    {
            //        p_arr_has_error[p_ind_exp_date] = true;
            //        p_i_err_cou++;
            //        p_exp_flow.BackColor = Color.Red;
            //        EP_p_exp.SetError(p_exp_year_msk, PLConstants.error_date);
            //    }
            //}
        }


    }
}
