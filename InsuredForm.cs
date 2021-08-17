using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class InsuredForm : Form
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

        DataTable selected_insureds;
        PIPDataSet.TInsuranceRow selected_ins;
        PLConstants.enum_insurances ins_enum;
        int new_sector_id;

        Control[] data_controls;
        Label[] lable_controls;
        Type[] control_types;
        TextBox[] text_controls;
        ComboBox[] combo_controls;
        MaskedTextBox[] masked_controls;
        CheckBox[] clear_checkboxes;
        ErrorProvider[] error_providers;

        int ind_insurance = 0, ind_sequence = 1, ind_id = 2, ind_sector = 3, ind_name = 4, ind_family = 5, ind_natioanl_code = 6, ind_exp = 7;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;
        PLConstants.enum_data_operation form_operation;

        Type int_type;
        Type string_type;
        Type bool_type;
        Type long_type;

        Type textbox_type;
        Type combobox_type;
        Type label_type;
        Type masked_type;
 
        PIPDataSetTableAdapters.TInsuredTableAdapter i_adapter;
        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sec_adapter;
        PIPDataSet.TInsuranceDataTable ins_data;
        PIPDataSet.TInsuranceSectorDataTable sec_table;

        public InsuredForm(PIPDataSet.TInsuranceRow insurance_row, PLConstants.enum_insurances insurance_enum, PIPDataSet.TInsuredRow data_row, PLConstants.enum_data_operation operation, DataTable selected_insureds)//checked
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            properties_count = 8;
            new_data = new object[properties_count];

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            i_adapter = new PIPDataSetTableAdapters.TInsuredTableAdapter();
            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sec_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);
            long_type = typeof(long);

            this.selected_ins = insurance_row;
            this.selected_insureds = selected_insureds;
            this.ins_enum = insurance_enum;

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);
            masked_type = typeof(MaskedTextBox);

            data_types = new Type[] { string_type, long_type, string_type,
                                      int_type, string_type,string_type,
                                      string_type, string_type};
            allow_validating = new bool[] { false, false, true,
                                            true, true,true, 
                                            true,true };
            allow_batch_validating = new bool[] { false, false, false,
                                                  true,true,true,
                                                  false,true};
            allow_null = new bool[] { false, false, false,
                                      false,false,false,
                                      true,true};
            errors = new bool[properties_count];
            regex = new string[] { PLConstants.reg_name, null, PLConstants.reg_id,
                                   PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,
                                   PLConstants.reg_national_code,PLConstants.reg_date_slash};
            error_text = new string[] { PLConstants.error_combo_not_selected, null, PLConstants.error_id,
                                        PLConstants.error_combo_not_selected,PLConstants.error_names,PLConstants.error_names,
                                        PLConstants.error_numbers_int,PLConstants.error_date};
            data_controls = new Control[] { insurance_combobox,seqeunce_textbox,id_textbox,
                                            sector_combobox,name_textbox,family_name_textbox,
                                            national_code_textbox,exp_masked};
            lable_controls = new Label[] { insurance_label,seqeunce_label,id_label,
                                            sector_label,name_label,family_name_label,
                                            national_code_label,exp_label};
            control_types = new Type[] { combobox_type, textbox_type, textbox_type,
                                         combobox_type,textbox_type,textbox_type,
                                         textbox_type,masked_type};
            text_controls = new TextBox[] { seqeunce_textbox,id_textbox,
                                            name_textbox,family_name_textbox,
                                            national_code_textbox};
            combo_controls = new ComboBox[] { insurance_combobox, sector_combobox};
            clear_checkboxes = new CheckBox[]{insurance_checkbox,seqeunce_checkbox,id_checkbox,
                                            sector_checkbox,name_checkbox,family_name_checkbox,
                                            national_code_checkbox,exp_checkbox};
            masked_controls = new MaskedTextBox[] { exp_masked };
            error_providers = new ErrorProvider[] { EP_insurance, null, EP_id,
                                                    EP_sector,EP_name,EP_family,
                                                    EP_national,EP_exp};

            

            if (operation == PLConstants.enum_data_operation.new_data)
            {
                allow_validating[ind_insurance] = true;
                this.Text = "ایجاد بیمه شده جدید";
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
                errors = new bool[] { true, false, true,
                                      false,true,true,false,
                                      false};
                error_count = 4;
                initInsuranceComboBox();
                insurance_combobox.Select();
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                initInsuranceComboBox();
                error_count = 0;
                current_data = new object[]{selected_ins.id,data_row.sequence,data_row.id,
                                            data_row.insurance_sector,data_row.name,data_row.family_name,
                                            data_row.national_code,data_row.exp_complete};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ویرایش اطلاعات بیمه شده";
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
                            combo_controls[cc].SelectedValue = current_data[i];
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
                id_textbox.Select();
            }
            else if (operation == PLConstants.enum_data_operation.batch_edit)
            {
                initInsuranceComboBox();
                errors = new bool[properties_count];
                error_count = 0;
                this.Text = "ویرایش دسته ای اطلاعات چند بیمه شده";
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
                insurance_combobox.SelectedValue = insurance_row.id;

            }
            if (form_operation != PLConstants.enum_data_operation.new_data)
            {
                switch (insurance_enum)
                {
                    case PLConstants.enum_insurances.Salamat:
                        id_textbox.MaxLength = PLConstants.len_Salamat_code;
                        regex[ind_id] = PLConstants.reg_pre_id_Salamat;
                        break;
                    case PLConstants.enum_insurances.TaminEjtemaei:
                        id_textbox.MaxLength = PLConstants.len_national_code;
                        regex[ind_id] = PLConstants.reg_pre_id_NationalCode;
                        break;
                    case PLConstants.enum_insurances.NirooMosalah:
                        id_textbox.MaxLength = PLConstants.len_NirooMosalah_code;
                        regex[ind_id] = PLConstants.reg_pre_id_NirooMosalah;
                        break;
                    case PLConstants.enum_insurances.KomitehEmdad:
                        id_textbox.MaxLength = PLConstants.len_KomitehEmdad_code;
                        regex[ind_id] = PLConstants.reg_pre_id_KomitehEmdad;
                        break;
                    case PLConstants.enum_insurances.Other:
                        id_textbox.MaxLength = PLConstants.len_max_id_20;
                        regex[ind_id] = PLConstants.reg_pre_id_Other;
                        break;
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)//checked
        {
            int tc = 0;
            int cc = 0;
            int mc = 0;

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
                            tc++;
                        }
                        else if ((control_types[i] == masked_type) && (new_data[i] != null))
                        {
                            message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                            mc++;
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
                        switch (ins_enum)
                        {
                            case PLConstants.enum_insurances.Salamat:
                                i_adapter.AddToSalamat(selected_ins.id,(short?)PLConstants.enum_activity_types.AddInsured,PLConstants.UserCode,(string)new_data[ind_id], (int?)new_data[ind_sector], (string)new_data[ind_name], (string)new_data[ind_family],
                                                       (string)new_data[ind_natioanl_code], PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]),
                                                       PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]), ref add_result);
                                break;
                            case PLConstants.enum_insurances.TaminEjtemaei:
                                i_adapter.AddToTaminEjtemaei(selected_ins.id, (short?)PLConstants.enum_activity_types.AddInsured, PLConstants.UserCode, (string)new_data[ind_id], (int?)new_data[ind_sector], (string)new_data[ind_name], (string)new_data[ind_family],
                                                       (string)new_data[ind_natioanl_code], PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]),
                                                       PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]), ref add_result);
                                break;
                            case PLConstants.enum_insurances.NirooMosalah:
                                i_adapter.AddToNirooMosalah(selected_ins.id, (short?)PLConstants.enum_activity_types.AddInsured, PLConstants.UserCode, (string)new_data[ind_id], (int?)new_data[ind_sector], (string)new_data[ind_name], (string)new_data[ind_family],
                                                       (string)new_data[ind_natioanl_code], PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]),
                                                       PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]), ref add_result);
                                break;
                            case PLConstants.enum_insurances.KomitehEmdad:
                                i_adapter.AddToKomitehEmdad(selected_ins.id, (short?)PLConstants.enum_activity_types.AddInsured, PLConstants.UserCode, (string)new_data[ind_id], (int?)new_data[ind_sector], (string)new_data[ind_name], (string)new_data[ind_family],
                                                       (string)new_data[ind_natioanl_code], PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]),
                                                       PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]), ref add_result);
                                break;
                            case PLConstants.enum_insurances.Other:
                                i_adapter.AddToOther(selected_ins.id, (short?)PLConstants.enum_activity_types.AddInsured, PLConstants.UserCode, (string)new_data[ind_id], (int?)new_data[ind_sector], (string)new_data[ind_name], (string)new_data[ind_family],
                                                       (string)new_data[ind_natioanl_code], PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]),
                                                       PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]), ref add_result);
                                break;
                        }
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
                        else if (control_types[i] == masked_type)
                        {
                            message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                            mc++;
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
                    else if (control_types[i] == masked_type)
                    {
                        mc++;
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
                        switch (ins_enum)
                        {
                            case PLConstants.enum_insurances.Salamat:
                                i_adapter.UpdateSalamat(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, false, (long)new_data[ind_sequence], PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[ind_id], (int)new_data[ind_sector],
                                                        (string)new_data[ind_name],(string)new_data[ind_family],(string)new_data[ind_natioanl_code],(string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]),PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.TaminEjtemaei:
                                i_adapter.UpdateTaminEjtemaei(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, false, (long)new_data[ind_sequence], PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[ind_id], (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], (string)new_data[ind_natioanl_code], (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.NirooMosalah:
                                i_adapter.UpdateNirooMosalah(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, false, (long)new_data[ind_sequence], PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[ind_id], (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], (string)new_data[ind_natioanl_code], (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.KomitehEmdad:
                                i_adapter.UpdateKomitehEmdad(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, false, (long)new_data[ind_sequence], PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[ind_id], (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], (string)new_data[ind_natioanl_code], (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.Other:
                                i_adapter.UpdateOther(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, false, (long)new_data[ind_sequence], PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[ind_id], (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], (string)new_data[ind_natioanl_code], (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                        }
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
                message_text.Add("ویرایش دسته ای اطلاعات " + selected_insureds.Rows.Count + " مورد");
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
                        else if (control_types[i] == masked_type)
                        {
                            if (new_data[i] != null)
                            {
                                message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                            }
                            mc++;
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
                    else if (control_types[i] == masked_type)
                    {
                        mc++;
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
                        switch (ins_enum)
                        {
                            case PLConstants.enum_insurances.Salamat:
                                i_adapter.UpdateSalamat(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode,true, null, selected_insureds, null, (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], null, (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.TaminEjtemaei:
                                i_adapter.UpdateTaminEjtemaei(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, true, null, selected_insureds, null, (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], null, (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.NirooMosalah:
                                i_adapter.UpdateNirooMosalah(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, true, null, selected_insureds, null, (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], null, (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.KomitehEmdad:
                                i_adapter.UpdateKomitehEmdad(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, true, null, selected_insureds, null, (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], null, (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                            case PLConstants.enum_insurances.Other:
                                i_adapter.UpdateOther(selected_ins.id, (short?)PLConstants.enum_activity_types.EditInsured, PLConstants.UserCode, true, null, selected_insureds, null, (int)new_data[ind_sector],
                                                        (string)new_data[ind_name], (string)new_data[ind_family], null, (string)new_data[ind_exp],
                                                        PLGlobalFuncs.getDAYofDate((string)new_data[ind_exp]), PLGlobalFuncs.getMONTHofDate((string)new_data[ind_exp]), PLGlobalFuncs.getYEARofDate((string)new_data[ind_exp]),
                                                        ref edit_result);
                                break;
                        }
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

        private void exp_masked_control_Leave(object sender, EventArgs e)//checked
        {
            MaskedTextBox t_msk = (MaskedTextBox)sender;
            int t_ind = int.Parse(t_msk.Tag.ToString());
            string t_text = t_msk.Text;

            if (t_text.Equals(PLConstants.str_empty_slash_date))
            {
                if (allow_null[t_ind])
                {
                    new_data[t_ind] = null;
                    if (errors[t_ind])
                    {
                        error_providers[t_ind].Clear();
                        error_count--;
                        errors[t_ind] = false;
                        t_msk.BackColor = Color.White;
                    }
                }
                else if (!errors[t_ind])
                {
                    error_count++;
                    errors[t_ind] = true;
                    t_msk.BackColor = Color.Red;
                    error_providers[t_ind].SetError(t_msk, error_text[t_ind]);
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
                    t_msk.BackColor = Color.White;
                }
            }
            else if (!errors[t_ind])
            {
                error_count++;
                errors[t_ind] = true;
                t_msk.BackColor = Color.Red;
                error_providers[t_ind].SetError(t_msk, error_text[t_ind]);
            }

        }

        private void insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(insurance_combobox.Tag.ToString());
            if (insurance_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = insurance_combobox.SelectedValue;
                selected_ins = (PIPDataSet.TInsuranceRow)ins_data.Rows[insurance_combobox.SelectedIndex];
                initInsSectorComboBox((int)new_data[c_ind]);
                if (errors[ind_insurance])
                {
                    errors[ind_insurance] = false;
                    error_count--;
                    EP_insurance.Clear();
                }
                if (form_operation == PLConstants.enum_data_operation.new_data)
                {
                    switch (ins_enum=PLEnumFuncs.convertInsuranceTagToEnum(((PIPDataSet.TInsuranceRow)(ins_data.Select(ins_data.idColumn.ColumnName+"="+insurance_combobox.SelectedValue.ToString()))[0]).tag))
                    {
                        case PLConstants.enum_insurances.Salamat:
                            id_textbox.MaxLength = PLConstants.len_Salamat_code;
                            regex[ind_id] = PLConstants.reg_pre_id_Salamat;
                            break;
                        case PLConstants.enum_insurances.TaminEjtemaei:
                            id_textbox.MaxLength = PLConstants.len_national_code;
                            regex[ind_id] = PLConstants.reg_pre_id_NationalCode;
                            break;
                        case PLConstants.enum_insurances.NirooMosalah:
                            id_textbox.MaxLength = PLConstants.len_NirooMosalah_code;
                            regex[ind_id] = PLConstants.reg_pre_id_NirooMosalah;
                            break;
                        case PLConstants.enum_insurances.KomitehEmdad:
                            id_textbox.MaxLength = PLConstants.len_KomitehEmdad_code;
                            regex[ind_id] = PLConstants.reg_pre_id_KomitehEmdad;
                            break;
                        case PLConstants.enum_insurances.Other:
                            id_textbox.MaxLength = PLConstants.len_max_id_20;
                            regex[ind_id] = PLConstants.reg_pre_id_Other;
                            break;
                    }
                    setAccessibilityOfControls(true);
                }
            }
            else
            {
                if (!errors[ind_insurance])
                {
                    new_data[ind_insurance] = null;
                    sector_combobox.DataSource = null;
                    errors[ind_insurance] = true;
                    error_count++;
                    EP_insurance.SetError(insurance_combobox, error_text[ind_insurance]);
                }
                if (form_operation == PLConstants.enum_data_operation.new_data)
                {
                    setAccessibilityOfControls(false);
                }
            }
        }

        private void setAccessibilityOfControls(bool acc)
        {
            id_textbox.Enabled = sector_combobox.Enabled = name_textbox.Enabled = family_name_textbox.Enabled =
                national_code_textbox.Enabled = exp_masked.Enabled = save_button.Enabled = acc;
        }

        private void combobox_control_SelectedIndexChanged(object sender, EventArgs e)//checked
        {
            ComboBox c_box = (ComboBox)sender;
            int c_ind = int.Parse(c_box.Tag.ToString());

            if (c_box.SelectedIndex > 0)
            {
                new_data[c_ind] = c_box.SelectedValue;
                new_sector_id = (int)new_data[c_ind];
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
                if ((data_types[ch_ind] == int_type) || (data_types[ch_ind] == long_type))
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

        private void exp_checkbox_CheckedChanged(object sender, EventArgs e)//checked
        {
            CheckBox ch_box = (CheckBox)sender;
            int ch_ind = int.Parse(ch_box.Tag.ToString());
            if (ch_box.Checked)
            {
                if (errors[ch_ind])
                {
                    error_providers[ch_ind].Clear();
                    error_count--;
                    errors[ch_ind] = false;
                    data_controls[ch_ind].BackColor = Color.White;
                }
                data_controls[ch_ind].Enabled = false;
                new_data[ch_ind] = PLConstants.str_clear;
            }
            else
            {
                data_controls[ch_ind].Enabled = true;
            }
        }

        private void initInsuranceComboBox()//checked
        {
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
        }
        private void initInsSectorComboBox(int selected_insurance)//checked
        {
            sec_table = sec_adapter.GetAllSectors(selected_insurance);
            PIPDataSet.TInsuranceSectorRow s_first_row = sec_table.NewTInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "--صندوق بیمه--";
            sec_table.Rows.InsertAt(s_first_row, 0);
            sector_combobox.DataSource = sec_table;
            sector_combobox.DisplayMember = sec_table.nameColumn.ColumnName;
            sector_combobox.ValueMember = sec_table.idColumn.ColumnName;
            sector_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(sector_combobox);
        }

    }
}
