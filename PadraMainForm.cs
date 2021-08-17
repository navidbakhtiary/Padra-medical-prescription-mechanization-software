using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace PadraInsurancePrescription
{
    public partial class PadraMainForm : Form
    {
        Dictionary<string, Type> dict_user_controls;
        Dictionary<string,TabPage> dict_tab_items;
        List<PictureBox> list_close_buttons;
        List<Label> list_labels;
        int items_count=0;

        TabPage searched_tab;
        Label searched_label;
        string temp_key;
        ToolStripMenuItem temp_menu_item;
        Type temp_type;

        Label active_label;
        string active_key;
        int active_index;

        Font normal_font;
        Font selected_font;
        string normal_font_name = "B Roya";

        PrescriptionSubmitForm pres_submit_form;
        PrescriptionEvaluateForm pres_evaluate_form;
        PrescriptionReportForm pres_report_form;
        LoginForm owner_form;

        public PadraMainForm(LoginForm owner_form)
        {
            InitializeComponent();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("fa-IR"));
            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.main);
            //this.user_row = user_row;
            this.owner_form = owner_form;
            //system_user = new DLSystemUser(user_row.user_code, user_row.user_name, user_row.name, user_row.family_name);
            setVisibilityOfItemsBasedOnAccessLevels();

            //this.Text = this.Text + "     کاربر : " + user_row.name + " " + user_row.family_name;
            this.Text = this.Text + "     کاربر : " + PLConstants.UserText;

            dict_tab_items = new Dictionary<string, TabPage>();
            list_close_buttons = new List<PictureBox>();
            list_labels = new List<Label>();
            items_tableLayout.HorizontalScroll.Enabled = false;
            items_tableLayout.HorizontalScroll.Visible = false;

            normal_font = new Font(new FontFamily(normal_font_name), 12F, FontStyle.Regular);
            selected_font = new Font(new FontFamily(normal_font_name), 12F, FontStyle.Bold);

            dict_user_controls = new Dictionary<string, Type>();

            /////////////////////////////////////////////////// PUBLIC INFO
            dict_user_controls.Add(men_1_province_city.Name,typeof(ProvinceCityControl));
            dict_user_controls.Add(men_1_clinic_types.Name, typeof(int));
            dict_user_controls.Add(men_1_clinic_parts.Name, typeof(ClinicPartControl));
            dict_user_controls.Add(men_1_field.Name, typeof(MedicineFieldControl));
            dict_user_controls.Add(men_1_degree.Name, typeof(MedicineDegreeControl));

            /////////////////////////////////////////////////// DOCTOR
            dict_user_controls.Add(men_1_doctors.Name, typeof(DoctorControl));

            /////////////////////////////////////////////////// CENTER
            dict_user_controls.Add(men_1_centers.Name, typeof(MedicalCenterControl));
            dict_user_controls.Add(men_1_center_parts.Name, typeof(MedicalCenterPartControl));
            dict_user_controls.Add(men_1_center_doctors.Name, typeof(MedicalCenterDoctorControl));
            dict_user_controls.Add(men_1_center_tariffs.Name, typeof(MedicalCenterTariffControl));
            dict_user_controls.Add(men_1_center_contracts.Name, typeof(MedicalCenterContractControl));
            dict_user_controls.Add(men_1_export_centers.Name, typeof(ExportCentersDataControl));
            dict_user_controls.Add(men_1_import_centers.Name, typeof(ImportCentersDataControl));

            /////////////////////////////////////////////////// INSURANCE
            dict_user_controls.Add(men_1_insurances.Name, typeof(InsuranceControl));
            dict_user_controls.Add(men_1_sectors.Name, typeof(InsuranceSectorControl));

            /////////////////////////////////////////////////// SERVICE
            dict_user_controls.Add(men_1_sevices.Name, typeof(MedicalServiceControl));
            dict_user_controls.Add(men_1_multiple_services.Name, typeof(int));
            dict_user_controls.Add(men_1_tariffs.Name, typeof(MedicalServiceTariffControl));

            /////////////////////////////////////////////////// INSURED
            dict_user_controls.Add(men_1_insured_info.Name, typeof(InsuredControl));
            dict_user_controls.Add(men_1_insured_import.Name, typeof(ImportInsuredsDataControl));
            dict_user_controls.Add(men_1_insured_export.Name, typeof(ExportInsuredsDataControl));

            /////////////////////////////////////////////////// PRESCRIPTION
            dict_user_controls.Add(men_1_pres_search.Name, typeof(SearchPrescriptionControl));
            dict_user_controls.Add(men_1_import_preses.Name, typeof(ImportPrescriptionsDataControl));
            dict_user_controls.Add(men_1_export_preses.Name, typeof(ExportPrescriptionsDataControl));

            /////////////////////////////////////////////////// Statistics
            dict_user_controls.Add(men_1_pres_stats.Name, typeof(PrescriptionsStatisticsControl));

            /////////////////////////////////////////////////// SYSTEM
            dict_user_controls.Add(men_1_users.Name, typeof(int));
            dict_user_controls.Add(men_1_users_accesibility.Name, typeof(int));
            dict_user_controls.Add(men_1_preses_permissions.Name, typeof(UserPrescriptionPermissionControl));

            /////////////////////////////////////////////////// SETTINGS
            dict_user_controls.Add(men_1_pres_params.Name, typeof(PresDataParametersControl));

        }

        private void PadraMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PGSDialog pgs_dialog = new PGSDialog();
            pgs_dialog.singleMessage(PLConstants.enum_dialog_types.notice, PLConstants.notice_backup_waiting);
            string backup_result = "";
            PIPDataSetTableAdapters.BackupTableAdapter b_ta = new PIPDataSetTableAdapters.BackupTableAdapter();
            b_ta.CreateBackupOfDB(new PIPDataSet.BackupDataTable(), ref backup_result);
            pgs_dialog.operationResult(PLEnumFuncs.opResultToEnum(backup_result), PLConstants.enum_information_part.other);
            owner_form.Close();
        }

        private void setVisibilityOfItemsBasedOnAccessLevels()
        {
            //throw new NotImplementedException();
        }
        
        private void addNewTab(string title_text,string new_key,UserControl user_control)
        {
            items_count++;
            int tab_count=items_count;
            Label new_lbl=new Label();
            new_lbl.Text=title_text;
            new_lbl.TextAlign=ContentAlignment.MiddleCenter;
            new_lbl.Click+=item_lbl_Click;
            new_lbl.Tag = new_key;
            new_lbl.Dock=DockStyle.Fill;
            new_lbl.AutoSize = true;
            new_lbl.Width = (int)(items_tableLayout.Width * 0.85);
            new_lbl.Margin = new Padding(0, 3, 3, 3);
            list_labels.Add(new_lbl);
            
            PictureBox close_btn = new PictureBox();
            close_btn.Image = Properties.Resources.close_icon_small;
            close_btn.Size = new Size(20, 30);
            close_btn.Margin = new Padding(3);
            close_btn.SizeMode = PictureBoxSizeMode.StretchImage;
            close_btn.Cursor = Cursors.Hand;
            close_btn.Click += close_btn_Click;
            close_btn.Tag = new_key;
            close_btn.Dock=DockStyle.Fill;
            list_close_buttons.Add(close_btn);

            items_tableLayout.Size = new Size(items_tableLayout.Size.Width, items_tableLayout.Size.Height + new_lbl.Height + 10);
            items_tableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            items_tableLayout.Controls.Add(new_lbl, 0, items_count );
            items_tableLayout.Controls.Add(close_btn, 1, items_count );
            items_tableLayout.RowCount++;

            TabPage new_tab = new TabPage();
            main_tabControl.TabPages.Add(new_tab);
            new_tab.AutoScroll = true;
            new_tab.BackColor = Color.WhiteSmoke;
            user_control.Location = new Point(new_tab.Size.Width - user_control.Width - 15, 15);
            new_tab.Controls.Add(user_control);
            dict_tab_items.Add(new_key, new_tab);
            //items_count++;

            selectLastItem(new_key);
        }

        private void item_lbl_Click(object sender, System.EventArgs e)
        {
            searched_label=(Label)sender;
            if (active_label != searched_label)
            {
                selectAnotherItemByKey(searched_label.Tag.ToString());
            }
        }

        private void close_btn_Click(object sender, System.EventArgs e)
        {
            temp_key = ((PictureBox)sender).Tag.ToString();
            TabPage sel_tab_for_close;
            dict_tab_items.TryGetValue(temp_key, out sel_tab_for_close);
            int ind = main_tabControl.TabPages.IndexOf(sel_tab_for_close);
            int new_ind=-1;
            if (active_index == ind)
            {
                if (ind == items_count - 1)
                {
                    if (items_count > 1)
                    {
                        new_ind = ind - 1;
                    }
                    else
                    {
                        new_ind = -1;
                    }
                }
                else
                {
                    new_ind = ind + 1;
                }
            }
            else if (active_index > ind)
            {
                active_index--;
            }
            selectAnotherItemByIndex(new_ind);
            items_tableLayout.Size = new Size(items_tableLayout.Size.Width, items_tableLayout.Size.Height - list_labels[ind].Height+5);
            list_labels.RemoveAt(ind);//remove label of index
            list_close_buttons.RemoveAt(ind);//remove btn of index
            items_tableLayout.Controls.RemoveAt((ind * 2) + 1);//remove close_btn-first remove for shift of controls to the start of controls
            items_tableLayout.Controls.RemoveAt(ind * 2);//remove label-second remove
            dict_tab_items.Remove(temp_key);
            main_tabControl.TabPages.RemoveAt(ind);//remove tabpage of index
            items_count--;
            for (int i = ind; i < items_count; i++)//controls of ind are removed-later controls shift to ind-ind include ind+1 control
            {
                items_tableLayout.SetRow(list_labels[i], i + 1);
                items_tableLayout.SetRow(list_close_buttons[i], i + 1);
            }
            items_tableLayout.RowStyles.RemoveAt(items_count + 1);//now (row_count=items_count+2) then (last row has index items_count+1) 
            items_tableLayout.RowCount--;
            //MessageBox.Show(items_tableLayout.GetRow(list_labels[items_count - 1]).ToString());
        }

        private void selectAnotherItemByIndex(int new_ind)
        {
            if (new_ind>-1)
            {
                list_labels[new_ind].Font = selected_font;
                list_labels[new_ind].BackColor = Color.Violet;
                active_label = list_labels[new_ind];
                active_key = list_labels[new_ind].Tag.ToString();
                main_tabControl.SelectedIndex = active_index = new_ind;
            }
        }

        private void selectAnotherItemByKey(string new_sel_key)
        {
            if (active_key != new_sel_key)
            {
                dict_tab_items.TryGetValue(new_sel_key, out searched_tab);
                int ind = main_tabControl.TabPages.IndexOf(searched_tab);
                if (items_count > 1)
                {
                    active_label.Font = normal_font;
                    active_label.BackColor = Color.White;
                    active_label = list_labels[ind];
                    active_label.Font = selected_font;
                    active_label.BackColor = Color.Violet;
                    active_key = new_sel_key;
                    main_tabControl.SelectedIndex = active_index = ind;
                }
                //else
                //{
                //    active_label = new_lbl;
                //    active_label.Font = selected_font;
                //    active_label.BackColor = Color.Violet;
                //    active_key = new_sel_key;
                //    main_tabControl.SelectedIndex = active_index =1;
                //}
            }
        }

        private void selectLastItem(string new_sel_key)
        {
            int ind = items_count - 1;
            if ((ind > 0) && (items_count > 1))
            {
                active_label.Font = normal_font;
                active_label.BackColor = Color.White;
            }
            active_label = list_labels[ind];
            active_label.Font = selected_font;
            active_label.BackColor = Color.Violet;
            active_key = new_sel_key;
            main_tabControl.SelectedIndex = active_index = ind;
        }

        ////////////////////////////////////////////////////////////////////////// menu 
       
        private void men_1_items_Click(object sender, System.EventArgs e)
        {
            temp_menu_item = (ToolStripMenuItem)sender;
            temp_key = temp_menu_item.Name;
            if (dict_tab_items.TryGetValue(temp_key, out searched_tab))
            {
                selectAnotherItemByKey(temp_key);
            }
            else
            {
                dict_user_controls.TryGetValue(temp_key, out temp_type);
                addNewTab(temp_menu_item.Text, temp_key, (UserControl)Activator.CreateInstance(temp_type));
            }
        }

        private void men_1_items_Click_sendUserVer(object sender, System.EventArgs e)
        {

        }

        private void men_1_pres_submit_Click(object sender, EventArgs e)
        {
            if (pres_submit_form == null)
            {
                pres_submit_form = new PrescriptionSubmitForm();
                pres_submit_form.ShowDialog();
            }
            else
            {
                pres_submit_form.ShowDialog();
            }
        }

        private void men_1_pres_evaluate_Click(object sender, EventArgs e)
        {
            if (pres_evaluate_form == null)
            {
                pres_evaluate_form = new PrescriptionEvaluateForm();
                pres_evaluate_form.ShowDialog();
            }
            else
            {
                pres_evaluate_form.ShowDialog();
            }
        }

        private void men_1_pres_report_Click(object sender, EventArgs e)
        {
            if (pres_report_form == null)
            {
                pres_report_form = new PrescriptionReportForm();
                pres_report_form.ShowDialog();
            }
            else
            {
                pres_report_form.ShowDialog();
            }
        }

        private void men_about_Click(object sender, EventArgs e)
        {
            AboutPadraForm about = new AboutPadraForm();
            about.ShowDialog();
        }
    }
}
