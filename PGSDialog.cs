using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public partial class PGSDialog : Form
    {
        UserControl owner_control;
        Form owner_form;
        
        public PLConstants.enum_dialog_options user_choice;

        public PGSDialog()
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);
        }

        public PGSDialog(UserControl owner)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            owner_control = owner;
        }

        public PGSDialog(Form owner)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            owner_form = owner;
        }

        public PGSDialog(UserControl owner, PLConstants.enum_dialog_types type, List<string> message)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            owner_control = owner;
            switch (type)
            {
                case PLConstants.enum_dialog_types.error:
                    this.Text = "خطا";
                    ok_button.Visible = true;
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    break;
                case PLConstants.enum_dialog_types.save_edit:
                    this.Text = "ذخیرۀ تغییرات اطلاعات";
                    yes_button.Visible = no_button.Visible = cancel_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.edit_icon;
                    break;
                case PLConstants.enum_dialog_types.save_new:
                    this.Text = "ذخیرۀ اطلاعات جدید";
                    yes_button.Visible = no_button.Visible = cancel_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.new_icon;
                    break;
                case PLConstants.enum_dialog_types.delete:
                    this.Text = "حذف اطلاعات";
                    yes_button.Visible = no_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.delete_icon;
                    break;
                case PLConstants.enum_dialog_types.notice:
                    this.Text = "توجه";
                    ok_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.notice_icon;
                    break;
                case PLConstants.enum_dialog_types.warning:
                    this.Text = "هشدار";
                    ok_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.warning_icon;
                    break;
            }
            message_box.Lines = message.ToArray();
        }

        public PGSDialog(UserControl owner, PLConstants.enum_dialog_types type, string message)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            owner_control = owner;
            switch (type)
            {
                case PLConstants.enum_dialog_types.error:
                    this.Text = "خطا";
                    ok_button.Visible = true;
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    break;
                case PLConstants.enum_dialog_types.save_edit:
                    this.Text = "ذخیرۀ تغییرات اطلاعات";
                    yes_button.Visible = no_button.Visible = cancel_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.edit_icon;
                    break;
                case PLConstants.enum_dialog_types.save_new:
                    this.Text = "ذخیرۀ اطلاعات جدید";
                    yes_button.Visible = no_button.Visible = cancel_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.new_icon;
                    break;
                case PLConstants.enum_dialog_types.delete:
                    this.Text = "حذف اطلاعات";
                    yes_button.Visible = no_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.delete_icon;
                    break;
                case PLConstants.enum_dialog_types.notice:
                    this.Text = "توجه";
                    ok_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.notice_icon;
                    break;
                case PLConstants.enum_dialog_types.warning:
                    this.Text = "هشدار";
                    ok_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.warning_icon;
                    break;
            }
            message_box.Text = message;
        }

        public PGSDialog(PLConstants.enum_dialog_types type, string message)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            switch (type)
            {
                case PLConstants.enum_dialog_types.error:
                    this.Text = "خطا";
                    ok_button.Visible = true;
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    break;
                case PLConstants.enum_dialog_types.save_edit:
                    this.Text = "ذخیرۀ تغییرات اطلاعات";
                    yes_button.Visible = no_button.Visible = cancel_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.edit_icon;
                    break;
                case PLConstants.enum_dialog_types.save_new:
                    this.Text = "ذخیرۀ اطلاعات جدید";
                    yes_button.Visible = no_button.Visible = cancel_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.new_icon;
                    break;
                case PLConstants.enum_dialog_types.delete:
                    this.Text = "حذف اطلاعات";
                    yes_button.Visible = no_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.delete_icon;
                    break;
                case PLConstants.enum_dialog_types.notice:
                    this.Text = "توجه";
                    ok_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.notice_icon;
                    break;
                case PLConstants.enum_dialog_types.warning:
                    this.Text = "هشدار";
                    ok_button.Visible = true;
                    icon_picturebox.Image = Properties.Resources.warning_icon;
                    break;
            }
            message_box.Text = message;
        }

        public PGSDialog(UserControl owner, PLConstants.enum_operation_results result,PLConstants.enum_information_part info_part)
        {
            InitializeComponent();

            PLGlobalFuncs.adjustWinFormProperties(this, PLConstants.enum_form_types.dialog);

            owner_control = owner;
            switch (result)
            {
                case PLConstants.enum_operation_results.success:
                    this.Text = "پایان عملیات";
                    icon_picturebox.Image = Properties.Resources.done_icon;
                    message_box.Text = PLConstants.op_message_success;
                    ok_button.Visible = true;
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.error:
                    this.Text = "خطا";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_message_error;
                    ok_button.Visible = true;
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.exist:
                    this.Text = "اطلاعات مشابه";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    switch (info_part)
                    {
                        case PLConstants.enum_information_part.province:
                            message_box.Text = PLConstants.op_message_province_exist;
                            break;
                    }
                    ok_button.Visible = true;
                    ok_button.Select();
                    break;
            }
        }

        public void singleMessage(PLConstants.enum_dialog_types type, string message)
        {
            switch (type)
            {
                case PLConstants.enum_dialog_types.error:
                    this.Text = "خطا";
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    break;
                case PLConstants.enum_dialog_types.save_edit:
                    this.Text = "ذخیرۀ تغییرات اطلاعات";
                    enableButtons(true, true, true, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.edit_icon;
                    break;
                case PLConstants.enum_dialog_types.save_new:
                    this.Text = "ذخیرۀ اطلاعات جدید";
                    enableButtons(true, true, true, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.new_icon;
                    break;
                case PLConstants.enum_dialog_types.delete:
                    this.Text = "حذف اطلاعات";
                    enableButtons(true, true, false, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.delete_icon;
                    break;
                case PLConstants.enum_dialog_types.notice:
                    this.Text = "توجه";
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.notice_icon;
                    break;
                case PLConstants.enum_dialog_types.warning:
                    this.Text = "هشدار";
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.warning_icon;
                    break;
                case PLConstants.enum_dialog_types.yes_no_question:
                    this.Text = "انتخاب";
                    enableButtons(true, true, false, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.question_icon;
                    break;
            }
            message_box.Text = message;
            ShowDialog();
        }

        public void multipleMessage(PLConstants.enum_dialog_types type, List<string> message)
        {
            switch (type)
            {
                case PLConstants.enum_dialog_types.error:
                    this.Text = "خطا";
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    break;
                case PLConstants.enum_dialog_types.save_edit:
                    this.Text = "ذخیرۀ تغییرات اطلاعات";
                    enableButtons(true, true, true, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.edit_icon;
                    break;
                case PLConstants.enum_dialog_types.save_new:
                    this.Text = "ذخیرۀ اطلاعات جدید";
                    enableButtons(true, true, true, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.new_icon;
                    break;
                case PLConstants.enum_dialog_types.delete:
                    this.Text = "حذف اطلاعات";
                    enableButtons(true, true, true, false);
                    yes_button.Select();
                    icon_picturebox.Image = Properties.Resources.delete_icon;
                    break;
                case PLConstants.enum_dialog_types.notice:
                    this.Text = "توجه";
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.notice_icon;
                    break;
                case PLConstants.enum_dialog_types.warning:
                    this.Text = "هشدار";
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    icon_picturebox.Image = Properties.Resources.warning_icon;
                    break;
            }
            message_box.Lines = message.ToArray();
            ShowDialog();
        }

        public void operationResult(PLConstants.enum_operation_results result, PLConstants.enum_information_part info_part)
        {
            switch (result)
            {
                case PLConstants.enum_operation_results.success:
                    this.Text = "پایان عملیات";
                    icon_picturebox.Image = Properties.Resources.done_icon;
                    message_box.Text = PLConstants.op_message_success;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.error:
                    this.Text = "خطا";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_message_error;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.exist:
                    this.Text = "اطلاعات مشابه";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    switch (info_part)
                    {
                        case PLConstants.enum_information_part.province:
                            message_box.Text = PLConstants.op_message_province_exist;
                            break;
                        case PLConstants.enum_information_part.city:
                            message_box.Text = PLConstants.op_message_city_exist;
                            break;
                        case PLConstants.enum_information_part.other:
                            message_box.Text = PLConstants.op_message_exist;
                            break;
                    }
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.subset:
                    this.Text = "دارای زیرمجموعه";
                    icon_picturebox.Image = Properties.Resources.relation_icon;
                    switch (info_part)
                    {
                        case PLConstants.enum_information_part.province:
                            message_box.Text = PLConstants.op_message_province_subset;
                            break;
                        case PLConstants.enum_information_part.city:
                            message_box.Text = PLConstants.op_message_city_subset;
                            break;
                        case PLConstants.enum_information_part.other:
                            message_box.Text = PLConstants.op_message_subset;
                            break;
                    }
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.saved_prescriptions:
                    this.Text = "دارای زیرمجموعه";
                    icon_picturebox.Image = Properties.Resources.relation_icon;
                    switch (info_part)
                    {
                        case PLConstants.enum_information_part.other:
                            message_box.Text = PLConstants.op_message_saved_prescription_in_current_sector;
                            break;
                    }
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.just_one_doctor:
                    this.Text = "دارای پزشک های ثبت شده";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    switch (info_part)
                    {
                        case PLConstants.enum_information_part.other:
                            message_box.Text = PLConstants.op_message_allow_just_one_doctor_in_center;
                            break;
                    }
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.superset:
                    this.Text = "خطای ثبت اطلاعات بالادستی";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    switch (info_part)
                    {
                        case PLConstants.enum_information_part.other:
                            message_box.Text = PLConstants.op_message_import_superset;
                            break;
                    }
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
            }
            ShowDialog();
        }

        public void prescriptionOperationResult(PLConstants.enum_prescription_results result)
        {
            switch (result)
            {
                case PLConstants.enum_prescription_results.insured_exist:
                    this.Text = "خطا در اطلاعات بیمه شده";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_inured_exist;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.pres_exist:
                    this.Text = "خطا در اطلاعات نسخه";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_pres_exist;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.service_exist:
                    this.Text = "خطا در اطلاعات خدمت ها";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_service_exist;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.subset:
                    this.Text = "خطا در اطلاعات خدمت ها";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_service_subset;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.service_not_exist:
                    this.Text = "خطا در اطلاعات خدمت ها";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_service_not_exist;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.center_doctor_error:
                    this.Text = "خطا در اطلاعات پزشک معالج";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_center_doctor;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.visit_expiration_error:
                    this.Text = "خطا در ارتباط تاریخ ویزیت و انقضا";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_visit_expiration;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.prescription_visit_error:
                    this.Text = "خطا در ارتباط تاریخ ارجاع و ویزیت";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_msg_pres_prescription_visit;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_prescription_results.error:
                    this.Text = "خطا";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.op_message_error;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
            }
            ShowDialog();
        }

        public void connectionResult(PLConstants.enum_operation_results result,string error_message)
        {
            switch (result)
            {
                case PLConstants.enum_operation_results.success:
                    this.Text = "برقراری ارتباط با بانک اطلاعاتی";
                    icon_picturebox.Image = Properties.Resources.done_icon;
                    message_box.Text = PLConstants.connection_success_message;
                    enableButtons(false, false, false, true);
                    ok_button.Select();
                    break;
                case PLConstants.enum_operation_results.error:
                    this.Text = "خطا در برقراری ارتباط با بانک اطلاعاتی";
                    icon_picturebox.Image = Properties.Resources.error_icon;
                    message_box.Text = PLConstants.connection_error_and_reset_message + "\n\n" + error_message;
                    enableButtons(true, true, false, false);
                    yes_button.Select();
                    break;
            }
            ShowDialog();
        }

        private void enableButtons(bool yes,bool no,bool cancel,bool ok)
        {
            yes_button.Visible = yes;
            no_button.Visible = no;
            cancel_button.Visible = cancel;
            ok_button.Visible = ok;
        }

        public void changeFontOfMessageBox()
        {
            message_box.Font = new System.Drawing.Font("Arial", 10);
        }

        private void yes_button_Click(object sender, EventArgs e)
        {
            user_choice = PLConstants.enum_dialog_options.yes;
            Close();
        }
        private void no_button_Click(object sender, EventArgs e)
        {
            user_choice = PLConstants.enum_dialog_options.no;
            Close();
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            user_choice = PLConstants.enum_dialog_options.cancel;
            Close();
        }
        private void ok_button_Click(object sender, EventArgs e)
        {
            user_choice = PLConstants.enum_dialog_options.ok;
            Close();
        }
    }
}
