using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.Media;

namespace PadraInsurancePrescription
{
    public partial class PrescriptionSubmitForm : Form
    {
        //////////////////////////////////////////////////////////////////// PUBLIC VARIABLES
        enum tab_enum { center, service, prescription };
        PLConstants.enum_insurances insurance_org;
        PLConstants.enum_other_insurances other_ins_org;
        char dash_char = '-';
        char slash_char = '/';
        int len_2 = 2, len_4 = 4, pres_items_cou = 12, pres_info_items_cou = 10, pres_ser_items_cou = 2;
        char enter_char = (char)Keys.Enter;

        PGSDialog pgs_dialog;
        bool? center_has_part;
        bool use_past_tariffs = false;
        string past_tariffs_day, past_tariffs_month, past_tariffs_year;
        string past_date;

        //////////////////////////////////////////////////////////////////// CENTER VARIABLES
        PIPDataSetTableAdapters.ProvinceTableAdapter c_province_adapter;
        PIPDataSetTableAdapters.CityTableAdapter c_city_adapter;
        PIPDataSetTableAdapters.TClinicTypeTableAdapter c_clinic_type_adapter;
        PIPDataSetTableAdapters.SMedicalCenterNameTableAdapter c_medical_center_adapter;
        //PIPDataSetTableAdapters.TClinicPartTableAdapter c_clinic_part_adapter;
        PIPDataSetTableAdapters.TMedicalCenterPartTableAdapter c_clinic_part_adapter;
        PIPDataSetTableAdapters.TInsuranceTableAdapter c_insurance_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter c_sector_adapter;
        PIPDataSetTableAdapters.YearTableAdapter c_year_adapter;
        PIPDataSetTableAdapters.MonthTableAdapter c_month_adapter;
        PIPDataSet.ProvinceDataTable c_province_data;
        PIPDataSet.CityDataTable c_city_data;
        PIPDataSet.TClinicTypeDataTable c_clinic_type_data;
        PIPDataSet.SMedicalCenterNameDataTable c_medical_center_data;
        //PIPDataSet.TClinicPartDataTable c_clinic_part_data;
        PIPDataSet.TMedicalCenterPartDataTable c_clinic_part_data;
        PIPDataSet.TInsuranceDataTable c_insurance_data;
        PIPDataSet.TInsuranceSectorDataTable c_sector_data;
        PIPDataSet.YearDataTable c_year_data;
        PIPDataSet.MonthDataTable c_month_data;
        PIPDataSet.TMedicalCenterTariffDataTable s_temp_tariffs;

        //////////////////////////////////////////////////////////////////// SERVICE VARIABLES
        PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter s_ser_category_adapter;
        PIPDataSet.TMedicalServiceCategoryDataTable s_ser_category_data;
        CheckBox s_service_select_all_chk, s_choosed_select_all_chk;
        string s_ser_str_sel_col, s_cho_str_sel_col;
        List<KeyValuePair<int, long>> s_list_sel_tariffs;//1-row number 2-id
        PLConstants.enum_service_status s_status;
        int s_static_service_count,s_static_total_cost, s_static_ins_share, s_static_pat_share;
        DataTable s_table_sel_tariffs,s_t_just_sel_tariffs;

        //////////////////////////////////////////////////////////////////// PRESCRIPTION VARIABLES
        VisitDayForm p_visit_day_form;
        SearchedInsuredForm p_other_sectors_form;
        SearchedInsuredServiceForm p_other_services_form;
        
        int p_i_err_cou;
        int p_s_err_cou;
        int p_chk_i_err_cou;
        int p_chk_s_err_cou;
        bool[] p_arr_is_constant;
        bool[] p_arr_has_error;
        ErrorProvider[] p_arr_error_providers;
        string[] p_arr_error_text;
        Control[] p_arr_controls;
        List<Control> p_editable_info_boxes;
        List<Control> p_editable_service_boxes;
        Control p_starter_info_control,p_starter_service_control;

        int p_ind_vis_day = 0, p_ind_insured_id = 1,p_ind_serial=2, p_ind_page = 3, p_ind_fun_doctor = 4, p_ind_insured_name = 5, p_ind_insured_family = 6, p_ind_exp_date = 7,
            p_ind_prescriptor_doctor = 8, p_ind_prescriptor_date = 9, p_ind_service_count = 10, p_ind_service_code = 11;

        string p_id_regex_str, p_serial_regex_str;
        int p_id_max_length;
        KeyPressEventHandler p_id_KeyPressHandler;

        bool p_process_insured_exist_checking, p_is_insured_exist;
        long? p_insured_sequence;
        bool? p_other_sectors_id;
        bool p_process_service_exist_checking;
        bool? p_insured_has_service;
        bool p_is_exp_date_changed;
        bool p_is_exp_date_constant;
        string p_previous_exp_day, p_previous_exp_month, p_previous_exp_year;
        bool page_reset;

        int? p_sel_part_value;
        bool p_is_info_saved;
        long? p_info_save_sequence;
        string p_save_info_result, p_save_service_result, p_delete_service_result;
        PLConstants.enum_prescription_results p_pres_op_result;
        PLConstants.enum_prescription_results p_service_op_result;
        PLConstants.enum_prescription_results p_delete_service_op_result;

        PIPDataSetTableAdapters.SInsuredDataTableAdapter p_insured_data_adapter;
        PIPDataSetTableAdapters.SMedicalCenterPartDoctorTableAdapter p_center_doctor_adapter;
        PIPDataSetTableAdapters.PrescriptionDataParametersTableAdapter p_data_params_adapter;
        PIPDataSetTableAdapters.TPrescriptionInfoTableAdapter p_prescription_info_adapter;
        PIPDataSetTableAdapters.TPrescriptionServiceTableAdapter p_pres_service_adapter;
        PIPDataSet.SMedicalCenterPartDoctorDataTable p_center_doctor_data;
        PIPDataSet.PrescriptionDataParametersDataTable p_data_params_data;
        PIPDataSet.ComboMCTASDataTable p_table_service_code;
        PIPDataSet.ComboMCTASRow p_row_service_code;
        PIPDataSet.TMedicalCenterTariffRow p_row_tariff;

        PIPDataSet.PrescriptionDataParametersRow p_params_row;

        int p_temp_int;
        string p_temp_str;
        bool p_temp_err_bool;
        short p_temp_short;
        string p_sub_info_str = "ثبت اطلاعات نسخه", p_sta_sub_info_str = "ثبت نهایی اطلاعات نسخه";
        
        CheckBox p_selected_select_all_chk,p_all_select_all_chk;
        string p_sel_str_sel_col,p_all_str_sel_col;
        List<KeyValuePair<int, long>> p_list_sel_tariffs;//1-row number 2-id
        int p_dynamic_service_count, p_dynamic_total_cost, p_dynamic_ins_share, p_dynamic_pat_share;

        delegate void ORG_get_insured_info_del();
        delegate void ORG_set_insured_info_del();
        ORG_get_insured_info_del org_get_insured_info_func;
        ORG_set_insured_info_del org_set_insured_info_func;

        delegate void ORG_get_service_exist_del();
        delegate void ORG_set_service_exist_del();
        ORG_get_service_exist_del org_get_service_exist_func;
        ORG_set_service_exist_del org_set_service_exist_func;

        delegate string var_get_prescription_day_del();
        delegate string var_get_prescription_month_del();
        delegate string var_get_prescription_year_del();
        delegate int? var_get_prescription_doc_del();
        var_get_prescription_day_del var_g_p_day_func;
        var_get_prescription_month_del var_g_p_month_func;
        var_get_prescription_year_del var_g_p_year_func;
        var_get_prescription_doc_del var_g_p_doc_func;

        delegate void ORG_save_info_exist_del();
        delegate void ORG_save_info_new_del();
        ORG_save_info_exist_del org_save_info_exist_func;
        ORG_save_info_new_del org_save_info_new_func;

        delegate void ORG_save_service_del();
        ORG_save_service_del org_save_service_func;
        delegate void ORG_delete_service_del();
        ORG_delete_service_del org_delete_service_func;

        delegate void setting_page_number_del();
        setting_page_number_del setting_page_number_func;

        delegate string var_get_serial_del();
        var_get_serial_del var_get_serial_func;
        delegate string var_get_identifier_del();
        var_get_identifier_del var_get_identifier_func;

        int sel_province;
        int sel_city;
        int sel_center_type;
        int? sel_center, last_center;
        int? sel_part, last_part;
        int sel_insurance, last_insurance;
        int sel_sector, last_sector;
        string sel_vis_year;
        string sel_vis_month;
        DataTable sel_static_services;
        DataTable sel_dynamic_services;
        string sel_vis_day, sel_insured_code, sel_pres_serial, sel_insured_identifier;
        short? sel_page;
        int? sel_fun_doctor;
        string sel_insured_name, sel_insured_family, sel_exp_day, sel_exp_month, sel_exp_year;
        string sel_prescriptor_day, sel_prescriptor_month, sel_prescriptor_year;
        int? sel_prescriptor_doctor, sel_service_count;
        int sel_shortcut_service_code,sel_service_index;
        string sel_service_code;
        long sel_service_tariff;
        int sel_all_service_count, sel_tot_price_val, sel_ins_share_val, sel_pat_share_val;
        
        public PrescriptionSubmitForm()//checked
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(s_service_grid,s_choosed_grid,p_all_service_grid,p_selected_service_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.main);

            int tab_item_header_width = main_tabControl.Width / main_tabControl.TabPages.Count;
            main_tabControl.ItemSize = new Size((main_tabControl.Width / main_tabControl.TabPages.Count), main_tabControl.ItemSize.Height);
            service_tab.Enabled = prescription_tab.Enabled = false;
            pgs_dialog = new PGSDialog(this);

            c_province_adapter = new PIPDataSetTableAdapters.ProvinceTableAdapter();
            c_city_adapter = new PIPDataSetTableAdapters.CityTableAdapter();
            c_clinic_type_adapter=new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            c_medical_center_adapter=new PIPDataSetTableAdapters.SMedicalCenterNameTableAdapter();
            c_clinic_part_adapter = new PIPDataSetTableAdapters.TMedicalCenterPartTableAdapter();
            c_insurance_adapter=new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            c_sector_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            c_year_adapter = new PIPDataSetTableAdapters.YearTableAdapter();
            c_month_adapter = new PIPDataSetTableAdapters.MonthTableAdapter();
            c_medical_center_data = new PIPDataSet.SMedicalCenterNameDataTable();
            c_clinic_part_data = new PIPDataSet.TMedicalCenterPartDataTable();
            c_insurance_data = new PIPDataSet.TInsuranceDataTable();
            c_sector_data = new PIPDataSet.TInsuranceSectorDataTable();
            c_year_data = new PIPDataSet.YearDataTable();
            c_month_data = new PIPDataSet.MonthDataTable();
            s_temp_tariffs = new PIPDataSet.TMedicalCenterTariffDataTable();

            initCProvinceComboBox();
            initCClinicTypeComboBox();
            PLGlobalFuncs.tariffInsSearchTypeForComboBox(s_ins_type_cbx);
            //PLGlobalFuncs.yearsForComboBox(c_year_cbx);
            //PLGlobalFuncs.monthesForComboBox(c_month_cbx);

            s_ser_category_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            s_service_select_all_chk = new CheckBox();
            s_choosed_select_all_chk = new CheckBox();
            s_service_select_all_chk.CheckedChanged += s_service_select_all_checkbox_CheckedChanged;
            s_choosed_select_all_chk.CheckedChanged += s_choosed_select_all_checkbox_CheckedChanged;
            s_service_select_all_chk.Visible = false;
            s_choosed_select_all_chk.Visible = false;
            s_ser_str_sel_col = s_ser_select_column.Name;
            s_cho_str_sel_col = s_cho_select_column.Name;
            s_list_sel_tariffs = new List<KeyValuePair<int, long>>();
            s_table_sel_tariffs = PLGlobalFuncs.emptySelectedServicesDataTable();
            s_t_just_sel_tariffs = PLGlobalFuncs.emptySelectedServicesDataTable();

            p_other_sectors_form = new SearchedInsuredForm();
            p_other_services_form = new SearchedInsuredServiceForm();
            p_arr_error_providers = new ErrorProvider[] { EP_p_vis, EP_p_id, EP_p_serial, EP_p_page, EP_p_fun_doctor, EP_p_name, EP_p_family, EP_p_exp, EP_p_pre_doctor, EP_p_pre_date, EP_p_pre_count, EP_p_service_code };
            p_arr_controls = new Control[] { p_vis_cbx, p_id_txt, p_serial_txt, p_page_msk, p_fun_doc_id_msk, p_name_txt, p_family_txt, p_exp_year_msk, p_pre_doc_msk, p_pre_year_msk,p_service_count_msk, p_service_code_msk };
            p_arr_error_text = new string[] { PLConstants.error_pres_vis_day, PLConstants.error_id, PLConstants.error_pres_serial, PLConstants.error_pres_page, 
                                              PLConstants.error_pres_fun_doctor, PLConstants.error_names, PLConstants.error_names,
                                              PLConstants.error_date, PLConstants.error_id, PLConstants.error_date,PLConstants.error_numbers_int,PLConstants.error_id_just_number };
            p_insured_info_worker.DoWork += p_insured_info_worker_DoWork;
            p_insured_service_exist_worker.DoWork += p_insured_service_exist_worker_DoWork;
            p_insured_data_adapter = new PIPDataSetTableAdapters.SInsuredDataTableAdapter();
            p_center_doctor_adapter = new PIPDataSetTableAdapters.SMedicalCenterPartDoctorTableAdapter();
            p_data_params_adapter = new PIPDataSetTableAdapters.PrescriptionDataParametersTableAdapter();
            p_prescription_info_adapter = new PIPDataSetTableAdapters.TPrescriptionInfoTableAdapter();
            p_pres_service_adapter = new PIPDataSetTableAdapters.TPrescriptionServiceTableAdapter();
            p_center_doctor_data = new PIPDataSet.SMedicalCenterPartDoctorDataTable();
            p_data_params_data=new PIPDataSet.PrescriptionDataParametersDataTable();
            PIPDataSet.TMedicalCenterTariffRow p_row_tariff;
            p_selected_select_all_chk = new CheckBox();
            p_all_select_all_chk = new CheckBox();
            p_sel_str_sel_col = p_sel_select_column.Name;
            p_all_str_sel_col = p_all_select_column.Name;
            p_selected_select_all_chk.CheckedChanged += p_selected_select_all_chk_CheckedChanged;
            p_list_sel_tariffs = new List<KeyValuePair<int, long>>();

            sel_static_services = PLGlobalFuncs.emptySelectedServicesDataTable();
            sel_dynamic_services = PLGlobalFuncs.emptySelectedServicesDataTable();
            
            sel_part = -1;
        }

        ///////////////////////////////////////////////////////////////////////// CENTER TAB
        #region CENTER Tab

        private void c_province_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_province_cbx.SelectedIndex > 0)
            {
                sel_province = (int)c_province_cbx.SelectedValue;
                initCCityComboBox();
            }
            else
            {
                c_city_cbx.DataSource = null;
                c_city_cbx.Enabled = false;
            }
        }
        private void c_city_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_city_cbx.SelectedIndex > 0)
            {
                sel_city = (int)c_city_cbx.SelectedValue;
                c_type_cbx.Enabled = true;
            }
            else
            {
                c_type_cbx.Enabled = false;
                c_type_cbx.SelectedIndex = 0;
            }
        }
        private void c_type_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_type_cbx.SelectedIndex > 0)
            {
                sel_center_type = (int)c_type_cbx.SelectedValue;
                initCCenterComboBox();
            }
            else
            {
                sel_center_type = -1;
                c_center_cbx.DataSource = null;
                c_center_cbx.Enabled = false;
            }
        }
        private void c_center_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_center_cbx.SelectedIndex > 0)
            {
                sel_center = (int)c_center_cbx.SelectedValue;
                initCPartComboBox();
                //initCInsuranceComboBox();
                c_part_cbx.Enabled = true;
                //c_insurance_cbx.Enabled = true;
            }
            else
            {
                c_part_cbx.Enabled = false;
                c_part_cbx.DataSource = null;
                //c_insurance_cbx.DataSource = null;
                //c_insurance_cbx.Enabled = false;
            }
        }
        private void c_part_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_part_cbx.SelectedIndex > 0)
            {
                p_sel_part_value= sel_part = (int)c_part_cbx.SelectedValue;
                initCInsuranceComboBox();
                c_insurance_cbx.Enabled = true;
            }
            else if (!(bool)center_has_part)
            {
                sel_part = -1;
                p_sel_part_value = null;
                initCInsuranceComboBox();
            }
            else
            {
                c_insurance_cbx.DataSource = null;
                c_insurance_cbx.Enabled = false;
            }
        }
        private void c_insurance_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_insurance_cbx.SelectedIndex > 0)
            {
                sel_insurance = (int)c_insurance_cbx.SelectedValue;
                initCSectorComboBox();
            }
            else
            {
                c_sector_cbx.DataSource = null;
                c_sector_cbx.Enabled = false;
            }
        }
        private void c_sector_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_sector_cbx.SelectedIndex > 0)
            {
                sel_sector = (int)c_sector_cbx.SelectedValue;
                //c_year_cbx.Enabled = true;
                initCYearComboBox();
            }
            else
            {
                c_year_cbx.Enabled = false;
                c_year_cbx.DataSource = null;
            }
        }
        private void c_year_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_year_cbx.SelectedIndex > 0)
            {
                sel_vis_year = (string)c_year_cbx.SelectedValue;
                //c_month_cbx.Enabled = true;
                initCMonthComboBox();
            }
            else
            {
                c_month_cbx.Enabled = false;
                c_month_cbx.DataSource = null;
            }
        }
        private void c_month_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_month_cbx.SelectedIndex > 0)
            {
                sel_vis_month = (string)c_month_cbx.SelectedValue;
                c_next_btn.Enabled = true;
            }
            else
            {
                c_next_btn.Enabled = false;

            }
        }
        private void c_past_tariffs_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (c_past_tariffs_chk.Checked)
            {
                use_past_tariffs = true;
                c_past_flowLayout.Enabled=true;
            }
            else
            {
                use_past_tariffs = false;
                c_past_flowLayout.Enabled = false;
            }
        }

        private void initCProvinceComboBox()
        {
            c_province_data = c_province_adapter.GetAllProvinces();
            PIPDataSet.ProvinceRow c_first_row = c_province_data.NewProvinceRow();
            c_first_row.id = -1;
            c_first_row.name = "--استان--";
            c_province_data.Rows.InsertAt(c_first_row, 0);
            c_province_cbx.DataSource = c_province_data;
            c_province_cbx.DisplayMember = c_province_data.nameColumn.ColumnName;
            c_province_cbx.ValueMember = c_province_data.idColumn.ColumnName;
            c_province_cbx.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_province_cbx);
        }
        private void initCCityComboBox()
        {
            c_city_data = c_city_adapter.GetCitiesOfProvince(sel_province);
            if (c_city_data.Rows.Count > 0)
            {
                PIPDataSet.CityRow c_first_row = c_city_data.NewCityRow();
                c_first_row.id = -1;
                c_first_row.name = "--شهر--";
                c_first_row.province = @sel_province;
                c_city_data.Rows.InsertAt(c_first_row, 0);
                c_city_cbx.DataSource = c_city_data;
                c_city_cbx.DisplayMember = c_city_data.nameColumn.ColumnName;
                c_city_cbx.ValueMember = c_city_data.idColumn.ColumnName;
                c_city_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_city_cbx);
                c_city_cbx.Enabled = true;
            }
        }
        private void initCClinicTypeComboBox()
        {
            c_clinic_type_data = c_clinic_type_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow c_first_row = c_clinic_type_data.NewTClinicTypeRow();
            c_first_row.id = -1;
            c_first_row.name = "--نوع مرکز درمانی--";
            c_clinic_type_data.Rows.InsertAt(c_first_row, 0);
            c_type_cbx.DataSource = c_clinic_type_data;
            c_type_cbx.DisplayMember = c_clinic_type_data.nameColumn.ColumnName;
            c_type_cbx.ValueMember = c_clinic_type_data.idColumn.ColumnName;
            c_type_cbx.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_type_cbx);
            c_type_cbx.Enabled = true;
        }
        private void initCCenterComboBox()
        {
            c_medical_center_adapter.FillByUser(c_medical_center_data, sel_city, sel_center_type, PLConstants.UserCode);
            if (c_medical_center_data.Rows.Count > 0)
            {
                PIPDataSet.SMedicalCenterNameRow c_first_row = c_medical_center_data.NewSMedicalCenterNameRow();
                c_first_row.id = -1;
                c_first_row.name = "--مرکز درمانی--";
                c_medical_center_data.Rows.InsertAt(c_first_row, 0);
                c_center_cbx.DataSource = c_medical_center_data;
                c_center_cbx.DisplayMember = c_medical_center_data.nameColumn.ColumnName;
                c_center_cbx.ValueMember = c_medical_center_data.idColumn.ColumnName;
                c_center_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_center_cbx);
                c_center_cbx.Enabled = true;
            }
        }
        private void initCPartComboBox()
        {
            center_has_part = false;
            c_clinic_part_adapter.FillByUser(c_clinic_part_data, PLConstants.UserCode, sel_center, true, ref center_has_part);
            if (c_clinic_part_data.Rows.Count > 0)
            {
                PIPDataSet.TMedicalCenterPartRow c_first_row = c_clinic_part_data.NewTMedicalCenterPartRow();
                c_first_row.id = -1;
                c_first_row.name = "--بخش درمانی--";
                c_clinic_part_data.Rows.InsertAt(c_first_row, 0);
                c_part_cbx.DataSource = c_clinic_part_data;
                c_part_cbx.DisplayMember = c_clinic_part_data.nameColumn.ColumnName;
                c_part_cbx.ValueMember = c_clinic_part_data.cen_par_seqColumn.ColumnName;
                c_part_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_part_cbx);
            }
            else if ((bool)center_has_part)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_center_part_for_user);
                c_part_cbx.DataSource = null;
            }
            else
            {
                c_part_cbx_SelectedIndexChanged(c_part_cbx, new EventArgs());
            }
        }
        private void initCInsuranceComboBox()
        {
            c_insurance_adapter.FillByUser(c_insurance_data, sel_center, p_sel_part_value, PLConstants.UserCode);
            if (c_insurance_data.Rows.Count > 0)
            {
                PIPDataSet.TInsuranceRow c_first_row = c_insurance_data.NewTInsuranceRow();
                c_first_row.id = -1;
                c_first_row.name = "--بیمه دارای قرارداد--";
                c_insurance_data.Rows.InsertAt(c_first_row, 0);
                c_insurance_cbx.DataSource = c_insurance_data;
                c_insurance_cbx.DisplayMember = c_insurance_data.nameColumn.ColumnName;
                c_insurance_cbx.ValueMember = c_insurance_data.idColumn.ColumnName;
                c_insurance_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_insurance_cbx);
                c_insurance_cbx.Enabled = true;
            }
        }
        private void initCSectorComboBox()
        {
            c_sector_adapter.FillByUser(c_sector_data, sel_center, p_sel_part_value, sel_insurance, PLConstants.UserCode); 
            if (c_sector_data.Rows.Count > 0)
            {
                PIPDataSet.TInsuranceSectorRow c_first_row = c_sector_data.NewTInsuranceSectorRow();
                c_first_row.id = -1;
                c_first_row.name = "--صندوق بیمه دارای قرارداد--";
                c_sector_data.Rows.InsertAt(c_first_row, 0);
                c_sector_cbx.DataSource = c_sector_data;
                c_sector_cbx.DisplayMember = c_sector_data.nameColumn.ColumnName;
                c_sector_cbx.ValueMember = c_sector_data.idColumn.ColumnName;
                c_sector_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_sector_cbx);
                c_sector_cbx.Enabled = true;
            }
        }
        private void initCYearComboBox()
        {
            c_year_adapter.FillByUser(c_year_data, PLConstants.UserCode, sel_center, p_sel_part_value, sel_sector);
            if (c_year_data.Rows.Count > 0)
            {
                PLGlobalFuncs.userYearsForComboBox(c_year_cbx, c_year_data);
                c_year_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_year_cbx);
                c_year_cbx.Enabled = true;
            }
        }
        private void initCMonthComboBox()
        {
            c_month_adapter.FillByUser(c_month_data, PLConstants.UserCode, sel_center, p_sel_part_value, sel_sector, sel_vis_year);
            if (c_month_data.Rows.Count > 0)
            {
                PLGlobalFuncs.userMonthesForComboBox(c_month_cbx, c_month_data);
                c_month_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_month_cbx);
                c_month_cbx.Enabled = true;
            }
        }

        private void c_next_btn_Click(object sender, EventArgs e)
        {
            bool allow_to_next=false;
            if (use_past_tariffs)
            {
                past_tariffs_day = c_past_day_msk.Text;
                past_tariffs_month = c_past_month_msk.Text;
                past_tariffs_year = c_past_year_msk.Text;
                if ((past_tariffs_day != "" && Regex.IsMatch(past_tariffs_day, PLConstants.reg_exact_day_of_date)) ||
                    (past_tariffs_month != "" && Regex.IsMatch(past_tariffs_month, PLConstants.reg_exact_month_of_date)) ||
                    (past_tariffs_year != "" && Regex.IsMatch(past_tariffs_year, PLConstants.reg_exact_year_of_date)))
                {
                    past_date=past_tariffs_year+"/"+past_tariffs_month+"/"+past_tariffs_day;
                    allow_to_next = true;
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_past_tariffs_start_date);
                    allow_to_next = false;
                }
            }
            else
            {
                allow_to_next = true;
            }
            if (allow_to_next)
            {
                s_different_chk.Checked = false;
                main_tabControl.SelectedTab = service_tab;
                center_tab.Enabled = false;
                service_tab.Enabled = true;
                initSCategoryComboBox();
                s_service_grid.CellValueChanged -= s_service_grid_CellValueChanged;
                s_service_grid.CurrentCellDirtyStateChanged -= s_service_grid_CurrentCellDirtyStateChanged;
                if (use_past_tariffs)
                {
                    s_past_tariffs_lbl.Visible = s_past_date_lbl.Visible = true;
                    s_past_date_lbl.Text = "تاریخ شروع خدمت ها: " + past_tariffs_year + "/" + past_tariffs_month + "/" + past_tariffs_day;
                    //tMedicalCenterTariffTableAdapter.FillByInsuranceAndPastTariffs(pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector, past_date);
                    tMedicalCenterTariffTableAdapter.FillByInsuranceAndPastTariffs(s_temp_tariffs, sel_center, sel_insurance, sel_sector, past_date);
                }
                else
                {
                    s_past_tariffs_lbl.Visible = s_past_date_lbl.Visible = false;
                    //tMedicalCenterTariffTableAdapter.FillByInsurance(pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector);
                    tMedicalCenterTariffTableAdapter.FillByInsurance(s_temp_tariffs, sel_center, sel_insurance, sel_sector);
                }
                //if (pIPDataSet.TMedicalCenterTariff.Rows.Count == 0)
                if (s_temp_tariffs.Rows.Count == 0)
                {
                    pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_medical_center_services);
                    s_service_select_all_chk.Visible = false;
                    s_search_btn.Enabled = s_service_grid.Enabled = s_next_btn.Enabled = s_different_chk.Enabled = false;
                }
                else
                {
                    if (s_temp_tariffs.Rows.Count > 100)
                    {
                        s_100_rows_lbl.Visible = true;
                        pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                    }
                    else
                    {
                        s_100_rows_lbl.Visible = false;
                        pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                        pIPDataSet.TMedicalCenterTariff.Merge(s_temp_tariffs);
                    }
                    s_service_select_all_chk.Visible = true;
                    s_search_btn.Enabled = s_service_grid.Enabled = s_next_btn.Enabled = s_different_chk.Enabled = true;
                }
                if (s_service_grid.DataSource == null) { s_service_grid.DataSource = pIPDataSet.TMedicalCenterTariff; }
                if ((sel_insurance != last_insurance) || (sel_center != last_center) || (sel_part != last_part))
                {
                    if (last_insurance > 0)
                    {
                        s_choosed_grid.Rows.Clear();
                        s_table_sel_tariffs.Clear();
                        s_t_just_sel_tariffs.Clear();
                        s_list_sel_tariffs.Clear();
                        s_arrow_lbl.Visible = false;
                        s_EP_choosed_grid.Clear();
                    }
                    last_insurance = sel_insurance;
                    last_center = sel_center;
                    last_part = sel_part;
                }
                else if (s_choosed_grid.Rows.Count > 0)
                {
                    if (sel_sector != last_sector)
                    {
                        bool? are_all_existence = false;
                        DataView dtv_1 = new DataView(s_table_sel_tariffs);
                        DataTable dt = dtv_1.ToTable(false, PLConstants.str_table_col_service_tariff_seq);
                        tMedicalCenterTariffTableAdapter.CheckExistenceOfTariffs((int?)sel_center, (int?)sel_insurance, (int?)sel_sector, dt, ref are_all_existence);
                        if ((bool)are_all_existence)
                        {
                            s_arrow_lbl.Visible = true;
                            s_EP_choosed_grid.SetError(s_arrow_lbl, PLConstants.notice_preses_sectors_services_in_choosed_grid);
                            last_sector = sel_sector;
                        }
                        else
                        {
                            s_choosed_grid.Rows.Clear();
                            s_table_sel_tariffs.Clear();
                            s_t_just_sel_tariffs.Clear();
                            s_list_sel_tariffs.Clear();
                            s_arrow_lbl.Visible = false;
                            s_EP_choosed_grid.Clear();
                        }
                    }
                    else
                    {
                        s_arrow_lbl.Visible = true;
                        s_EP_choosed_grid.SetError(s_arrow_lbl, PLConstants.notice_preses_services_in_choosed_grid);
                    }
                }
                else
                {
                    s_arrow_lbl.Visible = false;
                    s_EP_choosed_grid.Clear();
                }
            }
        }
        private void c_reset_btn_Click(object sender, EventArgs e)
        {
            c_province_cbx.SelectedIndex = 0;
        }

        #endregion CENTER Tab

        ///////////////////////////////////////////////////////////////////////// SERVICE TAB
        #region SERVICE Tab

        private void s_search_btn_Click(object sender, EventArgs e)
        {
            List<string> message_text = new List<string>();
            bool error = false;
            string t_search_name = "";
            string t_search_code = "";
            int t_search_category = -1;
            string t_search_alias = "";
            string t_ins_search_type = PLConstants.enum_tariff_ins_search_type.all.ToString();
            float? t_search_percent = null;

            if (s_category_cbx.SelectedIndex > 0)
            {
                t_search_category = (int)s_category_cbx.SelectedValue;
                t_ins_search_type = s_ins_type_cbx.SelectedValue.ToString();
                if (!Regex.IsMatch(t_search_name = s_name_txt.Text.Trim(), PLConstants.reg_m_service_name_search))
                {
                    error = true;
                    message_text.Add(PLConstants.error_medical_service_name);
                }
                if (!Regex.IsMatch(t_search_alias = s_alias_txt.Text.Trim(), PLConstants.reg_m_service_name_search))
                {
                    error = true;
                    message_text.Add(PLConstants.error_medical_service_name);
                }
                if (!Regex.IsMatch(t_search_code = s_code_txt.Text.Trim(), PLConstants.reg_search_id_10))
                {
                    error = true;
                    message_text.Add(PLConstants.error_id_just_number);
                }
                if (!Regex.IsMatch(s_ins_percent_txt.Text.Trim(), PLConstants.reg_float_code))
                {
                    error = true;
                    message_text.Add(PLConstants.error_numbers_float);
                }
                else if (s_ins_percent_txt.Text.Trim().Length > 0)
                {
                    t_search_percent = Single.Parse(s_ins_percent_txt.Text.Trim());
                }

                s_service_grid.CellValueChanged -= s_service_grid_CellValueChanged;
                s_service_grid.CurrentCellDirtyStateChanged -= s_service_grid_CurrentCellDirtyStateChanged;
                if (error)
                {
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
                }
                //else if (tMedicalCenterTariffTableAdapter.FillBySearchSmall(pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector,
                //    t_search_name, t_search_alias, t_search_code, t_search_category) == 0)
                //{
                //    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                //    s_service_select_all_chk.Visible=s_different_chk.Enabled = false;
                //}
                //else
                //{
                //    s_service_select_all_chk.Visible = s_different_chk.Enabled = true;
                //}
                else
                {
                    //////////////////////////////////////////////////// remove previous searched tariffs from s_table_sel_tariffs
                    s_table_sel_tariffs.Rows.Clear();
                    s_table_sel_tariffs.Merge(s_t_just_sel_tariffs);
                    if (use_past_tariffs)
                    {
                        tMedicalCenterTariffTableAdapter.FillByPastTariffsAndSearchSmall(s_temp_tariffs, sel_center, sel_insurance, sel_sector,
                        t_search_name, t_search_alias, t_search_code, t_search_category, past_date, t_ins_search_type, t_search_percent);
                        //pIPDataSet.TMedicalCenterTariff
                    }
                    else
                    {
                        tMedicalCenterTariffTableAdapter.FillBySearchSmall(s_temp_tariffs, sel_center, sel_insurance, sel_sector,
                        t_search_name, t_search_alias, t_search_code, t_search_category, t_ins_search_type, t_search_percent);
                    }

                    if (s_temp_tariffs.Rows.Count == 0)
                    {
                        pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                        if (s_service_grid.DataSource == null) { s_service_grid.DataSource = pIPDataSet.TMedicalCenterTariff; }
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                        s_service_select_all_chk.Visible = s_different_chk.Enabled = false;
                    }
                    else if (s_temp_tariffs.Rows.Count > 100)
                    {
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.yes_no_question, PLConstants.question_show_more_100_searched_tariffs_records_for_submit);
                        if (pgs_dialog.user_choice == PLConstants.enum_dialog_options.yes)
                        {
                            //s_service_grid.DataBindingComplete -= s_service_grid_DataBindingComplete;
                            s_service_grid.DataSource = null;
                            pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                            pIPDataSet.TMedicalCenterTariff.Merge(s_temp_tariffs);
                            s_service_select_all_chk.Visible = false;
                            //foreach (PIPDataSet.TMedicalCenterTariffRow row in pIPDataSet.TMedicalCenterTariff.Rows)
                            //{
                            //    s_table_sel_tariffs.Rows.Add(row.sequence);
                            //}
                            s_count_lbl.Text = "خدمت های ثابت:" + s_table_sel_tariffs.Rows.Count + "  خدمت های متغیر:" + pIPDataSet.TMedicalCenterTariff.Rows.Count;
                            s_different_chk.Checked = true;
                            s_use_search_chk.Checked = true;
                            s_next_btn_Click(s_next_btn, new EventArgs());
                        }
                        else
                        {
                            if (s_service_grid.DataSource == null) { s_service_grid.DataSource = pIPDataSet.TMedicalCenterTariff; }
                            pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                            pIPDataSet.TMedicalCenterTariff.Merge(s_temp_tariffs);
                            s_service_select_all_chk.Visible = true;
                        }
                        s_different_chk.Enabled = true;
                    }
                    else
                    {
                        pIPDataSet.TMedicalCenterTariff.Rows.Clear();
                        pIPDataSet.TMedicalCenterTariff.Merge(s_temp_tariffs);
                        if (s_service_grid.DataSource == null) { s_service_grid.DataSource = pIPDataSet.TMedicalCenterTariff; }
                        s_service_select_all_chk.Visible = s_different_chk.Enabled = true;
                    }
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_service_category_not_choosed);
            }
        }

        private void s_service_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (s_service_select_all_chk.Checked)
            {
                for (int i = 0; i < s_service_grid.Rows.Count; i++)
                {
                    s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < s_service_grid.Rows.Count; i++)
                {
                    s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value = false;
                }
            }
        }
        private void s_choosed_select_all_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (s_choosed_select_all_chk.Checked)
            {
                for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
                {
                    s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
                {
                    s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value = false;
                }
            }
        }

        private void s_service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (s_service_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(s_service_grid, s_service_select_all_chk);
                s_service_grid.CellValueChanged += s_service_grid_CellValueChanged;
                s_service_grid.CurrentCellDirtyStateChanged += s_service_grid_CurrentCellDirtyStateChanged;
            }
        }
        private void s_service_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (s_service_grid.IsCurrentCellDirty)
            {
                s_service_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void s_service_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(s_service_grid.Rows[e.RowIndex].Cells[s_ser_str_sel_col].Value))
            {
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                s_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }
        
        private void s_choosed_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (s_choosed_grid.Rows.Count > 0)
            {
                PLGlobalFuncs.DGVAfterFilling(s_choosed_grid, s_choosed_select_all_chk);
                s_choosed_grid.CellValueChanged += s_choosed_grid_CellValueChanged;
                s_choosed_grid.CurrentCellDirtyStateChanged += s_choosed_grid_CurrentCellDirtyStateChanged;
            }
        }
        private void s_choosed_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (s_choosed_grid.IsCurrentCellDirty)
            {
                s_choosed_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void s_choosed_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(s_choosed_grid.Rows[e.RowIndex].Cells[s_cho_str_sel_col].Value))
            {
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                s_choosed_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void s_add_ser_btn_Click(object sender, EventArgs e)
        {
            bool has_repetitive = false;
            getSelectedSServices();
            if (s_list_sel_tariffs.Count > 0)
            {
                int national_id_ind = s_national_id_column.Index;
                for (int i = 0; i < s_list_sel_tariffs.Count; i++)
                {
                    if (s_table_sel_tariffs.Select(PLConstants.str_table_col_service_tariff_seq+"=" + s_list_sel_tariffs[i].Value.ToString()).Length > 0)
                    {
                        has_repetitive = true;
                        break;
                    }
                }
                if (has_repetitive)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_repetitive_service);
                }
                else
                {
                    ServiceCountForm count_form = new ServiceCountForm();
                    int count = count_form.getCount();
                    if (count > 0)
                    {
                        s_choosed_grid.CellValueChanged -= s_choosed_grid_CellValueChanged;
                        s_choosed_grid.CurrentCellDirtyStateChanged -= s_choosed_grid_CurrentCellDirtyStateChanged;
                        for (int i = 0; i < s_list_sel_tariffs.Count; i++)
                        {
                            s_table_sel_tariffs.Rows.Add(new object[] { s_list_sel_tariffs[i].Value, count });
                            s_t_just_sel_tariffs.Rows.Add(new object[] { s_list_sel_tariffs[i].Value, count });
                            s_choosed_grid.Rows.Add(new object[] {false, 
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_sequence_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_national_id_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_name_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_alias_name_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_pub_tot_cost_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_pub_ins_sha_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_pub_pat_sha_column.Name].Value,
                                s_service_grid.Rows[s_list_sel_tariffs[i].Key].Cells[s_public_discount.Name].Value,
                                count});
                        }
                        s_choosed_grid_DataBindingComplete(s_choosed_grid, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemAdded));
                    }
                    s_count_lbl.Text = s_table_sel_tariffs.Rows.Count + "خدمت های ثابت: ";
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }
        private void s_delete_ser_btn_Click(object sender, EventArgs e)
        {
            getSelectedSChoosed();
            if (s_list_sel_tariffs.Count > 0)
            {
                s_choosed_grid.CellValueChanged -= s_choosed_grid_CellValueChanged;
                s_choosed_grid.CurrentCellDirtyStateChanged -= s_choosed_grid_CurrentCellDirtyStateChanged;
                for (int i = s_list_sel_tariffs.Count - 1; i >= 0; i--)
                {
                    s_choosed_grid.Rows.RemoveAt(s_list_sel_tariffs[i].Key);
                    s_table_sel_tariffs.Rows.RemoveAt(s_list_sel_tariffs[i].Key);
                    s_t_just_sel_tariffs.Rows.RemoveAt(s_list_sel_tariffs[i].Key);
                }
                s_choosed_grid_DataBindingComplete(s_choosed_grid, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemDeleted));
                s_count_lbl.Text = s_table_sel_tariffs.Rows.Count + "خدمت های ثابت: ";
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void s_different_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (s_different_chk.Checked)
            {
                s_use_search_chk.Enabled = true;
            }
            else
            {
                s_use_search_chk.Enabled = s_use_search_chk.Checked = false;
            }
        }

        private void initSCategoryComboBox()
        {
            s_ser_category_data = s_ser_category_adapter.GetAllCategories();
            PIPDataSet.TMedicalServiceCategoryRow c_first_row = s_ser_category_data.NewTMedicalServiceCategoryRow();
            c_first_row.id = -1;
            c_first_row.name = "--نوع خدمت پزشکی--";
            s_ser_category_data.Rows.InsertAt(c_first_row, 0);
            s_category_cbx.DataSource = s_ser_category_data;
            s_category_cbx.DisplayMember = s_ser_category_data.nameColumn.ColumnName;
            s_category_cbx.ValueMember = s_ser_category_data.idColumn.ColumnName;
            s_category_cbx.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(s_category_cbx);
        }

        private void getSelectedSServices()
        {
            s_list_sel_tariffs.Clear();
            int id_col = s_sequence_column.Index;
            for (int i = 0; i < s_service_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(s_service_grid.Rows[i].Cells[s_ser_str_sel_col].Value))
                {
                    s_list_sel_tariffs.Add(new KeyValuePair<int, long>(i, (long)s_service_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }
        private void getSelectedSChoosed()
        {
            s_list_sel_tariffs.Clear();
            int id_col = s_cho_sequence_column.Index;
            for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
            {
                if (Convert.ToBoolean(s_choosed_grid.Rows[i].Cells[s_cho_str_sel_col].Value))
                {
                    s_list_sel_tariffs.Add(new KeyValuePair<int, long>(i, (long)s_choosed_grid.Rows[i].Cells[id_col].Value));
                }
            }
        }

        private DataTable selectedTariffsToDataTable()
        {
            DataTable s_s_t = new DataTable();
            s_s_t.Columns.Add(PLConstants.str_table_col_entity_id, typeof(long));

            int seq_col = s_cho_sequence_column.Index;

            for (int i = 0; i < s_choosed_grid.Rows.Count; i++)
            {
                s_s_t.Rows.Add((long)s_choosed_grid.Rows[i].Cells[seq_col].Value);
            }
            return s_s_t;
        }

        private void s_previous_btn_Click(object sender, EventArgs e)
        {
            main_tabControl.SelectedTab = center_tab;
            center_tab.Enabled = true;
            service_tab.Enabled = false;
        }
        private void s_next_btn_Click(object sender, EventArgs e)
        {
            bool allow_to_next;
            if (s_table_sel_tariffs.Rows.Count > 0)
            {
                if (!s_different_chk.Checked) { s_status = PLConstants.enum_service_status.Static; }
                else { s_status = PLConstants.enum_service_status.StaticDynamic; }
                allow_to_next = true;
            }
            else
            {
                allow_to_next = s_different_chk.Checked;
                s_status = PLConstants.enum_service_status.Dynamic;
            }

            if (allow_to_next)
            {
                sel_static_services = s_table_sel_tariffs.Copy();
                DataRow[] i_row = c_insurance_data.Select(c_insurance_data.idColumn.ColumnName+"=" + sel_insurance);
                insurance_org = PLEnumFuncs.convertInsuranceTagToEnum((string)i_row[0][c_insurance_data.tagColumn.ColumnName]);

                ///////////////////////////////////////////////////////////////////////// DATA-PARAMETERS
                ////////////////////////////////////////////////////////////////////////////////////////////////////
                p_i_err_cou = p_s_err_cou = p_i_err_cou = p_chk_i_err_cou = p_chk_s_err_cou = 0;
                p_arr_has_error = new bool[pres_items_cou];
                p_arr_is_constant = new bool[pres_items_cou];
                p_editable_info_boxes = new List<Control>();
                p_editable_service_boxes = new List<Control>();
                p_editable_info_boxes.AddRange(new Control[] { p_id_txt,p_serial_txt, p_page_msk, p_fun_doc_id_msk, p_name_txt, p_family_txt, p_exp_day_msk, p_exp_month_msk, p_exp_year_msk, p_pre_doc_msk, p_pre_day_msk, p_pre_month_msk, p_pre_year_msk });
                p_editable_service_boxes.AddRange(new Control[]{p_service_count_msk,p_service_code_msk});
                if (p_data_params_adapter.FillByClinicType(p_data_params_data, sel_center_type, p_sel_part_value, sel_insurance, sel_sector) > 0)
                {
                    p_id_chk.Checked = p_serial_chk.Checked = p_page_chk.Checked = p_fun_doc_chk.Checked = p_name_chk.Checked =
                    p_family_chk.Checked = p_exp_chk.Checked = p_pre_doc_chk.Checked = p_pre_date_chk.Checked = p_count_chk.Checked =
                    p_service_code_chk.Checked = false;

                    p_params_row = (PIPDataSet.PrescriptionDataParametersRow)p_data_params_data.Rows[0];
                    p_vis_cbx.Enabled = p_params_row.p_visit_date;
                    p_arr_is_constant[p_ind_vis_day] = !p_params_row.p_visit_date;
                    if (p_params_row.p_visit_date)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_vis_day] = true;
                    }

                    p_id_txt.Enabled = p_id_txt.TabStop = p_id_chk.Enabled = p_params_row.p_id;
                    p_arr_is_constant[p_ind_insured_id] = !p_params_row.p_id;
                    if (p_params_row.p_id)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_insured_id] = true;
                    }
                    else
                    {
                        p_editable_info_boxes.Remove(p_id_txt);
                    }

                    p_serial_txt.Enabled = p_serial_txt.TabStop = p_serial_chk.Enabled = p_params_row.p_serial;
                    p_arr_is_constant[p_ind_serial] = !p_params_row.p_serial;
                    if (p_params_row.p_serial)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_serial] = true;
                        var_get_serial_func = new var_get_serial_del(getSerial);
                        var_get_identifier_func = new var_get_identifier_del(getInsuredCodeForIdentifier);
                    }
                    else
                    {
                        p_editable_info_boxes.Remove(p_serial_txt);
                        if (p_params_row.serial_include_id)
                        {
                            var_get_serial_func = new var_get_serial_del(getSerialFromInsuredCode);
                            var_get_identifier_func = new var_get_identifier_del(getIdentifierPartOfInsuredCode);
                        }
                        else
                        {
                            sel_pres_serial = null;
                            var_get_serial_func = new var_get_serial_del(getSerial);
                            var_get_identifier_func = new var_get_identifier_del(getInsuredCodeForIdentifier);
                        }
                    }

                    p_page_msk.Enabled = p_page_msk.TabStop = p_page_chk.Enabled = p_params_row.p_page_number;
                    p_arr_is_constant[p_ind_page] = !p_params_row.p_page_number;
                    if (p_params_row.p_page_number)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_page] = true;
                    }
                    else
                    {
                        p_editable_info_boxes.Remove(p_page_msk);
                        sel_page = null;
                    }

                    p_fun_doc_id_msk.Enabled = p_fun_doc_id_msk.TabStop = p_fun_doc_cbx.Enabled = p_fun_doc_chk.Enabled = p_params_row.p_functor_doctor;
                    p_arr_is_constant[p_ind_fun_doctor] = !p_params_row.p_functor_doctor;
                    initPFunctorDoctorComboBox();
                    if (p_params_row.p_functor_doctor)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_fun_doctor] = true;
                    }
                    else
                    {
                        p_fun_doc_cbx.SelectedIndex = 1;
                        getMedicalIDOfFunctorDoctorFromBox();
                        p_editable_info_boxes.Remove(p_fun_doc_id_msk);
                    }

                    p_name_txt.Enabled = p_name_txt.TabStop = p_name_chk.Enabled = p_params_row.p_name;
                    p_arr_is_constant[p_ind_insured_name] = !p_params_row.p_name;
                    if (p_params_row.p_name)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_insured_name] = true;
                    }
                    else
                    {
                        p_editable_info_boxes.Remove(p_name_txt);
                    }

                    p_family_txt.Enabled = p_family_txt.TabStop = p_family_chk.Enabled = p_params_row.p_family_name;
                    p_arr_is_constant[p_ind_insured_family] = !p_params_row.p_family_name;
                    if (p_params_row.p_family_name)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_insured_family] = true;
                    }
                    else
                    {
                        p_editable_info_boxes.Remove(p_family_txt);
                    }

                    p_exp_flow.Enabled = p_exp_day_msk.TabStop = p_exp_month_msk.TabStop = p_exp_year_msk.TabStop = p_exp_chk.Enabled = p_params_row.p_expiration_date;
                    p_arr_is_constant[p_ind_exp_date] = !p_params_row.p_expiration_date;
                    if (p_params_row.p_expiration_date)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_exp_date] = true;
                        org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfo);
                    }
                    else
                    {
                        p_is_exp_date_constant = true;
                        if (insurance_org != PLConstants.enum_insurances.TaminEjtemaei)
                        {
                            sel_exp_day = PLGlobalFuncs.getDaysCountOfMonth(sel_vis_month);
                            sel_exp_month = sel_vis_month;
                            sel_exp_year = sel_vis_year;
                        }
                        org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfoWithoutExpiration);
                        p_editable_info_boxes.Remove(p_exp_day_msk);
                        p_editable_info_boxes.Remove(p_exp_month_msk);
                        p_editable_info_boxes.Remove(p_exp_year_msk);
                    }

                    p_pre_doc_msk.Enabled = p_pre_doc_msk.TabStop = p_pre_doc_chk.Enabled = p_params_row.p_prescriptor_doctor;
                    p_arr_is_constant[p_ind_prescriptor_doctor] = !p_params_row.p_prescriptor_doctor;
                    if (p_params_row.p_prescriptor_doctor)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_prescriptor_doctor] = true;
                        var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor);
                    }
                    else
                    {
                        var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor_empty);
                        p_editable_info_boxes.Remove(p_pre_doc_msk);
                    }

                    p_pre_date_flow.Enabled = p_pre_day_msk.TabStop = p_pre_month_msk.TabStop = p_pre_year_msk.TabStop = p_pre_date_chk.Enabled = p_params_row.p_service_date;
                    p_arr_is_constant[p_ind_prescriptor_date] = !p_params_row.p_service_date;
                    if (p_params_row.p_service_date)
                    {
                        p_chk_i_err_cou++;
                        p_arr_has_error[p_ind_prescriptor_date] = true;
                        var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay);
                        var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth);
                        var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear);
                    }
                    else
                    {
                        var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay_empty);
                        var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth_empty);
                        var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear_empty);
                        p_editable_info_boxes.Remove(p_pre_day_msk);
                        p_editable_info_boxes.Remove(p_pre_month_msk);
                        p_editable_info_boxes.Remove(p_pre_year_msk);
                    }

                    p_service_count_msk.Enabled = p_service_count_msk.TabStop = p_count_chk.Enabled = p_params_row.p_service_count;
                    p_arr_is_constant[p_ind_service_count] = !p_params_row.p_service_count;
                    if (p_params_row.p_service_count)
                    {
                        p_chk_s_err_cou++;
                        p_arr_has_error[p_ind_service_count] = true;
                    }
                    else
                    {
                        sel_service_count = 1;
                        p_editable_service_boxes.Remove(p_service_count_msk);
                    }

                    p_service_code_msk.Enabled = p_service_code_msk.TabStop = p_service_code_chk.Enabled = p_params_row.p_service_code;
                    p_arr_is_constant[p_ind_service_code] = !p_params_row.p_service_code;
                    if (p_params_row.p_service_code)
                    {
                        p_chk_s_err_cou++;
                        p_arr_has_error[p_ind_service_code] = true;
                    }

                    ////////////////////////////////////////////////////////////////// INSURANCE-DELEGATES
                    ////////////////////////////////////////////////////////////////////////////////////////////////////

                    switch (insurance_org)
                    {
                        case PLConstants.enum_insurances.Salamat:
                            p_id_max_length = PLConstants.len_Salamat_code;
                            p_id_regex_str = PLConstants.reg_pre_id_Salamat;
                            p_id_txt.KeyPress -= p_id_KeyPressHandler;
                            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_DashDigit);
                            p_id_txt.KeyPress += p_id_KeyPressHandler;
                            org_get_insured_info_func = new ORG_get_insured_info_del(getSalamatInsuredInfo);
                            org_get_service_exist_func = new ORG_get_service_exist_del(getSalamatInsuredServiceExist);
                            org_save_info_exist_func = new ORG_save_info_exist_del(saveSalamat_Complete_exist);
                            org_save_info_new_func = new ORG_save_info_new_del(saveSalamat_Complete_new);
                            org_save_service_func = new ORG_save_service_del(saveSalamatService);
                            org_delete_service_func = new ORG_delete_service_del(deleteSalamat_Pres_service);
                            break;
                        case PLConstants.enum_insurances.TaminEjtemaei:
                            p_id_max_length = PLConstants.len_TaminEjtemaei_pre_code;
                            p_id_regex_str = PLConstants.reg_pre_id_TaminEjtemaei;
                            p_id_txt.KeyPress -= p_id_KeyPressHandler;
                            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
                            p_id_txt.KeyPress += p_id_KeyPressHandler;
                            org_get_insured_info_func = new ORG_get_insured_info_del(getTaminEjtemaeiInsuredInfo);
                            org_get_service_exist_func = new ORG_get_service_exist_del(getTaminEjtemaeiInsuredServiceExist);
                            org_save_info_exist_func = new ORG_save_info_exist_del(saveTaminEjtemaei_Complete_exist);
                            org_save_info_new_func = new ORG_save_info_new_del(saveTaminEjtemaei_Complete_new);
                            org_save_service_func = new ORG_save_service_del(saveTaminEjtemaeiService);
                            org_delete_service_func = new ORG_delete_service_del(deleteTaminEjtemaei_Pres_service);
                            setting_page_number_func = new setting_page_number_del(setTaminEjtemaei_page_number);
                            break;
                        case PLConstants.enum_insurances.NirooMosalah:
                            p_id_max_length = PLConstants.len_NirooMosalah_code;
                            p_id_regex_str = PLConstants.reg_pre_id_NirooMosalah;
                            p_id_txt.KeyPress -= p_id_KeyPressHandler;
                            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
                            p_id_txt.KeyPress += p_id_KeyPressHandler;
                            org_get_insured_info_func = new ORG_get_insured_info_del(getNirooMosalahInsuredInfo);
                            org_get_service_exist_func = new ORG_get_service_exist_del(getNirooMosalahInsuredServiceExist);
                            org_save_info_exist_func = new ORG_save_info_exist_del(saveNirooMosalah_Complete_exist);
                            org_save_info_new_func = new ORG_save_info_new_del(saveNirooMosalah_Complete_new);
                            org_save_service_func = new ORG_save_service_del(saveNirooMosalahService);
                            org_delete_service_func = new ORG_delete_service_del(deleteNirooMosalah_Pres_service);
                            break;
                        case PLConstants.enum_insurances.KomitehEmdad:
                            p_id_max_length = PLConstants.len_KomitehEmdad_code;
                            p_id_regex_str = PLConstants.reg_pre_id_KomitehEmdad;
                            p_id_txt.KeyPress -= p_id_KeyPressHandler;
                            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
                            p_id_txt.KeyPress += p_id_KeyPressHandler;
                            if (c_sector_data.Rows.Count == 1)
                            {
                                org_get_insured_info_func = new ORG_get_insured_info_del(getOneSectorKomitehEmdadInsuredInfo);
                                if (p_params_row.p_expiration_date)
                                {
                                    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfoOneSector);
                                }
                                else
                                {
                                    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfoOneSectorWithoutExpiration);
                                }
                            }
                            else
                            {
                                org_get_insured_info_func = new ORG_get_insured_info_del(getKomitehEmdadInsuredInfo);
                            }
                            org_get_service_exist_func = new ORG_get_service_exist_del(getKomitehEmdadInsuredServiceExist);
                            org_save_info_exist_func = new ORG_save_info_exist_del(saveKomitehEmdad_Complete_exist);
                            org_save_info_new_func = new ORG_save_info_new_del(saveKomitehEmdad_Complete_new);
                            org_save_service_func = new ORG_save_service_del(saveKomitehEmdadService);
                            org_delete_service_func = new ORG_delete_service_del(deleteKomitehEmdad_Pres_service);
                            break;
                        case PLConstants.enum_insurances.Other:
                            p_id_max_length = PLConstants.len_max_id_20;
                            p_id_regex_str = PLConstants.reg_pre_id_Other;
                            p_serial_regex_str = PLConstants.reg_id;
                            p_id_txt.KeyPress -= p_id_KeyPressHandler;
                            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_DashSlashDigit);
                            p_id_txt.KeyPress += p_id_KeyPressHandler;
                            if (c_sector_data.Rows.Count == 1)
                            {
                                org_get_insured_info_func = new ORG_get_insured_info_del(getOneSectorOtherInsuredInfo);
                                if (p_params_row.p_expiration_date)
                                {
                                    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfoOneSector);
                                }
                                else
                                {
                                    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfoOneSectorWithoutExpiration);
                                }
                            }
                            else
                            {
                                org_get_insured_info_func = new ORG_get_insured_info_del(getOtherInsuredInfo);
                            }
                            org_get_service_exist_func = new ORG_get_service_exist_del(getOtherInsuredServiceExist);
                            if (p_params_row.serial_include_id || p_params_row.p_serial)
                            {
                                org_save_info_exist_func = new ORG_save_info_exist_del(saveV2Other_Complete_exist);
                                org_save_info_new_func = new ORG_save_info_new_del(saveV2Other_Complete_new);
                            }
                            else
                            {
                                org_save_info_exist_func = new ORG_save_info_exist_del(saveOther_Complete_exist);
                                org_save_info_new_func = new ORG_save_info_new_del(saveOther_Complete_new);
                            }
                            org_save_service_func = new ORG_save_service_del(saveOtherService);
                            org_delete_service_func = new ORG_delete_service_del(deleteOther_Pres_service);
                            other_ins_org = PLEnumFuncs.convertOtherInsurancesTagToEnum((string)i_row[0][c_insurance_data.tagColumn.ColumnName]);
                            if (other_ins_org == PLConstants.enum_other_insurances.BankTejarat)
                            {
                                org_get_insured_info_func = new ORG_get_insured_info_del(getTejaratInsuredInfo);
                                setting_page_number_func = new setting_page_number_del(setTejarat_page_number);
                            }
                            break;
                    }
                    p_id_txt.MaxLength = p_id_max_length;
                    org_set_service_exist_func = new ORG_set_service_exist_del(setORGInsuredServiceExist);

                    ///////////////////////////////////////////////// SERVICE STATUS based on STATIC or DYNAMIC
                    //////////////////////////////////////////////////////////////////////////////
                    if (s_status == PLConstants.enum_service_status.Static)
                    {
                        // in previous IF based on DataParameters allowed or disallowed and in here based on static for items and grids
                        if (!p_arr_is_constant[p_ind_service_count])
                        {
                            p_arr_is_constant[p_ind_service_count] = true;
                            p_chk_s_err_cou--;
                        }
                        if (!p_arr_is_constant[p_ind_service_code])
                        {
                            p_arr_is_constant[p_ind_service_code] = true;
                            p_chk_s_err_cou--;
                        }
                        p_service_count_msk.Enabled = p_count_chk.Enabled = p_service_count_msk.TabStop = false;
                        p_service_code_msk.Enabled = p_service_code_msk.TabStop = p_service_code_chk.Enabled = false;
                        p_desel_ser_btn.Enabled = p_all_service_grid.Enabled = false;
                        p_desel_ser_btn.TabStop = p_selected_service_grid.TabStop = p_all_service_grid.TabStop = false;
                        p_finish_btn.Enabled = false;
                        p_info_submit_btn.Click -= p_info_submit_btn_Click_DYNAMIC_ver;
                        p_info_submit_btn.Click -= p_info_submit_btn_Click_STATIC_ver;// double static -+ because maybe last use was static
                        p_info_submit_btn.Click += p_info_submit_btn_Click_STATIC_ver;
                        p_ser_submit_btn.Enabled = false;
                    }
                    else
                    {
                        p_ser_submit_btn.Enabled = true;
                        p_service_code_chk.Enabled = false;
                        // in previous IF based on DataParameters allowed or disallowed and in here based on dynamic for grids
                        p_desel_ser_btn.Enabled = p_selected_service_grid.Enabled = p_all_service_grid.Enabled = true;
                        p_desel_ser_btn.TabStop = p_selected_service_grid.TabStop = p_all_service_grid.TabStop = true;
                        p_finish_btn.Enabled = true;
                        p_info_submit_btn.Click -= p_info_submit_btn_Click_DYNAMIC_ver;
                        p_info_submit_btn.Click -= p_info_submit_btn_Click_STATIC_ver;
                        p_info_submit_btn.Click += p_info_submit_btn_Click_DYNAMIC_ver;// double dynamic -+ because maybe last use was dynamic
                        if (s_status == PLConstants.enum_service_status.Dynamic)
                        {
                            switch (insurance_org)
                            {
                                case PLConstants.enum_insurances.Salamat:
                                    org_save_info_exist_func = new ORG_save_info_exist_del(saveSalamat_Info_exist);
                                    org_save_info_new_func = new ORG_save_info_new_del(saveSalamat_Info_new);
                                    break;
                                case PLConstants.enum_insurances.TaminEjtemaei:
                                    org_save_info_exist_func = new ORG_save_info_exist_del(saveTaminEjtemaei_Info_exist);
                                    org_save_info_new_func = new ORG_save_info_new_del(saveTaminEjtemaei_Info_new);
                                    break;
                                case PLConstants.enum_insurances.NirooMosalah:
                                    org_save_info_exist_func = new ORG_save_info_exist_del(saveNirooMosalah_Info_exist);
                                    org_save_info_new_func = new ORG_save_info_new_del(saveNirooMosalah_Info_new);
                                    break;
                                case PLConstants.enum_insurances.KomitehEmdad:
                                    org_save_info_exist_func = new ORG_save_info_exist_del(saveKomitehEmdad_Info_exist);
                                    org_save_info_new_func = new ORG_save_info_new_del(saveKomitehEmdad_Info_new);
                                    break;
                                case PLConstants.enum_insurances.Other:
                                    if (p_params_row.serial_include_id || p_params_row.p_serial)
                                    {
                                        org_save_info_exist_func = new ORG_save_info_exist_del(saveV2Other_Info_exist);
                                        org_save_info_new_func = new ORG_save_info_new_del(saveV2Other_Info_new);
                                    }
                                    else
                                    {
                                        org_save_info_exist_func = new ORG_save_info_exist_del(saveOther_Info_exist);
                                        org_save_info_new_func = new ORG_save_info_new_del(saveOther_Info_new);
                                    }
                                    break;
                            }
                        }
                    }

                    //////////////////////////////////////////////////////////////////////// P_CHK_ERR_COU
                    ////////////////////////////////////////////////////////////////////////////////////////////////////
                    p_i_err_cou = p_chk_i_err_cou;
                    p_s_err_cou = p_chk_s_err_cou;

                    //////////////////////////////////////////////////////// SERVICE GRID for PRESCRIPTION 
                    /////////////////////////////////////////////////////////////////////////////////
                    p_all_service_grid.CellValueChanged -= p_all_ser_grid_CellValueChanged;
                    p_all_service_grid.CurrentCellDirtyStateChanged -= p_all_ser_grid_CurrentCellDirtyStateChanged;
                    DataView dtv_1 = new DataView(s_table_sel_tariffs);
                    DataTable dt = dtv_1.ToTable(false, PLConstants.str_table_col_service_tariff_seq);
                    p_all_service_grid.DataSource = null;
                    //if (s_use_search_chk.Checked)
                    //{
                    //    DataView sea_view = new DataView(pIPDataSet.TMedicalCenterTariff);
                    //    DataTable sea_tariffs = sea_view.ToTable(false, pIPDataSet.TMedicalCenterTariff.sequenceColumn.ColumnName);
                    //    if (tMedicalCenterTariffTableAdapter.FillBySome(p_pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector, sea_tariffs, dt)==0)
                    //    {
                    //        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_not_dynamic_service);
                    //    }
                    //}
                    //else if (tMedicalCenterTariffTableAdapter.FillByInsuranceNotAll(p_pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector, dt) == 0)
                    //{
                    //    if (s_status != PLConstants.enum_service_status.Static)
                    //    {
                    //        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_not_dynamic_service);
                    //    }
                    //}
                    //if (p_pIPDataSet.TMedicalCenterTariff.Rows.Count>0)
                    //{
                    //    p_table_service_code = new PIPDataSet.ComboMCTASDataTable();
                    //    int plusplus = 0;
                    //    foreach (PIPDataSet.TMedicalCenterTariffRow row in p_pIPDataSet.TMedicalCenterTariff)
                    //    {
                    //        p_table_service_code.Rows.Add(row.national_id + " - " + row.name + " - " + row.public_insurance_share.ToString("N0"), row.sequence, row.national_id, plusplus);
                    //        p_table_service_code.Rows.Add(row.national_id + " - " + row.name + " - " + row.public_insurance_share.ToString("N0"), row.sequence, row.shortcut_code.ToString(), plusplus++);
                    //    }
                    //    DataView dtv_2 = new DataView(p_table_service_code);
                    //    dtv_2.Sort = p_table_service_code.search_valueColumn.ColumnName + " ASC";
                    //    initPServiceCodeComboBox();
                    //}

                    if (s_use_search_chk.Checked)
                    {
                        DataView sea_view = new DataView(pIPDataSet.TMedicalCenterTariff);
                        DataTable sea_tariffs = sea_view.ToTable(false, pIPDataSet.TMedicalCenterTariff.sequenceColumn.ColumnName);
                        if (tMedicalCenterTariffTableAdapter.FillBySome(p_pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector, sea_tariffs, dt) == 0)
                        {
                            pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_not_dynamic_service);
                        }
                    }
                    else if (s_status != PLConstants.enum_service_status.Static)
                    {
                        if (tMedicalCenterTariffTableAdapter.FillByInsuranceNotAll(p_pIPDataSet.TMedicalCenterTariff, sel_center, sel_insurance, sel_sector, dt) == 0)
                        {
                            pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_not_dynamic_service);
                        }
                    }
                    if (p_pIPDataSet.TMedicalCenterTariff.Rows.Count > 0 && s_status != PLConstants.enum_service_status.Static)
                    {
                        p_table_service_code = new PIPDataSet.ComboMCTASDataTable();
                        int plusplus = 0;
                        foreach (PIPDataSet.TMedicalCenterTariffRow row in p_pIPDataSet.TMedicalCenterTariff)
                        {
                            p_table_service_code.Rows.Add(row.national_id + " - " + row.name + " - " + row.public_insurance_share.ToString("N0"), row.sequence, row.national_id, plusplus);
                            p_table_service_code.Rows.Add(row.national_id + " - " + row.name + " - " + row.public_insurance_share.ToString("N0"), row.sequence, row.shortcut_code.ToString(), plusplus++);
                        }
                        DataView dtv_2 = new DataView(p_table_service_code);
                        dtv_2.Sort = p_table_service_code.search_valueColumn.ColumnName + " ASC";
                        initPServiceCodeComboBox();
                    }

                    ///////////////////////////////////////////////////////////////////// COSTS LABELS and STATIC GRID for PRESCRIPTION 
                    /////////////////////////////////////////////////////////////////////////////////

                    s_static_total_cost = s_static_ins_share = s_static_pat_share = 0;
                    s_static_service_count = sel_static_services.Rows.Count;
                    p_selected_service_grid.Rows.Clear();
                    for (int i = 0; i < s_static_service_count; i++)
                    {
                        p_temp_int = (int)s_choosed_grid.Rows[i].Cells[s_cho_count_column.Index].Value;
                        s_static_total_cost += ((int)s_choosed_grid.Rows[i].Cells[s_cho_cost_column.Index].Value) * p_temp_int;
                        s_static_ins_share += ((int)s_choosed_grid.Rows[i].Cells[s_cho_insurance_column.Index].Value) * p_temp_int;
                        s_static_pat_share += ((int)s_choosed_grid.Rows[i].Cells[s_cho_patient_column.Index].Value) * p_temp_int;
                        p_selected_service_grid.Rows.Add(new object[] {false, 
                                s_choosed_grid.Rows[i].Cells[s_cho_sequence_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_national_id_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_name_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_alias_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_cost_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_insurance_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_patient_column.Name].Value,
                                s_choosed_grid.Rows[i].Cells[s_cho_discount_column.Name].Value,
                                p_temp_int});
                        p_selected_service_grid.Rows[i].HeaderCell.Value = (i + 1).ToString();
                        p_selected_service_grid.Rows[i].ReadOnly = true;
                    }
                    p_tot_value_lbl.Text = s_static_total_cost.ToString("N0");
                    p_ins_share_value_lbl.Text = s_static_ins_share.ToString("N0");
                    p_pat_share_value_lbl.Text = s_static_pat_share.ToString("N0");
                    p_dynamic_service_count = s_static_service_count;
                    /////////////////////////////////////////////////////////////////////////////////  
                    /////////////////////////////////////////////////////////////////////////////////
                    PLGlobalFuncs.daysForComboBox(p_vis_cbx, int.Parse(sel_vis_month));
                    p_visit_day_form = new VisitDayForm(int.Parse(sel_vis_month));
                    p_other_sectors_lnk.Visible = p_has_service_lnk.Visible = false;
                    //initPFunctorDoctorComboBox();
                    searchForFirstInfoControl();
                    searchForFirstServiceControl();
                    resetAfterInfoSave();
                    
                    p_i_err_cou++;//because -1 in resetAfterInfoSave
                    p_vis_cbx.BackColor = Color.Red;
                    EP_p_vis.SetError(p_vis_cbx, PLConstants.error_pres_vis_day);
                    
                    resetAfterServiceSave();
                    ////////////
                    prescription_tab.Enabled = true;
                    service_tab.Enabled = false;
                    main_tabControl.SelectedTab = prescription_tab;
                    main_tabControl.Refresh();
                    p_vis_cbx.Select();

                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_no_data_parameters);
                }
                p_ins_sec_lbl.Text = c_insurance_cbx.Text + " - " + c_sector_cbx.Text + " - " + c_center_cbx.Text + " - " + c_part_cbx.Text + " - " + c_month_cbx.Text + " " + c_year_cbx.Text;
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_not_static_dynamic_service);
            }
        }

        #endregion SERVICE Tab

        ///////////////////////////////////////////////////////////////////////// PRESCRIPTION TAB
        #region PRESCRIPTION Tab

        ///////////////////////////////////////////////////////////////////////// Prescription GLOBAL METHODS
        /////////////////////////////////////////////////////////////////////////
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (main_tabControl.SelectedTab == prescription_tab)
            {
                if (keyData == (Keys.Control | Keys.A))
                {
                    p_visit_day_form.ShowDialog();
                    if (p_visit_day_form.selected_day != null)
                    {
                        p_vis_cbx.SelectedValue = p_visit_day_form.selected_day;
                    }
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.S))
                {
                    p_finish_btn_Click(p_finish_btn, new EventArgs());
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void default_control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == enter_char)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        public bool isIranianLetter(char ch)
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
            else if (input_year >= 1390 && input_year <= 1499)
            {
                output_year = input_year.ToString();
                return true;
            }
            else
            {
                output_year = "";
                return false;
            }
        }
        private void initPFunctorDoctorComboBox()
        {
            // in procedure based on value of sel_part search returns different values
            if (p_center_doctor_adapter.FillByPartAndUser(p_center_doctor_data, PLConstants.UserCode, sel_center, p_sel_part_value, sel_sector, sel_vis_year, sel_vis_month) > 0)
            {
                PIPDataSet.SMedicalCenterPartDoctorRow d_first_row = p_center_doctor_data.NewSMedicalCenterPartDoctorRow();
                d_first_row.medical_id = -1;
                d_first_row.title = "--پزشک های مرکز در بخش انتخاب شده--";
                p_center_doctor_data.Rows.InsertAt(d_first_row, 0);
                p_fun_doc_cbx.DataSource = p_center_doctor_data;
                p_fun_doc_cbx.DisplayMember = p_center_doctor_data.titleColumn.ColumnName;
                p_fun_doc_cbx.ValueMember = p_center_doctor_data.medical_idColumn.ColumnName;
                p_fun_doc_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(p_fun_doc_cbx);
            }
        }
        private void initPServiceCodeComboBox()
        {
            // in procedure based on value of sel_part search returns different values
            if (p_table_service_code.Rows.Count > 0)
            {
                PIPDataSet.ComboMCTASRow s_first_row = p_table_service_code.NewComboMCTASRow();
                s_first_row.search_value = -1;
                s_first_row.index = -1;
                s_first_row.name = "--خدمت های مرکز--";
                p_table_service_code.Rows.InsertAt(s_first_row, 0);
                p_service_code_cbx.DataSource = p_table_service_code;
                p_service_code_cbx.DisplayMember = p_table_service_code.nameColumn.ColumnName;
                p_service_code_cbx.ValueMember = p_table_service_code.search_valueColumn.ColumnName;
                p_service_code_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(p_service_code_cbx);
            }
        }
        private void resetAfterInfoSave()
        {
            p_i_err_cou = p_chk_i_err_cou - 1;//except visit day
            for (p_temp_int = 0; p_temp_int < p_editable_info_boxes.Count; p_temp_int++)
            {
                p_editable_info_boxes[p_temp_int].Text = "";
            }
            for (p_temp_int = 1; p_temp_int < pres_info_items_cou; p_temp_int++)//except visit day
            {
                if (!p_arr_is_constant[p_temp_int])
                {
                    p_arr_has_error[p_temp_int] = true;
                    p_arr_error_providers[p_temp_int].SetError(p_arr_controls[p_temp_int], p_arr_error_text[p_temp_int]);
                }
            }
        }
        private void resetAfterServiceSave()
        {
            p_s_err_cou = p_chk_s_err_cou;
            for (p_temp_int = 0; p_temp_int < p_editable_service_boxes.Count; p_temp_int++)
            {
                p_editable_service_boxes[p_temp_int].Text = "";
            }
            for (p_temp_int = pres_info_items_cou; p_temp_int < pres_info_items_cou+pres_ser_items_cou; p_temp_int++)
            {
                if (!p_arr_is_constant[p_temp_int])
                {
                    p_arr_has_error[p_temp_int] = true;
                    p_arr_error_providers[p_temp_int].SetError(p_arr_controls[p_temp_int], p_arr_error_text[p_temp_int]);
                }
            }
        }
        private void searchForFirstInfoControl()
        {
            if (!p_arr_is_constant[p_ind_insured_id])
            {
                p_starter_info_control = p_id_txt;
                return;
            }
            if (!p_arr_is_constant[p_ind_serial])
            {
                p_starter_info_control = p_serial_txt;
                return;
            }
            if (!p_arr_is_constant[p_ind_page])
            {
                p_starter_info_control = p_page_msk;
                return;
            }
            if (!p_arr_is_constant[p_ind_fun_doctor])
            {
                p_starter_info_control = p_fun_doc_id_msk;
                return;
            }
            if (!p_arr_is_constant[p_ind_insured_name])
            {
                p_starter_info_control = p_name_txt;
                return;
            }
            if (!p_arr_is_constant[p_ind_insured_family])
            {
                p_starter_info_control = p_family_txt;
                return;
            }
            if (!p_arr_is_constant[p_ind_exp_date])
            {
                p_starter_info_control = p_exp_day_msk;
                return;
            }
            if (!p_arr_is_constant[p_ind_prescriptor_doctor])
            {
                p_starter_info_control = p_pre_doc_msk;
                return;
            }
            if (!p_arr_is_constant[p_ind_prescriptor_date])
            {
                p_starter_info_control = p_pre_day_msk;
                return;
            }
        }
        private void searchForFirstServiceControl()
        {
            if (!p_arr_is_constant[p_ind_service_count])
            {
                p_starter_service_control = p_service_count_msk;
                return;
            }
            if (!p_arr_is_constant[p_ind_service_code])
            {
                p_starter_service_control = p_service_code_msk;
                return;
            }
        }
        private int P_CHK_S_ERR_COU
        {
            set
            {
                if (value == 0)
                {
                    switch (insurance_org)
                    {
                        case PLConstants.enum_insurances.Salamat:
                            org_save_info_exist_func -= saveSalamat_Info_exist;
                            org_save_info_exist_func += saveSalamat_Complete_exist;
                            break;
                        case PLConstants.enum_insurances.TaminEjtemaei:
                            org_save_info_exist_func -= saveTaminEjtemaei_Info_exist;
                            org_save_info_exist_func += saveTaminEjtemaei_Complete_exist;
                            break;
                        case PLConstants.enum_insurances.NirooMosalah:
                            org_save_info_exist_func -= saveNirooMosalah_Info_exist;
                            org_save_info_exist_func += saveNirooMosalah_Complete_exist;
                            break;
                        case PLConstants.enum_insurances.KomitehEmdad:
                            break;
                        case PLConstants.enum_insurances.Other:
                            break;
                    }
                    p_info_submit_btn.Text = p_sta_sub_info_str;
                    p_finish_btn.Enabled = p_finish_btn.TabStop = false;
                }
                else if ((p_chk_s_err_cou == 0) && (value == 1))
                {
                    switch (insurance_org)
                    {
                        case PLConstants.enum_insurances.Salamat:
                            org_save_info_exist_func += saveSalamat_Info_exist;
                            org_save_info_exist_func -= saveSalamat_Complete_exist;
                            break;
                        case PLConstants.enum_insurances.TaminEjtemaei:
                            org_save_info_exist_func += saveTaminEjtemaei_Info_exist;
                            org_save_info_exist_func -= saveTaminEjtemaei_Complete_exist;
                            break;
                        case PLConstants.enum_insurances.NirooMosalah:
                            org_save_info_exist_func += saveNirooMosalah_Info_exist;
                            org_save_info_exist_func -= saveNirooMosalah_Complete_exist;
                            break;
                        case PLConstants.enum_insurances.KomitehEmdad:
                            break;
                        case PLConstants.enum_insurances.Other:
                            break;
                    }
                    p_info_submit_btn.Text = p_sub_info_str;
                    p_finish_btn.Enabled = p_finish_btn.TabStop = true;
                }
                p_chk_s_err_cou = value;
            }
            get
            {
                return p_chk_s_err_cou;
            }
        }
        ///////////////////////////////////////////////////////////////////////// Prescription VISIT DAY
        /////////////////////////////////////////////////////////////////////////
        private void p_vis_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_vis_cbx.SelectedIndex > 0)
            {
                sel_vis_day = p_vis_cbx.SelectedValue.ToString();
                if (p_arr_has_error[p_ind_vis_day])
                {
                    p_arr_has_error[p_ind_vis_day] = false;
                    p_i_err_cou--;
                    p_vis_cbx.BackColor = Color.White;
                    EP_p_vis.Clear();
                }
            }
            else if (!p_arr_has_error[p_ind_vis_day])
            {
                p_arr_has_error[p_ind_vis_day] = true;
                p_i_err_cou++;
                p_vis_cbx.BackColor = Color.Red;
                EP_p_vis.SetError(p_vis_cbx, PLConstants.error_pres_vis_day);
            }
        }
        ///////////////////////////////////////////////////////////////////////// Prescription INSURED ID
        /////////////////////////////////////////////////////////////////////////
        private void p_id_txt_KeyPress_for_DashDigit(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar==dash_char)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == enter_char)
            {
                SendKeys.Send("{TAB}");
            }
            else if(ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift || ModifierKeys == Keys.Alt || e.KeyChar==(char)Keys.Tab ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void p_id_txt_KeyPress_for_Digit(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == enter_char)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift || ModifierKeys == Keys.Alt || e.KeyChar == (char)Keys.Tab ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void p_id_txt_KeyPress_for_DashSlashDigit(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == dash_char || e.KeyChar==slash_char)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == enter_char)
            {
                SendKeys.Send("{TAB}");
            }
            else if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift || ModifierKeys == Keys.Alt || e.KeyChar == (char)Keys.Tab ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void p_id_txt_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(sel_insured_code=p_id_txt.Text,p_id_regex_str))
            {
                if (!p_insured_info_worker.IsBusy)
                {
                    p_process_insured_exist_checking = p_process_service_exist_checking = true;
                    p_insured_info_worker.RunWorkerAsync();
                }
                if (p_arr_has_error[p_ind_insured_id])
                {
                    p_arr_has_error[p_ind_insured_id] = false;
                    p_i_err_cou--;
                    p_id_txt.BackColor = Color.White;
                    EP_p_id.Clear();
                }
            }
            else if (!p_arr_has_error[p_ind_insured_id])
            {
                p_arr_has_error[p_ind_insured_id] = true;
                p_i_err_cou++;
                p_id_txt.BackColor = Color.Red;
                EP_p_id.SetError(p_id_txt, PLConstants.error_id);
            }
        }
        private void p_insured_info_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            p_insured_sequence = -1;
            org_get_insured_info_func();
        }
        private void getNirooMosalahInsuredInfo()
        {
            p_insured_data_adapter.Get_NirooMosalah_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
        }
        private void getTaminEjtemaeiInsuredInfo()
        {
            sel_insured_identifier = sel_insured_code.Substring(0, PLConstants.len_national_code);
            p_insured_data_adapter.Get_TaminEjemaei_InsuredInfo(sel_sector, sel_insured_identifier, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
            Invoke(setting_page_number_func);
        }
        private void getSalamatInsuredInfo()
        {
            p_insured_data_adapter.Get_Salamat_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
        }
        private void getKomitehEmdadInsuredInfo()
        {
            p_insured_data_adapter.Get_KomitehEmdad_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
        }
        private void getOneSectorKomitehEmdadInsuredInfo()
        {
            p_insured_data_adapter.Get_KomitehEmdad_OneSector_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year);
        }
        private void getOtherInsuredInfo()
        {
            sel_insured_identifier = sel_insured_code;
            p_insured_data_adapter.Get_Other_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
        }
        private void getOneSectorOtherInsuredInfo()
        {
            sel_insured_identifier = sel_insured_code;
            p_insured_data_adapter.Get_Other_OneSector_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year);
        }
        private void getTejaratInsuredInfo()
        {
            if (sel_insured_code.Length >= PLConstants.len_min_Tejarat_code)
            {
                sel_insured_identifier = sel_insured_code.Substring(0, sel_insured_code.Length-PLConstants.len_Tejarat_other_part);
                p_insured_data_adapter.Get_Other_InsuredInfo(sel_sector, sel_insured_identifier, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
                page_reset = false;
            }
            else
            {
                sel_insured_identifier = sel_insured_code;
                p_insured_data_adapter.Get_Other_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
                sel_page = null;
                page_reset = true;
            }
            Invoke(setting_page_number_func);
        }
        private void p_insured_info_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(org_set_insured_info_func);
            if (!p_insured_service_exist_worker.IsBusy)
            {
                p_insured_service_exist_worker.RunWorkerAsync();
            }
        }
        private void setORGInsuredInfo()
        {
            if ((p_insured_sequence != null) && (p_insured_sequence > -1))
            {
                p_is_insured_exist = true;
                p_name_txt.Text = sel_insured_name;
                p_family_txt.Text = sel_insured_family;
                p_exp_day_msk.Text = sel_exp_day = p_previous_exp_day;
                p_exp_month_msk.Text = sel_exp_month = p_previous_exp_month;
                p_exp_year_msk.Text = sel_exp_year = p_previous_exp_year;
                p_name_txt_Leave(p_name_txt, new EventArgs());
                p_family_txt_Leave(p_family_txt, new EventArgs());
                p_exp_flow_Leave(p_exp_flow, new EventArgs());
                p_name_txt.Enabled = p_family_txt.Enabled = false;
            }
            else
            {
                p_is_insured_exist = false;
                p_name_txt.Enabled = p_family_txt.Enabled = true;
            }
            p_other_sectors_lnk.Visible = (bool)p_other_sectors_id;
            p_process_insured_exist_checking = false;
        }
        private void setORGInsuredInfoWithoutExpiration()
        {
            if ((p_insured_sequence != null) && (p_insured_sequence > -1))
            {
                p_is_insured_exist = true;
                p_name_txt.Text = sel_insured_name;
                p_family_txt.Text = sel_insured_family;
                p_name_txt_Leave(p_name_txt, new EventArgs());
                p_family_txt_Leave(p_family_txt, new EventArgs());
                p_name_txt.Enabled = p_family_txt.Enabled = false;
            }
            else
            {
                p_is_insured_exist = false;
                p_name_txt.Enabled = p_family_txt.Enabled = true;
                SelectNextControl(p_id_txt, true, true, true, false);
            }
            p_other_sectors_lnk.Visible = (bool)p_other_sectors_id;
            p_process_insured_exist_checking = false;
        }
        private void setORGInsuredInfoOneSector()
        {
            if ((p_insured_sequence != null) && (p_insured_sequence > -1))
            {
                p_is_insured_exist = true;
                p_name_txt.Text = sel_insured_name;
                p_family_txt.Text = sel_insured_family;
                p_exp_day_msk.Text = sel_exp_day = p_previous_exp_day;
                p_exp_month_msk.Text = sel_exp_month = p_previous_exp_month;
                p_exp_year_msk.Text = sel_exp_year = p_previous_exp_year;
                p_name_txt_Leave(p_name_txt, new EventArgs());
                p_family_txt_Leave(p_family_txt, new EventArgs());
                p_exp_flow_Leave(p_exp_flow, new EventArgs());
                p_name_txt.Enabled = p_family_txt.Enabled = false;
            }
            else
            {
                p_is_insured_exist = false;
                p_name_txt.Enabled = p_family_txt.Enabled = true;
            }
            p_process_insured_exist_checking = false;
        }
        private void setORGInsuredInfoOneSectorWithoutExpiration()
        {
            if ((p_insured_sequence != null) && (p_insured_sequence > -1))
            {
                p_is_insured_exist = true;
                p_name_txt.Text = sel_insured_name;
                p_family_txt.Text = sel_insured_family;
                p_name_txt_Leave(p_name_txt, new EventArgs());
                p_family_txt_Leave(p_family_txt, new EventArgs());
                p_name_txt.Enabled = p_family_txt.Enabled = false;
            }
            else
            {
                p_is_insured_exist = false;
                p_name_txt.Enabled = p_family_txt.Enabled = true;
                SelectNextControl(p_id_txt, true, true, true, false);
            }
            p_process_insured_exist_checking = false;
        }
        private void setTaminEjtemaei_page_number()
        {
            p_page_msk.Text = sel_insured_code.Substring(PLConstants.index_TaminEjtemaei_page_number, PLConstants.len_TaminEjtemaei_page_number);
            sel_page = short.Parse(p_page_msk.Text);
        }
        private void setTejarat_page_number()
        {
            if (page_reset)
            {
                p_page_msk.Text = null;
            }
            else
            {
                p_page_msk.Text = sel_insured_code.Substring(sel_insured_code.Length - PLConstants.len_Tejarat_page_number, PLConstants.len_Tejarat_page_number);
                sel_page = short.Parse(p_page_msk.Text);
            }
        }
        private void p_insured_service_exist_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            org_get_service_exist_func();
        }
        private void getNirooMosalahInsuredServiceExist()
        {
            p_insured_data_adapter.Get_NirooMosalah_InsuredServiceExist(sel_center, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, ref p_insured_has_service);
        }
        private void getTaminEjtemaeiInsuredServiceExist()
        {
            p_insured_data_adapter.Get_TaminEjtemaei_InsuredServiceExist(sel_center, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, ref p_insured_has_service);
        }
        private void getSalamatInsuredServiceExist()
        {
            p_insured_data_adapter.Get_Salamat_InsuredServiceExist(sel_center, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, ref p_insured_has_service);
        }
        private void getKomitehEmdadInsuredServiceExist()
        {
            p_insured_data_adapter.Get_KomitehEmdad_InsuredServiceExist(sel_center, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, ref p_insured_has_service);
        }
        private void getOtherInsuredServiceExist()
        {
            p_insured_data_adapter.Get_Other_InsuredServiceExist(sel_center, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, ref p_insured_has_service);
        }
        private void p_insured_service_exist_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(org_set_service_exist_func);
        }
        private void setORGInsuredServiceExist()
        {
            p_has_service_lnk.Visible = (bool)p_insured_has_service;
            p_process_service_exist_checking = false;
        }

        private string getInsuredCodeForIdentifier()
        {
            return sel_insured_code;
        }
        private string getIdentifierPartOfInsuredCode()
        {
            return sel_insured_identifier;
        }
        ///////////////////////////////////////////////////////////////////////// Prescription SERIAL
        /////////////////////////////////////////////////////////////////////////
        private void p_serial_txt_KeyPress_for_Digit(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == enter_char)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift || ModifierKeys == Keys.Alt || e.KeyChar == (char)Keys.Tab ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void p_serial_txt_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(sel_pres_serial = p_serial_txt.Text, p_serial_regex_str))
            {
                if (p_arr_has_error[p_ind_serial])
                {
                    p_arr_has_error[p_ind_serial] = false;
                    p_i_err_cou--;
                    p_serial_txt.BackColor = Color.White;
                    EP_p_serial.Clear();
                }
            }
            else if (!p_arr_has_error[p_ind_serial])
            {
                p_arr_has_error[p_ind_serial] = true;
                p_i_err_cou++;
                p_serial_txt.BackColor = Color.Red;
                EP_p_serial.SetError(p_serial_txt, PLConstants.error_pres_serial);
            }
        }

        private string getSerial()
        {
            return sel_pres_serial;
        }
        private string getSerialFromInsuredCode()
        {
            return sel_insured_code;
        }
        ///////////////////////////////////////////////////////////////////////// Prescription PAGE
        /////////////////////////////////////////////////////////////////////////
        private void p_page_msk_Leave(object sender, EventArgs e)
        {
            p_temp_err_bool = false;
            if (short.TryParse(p_temp_str = p_page_msk.Text.Trim(), out p_temp_short))
            {
                sel_page = p_temp_short;
                if (sel_page <= 0)
                {
                    p_temp_err_bool = true;
                }
            }
            else
            {
                p_temp_err_bool = true;
            }
            if (p_temp_err_bool)
            {
                if (!p_arr_has_error[p_ind_page])
                {
                    p_arr_has_error[p_ind_page] = true;
                    p_i_err_cou++;
                    p_page_msk.BackColor = Color.Red;
                    EP_p_page.SetError(p_page_msk, PLConstants.error_pres_page);
                }
            }
            else if (p_arr_has_error[p_ind_page])
            {
                p_arr_has_error[p_ind_page] = false;
                p_i_err_cou--;
                p_page_msk.BackColor = Color.White;
                EP_p_page.Clear();
            }
        }
        ///////////////////////////////////////////////////////////////////////// Prescription FUNCTOR DOCTOR
        /////////////////////////////////////////////////////////////////////////
        private void p_fun_doc_id_msk_Leave(object sender, EventArgs e)
        {
            getMedicalIDOfFunctorDoctorFromBox();
        }
        private void p_fun_doc_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_fun_doc_cbx.SelectedIndex > 0)
            {
                p_fun_doc_id_msk.Text = p_fun_doc_cbx.SelectedValue.ToString();
            }
            else
            {
                p_fun_doc_id_msk.Text = "";
            }
        }
        private void p_fun_doc_cbx_Leave(object sender, EventArgs e)
        {
            getMedicalIDOfFunctorDoctorFromBox();
        }
        private void getMedicalIDOfFunctorDoctorFromBox()
        {
            p_temp_err_bool = false;
            if (int.TryParse(p_temp_str = p_fun_doc_id_msk.Text.Trim(), out p_temp_int))
            {
                sel_fun_doctor = p_temp_int;
                if (sel_fun_doctor <= 0)
                {
                    p_temp_err_bool = true;
                }
                else
                {
                    p_fun_doc_cbx.SelectedValue = sel_fun_doctor;
                    if (p_fun_doc_cbx.SelectedValue == null)
                    {
                        p_temp_err_bool = true;
                    }
                }
            }
            else
            {
                p_temp_err_bool = true;
            }
            if (p_temp_err_bool)
            {
                p_fun_doc_cbx.SelectedIndex = 0;
                if (!p_arr_has_error[p_ind_fun_doctor])
                {
                    p_arr_has_error[p_ind_fun_doctor] = true;
                    p_i_err_cou++;
                    p_fun_doc_id_msk.BackColor = Color.Red;
                    EP_p_fun_doctor.SetError(p_fun_doc_id_msk, PLConstants.error_pres_fun_doctor);
                }
            }
            else if (p_arr_has_error[p_ind_fun_doctor])
            {
                p_fun_doc_cbx.SelectedValue = sel_fun_doctor;
                p_arr_has_error[p_ind_fun_doctor] = false;
                p_i_err_cou--;
                p_fun_doc_id_msk.BackColor = Color.White;
                EP_p_fun_doctor.Clear();
            }
        }
        ///////////////////////////////////////////////////////////////////////// Prescription INSURED NAMES
        /////////////////////////////////////////////////////////////////////////
        private void p_names_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == enter_char)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
            else if (isIranianLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (ModifierKeys == Keys.Control || ModifierKeys == Keys.Shift || ModifierKeys == Keys.Alt || e.KeyChar == (char)Keys.Tab ||
                e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Home || e.KeyChar == (char)Keys.End)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void p_name_txt_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(sel_insured_name = p_name_txt.Text.Trim(), PLConstants.reg_name))
            {
                if (p_arr_has_error[p_ind_insured_name])
                {
                    p_arr_has_error[p_ind_insured_name] = false;
                    p_i_err_cou--;
                    p_name_txt.BackColor = Color.White;
                    EP_p_name.Clear();
                }
            }
            else
            {
                if (!p_arr_has_error[p_ind_insured_name])
                {
                    p_arr_has_error[p_ind_insured_name] = true;
                    p_i_err_cou++;
                    p_name_txt.BackColor = Color.Red;
                    EP_p_name.SetError(p_name_txt, PLConstants.error_names);
                }
            }
        }
        private void p_family_txt_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(sel_insured_family = p_family_txt.Text.Trim(), PLConstants.reg_name))
            {
                if (p_arr_has_error[p_ind_insured_family])
                {
                    p_arr_has_error[p_ind_insured_family] = false;
                    p_i_err_cou--;
                    p_family_txt.BackColor = Color.White;
                    EP_p_family.Clear();
                }
            }
            else
            {
                if (!p_arr_has_error[p_ind_insured_family])
                {
                    p_arr_has_error[p_ind_insured_family] = true;
                    p_i_err_cou++;
                    p_family_txt.BackColor = Color.Red;
                    EP_p_family.SetError(p_family_txt, PLConstants.error_names);
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////// Prescription EXPIRATION DATE
        /////////////////////////////////////////////////////////////////////////
        private void p_exp_flow_Enter(object sender, EventArgs e)
        {
            p_exp_day_msk.SelectAll();
        }
        private void p_exp_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == enter_char)
            {
                //prescription_tab.SelectNextControl(p_exp_year_msk, true, true, false, false);
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void p_exp_day_msk_TextChanged(object sender, EventArgs e)
       {
            if (p_exp_day_msk.Text.Length == len_2)
            {
                if (Regex.IsMatch(sel_exp_day = p_exp_day_msk.Text, PLConstants.reg_exact_day_of_date))
                {
                    //p_exp_month_msk.SelectAll();
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
                    //p_exp_year_msk.SelectAll();
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
            p_temp_str=p_exp_year_msk.Text.Trim();
            if (int.TryParse(p_temp_str, out p_temp_int))
            {
                if (yearEvaluation(p_temp_int, out sel_exp_year))
                {
                    p_exp_year_msk.Text = sel_exp_year;
                }
            }
        }
        private void p_exp_flow_Leave(object sender, EventArgs e)
        {
            p_temp_err_bool = false;
            if (Regex.IsMatch(sel_exp_day, PLConstants.reg_exact_day_of_date) && Regex.IsMatch(sel_exp_month, PLConstants.reg_exact_month_of_date) && Regex.IsMatch(sel_exp_year, PLConstants.reg_exact_year_of_date))
            {
                if (sel_vis_day != null)
                {
                    if ((sel_exp_year+sel_exp_month+sel_exp_day).CompareTo(sel_vis_year+sel_vis_month+sel_vis_day) >= 0)
                    {
                        p_is_exp_date_changed = !((sel_exp_year == p_previous_exp_year) && (sel_exp_month == p_previous_exp_month) && (sel_exp_day == p_previous_exp_day));
                        if (p_arr_has_error[p_ind_exp_date])
                        {
                            p_arr_has_error[p_ind_exp_date] = false;
                            p_i_err_cou--;
                            p_exp_flow.BackColor = Color.Transparent;
                            EP_p_exp.Clear();
                        }
                    }
                    else if (!p_arr_has_error[p_ind_exp_date])
                    {
                        p_arr_has_error[p_ind_exp_date] = true;
                        p_i_err_cou++;
                        p_exp_flow.BackColor = Color.Red;
                        EP_p_exp.SetError(p_exp_year_msk, PLConstants.error_pres_exp_date_less);
                    }
                    else
                    {
                        p_exp_flow.BackColor = Color.Red;
                        EP_p_exp.SetError(p_exp_year_msk, PLConstants.error_pres_exp_date_less);
                    }
                }
            }
            else if (!p_arr_has_error[p_ind_exp_date])
            {
                p_arr_has_error[p_ind_exp_date] = true;
                p_i_err_cou++;
                p_exp_flow.BackColor = Color.Red;
                EP_p_exp.SetError(p_exp_year_msk, PLConstants.error_date);
            }
        }
        ///////////////////////////////////////////////////////////////////////// Prescription PRESCRIPTOR DOCTOR
        /////////////////////////////////////////////////////////////////////////
        private void p_pre_doc_msk_Leave(object sender, EventArgs e)
        {
            p_temp_err_bool = false;
            if (int.TryParse(p_temp_str = p_pre_doc_msk.Text.Trim(), out p_temp_int))
            {
                sel_prescriptor_doctor = p_temp_int;
                if (sel_prescriptor_doctor <= 0)
                {
                    p_temp_err_bool = true;
                }
            }
            else
            {
                p_temp_err_bool = true;
            }
            if (p_temp_err_bool)
            {
                if (!p_arr_has_error[p_ind_prescriptor_doctor])
                {
                    p_arr_has_error[p_ind_prescriptor_doctor] = true;
                    p_i_err_cou++;
                    p_pre_doc_msk.BackColor = Color.Red;
                    EP_p_pre_doctor.SetError(p_pre_doc_msk, PLConstants.error_id);
                }
            }
            else if (p_arr_has_error[p_ind_prescriptor_doctor])
            {
                p_arr_has_error[p_ind_prescriptor_doctor] = false;
                p_i_err_cou--;
                p_pre_doc_msk.BackColor = Color.White;
                EP_p_pre_doctor.Clear();
            }
        }
        private int? getPrescriptorDoctor()
        {
            return sel_prescriptor_doctor;
        }
        private int? getPrescriptorDoctor_empty()
        {
            return sel_fun_doctor;
        }
        ///////////////////////////////////////////////////////////////////////// Prescription SERVICE DATE
        /////////////////////////////////////////////////////////////////////////
        private void p_pre_date_flow_Enter(object sender, EventArgs e)
        {
            p_pre_day_msk.SelectAll();
        }
        private void p_prescriptor_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == enter_char)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }
        private void p_pre_day_msk_TextChanged(object sender, EventArgs e)
        {
            if (p_pre_day_msk.Text.Length == len_2)
            {
                if (Regex.IsMatch(sel_prescriptor_day = p_pre_day_msk.Text, PLConstants.reg_exact_day_of_date))
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        private void p_pre_day_msk_Leave(object sender, EventArgs e)
        {
            sel_prescriptor_day = p_pre_day_msk.Text;
        }
        private void p_pre_month_msk_TextChanged(object sender, EventArgs e)
        {
            if (p_pre_month_msk.Text.Length == len_2)
            {
                if (Regex.IsMatch(sel_prescriptor_month = p_pre_month_msk.Text, PLConstants.reg_exact_month_of_date))
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }
        private void p_pre_month_msk_Leave(object sender, EventArgs e)
        {
            sel_prescriptor_month = p_pre_month_msk.Text;
        }
        private void p_pre_year_msk_Leave(object sender, EventArgs e)
        {
            p_temp_str = p_pre_year_msk.Text.Trim();
            if (int.TryParse(p_temp_str, out p_temp_int))
            {
                if (yearEvaluation(p_temp_int, out sel_prescriptor_year))
                {
                    p_pre_year_msk.Text = sel_prescriptor_year;
                }
            }
        }
        private void p_pre_date_flow_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(sel_prescriptor_day, PLConstants.reg_exact_day_of_date) && Regex.IsMatch(sel_prescriptor_month, PLConstants.reg_exact_month_of_date) && Regex.IsMatch(sel_prescriptor_year, PLConstants.reg_exact_year_of_date))
            {
                if (sel_vis_day != null)
                {
                    if ((sel_prescriptor_year+sel_prescriptor_month+sel_prescriptor_day).CompareTo(sel_vis_year+sel_vis_month+sel_vis_day) <= 0)
                    {
                        if (p_arr_has_error[p_ind_prescriptor_date])
                        {
                            p_arr_has_error[p_ind_prescriptor_date] = false;
                            p_i_err_cou--;
                            p_pre_date_flow.BackColor = Color.Transparent;
                            EP_p_pre_date.Clear();
                        }
                    }
                    else if (!p_arr_has_error[p_ind_prescriptor_date])
                    {
                        p_arr_has_error[p_ind_prescriptor_date] = true;
                        p_i_err_cou++;
                        p_pre_date_flow.BackColor = Color.Red;
                        EP_p_pre_date.SetError(p_pre_year_msk, PLConstants.error_pres_prescriptor_date_greater);
                    }
                    else
                    {
                        p_pre_date_flow.BackColor = Color.Red;
                        EP_p_pre_date.SetError(p_pre_year_msk, PLConstants.error_pres_prescriptor_date_greater);
                    }
                }
            }
            else if (!p_arr_has_error[p_ind_prescriptor_date])
            {
                p_arr_has_error[p_ind_prescriptor_date] = true;
                p_i_err_cou++;
                p_pre_date_flow.BackColor = Color.Red;
                EP_p_pre_date.SetError(p_pre_year_msk, PLConstants.error_date);
            }
        }

        private string getPrescriptorDay()
        {
            return sel_prescriptor_day;
        }
        private string getPrescriptorMonth()
        {
            return sel_prescriptor_month;
        }
        private string getPrescriptorYear()
        {
            return sel_prescriptor_year;
        }
        private string getPrescriptorDay_empty()
        {
            return sel_vis_day;
        }
        private string getPrescriptorMonth_empty()
        {
            return sel_vis_month;
        }
        private string getPrescriptorYear_empty()
        {
            return sel_vis_year;
        }
        ///////////////////////////////////////////////////////////////////////// Prescription INFO CHECKBOXES
        /////////////////////////////////////////////////////////////////////////
        private void p_id_chk_Click(object sender, EventArgs e)
        {
            if (!p_id_chk.Checked)
            {
                if (p_arr_has_error[p_ind_insured_id])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_id);
                }
                else
                {
                    p_arr_is_constant[p_ind_insured_id] = true;
                    p_id_chk.Checked = true;
                    p_id_txt.Enabled = false;
                    p_editable_info_boxes.Remove(p_id_txt);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_insured_id] = false;
                p_arr_is_constant[p_ind_insured_id] = false;
                p_id_chk.Checked = false;
                p_id_txt.Enabled = true;
                p_editable_info_boxes.Add(p_id_txt);
                p_chk_i_err_cou++;
                searchForFirstInfoControl();
            }
            
        }
        private void p_serial_chk_Click(object sender, EventArgs e)
        {
            if (!p_serial_chk.Checked)
            {
                if (p_arr_has_error[p_ind_serial])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_serial);
                }
                else
                {
                    p_arr_is_constant[p_ind_serial] = true;
                    p_serial_chk.Checked = true;
                    p_serial_txt.Enabled = false;
                    p_editable_info_boxes.Remove(p_serial_txt);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_serial] = false;
                p_arr_is_constant[p_ind_serial] = false;
                p_serial_chk.Checked = false;
                p_serial_txt.Enabled = true;
                p_editable_info_boxes.Add(p_serial_txt);
                p_chk_i_err_cou++;
                searchForFirstInfoControl();
            }

        }
        private void p_page_chk_Click(object sender, EventArgs e)
        {
            if (!p_page_chk.Checked)
            {
                if (p_arr_has_error[p_ind_page])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_page);
                }
                else
                {
                    p_arr_is_constant[p_ind_page] = true;
                    p_page_chk.Checked = true;
                    p_page_msk.Enabled = false;
                    p_editable_info_boxes.Remove(p_page_msk);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_page] = false;
                p_arr_is_constant[p_ind_page] = false;
                p_page_chk.Checked = false;
                p_page_msk.Enabled = true;
                p_editable_info_boxes.Add(p_page_msk);
                p_chk_i_err_cou++;
                searchForFirstInfoControl();
            }
        }
        private void p_fun_doc_chk_Click(object sender, EventArgs e)
        {
            p_temp_err_bool = false;
            if (!p_fun_doc_chk.Checked)
            {
                if (sel_part > 0)
                {
                    if (p_fun_doc_id_msk.Text.Trim() == "")
                    {
                        p_temp_err_bool = false;
                        p_arr_has_error[p_ind_fun_doctor] = false;
                        p_i_err_cou--;
                        p_fun_doc_id_msk.BackColor = Color.White;
                        EP_p_fun_doctor.Clear();
                    }
                    else if (p_arr_has_error[p_ind_fun_doctor])
                    {
                        p_temp_err_bool = true;
                        pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_fun_doctor);
                    }
                    else
                    {
                        p_temp_err_bool = false;
                    }
                }
                else if (p_arr_has_error[p_ind_fun_doctor])
                {
                    p_temp_err_bool = true;
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_fun_doctor);
                }
                else
                {
                    p_temp_err_bool = false;
                }
                if (!p_temp_err_bool)
                {
                    p_arr_is_constant[p_ind_fun_doctor] = true;
                    p_fun_doc_chk.Checked = true;
                    p_fun_doc_cbx.Enabled = p_fun_doc_id_msk.Enabled = false;
                    p_editable_info_boxes.Remove(p_fun_doc_id_msk);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_fun_doctor] = false;
                p_arr_is_constant[p_ind_fun_doctor] = false;
                p_fun_doc_chk.Checked = false;
                p_fun_doc_cbx.Enabled = p_fun_doc_id_msk.Enabled = true;
                p_editable_info_boxes.Add(p_fun_doc_id_msk);
                p_chk_i_err_cou++;
                if (p_fun_doc_id_msk.Text.Trim() == "")
                {
                    p_arr_has_error[p_ind_fun_doctor] = true;
                    p_i_err_cou++;
                    p_fun_doc_id_msk.BackColor = Color.Red;
                    EP_p_fun_doctor.SetError(p_fun_doc_id_msk, PLConstants.error_pres_fun_doctor);
                }
                searchForFirstInfoControl();
            }
        }
        private void p_name_chk_Click(object sender, EventArgs e)
        {
            if (!p_name_chk.Checked)
            {
                if (p_arr_has_error[p_ind_insured_name])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_names);
                }
                else
                {
                    p_arr_is_constant[p_ind_insured_name] = true;
                    p_name_chk.Checked = true;
                    p_name_txt.Enabled = false;
                    p_editable_info_boxes.Remove(p_name_txt);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_insured_name] = false;
                p_arr_is_constant[p_ind_insured_name] = false;
                p_name_chk.Checked = false;
                p_name_txt.Enabled = true;
                p_editable_info_boxes.Add(p_name_txt);
                p_chk_i_err_cou++;
                searchForFirstInfoControl();
            }
        }
        private void p_family_chk_Click(object sender, EventArgs e)
        {
            if (!p_family_chk.Checked)
            {
                if (p_arr_has_error[p_ind_insured_family])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_names);
                }
                else
                {
                    p_arr_is_constant[p_ind_insured_family] = true;
                    p_family_chk.Checked = true;
                    p_family_txt.Enabled = false;
                    p_editable_info_boxes.Remove(p_family_txt);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_insured_family] = false;
                p_arr_is_constant[p_ind_insured_family] = false;
                p_family_chk.Checked = false;
                p_family_txt.Enabled = true;
                p_editable_info_boxes.Add(p_family_txt);
                p_chk_i_err_cou++;
                searchForFirstInfoControl();
            }
        }
        private void p_exp_chk_Click(object sender, EventArgs e)
        {
            if (!p_exp_chk.Checked)
            {
                if (p_arr_has_error[p_ind_exp_date])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_date);
                }
                else
                {
                    p_arr_is_constant[p_ind_exp_date] = true;
                    p_exp_chk.Checked = true;
                    p_exp_flow.Enabled = false;
                    p_editable_info_boxes.Remove(p_exp_day_msk);
                    p_editable_info_boxes.Remove(p_exp_month_msk);
                    p_editable_info_boxes.Remove(p_exp_year_msk);
                    p_chk_i_err_cou--;
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_exp_date] = false;
                p_arr_is_constant[p_ind_exp_date] = false;
                p_exp_chk.Checked = false;
                p_exp_flow.Enabled = true;
                p_editable_info_boxes.Add(p_exp_day_msk);
                p_editable_info_boxes.Add(p_exp_month_msk);
                p_editable_info_boxes.Add(p_exp_year_msk);
                p_chk_i_err_cou++;
                searchForFirstInfoControl();
            }
        }
        private void p_pre_doc_chk_Click(object sender, EventArgs e)
        {
            if (!p_pre_doc_chk.Checked)
            {
                if ((p_pre_doc_msk.Text.Trim() == ""))
                {
                    var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor_empty);
                    p_arr_is_constant[p_ind_prescriptor_doctor] = true;
                    p_pre_doc_chk.Checked = true;
                    p_pre_doc_msk.Enabled = false;
                    p_editable_info_boxes.Remove(p_pre_doc_msk);
                    p_chk_i_err_cou--;
                    if (p_arr_has_error[p_ind_prescriptor_doctor])
                    {
                        p_arr_has_error[p_ind_prescriptor_doctor] = false;
                        p_i_err_cou--;
                        p_pre_doc_msk.BackColor = Color.White;
                        EP_p_pre_doctor.Clear();
                    }
                    searchForFirstInfoControl();
                }
                else if (p_arr_has_error[p_ind_prescriptor_doctor])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_id);
                }
                else
                {
                    p_arr_is_constant[p_ind_prescriptor_doctor] = true;
                    p_pre_doc_chk.Checked = true;
                    p_pre_doc_msk.Enabled = false;
                    p_editable_info_boxes.Remove(p_pre_doc_msk);
                    p_chk_i_err_cou--;
                    var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor);
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_prescriptor_doctor] = false;
                p_arr_is_constant[p_ind_prescriptor_doctor] = false;
                p_pre_doc_chk.Checked = false;
                p_pre_doc_msk.Enabled = true;
                p_editable_info_boxes.Add(p_page_msk);
                p_chk_i_err_cou++;
                var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor);
                if (p_pre_doc_msk.Text.Trim() == "")
                {
                    p_arr_has_error[p_ind_prescriptor_doctor] = true;
                    p_i_err_cou++;
                    p_pre_doc_msk.BackColor = Color.Red;
                    EP_p_pre_doctor.SetError(p_pre_doc_msk, PLConstants.error_id);
                }
                searchForFirstInfoControl();
            }
        }
        private void p_pre_date_chk_Click(object sender, EventArgs e)
        {
            if (!p_pre_date_chk.Checked)
            {
                if ((p_pre_day_msk.Text.Trim() == "") && (p_pre_month_msk.Text.Trim() == "") && (p_pre_year_msk.Text.Trim() == ""))
                {
                    var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay_empty);
                    var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth_empty);
                    var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear_empty);
                    p_arr_is_constant[p_ind_prescriptor_date] = true;
                    p_pre_date_chk.Checked = true;
                    p_pre_date_flow.Enabled = false;
                    p_editable_info_boxes.Remove(p_pre_day_msk);
                    p_editable_info_boxes.Remove(p_pre_month_msk);
                    p_editable_info_boxes.Remove(p_pre_year_msk);
                    p_chk_i_err_cou--;
                    if (p_arr_has_error[p_ind_prescriptor_date])
                    {
                        p_arr_has_error[p_ind_prescriptor_date] = false;
                        p_i_err_cou--;
                        p_pre_date_flow.BackColor = Color.Transparent;
                        EP_p_pre_date.Clear();
                    }
                    searchForFirstInfoControl();
                }
                else if (p_arr_has_error[p_ind_prescriptor_date])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_date);
                }
                else
                {
                    p_arr_is_constant[p_ind_prescriptor_date] = true;
                    p_pre_date_chk.Checked = true;
                    p_pre_date_flow.Enabled = false;
                    p_editable_info_boxes.Remove(p_pre_day_msk);
                    p_editable_info_boxes.Remove(p_pre_month_msk);
                    p_editable_info_boxes.Remove(p_pre_year_msk);
                    p_chk_i_err_cou--;
                    var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay);
                    var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth);
                    var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear);
                    searchForFirstInfoControl();
                }
            }
            else
            {
                p_arr_has_error[p_ind_prescriptor_date] = false;
                p_arr_is_constant[p_ind_prescriptor_date] = false;
                p_pre_date_chk.Checked = false;
                p_pre_date_flow.Enabled = true;
                p_editable_info_boxes.Add(p_pre_day_msk);
                p_editable_info_boxes.Add(p_pre_month_msk);
                p_editable_info_boxes.Add(p_pre_year_msk);
                p_chk_i_err_cou++;
                var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay);
                var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth);
                var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear);
                if ((p_pre_day_msk.Text.Trim() == "") && (p_pre_month_msk.Text.Trim() == "") && (p_pre_year_msk.Text.Trim() == ""))
                {
                    p_arr_has_error[p_ind_prescriptor_date] = true;
                    p_i_err_cou++;
                    p_pre_date_flow.BackColor = Color.Red;
                    EP_p_pre_date.SetError(p_pre_year_msk, PLConstants.error_date);
                }
                searchForFirstInfoControl();
            }
        }
        
        ///////////////////////////////////////////////////////////////////////// Prescription INFO BUTTONS
        /////////////////////////////////////////////////////////////////////////
        private void p_info_clear_btn_Click(object sender, EventArgs e)
        {
            p_vis_cbx.SelectedIndex = 0;
            if (!p_arr_is_constant[p_ind_fun_doctor])
            {
                p_fun_doc_cbx.SelectedIndex = 0;
            }
            for (int i = p_ind_insured_id; i <= p_ind_exp_date; i++)
            {
                if (!p_arr_is_constant[i])
                {
                    p_arr_has_error[i] = true;
                }
            }
            p_i_err_cou = p_chk_i_err_cou;
            foreach (Control i_ct in p_editable_info_boxes)
            {
                i_ct.Text = null;
            }
            p_vis_cbx.Select();
        }
        private void p_info_submit_btn_Click_STATIC_ver(object sender, EventArgs e)
        {
            if (p_i_err_cou > 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_has_error);
            }
            else if(!p_process_insured_exist_checking)
            {
                if (p_is_insured_exist)
                {
                    org_save_info_exist_func();
                }
                else
                {
                    org_save_info_new_func();
                }
                p_pres_op_result = PLEnumFuncs.prescriptionResultToEnum(p_save_info_result);
                switch (p_pres_op_result)
                {
                    case PLConstants.enum_prescription_results.success:
                        p_reception_val_lbl.Text = p_info_save_sequence.ToString();
                        resetAfterInfoSave();
                        p_starter_info_control.Select();
                        break;
                    default:
                        SystemSounds.Beep.Play();
                        pgs_dialog.prescriptionOperationResult(p_pres_op_result);
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_pres_process_info_checking);
            }
        }
        private void p_info_submit_btn_Click_DYNAMIC_ver(object sender, EventArgs e)
        {
            if (p_i_err_cou > 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_has_error);
            }
            else if (!p_process_insured_exist_checking)
            {
                if (p_is_insured_exist)
                {
                    org_save_info_exist_func();
                }
                else
                {
                    org_save_info_new_func();
                }
                p_pres_op_result = PLEnumFuncs.prescriptionResultToEnum(p_save_info_result);
                switch (p_pres_op_result)
                {
                    case PLConstants.enum_prescription_results.success:
                        p_reception_val_lbl.Text = p_info_save_sequence.ToString();
                        p_is_info_saved = true;
                        p_dynamic_service_count = p_dynamic_total_cost = p_dynamic_ins_share = p_dynamic_pat_share = 0;
                        p_info_submit_btn.Enabled = p_info_clear_btn.Enabled = false;
                        p_starter_service_control.Select();
                        break;
                    default:
                        SystemSounds.Beep.Play();
                        pgs_dialog.prescriptionOperationResult(p_pres_op_result);
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_pres_process_info_checking);
            }
        }
        
        private void saveTaminEjtemaei_Info_exist()
        {
            p_prescription_info_adapter.AddTaminEjtemaeiPresInfo_InsuredExist(sel_insurance,(short?)PLConstants.enum_activity_types.AddPrescription,(short?)PLConstants.enum_activity_types.EditInsuredExpiration,sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence,sel_insured_code, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, p_is_exp_date_changed,ref p_save_info_result,ref p_info_save_sequence);
        }
        private void saveTaminEjtemaei_Info_new()
        {
            p_prescription_info_adapter.AddTaminEjtemaeiPresInfo_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured,sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_identifier,sel_insured_code,sel_sector,sel_insured_name,sel_insured_family,sel_vis_day,sel_vis_month,sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveTaminEjtemaei_Complete_exist()
        {
            p_prescription_info_adapter.AddTaminEjtemaeiPresComplete_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence,sel_insured_code, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveTaminEjtemaei_Complete_new()
        {
            p_prescription_info_adapter.AddTaminEjtemaeiPresComplete_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_identifier,sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveNirooMosalah_Info_exist()
        {
            p_prescription_info_adapter.AddNirooMosalahPresInfo_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveNirooMosalah_Info_new()
        {
            p_prescription_info_adapter.AddNirooMosalahPresInfo_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveNirooMosalah_Complete_exist()
        {
            p_prescription_info_adapter.AddNirooMosalahPresComplete_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveNirooMosalah_Complete_new()
        {
            p_prescription_info_adapter.AddNirooMosalahPresComplete_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveSalamat_Info_exist()
        {
            p_prescription_info_adapter.AddSalamatPresInfo_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveSalamat_Info_new()
        {
            p_prescription_info_adapter.AddSalamatPresInfo_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveSalamat_Complete_exist()
        {
            p_prescription_info_adapter.AddSalamatPresComplete_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveSalamat_Complete_new()
        {
            p_prescription_info_adapter.AddSalamatPresComplete_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveKomitehEmdad_Info_exist()
        {
            p_prescription_info_adapter.AddKomitehEmdadPresInfo_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveKomitehEmdad_Info_new()
        {
            p_prescription_info_adapter.AddKomitehEmdadPresInfo_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveKomitehEmdad_Complete_exist()
        {
            p_prescription_info_adapter.AddKomitehEmdadPresComplete_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveKomitehEmdad_Complete_new()
        {
            p_prescription_info_adapter.AddKomitehEmdadPresComplete_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveOther_Info_exist()
        {
            p_prescription_info_adapter.AddOtherPresInfo_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveOther_Info_new()
        {
            p_prescription_info_adapter.AddOtherPresInfo_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveOther_Complete_exist()
        {
            p_prescription_info_adapter.AddOtherPresComplete_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveOther_Complete_new()
        {
            p_prescription_info_adapter.AddOtherPresComplete_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, sel_insured_code, sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveV2Other_Info_exist()
        {
            p_prescription_info_adapter.AddOtherBySerialPresInfo_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, var_get_serial_func(), sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveV2Other_Info_new()
        {
            p_prescription_info_adapter.AddOtherBySerialPresInfo_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, var_get_identifier_func(), var_get_serial_func(), sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveV2Other_Complete_exist()
        {
            p_prescription_info_adapter.AddOtherBySerialPresComplete_InsuredExist(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.EditInsuredExpiration, sel_center, p_sel_part_value, sel_fun_doctor, p_insured_sequence, var_get_serial_func(), sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, p_is_exp_date_changed, ref p_save_info_result, ref p_info_save_sequence);
        }
        private void saveV2Other_Complete_new()
        {
            p_prescription_info_adapter.AddOtherBySerialPresComplete_NewInsured(sel_insurance, (short?)PLConstants.enum_activity_types.AddPrescription, (short?)PLConstants.enum_activity_types.AddInsured, sel_center, p_sel_part_value, sel_fun_doctor, var_get_identifier_func(), var_get_serial_func(), sel_sector, sel_insured_name, sel_insured_family, sel_vis_day, sel_vis_month, sel_vis_year, var_g_p_doc_func(), var_g_p_day_func(), var_g_p_month_func(), var_g_p_year_func(), sel_page, sel_exp_day, sel_exp_month, sel_exp_year, sel_static_services, PLConstants.UserCode, ref p_save_info_result, ref p_info_save_sequence);
        }


        ///////////////////////////////////////////////////////////////////////// Prescription SERVICE COUNT
        /////////////////////////////////////////////////////////////////////////
        private void p_service_count_msk_Leave(object sender, EventArgs e)
        {
            p_temp_err_bool = false;
            if (int.TryParse(p_temp_str = p_service_count_msk.Text.Trim(), out p_temp_int))
            {
                sel_service_count = p_temp_int;
                if (sel_service_count <= 0)
                {
                    p_temp_err_bool = true;
                }
            }
            else
            {
                p_temp_err_bool = true;
            }
            if (p_temp_err_bool)
            {
                if (!p_arr_has_error[p_ind_service_count])
                {
                    p_arr_has_error[p_ind_service_count] = true;
                    p_s_err_cou++;
                    p_service_count_msk.BackColor = Color.Red;
                    EP_p_pre_count.SetError(p_service_count_msk, PLConstants.error_numbers_int);
                }
            }
            else if (p_arr_has_error[p_ind_service_count])
            {
                p_arr_has_error[p_ind_service_count] = false;
                p_s_err_cou--;
                p_service_count_msk.BackColor = Color.White;
                EP_p_pre_count.Clear();
            }
        }

        ///////////////////////////////////////////////////////////////////////// Prescription SERVICE CODE
        /////////////////////////////////////////////////////////////////////////
        private void p_service_code_msk_Leave(object sender, EventArgs e)
        {
            p_service_code_cbx.SelectedValue = p_service_code_msk.Text.Trim();
            getServiceCodeFromBox();
        }
        private void p_service_code_cbx_Leave(object sender, EventArgs e)
        {
            if (p_service_code_cbx.SelectedIndex > 0)
            {
                p_service_code_msk.Text = p_service_code_cbx.SelectedValue.ToString();
            }
            getServiceCodeFromBox();
        }
        private void getServiceCodeFromBox()
        {
            if (p_service_code_cbx.SelectedIndex > 0)
            {
                p_row_service_code = (PIPDataSet.ComboMCTASRow)p_table_service_code.Rows[p_service_code_cbx.SelectedIndex];
                //sel_service_code = p_row_service_code.national_id;
                //sel_shortcut_service_code = p_row_service_code.shortcut_code;
                sel_service_tariff = p_row_service_code.tariff;
                sel_service_index = p_row_service_code.index;
                if (p_arr_has_error[p_ind_service_code])
                {
                    p_arr_has_error[p_ind_service_code] = false;
                    p_s_err_cou--;
                    p_service_code_msk.BackColor = Color.White;
                    EP_p_service_code.Clear();
                }
            }
            else if (!p_arr_has_error[p_ind_service_code])
            {
                p_arr_has_error[p_ind_service_code] = true;
                p_s_err_cou++;
                p_service_code_msk.BackColor = Color.Red;
                EP_p_service_code.SetError(p_service_code_msk, PLConstants.error_pres_service_code);
            }
        }

        ///////////////////////////////////////////////////////////////////////// Prescription SERVICE CHECKBOXES
        /////////////////////////////////////////////////////////////////////////
        private void p_count_chk_Click(object sender, EventArgs e)
        {
            if (!p_count_chk.Checked)
            {
                if (p_arr_has_error[p_ind_service_count])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_service_count);
                }
                else
                {
                    p_arr_is_constant[p_ind_service_count] = true;
                    p_count_chk.Checked = true;
                    p_service_count_msk.Enabled = false;
                    p_editable_service_boxes.Remove(p_service_count_msk);
                    p_chk_s_err_cou--;
                    searchForFirstServiceControl();
                }
            }
            else
            {
                p_arr_is_constant[p_ind_service_count] = false;
                p_count_chk.Checked = false;
                p_service_count_msk.Enabled = true;
                p_editable_service_boxes.Add(p_service_count_msk);
                p_chk_s_err_cou++;
                searchForFirstServiceControl();
            }
        }
        private void p_service_code_chk_Click(object sender, EventArgs e)
        {
            if (!p_service_code_chk.Checked)
            {
                if (p_arr_has_error[p_ind_service_code])
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_service_code);
                }
                else
                {
                    p_arr_is_constant[p_ind_service_code] = true;
                    p_service_code_chk.Checked = true;
                    p_service_code_msk.Enabled = false;
                    p_editable_service_boxes.Remove(p_service_code_msk);
                    p_chk_s_err_cou--;
                    searchForFirstServiceControl();
                }
            }
            else
            {
                p_arr_is_constant[p_ind_service_code] = false;
                p_service_code_chk.Checked = false;
                p_service_code_msk.Enabled = true;
                p_editable_service_boxes.Add(p_service_code_msk);
                p_chk_s_err_cou++;
                searchForFirstServiceControl();
            }
        }

        ///////////////////////////////////////////////////////////////////////// Prescription SERVICE BUTTONS
        /////////////////////////////////////////////////////////////////////////
        private void p_ser_clear_btn_Click(object sender, EventArgs e)
        {

        }
        private void p_ser_submit_btn_Click(object sender, EventArgs e)
        {
            if (p_s_err_cou > 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_has_error);
            }
            else if (p_is_info_saved)
            {
                org_save_service_func();
                p_service_op_result = PLEnumFuncs.prescriptionResultToEnum(p_save_service_result);
                switch (p_service_op_result)
                {
                    case PLConstants.enum_prescription_results.success:
                        addDynamicServiceToSelectedGrid();
                        resetAfterServiceSave();
                        p_starter_service_control.Select();
                        break;
                    default:
                        SystemSounds.Beep.Play();
                        pgs_dialog.prescriptionOperationResult(p_service_op_result);
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.error_pres_info_not_saved);
            }
        }

        private void saveTaminEjtemaeiService()
        {
            p_pres_service_adapter.AddTaminEjtemaeiPresService(p_info_save_sequence, sel_service_tariff, sel_service_count, ref p_save_service_result);
        }
        private void saveNirooMosalahService()
        {
            p_pres_service_adapter.AddNirooMosalahPresService(p_info_save_sequence, sel_service_tariff, sel_service_count, ref p_save_service_result);
        }
        private void saveSalamatService()
        {
            p_pres_service_adapter.AddSalamatPresService(p_info_save_sequence, sel_service_tariff, sel_service_count, ref p_save_service_result);
        }
        private void saveOtherService()
        {
            p_pres_service_adapter.AddOtherPresService(p_info_save_sequence, sel_service_tariff, sel_service_count, ref p_save_service_result);
        }
        private void saveKomitehEmdadService()
        {
            p_pres_service_adapter.AddKomitehEmdadPresService(p_info_save_sequence, sel_service_tariff, sel_service_count, ref p_save_service_result);
        }

        private void addDynamicServiceToSelectedGrid()
        {
            p_selected_service_grid.CellValueChanged -= p_selected_service_grid_CellValueChanged;
            p_selected_service_grid.CurrentCellDirtyStateChanged -= p_selected_service_grid_CurrentCellDirtyStateChanged;
            
            p_temp_int = (int)sel_service_count;
            p_row_tariff = (PIPDataSet.TMedicalCenterTariffRow)p_pIPDataSet.TMedicalCenterTariff.Rows[sel_service_index];
            p_dynamic_service_count++;
            p_dynamic_total_cost += p_row_tariff.public_total_cost * p_temp_int;
            p_dynamic_ins_share += p_row_tariff.public_insurance_share * p_temp_int;
            p_dynamic_pat_share += p_row_tariff.public_patient_share * p_temp_int;

            sel_all_service_count = s_static_service_count + p_dynamic_service_count;
            p_tot_value_lbl.Text = (sel_tot_price_val = p_dynamic_total_cost + s_static_total_cost).ToString("N0");
            p_ins_share_value_lbl.Text = (sel_ins_share_val = p_dynamic_ins_share + s_static_ins_share).ToString("N0");
            p_pat_share_value_lbl.Text = (sel_pat_share_val = p_dynamic_pat_share + s_static_pat_share).ToString("N0");

            p_selected_service_grid.Rows.Add(false,
                            p_row_tariff.sequence,
                            p_row_tariff.national_id,
                            p_row_tariff.name,
                            p_row_tariff.alias_name,
                            p_row_tariff.public_total_cost,
                            p_row_tariff.public_insurance_share,
                            p_row_tariff.public_patient_share,
                            p_row_tariff.public_discount,
                            sel_service_count);
            p_selected_service_grid.Rows[sel_all_service_count - 1].HeaderCell.Value = (sel_all_service_count).ToString();

            p_selected_service_grid.CellValueChanged += p_selected_service_grid_CellValueChanged;
            p_selected_service_grid.CurrentCellDirtyStateChanged += p_selected_service_grid_CurrentCellDirtyStateChanged;
        }

        ///////////////////////////////////////////////////////////////////////// Selected Services DATAGRID
        /////////////////////////////////////////////////////////////////////////
        private void p_selected_service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (p_selected_service_grid.Rows.Count > 0)
            {
                afterPSelectedServiceGridFilled();
                p_selected_service_grid.CellValueChanged += p_selected_service_grid_CellValueChanged;
                p_selected_service_grid.CurrentCellDirtyStateChanged += p_selected_service_grid_CurrentCellDirtyStateChanged;
            }
        }
        private void p_selected_service_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (p_selected_service_grid.IsCurrentCellDirty)
            {
                p_selected_service_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void p_selected_service_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(p_selected_service_grid.Rows[e.RowIndex].Cells[p_sel_str_sel_col].Value))
            {
                p_selected_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                p_selected_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                p_selected_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                p_selected_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }

        private void p_selected_select_all_chk_CheckedChanged(object sender, EventArgs e)//checked
        {
            if (p_selected_select_all_chk.Checked)
            {
                for (int i = s_static_service_count; i < p_selected_service_grid.Rows.Count; i++)
                {
                    p_selected_service_grid.Rows[i].Cells[p_sel_str_sel_col].Value = true;
                }
            }
            else
            {
                for (int i = s_static_service_count; i < p_selected_service_grid.Rows.Count; i++)
                {
                    p_selected_service_grid.Rows[i].Cells[p_sel_str_sel_col].Value = false;
                }
            }
        }
        private void getSelectedPSelServices()
        {
            p_list_sel_tariffs.Clear();
            int seq_col = p_sel_sequence_column.Index;
            for (int i = s_static_service_count; i < sel_all_service_count; i++)
            {
                if (Convert.ToBoolean(p_selected_service_grid.Rows[i].Cells[p_sel_str_sel_col].Value))
                {
                    p_list_sel_tariffs.Add(new KeyValuePair<int, long>(i, (long)p_selected_service_grid.Rows[i].Cells[seq_col].Value));
                }
            }
        }
        private DataTable selectedPSelServicesToDataTable()
        {
            DataTable s_s_t = PLGlobalFuncs.emptyLongIDsDataTable();
            foreach (KeyValuePair<int, long> t_id in p_list_sel_tariffs)
            {
                s_s_t.Rows.Add(t_id.Value);
            }
            return s_s_t;
        }

        private void afterPSelectedServiceGridFilled()
        {
            PLGlobalFuncs.dataGridViewAfterFilling(p_selected_service_grid, p_selected_select_all_chk);
            PLGlobalFuncs.createAllCheckBoxForDataGridView(p_selected_service_grid, p_selected_select_all_chk);

            for (int i = 0; i < p_selected_service_grid.Rows.Count; i++)
            {
                p_selected_service_grid.Rows[i].Cells[p_sel_str_sel_col].Value = false;
            }
        }

        private void p_desel_ser_btn_Click(object sender, EventArgs e)
        {
            getSelectedPSelServices();
            if (p_list_sel_tariffs.Count > 0)
            {
                org_delete_service_func();
                p_delete_service_op_result = PLEnumFuncs.presServiceResultToEnum(p_delete_service_result);
                switch (p_delete_service_op_result)
                {
                    case PLConstants.enum_prescription_results.success:
                        DataGridViewRow dgv_row;
                        for (int i = p_list_sel_tariffs.Count - 1; i >= 0; i--)
                        {
                            dgv_row = p_selected_service_grid.Rows[p_list_sel_tariffs[i].Key];
                            p_temp_int = (int)dgv_row.Cells[p_sel_count_column.Name].Value;
                            p_dynamic_total_cost -= ((int)dgv_row.Cells[p_sel_cost_column.Name].Value) * p_temp_int;
                            p_dynamic_ins_share -= ((int)dgv_row.Cells[p_sel_insurance_column.Name].Value) * p_temp_int;
                            p_dynamic_pat_share -= ((int)dgv_row.Cells[p_sel_patient_column.Name].Value) * p_temp_int;
                            p_selected_service_grid.Rows.RemoveAt(p_list_sel_tariffs[i].Key);
                        }
                        p_tot_value_lbl.Text = (sel_tot_price_val = p_dynamic_total_cost + s_static_total_cost).ToString("N0");
                        p_ins_share_value_lbl.Text = (sel_ins_share_val = p_dynamic_ins_share + s_static_ins_share).ToString("N0");
                        p_pat_share_value_lbl.Text = (sel_pat_share_val = p_dynamic_pat_share + s_static_pat_share).ToString("N0");
                        sel_all_service_count = s_static_service_count + (p_dynamic_service_count -= p_list_sel_tariffs.Count);
                        p_selected_service_grid_DataBindingComplete(p_selected_service_grid, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemDeleted));
                        break;
                    default:
                        pgs_dialog.prescriptionOperationResult(p_delete_service_op_result);
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_nothing_selected);
            }
        }

        private void deleteSalamat_Pres_service()
        {
            p_pres_service_adapter.DeleteSalamat_PresService(sel_insurance,(short?)PLConstants.enum_activity_types.DeletePresService,PLConstants.UserCode,p_info_save_sequence, selectedPSelServicesToDataTable(), ref p_delete_service_result);
        }
        private void deleteTaminEjtemaei_Pres_service()
        {
            p_pres_service_adapter.DeleteTaminEjtemaei_PresService(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_info_save_sequence, selectedPSelServicesToDataTable(), ref p_delete_service_result);
        }
        private void deleteNirooMosalah_Pres_service()
        {
            p_pres_service_adapter.DeleteNirooMosalah_PresService(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_info_save_sequence, selectedPSelServicesToDataTable(), ref p_delete_service_result);
        }
        private void deleteKomitehEmdad_Pres_service()
        {
            p_pres_service_adapter.DeleteKomitehEmdad_PresService(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_info_save_sequence, selectedPSelServicesToDataTable(), ref p_delete_service_result);
        }
        private void deleteOther_Pres_service()
        {
            p_pres_service_adapter.DeleteOther_PresService(sel_insurance, (short?)PLConstants.enum_activity_types.DeletePresService, PLConstants.UserCode, p_info_save_sequence, selectedPSelServicesToDataTable(), ref p_delete_service_result);
        }

        ///////////////////////////////////////////////////////////////////////// All Services DATAGRID
        /////////////////////////////////////////////////////////////////////////
        private void p_all_ser_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)//checked
        {
            if (p_all_service_grid.Rows.Count > 0)
            {
                afterPAllServicesGridFilled();
                p_all_service_grid.CellValueChanged += p_all_ser_grid_CellValueChanged;
                p_all_service_grid.CurrentCellDirtyStateChanged += p_all_ser_grid_CurrentCellDirtyStateChanged;
            }
        }
        private void p_all_ser_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (p_all_service_grid.IsCurrentCellDirty)
            {
                p_all_service_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void p_all_ser_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToBoolean(p_all_service_grid.Rows[e.RowIndex].Cells[p_all_str_sel_col].Value))
            {
                p_all_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                p_all_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                p_all_service_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                p_all_service_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.ControlText;
            }
        }
        private void afterPAllServicesGridFilled()
        {
            PLGlobalFuncs.dataGridViewAfterFilling(p_all_service_grid, p_all_select_all_chk);
            for (int i = 0; i < p_all_service_grid.Rows.Count; i++)
            {
                p_all_service_grid.Rows[i].Cells[p_all_str_sel_col].Value = false;
            }
        }

        ///////////////////////////////////////////////////////////////////////// Prescription HELPER INFO LINKS
        /////////////////////////////////////////////////////////////////////////
        private void p_other_sectors_lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (insurance_org == PLConstants.enum_insurances.TaminEjtemaei)
            {
                p_other_sectors_form.showWithData(insurance_org, c_insurance_cbx.Text, c_sector_cbx.Text, sel_insured_identifier);
            }
            else
            {
                p_other_sectors_form.showWithData(insurance_org, c_insurance_cbx.Text, c_sector_cbx.Text, sel_insured_code);
            }
        }
        
        private void p_has_service_lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            p_other_services_form.showWithData(insurance_org, c_insurance_cbx.Text, c_sector_cbx.Text, (long)p_insured_sequence, sel_insured_code + " - " + sel_insured_name + " " + sel_insured_family, (int)sel_center, c_center_cbx.Text, sel_vis_day, sel_vis_month, sel_vis_year);
        }
        
        ///////////////////////////////////////////////////////////////////////// Prescription PREVIOUS BUTTON
        /////////////////////////////////////////////////////////////////////////
        private void p_previous_btn_Click(object sender, EventArgs e)
        {
            main_tabControl.SelectedTab = service_tab;
            service_tab.Enabled = true;
            prescription_tab.Enabled = false;
        }

        ///////////////////////////////////////////////////////////////////////// Prescription FINISH BUTTON
        /////////////////////////////////////////////////////////////////////////
        private void p_finish_btn_Click(object sender, EventArgs e)
        {
            if (p_dynamic_service_count > 0)
            {
                resetAfterInfoSave();
                if (s_status != PLConstants.enum_service_status.Static)
                {
                    resetAfterServiceSave();
                    if (s_status == PLConstants.enum_service_status.Dynamic)
                    {
                        p_selected_service_grid.Rows.Clear();
                    }
                    else
                    {
                        for (p_temp_int = s_static_service_count; p_temp_int < sel_all_service_count; p_temp_int++)
                        {
                            p_selected_service_grid.Rows.RemoveAt(p_temp_int);
                        }
                    }
                }
                p_starter_info_control.Select();
                p_info_submit_btn.Enabled = p_info_clear_btn.Enabled = true;
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_no_dynamic_service);
            }
        }

        #endregion PRESCRIPTION TAB

    }
}
