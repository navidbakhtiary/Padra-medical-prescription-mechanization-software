using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;


namespace PadraInsurancePrescription
{
    public partial class ProvinceForm : Form
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

        PIPDataSetTableAdapters.ProvinceTableAdapter p_adapter;

        public ProvinceForm(object[] data, PLConstants.enum_data_operation operation)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            data_types = new Type[] { null, typeof(string) };
            allow_validating = new bool[] { false, true };
            allow_batch_validating = new bool[] { false, false };
            regex = new string[] { null, PLConstants.reg_name };
            error_text = new string[] { null, PLConstants.error_letters_only };
            errors = new bool[] { false, false };
            error_count = 0;
            current_data = data;
            new_data = new object[data_types.Length];
            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);

            data_controls = new Control[] { id_textbox, name_textbox };
            lable_controls = new Label[] { id_lable, name_lable };
            control_types = new Type[] { textbox_type, textbox_type };
            text_controls = new TextBox[] { id_textbox, name_textbox };
            combo_controls = new ComboBox[] {  };
            error_providers = new ErrorProvider[] { null, name_errorProvider };

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            p_adapter = new PIPDataSetTableAdapters.ProvinceTableAdapter();

            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد استان جدید";
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
                this.Text = "ویرایش اطلاعات استان";
                for (int i = 0; i < allow_validating.Length; i++)
                {
                    if (!allow_validating[i])
                    {
                        data_controls[i].Enabled = false;
                    }
                    if (control_types[i] == textbox_type)
                    {
                        text_controls[tc].Text = current_data[i].ToString();
                        tc++;
                    }
                }
            }
            
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            int tc = 0;

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
                        if (control_types[i] == textbox_type)
                        {
                            message_text.Add(lable_controls[i].Text + new_data[i].ToString());
                        }
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string add_result = "";
                        p_adapter.AddProvince((string)new_data[1], ref add_result);
                        result_enum = PLEnumFuncs.opResultToEnum(add_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.province);
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
                    }
                    else if (control_types[i] == textbox_type)
                    {
                        tc++;
                    }
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        p_adapter.EditProvince((int)current_data[0], (string)new_data[1], ref edit_result);
                        result_enum = PLEnumFuncs.opResultToEnum(edit_result);
                        pgs_dialog.operationResult(result_enum, PLConstants.enum_information_part.province);
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
            int c_ind = (int)c_box.Tag;
            if (c_box.SelectedIndex > 0)
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
    }
}