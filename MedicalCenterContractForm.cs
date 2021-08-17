using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;


namespace PadraInsurancePrescription
{
    public partial class MedicalCenterContractForm : Form
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

        PIPDataSet.SMedicalCenterRow selected_center;
        DataTable selected_contracts;
        DataTable selected_sectors;
        PIPDataSet.TMedicalCenterContractRow single_contract;
        List<string> ins_message;

        Control[] data_controls;
        Label[] lable_controls;
        Type[] control_types;
        TextBox[] text_controls;
        ComboBox[] combo_controls;
        CheckBox[] clear_checkboxes;
        ErrorProvider[] error_providers;

        PGSDialog pgs_dialog;
        public PLConstants.enum_operation_results result_enum;
        PLConstants.enum_data_operation form_operation;

        Type int_type;
        Type string_type;
        Type bool_type;

        Type textbox_type;
        Type combobox_type;
        Type label_type;

        PIPDataSetTableAdapters.TMedicalCenterContractTableAdapter c_adapter;

        public MedicalCenterContractForm(PIPDataSet.SMedicalCenterRow selected_center, PLConstants.enum_data_operation operation, DataTable selected_contracts, DataTable selected_sectors,List<string> insurances_message, PIPDataSet.TMedicalCenterContractRow data_row)//checked
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.sub_data);

            properties_count = 2;
            new_data = new object[properties_count];

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);

            data_types = new Type[] { string_type,string_type};
            allow_validating = new bool[] { false,true};
            allow_batch_validating = new bool[] { false,true};
            allow_null = new bool[] { false,false};
            regex = new string[] { null,PLConstants.reg_id};
            error_text = new string[] { null,PLConstants.error_id_just_number};

            this.selected_center = selected_center;
            this.selected_sectors = selected_sectors;
            this.selected_contracts = selected_contracts;
            this.single_contract = data_row;
            this.ins_message = insurances_message;

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);

            data_controls = new Control[] { center_textbox,specific_id_textbox};
            lable_controls = new Label[] { center_label, id_lable };
            control_types = new Type[] { textbox_type,textbox_type};
            text_controls = new TextBox[] { center_textbox, specific_id_textbox};
            combo_controls = new ComboBox[] { };
            clear_checkboxes = new CheckBox[] { center_checkbox, specific_id_checkbox };
            error_providers = new ErrorProvider[] { null,EP_specific_id};

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            c_adapter = new PIPDataSetTableAdapters.TMedicalCenterContractTableAdapter();

            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد قرارداد جدید با بیمه های درمانی";
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
                errors = new bool[] { false,true};
                error_count = 1;
                ///////////////////////////////////////// initialize new 
                new_data[0] = selected_center.name;
                center_textbox.Text = selected_center.name;

            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                errors = new bool[properties_count];
                error_count = 0;
                current_data = new object[]{selected_center.name,data_row.specific_contract_id};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                this.Text = "ویرایش اطلاعات قرارداد با بیمه های درمانی";
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
                    }
                    else if (control_types[i] == combobox_type)
                    {
                        cc++;
                    }
                    else
                    {
                        tc++;
                    }
                }
            }
            else if (operation == PLConstants.enum_data_operation.batch_edit)
            {
                errors = new bool[properties_count];
                error_count = 0;
                this.Text = "ویرایش دسته ای اطلاعات چند قرارداد با بیمه های درمانی";
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
            specific_id_textbox.Select();
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
                message_text.Add(PLConstants.question_new_contract_for_center);
                message_text.Add(center_label.Text + selected_center.name);
                message_text.Add("بیمه ها و صندوق های انتخاب شده:");
                message_text.AddRange(ins_message);
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
                        c_adapter.AddContracts(selected_center.id, selected_sectors, (string)new_data[1], ref add_result);
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
                message_text.Add(center_label.Text + selected_center.name);
                message_text.Add("قرارداد انتخاب شده:");
                message_text.Add(single_contract.insurance_name + " - " + single_contract.sector_name);
                message_text.Add("اطلاعات کنونی");
                message_text.Add(id_lable.Text + single_contract.specific_contract_id);
                //for (int i = 0; i < properties_count; i++)
                //{
                //    if (current_data[i] != null)
                //    {
                //        message_text.Add(lable_controls[i].Text + current_data[i].ToString());
                //    }
                //}
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
                        c_adapter.EditContracts(false, single_contract.sequence, PLGlobalFuncs.emptyIntIDsDataTable(), (string)new_data[1], ref edit_result);
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
                message_text.Add(center_label.Text + selected_center.name);
                message_text.Add("ویرایش دسته ای اطلاعات " + selected_contracts.Rows.Count + " مورد");
                message_text.Add("قراردادهای انتخاب شده:");
                message_text.AddRange(ins_message);
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
                        c_adapter.EditContracts(true, null, selected_contracts, (string)new_data[1], ref edit_result);
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

        private void clear_checkboxes_CheckedChanged(object sender, EventArgs e)//checked
        {

        }

    }
}
