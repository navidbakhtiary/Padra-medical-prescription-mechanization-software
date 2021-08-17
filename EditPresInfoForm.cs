using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.Media;

namespace PadraInsurancePrescription
{
    public partial class EditPresInfoForm : Form
    {
        //////////////////////////////////////////////////////////////////// PUBLIC VARIABLES
        enum tab_enum { center, prescription };
        char dash_char = '-';
        char slash_char = '/';
        int len_2 = 2, len_4 = 4, pres_items_cou = 10, pres_info_items_cou = 10;
        char enter_char = (char)Keys.Enter;
        bool? center_has_part;

        PGSDialog pgs_dialog;
        PLConstants.enum_data_operation form_operation;
        bool were_actions_successeded = false;
        bool is_batch;
        bool is_first_load = true;

        PLConstants.enum_activity_types insured_activity;

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
        PLConstants.enum_insurances insurance_org;
        PLConstants.enum_other_insurances other_ins_org;
        int first_sector;

        //////////////////////////////////////////////////////////////////// PRESCRIPTION VARIABLES
        SearchedInsuredForm p_other_sectors_form;

        int p_i_err_cou;
        int p_chk_i_err_cou;
        bool[] p_arr_has_error;
        ErrorProvider[] p_arr_error_providers;
        string[] p_arr_error_text;
        Control[] p_arr_controls;

        int p_ind_vis_day = 0, p_ind_insured_id = 1, p_ind_serial = 2, p_ind_page = 3, p_ind_fun_doctor = 4, p_ind_insured_name = 5, p_ind_insured_family = 6, p_ind_exp_date = 7,
            p_ind_prescriptor_doctor = 8, p_ind_prescriptor_date = 9;

        string p_id_regex_str, p_serial_regex_str;
        int p_id_max_length;
        KeyPressEventHandler p_id_KeyPressHandler;

        bool p_process_insured_exist_checking, p_is_insured_exist, p_is_insured_empty;
        long? p_insured_sequence;
        bool? p_other_sectors_id;
        bool p_is_exp_date_changed;
        string p_previous_exp_day, p_previous_exp_month, p_previous_exp_year;

        bool page_reset;

        int? p_sel_part_value;
        string p_save_info_result;
        PLConstants.enum_prescription_results p_pres_op_result;

        PIPDataSetTableAdapters.SInsuredDataTableAdapter p_insured_data_adapter;
        PIPDataSetTableAdapters.SMedicalCenterPartDoctorTableAdapter p_center_doctor_adapter;
        PIPDataSetTableAdapters.PrescriptionDataParametersTableAdapter p_data_params_adapter;
        PIPDataSetTableAdapters.TPrescriptionInfoTableAdapter p_prescription_info_adapter;
        PIPDataSet.SMedicalCenterPartDoctorDataTable p_center_doctor_data;
        PIPDataSet.PrescriptionDataParametersDataTable p_data_params_data;
        PIPDataSet.PrescriptionDataParametersRow p_params_row;

        int p_temp_int;
        string p_temp_str;
        bool p_temp_err_bool;
        short p_temp_short;

        delegate void ORG_get_insured_info_del();
        delegate void ORG_set_insured_info_del();
        ORG_get_insured_info_del org_get_insured_info_func;
        ORG_set_insured_info_del org_set_insured_info_func;

        delegate void ORG_save_info_del();
        ORG_save_info_del org_save_info_func;

        delegate void setting_page_number_del();
        setting_page_number_del setting_page_number_func;

        delegate string var_get_prescription_day_del();
        delegate string var_get_prescription_month_del();
        delegate string var_get_prescription_year_del();
        delegate int? var_get_prescription_doc_del();
        var_get_prescription_day_del var_g_p_day_func;
        var_get_prescription_month_del var_g_p_month_func;
        var_get_prescription_year_del var_g_p_year_func;
        var_get_prescription_doc_del var_g_p_doc_func;

        delegate string var_get_serial_del();
        var_get_serial_del var_get_serial_func;
        delegate string var_get_identifier_del();
        var_get_identifier_del var_get_identifier_func;

        DataTable sel_prescriptions;
        PIPDataSet.TPrescriptionInfoRow data_row;
        long? pres_save_sequence;
        int sel_province;
        int sel_city;
        int sel_center_type;
        int? sel_center;
        int? sel_part;
        int sel_insurance;
        int sel_sector;
        string sel_vis_year;
        string sel_vis_month;
        string sel_vis_day, sel_insured_code, sel_pres_serial, sel_insured_identifier;
        short? sel_page;
        int? sel_fun_doctor;
        string sel_insured_name, sel_insured_family, sel_exp_day, sel_exp_month, sel_exp_year;
        string sel_prescriptor_day, sel_prescriptor_month, sel_prescriptor_year;
        int? sel_prescriptor_doctor;

        ///////////////////////////////////////////// Constructor for edit from pres evaluate
        public EditPresInfoForm(PLConstants.enum_data_operation operation, int province, int city, int c_type, int center, int c_part, int insurance, PLConstants.enum_insurances ins_org, int sector, string year, string month, PIPDataSet.TPrescriptionInfoRow d_row, DataTable prescriptions)
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);
            int tab_item_header_width = main_tabControl.Width / main_tabControl.TabPages.Count;
            main_tabControl.ItemSize = new Size((main_tabControl.Width / main_tabControl.TabPages.Count) - 5, main_tabControl.ItemSize.Height);
            prescription_tab.Enabled = false;
            form_operation = operation;
            if (d_row != null)
            {
                data_row = d_row;
                pres_save_sequence = d_row.save_sequence;
            }
            else
            {
                pres_save_sequence = null;
            }
            sel_prescriptions = prescriptions;
            if (form_operation == PLConstants.enum_data_operation.batch_edit)
            {
                is_batch = true;
            }
            else
            {
                is_batch = false;
            }

            pgs_dialog = new PGSDialog(this);
            c_province_adapter = new PIPDataSetTableAdapters.ProvinceTableAdapter();
            c_city_adapter = new PIPDataSetTableAdapters.CityTableAdapter();
            c_clinic_type_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            c_medical_center_adapter = new PIPDataSetTableAdapters.SMedicalCenterNameTableAdapter();
            //c_clinic_part_adapter = new PIPDataSetTableAdapters.TClinicPartTableAdapter();
            c_clinic_part_adapter = new PIPDataSetTableAdapters.TMedicalCenterPartTableAdapter();
            c_insurance_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            c_sector_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            c_year_adapter = new PIPDataSetTableAdapters.YearTableAdapter();
            c_month_adapter = new PIPDataSetTableAdapters.MonthTableAdapter();
            c_medical_center_data = new PIPDataSet.SMedicalCenterNameDataTable();
            //c_clinic_part_data = new PIPDataSet.TClinicPartDataTable();
            c_clinic_part_data = new PIPDataSet.TMedicalCenterPartDataTable();
            c_insurance_data = new PIPDataSet.TInsuranceDataTable();
            c_sector_data = new PIPDataSet.TInsuranceSectorDataTable();
            c_year_data = new PIPDataSet.YearDataTable();
            c_month_data = new PIPDataSet.MonthDataTable();
            p_other_sectors_form = new SearchedInsuredForm();
            p_arr_error_providers = new ErrorProvider[] { EP_p_vis, EP_p_id, EP_p_serial, EP_p_page, EP_p_fun_doctor, EP_p_name, EP_p_family, EP_p_exp, EP_p_pre_doctor, EP_p_pre_date };
            p_arr_controls = new Control[] { p_vis_cbx, p_id_txt, p_serial_txt, p_page_msk, p_fun_doc_id_msk, p_name_txt, p_family_txt, p_exp_year_msk, p_pre_doc_msk, p_pre_year_msk };
            p_arr_error_text = new string[] { PLConstants.error_pres_vis_day, PLConstants.error_id,PLConstants.error_pres_serial, PLConstants.error_pres_page, 
                                              PLConstants.error_pres_fun_doctor, PLConstants.error_names, PLConstants.error_names,
                                              PLConstants.error_date, PLConstants.error_id, PLConstants.error_date };
            p_arr_has_error = new bool[pres_info_items_cou];
            p_i_err_cou = p_chk_i_err_cou = 0;
            PLGlobalFuncs.yearsForComboBox(c_year_cbx);
            PLGlobalFuncs.monthesForComboBox(c_month_cbx);
            p_insured_info_worker.DoWork += p_insured_info_worker_DoWork;
            p_insured_data_adapter = new PIPDataSetTableAdapters.SInsuredDataTableAdapter();
            p_center_doctor_adapter = new PIPDataSetTableAdapters.SMedicalCenterPartDoctorTableAdapter();
            p_data_params_adapter = new PIPDataSetTableAdapters.PrescriptionDataParametersTableAdapter();
            p_prescription_info_adapter = new PIPDataSetTableAdapters.TPrescriptionInfoTableAdapter();
            p_center_doctor_data = new PIPDataSet.SMedicalCenterPartDoctorDataTable();
            p_data_params_data = new PIPDataSet.PrescriptionDataParametersDataTable();

            //initFormPartOne();

            initCProvinceComboBox();
            initCClinicTypeComboBox();

            c_province_cbx.SelectedValue = sel_province = province;
            c_city_cbx.SelectedValue = sel_city = city;
            c_type_cbx.SelectedValue = sel_center_type = c_type;
            c_center_cbx.SelectedValue = sel_center = center;
            c_part_cbx.SelectedValue = sel_part = c_part;
            c_insurance_cbx.SelectedValue = sel_insurance = insurance;
            insurance_org = ins_org;
            c_sector_cbx.SelectedValue = sel_sector = first_sector = sector;
            c_year_cbx.SelectedValue = sel_vis_year = year;
            c_month_cbx.SelectedValue = sel_vis_month = month;

            c_insurance_cbx.Enabled = false;

            c_current_province_txt.Text = c_province_cbx.Text;
            c_current_city_txt.Text = c_city_cbx.Text;
            c_current_type_txt.Text = c_type_cbx.Text;
            c_current_center_txt.Text = c_center_cbx.Text;
            c_current_part_txt.Text = c_part_cbx.Text;
            c_current_insurance_txt.Text = c_insurance_cbx.Text;
            c_current_sector_txt.Text = c_sector_cbx.Text;
            c_current_year_txt.Text = c_year_cbx.Text;
            c_current_month_txt.Text = c_month_cbx.Text;
            PLGlobalFuncs.daysForComboBox(p_vis_cbx, int.Parse(sel_vis_month));

            switch (insurance_org)
            {
                case PLConstants.enum_insurances.Salamat:
                    p_id_max_length = PLConstants.len_Salamat_code;
                    p_id_regex_str = PLConstants.reg_pre_id_Salamat;
                    p_id_txt.KeyPress -= p_id_KeyPressHandler;
                    p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_DashDigit);
                    p_id_txt.KeyPress += p_id_KeyPressHandler;
                    org_get_insured_info_func = new ORG_get_insured_info_del(getSalamatInsuredInfo);
                    org_save_info_func = new ORG_save_info_del(saveSalamat_Info);
                    break;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    p_id_max_length = PLConstants.len_TaminEjtemaei_pre_code;
                    p_id_regex_str = PLConstants.reg_pre_id_TaminEjtemaei;
                    p_id_txt.KeyPress -= p_id_KeyPressHandler;
                    p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
                    p_id_txt.KeyPress += p_id_KeyPressHandler;
                    org_get_insured_info_func = new ORG_get_insured_info_del(getTaminEjtemaeiInsuredInfo);
                    org_save_info_func = new ORG_save_info_del(saveTaminEjtemaei_Info);
                    setting_page_number_func = new setting_page_number_del(setTaminEjtemaei_page_number);
                    break;
                case PLConstants.enum_insurances.NirooMosalah:
                    p_id_max_length = PLConstants.len_NirooMosalah_code;
                    p_id_regex_str = PLConstants.reg_pre_id_NirooMosalah;
                    p_id_txt.KeyPress -= p_id_KeyPressHandler;
                    p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
                    p_id_txt.KeyPress += p_id_KeyPressHandler;
                    org_get_insured_info_func = new ORG_get_insured_info_del(getNirooMosalahInsuredInfo);
                    org_save_info_func = new ORG_save_info_del(saveNirooMosalah_Info);
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
                    org_save_info_func = new ORG_save_info_del(saveKomitehEmdad_Info);
                    break;
                case PLConstants.enum_insurances.Other:
                    p_id_max_length = PLConstants.len_max_id_20;
                    p_id_regex_str = PLConstants.reg_pre_id_Other;
                    p_id_txt.KeyPress -= p_id_KeyPressHandler;
                    p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_DashSlashDigit);
                    p_id_txt.KeyPress += p_id_KeyPressHandler;
                    p_serial_regex_str = PLConstants.reg_id;
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
                    org_save_info_func = new ORG_save_info_del(saveOther_Info);
                    other_ins_org = PLEnumFuncs.convertOtherInsurancesTagToEnum(insurance_org.ToString());
                    if (other_ins_org == PLConstants.enum_other_insurances.BankTejarat)
                    {
                        org_get_insured_info_func = new ORG_get_insured_info_del(getTejaratInsuredInfo);
                        setting_page_number_func = new setting_page_number_del(setTejarat_page_number);
                    }
                    break;
            }
            org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfo);
            p_id_txt.MaxLength = p_id_max_length;

            //switch (form_operation)
            //{
            //    case PLConstants.enum_data_operation.edit_data:
            //        p_vis_day_chk.Enabled = p_id_chk.Enabled = p_serial_chk.Enabled = p_page_chk.Enabled = p_fun_doc_chk.Enabled = p_name_chk.Enabled = p_family_chk.Enabled = p_exp_chk.Enabled = p_pre_doc_chk.Enabled = p_pre_date_chk.Enabled = false;
            //        c_seq_value_lbl.Text = p_seq_value_lbl.Text = data_row.save_sequence.ToString();

            //        p_vis_cbx.SelectedValue = sel_vis_day = data_row.visit_day;
            //        p_current_vis_txt.Text = p_vis_cbx.Text;

            //        if (insurance_org == PLConstants.enum_insurances.TaminEjtemaei)
            //        {
            //            p_current_id_txt.Text = p_id_txt.Text = sel_insured_code = data_row.pres_code;
            //        }
            //        else
            //        {
            //            p_current_id_txt.Text = p_id_txt.Text = sel_insured_code = data_row.insured_id;
            //        }
            //        p_id_txt_Leave(p_id_txt, new EventArgs());
            //        p_current_name_txt.Text = p_name_txt.Text;
            //        p_current_family_txt.Text = p_family_txt.Text;

            //        p_current_serial_txt.Text = p_serial_txt.Text = data_row.pres_code;

            //        p_current_page_txt.Text = p_page_msk.Text = (sel_page = data_row.page_number).ToString();

            //        p_current_fun_doc_id_txt.Text = p_fun_doc_id_msk.Text = (p_fun_doc_cbx.SelectedValue = data_row.doctor_medical_id).ToString();
            //        p_current_fun_doc_txt.Text = p_fun_doc_cbx.Text;

            //        p_exp_day_msk.Text = sel_exp_day = data_row.exp_day;
            //        p_exp_month_msk.Text = sel_exp_month = data_row.exp_month;
            //        p_exp_year_msk.Text = sel_exp_year = data_row.exp_year;
            //        p_current_exp_txt.Text = data_row.exp_date;

            //        p_current_pre_doc_txt.Text = p_pre_doc_msk.Text = (sel_prescriptor_doctor = data_row.prescriptor_doctor).ToString();

            //        p_pre_day_msk.Text = sel_prescriptor_day = data_row.prescription_day;
            //        p_pre_month_msk.Text = sel_prescriptor_month = data_row.prescription_month;
            //        p_pre_year_msk.Text = sel_prescriptor_year = data_row.prescription_year;
            //        p_current_pre_date_txt.Text = data_row.prescription_date;

            //        break;
            //    case PLConstants.enum_data_operation.batch_edit:
            //        p_vis_cbx.Enabled = p_vis_day_chk.Enabled =
            //        p_id_txt.Enabled = p_id_chk.Enabled =
            //        p_serial_txt.Enabled = p_serial_chk.Enabled =
            //        p_page_msk.Enabled = p_page_chk.Enabled =
            //        p_name_txt.Enabled = p_name_chk.Enabled =
            //        p_family_txt.Enabled = p_family_chk.Enabled =
            //        p_pre_doc_msk.Enabled = p_pre_doc_chk.Enabled =
            //        p_pre_date_flow.Enabled = p_pre_date_chk.Enabled = false;
            //        break;
            //}

            if (sel_prescriptions.Rows.Count > 0 && d_row != null)
            {
                c_edit_info_lbl.Text = p_edit_info_lbl.Text = "ویرایش " + sel_prescriptions.Rows.Count.ToString() + " نسخه از > " + c_insurance_cbx.Text + " - " + c_sector_cbx.Text + " - " + c_center_cbx.Text + " - " + c_part_cbx.Text + " - " + c_month_cbx.Text + " " + c_year_cbx.Text;
            }
            else
            {
                c_edit_info_lbl.Text = p_edit_info_lbl.Text = "ویرایش 1 نسخه از > " + c_insurance_cbx.Text + " - " + c_sector_cbx.Text + " - " + c_center_cbx.Text + " - " + c_part_cbx.Text + " - " + c_month_cbx.Text + " " + c_year_cbx.Text;
            }
        }

        ///////////////////////////////////////////// Constructor for edit from pres search
        public EditPresInfoForm(PLConstants.enum_data_operation operation, PIPDataSet.TSearchPrescriptionRow d_row, DataTable prescriptions)
        {
            InitializeComponent();
            initCProvinceComboBox();
            initCClinicTypeComboBox();
            c_province_cbx.SelectedValue = sel_province = d_row.province_id;
            c_city_cbx.SelectedValue = sel_city = d_row.city_id;
            c_type_cbx.SelectedValue = sel_center_type = d_row.center_type_id;
            c_center_cbx.SelectedValue = sel_center = d_row.medical_center;
            c_part_cbx.SelectedValue = sel_part = d_row.center_part;
            c_insurance_cbx.SelectedValue = sel_insurance = d_row.insurance_id;
            insurance_org = PLEnumFuncs.convertInsuranceTagToEnum(d_row.insurance_tag);
            c_sector_cbx.SelectedValue = sel_sector = first_sector = d_row.sector_id;
            c_year_cbx.SelectedValue = sel_vis_day = d_row.visit_year;
            c_month_cbx.SelectedValue = sel_vis_month = d_row.visit_month;
            c_insurance_cbx.Enabled = false;
            //sel_part = -1;
            form_operation = operation;
            data_row = pIPDataSet.TPrescriptionInfo.NewTPrescriptionInfoRow();
            data_row.save_sequence = d_row.save_sequence;
            data_row.visit_day = d_row.visit_day;
            if (insurance_org == PLConstants.enum_insurances.TaminEjtemaei)
            {
                data_row.insured_id = d_row.pres_code;
            }
            else
            {
                data_row.insured_id = d_row.insured_id;
            }
            data_row.page_number = d_row.page_number;
            data_row.doctor_medical_id = d_row.doctor_medical_id;
            data_row.exp_day = d_row.exp_day;
            data_row.exp_month = d_row.exp_month;
            data_row.exp_year = d_row.exp_year;
            data_row.prescriptor_doctor = d_row.prescriptor_doctor;
            data_row.prescription_day = d_row.prescription_day;
            data_row.prescription_month = d_row.prescription_month;
            data_row.prescription_year = d_row.prescription_year;
            sel_prescriptions = prescriptions;
            is_first_load = false;
            //initFormPartTwo();
        }

        //private void initFormPartOne()
        //{
        //    PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);
        //    int tab_item_header_width = main_tabControl.Width / main_tabControl.TabPages.Count;
        //    main_tabControl.ItemSize = new Size((main_tabControl.Width / main_tabControl.TabPages.Count) - 5, main_tabControl.ItemSize.Height);
        //    prescription_tab.Enabled = false;
        //    pgs_dialog = new PGSDialog(this);
        //    c_province_adapter = new PIPDataSetTableAdapters.ProvinceTableAdapter();
        //    c_city_adapter = new PIPDataSetTableAdapters.CityTableAdapter();
        //    c_clinic_type_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
        //    c_medical_center_adapter = new PIPDataSetTableAdapters.SMedicalCenterNameTableAdapter();
        //    c_clinic_part_adapter = new PIPDataSetTableAdapters.TClinicPartTableAdapter();
        //    c_insurance_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
        //    c_sector_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
        //    c_medical_center_data = new PIPDataSet.SMedicalCenterNameDataTable();
        //    c_clinic_part_data = new PIPDataSet.TClinicPartDataTable();
        //    c_insurance_data = new PIPDataSet.TInsuranceDataTable();
        //    c_sector_data = new PIPDataSet.TInsuranceSectorDataTable();
        //    p_other_sectors_form = new SearchedInsuredForm();
        //    p_arr_error_providers = new ErrorProvider[] { EP_p_vis, EP_p_id, EP_p_page, EP_p_fun_doctor, EP_p_name, EP_p_family, EP_p_exp, EP_p_pre_doctor, EP_p_pre_date };
        //    p_arr_controls = new Control[] { p_vis_cbx, p_id_txt, p_page_msk, p_fun_doc_id_msk, p_name_txt, p_family_txt, p_exp_year_msk, p_pre_doc_msk, p_pre_year_msk };
        //    p_arr_error_text = new string[] { PLConstants.error_pres_vis_day, PLConstants.error_id, PLConstants.error_pres_page, 
        //                                      PLConstants.error_pres_fun_doctor, PLConstants.error_names, PLConstants.error_names,
        //                                      PLConstants.error_date, PLConstants.error_id, PLConstants.error_date };
        //    p_arr_has_error = new bool[pres_info_items_cou];
        //    p_i_err_cou = p_chk_i_err_cou = 0;
        //    PLGlobalFuncs.yearsForComboBox(c_year_cbx);
        //    PLGlobalFuncs.monthesForComboBox(c_month_cbx);
        //    p_insured_info_worker.DoWork += p_insured_info_worker_DoWork;
        //    p_insured_data_adapter = new PIPDataSetTableAdapters.SInsuredDataTableAdapter();
        //    p_center_doctor_adapter = new PIPDataSetTableAdapters.SMedicalCenterPartDoctorTableAdapter();
        //    p_data_params_adapter = new PIPDataSetTableAdapters.PrescriptionDataParametersTableAdapter();
        //    p_prescription_info_adapter = new PIPDataSetTableAdapters.TPrescriptionInfoTableAdapter();
        //    p_center_doctor_data = new PIPDataSet.SMedicalCenterPartDoctorDataTable();
        //    p_data_params_data = new PIPDataSet.PrescriptionDataParametersDataTable();
        //}

        //private void initFormPartTwo()
        //{
        //    PLGlobalFuncs.daysForComboBox(p_vis_cbx, int.Parse(sel_vis_month));

        //    switch (insurance_org)
        //    {
        //        case PLConstants.enum_insurances.Salamat:
        //            p_id_max_length = PLConstants.len_Salamat_code;
        //            p_id_regex_str = PLConstants.reg_pre_id_Salamat;
        //            p_id_txt.KeyPress -= p_id_KeyPressHandler;
        //            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_DashDigit);
        //            p_id_txt.KeyPress += p_id_KeyPressHandler;
        //            org_get_insured_info_func = new ORG_get_insured_info_del(getSalamatInsuredInfo);
        //            org_save_info_func = new ORG_save_info_del(saveSalamat_Info);
        //            break;
        //        case PLConstants.enum_insurances.TaminEjtemaei:
        //            p_id_max_length = PLConstants.len_TaminEjtemaei_pre_code;
        //            p_id_regex_str = PLConstants.reg_pre_id_TaminEjtemaei;
        //            p_id_txt.KeyPress -= p_id_KeyPressHandler;
        //            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
        //            p_id_txt.KeyPress += p_id_KeyPressHandler;
        //            org_get_insured_info_func = new ORG_get_insured_info_del(getTaminEjtemaeiInsuredInfo);
        //            org_save_info_func = new ORG_save_info_del(saveTaminEjtemaei_Info);
        //            break;
        //        case PLConstants.enum_insurances.NirooMosalah:
        //            p_id_max_length = PLConstants.len_NirooMosalah_code;
        //            p_id_regex_str = PLConstants.reg_pre_id_NirooMosalah;
        //            p_id_txt.KeyPress -= p_id_KeyPressHandler;
        //            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
        //            p_id_txt.KeyPress += p_id_KeyPressHandler;
        //            org_get_insured_info_func = new ORG_get_insured_info_del(getNirooMosalahInsuredInfo);
        //            org_save_info_func = new ORG_save_info_del(saveNirooMosalah_Info);
        //            break;
        //        case PLConstants.enum_insurances.KomitehEmdad:
        //            p_id_max_length = PLConstants.len_KomitehEmdad_code;
        //            p_id_regex_str = PLConstants.reg_pre_id_KomitehEmdad;
        //            p_id_txt.KeyPress -= p_id_KeyPressHandler;
        //            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_Digit);
        //            p_id_txt.KeyPress += p_id_KeyPressHandler;
        //            org_get_insured_info_func = new ORG_get_insured_info_del(getKomitehEmdadInsuredInfo);
        //            org_save_info_func = new ORG_save_info_del(saveKomitehEmdad_Info);
        //            break;
        //        case PLConstants.enum_insurances.Other:
        //            p_id_max_length = PLConstants.len_max_id_20;
        //            p_id_regex_str = PLConstants.reg_pre_id_Other;
        //            p_id_txt.KeyPress -= p_id_KeyPressHandler;
        //            p_id_KeyPressHandler = new KeyPressEventHandler(p_id_txt_KeyPress_for_DashDigit);
        //            p_id_txt.KeyPress += p_id_KeyPressHandler;
        //            org_get_insured_info_func = new ORG_get_insured_info_del(getOtherInsuredInfo);
        //            org_save_info_func = new ORG_save_info_del(saveOther_Info);
        //            break;
        //    }
        //    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfo);
        //    initPFunctorDoctorComboBox();
        //    p_id_txt.MaxLength = p_id_max_length;

        //    switch (form_operation)
        //    {
        //        case PLConstants.enum_data_operation.edit_data:
        //            p_vis_day_chk.Enabled = p_id_chk.Enabled = p_page_chk.Enabled = p_fun_doc_chk.Enabled = p_name_chk.Enabled = p_family_chk.Enabled = p_exp_chk.Enabled = p_pre_doc_chk.Enabled = p_pre_date_chk.Enabled = false;
        //            c_seq_value_lbl.Text = p_seq_value_lbl.Text = data_row.save_sequence.ToString();

        //            break;
        //        case PLConstants.enum_data_operation.batch_edit:
        //            p_name_chk.Enabled = p_family_chk.Enabled = false;
        //            break;
        //    }
        //}

        public bool formStart()
        {
            this.ShowDialog();
            return were_actions_successeded;
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
                initCInsuranceComboBox();
                c_part_cbx.Enabled = true;
                //c_insurance_cbx.Enabled = true;
                c_insurance_cbx.SelectedValue = sel_insurance;
            }
            else
            {
                c_part_cbx.Enabled = false;
                c_part_cbx.DataSource = null;
                c_insurance_cbx.DataSource = null;
                //c_insurance_cbx.Enabled = false;
            }
        }
        private void c_part_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_part_cbx.SelectedIndex > 0)
            {
                p_sel_part_value = sel_part = (int)c_part_cbx.SelectedValue;
            }
            else
            {
                sel_part = -1;
                p_sel_part_value = null;
            }
        }
        private void c_insurance_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_insurance_cbx.SelectedIndex > 0)
            {
                //sel_insurance = (int)c_insurance_cbx.SelectedValue;
                initCSectorComboBox();
            }
            else
            {
                c_sector_cbx.DataSource = null;
                c_sector_cbx.Enabled = false;
                if (!is_first_load)
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_pres_edit_info_no_insurance);
                }
            }
        }
        private void c_sector_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_sector_cbx.SelectedIndex > 0)
            {
                sel_sector = (int)c_sector_cbx.SelectedValue;
                c_year_cbx.Enabled = true;
            }
            else
            {
                c_year_cbx.Enabled = false;
                c_year_cbx.SelectedIndex = 0;
            }
        }
        private void c_year_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_year_cbx.SelectedIndex > 0)
            {
                sel_vis_year = (string)c_year_cbx.SelectedValue;
                c_month_cbx.Enabled = true;
            }
            else
            {
                c_month_cbx.Enabled = false;
                c_month_cbx.SelectedIndex = 0;
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
            //center_has_part = false;
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

            //c_clinic_part_adapter.FillByCenter(c_clinic_part_data, sel_center);
            //if (c_clinic_part_data.Rows.Count > 0)
            //{
            //    PIPDataSet.TClinicPartRow c_first_row = c_clinic_part_data.NewTClinicPartRow();
            //    c_first_row.id = -1;
            //    c_first_row.name = "--بخش درمانی--";
            //    c_clinic_part_data.Rows.InsertAt(c_first_row, 0);
            //    c_part_cbx.DataSource = c_clinic_part_data;
            //    c_part_cbx.DisplayMember = c_clinic_part_data.nameColumn.ColumnName;
            //    c_part_cbx.ValueMember = c_clinic_part_data.cen_par_seqColumn.ColumnName;
            //    c_part_cbx.SelectedIndex = 0;
            //    PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_part_cbx);
            //}
        }
        private void initCInsuranceComboBox()
        {
            //c_insurance_adapter.FillByCenterContract(c_insurance_data, sel_center);
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
                //c_insurance_cbx.SelectedIndex = 0;
                PLGlobalFuncs.adjustDropDownWidthOfComboBox(c_insurance_cbx);
                //c_insurance_cbx.Enabled = true;
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
            if (p_data_params_adapter.FillByClinicType(p_data_params_data, sel_center_type, p_sel_part_value, sel_insurance, sel_sector) > 0)
            {
                p_params_row = (PIPDataSet.PrescriptionDataParametersRow)p_data_params_data.Rows[0];
                p_vis_cbx.Enabled = p_vis_day_chk.Enabled = p_params_row.p_visit_date;
                if (p_params_row.p_visit_date)
                {
                    p_chk_i_err_cou++;
                }

                p_id_txt.Enabled = p_id_txt.TabStop = p_id_chk.Enabled = p_params_row.p_id;
                if (p_params_row.p_id)
                {
                    p_chk_i_err_cou++;
                }

                p_serial_txt.Enabled = p_serial_txt.TabStop = p_serial_chk.Enabled = p_params_row.p_serial;
                if (p_params_row.p_serial)
                {
                    p_chk_i_err_cou++;
                    var_get_serial_func = new var_get_serial_del(getSerial);
                    var_get_identifier_func = new var_get_identifier_del(getInsuredCodeForIdentifier);
                }
                else
                {
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
                if (p_params_row.p_page_number)
                {
                    p_chk_i_err_cou++;
                }

                p_fun_doc_id_msk.Enabled = p_fun_doc_id_msk.TabStop = p_fun_doc_cbx.Enabled = p_fun_doc_chk.Enabled = p_params_row.p_functor_doctor;
                initPFunctorDoctorComboBox();
                if (p_params_row.p_functor_doctor)
                {
                    p_chk_i_err_cou++;
                }
                else
                {
                    p_fun_doc_cbx.SelectedIndex = 1;
                    getMedicalIDOfFunctorDoctorFromBox();
                }

                p_name_txt.Enabled = p_name_txt.TabStop = p_name_chk.Enabled = p_params_row.p_name;
                if (p_params_row.p_name)
                {
                    p_chk_i_err_cou++;
                }

                p_family_txt.Enabled = p_family_txt.TabStop = p_family_chk.Enabled = p_params_row.p_family_name;
                if (p_params_row.p_family_name)
                {
                    p_chk_i_err_cou++;
                }

                p_exp_flow.Enabled = p_exp_day_msk.TabStop = p_exp_month_msk.TabStop = p_exp_year_msk.TabStop = p_exp_chk.Enabled = p_params_row.p_expiration_date;
                if (p_params_row.p_expiration_date)
                {
                    p_chk_i_err_cou++;
                    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfo);
                }
                else
                {
                    if (insurance_org != PLConstants.enum_insurances.TaminEjtemaei)
                    {
                        sel_exp_day = PLGlobalFuncs.getDaysCountOfMonth(sel_vis_month);
                        sel_exp_month = sel_vis_month;
                        sel_exp_year = sel_vis_year;
                    }
                    org_set_insured_info_func = new ORG_set_insured_info_del(setORGInsuredInfoWithoutExpiration);
                }

                p_pre_doc_msk.Enabled = p_pre_doc_msk.TabStop = p_pre_doc_chk.Enabled = p_params_row.p_prescriptor_doctor;
                if (p_params_row.p_prescriptor_doctor)
                {
                    p_chk_i_err_cou++;
                    var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor);
                }
                else
                {
                    var_g_p_doc_func = new var_get_prescription_doc_del(getPrescriptorDoctor_empty);
                }

                p_pre_date_flow.Enabled = p_pre_day_msk.TabStop = p_pre_month_msk.TabStop = p_pre_year_msk.TabStop = p_pre_date_chk.Enabled = p_params_row.p_service_date;
                if (p_params_row.p_service_date)
                {
                    p_chk_i_err_cou++;
                    var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay);
                    var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth);
                    var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear);
                }
                else
                {
                    var_g_p_day_func = new var_get_prescription_day_del(getPrescriptorDay_empty);
                    var_g_p_month_func = new var_get_prescription_month_del(getPrescriptorMonth_empty);
                    var_g_p_year_func = new var_get_prescription_year_del(getPrescriptorYear_empty);
                }

                switch (form_operation)
                {
                    case PLConstants.enum_data_operation.edit_data:
                        p_vis_day_chk.Enabled = p_id_chk.Enabled = p_serial_chk.Enabled = p_page_chk.Enabled = p_fun_doc_chk.Enabled = p_name_chk.Enabled = p_family_chk.Enabled = p_exp_chk.Enabled = p_pre_doc_chk.Enabled = p_pre_date_chk.Enabled = false;
                        c_seq_value_lbl.Text = p_seq_value_lbl.Text = data_row.save_sequence.ToString();

                        p_vis_cbx.SelectedValue = sel_vis_day = data_row.visit_day;
                        p_current_vis_txt.Text = p_vis_cbx.Text;

                        if (insurance_org == PLConstants.enum_insurances.TaminEjtemaei)
                        {
                            p_current_id_txt.Text = p_id_txt.Text = sel_insured_code = data_row.pres_code;
                        }
                        else
                        {
                            p_current_id_txt.Text = p_id_txt.Text = sel_insured_code = data_row.insured_id;
                        }
                        p_id_txt_Leave(p_id_txt, new EventArgs());
                        p_current_name_txt.Text = p_name_txt.Text;
                        p_current_family_txt.Text = p_family_txt.Text;

                        p_current_serial_txt.Text = p_serial_txt.Text = data_row.pres_code;

                        p_current_page_txt.Text = p_page_msk.Text = (sel_page = data_row.page_number).ToString();

                        p_current_fun_doc_id_txt.Text = p_fun_doc_id_msk.Text = (p_fun_doc_cbx.SelectedValue = data_row.doctor_medical_id).ToString();
                        p_current_fun_doc_txt.Text = p_fun_doc_cbx.Text;

                        p_exp_day_msk.Text = sel_exp_day = data_row.exp_day;
                        p_exp_month_msk.Text = sel_exp_month = data_row.exp_month;
                        p_exp_year_msk.Text = sel_exp_year = data_row.exp_year;
                        p_current_exp_txt.Text = data_row.exp_date;

                        p_current_pre_doc_txt.Text = p_pre_doc_msk.Text = (sel_prescriptor_doctor = data_row.prescriptor_doctor).ToString();

                        p_pre_day_msk.Text = sel_prescriptor_day = data_row.prescription_day;
                        p_pre_month_msk.Text = sel_prescriptor_month = data_row.prescription_month;
                        p_pre_year_msk.Text = sel_prescriptor_year = data_row.prescription_year;
                        p_current_pre_date_txt.Text = data_row.prescription_date;

                        break;
                    case PLConstants.enum_data_operation.batch_edit:
                        p_vis_cbx.Enabled = p_vis_day_chk.Enabled =
                        p_id_txt.Enabled = p_id_chk.Enabled =
                        p_serial_txt.Enabled = p_serial_chk.Enabled =
                        p_page_msk.Enabled = p_page_chk.Enabled =
                        p_name_txt.Enabled = p_name_chk.Enabled =
                        p_family_txt.Enabled = p_family_chk.Enabled =
                        p_pre_doc_msk.Enabled = p_pre_doc_chk.Enabled =
                        p_pre_date_flow.Enabled = p_pre_date_chk.Enabled = false;
                        break;
                }

                main_tabControl.SelectedTab = prescription_tab;
                center_tab.Enabled = false;
                prescription_tab.Enabled = true;
                main_tabControl.Refresh();
            }
        }
        private void c_reset_btn_Click(object sender, EventArgs e)
        {
            c_province_cbx.SelectedIndex = 0;
        }

        #endregion CENTER Tab

        ///////////////////////////////////////////////////////////////////////// PRESCRIPTION TAB
        #region PRESCRIPTION Tab

        ///////////////////////////////////////////////////////////////////////// Prescription GLOBAL METHODS
        /////////////////////////////////////////////////////////////////////////

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
            if (p_center_doctor_adapter.FillByClinicPart(p_center_doctor_data, sel_center, sel_part) > 0)
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
                p_fun_doc_cbx.Enabled = true;
            }
        }

        ///////////////////////////////////////////////////////////////////////// INSURED ID
        private void p_id_txt_KeyPress_for_DashDigit(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == dash_char)
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
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == dash_char || e.KeyChar == slash_char)
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
            if (Regex.IsMatch(sel_insured_code = p_id_txt.Text, p_id_regex_str))
            {
                if (!p_insured_info_worker.IsBusy)
                {
                    p_process_insured_exist_checking = true;
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
            sel_insured_identifier = sel_insured_code;
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
            sel_insured_identifier = sel_insured_code;
            p_insured_data_adapter.Get_Salamat_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
        }
        private void getKomitehEmdadInsuredInfo()
        {
            sel_insured_identifier = sel_insured_code;
            p_insured_data_adapter.Get_KomitehEmdad_InsuredInfo(sel_sector, sel_insured_code, ref p_insured_sequence, ref sel_insured_name, ref sel_insured_family, ref p_previous_exp_day, ref p_previous_exp_month, ref p_previous_exp_year, ref p_other_sectors_id);
        }
        private void getOneSectorKomitehEmdadInsuredInfo()
        {
            sel_insured_identifier = sel_insured_code;
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
                sel_insured_identifier = sel_insured_code.Substring(0, sel_insured_code.Length - PLConstants.len_Tejarat_other_part);
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

        private string getInsuredCodeForIdentifier()
        {
            return sel_insured_code;
        }
        private string getIdentifierPartOfInsuredCode()
        {
            return sel_insured_identifier;
        }

        ///////////////////////////////////////////////////////////////////////// Prescription SERIAL
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

        private string getSerial()
        {
            return sel_pres_serial;
        }
        private string getSerialFromInsuredCode()
        {
            return sel_insured_code;
        }

        ///////////////////////////////////////////////////////////////////////// Prescription FUNCTOR DOCTOR
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
            else if (p_temp_str == "" && is_batch)// && p_fun_doc_chk.Checked)
            {
                p_temp_err_bool = false;
                sel_fun_doctor = -1;
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

        ///////////////////////////////////////////////////////////////////////// Prescription EXPIRATION DATE
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
            p_temp_str = p_exp_year_msk.Text.Trim();
            if (int.TryParse(p_temp_str, out p_temp_int))
            {
                if (yearEvaluation(p_temp_int, out sel_exp_year))
                {
                    p_exp_year_msk.Text = sel_exp_year;
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////// Prescription PRESCRIPTION DOCTOR
        private int? getPrescriptorDoctor()
        {
            return sel_prescriptor_doctor;
        }
        private int? getPrescriptorDoctor_empty()
        {
            return sel_fun_doctor;
        }

        ///////////////////////////////////////////////////////////////////////// Prescription SERVICE DATE
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
        private void p_vis_day_chk_Click(object sender, EventArgs e)
        {
            if (!p_vis_day_chk.Checked)
            {
                p_vis_cbx.SelectedIndex = 0;
                p_vis_cbx.Enabled = false;
                sel_vis_day = PLConstants.str_unchanged;
                p_arr_error_providers[p_ind_vis_day].Clear();
                p_chk_i_err_cou--;
                p_vis_day_chk.Checked = true;
                if (p_arr_has_error[p_ind_vis_day])
                {
                    p_arr_has_error[p_ind_vis_day] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_arr_error_providers[p_ind_vis_day].SetError(p_arr_controls[p_ind_vis_day], p_arr_error_text[p_ind_vis_day]);
                p_i_err_cou++;
                p_arr_has_error[p_ind_insured_id] = true;
                p_vis_day_chk.Checked = false;
                p_vis_cbx.Enabled = true;
                p_chk_i_err_cou++;
            }
        }
        private void p_id_chk_Click(object sender, EventArgs e)
        {
            if (!p_id_chk.Checked)
            {
                p_id_txt.Clear();
                p_name_txt.Clear();
                p_family_txt.Clear();
                p_id_txt.Enabled = p_name_txt.Enabled = p_family_txt.Enabled = false;
                p_insured_sequence = -1;
                p_is_insured_exist = true;
                sel_insured_name = sel_insured_code = PLConstants.str_unchanged;
                p_arr_error_providers[p_ind_insured_id].Clear();
                p_arr_error_providers[p_ind_insured_name].Clear();
                p_arr_error_providers[p_ind_insured_family].Clear();
                p_chk_i_err_cou -= 3;//id name family
                p_id_chk.Checked = true;
                if (p_arr_has_error[p_ind_insured_id])
                {
                    p_arr_has_error[p_ind_insured_id] = false;
                    p_i_err_cou--;
                }
                if (p_arr_has_error[p_ind_insured_name])
                {
                    p_arr_has_error[p_ind_insured_name] = false;
                    p_i_err_cou--;
                }
                if (p_arr_has_error[p_ind_insured_family])
                {
                    p_arr_has_error[p_ind_insured_family] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_id_txt.Enabled = p_name_txt.Enabled = p_family_txt.Enabled = true;
                p_arr_error_providers[p_ind_insured_id].SetError(p_arr_controls[p_ind_insured_id], p_arr_error_text[p_ind_insured_id]);
                p_arr_error_providers[p_ind_insured_name].SetError(p_arr_controls[p_ind_insured_name], p_arr_error_text[p_ind_insured_name]);
                p_arr_error_providers[p_ind_insured_family].SetError(p_arr_controls[p_ind_insured_family], p_arr_error_text[p_ind_insured_family]);
                p_chk_i_err_cou += 3;//id name family
                p_is_insured_exist = false;
                p_id_chk.Checked = false;
                p_arr_has_error[p_ind_insured_id] = p_arr_has_error[p_ind_insured_name] = p_arr_has_error[p_ind_insured_family] = true;
                p_i_err_cou += 3;
            }
        }
        private void p_serial_chk_Click(object sender, EventArgs e)
        {
            if (!p_serial_chk.Checked)
            {
                p_serial_txt.Clear();
                p_serial_txt.Enabled = false;
                sel_pres_serial = PLConstants.str_unchanged;
                p_arr_error_providers[p_ind_serial].Clear();
                p_chk_i_err_cou--;
                p_serial_chk.Checked = true;
                if (p_arr_has_error[p_ind_serial])
                {
                    p_arr_has_error[p_ind_serial] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_serial_txt.Enabled = true;
                p_arr_error_providers[p_ind_serial].SetError(p_arr_controls[p_ind_serial], p_arr_error_text[p_ind_serial]);
                p_serial_chk.Checked = false;
                p_arr_has_error[p_ind_serial] = true;
                p_i_err_cou++;
            }
        }
        private void p_page_chk_Click(object sender, EventArgs e)
        {
            if (!p_page_chk.Checked)
            {
                p_page_msk.Clear();
                p_page_msk.Enabled = false;
                sel_page = -1;
                p_arr_error_providers[p_ind_page].Clear();
                p_chk_i_err_cou--;
                p_page_chk.Checked = true;
                if (p_arr_has_error[p_ind_page])
                {
                    p_arr_has_error[p_ind_page] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_page_msk.Enabled = true;
                p_arr_error_providers[p_ind_page].SetError(p_arr_controls[p_ind_page], p_arr_error_text[p_ind_page]);
                p_chk_i_err_cou++;
                p_page_chk.Checked = false;
                p_arr_has_error[p_ind_page] = true;
                p_i_err_cou++;
            }
        }
        private void p_fun_doc_chk_Click(object sender, EventArgs e)
        {
            if (!p_fun_doc_chk.Checked)
            {
                p_fun_doc_id_msk.Clear();
                p_fun_doc_cbx.SelectedIndex = 0;
                p_fun_doc_id_msk.Enabled = p_fun_doc_cbx.Enabled = false;
                sel_fun_doctor = -1;
                p_arr_error_providers[p_ind_fun_doctor].Clear();
                p_chk_i_err_cou--;
                p_fun_doc_chk.Checked = true;
                if (p_arr_has_error[p_ind_fun_doctor])
                {
                    p_arr_has_error[p_ind_fun_doctor] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_fun_doc_id_msk.Enabled = p_fun_doc_cbx.Enabled = true;
                p_arr_error_providers[p_ind_fun_doctor].SetError(p_arr_controls[p_ind_fun_doctor], p_arr_error_text[p_ind_fun_doctor]);
                p_chk_i_err_cou++;
                p_fun_doc_chk.Checked = false;
                p_arr_has_error[p_ind_fun_doctor] = true;
                p_i_err_cou++;
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
                    p_name_chk.Checked = true;
                    p_name_txt.Enabled = false;
                    p_chk_i_err_cou--;
                }
            }
            else
            {
                p_arr_has_error[p_ind_insured_name] = false;
                p_name_chk.Checked = false;
                p_name_txt.Enabled = true;
                p_chk_i_err_cou++;
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
                    p_family_chk.Checked = true;
                    p_family_txt.Enabled = false;
                    p_chk_i_err_cou--;
                }
            }
            else
            {
                p_arr_has_error[p_ind_insured_family] = false;
                p_family_chk.Checked = false;
                p_family_txt.Enabled = true;
                p_chk_i_err_cou++;
            }
        }
        private void p_exp_chk_Click(object sender, EventArgs e)
        {
            if (!p_exp_chk.Checked)
            {
                p_exp_day_msk.Clear();
                p_exp_month_msk.Clear();
                p_exp_year_msk.Clear();
                p_exp_flow.Enabled = false;
                sel_exp_day = sel_exp_month = sel_exp_year = PLConstants.str_unchanged;
                p_arr_error_providers[p_ind_exp_date].Clear();
                p_exp_flow.BackColor = Color.Transparent;
                p_chk_i_err_cou--;
                p_exp_chk.Checked = true;
                if (p_arr_has_error[p_ind_exp_date])
                {
                    p_arr_has_error[p_ind_exp_date] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_exp_flow.Enabled = true;
                p_arr_error_providers[p_ind_exp_date].SetError(p_arr_controls[p_ind_exp_date], p_arr_error_text[p_ind_exp_date]);
                p_exp_flow.BackColor = Color.Red;
                p_chk_i_err_cou++;
                p_exp_chk.Checked = false;
                p_arr_has_error[p_ind_exp_date] = true;
                p_i_err_cou++;
            }
        }
        private void p_pre_doc_chk_Click(object sender, EventArgs e)
        {
            if (!p_pre_doc_chk.Checked)
            {
                p_pre_doc_msk.Clear();
                p_pre_doc_msk.Enabled = false;
                sel_prescriptor_doctor = -1;
                p_arr_error_providers[p_ind_prescriptor_doctor].Clear();
                p_chk_i_err_cou--;
                p_pre_doc_chk.Checked = true;
                if (p_arr_has_error[p_ind_prescriptor_doctor])
                {
                    p_arr_has_error[p_ind_prescriptor_doctor] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_pre_doc_msk.Enabled = true;
                p_arr_error_providers[p_ind_prescriptor_doctor].SetError(p_arr_controls[p_ind_prescriptor_doctor], p_arr_error_text[p_ind_prescriptor_doctor]);
                p_chk_i_err_cou++;
                p_pre_doc_chk.Checked = false;
                p_arr_has_error[p_ind_prescriptor_doctor] = true;
                p_i_err_cou++;
            }
        }
        private void p_pre_date_chk_Click(object sender, EventArgs e)
        {
            if (!p_pre_date_chk.Checked)
            {
                p_pre_day_msk.Clear();
                p_pre_month_msk.Clear();
                p_pre_year_msk.Clear();
                p_pre_date_flow.Enabled = false;
                sel_prescriptor_day = sel_prescriptor_month = sel_prescriptor_year = PLConstants.str_unchanged;
                p_arr_error_providers[p_ind_prescriptor_date].Clear();
                p_pre_date_flow.BackColor = Color.Transparent;
                p_chk_i_err_cou--;
                p_pre_date_chk.Checked = true;
                if (p_arr_has_error[p_ind_prescriptor_date])
                {
                    p_arr_has_error[p_ind_prescriptor_date] = false;
                    p_i_err_cou--;
                }
            }
            else
            {
                p_pre_date_flow.Enabled = true;
                p_arr_error_providers[p_ind_prescriptor_date].SetError(p_arr_controls[p_ind_prescriptor_date], p_arr_error_text[p_ind_prescriptor_date]);
                p_pre_date_flow.BackColor = Color.Red;
                p_chk_i_err_cou++;
                p_pre_date_chk.Checked = false;
                p_arr_has_error[p_ind_prescriptor_date] = true;
                p_i_err_cou++;
            }
        }

        ///////////////////////////////////////////////////////////////////////// Prescription INFO BUTTONS
        /////////////////////////////////////////////////////////////////////////
        private void p_info_submit_btn_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////// visit day
            if (p_params_row.p_visit_date)
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
                else if (is_batch)// && p_vis_day_chk.Checked)
                {
                    sel_vis_day = PLConstants.str_unchanged;
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
            ////////////////////////////////////////////////////// id
            if (p_params_row.p_id)
            {
                if (Regex.IsMatch(sel_insured_code = p_id_txt.Text, p_id_regex_str))
                {
                    if (p_arr_has_error[p_ind_insured_id])
                    {
                        p_arr_has_error[p_ind_insured_id] = false;
                        p_i_err_cou--;
                        p_id_txt.BackColor = Color.White;
                        EP_p_id.Clear();
                    }
                }
                else if (sel_insured_code == "" && is_batch)
                {
                    sel_insured_code = sel_insured_identifier = PLConstants.str_unchanged;
                    if (p_arr_has_error[p_ind_insured_id])
                    {
                        p_arr_has_error[p_ind_insured_id] = false;
                        p_i_err_cou--;
                        p_vis_cbx.BackColor = Color.White;
                        EP_p_vis.Clear();
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
            ////////////////////////////////////////////////////// serial
            if (p_params_row.p_serial)
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
                else if (is_batch)// && p_serial_chk.Checked)
                {
                    sel_pres_serial = PLConstants.str_unchanged;
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
            ////////////////////////////////////////////////////// page number
            if (p_params_row.p_page_number)
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
                else if (p_temp_str == "" && is_batch)// && p_page_chk.Checked)
                {
                    sel_page = -1;
                    p_temp_err_bool = false;
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
            ////////////////////////////////////////////////////// functor doctor
            getMedicalIDOfFunctorDoctorFromBox();

            ////////////////////////////////////////////////////// name
            if (p_params_row.p_name)
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
                else if (sel_insured_name == "" && is_batch)// && sel_insured_code == "") && p_id_chk.Checked)
                {
                    sel_insured_name = PLConstants.str_unchanged;
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

            ////////////////////////////////////////////////////// family name
            if (p_params_row.p_family_name)
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
                else if (sel_insured_family == "" && is_batch)// && sel_insured_code == "") && p_id_chk.Checked)
                {
                    sel_insured_family = PLConstants.str_unchanged;
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

            ////////////////////////////////////////////////////// exp date
            if (p_params_row.p_expiration_date)
            {
                sel_exp_day = p_exp_day_msk.Text;
                sel_exp_month = p_exp_month_msk.Text;
                sel_exp_year = p_exp_year_msk.Text.Trim();

                p_temp_err_bool = false;
                if (Regex.IsMatch(sel_exp_day, PLConstants.reg_exact_day_of_date) && Regex.IsMatch(sel_exp_month, PLConstants.reg_exact_month_of_date) && Regex.IsMatch(sel_exp_year, PLConstants.reg_exact_year_of_date))
                {
                    if (sel_vis_day != null)
                    {
                        if ((sel_exp_year + sel_exp_month + sel_exp_day).CompareTo(sel_vis_year + sel_vis_month + sel_vis_day) >= 0)
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
                else if (sel_exp_day == "" && sel_exp_month == "" && sel_exp_year == "" && is_batch)// && p_exp_chk.Checked)
                {
                    sel_exp_day = sel_exp_month = sel_exp_year = PLConstants.str_unchanged;
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
                    EP_p_exp.SetError(p_exp_year_msk, PLConstants.error_date);
                }
            }
            else
            {
                sel_exp_day = PLGlobalFuncs.getDaysCountOfMonth(sel_vis_month);
                sel_exp_month = sel_vis_month;
                sel_exp_year = sel_vis_year;
            }

            ////////////////////////////////////////////////////// prescriptor doctor
            if (p_params_row.p_prescriptor_doctor)
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
                else if (p_temp_str == "" && is_batch)// && p_pre_doc_chk.Checked)
                {
                    sel_prescriptor_doctor = -1;
                    p_temp_err_bool = false;
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
            else if (is_batch)
            {
                if (p_fun_doc_chk.Checked) { sel_prescriptor_doctor = -1; }
                else if(p_params_row.p_functor_doctor)
                { 
                    sel_prescriptor_doctor = sel_fun_doctor;
                }
                else
                {
                    sel_prescriptor_doctor = (int)p_fun_doc_cbx.SelectedValue;
                }
            }
            else
            {
                sel_prescriptor_doctor = sel_fun_doctor;
            }

            ////////////////////////////////////////////////////// prescription date
            if (p_params_row.p_service_date)
            {
                sel_prescriptor_day = p_pre_day_msk.Text;
                sel_prescriptor_month = p_pre_month_msk.Text;
                sel_prescriptor_year = p_pre_year_msk.Text.Trim();

                if (Regex.IsMatch(sel_prescriptor_day, PLConstants.reg_exact_day_of_date) && Regex.IsMatch(sel_prescriptor_month, PLConstants.reg_exact_month_of_date) && Regex.IsMatch(sel_prescriptor_year, PLConstants.reg_exact_year_of_date))
                {
                    if (sel_vis_day != null)
                    {
                        if ((sel_prescriptor_year + sel_prescriptor_month + sel_prescriptor_day).CompareTo(sel_vis_year + sel_vis_month + sel_vis_day) <= 0)
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
                else if (sel_prescriptor_day == "" && sel_prescriptor_month == "" && sel_prescriptor_year == "" && is_batch)// && p_pre_date_chk.Checked)
                {
                    sel_prescriptor_day = sel_prescriptor_month = sel_prescriptor_year = PLConstants.str_unchanged;
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
                    EP_p_pre_date.SetError(p_pre_year_msk, PLConstants.error_date);
                }
            }
            else if (is_batch)
            {
                if (p_vis_day_chk.Checked)
                {
                    sel_prescriptor_day = PLConstants.str_unchanged;
                }
                else
                {
                    sel_prescriptor_day = sel_vis_day;
                }
                sel_prescriptor_month = sel_vis_month;
                sel_prescriptor_year = sel_vis_year;
            }
            else
            {
                sel_prescriptor_day = sel_vis_day;
                sel_prescriptor_month = sel_vis_month;
                sel_prescriptor_year = sel_vis_year;
            }

            /////////////////////////////////////////////////////////////////// save edit
            if (p_i_err_cou > 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_has_error);
            }
            else if (!p_process_insured_exist_checking)
            {
                if (sel_insured_code != "" && sel_insured_code != null)
                {
                    if (!p_is_insured_exist)
                    {
                        insured_activity = PLConstants.enum_activity_types.AddInsuredWithUpdate;
                    }
                }
                else if (sel_sector != first_sector)
                {
                    insured_activity = PLConstants.enum_activity_types.EditInsured;
                }
                org_save_info_func();
                p_pres_op_result = PLEnumFuncs.prescriptionResultToEnum(p_save_info_result);
                switch (p_pres_op_result)
                {
                    case PLConstants.enum_prescription_results.success:
                        pgs_dialog.operationResult(PLConstants.enum_operation_results.success, PLConstants.enum_information_part.other);
                        were_actions_successeded = true;
                        Close();
                        break;
                    default:
                        SystemSounds.Beep.Play();
                        pgs_dialog.prescriptionOperationResult(p_pres_op_result);
                        were_actions_successeded = false;
                        break;
                }
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_pres_process_info_checking);
            }
        }

        private void saveTaminEjtemaei_Info()
        {
            p_prescription_info_adapter.EditTaminEjtemaeiPreses(is_batch,sel_prescriptions,pres_save_sequence, (short?)PLConstants.enum_activity_types.EditPresInfo, (short?)insured_activity,
                                                    PLConstants.UserCode,sel_center,p_sel_part_value,sel_insurance,first_sector,sel_sector,sel_vis_day,sel_vis_month,sel_vis_year, !(p_is_insured_exist || p_is_insured_empty),
                                                    p_insured_sequence, var_get_identifier_func(), sel_insured_name, sel_insured_family, var_get_serial_func(), sel_page, sel_fun_doctor,
                                                    sel_exp_day, sel_exp_month, sel_exp_year, sel_prescriptor_doctor,sel_prescriptor_day,sel_prescriptor_month,sel_prescriptor_year, ref p_save_info_result, ref p_temp_str);
        }
        private void saveNirooMosalah_Info()
        {
            p_prescription_info_adapter.EditNirooMosalahPreses(is_batch, sel_prescriptions, pres_save_sequence, (short?)PLConstants.enum_activity_types.EditPresInfo, (short?)insured_activity,
                                                    PLConstants.UserCode, sel_center, p_sel_part_value, sel_insurance, first_sector, sel_sector, sel_vis_day, sel_vis_month, sel_vis_year, !(p_is_insured_exist || p_is_insured_empty),
                                                    p_insured_sequence, var_get_identifier_func(), sel_insured_name, sel_insured_family, var_get_serial_func(), sel_page, sel_fun_doctor,
                                                    sel_exp_day, sel_exp_month, sel_exp_year, sel_prescriptor_doctor, sel_prescriptor_day, sel_prescriptor_month, sel_prescriptor_year, ref p_save_info_result, ref p_temp_str);
        }
        private void saveSalamat_Info()
        {
            p_prescription_info_adapter.EditSalamatPreses(is_batch, sel_prescriptions, pres_save_sequence, (short?)PLConstants.enum_activity_types.EditPresInfo, (short?)insured_activity,
                                                    PLConstants.UserCode, sel_center, p_sel_part_value, sel_insurance, first_sector, sel_sector, sel_vis_day, sel_vis_month, sel_vis_year, !(p_is_insured_exist || p_is_insured_empty),
                                                    p_insured_sequence, var_get_identifier_func(), sel_insured_name, sel_insured_family, var_get_serial_func(), sel_page, sel_fun_doctor,
                                                    sel_exp_day, sel_exp_month, sel_exp_year, sel_prescriptor_doctor, sel_prescriptor_day, sel_prescriptor_month, sel_prescriptor_year, ref p_save_info_result, ref p_temp_str);
        }
        private void saveKomitehEmdad_Info()
        {
            p_prescription_info_adapter.EditKomitehEmdadPreses(is_batch, sel_prescriptions, pres_save_sequence, (short?)PLConstants.enum_activity_types.EditPresInfo, (short?)insured_activity,
                                                    PLConstants.UserCode, sel_center, p_sel_part_value, sel_insurance, first_sector, sel_sector, sel_vis_day, sel_vis_month, sel_vis_year, !(p_is_insured_exist || p_is_insured_empty),
                                                    p_insured_sequence, var_get_identifier_func(), sel_insured_name, sel_insured_family, var_get_serial_func(), sel_page, sel_fun_doctor,
                                                    sel_exp_day, sel_exp_month, sel_exp_year, sel_prescriptor_doctor, sel_prescriptor_day, sel_prescriptor_month, sel_prescriptor_year, ref p_save_info_result, ref p_temp_str);
        }
        private void saveOther_Info()
        {
            p_prescription_info_adapter.EditOtherPreses(is_batch, sel_prescriptions, pres_save_sequence, (short?)PLConstants.enum_activity_types.EditPresInfo, (short?)insured_activity,
                                                    PLConstants.UserCode, sel_center, p_sel_part_value, sel_insurance, first_sector, sel_sector, sel_vis_day, sel_vis_month, sel_vis_year, !(p_is_insured_exist || p_is_insured_empty),
                                                    p_insured_sequence, var_get_identifier_func(), sel_insured_name, sel_insured_family, var_get_serial_func(), sel_page, sel_fun_doctor,
                                                    sel_exp_day, sel_exp_month, sel_exp_year, sel_prescriptor_doctor, sel_prescriptor_day, sel_prescriptor_month, sel_prescriptor_year, ref p_save_info_result, ref p_temp_str);
        }

        private void p_other_sectors_lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            p_other_sectors_form.showWithData(insurance_org, c_insurance_cbx.Text, c_sector_cbx.Text, sel_insured_code);
        }
        private void p_previous_btn_Click(object sender, EventArgs e)
        {
            main_tabControl.SelectedTab = center_tab;
            center_tab.Enabled = true;
            prescription_tab.Enabled = false;
        }

        #endregion PRESCRIPTION TAB

    }
}
