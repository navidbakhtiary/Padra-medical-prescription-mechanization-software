using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;


namespace PadraInsurancePrescription
{
    public partial class MedicalCenterForm : Form
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

        DataTable selected_centers;

        Control[] data_controls;
        Label[] lable_controls;
        Type[] control_types;
        TextBox[] text_controls;
        ComboBox[] combo_controls;
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
        Type label_type;

        PIPDataSetTableAdapters.TMedicalCenterTableAdapter mc_adapter;
        PIPDataSetTableAdapters.ProvinceTableAdapter p_adapter;
        PIPDataSetTableAdapters.CityTableAdapter c_adapter;
        PIPDataSetTableAdapters.TClinicTypeTableAdapter ct_adapter;

        PIPDataSet.ProvinceDataTable p_table;
        PIPDataSet.CityDataTable c_table;
        PIPDataSet.TClinicTypeDataTable ct_table;

        public MedicalCenterForm(PIPDataSet.TMedicalCenterRow data_row, PLConstants.enum_data_operation operation, DataTable selected_centers)//checked
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            properties_count = 11;
            new_data = new object[properties_count];

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);


            this.selected_centers = selected_centers;
            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);

            errors = new bool[properties_count];
            data_types = new Type[] { int_type, int_type, string_type,
                                      string_type,int_type,int_type,string_type,
                                      string_type, string_type, string_type,
                                      string_type};
            allow_validating = new bool[] { false, true, true,
                                            true, true,true, true,
                                            true, true, true,
                                            true };
            allow_batch_validating = new bool[] { false, true, false,
                                                  true,true,true,true,
                                                  true,true,true,
                                                  true};
            allow_null = new bool[] { false, false, true,
                                      false,false,false,true,
                                      true,true,true,
                                      true};
            regex = new string[] { null, PLConstants.reg_name, PLConstants.reg_id,
                                   PLConstants.reg_title,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_address,
                                   PLConstants.reg_phone,PLConstants.reg_phone,PLConstants.reg_multiple_names,
                                   PLConstants.reg_description};
            error_text = new string[] { null, PLConstants.error_combo_not_selected, PLConstants.error_id_just_number,
                                        PLConstants.error_title,PLConstants.error_combo_not_selected,PLConstants.error_combo_not_selected,PLConstants.error_address,
                                        PLConstants.error_phone,PLConstants.error_phone,PLConstants.error_multiple_names,
                                        PLConstants.error_description};


            data_controls = new Control[] { id_textbox,type_combobox,national_id_textbox,
                                            title_textbox,province_combobox,city_combobox,address_textbox,
                                            phone_number_textbox,mobile_number_textbox,anwserable_names_textbox,
                                            description_textbox};
            lable_controls = new Label[] { id_lable, type_lable, national_id_label,
                                           title_label,province_label,city_label,address_label,
                                           phone_label,mobile_label,anwserable_label,
                                           description_label};
            control_types = new Type[] { textbox_type, combobox_type, textbox_type,
                                         textbox_type,combobox_type,combobox_type,textbox_type,
                                         textbox_type,textbox_type,textbox_type,
                                         textbox_type};
            text_controls = new TextBox[] { id_textbox,national_id_textbox,
                                            title_textbox,address_textbox,
                                            phone_number_textbox,mobile_number_textbox,anwserable_names_textbox,
                                            description_textbox};
            combo_controls = new ComboBox[] { type_combobox,
                                              province_combobox,city_combobox};
            clear_checkboxes = new CheckBox[]{id_checkbox,type_checkbox,national_id_checkbox,
                                              title_checkbox,province_checkbox,city_checkbox,address_checkbox,
                                              phone_checkbox,mobile_checkbox,anwserable_checkbox,
                                              description_checkbox};
            error_providers = new ErrorProvider[] { null, EP_type, EP_national_id,
                                                    EP_title,EP_province,EP_city,EP_address,
                                                    EP_phone,EP_mobile,EP_anwserable,
                                                    EP_description};

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            mc_adapter = new PIPDataSetTableAdapters.TMedicalCenterTableAdapter();
            c_adapter = new PIPDataSetTableAdapters.CityTableAdapter();
            p_adapter = new PIPDataSetTableAdapters.ProvinceTableAdapter();
            ct_adapter = new PIPDataSetTableAdapters.TClinicTypeTableAdapter();

            initComboBoxes();
            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "مرکز جدید";
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
                                      true,true,true,false,
                                      false,false,false,
                                      false};
                error_count = 4;
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                errors = new bool[properties_count];
                error_count = 0;
                current_data = new object[]{data_row.id,data_row.clinic_type,data_row.national_id,
                                            data_row.name,data_row.province,data_row.city,data_row.address,
                                            data_row.phone_numbers,data_row.mobile_numbers,data_row.anwserable_names,
                                            data_row.description};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                this.Text = "ویرایش اطلاعات مرکز";
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
                this.Text = "ویرایش دسته ای اطلاعات چند مرکز";
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

        /////////////////////////////////////////////////////////////////////////// EVENTS
        #region events

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
                        mc_adapter.AddMedicalCenter((int)new_data[1], (string)new_data[2],(string)new_data[3],
                                            (int)new_data[5], (string)new_data[6], (string)new_data[7],
                                            (string)new_data[8], (string)new_data[9], (string)new_data[10],
                                            ref add_result);
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
                        mc_adapter.EditMedicalCenters(false, (int)new_data[0], PLGlobalFuncs.emptyIntIDsDataTable(), (int)new_data[1],
                                                     (string)new_data[2],(string)new_data[3], (int)new_data[5],(string)new_data[6],
                                                     (string)new_data[7], (string)new_data[8], (string)new_data[9],(string)new_data[10],
                                                     ref edit_result);
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
                message_text.Add("ویرایش دسته ای اطلاعات " + selected_centers.Rows.Count + " مورد");
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
                        mc_adapter.EditMedicalCenters(true, null, selected_centers, (int?)new_data[1],
                                                     (string)new_data[2],(string)new_data[3], (int?)new_data[5],(string)new_data[6],
                                                     (string)new_data[7], (string)new_data[8], (string)new_data[9],(string)new_data[10],
                                                     ref edit_result);
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

        private void province_combobox_SelectedIndexChanged(object sender, EventArgs e)//checked
        {
            int c_ind = int.Parse(province_combobox.Tag.ToString());
            if (province_combobox.SelectedIndex > 0)
            {
                new_data[c_ind] = province_combobox.SelectedValue;
                if (errors[c_ind] || false)
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    province_combobox.BackColor = Color.White;
                }
                initCityComboBox((int)province_combobox.SelectedValue);
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_edit)
            {
                new_data[c_ind] = null;
                if (errors[c_ind])
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    province_combobox.BackColor = Color.White;
                }
            }
            else
            {
                error_providers[c_ind].SetError(province_combobox, error_text[c_ind]);
                error_count++;
                errors[c_ind] = true;
                province_combobox.BackColor = Color.Red;
                city_combobox.DataSource = null;
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

        #endregion

        /////////////////////////////////////////////////////////////////////////// METHODS
        #region methods

        private void initComboBoxes()//checked
        {
            p_table = p_adapter.GetAllProvinces();
            PIPDataSet.ProvinceRow p_first_row = p_table.NewProvinceRow();
            p_first_row.id = -1;
            p_first_row.name = "---استان---";
            p_table.Rows.InsertAt(p_first_row, 0);
            province_combobox.DataSource = p_table;
            province_combobox.DisplayMember = p_table.nameColumn.ColumnName;
            province_combobox.ValueMember = p_table.idColumn.ColumnName;
            province_combobox.SelectedIndex = 0;

            ct_table = ct_adapter.GetAllTypes();
            PIPDataSet.TClinicTypeRow ct_first_row = ct_table.NewTClinicTypeRow();
            ct_first_row.id = -1;
            ct_first_row.name = "--نوع مرکز--";
            ct_table.Rows.InsertAt(ct_first_row, 0);
            type_combobox.DataSource = ct_table;
            type_combobox.DisplayMember = ct_table.nameColumn.ColumnName;
            type_combobox.ValueMember = ct_table.idColumn.ColumnName;
            type_combobox.SelectedIndex = 0;

            PLGlobalFuncs.adjustDropDownWidthOfComboBox(type_combobox);
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(province_combobox);
        }

        private void initCityComboBox(int selected_province)//checked
        {
            c_table = c_adapter.GetCitiesOfProvince(selected_province);
            PIPDataSet.CityRow c_first_row = c_table.NewCityRow();
            c_first_row.id = -1;
            c_first_row.name = "---شهر---";
            c_first_row.province = selected_province;
            c_table.Rows.InsertAt(c_first_row, 0);
            city_combobox.DataSource = c_table;
            city_combobox.DisplayMember = c_table.nameColumn.ColumnName;
            city_combobox.ValueMember = c_table.idColumn.ColumnName;
            city_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(city_combobox);
        }

        #endregion methods
    }
}
