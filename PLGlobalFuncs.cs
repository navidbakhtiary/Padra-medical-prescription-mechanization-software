using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Resources;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PadraInsurancePrescription
{
    public class PLGlobalFuncs
    {
        //////////////////////////////////////////////////////////////////////// Forms
        public static void adjustWinFormProperties(Form form, PLConstants.enum_form_types form_type)
        {
            TableLayoutPanel table_layout = null;
            TabControl tab_control = null;
            Rectangle working_rect = Screen.PrimaryScreen.WorkingArea;
            Rectangle bounds_rect = Screen.PrimaryScreen.Bounds;
            Control[] controls = form.Controls.Find(PLConstants.str_main_table_layout_name, true);
            int best_height;

            if (controls.Length > 0)
            {
                if (controls[0] is TableLayoutPanel)
                {
                    table_layout = (TableLayoutPanel)controls[0];
                }
            }
            else if ((controls = form.Controls.Find(PLConstants.str_main_tab_control_name, true)).Length > 0)
            {
                if (controls[0] is TabControl)
                {
                    tab_control = (TabControl)controls[0];
                }
            }

            if (form_type == PLConstants.enum_form_types.main)
            {
                form.WindowState = FormWindowState.Maximized;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.FormBorderStyle = FormBorderStyle.Fixed3D;
                form.Bounds = working_rect;
                form.MaximizeBox = true;
            }
            else if (form_type == PLConstants.enum_form_types.data || form_type == PLConstants.enum_form_types.sub_data)
            {
                form.WindowState = FormWindowState.Normal;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.AutoScaleMode = AutoScaleMode.Dpi;
                if (table_layout != null)
                {
                    if (table_layout.Height > (best_height = form.Height)) { best_height = table_layout.Height; }
                    if (best_height > (working_rect.Height - (bounds_rect.Height - working_rect.Height))) { best_height = working_rect.Height - (bounds_rect.Height - working_rect.Height); }
                    form.FormBorderStyle = FormBorderStyle.Sizable;
                    form.Size = new Size(form.Size.Width, best_height);
                    form.FormBorderStyle = FormBorderStyle.Fixed3D;

                }
                else if (tab_control != null)
                {
                    if (tab_control.Height > (best_height = form.Height)) { best_height = tab_control.Height; }
                    if (best_height > (working_rect.Height - (bounds_rect.Height - working_rect.Height))) { best_height = working_rect.Height - (bounds_rect.Height - working_rect.Height); }
                    form.FormBorderStyle = FormBorderStyle.Sizable;
                    form.Size = new Size(form.Size.Width, best_height);
                    if (form.ClientSize.Height < tab_control.Size.Height)
                    {
                        tab_control.Size = new Size(tab_control.Width, form.ClientSize.Height - 1);
                    }
                    form.FormBorderStyle = FormBorderStyle.Fixed3D;
                }
                form.MaximizeBox = false;
            }
            form.Icon = Properties.Resources.padra_icon;
        }
        //////////////////////////////////////////////////////////////////////// Data Checking
        public static bool isCorrect(string input_text, string regular_exp)
        {
            Regex regex = new Regex(regular_exp);
            return regex.IsMatch(input_text);
        }
        public static bool isIranianLetter(char ch)
        {
            if (((ch >= PLConstants.char_let_ran_fir_sta) && (ch <= PLConstants.char_let_ran_fir_end)) ||
               ((ch >= PLConstants.char_let_ran_sec_sta) && (ch <= PLConstants.char_let_ran_sec_end)) ||
               (ch == PLConstants.char_let_che) || (ch == PLConstants.char_let_ge) || (ch == PLConstants.char_let_hedonoghte) || (ch == PLConstants.char_let_ke) ||
               (ch == PLConstants.char_let_pe) || (ch == PLConstants.char_let_ye) || (ch == PLConstants.char_let_zhe) || char.IsWhiteSpace(ch))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //////////////////////////////////////////////////////////////////////// DATE
        public static string getDAYofDate(string date)
        {
            if (date == null || date.Equals(PLConstants.str_empty_dash_date) || date.Equals(PLConstants.str_empty_slash_date) || date.Equals(PLConstants.str_clear))
            {
                return null;
            }
            else
            {
                return date.Substring(8, 2);
            }
        }
        public static string getMONTHofDate(string date)
        {
            if (date == null || date.Equals(PLConstants.str_empty_dash_date) || date.Equals(PLConstants.str_empty_slash_date) || date.Equals(PLConstants.str_clear))
            {
                return null;
            }
            else
            {
                return date.Substring(5, 2);
            }
        }
        public static string getYEARofDate(string date)
        {
            if (date == null || date.Equals(PLConstants.str_empty_dash_date) || date.Equals(PLConstants.str_empty_slash_date) || date.Equals(PLConstants.str_clear))
            {
                return null;
            }
            else
            {
                return date.Substring(0, 4);
            }
        }
        public static string getDaysCountOfMonth(string month_value)
        {
            return PLConstants.days_count_of_monthes[int.Parse(month_value) - 1].ToString();
        }
        //////////////////////////////////////////////////////////////////////// Data Tables for ComboBox
        public static void monthesForComboBox(ComboBox combo_box)
        {
            DataTable table_monthes = new DataTable();
            table_monthes.Columns.Add("id", typeof(string));
            table_monthes.Columns.Add("name", typeof(string));
            table_monthes.Rows.Add("00", "----- ماه -----");
            table_monthes.Rows.Add("01", "فروردین");
            table_monthes.Rows.Add("02", "اردیبهشت");
            table_monthes.Rows.Add("03", "خرداد");
            table_monthes.Rows.Add("04", "تیر");
            table_monthes.Rows.Add("05", "مرداد");
            table_monthes.Rows.Add("06", "شهریور");
            table_monthes.Rows.Add("07", "مهر");
            table_monthes.Rows.Add("08", "آبان");
            table_monthes.Rows.Add("09", "آذر");
            table_monthes.Rows.Add("10", "دی");
            table_monthes.Rows.Add("11", "بهمن");
            table_monthes.Rows.Add("12", "اسفند");
            if (combo_box != null)
            {
                combo_box.DataSource = table_monthes;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void yearsForComboBox(ComboBox combo_box)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(DateTime.Now);
            DataTable table_years = new DataTable();
            table_years.Columns.Add("id", typeof(string));
            table_years.Columns.Add("name", typeof(string));
            table_years.Rows.Add("0000", "----- سال -----");
            for (int i = 1394; i <= year; i++)
            {
                table_years.Rows.Add(i.ToString(), i.ToString());
            }
            if (combo_box != null)
            {
                combo_box.DataSource = table_years;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void daysForComboBox(ComboBox combo_box,int month)
        {
            DataTable table_days = new DataTable();
            table_days.Columns.Add("id", typeof(string));
            table_days.Columns.Add("name", typeof(string));
            table_days.Rows.Add("0", "--- روز ---");
            table_days.Rows.Add("01", "1");
            table_days.Rows.Add("02", "2");
            table_days.Rows.Add("03", "3");
            table_days.Rows.Add("04", "4");
            table_days.Rows.Add("05", "5");
            table_days.Rows.Add("06", "6");
            table_days.Rows.Add("07", "7");
            table_days.Rows.Add("08", "8");
            table_days.Rows.Add("09", "9");
            table_days.Rows.Add("10", "10");
            table_days.Rows.Add("11", "11");
            table_days.Rows.Add("12", "12");
            table_days.Rows.Add("13", "13");
            table_days.Rows.Add("14", "14");
            table_days.Rows.Add("15", "15");
            table_days.Rows.Add("16", "16");
            table_days.Rows.Add("17", "17");
            table_days.Rows.Add("18", "18");
            table_days.Rows.Add("19", "19");
            table_days.Rows.Add("20", "20");
            table_days.Rows.Add("21", "21");
            table_days.Rows.Add("22", "22");
            table_days.Rows.Add("23", "23");
            table_days.Rows.Add("24", "24");
            table_days.Rows.Add("25", "25");
            table_days.Rows.Add("26", "26");
            table_days.Rows.Add("27", "27");
            table_days.Rows.Add("28", "28");
            table_days.Rows.Add("29", "29");
            table_days.Rows.Add("30", "30");
            if (PLConstants.days_count_of_monthes[month - 1] > 30)
            {
                table_days.Rows.Add("31", "31");
            }

            if (combo_box != null)
            {
                combo_box.DataSource = table_days;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void allDaysForComboBox(ComboBox combo_box)
        {
            DataTable table_days = new DataTable();
            table_days.Columns.Add("id", typeof(string));
            table_days.Columns.Add("name", typeof(string));
            table_days.Rows.Add("0", "--- روز ---");
            table_days.Rows.Add("01", "1");
            table_days.Rows.Add("02", "2");
            table_days.Rows.Add("03", "3");
            table_days.Rows.Add("04", "4");
            table_days.Rows.Add("05", "5");
            table_days.Rows.Add("06", "6");
            table_days.Rows.Add("07", "7");
            table_days.Rows.Add("08", "8");
            table_days.Rows.Add("09", "9");
            table_days.Rows.Add("10", "10");
            table_days.Rows.Add("11", "11");
            table_days.Rows.Add("12", "12");
            table_days.Rows.Add("13", "13");
            table_days.Rows.Add("14", "14");
            table_days.Rows.Add("15", "15");
            table_days.Rows.Add("16", "16");
            table_days.Rows.Add("17", "17");
            table_days.Rows.Add("18", "18");
            table_days.Rows.Add("19", "19");
            table_days.Rows.Add("20", "20");
            table_days.Rows.Add("21", "21");
            table_days.Rows.Add("22", "22");
            table_days.Rows.Add("23", "23");
            table_days.Rows.Add("24", "24");
            table_days.Rows.Add("25", "25");
            table_days.Rows.Add("26", "26");
            table_days.Rows.Add("27", "27");
            table_days.Rows.Add("28", "28");
            table_days.Rows.Add("29", "29");
            table_days.Rows.Add("30", "30");
            table_days.Rows.Add("31", "31");
            if (combo_box != null)
            {
                combo_box.DataSource = table_days;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void expirationMonthesForComboBox(ComboBox combo_box)
        {
            DataTable table_monthes = new DataTable();
            table_monthes.Columns.Add("id", typeof(string));
            table_monthes.Columns.Add("name", typeof(string));
            table_monthes.Rows.Add("00", "----- ماه -----");
            table_monthes.Rows.Add("01", "1");
            table_monthes.Rows.Add("02", "2");
            table_monthes.Rows.Add("03", "3");
            table_monthes.Rows.Add("04", "4");
            table_monthes.Rows.Add("05", "5");
            table_monthes.Rows.Add("06", "6");
            table_monthes.Rows.Add("07", "7");
            table_monthes.Rows.Add("08", "8");
            table_monthes.Rows.Add("09", "9");
            table_monthes.Rows.Add("10", "10");
            table_monthes.Rows.Add("11", "11");
            table_monthes.Rows.Add("12", "12");
            if (combo_box != null)
            {
                combo_box.DataSource = table_monthes;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void expirationYearsForComboBox(ComboBox combo_box)
        {
            DataTable table_years = new DataTable();
            table_years.Columns.Add("id", typeof(string));
            table_years.Columns.Add("name", typeof(string));
            table_years.Rows.Add("0000", "----- سال -----");
            table_years.Rows.Add("1394", "1394");
            table_years.Rows.Add("1395", "1395");
            table_years.Rows.Add("1396", "1396");
            table_years.Rows.Add("1397", "1397");
            table_years.Rows.Add("1398", "1398");
            table_years.Rows.Add("1399", "1399");
            table_years.Rows.Add("1400", "1400");
            table_years.Rows.Add("1401", "1401");
            table_years.Rows.Add("1402", "1402");
            table_years.Rows.Add("1403", "1403");
            table_years.Rows.Add("1404", "1404");
            table_years.Rows.Add("1405", "1405");
            table_years.Rows.Add("1406", "1406");
            table_years.Rows.Add("1407", "1407");
            table_years.Rows.Add("1408", "1408");
            table_years.Rows.Add("1409", "1409");
            table_years.Rows.Add("1410", "1410");

            if (combo_box != null)
            {
                combo_box.DataSource = table_years;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void gendersForComboBox(ComboBox combo_box)
        {
            DataTable table_genders = new DataTable();
            table_genders.Columns.Add("g_id", typeof(bool));
            table_genders.Columns.Add("g_name", typeof(string));
            table_genders.Rows.Add(null, "--- جنسیت ---");
            table_genders.Rows.Add(true, "مرد");
            table_genders.Rows.Add(false, "زن");
            if (combo_box != null)
            {
                combo_box.DataSource = table_genders;
                combo_box.ValueMember = "g_id";
                combo_box.DisplayMember = "g_name";
            }
        }
        public static void userMonthesForComboBox(ComboBox combo_box,PIPDataSet.MonthDataTable m_table)
        {
            DataTable table_monthes = new DataTable();
            table_monthes.Columns.Add("id", typeof(string));
            table_monthes.Columns.Add("name", typeof(string));
            table_monthes.Rows.Add("01", "فروردین");
            table_monthes.Rows.Add("02", "اردیبهشت");
            table_monthes.Rows.Add("03", "خرداد");
            table_monthes.Rows.Add("04", "تیر");
            table_monthes.Rows.Add("05", "مرداد");
            table_monthes.Rows.Add("06", "شهریور");
            table_monthes.Rows.Add("07", "مهر");
            table_monthes.Rows.Add("08", "آبان");
            table_monthes.Rows.Add("09", "آذر");
            table_monthes.Rows.Add("10", "دی");
            table_monthes.Rows.Add("11", "بهمن");
            table_monthes.Rows.Add("12", "اسفند");

            DataTable combo_table=new DataTable();
            combo_table.Columns.Add("id", typeof(string));
            combo_table.Columns.Add("name", typeof(string));
            combo_table.Rows.Add("00", "----- ماه -----");
            int index=0;
            foreach (PIPDataSet.MonthRow row in m_table.Rows)
            {
                for (int i = index; i < table_monthes.Rows.Count; i++)
                {
                    index++;
                    if (row.month == (string)table_monthes.Rows[i][0])
                    {
                        combo_table.Rows.Add(row.month, table_monthes.Rows[i][1]);
                        break;
                    }
                }
            }
            if (combo_box != null)
            {
                combo_box.DataSource = combo_table;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void userYearsForComboBox(ComboBox combo_box, PIPDataSet.YearDataTable y_table)
        {
            DataTable table_years = new DataTable();
            table_years.Columns.Add("id", typeof(string));
            table_years.Columns.Add("name", typeof(string));
            table_years.Rows.Add("0000", "----- سال -----");
            foreach (PIPDataSet.YearRow row in y_table.Rows)
            {
                table_years.Rows.Add(row.year, row.year);
            }
            if (combo_box != null)
            {
                combo_box.DataSource = table_years;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }
        public static void yesNoForComboBox(ComboBox combo_box,string title)
        {
            DataTable table_choices = new DataTable();
            table_choices.Columns.Add("id", typeof(bool));
            table_choices.Columns.Add("name", typeof(string));
            if (title != null && title != "")
            {
                table_choices.Rows.Add(null, "-- " + title + " --");
            }
            else
            {
                table_choices.Rows.Add(null, "--- انتخاب ---");
            }
            table_choices.Rows.Add(false, "خیر");
            table_choices.Rows.Add(true, "بله");
            if (combo_box != null)
            {
                combo_box.DataSource = table_choices;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
            adjustDropDownWidthOfComboBox(combo_box);
        }
        public static void activationForComboBox(ComboBox combo_box, string title)
        {
            DataTable table_choices = new DataTable();
            table_choices.Columns.Add("id", typeof(bool?));
            table_choices.Columns.Add("name", typeof(string));
            if (title != null && title != "")
            {
                table_choices.Rows.Add(null, "-- " + title + " --");
            }
            else
            {
                table_choices.Rows.Add(null, "--- انتخاب ---");
            }
            table_choices.Rows.Add(false, "غیرفعال");
            table_choices.Rows.Add(true, "فعال");
            if (combo_box != null)
            {
                combo_box.DataSource = table_choices;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
            adjustDropDownWidthOfComboBox(combo_box);
        }
        public static void tariffInsSearchTypeForComboBox(ComboBox combo_box)
        {
            DataTable table_choices = new DataTable();
            table_choices.Columns.Add("id", typeof(string));
            table_choices.Columns.Add("name", typeof(string));
            table_choices.Rows.Add(PLConstants.enum_tariff_ins_search_type.all.ToString(), "همه- تعرفه های صندوق موردنظر،سایر صندوق های بیمه انتخاب شده و کلیه تعرفه های عمومی مرکز انتخاب شده");
            table_choices.Rows.Add(PLConstants.enum_tariff_ins_search_type.insurance.ToString(), "بیمه انتخاب شده- تعرفه های صندوق موردنظر و سایر صندوق های بیمه انتخاب شده از مرکز انتخاب شده");
            table_choices.Rows.Add(PLConstants.enum_tariff_ins_search_type.sector.ToString(), "صندوق انتخاب شده- تعرفه های صندوق موردنظر از مرکز انتخاب شده");
            table_choices.Rows.Add(PLConstants.enum_tariff_ins_search_type.nulls.ToString(), "عمومی- تعرفه های عمومی بدون بیمه از مرکز انتخاب شده");
            if (combo_box != null)
            {
                combo_box.DataSource = table_choices;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
            adjustDropDownWidthOfComboBox(combo_box);
        }
        //////////////////////////////////////////////////////////////////////// Data Tables for ListBox
        public static void yearsForCheckedListBox(CheckedListBox checked_list_box)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(DateTime.Now);
            DataTable table_years = new DataTable();
            table_years.Columns.Add("id", typeof(string));
            table_years.Columns.Add("name", typeof(string));
            table_years.Rows.Add("all", "---انتخاب همه---");
            for (int i = 1394; i <= year; i++)
            {
                table_years.Rows.Add(i.ToString(), i.ToString());
            }
            if (checked_list_box != null)
            {
                checked_list_box.DataSource = table_years;
                checked_list_box.ValueMember = "id";
                checked_list_box.DisplayMember = "name";
            }
        }
        public static void monthesForCheckedListBox(CheckedListBox checked_list_box)
        {
            DataTable table_monthes = new DataTable();
            table_monthes.Columns.Add("id", typeof(string));
            table_monthes.Columns.Add("name", typeof(string));
            table_monthes.Rows.Add("all", "---انتخاب همه---");
            table_monthes.Rows.Add("01", "فروردین");
            table_monthes.Rows.Add("02", "اردیبهشت");
            table_monthes.Rows.Add("03", "خرداد");
            table_monthes.Rows.Add("04", "تیر");
            table_monthes.Rows.Add("05", "مرداد");
            table_monthes.Rows.Add("06", "شهریور");
            table_monthes.Rows.Add("07", "مهر");
            table_monthes.Rows.Add("08", "آبان");
            table_monthes.Rows.Add("09", "آذر");
            table_monthes.Rows.Add("10", "دی");
            table_monthes.Rows.Add("11", "بهمن");
            table_monthes.Rows.Add("12", "اسفند");
            if (checked_list_box != null)
            {
                checked_list_box.DataSource = table_monthes;
                checked_list_box.ValueMember = "id";
                checked_list_box.DisplayMember = "name";
            }
        }
        public static void contractStatusForCheckedListBox(CheckedListBox checked_list_box)
        {
            DataTable table_contract_status = new DataTable();
            table_contract_status.Columns.Add("id", typeof(int));
            table_contract_status.Columns.Add("name", typeof(string));
            table_contract_status.Rows.Add(3, "---انتخاب همه---");
            table_contract_status.Rows.Add(1, "فقط صندوق های داری قرارداد");
            table_contract_status.Rows.Add(2, "صندوق هایی که قرارداد ندارند");
            if (checked_list_box != null)
            {
                checked_list_box.DataSource = table_contract_status;
                checked_list_box.ValueMember = "id";
                checked_list_box.DisplayMember = "name";
            }
        }
        //////////////////////////////////////////////////////////////////////// DataTable
        public static DataTable emptyIntIDsDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(int));
            return s_d_t;
        }
        public static DataTable emptyLongIDsDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(long));
            return s_d_t;
        }
        public static DataTable emptySelectedServicesDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(new DataColumn(PLConstants.str_table_col_service_tariff_seq, typeof(long)));
            s_d_t.Columns.Add(new DataColumn(PLConstants.str_table_col_servicing_count, typeof(int)));
            return s_d_t;
        }
        public static DataTable emptyMonthIDsDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_month_id, typeof(string));
            return s_d_t;
        }
        public static DataTable emptyYearIDsDataTable()
        {
            DataTable s_d_t = new DataTable();
            s_d_t.Columns.Add(PLConstants.str_table_col_year_id, typeof(string));
            return s_d_t;
        }
        public static DataTable rowingOneColumnDataTable(DataTable table)
        {
            if (table.Columns.Count == 1)
            {
                table.Columns.Add(new DataColumn(PLConstants.str_table_col_row_number, typeof(int)));
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i][1] = i + 1;
                }
            }
            return table;
        }
        public static DataTable insuranceLogoDataTable()
        {
            //string path = "Insurance_Logo\";
            //string path = "PadraInsurancePrescription.Insurance_Logo.";
            ResourceManager rm = Properties.Resources.ResourceManager;
            DataTable i_l_t = new DataTable();
            i_l_t.Columns.Add(PLConstants.str_table_col_ins_id, typeof(int));
            i_l_t.Columns.Add(PLConstants.str_table_col_ins_tag, typeof(string));
            i_l_t.Columns.Add(PLConstants.str_table_col_ins_logo_image, typeof(byte[]));
            foreach (PLConstants.enum_tag_of_insurances insurance in Enum.GetValues(typeof(PLConstants.enum_tag_of_insurances)))
            {
                i_l_t.Rows.Add((int)insurance, insurance.ToString(), convertImageToBinary((Bitmap)rm.GetObject("logo_" + insurance.ToString())));
            }
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.SedaSima, PLConstants.enum_tag_of_insurances.SedaSima.ToString(), convertImageToBinary(Properties.Resources.logo_SedaSima));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.Naft, PLConstants.enum_tag_of_insurances.Naft.ToString(), convertImageToBinary(Properties.Resources.logo_Naft));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.Melli, PLConstants.enum_tag_of_insurances.Melli.ToString(), convertImageToBinary(Properties.Resources.logo_Melli));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.TaminEjtemaei, PLConstants.enum_tag_of_insurances.TaminEjtemaei.ToString(), convertImageToBinary(Properties.Resources.logo_TaminEjtemaei));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.NirooMosalah, PLConstants.enum_tag_of_insurances.NirooMosalah.ToString(), convertImageToBinary(Properties.Resources.logo_NirooMosalah));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.Salamat, PLConstants.enum_tag_of_insurances.Salamat.ToString(), convertImageToBinary(Properties.Resources.logo_Salamat));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.KomitehEmdad, PLConstants.enum_tag_of_insurances.KomitehEmdad.ToString(), convertImageToBinary(Properties.Resources.logo_KomitehEmdad));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.Tejarat, PLConstants.enum_tag_of_insurances.Tejarat.ToString(), convertImageToBinary(Properties.Resources.logo_Tejarat));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.Sepah, PLConstants.enum_tag_of_insurances.Sepah.ToString(), convertImageToBinary(Properties.Resources.logo_Sepah));
            //i_l_t.Rows.Add((int)PLConstants.enum_tag_of_insurances.Saderat, PLConstants.enum_tag_of_insurances.Saderat.ToString(), convertImageToBinary(Properties.Resources.logo_Saderat));
            return i_l_t;
        }
        public static DataTable monthesCompleteDataTable()
        {
            DataTable m_t = new DataTable();
            m_t.Columns.Add(PLConstants.str_table_col_month_id, typeof(string));
            m_t.Columns.Add(PLConstants.str_table_col_month_name, typeof(string));
            m_t.Rows.Add("01", "فروردین");
            m_t.Rows.Add("02", "اردیبهشت");
            m_t.Rows.Add("03", "خرداد");
            m_t.Rows.Add("04", "تیر");
            m_t.Rows.Add("05", "مرداد");
            m_t.Rows.Add("06", "شهریور");
            m_t.Rows.Add("07", "مهر");
            m_t.Rows.Add("08", "آبان");
            m_t.Rows.Add("09", "آذر");
            m_t.Rows.Add("10", "دی");
            m_t.Rows.Add("11", "بهمن");
            m_t.Rows.Add("12", "اسفند");
            return m_t;
        }
        //////////////////////////////////////////////////////////////////////// ComboBoxes
        public static void adjustDropDownWidthOfComboBox(ComboBox combo_box)
        {
            Graphics graphic = combo_box.CreateGraphics();
            Font font = combo_box.Font;
            int vert_scrollBarWidth =
                (combo_box.Items.Count > combo_box.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int big_item_width = 0, item_width = 0;
            for (int i = 0; i < combo_box.Items.Count;i++ )
            {
                item_width = (int)graphic.MeasureString(combo_box.GetItemText(combo_box.Items[i]), font).Width;
                if (item_width > big_item_width)
                {
                    big_item_width = item_width;
                }
            }
            int last_width = big_item_width + 50 + vert_scrollBarWidth;
            if (last_width > combo_box.Size.Width)
            {
                combo_box.DropDownWidth = last_width;
            }
        }

        //////////////////////////////////////////////////////////////////////// DataGridView functions
        public static void changeDGVSettings(params DataGridView[] grids)
        {
            foreach (DataGridView grid in grids)
            {
                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.AllowUserToOrderColumns = false;
                grid.AllowUserToResizeRows = false;
                grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                grid.MultiSelect = false;
                grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
                grid.ReadOnly = false;
                foreach (DataGridViewColumn col in grid.Columns)
                {
                    col.ReadOnly = true;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (grid.Columns[0] is DataGridViewCheckBoxColumn)
                {
                    grid.Columns[0].ReadOnly = false;
                    grid.Columns[0].Frozen = true;
                }
            }
        }

        public static void DGVAfterFilling(DataGridView grid, CheckBox check_box)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            if (grid.Rows.Count > 0)
            {
                check_box.Visible = true;
                Rectangle rect = grid.GetCellDisplayRectangle(0, -1, true);
                check_box.Size = new Size(30, 30);
                check_box.BackColor = Color.Transparent;
                check_box.CheckAlign = ContentAlignment.MiddleCenter;
                check_box.Location = new Point(rect.Location.X + (rect.Width / 2) - 15, rect.Location.Y + (rect.Height / 2) - 15);
                grid.Controls.Add(check_box);
            }
            else
            {
                check_box.Visible = false;
            }
        }

        public static void DGVAfterFillingWithStartNumber(DataGridView grid, CheckBox check_box, int start_number)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].HeaderCell.Value = (i + start_number + 1).ToString();
            }
            if (grid.Rows.Count > 0)
            {
                check_box.Visible = true;
                Rectangle rect = grid.GetCellDisplayRectangle(0, -1, true);
                check_box.Size = new Size(30, 30);
                check_box.BackColor = Color.Transparent;
                check_box.CheckAlign = ContentAlignment.MiddleCenter;
                check_box.Location = new Point(rect.Location.X + (rect.Width / 2) - 15, rect.Location.Y + (rect.Height / 2) - 15);
                grid.Controls.Add(check_box);
            }
            else
            {
                check_box.Visible = false;
            }
        }
        
        public static bool dataGridViewAfterFilling(DataGridView grid, CheckBox check_box)
        {
            check_box.Visible = true;
            dataGridViewRowNumbering(grid);
            return false;
        }

        public static void createAllCheckBoxForDataGridView(DataGridView grid, CheckBox check_box)
        {
            if (grid.Rows.Count > 0)
            {
                Rectangle rect = grid.GetCellDisplayRectangle(0, -1, true);
                check_box.Size = new Size(30, 30);
                check_box.BackColor = Color.Transparent;
                check_box.CheckAlign = ContentAlignment.MiddleCenter;
                check_box.Location = new Point(rect.Location.X + (rect.Width / 2) - 15, rect.Location.Y + (rect.Height / 2) - 15);
                grid.Controls.Add(check_box);
            }
        }

        public static void dataGridViewRowNumbering(DataGridView grid)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        //////////////////////////////////////////////////////////////////////// REPORTS
        public static void lettersReportForComboBox(PLConstants.enum_insurances ins_org, ComboBox combo_box)
        {
            DataTable table_monthes = new DataTable();
            table_monthes.Columns.Add("id", typeof(string));
            table_monthes.Columns.Add("name", typeof(string));
            table_monthes.Rows.Add("00", "----- ماه -----");
            table_monthes.Rows.Add("01", "فروردین");
            table_monthes.Rows.Add("02", "اردیبهشت");
            table_monthes.Rows.Add("03", "خرداد");
            table_monthes.Rows.Add("04", "تیر");
            table_monthes.Rows.Add("05", "مرداد");
            table_monthes.Rows.Add("06", "شهریور");
            table_monthes.Rows.Add("07", "مهر");
            table_monthes.Rows.Add("08", "آبان");
            table_monthes.Rows.Add("09", "آذر");
            table_monthes.Rows.Add("10", "دی");
            table_monthes.Rows.Add("11", "بهمن");
            table_monthes.Rows.Add("12", "اسفند");
            if (combo_box != null)
            {
                combo_box.DataSource = table_monthes;
                combo_box.ValueMember = "id";
                combo_box.DisplayMember = "name";
            }
        }

        //////////////////////////////////////////////////////////////////////// Pictures And Photos
        public static Bitmap convertBinaryToBitmap(byte[] image_bytes)
        {
            if (image_bytes != null)
            {
                MemoryStream stream = new MemoryStream(image_bytes);
                return new Bitmap(stream);
            }
            return null;
        }
        public static byte[] convertImageToBinary(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        //////////////////////////////////////////////////////////////////////// Import Export
        public static void importCentersData(bool db_is_empty)
        {
            PGSDialog pgs_dialog = new PGSDialog();
            string op_result = "", error_message = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = PLConstants.str_excel_type_filter;
            ofd.Title = PLConstants.str_excel_file_centers_dialog_title;

            PasswordForm pass_form = new PasswordForm();
            string pass = "";

            PIPDataSetTableAdapters.TSystemUserTableAdapter user_adapter = new PIPDataSetTableAdapters.TSystemUserTableAdapter();
            PIPDataSetTableAdapters.DataTransferTableAdapter transfer_adapter = new PIPDataSetTableAdapters.DataTransferTableAdapter();
            DataSet data_set = new DataSet();

            List<SqlParameter> params_list = new List<SqlParameter>();
            SqlParameter temp_param;

            bool import_allowed = false;
            if (db_is_empty)
            {
                import_allowed = true;
                pass = pass_form.ShowEmptyVer();
            }
            else if (pass_form.ShowUserVer())
            {
                user_adapter.GetUserPassword(PLConstants.UserCode, ref pass);
                import_allowed = true;
            }

            if (import_allowed)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string file_path = ofd.FileName;
                    try
                    {
                        Excel.Application excel_app = new Excel.Application();
                        Excel.Workbook workbook = excel_app.Workbooks.Open(file_path, Password: pass, ReadOnly: true);
                        Excel.Worksheet worksheet;
                        Excel.Range sheet_range;
                        Excel.Range columns_header_row;
                        Excel.Range columns_type_row;
                        int columns_count;
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_import_file_wait);
                        foreach (PLConstants.enum_user_tables_for_transfer import_table in Enum.GetValues(typeof(PLConstants.enum_user_tables_for_transfer)))
                        {
                            DataTable data = new DataTable(import_table.ToString());
                            worksheet = workbook.Worksheets.get_Item(import_table.ToString());
                            sheet_range = worksheet.UsedRange;
                            columns_header_row = sheet_range.Rows[1];
                            columns_type_row = sheet_range.Rows[2];
                            columns_count = columns_header_row.Cells.Count;
                            if (import_table != PLConstants.enum_user_tables_for_transfer.Insurance &&
                                import_table != PLConstants.enum_user_tables_for_transfer.InsuranceSector)
                            {
                                for (int c = 1; c <= columns_count; c++)
                                {
                                    if (columns_type_row.Cells[c].Value == PLConstants.enum_data_types.string_type.ToString() ||
                                        columns_type_row.Cells[c].Value == PLConstants.enum_data_types.number_type.ToString() ||
                                        columns_type_row.Cells[c].Value == PLConstants.enum_data_types.other_type.ToString())
                                    {
                                        data.Columns.Add(columns_header_row.Cells[c].Value);
                                    }
                                    else if (columns_type_row.Cells[c].Value == PLConstants.enum_data_types.bool_type.ToString())
                                    {
                                        data.Columns.Add(columns_header_row.Cells[c].Value, typeof(bool));
                                    }
                                    else
                                    {
                                        throw new Exception("unknown data type for table:" + import_table.ToString() + " ,column: " + columns_header_row.Cells[c].Value + " ,type: " + columns_type_row.Cells[c].Value);
                                    }
                                }
                                for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                {
                                    data.Rows.Add(data.NewRow());
                                }
                                for (int c = 0; c < columns_count; c++)
                                {
                                    if (data.Columns[c].DataType == typeof(bool))
                                    {
                                        for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                        {
                                            object obj = data.Rows[r - 3][c] = sheet_range.Cells[r, c + 1].Value == "1" ? true : false;
                                        }
                                    }
                                    else
                                    {
                                        for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                        {
                                            object obj = data.Rows[r - 3][c] = sheet_range.Cells[r, c + 1].Value;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int c = 1; c <= columns_count; c++)
                                {
                                    if (columns_type_row.Cells[c].Value == PLConstants.enum_data_types.string_type.ToString() ||
                                        columns_type_row.Cells[c].Value == PLConstants.enum_data_types.number_type.ToString())
                                    {
                                        data.Columns.Add(columns_header_row.Cells[c].Value);
                                    }
                                    else if (columns_type_row.Cells[c].Value == PLConstants.enum_data_types.bool_type.ToString())
                                    {
                                        data.Columns.Add(columns_header_row.Cells[c].Value, typeof(bool));
                                    }
                                    else if (columns_type_row.Cells[c].Value == PLConstants.enum_data_types.other_type.ToString())
                                    {
                                        if (columns_header_row.Cells[c].Value == PLConstants.str_table_insurance_col_logo_image)
                                        {
                                            data.Columns.Add(columns_header_row.Cells[c].Value, typeof(byte[]));
                                        }
                                        else
                                        {
                                            data.Columns.Add(columns_header_row.Cells[c].Value);
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("unknown data type for table:" + import_table.ToString() + " ,column: " + columns_header_row.Cells[c].Value + " ,type: " + columns_type_row.Cells[c].Value);
                                    }
                                }
                                for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                {
                                    data.Rows.Add(data.NewRow());
                                }
                                for (int c = 0; c < columns_count; c++)
                                {
                                    if (data.Columns[c].DataType == typeof(bool))
                                    {
                                        for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                        {
                                            object obj = data.Rows[r - 3][c] = sheet_range.Cells[r, c + 1].Value == "1" ? true : false;
                                        }
                                    }
                                    else if (data.Columns[c].ColumnName == PLConstants.str_table_insurance_col_logo_image)
                                    {
                                        for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                        {
                                            data.Rows[r - 3][c] = null;
                                        }
                                    }
                                    else
                                    {
                                        for (int r = 3; r <= sheet_range.Rows.Count; r++)
                                        {
                                            data.Rows[r - 3][c] = sheet_range.Cells[r, c + 1].Value;
                                        }
                                    }
                                }
                            }
                            data_set.Tables.Add(data);
                            temp_param = new SqlParameter("@" + import_table.ToString(), data);
                            temp_param.SqlDbType = SqlDbType.Structured;
                            params_list.Add(temp_param);
                        }

                        SqlConnection connection = new SqlConnection(transfer_adapter.Connection.ConnectionString);
                        SqlCommand command = new SqlCommand(PLConstants.sp_import_centers_data_into_user, connection);
                        command.CommandTimeout = 7200;
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter result_par = new SqlParameter("@operations_result", SqlDbType.VarChar, 50);
                        result_par.Direction = ParameterDirection.Output;
                        params_list.Add(result_par);
                        SqlParameter message_par = new SqlParameter("@error_message", SqlDbType.VarChar, 1000);
                        message_par.Direction = ParameterDirection.Output;
                        params_list.Add(message_par);

                        command.Parameters.AddRange(params_list.ToArray());
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();
                        op_result = command.Parameters[result_par.ParameterName].Value.ToString();
                        error_message = command.Parameters[message_par.ParameterName].Value.ToString();

                        //transfer_adapter.ImportCentersDataIntoUser(
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.Month.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.UserType.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.Insurance.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.InsuranceSector.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.SystemUser.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.Province.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.City.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.ClinicGroup.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.ClinicType.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.ClinicPart.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.DoctorGroup.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicineDegreeGroup.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicineDegree.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicineField.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.Doctor.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalCenter.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalCenterPart.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalCenterContract.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalCenterDoctor.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalServiceCategory.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalServiceSubCategory.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalService.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.KValue.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalServiceTariff.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.MedicalCenterTariff.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.PrescriptionDataParameters.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.StandardReport.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.UserPrescriptionPermission.ToString()],
                        //    data_set.Tables[PLConstants.enum_user_tables_for_transfer.ActivityType.ToString()],
                        //    ref op_result, ref error_message);

                        if (PLEnumFuncs.opResultToEnum(op_result) == PLConstants.enum_operation_results.success)
                        {
                            transfer_adapter.ImportInsuranceLogoForUser(PLGlobalFuncs.insuranceLogoDataTable(), ref op_result);
                        }
                        pgs_dialog.operationResult(PLEnumFuncs.opResultToEnum(op_result), PLConstants.enum_information_part.other);
                        workbook.Close();
                        excel_app.Quit();
                    }
                    catch (Exception exp)
                    {
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_transfer_import_export_data);
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////////////// EVENTS

        //private void code_textbox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //        t_int_str = t_int_str.Remove(t_int_str.Length - 1);
        //        if (t_int_str == "") { t_int_str = "0"; }
        //        t_str = t_int_str;
        //        t_box.Text = (int.Parse(t_int_str)).ToString("N0");
        //    }
        //    else if (e.KeyChar == (char)Keys.Tab)
        //    {
        //        e.Handled = false;
        //    }
        //    else if (t_box.Text.Length < t_box.MaxLength)
        //    {
        //        e.Handled = true;
        //        if (Char.IsDigit(e.KeyChar))
        //        {
        //            t_int_str = (t_int_str == "0") ? e.KeyChar.ToString() : t_int_str + e.KeyChar;
        //            t_str = t_int_str;
        //            t_box.Text = (int.Parse(t_int_str)).ToString("N0");
        //        }
        //    }
        //}

    }
}
