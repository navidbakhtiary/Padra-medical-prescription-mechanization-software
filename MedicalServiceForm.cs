using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class MedicalServiceForm : Form
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

        string choose_sub_category_message;
        string choose_ins_sector_message;

        DataTable selected_services;

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
        Type long_type;
        Type double_type;

        Type textbox_type;
        Type combobox_type;
        Type label_type;
        Type masked_type;

        PIPDataSetTableAdapters.TMedicalServiceTableAdapter service_adapter;
        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sec_adapter;
        PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter cat_adapter;
        PIPDataSetTableAdapters.TMedicalServiceSubCategoryTableAdapter sub_adapter;

        PIPDataSet.TInsuranceDataTable ins_table;
        PIPDataSet.TInsuranceSectorDataTable sec_table;
        PIPDataSet.TMedicalServiceCategoryDataTable cat_table;
        PIPDataSet.TMedicalServiceSubCategoryDataTable sub_table;

        public MedicalServiceForm(PIPDataSet.TMedicalServiceRow data_row, PLConstants.enum_data_operation operation, DataTable selected_services)//checked
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            properties_count = 13;
            new_data = new object[properties_count];

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);
            long_type = typeof(long);
            double_type = typeof(double);
            errors = new bool[properties_count];
            error_count = 0;
            data_types = new Type[] { null, string_type, string_type,
                                      int_type,int_type, int_type, int_type,
                                      double_type, double_type, double_type,
                                      string_type,int_type, string_type};
            allow_validating = new bool[] { false, true, true,
                                            true, true, true, true,
                                            true, true, true,
                                            true, true, true};
            allow_batch_validating = new bool[] { false, true, true,
                                                  true,true,true,true,
                                                  true, true, true,
                                                  true, true, true};
            allow_null = new bool[] { false, false, false,
                                      true,true,false,true,
                                      true,true,true,
                                      false,true,true};
            regex = new string[] { null, PLConstants.reg_medical_service_code, PLConstants.reg_m_service_name,
                                   PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,
                                   PLConstants.reg_float_code,PLConstants.reg_float_code,PLConstants.reg_float_code,
                                   PLConstants.reg_date_slash,PLConstants.reg_number,PLConstants.reg_description };
            error_text = new string[] { null, PLConstants.error_id_just_number, PLConstants.error_medical_service_name,
                                        null,null,PLConstants.error_combo_not_selected,null,
                                        PLConstants.error_numbers_float,PLConstants.error_numbers_float,PLConstants.error_numbers_float,
                                        PLConstants.error_date,PLConstants.error_numbers_int,PLConstants.error_description};

            this.selected_services = selected_services;

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);
            masked_type = typeof(MaskedTextBox);

            data_controls = new Control[] { id_textbox,national_id_textbox,name_textbox,
                                            insurance_combobox,sector_combobox,category_combobox,sub_combobox,
                                            factor_textbox,professional_k_textbox,technical_k_textbox,
                                            date_masked,shortcut_textbox,description_textbox};
            lable_controls = new Label[] { id_lable, national_id_lable, name_label,
                                           insurance_label,sector_lable,category_label,sub_label,
                                           factor_label,professional_k_label,technical_k_label,
                                           date_label,shortcut_label,description_label};
            control_types = new Type[] { textbox_type, textbox_type, textbox_type,
                                         combobox_type,combobox_type,combobox_type,combobox_type,
                                         textbox_type,textbox_type,textbox_type,
                                         masked_type,textbox_type,textbox_type};
            text_controls = new TextBox[] { id_textbox,national_id_textbox,name_textbox,
                                            factor_textbox,professional_k_textbox,technical_k_textbox,
                                            shortcut_textbox,description_textbox};
            combo_controls = new ComboBox[] { insurance_combobox,sector_combobox,category_combobox,sub_combobox};
            masked_controls = new MaskedTextBox[] { date_masked };
            clear_checkboxes = new CheckBox[]{id_checkbox,national_id_checkbox,name_checkbox,
                                              insurance_checkbox,sector_checkbox,category_checkbox,sub_checkbox,
                                              factor_checkbox,professional_k_checkbox,technical_k_checkbox,
                                              date_checkbox,shortcut_checkbox,description_checkbox};
            error_providers = new ErrorProvider[] { null, EP_national_id, EP_name,
                                                    null,EP_sector,EP_category,EP_sub_category,
                                                    EP_factor,EP_professional,EP_technical,
                                                    EP_date,EP_shortcut,EP_description};

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;

            service_adapter = new PIPDataSetTableAdapters.TMedicalServiceTableAdapter();

            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sec_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            cat_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            sub_adapter = new PIPDataSetTableAdapters.TMedicalServiceSubCategoryTableAdapter();

            choose_ins_sector_message = "چون شرکت بیمه انتخاب شده است، باید صندوق بیمه پاک شود یا یک گزینه انتخاب گردد!";
            choose_sub_category_message = "چون نوع خدمت انتخاب شده است، باید نوع فرعی خدمت پاک شود یا یک گزینه انتخاب گردد!";

            initComboBoxes();
            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد خدمت پزشکی جدید";
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
                errors = new bool[] { false, true, true,
                                      false,false,true,false,
                                      false,false,false,
                                      true,false,false};
                error_count = 4;
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                current_data = new object[]{data_row.sequence,data_row.national_id,data_row.name,
                                            data_row.insurance,data_row.insurance_sector,data_row.category,data_row.sub_category,
                                            data_row.k_factor,data_row.professional_k,data_row.technical_k,
                                            data_row.start_date,data_row.shortcut_code,data_row.description};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ویرایش اطلاعات خدمت پزشکی";
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
                            if (data_types[i] == int_type && new_data[i] != null)
                            {
                                if ((int)new_data[i] == -1)
                                {
                                    new_data[i] = null;
                                }
                            }
                            cc++;
                        }
                        else if (control_types[i] == textbox_type)
                        {
                            if (data_types[i] == int_type && ((int)current_data[i]) == -1)
                            {
                                text_controls[tc].Text = "";
                                current_data[i] = new_data[i] = null;
                            }
                            else
                            {
                                text_controls[tc].Text = current_data[i].ToString();
                            }
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
                this.Text = "ویرایش دسته ای اطلاعات چند خدمت پزشکی";
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
            else if (operation == PLConstants.enum_data_operation.copy_data)
            {
                errors[8] = true;
                error_count = 1;
                EP_date.SetError(date_masked, error_text[8]);
                current_data = new object[]{null,data_row.national_id,data_row.name,
                                            data_row.insurance,data_row.insurance_sector,data_row.category,data_row.sub_category,
                                            data_row.k_factor,data_row.professional_k,data_row.technical_k,
                                            null,data_row.shortcut_code,data_row.description};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ایجاد خدمت پزشکی جدید بر اساس اطلاعات موجود";
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
                            if (data_types[i] == int_type && ((int?)new_data[i]) == -1)
                            {
                                new_data[i] = null;
                            }
                            cc++;
                        }
                        else if (control_types[i] == textbox_type)
                        {
                            if (data_types[i] == int_type && ((int)current_data[i]) == -1)
                            {
                                text_controls[tc].Text = "";
                                current_data[i] = new_data[i] = null;
                            }
                            else
                            {
                                text_controls[tc].Text = current_data[i].ToString();
                            }
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
            else if (operation == PLConstants.enum_data_operation.batch_copy)
            {
                errors = new bool[properties_count];
                errors[8] = true;
                error_count = 1;
                EP_date.SetError(date_masked, error_text[8]);
                this.Text = "ایجاد چند خدمت پزشکی جدید بر اساس اطلاعات موجود";
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
            int mc = 0;

            if (error_count > 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_has_error);
            }
            else if ((form_operation == PLConstants.enum_data_operation.new_data) || (form_operation == PLConstants.enum_data_operation.copy_data))
            {
                if (checkKFactors())
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
                            else if (control_types[i] == combobox_type)
                            {
                                if (new_data[i] != null)
                                {
                                    message_text.Add(lable_controls[i].Text + combo_controls[cc].Text);
                                }
                                cc++;
                            }
                            else if (control_types[i] == masked_type)
                            {
                                if (new_data[i] != null)
                                {
                                    message_text.Add(lable_controls[i].Text + masked_controls[mc].Text);
                                }
                                mc++;
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
                        else if (control_types[i] == masked_type)
                        {
                            mc++;
                        }
                    }
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);
                    switch (pgs_dialog.user_choice)
                    {
                        case PLConstants.enum_dialog_options.yes:
                            string add_result = "";
                            service_adapter.AddMedicalServices(false, PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[1], (string)new_data[2],
                                                (int?)new_data[3], (int?)new_data[4], (int)new_data[5], (int?)new_data[6],
                                                (double?)new_data[7], (double?)new_data[8], (double?)new_data[9],
                                                (string)new_data[10], (int?)new_data[11], (string)new_data[12], ref add_result);
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
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_k_factors_not_matched);
                }
            }
            else if (form_operation == PLConstants.enum_data_operation.edit_data)
            {
                if (checkKFactors())
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
                            else if ((control_types[i] == masked_type) && (new_data[i] != null))
                            {
                                message_text.Add(lable_controls[i].Text + masked_controls[mc].Text);
                                mc++;
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
                        else
                        {
                            mc++;
                        }
                    }
                    pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                    switch (pgs_dialog.user_choice)
                    {
                        case PLConstants.enum_dialog_options.yes:
                            string edit_result = "";
                            service_adapter.EditMedicalServices(false, (long)new_data[0], PLGlobalFuncs.emptyLongIDsDataTable(), (string)new_data[1],
                                                  (string)new_data[2], (int?)new_data[3], (int?)new_data[4],
                                                  (int)new_data[5], (int?)new_data[6],
                                                  (double?)new_data[7], (double?)new_data[8], (double?)new_data[9],
                                                  (string)new_data[10], (int?)new_data[11], (string)new_data[12], ref edit_result);
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
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_k_factors_not_matched);
                }
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_edit)
            {
                List<string> message_text = new List<string>();
                message_text.Add(PLConstants.question_save_edit);
                message_text.Add("ویرایش دسته ای اطلاعات " + selected_services.Rows.Count + " مورد");
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
                        else if (control_types[i] == masked_type)
                        {
                            if (new_data[i] != null)
                            {
                                message_text.Add(lable_controls[i].Text + masked_controls[mc].Text);
                            }
                            mc++;
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
                    else if (control_types[i] == masked_type)
                    {
                        mc++;
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        service_adapter.EditMedicalServices(true, null, selected_services, (string)new_data[1],
                                              (string)new_data[2], (int?)new_data[3], (int?)new_data[4],
                                              (int?)new_data[5], (int?)new_data[6],
                                              (double?)new_data[7], (double?)new_data[8], (double?)new_data[9],
                                              (string)new_data[10], (int?)new_data[11], (string)new_data[12], ref edit_result);
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
            else if (form_operation == PLConstants.enum_data_operation.batch_copy)
            {
                List<string> message_text = new List<string>();
                message_text.Add(PLConstants.question_save_new);
                message_text.Add("نسخه برداری دسته ای اطلاعات " + selected_services.Rows.Count + " مورد");
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
                        else if (control_types[i] == masked_type)
                        {
                            if (new_data[i] != null)
                            {
                                message_text.Add(lable_controls[i].Text + masked_controls[mc].Text);
                            }
                            mc++;
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
                    else if (control_types[i] == masked_type)
                    {
                        mc++;
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string add_result = "";
                        service_adapter.AddMedicalServices(true, selected_services, (string)new_data[1],
                                              (string)new_data[2], (int?)new_data[3], (int?)new_data[4],
                                              (int?)new_data[5], (int?)new_data[6],
                                              (double?)new_data[7], (double?)new_data[8], (double?)new_data[9],
                                              (string)new_data[10], (int?)new_data[11], (string)new_data[12], ref add_result);
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
                if (allow_null[t_ind] || (form_operation == PLConstants.enum_data_operation.batch_edit) || (form_operation == PLConstants.enum_data_operation.batch_copy))
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
                if (data_types[t_ind] == int_type)
                {
                    new_data[t_ind] = int.Parse(t_text);
                }
                else
                {
                    new_data[t_ind] = t_text;
                }
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

        private void k_factors_textbox_Leave(object sender, EventArgs e)
        {
            TextBox t_box = (TextBox)sender;
            int t_ind = int.Parse(t_box.Tag.ToString());
            string t_text = t_box.Text.Trim();
            double temp_dou;
            if (t_text == "")
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
            else if (double.TryParse(t_text, out temp_dou))
            {
                new_data[t_ind] = temp_dou;
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

        private void date_masked_Leave(object sender, EventArgs e)
        {
            int t_ind = int.Parse(date_masked.Tag.ToString());
            string t_text = date_masked.Text;
            bool m_error = false;
            
            if (Regex.IsMatch(t_text, regex[t_ind]))
            {
                new_data[t_ind] = t_text;
                m_error = false;
            }
            else if ((t_text==PLConstants.str_empty_slash_date) && (form_operation == PLConstants.enum_data_operation.batch_edit))
            {
                new_data[t_ind] = null;
                m_error = false;
            }
            else
            {
                m_error = true;
            }

            if (m_error)
            {
                if (!errors[t_ind])
                {
                    error_count++;
                    errors[t_ind] = true;
                    date_masked.BackColor = Color.Red;
                    error_providers[t_ind].SetError(date_masked, error_text[t_ind]);
                }
            }
            else
            {
                if (errors[t_ind])
                {
                    error_providers[t_ind].Clear();
                    error_count--;
                    errors[t_ind] = false;
                    date_masked.BackColor = Color.White;
                }
            }
        }

        private void insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(insurance_combobox.Tag.ToString());
            if (insurance_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = insurance_combobox.SelectedValue;
                initInsSectorComboBox((int)insurance_combobox.SelectedValue);
                //initSubCategoryComboBox((int)category_combobox.SelectedValue, (int)insurance_combobox.SelectedValue, (int)sector_combobox.SelectedValue);
                if ((form_operation == PLConstants.enum_data_operation.batch_edit || form_operation == PLConstants.enum_data_operation.batch_copy) && (!errors[4]) && (!sector_checkbox.Checked))
                {
                    errors[4] = true;
                    error_count++;
                    EP_sector.SetError(sector_combobox, choose_ins_sector_message);
                }
            }
            else
            {
                new_data[c_ind] = null;
                sector_combobox.DataSource = null;
                //initSubCategoryComboBox((int)category_combobox.SelectedValue, (int)insurance_combobox.SelectedValue, (int)sector_combobox.SelectedValue);
                if ((form_operation == PLConstants.enum_data_operation.batch_edit || form_operation == PLConstants.enum_data_operation.batch_copy) && errors[4])
                {
                    errors[4] = false;
                    error_count--;
                    EP_sector.Clear();
                }
            }
        }

        private void category_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(category_combobox.Tag.ToString());
            if (category_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = category_combobox.SelectedValue;
                if (errors[c_ind] || false)
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    category_combobox.BackColor = Color.White;
                }
                if ((form_operation == PLConstants.enum_data_operation.batch_edit || form_operation == PLConstants.enum_data_operation.batch_copy) && (!errors[6]) && (!sub_checkbox.Checked))
                {
                    errors[6] = true;
                    error_count++;
                    EP_sub_category.SetError(sub_combobox, choose_sub_category_message);
                }
                initSubCategoryComboBox((int)category_combobox.SelectedValue);
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_edit || form_operation == PLConstants.enum_data_operation.batch_copy)
            {
                new_data[c_ind] = null;
                if (errors[c_ind])
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    category_combobox.BackColor = Color.White;
                }
                sub_combobox.DataSource = null;
                if (errors[6])
                {
                    errors[6] = false;
                    error_count--;
                    EP_sub_category.Clear();
                }
            }
            else if (!errors[c_ind])
            {
                new_data[c_ind] = null;
                error_providers[c_ind].SetError(category_combobox, error_text[c_ind]);
                error_count++;
                errors[c_ind] = true;
                category_combobox.BackColor = Color.Red;
                sub_combobox.DataSource = null;
            }
        }

        private void sector_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(sector_combobox.Tag.ToString());
            if (sector_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = sector_combobox.SelectedValue;
                //initSubCategoryComboBox((int)category_combobox.SelectedValue, (int)insurance_combobox.SelectedValue, (int)sector_combobox.SelectedValue);
                if (errors[4])
                {
                    errors[4] = false;
                    error_count--;
                    EP_sector.Clear();
                }
            }
            else
            {
                new_data[c_ind] = null;
                //initSubCategoryComboBox((int)category_combobox.SelectedValue, (int)insurance_combobox.SelectedValue, (int)sector_combobox.SelectedValue);
                if ((form_operation == PLConstants.enum_data_operation.batch_edit || form_operation == PLConstants.enum_data_operation.batch_copy) && (insurance_combobox.SelectedIndex > 0) && (!errors[4]))
                {
                    errors[4] = true;
                    error_count++;
                    EP_sector.SetError(sector_combobox, choose_ins_sector_message);
                }
            }
        }

        private void sub_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c_ind = int.Parse(sub_combobox.Tag.ToString());
            if (sub_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = sub_combobox.SelectedValue;
                if (errors[6])
                {
                    errors[6] = false;
                    error_count--;
                    EP_sub_category.Clear();
                }
            }
            else
            {
                new_data[c_ind] = null;
                if ((form_operation == PLConstants.enum_data_operation.batch_edit || form_operation == PLConstants.enum_data_operation.batch_copy) && (category_combobox.SelectedIndex > 0) && (!errors[6]))
                {
                    errors[6] = true;
                    error_count++;
                    EP_sub_category.SetError(sub_combobox, choose_sub_category_message);
                }
            }
        }
        
        private void clear_checkboxes_CheckedChanged(object sender, EventArgs e)//checked
        {
            CheckBox ch_box = (CheckBox)sender;
            int ch_ind = int.Parse(ch_box.Tag.ToString());
            if (ch_box.Checked)
            {
                if ((control_types[ch_ind] == textbox_type)||(control_types[ch_ind] == masked_type))
                {
                    //new_data[ch_ind] = null;
                    data_controls[ch_ind].Text = "";
                }
                else if (control_types[ch_ind] == combobox_type)
                {
                    //new_data[ch_ind] = null;
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
                if ((data_types[ch_ind] == int_type) || (data_types[ch_ind] == double_type))
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

        private void sector_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (sector_checkbox.Checked)
            {
                sector_combobox.SelectedIndex = 0;
                if (errors[4])
                {
                    EP_sector.Clear();
                    error_count--;
                    errors[4] = false;
                    sector_combobox.BackColor = Color.White;
                }
                sector_combobox.Enabled = false;
                new_data[4] = PLConstants.int_minus_11;
                //initSubCategoryComboBox((int)category_combobox.SelectedValue, (int)insurance_combobox.SelectedValue, (int)sector_combobox.SelectedValue);
            }
            else if (insurance_combobox.SelectedIndex > 0)
            {
                new_data[4] = null;
                errors[4] = true;
                error_count++;
                EP_sector.SetError(sector_combobox, choose_ins_sector_message);
            }
        }

        private void sub_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (sub_checkbox.Checked)
            {
                sub_combobox.SelectedIndex = 0;
                if (errors[6])
                {
                    EP_sub_category.Clear();
                    error_count--;
                    errors[6] = false;
                    sub_combobox.BackColor = Color.White;
                }
                sub_combobox.Enabled = false;
                new_data[6] = PLConstants.int_minus_11;
            }
            else if (category_combobox.SelectedIndex > 0)
            {
                new_data[6] = null;
                errors[6] = true;
                error_count++;
                EP_sub_category.SetError(sub_combobox, choose_sub_category_message);
            }
        }

        private void initComboBoxes()//checked
        {
            ins_table = ins_adapter.GetAllInsurances();
            PIPDataSet.TInsuranceRow i_first_row = ins_table.NewTInsuranceRow();
            i_first_row.id = -1;
            i_first_row.name = "---شرکت بیمه---";
            ins_table.Rows.InsertAt(i_first_row, 0);
            insurance_combobox.DataSource = ins_table;
            insurance_combobox.DisplayMember = ins_table.nameColumn.ColumnName;
            insurance_combobox.ValueMember = ins_table.idColumn.ColumnName;
            insurance_combobox.SelectedIndex = 0;

            cat_table = cat_adapter.GetAllCategories();
            PIPDataSet.TMedicalServiceCategoryRow c_first_row = cat_table.NewTMedicalServiceCategoryRow();
            c_first_row.id = -1;
            c_first_row.name = "--نوع اصلی خدمت پزشکی--";
            cat_table.Rows.InsertAt(c_first_row, 0);
            category_combobox.DataSource = cat_table;
            category_combobox.DisplayMember = cat_table.nameColumn.ColumnName;
            category_combobox.ValueMember = cat_table.idColumn.ColumnName;
            category_combobox.SelectedIndex = 0;

            PLGlobalFuncs.adjustDropDownWidthOfComboBox(insurance_combobox);
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(category_combobox);
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

        private void initSubCategoryComboBox(int selected_category)//checked
        {
            sub_table = sub_adapter.GetSubCategories(selected_category);
            PIPDataSet.TMedicalServiceSubCategoryRow s_first_row = sub_table.NewTMedicalServiceSubCategoryRow();
            s_first_row.id = -1;
            s_first_row.name = "--نوع فرعی خدمت--";
            sub_table.Rows.InsertAt(s_first_row, 0);
            sub_combobox.DataSource = sub_table;
            sub_combobox.DisplayMember = sub_table.nameColumn.ColumnName;
            sub_combobox.ValueMember = sub_table.idColumn.ColumnName;
            sub_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(sub_combobox);
        }

        private bool checkKFactors()
        {
            string s_k,s_pk,s_tk;
            decimal k,pk,tk;
            s_k = factor_textbox.Text.Trim()=="" ? "0":factor_textbox.Text.Trim();
            s_pk = professional_k_textbox.Text.Trim()==""?"0":professional_k_textbox.Text.Trim();
            s_tk = technical_k_textbox.Text.Trim()==""?"0":technical_k_textbox.Text.Trim();
            k = decimal.Parse(s_k);
            pk = decimal.Parse(s_pk);
            tk = decimal.Parse(s_tk);
            decimal temp = pk + tk;
            if (k == pk + tk) { return true; }
            return false;
        }

    }
}
