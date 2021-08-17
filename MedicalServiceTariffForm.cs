using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Data;

namespace PadraInsurancePrescription
{
    public partial class MedicalServiceTariffForm : Form
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
        bool need_to_service;
        string current_service_str;
        int error_count;
        int s_error_count;
        int i_error_count;
        int t_error_count;

        int tip_tot,tip_pat_sha,tip_dis,tip_ins_sha,tip_pat_per,tip_ins_per,tip_k;//tip_pat_k,tip_ins_k;
        int tpr_tot, tpr_pat_sha, tpr_dis, tpr_ins_sha, tpr_pat_per, tpr_ins_per, tpr_k;//,tpr_pat_k,tpr_ins_k;
        enum refresh_enum { all, cost, discount, k };
        enum tab_enum { service, info, tariff };
        ImageList error_images;

        string service_tab_error;
        string info_tab_error;
        string tariff_tab_error;

        DataTable selected_tariffs;

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
        Type double_type;

        Type textbox_type;
        Type combobox_type;
        Type label_type;
        Type masked_type;

        PIPDataSetTableAdapters.TMedicalServiceTariffTableAdapter tariff_adapter;
        PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter s_cat_adapter;
        PIPDataSetTableAdapters.TMedicalServiceTableAdapter service_adapter;
        PIPDataSetTableAdapters.TInsuranceTableAdapter ins_adapter;
        PIPDataSetTableAdapters.TInsuranceSectorTableAdapter sec_adapter;
        PIPDataSetTableAdapters.TMedicineDegreeTableAdapter deg_adapter;

        PIPDataSet.TMedicalServiceCategoryDataTable s_categories_data;
        PIPDataSet.TInsuranceDataTable ins_table;
        PIPDataSet.TInsuranceSectorDataTable sec_table;
        PIPDataSet.TMedicineDegreeDataTable deg_table;
        PIPDataSet.KValueDataTable k_value_public_table,k_value_private_table;

        PIPDataSet.TMedicalServiceRow s_service_row;

        string s_search_name;
        string s_search_code;
        int s_search_category;
        int s_index_one;
        int s_index_two;
        long s_selected_id;
        CheckBox s_select_all_checkbox;
        string s_str_sel_col;

        string k_year;
        int k_pub_index, k_pri_index;
        int? k_pub_id=null, k_pri_id=null;
        int k_pub_pro_val, k_pub_tec_val;
        int k_pri_pro_val, k_pri_tec_val;
        string k_str_pub_sel_col, k_str_pri_sel_col;
        PIPDataSet.KValueRow k_pub_row, k_pri_row;
        CheckBox k_pub_select_all_chk, k_pri_select_all_chk;
        bool k_auto_vals;
       
        public MedicalServiceTariffForm(PIPDataSet.TMedicalServiceTariffRow data_row, PLConstants.enum_data_operation operation, DataTable selected_tariffs)//checked
        {
            InitializeComponent();
            PLGlobalFuncs.changeDGVSettings(s_service_grid, k_public_grid, k_private_grid);
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.data);

            int tab_item_header_width = main_tabControl.Width / main_tabControl.TabPages.Count;
            main_tabControl.ItemSize = new Size((main_tabControl.Width / main_tabControl.TabPages.Count) - 2, main_tabControl.ItemSize.Height);

            properties_count = 23;
            new_data = new object[properties_count];

            int_type = typeof(int);
            string_type = typeof(string);
            bool_type = typeof(bool);
            long_type = typeof(long);
            float_type = typeof(float);
            double_type = typeof(double);

            textbox_type = typeof(TextBox);
            combobox_type = typeof(ComboBox);
            label_type = typeof(Label);
            masked_type = typeof(MaskedTextBox);

            errors = new bool[properties_count];
            error_count = s_error_count = i_error_count = t_error_count = 0;

            data_types = new Type[] { long_type,
                                      long_type,string_type, int_type,int_type,int_type,string_type,string_type,string_type,
                                      int_type,int_type, int_type,int_type,
                                      double_type,double_type,
                                      double_type,
                                      int_type,int_type, int_type,int_type,
                                      double_type,double_type,
                                      double_type};
            allow_validating = new bool[] { false, 
                                            false, true,true, true,true, true,true,true,
                                            true, true,true,true,
                                            true,true,
                                            true,
                                            true, true,true,true,
                                            true,true,
                                            true};
            allow_batch_validating = new bool[] { false, 
                                            false,true, true,true, true,true, true,true,
                                            true, true,true,true,
                                            true,true,
                                            true,
                                            true, true,true,true,
                                            true,true,
                                            true};
            allow_null = new bool[] { false, 
                                      false, true, true, true, false, false, true, true,
                                      false, false,false,false,
                                      false,false,
                                      false,
                                      false, false,false,false,
                                      false,false,
                                      false};
            regex = new string[] { null, 
                                   null,PLConstants.reg_title, PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_name,PLConstants.reg_date_slash,PLConstants.reg_date_slash,PLConstants.reg_description,
                                   null,null,null,null,
                                   null,null,
                                   null,
                                   null,null,null,null,
                                   null,null,
                                   null};
            error_text = new string[] { PLConstants.error_choose_one_service,
                                        null,PLConstants.error_title, null,null,PLConstants.error_combo_not_selected,PLConstants.error_date,PLConstants.error_date,PLConstants.error_description,
                                        PLConstants.error_public_tariff,null,null,null,
                                        null,null,
                                        null,
                                        null,null,null,null,
                                        null,null,
                                        null};

            tip_tot = 9; tip_pat_sha = 10; tip_dis = 11; tip_ins_sha = 12; tip_pat_per = 13; tip_ins_per = 14; tip_k = 15; 
            tpr_tot = 16; tpr_pat_sha = 17; tpr_dis = 18; tpr_ins_sha = 19; tpr_pat_per = 20; tpr_ins_per = 21; tpr_k = 22; 

            service_tab_error = "هیچ خدمتی برای تعیین تعرفه مشخص نشده است. حتما باید یک خدمت انتخاب شود !";
            info_tab_error = "در قسمت اطلاعات تعرفه خطا وجود دارد. خطاها را اصلاح کنید !";
            tariff_tab_error = "در قسمت هزینه های تعرفه خطا وجود دارد. خطاها را اصلاح کنید !";

            this.selected_tariffs = selected_tariffs;

            data_controls = new Control[] { null,
                                            i_sequence_textbox,i_alias_textbox,i_insurance_combobox,i_sector_combobox,i_degree_combobox,i_start_date_masked,i_end_date_masked,i_description_textbox,
                                            public_total_textbox,public_pat_sha_textbox,public_discount_textbox,public_ins_sha_textbox,
                                            public_pat_per_textbox,public_ins_per_textbox,
                                            public_k_textbox,
                                            private_total_textbox,private_pat_sha_textbox,private_discount_textbox,private_ins_sha_textbox,
                                            private_pat_per_textbox,private_ins_per_textbox,
                                            private_k_textbox};
            lable_controls = new Label[] { null,
                                           i_sequence_label,i_alias_label,i_insurance_label,i_sector_label,i_degree_label,i_start_date_label,i_end_date_label,i_description_label,
                                           public_total_label,public_pat_sha_label,public_discount_label,public_ins_sha_label,
                                           public_pat_per_label,public_ins_per_label,
                                           public_k_label,
                                           private_total_label,private_pat_sha_label,private_discount_label,private_ins_sha_label,
                                           private_pat_per_label,private_ins_per_label,
                                           private_k_label};
            control_types = new Type[] { null, 
                                         textbox_type,textbox_type,combobox_type,combobox_type,combobox_type,masked_type,masked_type,textbox_type,
                                         textbox_type,textbox_type,textbox_type,textbox_type,
                                         textbox_type,textbox_type,
                                         textbox_type,
                                         textbox_type,textbox_type,textbox_type,textbox_type,
                                         textbox_type,textbox_type,
                                         textbox_type};
            text_controls = new TextBox[] { i_sequence_textbox,i_alias_textbox,i_description_textbox,
                                            public_total_textbox,public_pat_sha_textbox,public_discount_textbox,public_ins_sha_textbox,
                                            public_pat_per_textbox,public_ins_per_textbox,
                                            public_k_textbox,
                                            private_total_textbox,private_pat_sha_textbox,private_discount_textbox,private_ins_sha_textbox,
                                            private_pat_per_textbox,private_ins_per_textbox,
                                            private_k_textbox};
            combo_controls = new ComboBox[] { i_insurance_combobox, i_sector_combobox, i_degree_combobox };
            masked_controls = new MaskedTextBox[] { i_start_date_masked, i_end_date_masked };
            clear_checkboxes = new CheckBox[]{null,
                                              i_sequence_checkbox,i_alias_checkbox,i_insurance_checkbox,i_sector_checkbox,i_degree_checkbox,i_start_date_checkbox,i_end_date_checkbox,i_description_checkbox,
                                              public_total_checkbox,public_pat_sha_checkbox,public_discount_checkbox,public_ins_sha_checkbox,
                                              public_pat_per_checkbox,public_ins_per_checkbox,
                                              public_k_checkbox,
                                              private_total_checkbox,private_pat_sha_checkbox,private_discount_checkbox,private_ins_sha_checkbox,
                                              private_pat_per_checkbox,private_ins_per_checkbox,
                                              private_k_checkbox};
            error_providers = new ErrorProvider[] { EP_service,
                                                    null,EP_alias,null,null,EP_degree,EP_start_date,EP_end_date,EP_description,    
                                                    EP_public,null,null,null,
                                                    null,null,
                                                    null,
                                                    null,null,null,null,
                                                    null,null,
                                                    null};

            pgs_dialog = new PGSDialog(this);
            form_operation = operation;
            error_images = new ImageList();
            error_images.Images.Add(Properties.Resources.notice_icon_red_small);
            main_tabControl.ImageList = error_images;

            tariff_adapter = new PIPDataSetTableAdapters.TMedicalServiceTariffTableAdapter();
            service_adapter = new PIPDataSetTableAdapters.TMedicalServiceTableAdapter();
            s_cat_adapter = new PIPDataSetTableAdapters.TMedicalServiceCategoryTableAdapter();
            ins_adapter = new PIPDataSetTableAdapters.TInsuranceTableAdapter();
            sec_adapter = new PIPDataSetTableAdapters.TInsuranceSectorTableAdapter();
            deg_adapter = new PIPDataSetTableAdapters.TMedicineDegreeTableAdapter();

            s_selected_id = -1;
            s_select_all_checkbox = new CheckBox();
            //s_select_all_checkbox.CheckedChanged += s_select_all_checkbox_CheckedChanged;
            s_select_all_checkbox.Visible = false;
            s_index_one = s_index_two = -1;
            s_str_sel_col = "s_select_column";

            k_value_public_table = new PIPDataSet.KValueDataTable();
            k_value_private_table = new PIPDataSet.KValueDataTable();
            k_str_pub_sel_col = k_pub_select_column.Name;
            k_str_pri_sel_col = k_pri_select_column.Name;
            k_pub_select_all_chk = new CheckBox();
            k_pri_select_all_chk = new CheckBox();

            initSCategoryComboBox();
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(s_category_combobox);

            initInfoComboBoxes();
            initKYearComboBox();

            if (operation == PLConstants.enum_data_operation.new_data)
            {
                this.Text = "ایجاد تعرفه پزشکی جدید";
                need_to_service = true;
                for (int i = 1; i <= 8; i++)
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
                for (int i = 9; i < properties_count; i++)
                {
                    data_controls[i].Enabled = true;
                }
                errors = new bool[] { true, 
                                      false,false, false,false, true,true, false,false,
                                      true, false,false,false,
                                      false,false,
                                      false,
                                      false, false,false,false,
                                      false,false,
                                      false};
                new_data[tip_tot] = new_data[tip_pat_sha] = new_data[tip_dis] = new_data[tip_ins_sha] = 0;
                new_data[tip_pat_per] = 0.0;
                new_data[tip_ins_per] = 100.0;
                new_data[tip_k] = 0.0;
                new_data[tpr_tot] = new_data[tpr_pat_sha] = new_data[tpr_dis] = new_data[tpr_ins_sha] = 0;
                new_data[tpr_pat_per] = 0.0;
                new_data[tpr_ins_per] = 100.0;
                new_data[tpr_k] = 0.0;
                error_count = 4;
                s_error_count = 1;
                i_error_count = 2;
                t_error_count = 1;
                EP_service.SetError(s_selected_textbox, error_text[0]);
                setTabError(tab_enum.service, true);
                setTabError(tab_enum.info, true);
                setTabError(tab_enum.tariff, true);
                EP_public.SetError(public_total_textbox, error_text[tip_tot]);
            }
            else if (operation == PLConstants.enum_data_operation.edit_data)
            {
                errors[0] = true;
                error_count = s_error_count = 1;
                need_to_service = true;
                current_data = new object[]{data_row.service,
                                            data_row.sequence,data_row.alias_name,data_row.insurance,data_row.insurance_sector,data_row.medicine_degree,data_row.start_date,data_row.end_date,data_row.description,
                                            data_row.public_total_cost,data_row.public_patient_share,data_row.public_discount,data_row.public_insurance_share,
                                            data_row.public_patient_percent,data_row.public_insurance_percent,
                                            data_row.k_factor,
                                            data_row.private_total_cost,data_row.private_patient_share,data_row.private_discount,data_row.private_insurance_share,
                                            data_row.private_patient_percent,data_row.private_insurance_percent,
                                            data_row.k_factor};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ویرایش اطلاعات تعرفه پزشکی";
                
                service_adapter.FillBySequence(pIPDataSet.TMedicalService, data_row.service);
                
                for (int i = 1; i <= 8; i++)// 1 because of service-service is skipped   7 because of controls of info tab
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
                            if (data_types[i] == int_type && ((int)new_data[i]) == -1)
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

                k_public_grid.CellValueChanged -= k_public_grid_CellValueChanged;
                k_public_grid.CurrentCellDirtyStateChanged -= k_public_grid_CurrentCellDirtyStateChanged;
                k_private_grid.CellValueChanged -= k_private_grid_CellValueChanged;
                k_private_grid.CurrentCellDirtyStateChanged -= k_private_grid_CurrentCellDirtyStateChanged;
                kValueTableAdapter.FillByID(k_value_public_table, data_row.public_k_value);
                k_public_grid.DataSource = k_value_public_table;
                kValueTableAdapter.FillByID(k_value_private_table, data_row.private_k_value);
                k_private_grid.DataSource = k_value_private_table;
                k_pub_index = k_pri_index = 1;
                k_public_grid.CellValueChanged += k_public_grid_CellValueChanged;
                k_public_grid.CurrentCellDirtyStateChanged += k_public_grid_CurrentCellDirtyStateChanged;
                k_private_grid.CellValueChanged += k_private_grid_CellValueChanged;
                k_private_grid.CurrentCellDirtyStateChanged += k_private_grid_CurrentCellDirtyStateChanged;

                double t_fl;
                string t_fl_str;
                for (int i = 9; i < properties_count; i++)// 1 because of service-service is skipped   7 because of controls of info tab
                {
                    data_controls[i].Enabled = true;
                    if (data_types[i] == int_type)
                    {
                        text_controls[tc].Text = ((int)current_data[i]).ToString("N0");
                        tc++;
                    }
                    else if (data_types[i] == double_type)
                    {
                        text_controls[tc].Text = (Convert.ToDouble(current_data[i])).ToString("N2");
                        tc++;
                    }
                }
            }
            else if (operation == PLConstants.enum_data_operation.copy_data)
            {
                need_to_service = true;
                //errors = new bool[properties_count];
                current_data = new object[]{data_row.service,
                                            data_row.sequence,data_row.alias_name,data_row.insurance,data_row.insurance_sector,data_row.medicine_degree,null,null,data_row.description,
                                            data_row.public_total_cost,data_row.public_patient_share,data_row.public_discount,data_row.public_insurance_share,
                                            data_row.public_patient_percent,data_row.public_insurance_percent,
                                            data_row.k_factor,
                                            data_row.private_total_cost,data_row.private_patient_share,data_row.private_discount,data_row.private_insurance_share,
                                            data_row.private_patient_percent,data_row.private_insurance_percent,
                                            data_row.k_factor};
                Array.Copy(current_data, new_data, properties_count);
                int tc = 0;
                int cc = 0;
                int mc = 0;
                this.Text = "ایجاد تعرفه پزشکی جدید بر اساس یک تعرفه ثبت شده";
                service_adapter.FillBySequence(pIPDataSet.TMedicalService, data_row.service);
                //s_service_grid.Rows[0].Cells[s_select_column.Name].Value = true;
                for (int i = 1; i <= 8; i++)// 1 because of service-service is skipped   8 because of controls of info tab
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
                            if (data_types[i] == int_type && ((int)new_data[i]) == -1)
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

                k_public_grid.CellValueChanged -= k_public_grid_CellValueChanged;
                k_public_grid.CurrentCellDirtyStateChanged -= k_public_grid_CurrentCellDirtyStateChanged;
                k_private_grid.CellValueChanged -= k_private_grid_CellValueChanged;
                k_private_grid.CurrentCellDirtyStateChanged -= k_private_grid_CurrentCellDirtyStateChanged;
                kValueTableAdapter.FillByID(k_value_public_table, data_row.public_k_value);
                k_public_grid.DataSource = k_value_public_table;
                kValueTableAdapter.FillByID(k_value_private_table, data_row.private_k_value);
                k_private_grid.DataSource = k_value_private_table;
                k_pub_index = k_pri_index = 1;
                k_public_grid.CellValueChanged += k_public_grid_CellValueChanged;
                k_public_grid.CurrentCellDirtyStateChanged += k_public_grid_CurrentCellDirtyStateChanged;
                k_private_grid.CellValueChanged += k_private_grid_CellValueChanged;
                k_private_grid.CurrentCellDirtyStateChanged += k_private_grid_CurrentCellDirtyStateChanged;
                
                double t_fl;
                string t_fl_str;
                for (int i = 9; i < properties_count; i++)// 1 because of service-service is skipped   7 because of controls of info tab
                {
                    data_controls[i].Enabled = true;
                    if (current_data[i] != null)
                    {
                        if (data_types[i] == int_type)
                        {
                            text_controls[tc].Text = ((int)current_data[i]).ToString("N0");
                            tc++;
                        }
                        else if (data_types[i] == double_type)
                        {
                            t_fl = Convert.ToDouble(current_data[i]);
                            t_fl_str = ((t_fl % 1) == 0) ? "" : (t_fl % 1).ToString();
                            text_controls[tc].Text = t_fl.ToString("N" + t_fl_str.Length);
                            tc++;
                        }
                    }
                }

                //errors[0]=errors[6] = true;
                errors[6] = true;
                //s_error_count = 1;
                s_error_count = 0;
                i_error_count = 1;
                t_error_count = 0;
                //error_count = 2;
                error_count = 1;
                //s_error_count = t_error_count = 0;
                //need_to_service = true;

                i_start_date_masked.Text = "";
                EP_start_date.SetError(i_start_date_masked, error_text[6]);
                EP_info_tab.SetError(info_tab, info_tab_error);
            }
            else if (operation == PLConstants.enum_data_operation.batch_copy)
            {
                /*errors = new bool[properties_count];
                errors[6] = true;
                error_count = i_error_count = 1;
                s_error_count = t_error_count = 0;
                need_to_service = false;
                EP_start_date.SetError(i_start_date_masked, error_text[6]);
                EP_info_tab.SetError(info_tab, info_tab_error);
                this.Text = "ایجاد چند تعرفه پزشکی جدید بر اساس اطلاعات موجود";
                i_clear_label.Visible = t_clear_label.Visible = true;
                for (int i = 1; i < properties_count; i++)
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
            else if (operation == PLConstants.data_operation.batch_edit)
            {
                need_to_service = false;
                errors = new bool[properties_count];
                error_count = 0;
                this.Text = "ویرایش دسته ای اطلاعات چند تعرفه پزشکی";
                i_clear_label.Visible = t_clear_label.Visible = true;
                for (int i = 1; i < properties_count; i++)//1 because of service skipped
                {
                    if (allow_batch_validating[i])
                    {
                        data_controls[i].Enabled = true;
                    }
                    if (allow_null[i])
                    {
                        clear_checkboxes[i].Enabled = true;
                    }
                }*/
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
                List<string> message_text = new List<string>();
                message_text.Add("اطلاعات جدید");
                message_text.Add("خدمت پزشکی: " + s_selected_textbox.Text);
                for (int i = 1; i <= 8; i++)
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
                for (int i = 9; i < properties_count; i++)
                {
                    message_text.Add(lable_controls[i].Text + data_controls[i].Text);
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_new, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string add_result = "";
                        tariff_adapter.AddMedicalTariffs(false, PLGlobalFuncs.emptyLongIDsDataTable(),
                                            s_selected_id, (string)new_data[2], (int?)new_data[3], (int?)new_data[4], (int)new_data[5],
                                            (string)new_data[6], (string)new_data[7], (string)new_data[8],
                                            k_pub_id,k_pri_id,
                                            Convert.ToDouble(new_data[tip_ins_per]),Convert.ToDouble(new_data[tip_pat_per]),
                                            (int)new_data[tip_tot],(int)new_data[tip_ins_sha], (int)new_data[tip_pat_sha], (int)new_data[tip_dis],    
                                            Convert.ToDouble(new_data[tpr_ins_per]), Convert.ToDouble(new_data[tpr_pat_per]),
                                            (int)new_data[tpr_tot], (int)new_data[tpr_ins_sha], (int)new_data[tpr_pat_sha], (int)new_data[tpr_dis], 
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
                message_text.Add("خدمت پزشکی: " + current_service_str);
                for (int i = 1; i < properties_count; i++)
                {
                    if (current_data[i] != null)
                    {
                        message_text.Add(lable_controls[i].Text + current_data[i].ToString());
                    }
                }
                message_text.Add("اطلاعات جدید");
                for (int i = 1; i <= 8; i++)
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
                for (int i = 9; i < properties_count; i++)
                {
                    message_text.Add(lable_controls[i].Text + data_controls[i].Text);
                }
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.save_edit, message_text);
                switch (pgs_dialog.user_choice)
                {
                    case PLConstants.enum_dialog_options.yes:
                        string edit_result = "";
                        tariff_adapter.EditMedicalTariffs(false, (long)new_data[1], PLGlobalFuncs.emptyLongIDsDataTable(),
                                              s_selected_id, (string)new_data[2], (int?)new_data[3], (int?)new_data[4],
                                              (int)new_data[5], (string)new_data[6], (string)new_data[7], (string)new_data[8],
                                              k_pub_id,k_pri_id,
                                              (double)new_data[tip_ins_per],(double)new_data[tip_pat_per],
                                              (int)new_data[tip_tot],(int)new_data[tip_ins_sha], (int)new_data[tip_pat_sha], (int)new_data[tip_dis],
                                              (double)new_data[tpr_ins_per], (double)new_data[tpr_pat_per],
                                              (int)new_data[tpr_tot], (int)new_data[tpr_ins_sha], (int)new_data[tpr_pat_sha], (int)new_data[tpr_dis],
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
            }
            else if (form_operation == PLConstants.enum_data_operation.batch_copy)
            {
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)//checked
        {
            this.Close();
        }

        private void setTabError(tab_enum s_tab, bool has_error)
        {
            switch (s_tab)
            {
                case tab_enum.service:
                    if (has_error)
                    {
                        service_tab.ImageIndex = 0;
                        service_tab.ToolTipText = service_tab_error;
                    }
                    else
                    {
                        service_tab.ImageIndex = -1;
                        service_tab.ToolTipText = null;
                    }
                    break;
                case tab_enum.info:
                    if (has_error)
                    {
                        info_tab.ImageIndex = 0;
                        info_tab.ToolTipText = info_tab_error;
                    }
                    else
                    {
                        info_tab.ImageIndex = -1;
                        info_tab.ToolTipText = null;
                    }
                    break;
                case tab_enum.tariff:
                    if(has_error)
                    {
                        tariff_tab.ImageIndex = 0;
                        tariff_tab.ToolTipText = tariff_tab_error;
                    }
                    else
                    {
                        tariff_tab.ImageIndex = -1;
                        tariff_tab.ToolTipText = null;
                    }
                    break;
            }
        }

        private void MedicalServiceTariffForm_Shown(object sender, EventArgs e)
        {
            if ((form_operation == PLConstants.enum_data_operation.edit_data) || (form_operation == PLConstants.enum_data_operation.copy_data))
            {
                (s_service_grid.Rows[0].Cells[s_str_sel_col] as DataGridViewCheckBoxCell).Value = true;
            }
        }

        ///////////////////////////////////////////////////////////////////////// SERVICE TAB
        #region Service Tab

        private void s_search_button_Click(object sender, EventArgs e)//checked
        {
            List<string> message_text = new List<string>();
            bool error = false;
            bool all_empty = true;
            s_search_name = "";
            s_search_code = "";
            s_search_category = -1;

            if (!Regex.IsMatch(s_search_name = s_name_text.Text.Trim(), PLConstants.reg_m_service_name_search))
            {
                error = true;
                message_text.Add(PLConstants.error_medical_service_name);
            }
            else if (s_search_name.Length > 0)
            {
                all_empty = false;
            }
            if (!Regex.IsMatch(s_search_code = s_code_text.Text.Trim(), PLConstants.reg_search_id_10))
            {
                error = true;
                message_text.Add(PLConstants.error_id_just_number);
            }
            else if (s_search_code.Length > 0)
            {
                all_empty = false;
            }
            if (s_category_combobox.SelectedIndex > 0)
            {
                all_empty = false;
                s_search_category = (int)s_category_combobox.SelectedValue;
            }
            s_service_grid.CellValueChanged -= s_service_grid_CellValueChanged;
            s_service_grid.CurrentCellDirtyStateChanged -= s_service_grid_CurrentCellDirtyStateChanged;
            if (error)
            {
                pgs_dialog.multipleMessage(PLConstants.enum_dialog_types.error, message_text);
            }
            else if (all_empty)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_search_fields_not_empty);
            }
            else if (tMedicalServiceTableAdapter.FillBySearch(pIPDataSet.TMedicalService, s_search_name, s_search_category, s_search_code) == 0)
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_no_record_after_search);
                //s_select_all_checkbox.Visible = false;
            }
            s_service_grid.CellValueChanged += s_service_grid_CellValueChanged;
            s_service_grid.CurrentCellDirtyStateChanged += s_service_grid_CurrentCellDirtyStateChanged;
        }

        private void s_service_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (s_service_grid.Rows.Count > 0)
            {
                afterServiceGridFilled();
                s_service_grid.CellValueChanged += s_service_grid_CellValueChanged;
                s_service_grid.CurrentCellDirtyStateChanged += s_service_grid_CurrentCellDirtyStateChanged;
                s_index_one = s_index_two = -1;
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
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(s_service_grid.Rows[e.RowIndex].Cells[s_str_sel_col].Value))
                {
                    if (e.RowIndex!=s_index_two)
                    {
                        if (s_index_two > -1)
                        {
                            int id_col = pIPDataSet.TMedicalService.sequenceColumn.Ordinal;
                            s_index_one = s_index_two;
                            s_index_two = e.RowIndex;
                            s_service_row = (PIPDataSet.TMedicalServiceRow)pIPDataSet.TMedicalService.Rows[s_index_two];
                            new_data[0] = s_selected_id = (long)pIPDataSet.TMedicalService.Rows[s_index_two][id_col];
                            s_service_grid.Rows[s_index_two].DefaultCellStyle.BackColor = SystemColors.Highlight;
                            s_service_grid.Rows[s_index_two].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
                            s_selected_textbox.Text = current_service_str = pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.category_nameColumn.Ordinal].ToString() + " - " +
                                pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.nameColumn.Ordinal].ToString() + " - " +
                                pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.national_idColumn.Ordinal].ToString() + " - " +
                                pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.k_factorColumn.Ordinal].ToString();
                            s_service_grid.Rows[s_index_one].DefaultCellStyle.BackColor = SystemColors.Window;
                            s_service_grid.Rows[s_index_one].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                            s_service_grid.Rows[s_index_one].Cells[s_str_sel_col].Value = false;
                            setKFactor(true);
                        }
                        else
                        {
                            int id_col = pIPDataSet.TMedicalService.sequenceColumn.Ordinal;
                            s_index_one = -1;
                            s_index_two = e.RowIndex;
                            s_service_row = (PIPDataSet.TMedicalServiceRow)pIPDataSet.TMedicalService.Rows[s_index_two];
                            new_data[0] = s_selected_id = (long)pIPDataSet.TMedicalService.Rows[s_index_two][id_col];
                            s_service_grid.Rows[s_index_two].DefaultCellStyle.BackColor = SystemColors.Highlight;
                            s_service_grid.Rows[s_index_two].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
                            s_selected_textbox.Text = current_service_str = pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.category_nameColumn.Ordinal].ToString() + " - " +
                                pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.nameColumn.Ordinal].ToString() + " - " +
                                pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.national_idColumn.Ordinal].ToString() + " - " +
                                pIPDataSet.TMedicalService.Rows[s_index_two][pIPDataSet.TMedicalService.k_factorColumn.Ordinal].ToString();
                            error_count--;
                            s_error_count--;
                            errors[0] = false;
                            setTabError(tab_enum.service, false);
                            EP_service.Clear();
                            setKFactor(true);
                        }
                    }
                }
                else if (s_index_two == e.RowIndex)
                {
                    s_service_grid.Rows[s_index_two].DefaultCellStyle.BackColor = SystemColors.Window;
                    s_service_grid.Rows[s_index_two].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    new_data[0] = s_selected_id = -1;
                    s_index_one = s_index_two = -1;
                    s_selected_textbox.Text = "";
                    if (need_to_service)
                    {
                        error_count++;
                        s_error_count++;
                        errors[0] = true;
                        EP_service.SetError(s_selected_textbox, error_text[0]);
                        setTabError(tab_enum.service, true);
                    }
                    s_service_row = null;
                    setKFactor(false);
                }
            }
        }

        private void afterServiceGridFilled()
        {
            PLGlobalFuncs.dataGridViewAfterFilling(s_service_grid, s_select_all_checkbox);
            for (int i = 0; i < s_service_grid.Rows.Count; i++)
            {
                s_service_grid.Rows[i].Cells[s_str_sel_col].Value = false;
            }
        }

        private void changeStatusOfPreviousServiceRow(int c_index_one)
        {
            if (c_index_one > -1)
            {
                s_service_grid.Rows[c_index_one].DefaultCellStyle.BackColor = SystemColors.Window;
                s_service_grid.Rows[c_index_one].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                s_service_grid.Rows[c_index_one].Cells[s_str_sel_col].Value = false;
                c_index_one = -1;
            }
        }

        private void initSCategoryComboBox()
        {
            s_categories_data = s_cat_adapter.GetAllCategories();
            PIPDataSet.TMedicalServiceCategoryRow c_first_row = s_categories_data.NewTMedicalServiceCategoryRow();
            c_first_row.id = -1;
            c_first_row.name = "--نوع خدمت پزشکی--";
            s_categories_data.Rows.InsertAt(c_first_row, 0);
            s_category_combobox.DataSource = s_categories_data;
            s_category_combobox.DisplayMember = s_categories_data.nameColumn.ColumnName;
            s_category_combobox.ValueMember = s_categories_data.idColumn.ColumnName;
            s_category_combobox.SelectedIndex = 0;
        }

        private void setKFactor(bool is_setter)
        {
            if (is_setter)
            {
                new_data[tip_k] = new_data[tpr_k] = s_service_row.k_factor;
                public_k_textbox.Text = private_k_textbox.Text = s_service_row.k_factor.ToString();
                public_k_textbox.Enabled = private_k_textbox.Enabled = false;
            }
            else
            {
                new_data[tip_k] = new_data[tpr_k] = 0.0;
                public_k_textbox.Text = private_k_textbox.Text = "0";
                public_k_textbox.Enabled = private_k_textbox.Enabled = true;
            }
        }

        #endregion Service Tab

        ///////////////////////////////////////////////////////////////////////// INFO TAB
        #region INFO Tab
        
        private void i_textbox_control_Leave(object sender, EventArgs e)//checked
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
                        i_error_count--;
                        errors[t_ind] = false;
                        t_box.BackColor = Color.White;
                        if (i_error_count == 0) { setTabError(tab_enum.service, false); }
                    }
                }
                else if (!errors[t_ind])
                {
                    error_count++;
                    i_error_count++;
                    errors[t_ind] = true;
                    t_box.BackColor = Color.Red;
                    error_providers[t_ind].SetError(t_box, error_text[t_ind]);
                    if (i_error_count == 1) { setTabError(tab_enum.service, true); }
                }
            }
            else if (Regex.IsMatch(t_text, regex[t_ind]))
            {
                new_data[t_ind] = t_text;
                if (errors[t_ind])
                {
                    error_providers[t_ind].Clear();
                    error_count--;
                    i_error_count--;
                    errors[t_ind] = false;
                    t_box.BackColor = Color.White;
                    if (i_error_count == 0) { setTabError(tab_enum.service, false); }
                }
            }
            else if (!errors[t_ind])
            {
                error_count++;
                i_error_count++;
                errors[t_ind] = true;
                t_box.BackColor = Color.Red;
                error_providers[t_ind].SetError(t_box, error_text[t_ind]);
                if (i_error_count == 1) { setTabError(tab_enum.service, true); }
            }
        }

        private void i_date_masked_Leave(object sender, EventArgs e)
        {
            MaskedTextBox m_box = (MaskedTextBox)sender;
            int m_ind = int.Parse(m_box.Tag.ToString());
            string m_text = m_box.Text;

            if (Regex.IsMatch(m_text, regex[m_ind]))
            {
                new_data[m_ind] = m_text;
                if (errors[m_ind])
                {
                    error_providers[m_ind].Clear();
                    error_count--;
                    i_error_count--;
                    errors[m_ind] = false;
                    m_box.BackColor = Color.White;
                    if (i_error_count == 0) { setTabError(tab_enum.info, false); }
                }
            }
            else if ((m_text == "____/__/__") && (allow_null[m_ind] || (form_operation == PLConstants.enum_data_operation.batch_edit) || (form_operation == PLConstants.enum_data_operation.batch_copy)))
            {
                new_data[m_ind] = null;
                if (errors[m_ind])
                {
                    error_providers[m_ind].Clear();
                    error_count--;
                    i_error_count--;
                    errors[m_ind] = false;
                    m_box.BackColor = Color.White;
                    if (i_error_count == 0) { setTabError(tab_enum.info, false); }
                }
            }
            else
            {
                new_data[m_ind]=null;
                if (!errors[m_ind])
                {
                    error_count++;
                    i_error_count++;
                    errors[m_ind] = true;
                    m_box.BackColor = Color.Red;
                    error_providers[m_ind].SetError(m_box, error_text[m_ind]);
                    if (i_error_count == 1) { setTabError(tab_enum.info, true); }
                }
            }
        }

        private void i_insurance_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i_ind = int.Parse(i_insurance_combobox.Tag.ToString());
            if (i_insurance_combobox.SelectedIndex > 0)
            {
                new_data[i_ind] = i_insurance_combobox.SelectedValue;
                initInsSectorComboBox((int)new_data[i_ind]);
            }
            else
            {
                new_data[i_ind] = null;
                i_sector_combobox.DataSource = null;
            }
        }

        private void i_combobox_SelectedIndexChanged(object sender, EventArgs e)
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
                    i_error_count--;
                    errors[c_ind] = false;
                    c_box.BackColor = Color.White;
                    if (i_error_count == 0) { setTabError(tab_enum.info, false); }
                }
            }
            else
            {
                if (data_types[c_ind] == int_type) { new_data[c_ind] = -1; }
                else { new_data[c_ind] = null; }
                if ((!allow_null[c_ind])&&(!errors[c_ind]))
                {
                    error_providers[c_ind].SetError(c_box,error_text[c_ind]);
                    error_count++;
                    i_error_count++;
                    errors[c_ind] = true;
                    c_box.BackColor = Color.Red;
                    if (i_error_count == 1) { setTabError(tab_enum.info, true); }
                }
            }
        }

        private void clear_checkboxes_CheckedChanged(object sender, EventArgs e)//checked
        {
            CheckBox ch_box = (CheckBox)sender;
            int ch_ind = int.Parse(ch_box.Tag.ToString());
            if (ch_box.Checked)
            {
                if ((control_types[ch_ind] == textbox_type) && (control_types[ch_ind] == masked_type))
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

        private void initInsSectorComboBox(int selected_insurance)//checked
        {
            sec_table = sec_adapter.GetAllSectors(selected_insurance);
            PIPDataSet.TInsuranceSectorRow s_first_row = sec_table.NewTInsuranceSectorRow();
            s_first_row.id = -1;
            s_first_row.name = "--صندوق بیمه--";
            sec_table.Rows.InsertAt(s_first_row, 0);
            i_sector_combobox.DataSource = sec_table;
            i_sector_combobox.DisplayMember = sec_table.nameColumn.ColumnName;
            i_sector_combobox.ValueMember = sec_table.idColumn.ColumnName;
            i_sector_combobox.SelectedIndex = 0;
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(i_sector_combobox);
        }

        private void initInfoComboBoxes()//checked
        {
            ins_table = ins_adapter.GetAllInsurances();
            PIPDataSet.TInsuranceRow i_first_row = ins_table.NewTInsuranceRow();
            i_first_row.id = -1;
            i_first_row.name = "---شرکت بیمه---";
            ins_table.Rows.InsertAt(i_first_row, 0);
            i_insurance_combobox.DataSource = ins_table;
            i_insurance_combobox.DisplayMember = ins_table.nameColumn.ColumnName;
            i_insurance_combobox.ValueMember = ins_table.idColumn.ColumnName;
            i_insurance_combobox.SelectedIndex = 0;

            deg_table = deg_adapter.GetAllDegrees();
            PIPDataSet.TMedicineDegreeRow d_first_row = deg_table.NewTMedicineDegreeRow();
            d_first_row.id = -1;
            d_first_row.name = "--مدرک پزشکی--";
            deg_table.Rows.InsertAt(d_first_row, 0);
            i_degree_combobox.DataSource = deg_table;
            i_degree_combobox.DisplayMember = deg_table.nameColumn.ColumnName;
            i_degree_combobox.ValueMember = deg_table.idColumn.ColumnName;
            i_degree_combobox.SelectedIndex = 0;

            PLGlobalFuncs.adjustDropDownWidthOfComboBox(i_insurance_combobox);
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(i_degree_combobox);
        }

        private void setInfoTabError()
        {
            if (i_error_count > 0)
            {
                setTabError(tab_enum.info, true);
            }
            else
            {
                setTabError(tab_enum.info, false);
            }
        }

        #endregion INFO Tab

        ///////////////////////////////////////////////////////////////////////// K TAB
        #region k_value_tab

        private void k_search_button_Click(object sender, EventArgs e)
        {
            if (k_year_cbx.SelectedIndex > 0)
            {
                k_year=k_year_cbx.SelectedValue.ToString();
                k_public_grid.CellValueChanged -= k_public_grid_CellValueChanged;
                k_public_grid.CurrentCellDirtyStateChanged -= k_public_grid_CurrentCellDirtyStateChanged;
                k_private_grid.CellValueChanged -= k_private_grid_CellValueChanged;
                k_private_grid.CurrentCellDirtyStateChanged -= k_private_grid_CurrentCellDirtyStateChanged;
                kValueTableAdapter.FillByYear(k_value_public_table, k_year);
                k_public_grid.DataSource = k_value_public_table;
                kValueTableAdapter.FillByYear(k_value_private_table, k_year);
                k_private_grid.DataSource = k_value_private_table;
                k_pub_index = k_pri_index = -1;
            }
            else
            {
                pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_year_not_choosed);
            }
        }

        private void k_public_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (k_public_grid.Rows.Count > 0)
            {
                afterKPublicGridFilled();
                k_public_grid.CellValueChanged += k_public_grid_CellValueChanged;
                k_public_grid.CurrentCellDirtyStateChanged += k_public_grid_CurrentCellDirtyStateChanged;
                k_pub_index = -1;
            }
        }

        private void k_public_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (k_public_grid.IsCurrentCellDirty)
            {
                k_public_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void k_public_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(k_public_grid.Rows[e.RowIndex].Cells[k_str_pub_sel_col].Value))
                {
                    if (k_pub_index!=e.RowIndex)
                    {
                        if (k_pub_index > -1)
                        {
                            //k_public_grid.Rows[k_pub_index].DefaultCellStyle.BackColor = SystemColors.Window;
                            //k_public_grid.Rows[k_pub_index].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                            k_public_grid.Rows[k_pub_index].Cells[k_str_pub_sel_col].Value = false;
                        }
                        k_pub_row=(PIPDataSet.KValueRow)k_value_public_table.Rows[e.RowIndex];
                        k_pub_id = k_pub_row.id;
                        k_pub_pro_val = k_pub_row.professional_value;
                        k_pub_tec_val = k_pub_row.technical_value;
                        k_public_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                        k_public_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
                        k_pub_index = e.RowIndex;
                        setTariffPublicPrices(true);
                    }
                }
                else if (k_pub_index == e.RowIndex)
                {
                    k_public_grid.Rows[k_pub_index].DefaultCellStyle.BackColor = SystemColors.Window;
                    k_public_grid.Rows[k_pub_index].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    k_pub_index = -1;
                    k_pub_id = null;
                    setTariffPublicPrices(false);
                }
            }
        }

        private void k_private_grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (k_private_grid.Rows.Count > 0)
            {
                afterKPrivateGridFilled();
                k_private_grid.CellValueChanged += k_private_grid_CellValueChanged;
                k_private_grid.CurrentCellDirtyStateChanged += k_private_grid_CurrentCellDirtyStateChanged;
                k_pri_index = -1;
            }
        }

        private void k_private_grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (k_private_grid.IsCurrentCellDirty)
            {
                k_private_grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void k_private_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(k_private_grid.Rows[e.RowIndex].Cells[k_str_pri_sel_col].Value))
                {
                    if (k_pri_index != e.RowIndex)
                    {
                        k_pri_row = (PIPDataSet.KValueRow)k_value_private_table.Rows[e.RowIndex];
                        k_pri_id = k_pri_row.id;
                        k_pri_pro_val = k_pri_row.professional_value;
                        k_pri_tec_val = k_pri_row.technical_value;
                        k_private_grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;
                        k_private_grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = SystemColors.HighlightText;
                        if (k_pri_index > -1)
                        {
                            k_private_grid.Rows[k_pri_index].DefaultCellStyle.BackColor = SystemColors.Window;
                            k_private_grid.Rows[k_pri_index].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                        }
                        k_pri_index = e.RowIndex;
                        setTariffPrivatePrices(true);
                    }
                }
                else if (k_pri_index == e.RowIndex)
                {
                    k_private_grid.Rows[k_pri_index].DefaultCellStyle.BackColor = SystemColors.Window;
                    k_private_grid.Rows[k_pri_index].DefaultCellStyle.ForeColor = SystemColors.ControlText;
                    k_pri_index = -1;
                    k_pri_id = null;
                    setTariffPrivatePrices(false);
                }
            }
        }

        private void initKYearComboBox()
        {
            PLGlobalFuncs.yearsForComboBox(k_year_cbx);
            PLGlobalFuncs.adjustDropDownWidthOfComboBox(k_year_cbx);
        }

        private void afterKPublicGridFilled()
        {
            PLGlobalFuncs.dataGridViewAfterFilling(k_public_grid, k_pub_select_all_chk);
            for (int i = 0; i < k_public_grid.Rows.Count; i++)
            {
                k_public_grid.Rows[i].Cells[k_str_pub_sel_col].Value = false;
            }
        }

        private void afterKPrivateGridFilled()
        {
            PLGlobalFuncs.dataGridViewAfterFilling(k_private_grid, k_pri_select_all_chk);
            for (int i = 0; i < k_private_grid.Rows.Count; i++)
            {
                k_private_grid.Rows[i].Cells[k_str_pri_sel_col].Value = false;
            }
        }

        private void setTariffPublicPrices(bool is_setter)
        {
            if (is_setter)
            {
                if (s_service_row != null)
                {
                    new_data[tip_tot] = (int)((s_service_row.professional_k * k_pub_pro_val) + (s_service_row.technical_k * k_pub_tec_val));
                    tariff_textbox_Enter(public_total_textbox, new EventArgs());
                    public_total_textbox_Leave(public_total_textbox, new EventArgs());
                    //public_total_textbox.Text = ((int)new_data[tip_tot]).ToString("N0");
                    public_total_textbox.Enabled = false;
                    if (k_pri_index > -1) { k_auto_vals = true; }
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_service_for_tariff);
                }
            }
            else
            {
                new_data[tip_tot] = 0;
                tariff_textbox_Enter(public_total_textbox, new EventArgs());
                public_total_textbox_Leave(public_total_textbox, new EventArgs());
                public_total_textbox.Enabled = true;
                k_auto_vals = false;
            }
            allowInsPatBoxes();
        }

        private void setTariffPrivatePrices(bool is_setter)
        {
            if (is_setter)
            {
                if (s_service_row != null)
                {
                    new_data[tpr_tot] = (int)((s_service_row.professional_k * k_pri_pro_val) + (s_service_row.technical_k * k_pri_tec_val));
                    tariff_textbox_Enter(private_total_textbox, new EventArgs());
                    private_total_textbox_Leave(private_total_textbox, new EventArgs());
                    //private_total_textbox.Text = ((int)new_data[tpr_tot]).ToString("N0");
                    private_total_textbox.Enabled = false;
                    if (k_pub_index > -1) { k_auto_vals = true; }
                }
                else
                {
                    pgs_dialog.singleMessage(PLConstants.enum_dialog_types.error, PLConstants.error_choose_one_service_for_tariff);
                }
            }
            else
            {
                new_data[tpr_tot] = 0;
                tariff_textbox_Enter(private_total_textbox, new EventArgs());
                private_total_textbox_Leave(private_total_textbox, new EventArgs());
                private_total_textbox.Enabled = true;
                k_auto_vals = false;
            }
            allowInsPatBoxes();
        }

        private void allowInsPatBoxes()
        {
            public_ins_sha_textbox.Enabled = public_pat_sha_textbox.Enabled =
                private_ins_sha_textbox.Enabled = private_pat_sha_textbox.Enabled = !k_auto_vals;
            private_pat_per_textbox.Enabled = private_ins_per_textbox.Enabled = !k_auto_vals;
        }
        
        #endregion
        
        ///////////////////////////////////////////////////////////////////////// TARIFF TAB
        #region tariff_tab

        int t_ind;
        string t_str;
        TextBox t_box;
        bool t_has_point;
        int t_after_point_len;
        string t_double_str;
        string t_int_str;
        double t_val = 0f;

        private void tariff_textbox_Enter(object sender, EventArgs e)
        {
            t_box = (TextBox)sender;
            t_ind=int.Parse(t_box.Tag.ToString());
            if (new_data[t_ind] != null)
            {
                t_str = new_data[t_ind].ToString();

                if (data_types[t_ind] == int_type)
                {
                    t_val = (int)new_data[t_ind];
                    t_has_point = false;
                    t_after_point_len = 0;
                    t_int_str = new_data[t_ind].ToString();
                    t_double_str = "";
                    t_box.Text = t_val.ToString("N0");
                }
                else
                {
                    t_val = Convert.ToDouble(new_data[t_ind]);
                    if ((t_val % 1) == 0)
                    {
                        t_int_str = ((int)t_val).ToString();
                        t_double_str = "";
                    }
                    else
                    {
                        //string[] ajib = (Math.Round(t_val,2).ToString()).Split(new char[] { '.' });
                        string[] ajib = (t_val.ToString()).Split(new char[] { '.' });
                        t_int_str = ajib[0];
                        t_double_str = ajib[1];
                    }
                    t_has_point = (t_double_str.Length == 0) ? false : true;
                    t_after_point_len = t_double_str.Length;
                    t_box.Text = t_val.ToString("N" + t_after_point_len);
                }
            }
            else
            {
                t_int_str = "0";
                t_double_str = "";
                t_box.Text = t_int_str;
            }
            t_box.Select();
            t_box.SelectionStart = t_box.Text.Length;
            t_box.SelectionLength = 0;
        }

        private void tariff_int_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = true;
                t_int_str = t_int_str.Remove(t_int_str.Length - 1);
                if (t_int_str == "") { t_int_str = "0"; }
                t_str = t_int_str;
                t_box.Text = (int.Parse(t_int_str)).ToString("N0");
                t_box.SelectionStart = t_box.Text.Length;
                t_box.SelectionLength = 0;
            }
            else if (e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = false;
            }
            else if (t_box.Text.Length < t_box.MaxLength)
            {
                e.Handled = true;
                if (Char.IsDigit(e.KeyChar))
                {
                    t_int_str = (t_int_str == "0") ? e.KeyChar.ToString() : t_int_str + e.KeyChar;
                    t_str = t_int_str;
                    t_box.Text = (int.Parse(t_int_str)).ToString("N0");
                }
            }
        }

        private void tariff_float_textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = true;
                if (!t_has_point)
                {
                    t_int_str = t_int_str.Remove(t_int_str.Length - 1);
                    if (t_int_str == "") { t_int_str = "0"; }
                    t_str = t_int_str;
                    t_box.Text = (double.Parse(t_int_str)).ToString("N0");
                }
                else if (t_after_point_len < 2)
                {
                    t_has_point = false;
                    t_after_point_len = 0;
                    t_double_str = "";
                    t_str = t_int_str;
                    t_box.Text = (double.Parse(t_int_str)).ToString("N0");
                }
                else
                {
                    t_after_point_len--;
                    t_double_str = t_double_str.Remove(t_double_str.Length - 1);
                    t_str = t_int_str + '.' + t_double_str;
                    t_box.Text = (double.Parse(t_str)).ToString("N1");
                }
                t_box.SelectionStart = t_box.Text.Length;
                t_box.SelectionLength = 0;
            }
            else if (e.KeyChar == (char)Keys.Tab)
            {
                e.Handled = false;
            }
            else if (t_box.Text.Length < t_box.MaxLength)
            {
                e.Handled = true;
                if (Char.IsDigit(e.KeyChar))
                {
                    if (!t_has_point)
                    {
                        t_int_str = (t_int_str == "0") ? e.KeyChar.ToString() : t_int_str + e.KeyChar;
                        t_str = t_int_str;
                        t_box.Text = (double.Parse(t_int_str)).ToString("N0");
                    }
                    else if (t_after_point_len == 0)
                    {
                        t_after_point_len++;
                        t_double_str += e.KeyChar;
                        t_str = t_int_str + '.' + t_double_str;
                        t_box.Text = (double.Parse(t_str)).ToString("N1");
                    }
                    else if (t_after_point_len == 1)
                    {
                        t_after_point_len++;
                        t_double_str += e.KeyChar;
                        t_str = t_int_str + '.' + t_double_str;
                        t_box.Text = (double.Parse(t_str)).ToString("N2");
                    }
                }
                else if ((e.KeyChar == '.') || (e.KeyChar == '/'))
                {
                    if (!t_has_point)
                    {
                        t_has_point = true;
                        t_after_point_len = 0;
                        t_str = t_int_str;
                        t_box.Text = (double.Parse(t_int_str)).ToString("N0") + '.';
                    }
                }
            }
        }

        private void public_total_textbox_Leave(object sender, EventArgs e)
        {
            int t_tot,tot;
            if ((t_tot = int.Parse(t_int_str)) != (tot = (int)new_data[tip_tot]))
            {
                int t_pat;
                new_data[tip_tot] = t_tot;
                new_data[tip_pat_sha] = t_pat = (int)(t_tot * ((double)new_data[tip_pat_per] / 100.0));
                new_data[tip_ins_sha] = t_tot - t_pat;
                new_data[tip_dis] = 0;
                refreshPublicTextBoxes(refresh_enum.cost);
            }
            if (errors[tip_tot])
            {
                errors[tip_tot] = false;
                t_error_count--;
                error_count--;
                error_providers[tip_tot].Clear();
                setTabError(tab_enum.tariff, false);
            }
        }

        private void public_pat_sha_textbox_Leave(object sender, EventArgs e)
        {
            int t_pat, pat;
            if ((t_pat = int.Parse(t_int_str)) != (pat = (int)new_data[tip_pat_sha]))
            {
                int t_tot = (int)new_data[tip_tot];
                double t_k = (double)new_data[tip_k];
                if (t_pat >= t_tot)
                {
                    new_data[tip_pat_sha] = t_tot;
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = 0;
                    new_data[tip_pat_per] = 100f;
                    new_data[tip_ins_per] = 0f;
                }
                else
                {
                    double t_pat_per;
                    new_data[tip_pat_sha] = t_pat;
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = t_tot - t_pat;
                    new_data[tip_pat_per] = t_pat_per = (double)Math.Round((((double)(t_pat)) / t_tot) * 100f, 2);
                    new_data[tip_ins_per] = (double)Math.Round(100f - t_pat_per,2);
                }
                refreshPublicTextBoxes(refresh_enum.all);
            }
        }

        private void public_discount_textbox_Leave(object sender, EventArgs e)
        {
            int t_dis, dis;
            if ((t_dis = int.Parse(t_int_str)) != (dis = (int)new_data[tip_dis]))
            {
                int t_pat = (int)new_data[tip_pat_sha];
                if (t_dis >= t_pat)
                {
                    //new_data[tip_pat_sha] = 0;
                    new_data[tip_dis] = t_pat;
                }
                else
                {
                    //new_data[tip_pat_sha] = t_pat - t_dis;
                    new_data[tip_dis] = t_dis;
                }
                refreshPublicTextBoxes(refresh_enum.discount);
            }
        }

        private void public_ins_sha_textbox_Leave(object sender, EventArgs e)
        {
            int t_ins, ins;
            if ((t_ins = int.Parse(t_int_str)) != (ins = (int)new_data[tip_ins_sha]))
            {
                int t_tot = (int)new_data[tip_tot];
                double t_k = (double)new_data[tip_k];
                if (t_ins >= t_tot)
                {
                    new_data[tip_pat_sha] = 0;
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = t_tot;
                    new_data[tip_pat_per] = 0f;
                    new_data[tip_ins_per] = 100f;
                }
                else
                {
                    double t_ins_per;
                    new_data[tip_pat_sha] = t_tot - t_ins;
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = t_ins;
                    new_data[tip_ins_per] = t_ins_per = (double)Math.Round((((double)(t_ins)) / t_tot) * 100f, 2);
                    new_data[tip_pat_per] = 100f - t_ins_per;
                }
                refreshPublicTextBoxes(refresh_enum.all);
            }
        }

        private void public_pat_per_textbox_Leave(object sender, EventArgs e)
        {
            double t_per, per;
            if ((t_per = double.Parse(t_str)) != (per = (double)new_data[tip_pat_per]))
            {
                int t_tot = (int)new_data[tip_tot];
                double t_k = (double)new_data[tip_k];
                if (t_per >= 100.0)
                {
                    new_data[tip_pat_sha] = t_tot;
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = 0;
                    new_data[tip_pat_per] = 100f;
                    new_data[tip_ins_per] = 0f;
                }
                else
                {
                    int t_pat_sha;
                    new_data[tip_pat_sha] = t_pat_sha = (int)((t_per / 100f) * t_tot);
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = t_tot - t_pat_sha;
                    new_data[tip_pat_per] = t_per;
                    new_data[tip_ins_per] = (double)Math.Round(100f - t_per,2);
                }
                if (k_auto_vals)
                {
                    new_data[tpr_pat_sha] = ((int)new_data[tpr_tot]) - ((int)(new_data[tpr_ins_sha] = new_data[tip_ins_sha]));
                    new_data[tpr_dis] = 0;
                    new_data[tpr_pat_per] = (Convert.ToDouble(new_data[tpr_pat_sha]) / Convert.ToDouble(new_data[tpr_tot])) * 100.0;
                    new_data[tpr_ins_per] = 100.0 - (double)new_data[tpr_pat_per];
                    refreshPrivateTextBoxes(refresh_enum.all);
                }
                refreshPublicTextBoxes(refresh_enum.all);
            }
        }

        private void public_ins_per_textbox_Leave(object sender, EventArgs e)
        {
            double t_per, per;
            if ((t_per = double.Parse(t_str)) != (per = (double)new_data[tip_ins_per]))
            {
                int t_tot = (int)new_data[tip_tot];
                double t_k = (double)new_data[tip_k];
                if (t_per >= 100.0)
                {
                    new_data[tip_pat_sha] = 0;
                    new_data[tip_dis] = 0;
                    new_data[tip_ins_sha] = t_tot;
                    new_data[tip_pat_per] = 0f;
                    new_data[tip_ins_per] = 100f;
                }
                else
                {
                    int t_ins_sha;
                    new_data[tip_ins_sha] = t_ins_sha = (int)((t_per / 100f) * t_tot);
                    new_data[tip_dis] = 0;
                    new_data[tip_pat_sha] = t_tot - t_ins_sha;
                    new_data[tip_ins_per] = t_per;
                    new_data[tip_pat_per] = (double)Math.Round(100f - t_per,2);
                }
                if (k_auto_vals)
                {
                    new_data[tpr_pat_sha] = ((int)new_data[tpr_tot]) - ((int)(new_data[tpr_ins_sha] = new_data[tip_ins_sha]));
                    new_data[tpr_dis] = 0;
                    new_data[tpr_pat_per] = (Convert.ToDouble(new_data[tpr_pat_sha]) / Convert.ToDouble(new_data[tpr_tot])) * 100.0;
                    new_data[tpr_ins_per] = 100.0 - ((double)new_data[tpr_pat_per]);
                    refreshPrivateTextBoxes(refresh_enum.all);
                }
                refreshPublicTextBoxes(refresh_enum.all);
            }
        }

        private void public_k_textbox_Leave(object sender, EventArgs e)
        {
            double t_k, k;
            if ((t_k = double.Parse(t_str)) != (k = (double)new_data[tip_k]))
            {
                new_data[tip_k] = t_k;
                refreshPublicTextBoxes(refresh_enum.k);
            }
        }

        private void private_total_textbox_Leave(object sender, EventArgs e)
        {
            int t_tot, tot;
            if ((t_tot = int.Parse(t_int_str)) != (tot = (int)new_data[tpr_tot]))
            {
                int t_pat;
                new_data[tpr_tot] = t_tot;
                new_data[tpr_pat_sha] = t_pat = (int)(t_tot * ((double)new_data[tpr_pat_per] / 100f));
                new_data[tpr_ins_sha] = t_tot - t_pat;
                new_data[tpr_dis] = 0;
                refreshPrivateTextBoxes(refresh_enum.cost);
            }
        }

        private void private_pat_sha_textbox_Leave(object sender, EventArgs e)
        {
            int t_pat, pat;
            if ((t_pat = int.Parse(t_int_str)) != (pat = (int)new_data[tpr_pat_sha]))
            {
                int t_tot = (int)new_data[tpr_tot];
                double t_k = (double)new_data[tpr_k];
                if (t_pat >= t_tot)
                {
                    new_data[tpr_pat_sha] = t_tot;
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = 0;
                    new_data[tpr_pat_per] = 100f;
                    new_data[tpr_ins_per] = 0f;
                }
                else
                {
                    double t_pat_per;
                    new_data[tpr_pat_sha] = t_pat;
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = t_tot - t_pat;
                    new_data[tpr_pat_per] = t_pat_per = (double)Math.Round((((double)(t_pat)) / t_tot) * 100f, 2);
                    new_data[tpr_ins_per] = 100f - t_pat_per;
                }
                refreshPrivateTextBoxes(refresh_enum.all);
            }
        }

        private void private_discount_textbox_Leave(object sender, EventArgs e)
        {
            int t_dis, dis;
            if ((t_dis = int.Parse(t_int_str)) != (dis = (int)new_data[tpr_dis]))
            {
                int t_pat = (int)new_data[tpr_pat_sha];
                if (t_dis >= t_pat)
                {
                    //new_data[tpr_pat_sha] = 0;
                    new_data[tpr_dis] = t_pat;
                }
                else
                {
                    //new_data[tpr_pat_sha] = t_pat - t_dis;
                    new_data[tpr_dis] = t_dis;
                }
                refreshPrivateTextBoxes(refresh_enum.discount);
            }
        }

        private void private_ins_sha_textbox_Leave(object sender, EventArgs e)
        {
            int t_ins, ins;
            if ((t_ins = int.Parse(t_int_str)) != (ins = (int)new_data[tpr_ins_sha]))
            {
                int t_tot = (int)new_data[tpr_tot];
                double t_k = (double)new_data[tpr_k];
                if (t_ins >= t_tot)
                {
                    new_data[tpr_pat_sha] = 0;
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = t_tot;
                    new_data[tpr_pat_per] = 0f;
                    new_data[tpr_ins_per] = 100f;
                }
                else
                {
                    double t_ins_per;
                    new_data[tpr_pat_sha] = t_tot - t_ins;
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = t_ins;
                    new_data[tpr_ins_per] = t_ins_per = (double)Math.Round((((double)(t_ins)) / t_tot) * 100f, 2);
                    new_data[tpr_pat_per] = 100f - t_ins_per;
                }
                refreshPrivateTextBoxes(refresh_enum.all);
            }
        }

        private void private_pat_per_textbox_Leave(object sender, EventArgs e)
        {
            double t_per, per;
            if ((t_per = double.Parse(t_str)) != (per = Convert.ToDouble(new_data[tpr_pat_per])))
            {
                int t_tot = (int)new_data[tpr_tot];
                double t_k = (double)new_data[tpr_k];
                if (t_per >= 100.0)
                {
                    new_data[tpr_pat_sha] = t_tot;
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = 0;
                    new_data[tpr_pat_per] = 100f;
                    new_data[tpr_ins_per] = 0f;
                }
                else
                {
                    int t_pat_sha;
                    new_data[tpr_pat_sha] = t_pat_sha = (int)((t_per / 100f) * t_tot);
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = t_tot - t_pat_sha;
                    new_data[tpr_pat_per] = t_per;
                    new_data[tpr_ins_per] = (double)Math.Round(100f - t_per,2);
                }
                refreshPrivateTextBoxes(refresh_enum.all);
            }
        }

        private void private_ins_per_textbox_Leave(object sender, EventArgs e)
        {
            double t_per, per;
            if ((t_per = double.Parse(t_str)) != (per = Convert.ToDouble(new_data[tpr_ins_per])))
            {
                int t_tot = (int)new_data[tpr_tot];
                double t_k = (double)new_data[tpr_k];
                if (t_per >= 100.0)
                {
                    new_data[tpr_pat_sha] = 0;
                    new_data[tpr_dis] = 0;
                    new_data[tpr_ins_sha] = t_tot;
                    new_data[tpr_pat_per] = 0f;
                    new_data[tpr_ins_per] = 100f;
                }
                else
                {
                    int t_ins_sha;
                    new_data[tpr_ins_sha] = t_ins_sha = (int)((t_per / 100f) * t_tot);
                    new_data[tpr_dis] = 0;
                    new_data[tpr_pat_sha] = t_tot - t_ins_sha;
                    new_data[tpr_ins_per] = t_per;
                    new_data[tpr_pat_per] = (double)Math.Round(100f - t_per,2);
                }
                refreshPrivateTextBoxes(refresh_enum.all);
            }
        }

        private void private_k_textbox_Leave(object sender, EventArgs e)
        {
            double t_k, k;
            if ((t_k = double.Parse(t_str)) != (k = (double)new_data[tpr_k]))
            {
                new_data[tpr_k] = t_k;
                refreshPrivateTextBoxes(refresh_enum.k);
            }
        }

        private void refreshPublicTextBoxes(refresh_enum refresh_zone)
        {
            switch (refresh_zone)
            {
                case refresh_enum.all:
                    public_pat_sha_textbox.Text = ((int)new_data[tip_pat_sha]).ToString("N0");
                    public_ins_sha_textbox.Text = ((int)new_data[tip_ins_sha]).ToString("N0");
                    public_discount_textbox.Text = ((int)new_data[tip_dis]).ToString("N0");
                    public_pat_per_textbox.Text = ((double)new_data[tip_pat_per]).ToString("N2");
                    public_ins_per_textbox.Text = ((double)new_data[tip_ins_per]).ToString("N2");
                    break;
                case refresh_enum.cost:
                    public_pat_sha_textbox.Text = ((int)new_data[tip_pat_sha]).ToString("N0");
                    public_ins_sha_textbox.Text = ((int)new_data[tip_ins_sha]).ToString("N0");
                    public_discount_textbox.Text = ((int)new_data[tip_dis]).ToString("N0");
                    break;
                case refresh_enum.discount:
                    public_pat_sha_textbox.Text = ((int)new_data[tip_pat_sha]).ToString("N0");
                    public_discount_textbox.Text = ((int)new_data[tip_dis]).ToString("N0");
                    break;
                case refresh_enum.k:
                    break;
            }
        }

        private void refreshPrivateTextBoxes(refresh_enum refresh_zone)
        {
            switch (refresh_zone)
            {
                case refresh_enum.all:
                    private_pat_sha_textbox.Text = ((int)new_data[tpr_pat_sha]).ToString("N0");
                    private_ins_sha_textbox.Text = ((int)new_data[tpr_ins_sha]).ToString("N0");
                    private_discount_textbox.Text = ((int)new_data[tpr_dis]).ToString("N0");
                    private_pat_per_textbox.Text = Convert.ToDouble(new_data[tpr_pat_per]).ToString("N2");
                    private_ins_per_textbox.Text = Convert.ToDouble(new_data[tpr_ins_per]).ToString("N2");
                    break;
                case refresh_enum.cost:
                    private_pat_sha_textbox.Text = ((int)new_data[tpr_pat_sha]).ToString("N0");
                    private_ins_sha_textbox.Text = ((int)new_data[tpr_ins_sha]).ToString("N0");
                    private_discount_textbox.Text = ((int)new_data[tpr_dis]).ToString("N0");
                    break;
                case refresh_enum.discount:
                    private_pat_sha_textbox.Text = ((int)new_data[tpr_pat_sha]).ToString("N0");
                    private_discount_textbox.Text = ((int)new_data[tpr_dis]).ToString("N0");
                    break;
                case refresh_enum.k:
                    break;
            }
        }


        #endregion tariff_tab

    }
}
