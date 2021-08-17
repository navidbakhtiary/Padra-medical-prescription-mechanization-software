using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class CityForm : Form
    {
        object[] new_data;
        object[] current_data;
        Type[] data_types;
        bool[] allow_validating;
        bool[] allow_batch_validating;
        string[] regex;
        string[] error_text;
        bool[] errors;
        int error_count;

        DataTable selected_cities;

        Control[] data_controls;
        Label[] lable_controls;
        Type[] control_types;
        TextBox[] text_controls;
        ComboBox[] combo_controls;
        ErrorProvider[] error_providers;

        PGSDialog pgs_dialog;
        PLConstants.enum_operation_results result_enum;
        PLConstants.enum_data_operation form_operation;

        Type textbox_type;
        Type combobox_type;
        Type label_type;

        PIPDataSetTableAdapters.TCityTableAdapter c_adapter;
        PIPDataSetTableAdapters.ProvinceTableAdapter p_adapter;
        PIPDataSet.ProvinceDataTable provinces_data;

        public CityForm(object[] data, PLConstants.enum_data_operation operation, DataTable selected_cities)
        {
            InitializeComponent();
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            data_types = new Type[] { null, typeof(int), typeof(string) };
            allow_validating = new bool[] { false, true, true };
            allow_batch_validating = new bool[] { false, true, false };
            regex = new string[] { null, PLConstants.reg_name, PLConstants.reg_name };
            error_text = new string[] { null, PLConstants.error_combo_province_not_selected, PLConstants.error_letters_only };
            errors = new bool[] { false, false, false };
            error_count = 0;
            new_data = new object[data_types.Length];
            this.selected_cities = selected_cities;

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);

            data_controls = new Control[] { id_textbox, province_combobox, name_textbox };
            lable_controls = new Label[] { id_lable, province_label, name_lable };
            control_types = new Type[] { textbox_type, combobox_type, textbox_type };
            text_controls = new TextBox[] { id_textbox, name_textbox };
            combo_controls = new ComboBox[] { province_combobox };
            error_providers = new ErrorProvider[] { null, province_errorProvider, name_errorProvider };

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            c_adapter = new PIPDataSetTableAdapters.TCityTableAdapter();
            p_adapter = new PIPDataSetTableAdapters.ProvinceTableAdapter();
            initProvinceComboBox();

            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد شهر جدید";
                for (int i = 0; i < allow_validating.Length; i++)
                {
                    if (!allow_validating[i])
                    {
                        data_controls[i].Enabled = false;
                    }
                }
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                int tc = 0;
                int cc = 0;
                this.Text = "ویرایش اطلاعات شهر";
                current_data = new object[] { data[0], data[2], data[1] };//0=city id, 1=province id, 2=city name
                Array.Copy(current_data, new_data, data_types.Length);
                for (int i = 0; i < allow_validating.Length; i++)
                {
                    if (!allow_validating[i])
                    {
                        data_controls[i].Enabled = false;
                    }
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
            }
            else if (operation == PLConstants.enum_data_operation.batch_edit)
            {
                this.Text = "ویرایش دسته ای اطلاعات چند شهر";
                for (int i = 0; i < allow_batch_validating.Length; i++)
                {
                    if (!allow_batch_validating[i])
                    {
                        data_controls[i].Enabled = false;
                    }
                }
            }
        }

        private void save_button_Click(object sender, EventArgs e)
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
                for (int i = 0; i < new_data.Length; i++)
                {
                    if (allow_validating[i])
                    {
                        if (control_types[i]==textbox_type)
                        {
                            message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                        }
                        else if (control_types[i]==combobox_type)
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
                        c_adapter.AddCity((int)new_data[1], new_data[2].ToString(), ref add_result);
                        result_enum = PLEnumFuncs.opResultToEnum(add_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.city);
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
                for (int i = 0; i < current_data.Length; i++)
                {
                    message_text.Add(lable_controls[i].Text + current_data[i].ToString());
                }
                message_text.Add("اطلاعات جدید");
                for (int i = 0; i < new_data.Length; i++)
                {
                    if (allow_validating[i])
                    {
                        if (control_types[i] == textbox_type)
                        {
                            message_text.Add(lable_controls[i].Text + new_data[tc].ToString());
                            tc++;
                        }
                        else if (control_types[i] == combobox_type)
                        {
                            message_text.Add(lable_controls[i].Text + combo_controls[cc].Text);
                            cc++;
                        }
                    }
                    else
                    {
                        if (control_types[i] == textbox_type)
                        {
                            tc++;
                        }
                        else if (control_types[i] == combobox_type)
                        {
                            cc++;
                        }
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        c_adapter.EditCities(false, (int)current_data[0], PLGlobalFuncs.emptyIntIDsDataTable(), (int)new_data[1], new_data[2].ToString(), ref edit_result);
                        result_enum = PLEnumFuncs.opResultToEnum(edit_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.city);
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
                message_text.Add("ویرایش دسته ای اطلاعات "+selected_cities.Rows.Count+" مورد");
                message_text.Add("اطلاعات جدید");
                for (int i = 0; i < new_data.Length; i++)
                {
                    if (allow_batch_validating[i])
                    {
                        if (control_types[i] == textbox_type)
                        {
                            message_text.Add(lable_controls[i].Text + new_data[tc].ToString());
                            tc++;
                        }
                        else if (control_types[i] == combobox_type)
                        {
                            message_text.Add(lable_controls[i].Text + combo_controls[cc].Text);
                            cc++;
                        }
                    }
                    else
                    {
                        if (control_types[i] == textbox_type)
                        {
                            tc++;
                        }
                        else if (control_types[i] == combobox_type)
                        {
                            cc++;
                        }
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        c_adapter.EditCities(true, -1, selected_cities, (int)new_data[1], null, ref edit_result);
                        result_enum = PLEnumFuncs.opResultToEnum(edit_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.city);
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

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void text_control_Leave(object sender, EventArgs e)
        {
            TextBox t_box = (TextBox)sender;
            int t_ind = int.Parse(t_box.Tag.ToString());
            if (Regex.IsMatch(t_box.Text.Trim(), regex[t_ind]))
            {
                new_data[t_ind] = t_box.Text.Trim();
                if (errors[t_ind] || false)
                {
                    error_providers[t_ind].Clear();
                    error_count--;
                    errors[t_ind] = false;
                    t_box.BackColor = Color.White;
                }
            }
            else if (!(errors[t_ind] && true))
            {
                error_count++;
                errors[t_ind] = true;
                t_box.BackColor = Color.Red;
                error_providers[t_ind].SetError(t_box, error_text[t_ind]);
            }
        }

        private void combobox_control_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox c_box = (ComboBox)sender;
            int c_ind = int.Parse(c_box.Tag.ToString());
            if (c_box.SelectedIndex>0)
            {
                new_data[c_ind] = c_box.SelectedValue;
                if (errors[c_ind] || false)
                {
                    error_providers[c_ind].Clear();
                    error_count--;
                    errors[c_ind] = false;
                    c_box.BackColor = Color.White;
                }
            }
            else
            {
                error_providers[c_ind].SetError(c_box, error_text[c_ind]);
                error_count++;
                errors[c_ind] = true;
                c_box.BackColor = Color.Red;
            }
        }

        private void initProvinceComboBox()
        {
            provinces_data = p_adapter.GetAllProvinces();
            PIPDataSet.ProvinceRow p_first_row = provinces_data.NewProvinceRow();
            p_first_row.id = -1;
            p_first_row.name = "---استان---";
            provinces_data.Rows.InsertAt(p_first_row, 0);
            province_combobox.DataSource = provinces_data;
            province_combobox.DisplayMember = provinces_data.nameColumn.ColumnName;
            province_combobox.ValueMember = provinces_data.idColumn.ColumnName;
            province_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(province_combobox);
        }
    }
}
