using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class ClinicPartForm : Form
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

        DataTable selected_parts;

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
        Type float_type;

        Type textbox_type;
        Type combobox_type;
        Type label_type;
        Type masked_type;

        PIPDataSetTableAdapters.SClinicPartTableAdapter clinic_part_adapter;
        PIPDataSetTableAdapters.TClinicTypeTableAdapter type_adapter;
        
        PIPDataSet.TClinicTypeDataTable type_table;
        
        public ClinicPartForm(PIPDataSet.SClinicPartRow data_row, PLConstants.enum_data_operation operation, DataTable selected_parts)//checked
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            properties_count = 5;
            new_data = new object[properties_count];

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);
            long_type = typeof(long);
            float_type = typeof(float);

            data_types = new Type[] { int_type, string_type, int_type,
                                      string_type, string_type};
            allow_validating = new bool[] { false, true, true,
                                            true, true};
            allow_batch_validating = new bool[] { false, true, true,
                                                  true,true};
            allow_null = new bool[] { false, false, true,
                                      true,true};
            regex = new string[] { null, PLConstants.reg_clinic_part_title, PLConstants.reg_name,
                                   PLConstants.reg_english_title,PLConstants.reg_description };
            error_text = new string[] { null, PLConstants.error_title, PLConstants.error_combo_not_selected,
                                        PLConstants.error_title_english,PLConstants.error_description};

            this.selected_parts = selected_parts;

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);
            masked_type = typeof(MaskedTextBox);

            data_controls = new Control[] { id_textbox,name_textbox,clinic_type_combobox,
                                            tag_textbox,description_textbox};
            lable_controls = new Label[] { id_lable, name_label,clinic_type_label,
                                           tag_label,description_label};
            control_types = new Type[] { textbox_type,textbox_type, combobox_type,
                                         textbox_type,textbox_type};
            text_controls = new TextBox[] { id_textbox,name_textbox,
                                            tag_textbox,description_textbox};
            combo_controls = new ComboBox[] { clinic_type_combobox};
            masked_controls = null;
            clear_checkboxes = new CheckBox[]{id_checkbox,name_checkbox,clinic_type_checkbox,
                                              tag_checkbox,description_checkbox};
            error_providers = new ErrorProvider[] { null, EP_name,EP_clinic_type,
                                                    EP_tag,EP_description};

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;

            clinic_part_adapter = new PIPDataSetTableAdapters.SClinicPartTableAdapter();
            type_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();
            
            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد بخش درمانی جدید";
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
                errors = new bool[] { false, true, false,
                                      false,false};
                error_count = 1;
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                errors = new bool[properties_count];
                error_count = 0;
                current_data = new object[]{data_row.id,data_row.name,data_row.clinic_type_id,
                                            data_row.tag,data_row.description};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ویرایش اطلاعات بخش درمانی";
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
                            text_controls[mc].Text = current_data[i].ToString();
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
                this.Text = "ویرایش دسته ای اطلاعات چند بخش درمانی";
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

            initComboBoxes();
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
                        clinic_part_adapter.AddClinicPart((string)new_data[1], (int?)new_data[2], (string)new_data[3], (string)new_data[4], ref add_result);
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
                        clinic_part_adapter.EditClinicParts(false, (int)new_data[0], PLGlobalFuncs.emptyIntIDsDataTable(), (string)new_data[1],
                                              (int?)new_data[2], (string)new_data[3], (string)new_data[4], ref edit_result);
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
                message_text.Add("ویرایش دسته ای اطلاعات " + selected_parts.Rows.Count + " مورد");
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
                        clinic_part_adapter.EditClinicParts(true, null, selected_parts, (string)new_data[1], (int?)new_data[2], 
                                                (string)new_data[3], (string)new_data[4], ref edit_result);
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
            else if (allow_null[c_ind])
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
                if ((control_types[ch_ind] == textbox_type)&&(control_types[ch_ind] == masked_type))
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
                if ((data_types[ch_ind] == int_type) || (data_types[ch_ind] == float_type))
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
            type_table = type_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow it_first_row = type_table.NewTClinicTypeRow();
            it_first_row.id = -1;
            it_first_row.name = "---نوع مرکز درمانی---";
            type_table.Rows.InsertAt(it_first_row, 0);
            clinic_type_combobox.DataSource = type_table;
            clinic_type_combobox.DisplayMember = type_table.nameColumn.ColumnName;
            clinic_type_combobox.ValueMember = type_table.idColumn.ColumnName;
            clinic_type_combobox.SelectedIndex = 0;
            
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(clinic_type_combobox);
        }

    }
}
