using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class PresDataParametersForm : Form
    {
        int properties_count;
        object[] new_data;
        object[] current_data;
        Type[] data_types;
        bool[] allow_validating;
        bool[] allow_batch_validating;
        bool[] allow_null;
        string[] regex;
        string[] error_text;
        bool[] errors;
        int error_count;

        DataTable selected_data_params;

        Control[] data_controls;
        Label[] lable_controls;
        Type[] control_types;
        TextBox[] text_controls;
        ComboBox[] combo_controls;
        MaskedTextBox[] masked_controls;
        CheckBox[] clear_checkboxes;
        ErrorProvider[] error_providers;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;
        PLConstants.enum_data_operation form_operation;

        Type int_type;
        Type string_type;
        Type bool_type;

        Type textbox_type;
        Type combobox_type;
        Type masked_type;
        Type label_type;

        PIPDataSetTableAdapters.TPresDataParametersTableAdapter dp_adapter;
        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;
        PIPDataSet.TClinicTypeDataTable ct_data;
        PIPDataSetTableAdapters.SClinicPartTableAdapter cp_adapter;
        PIPDataSet.SClinicPartDataTable cp_data;
        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSet.TInsuranceDataTable ins_data;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sec_adapter;
        PIPDataSet.TInsuranceSectorDataTable sec_data;

        public PresDataParametersForm(PIPDataSet.TPresDataParametersRow data_row, PLConstants.enum_data_operation operation, DataTable selected_data_params)//checked
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            properties_count = 30;
            new_data = new object[properties_count];

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            masked_type= typeof(MaskedTextBox);
            label_type = typeof(Label);

            errors = new bool[properties_count];
            data_types = new Type[] { null, 
                                      int_type, int_type,int_type,int_type,
                                      bool_type,bool_type,bool_type,bool_type,bool_type,bool_type,
                                      bool_type,bool_type,bool_type,bool_type,bool_type,bool_type,
                                      bool_type,
                                      int_type,int_type,
                                      string_type,
                                      int_type,int_type,int_type,int_type,int_type,int_type,int_type,
                                      bool_type,
                                      int_type};
            allow_validating = new bool[] { false,
                                            true, true,true,true,
                                            true, true,true, true,true,true,
                                            true, true, true,true,true,true,
                                            true,
                                            true,true,
                                            true,
                                            true, true, true,true,true,true, true, 
                                            true,
                                            true };
            allow_batch_validating = new bool[] { false,
                                                  false, false, false, false,
                                                  true, true, true, true, true, true,
                                                  true, true, true, true, true, true,
                                                  true,
                                                  true, true,
                                                  true,
                                                  true, true, true, true, true,true, true,
                                                  true, 
                                                  true };
            allow_null = new bool[] { false,
                                    false, true, false, true,
                                    false, false, false, false, false, false,
                                    false, false, false, false, false, false,
                                    false,
                                    true, true,
                                    true,
                                    true, true, true, true, true,true, true, 
                                    true, 
                                    true };
            regex = new string[] { null,
                                   PLConstants.reg_name, PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,
                                   PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name, PLConstants.reg_name,
                                   PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name, PLConstants.reg_name,
                                   PLConstants.reg_name,
                                   PLConstants.reg_number,PLConstants.reg_number,
                                   null,
                                   PLConstants.reg_number,PLConstants.reg_number,PLConstants.reg_number,PLConstants.reg_number,PLConstants.reg_number,
                                   PLConstants.reg_number,PLConstants.reg_number,
                                   PLConstants.reg_name,
                                   PLConstants.reg_number};
            error_text = new string[] { null, 
                                        PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,
                                        PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,
                                        PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,
                                        PLConstants.error_combo_not_selected,
                                        PLConstants.error_numbers_int,PLConstants.error_numbers_int,
                                        PLConstants.error_not_valid,
                                        PLConstants.error_numbers_int,PLConstants.error_numbers_int,PLConstants.error_numbers_int,PLConstants.error_numbers_int,PLConstants.error_numbers_int,
                                        PLConstants.error_numbers_int,PLConstants.error_numbers_int,
                                        PLConstants.error_combo_not_selected,
                                        PLConstants.error_numbers_int};

            data_controls = new Control[] { sequence_textbox,
                                            clinic_type_combobox,clinic_part_combobox,insurance_combobox,insurance_sector_combobox,
                                            p_visit_date_combobox,p_id_combobox,p_serial_combobox,p_page_number_combobox,p_functor_doctor_combobox,p_name_combobox,
                                            p_family_name_combobox,p_expiration_date_combobox,p_service_date_combobox,p_prescriptor_doctor_combobox,p_service_count_combobox,p_service_code_combobox,
                                            serial_include_id_combobox,
                                            id_exact_length_masked, id_min_length_masked,
                                            id_regex_textbox,
                                            id_code_exact_length_masked,id_code_min_length_masked,id_code_start_index_masked,id_other_min_length_masked,id_other_start_index_masked,
                                            id_page_exact_length_masked,id_page_min_length_masked,
                                            id_page_from_end_combobox,
                                            id_page_start_index_masked };
            lable_controls = new Label[] { sequence_label,
                                            clinic_type_label,clinic_part_label,insurance_label,insurance_sector_label,
                                            p_visit_date_label,p_id_label,p_serial_label,p_page_number_label,p_functor_doctor_label,p_name_label,
                                            p_family_name_label,p_expiration_date_label,p_service_date_label,p_prescriptor_doctor_label,p_service_count_label,p_service_code_label,
                                            serial_include_id_label,
                                            id_exact_length_label, id_min_length_label,
                                            id_regex_label,
                                            id_code_exact_length_label,id_code_min_length_label,id_code_start_index_label,id_other_min_length_label,id_other_start_index_label,
                                            id_page_exact_length_label,id_page_min_length_label,
                                            id_page_from_end_label,
                                            id_page_start_index_label};
            control_types = new Type[] { textbox_type,
                                        combobox_type,combobox_type,combobox_type,combobox_type,
                                        combobox_type,combobox_type,combobox_type,combobox_type,combobox_type,combobox_type,
                                        combobox_type,combobox_type,combobox_type,combobox_type,combobox_type,combobox_type,
                                        combobox_type,
                                        masked_type, masked_type,
                                        textbox_type,
                                        masked_type,masked_type,masked_type,masked_type,masked_type,
                                        masked_type,masked_type,
                                        combobox_type,
                                        masked_type};
            text_controls = new TextBox[] { sequence_textbox,id_regex_textbox};
            combo_controls = new ComboBox[] { clinic_type_combobox,clinic_part_combobox,insurance_combobox,insurance_sector_combobox,
                                            p_visit_date_combobox,p_id_combobox,p_serial_combobox,p_page_number_combobox,p_functor_doctor_combobox,p_name_combobox,
                                            p_family_name_combobox,p_expiration_date_combobox,p_service_date_combobox,p_prescriptor_doctor_combobox,p_service_count_combobox,p_service_code_combobox,
                                            serial_include_id_combobox,
                                            id_page_from_end_combobox};
            masked_controls = new MaskedTextBox[] { id_exact_length_masked, id_min_length_masked,
                                            id_code_exact_length_masked,id_code_min_length_masked,id_code_start_index_masked,id_other_min_length_masked,id_other_start_index_masked,
                                            id_page_exact_length_masked,id_page_min_length_masked,
                                            id_page_start_index_masked};
            clear_checkboxes = new CheckBox[]{ sequence_checkbox,
                                            clinic_type_checkbox,clinic_part_checkbox,insurance_checkbox,insurance_sector_checkbox,
                                            p_visit_date_checkbox,p_id_checkbox,p_serial_checkbox,p_page_number_checkbox,p_functor_doctor_checkbox,p_name_checkbox,
                                            p_family_name_checkbox,p_expiration_date_checkbox,p_service_date_checkbox,p_prescriptor_doctor_checkbox,p_service_count_checkbox,p_service_code_checkbox,
                                            serial_include_id_checkbox,
                                            id_exact_length_checkbox, id_min_length_checkbox,
                                            id_regex_checkbox,
                                            id_code_exact_length_checkbox,id_code_min_length_checkbox,id_code_start_index_checkbox,id_other_min_length_checkbox,id_other_start_index_checkbox,
                                            id_page_exact_length_checkbox,id_page_min_length_checkbox,
                                            id_page_from_end_checkbox,
                                            id_page_start_index_checkbox};
            error_providers = new ErrorProvider[] { null,
                                            EP_clinic_type,null,EP_insurance,null,
                                            EP_p_visit_date,EP_p_id,EP_p_serial,EP_p_page_number,EP_p_functor_doctor,EP_p_name,
                                            EP_p_family_name,EP_p_expiration_date,EP_p_service_date,EP_p_prescriptor_doctor,EP_p_service_count,EP_p_service_code,
                                            EP_serial_include_id,
                                            EP_id_exact_length, EP_id_min_length,
                                            EP_id_regex,
                                            EP_id_code_exact_length,EP_id_code_min_length,EP_id_code_start_index,EP_id_other_min_length,EP_id_other_start_index,
                                            EP_id_page_exact_length,EP_id_page_min_length,
                                            null,
                                            EP_id_page_start_index};
            
            this.selected_data_params = selected_data_params;
            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            dp_adapter = new PIPDataSetTableAdapters.TPresDataParametersTableAdapter();
            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            cp_adapter = new PIPDataSetTableAdapters.SClinicPartTableAdapter();
            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sec_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            ct_data = new PIPDataSet.TClinicTypeDataTable();
            cp_data = new PIPDataSet.SClinicPartDataTable();
            ins_data = new PIPDataSet.TInsuranceDataTable();
            sec_data = new PIPDataSet.TInsuranceSectorDataTable();

            initComboBoxes();
            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد تنظیمات جدید برای پارامترهای ثبت نسخ";
                for (int i = 0; i < properties_count; i++)
                {
                    if (allow_validating[i])
                    {
                        data_controls[i].Enabled = true;
                        if (!allow_null[i])
                        {
                            error_providers[i].SetError(data_controls[i], error_text[i]);
                        }
                    }
                }
                errors = new bool[] { false,
                                    true, false, true, false,
                                    true, true, true, true, true, true,
                                    true, true, true, true, true, true,
                                    true,
                                    false, false,
                                    false,
                                    false, false, false, false, false,false, false, 
                                    false, 
                                    false };
                error_count = 15;
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                errors = new bool[properties_count];
                error_count = 0;
                current_data = new object[]{data_row.sequence,
                                            data_row.clinic_type,data_row.clinic_part,data_row.insurance,data_row.insurance_sector,
                                            data_row.p_visit_date,data_row.p_id,data_row.p_serial,data_row.p_page_number,data_row.p_functor_doctor,data_row.p_name,
                                            data_row.p_family_name,data_row.p_expiration_date,data_row.p_service_date,data_row.p_prescriptor_doctor,data_row.p_service_count,data_row.p_service_code,
                                            data_row.serial_include_id,
                                            data_row.id_exact_length, data_row.id_min_length,
                                            data_row.id_regex,
                                            data_row.id_code_exact_length,data_row.id_code_min_length,data_row.id_code_start_index,data_row.id_other_min_length,data_row.id_other_start_index,
                                            data_row.id_page_exact_length,data_row.id_page_min_length,
                                            data_row.id_page_from_end,
                                            data_row.id_page_start_index};

                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ویرایش تنظیمات پارامترهای ثبت نسخ";
                for (int i = 0; i < properties_count; i++)
                {
                    if (allow_validating[i])
                    {
                        data_controls[i].Enabled = true;
                    }
                    if (current_data[i] != null)
                    {
                        if (control_types[i] == combobox_type)
                        {
                            combo_controls[cc].SelectedValue = current_data[i].ToString();
                            current_data[i] = combo_controls[cc].Text;
                            cc++;
                        }
                        else if (control_types[i] == textbox_type)
                        {
                            text_controls[tc].Text = current_data[i].ToString();
                            tc++;
                        }
                        else if (control_types[i] == masked_type)
                        {
                            masked_controls[mc].Text = current_data[i].ToString();
                            mc++;
                        }
                    }
                    else if (control_types[i] == combobox_type)
                    {
                        cc++;
                    }
                    else if (control_types[i] == textbox_type)
                    {
                        tc++;
                    }
                    else
                    {
                        mc++;
                    }
                }
            }
            else if (operation == PLConstants.enum_data_operation.batch_edit)
            {
                errors = new bool[properties_count];
                error_count = 0;
                this.Text = "ویرایش دسته ای تنظیمات پارامترهای ثبت نسخ";
                clear_label.Visible = true;
                for (int i = 0; i < properties_count; i++)
                {
                    if (allow_batch_validating[i])
                    {
                        data_controls[i].Enabled = true;
                    }
                    if (allow_null[i])
                    {
                        clear_checkboxes[i].Enabled = true;
                    }
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)//checked
        {
            int tc = 0;
            int cc = 0;

            if (error_count > 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_has_error);
            }
            else if (form_operation == PLConstants.enum_data_operation.new_data)
            {
                List<string> message_text = new List<string>();
                message_text.Add("اطلاعات جدید");
                for (int i = 0; i < properties_count; i++)
                {
                    if (allow_validating[i])
                    {
                        if ((control_types[i] == textbox_type) && (new_data[i] != null))
                        {
                            message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                        }
                        else if ((control_types[i] == combobox_type) && (new_data[i] != null))
                        {
                            message_text.Add(lable_controls[i].Text + combo_controls[cc].Text);
                            cc++;
                        }
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string add_result = "";
                        //dp_adapter.AddDoctor(Convert.ToInt32(new_data[1]), (string)new_data[2],
                        //                    (string)new_data[3], (bool)new_data[4], (string)new_data[7], (int)new_data[9],
                        //                    (string)new_data[10], (string)new_data[11], (string)new_data[12],
                        //                    (string)new_data[13], (string)new_data[14], (int)new_data[5],
                        //                    (int)new_data[6], (string)new_data[15], ref add_result);
                        result_enum = PLEnumFuncs.opResultToEnum(add_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                this.Close();
                                break;
                        }
                        break;
                }
            }
            else if (form_operation == PLConstants.enum_data_operation.edit_data)
            {
                List<string> message_text = new List<string>();
                message_text.Add(PLConstants.question_save_edit);
                message_text.Add("اطلاعات کنونی");
                for (int i = 0; i < properties_count; i++)
                {
                    if (current_data[i] != null)
                    {
                        message_text.Add(lable_controls[i].Text + current_data[i].ToString());
                    }
                }
                message_text.Add("اطلاعات جدید");
                for (int i = 0; i < properties_count; i++)
                {
                    if (allow_validating[i] && new_data[i] != null)
                    {
                        if (control_types[i] == textbox_type)
                        {
                            message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                            tc++;
                        }
                        else if (control_types[i] == combobox_type)
                        {
                            message_text.Add(lable_controls[i].Text + combo_controls[cc].Text);
                            cc++;
                        }
                    }
                    else if (control_types[i] == textbox_type)
                    {
                        tc++;
                    }
                    else
                    {
                        cc++;
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        //dp_adapter.EditDoctors(false, (int)new_data[0], PLGlobalFuncs.emptyIntIDsDataTable(), Convert.ToInt32(new_data[1]), (string)new_data[2],
                        //                      (string)new_data[3], (bool)new_data[4], (string)new_data[7], (int)new_data[9],
                        //                      (string)new_data[10], (string)new_data[11], (string)new_data[12], (string)new_data[13],
                        //                      (string)new_data[14], (int)new_data[5], (int)new_data[6], (string)new_data[15],
                        //                      ref edit_result);
                        result_enum = PLEnumFuncs.opResultToEnum(edit_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                this.Close();
                                break;
                        }
                        break;
                }
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_edit)
            {
                List<string> message_text = new List<string>();
                message_text.Add(PLConstants.question_save_edit);
                message_text.Add("ویرایش دسته ای اطلاعات " + selected_data_params.Rows.Count + " مورد");
                message_text.Add("اطلاعات جدید");
                for (int i = 0; i < properties_count; i++)
                {
                    if (allow_batch_validating[i])
                    {
                        if (clear_checkboxes[i].Checked)
                        {
                            message_text.Add(lable_controls[i].Text + "پاک شدن اطلاعات ");
                        }
                        else if (control_types[i] == textbox_type)
                        {
                            if (new_data[i] != null)
                            {
                                message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                            }
                            tc++;
                        }
                        else if (control_types[i] == combobox_type)
                        {
                            if (new_data[i] != null)
                            {
                                message_text.Add(lable_controls[i].Text + combo_controls[cc].Text);
                            }
                            cc++;
                        }
                    }
                    else if (control_types[i] == textbox_type)
                    {
                        tc++;
                    }
                    else if (control_types[i] == combobox_type)
                    {
                        cc++;
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        //dp_adapter.EditDoctors(true, null, selected_data_params, (int?)new_data[1], (string)new_data[2],
                        //                      (string)new_data[3], (bool?)new_data[4], (string)new_data[7], (int?)new_data[9],
                        //                      (string)new_data[10], (string)new_data[11], (string)new_data[12], (string)new_data[13],
                        //                      (string)new_data[14], (int?)new_data[5], (int?)new_data[6], (string)new_data[15],
                        //                      ref edit_result);
                        result_enum = PLEnumFuncs.opResultToEnum(edit_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.other);
                        switch (result_enum)
                        {
                            case PLConstants.enum_operation_results.success:
                                this.Close();
                                break;
                        }
                        break;
                }
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)//checked
        {
            this.Close();
        }

        private void textbox_control_Leave(object sender, EventArgs e)//checked
        {
            TextBox t_box = (TextBox)sender;
            int t_ind = int.Parse(t_box.Tag.ToString());
            string t_text = t_box.Text.Trim();

            if (t_text == "")
            {
                if (allow_null[t_ind] || (form_operation == PLConstants.enum_data_operation.batch_edit))
                {
                    new_data[t_ind] = null;
                    if (errors[t_ind])
                    {
                        error_providers[t_ind].Clear();
                        error_count--;
                        errors[t_ind] = false;
                        t_box.BackColor = Color.White;
                    }
                }
                else if (!errors[t_ind])
                {
                    error_count++;
                    errors[t_ind] = true;
                    t_box.BackColor = Color.Red;
                    error_providers[t_ind].SetError(t_box, error_text[t_ind]);
                }
            }
            else if (Regex.IsMatch(t_text, regex[t_ind]))
            {
                new_data[t_ind] = t_text;
                if (errors[t_ind])
                {
                    error_providers[t_ind].Clear();
                    error_count--;
                    errors[t_ind] = false;
                    t_box.BackColor = Color.White;
                }
            }
            else if (!errors[t_ind])
            {
                error_count++;
                errors[t_ind] = true;
                t_box.BackColor = Color.Red;
                error_providers[t_ind].SetError(t_box, error_text[t_ind]);
            }

        }
        private void id_exact_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_min_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_code_exact_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_code_min_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_code_start_index_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_other_min_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_other_start_index_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_page_exact_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_page_min_length_masked_Leave(object sender, EventArgs e)
        {

        }
        private void id_page_start_index_masked_Leave(object sender, EventArgs e)
        {

        }

        private void clinic_type_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(clinic_type_combobox.Tag.ToString());
            if (clinic_type_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = clinic_type_combobox.SelectedValue;
                if (errors[c_ind] || false)
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    clinic_type_combobox.BackColor = Color.White;
                }
                initClinicPartCombobox((int)clinic_type_combobox.SelectedValue);
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_edit)
            {
                new_data[c_ind] = null;
                if (errors[c_ind])
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    clinic_type_combobox.BackColor = Color.White;
                }
            }
            else
            {
                error_providers[c_ind].SetError(clinic_type_combobox, error_text[c_ind]);
                error_count++;
                errors[c_ind] = true;
                clinic_type_combobox.BackColor = Color.Red;
                clinic_type_combobox.DataSource = null;
            }
        }
        private void insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(insurance_combobox.Tag.ToString());
            if (insurance_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = insurance_combobox.SelectedValue;
                if (errors[c_ind] || false)
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    insurance_combobox.BackColor = Color.White;
                }
                initInsSectorComboBox((int)insurance_combobox.SelectedValue);
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_edit)
            {
                new_data[c_ind] = null;
                if (errors[c_ind])
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    insurance_combobox.BackColor = Color.White;
                }
            }
            else
            {
                error_providers[c_ind].SetError(insurance_combobox, error_text[c_ind]);
                error_count++;
                errors[c_ind] = true;
                insurance_combobox.BackColor = Color.Red;
                insurance_combobox.DataSource = null;
            }
        }
        private void serial_include_id_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void combobox_control_SelectedIndexChanged(object sender, EventArgs e)//checked
        {
            ComboBox c_box = (ComboBox)sender;
            int c_ind = int.Parse(c_box.Tag.ToString());

            if (c_box.SelectedIndex > 0)
            {
                new_data[c_ind] = c_box.SelectedValue;
                if (errors[c_ind])
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    c_box.BackColor = Color.White;
                }
            }
            else if (allow_null[c_ind] || (form_operation == PLConstants.enum_data_operation.batch_edit))
            {
                new_data[c_ind] = null;
                if (errors[c_ind])
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    c_box.BackColor = Color.White;
                }
            }
            else if (!errors[c_ind])
            {
                error_providers[c_ind].SetError(c_box, error_text[c_ind]);
                error_count++;
                errors[c_ind] = true;
                c_box.BackColor = Color.Red;
            }
        }

        private void clear_checkboxes_CheckedChanged(object sender, EventArgs e)//checked
        {
            CheckBox ch_box = (CheckBox)sender;
            int ch_ind = int.Parse(ch_box.Tag.ToString());
            if (ch_box.Checked)
            {
                if (control_types[ch_ind] == textbox_type)
                {
                    new_data[ch_ind] = null;
                    data_controls[ch_ind].Text = "";
                }
                else if (control_types[ch_ind] == combobox_type)
                {
                    new_data[ch_ind] = null;
                    ((ComboBox)data_controls[ch_ind]).SelectedIndex = 0;
                }
                if (errors[ch_ind])
                {
                    error_providers[ch_ind].Clear();
                    error_count--;
                    errors[ch_ind] = false;
                    data_controls[ch_ind].BackColor = Color.White;
                }
                data_controls[ch_ind].Enabled = false;
                if (data_types[ch_ind] == int_type)
                {
                    new_data[ch_ind] = PLConstants.int_minus_11;
                }
                else if (data_types[ch_ind] == string_type)
                {
                    new_data[ch_ind] = PLConstants.str_clear;
                }
            }
            else
            {
                data_controls[ch_ind].Enabled = true;
            }
        }

        private void initComboBoxes()//checked
        {
            ct_data = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow mc_first_row = ct_data.NewTClinicTypeRow();
            mc_first_row.id = -1;
            mc_first_row.name = "--نوع مرکز--";
            ct_data.Rows.InsertAt(mc_first_row, 0);
            clinic_type_combobox.DataSource = ct_data;
            clinic_type_combobox.DisplayMember = ct_data.nameColumn.ColumnName;
            clinic_type_combobox.ValueMember = ct_data.idColumn.ColumnName;
            clinic_type_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(clinic_type_combobox);

            ins_data = ins_adapter.GetAllInsurances();
            PIPDataSet.TInsuranceRow i_first_row = ins_data.NewTInsuranceRow();
            i_first_row.id = -1;
            i_first_row.name = "---شرکت بیمه---";
            ins_data.Rows.InsertAt(i_first_row, 0);
            insurance_combobox.DataSource = ins_data;
            insurance_combobox.DisplayMember = ins_data.nameColumn.ColumnName;
            insurance_combobox.ValueMember = ins_data.idColumn.ColumnName;
            insurance_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_combobox);

            PLGlobalFuncs.activationForComboBox(p_visit_date_combobox, p_visit_date_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_id_combobox, p_id_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_serial_combobox, p_serial_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_page_number_combobox, p_page_number_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_functor_doctor_combobox, p_functor_doctor_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_name_combobox, p_name_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_family_name_combobox, p_family_name_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_expiration_date_combobox, p_expiration_date_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_prescriptor_doctor_combobox, p_prescriptor_doctor_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_service_date_combobox, p_service_date_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_service_count_combobox, p_service_count_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.activationForComboBox(p_service_code_combobox, p_service_code_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.yesNoForComboBox(serial_include_id_combobox, serial_include_id_label.Text.Trim(' ', ':'));
            PLGlobalFuncs.yesNoForComboBox(id_page_from_end_combobox, id_page_from_end_label.Text.Trim(' ', ':'));            
        }
        private void initClinicPartCombobox(int selected_type)//checked
        {
            cp_adapter.FillByClinicType(cp_data,selected_type);
            PIPDataSet.SClinicPartRow p_first_row = cp_data.NewSClinicPartRow();
            p_first_row.id = -1;
            p_first_row.name = "--بخش درمانی از مرکز--";
            cp_data.Rows.InsertAt(p_first_row, 0);
            clinic_part_combobox.DataSource = cp_data;
            clinic_part_combobox.DisplayMember = cp_data.nameColumn.ColumnName;
            clinic_part_combobox.ValueMember = cp_data.idColumn.ColumnName;
            clinic_part_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(clinic_part_combobox);
        }
        private void initInsSectorComboBox(int selected_insurance)//checked
        {
            sec_data = sec_adapter.GetAllSectors(selected_insurance);
            PIPDataSet.TInsuranceSectorRow s_first_row = sec_data.NewTInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "--صندوق بیمه--";
            sec_data.Rows.InsertAt(s_first_row, 0);
            insurance_sector_combobox.DataSource = sec_data;
            insurance_sector_combobox.DisplayMember = sec_data.nameColumn.ColumnName;
            insurance_sector_combobox.ValueMember = sec_data.idColumn.ColumnName;
            insurance_sector_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_sector_combobox);
        }




    }
}
