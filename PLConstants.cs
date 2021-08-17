using System.Windows.Forms;

namespace PadraInsurancePrescription
{
    public class PLConstants
    {
        //////////////////////////////////////////////////////////////////////// User
        public static DLSystemUser system_user;
        public static DLSystemUser SYSUser
        {
            set
            {
                system_user = value;
            }
            get
            {
                return system_user;
            }
        }
        public static int UserCode
        {
            get
            {
                return system_user.user_code;
            }
        }
        public static string UserText
        {
            get
            {
                return system_user.names_str;
            }
        }
        public static string UserName
        {
            get
            {
                return system_user.user_name;
            }
        }
        ////////////////////////////////////////////////////////////////////////// App.config and Settings strings
        public static readonly string config_connection_string_name = "PIP_connectionString";
        public static readonly string config_tag_connectionStrings = "connectionStrings";
        public static readonly string config_last_folder_setting_name = "last_directory_for_saving_file";
        public static readonly string config_padra_phone_number_setting_name = "padra_phone_number";
        public static readonly string config_padra_website_setting_name = "padra_website";
        public static readonly string config_padra_title_setting_name = "padra_title";
        public static readonly string config_tag_appSettings = "appSettings";
        public static readonly string setting_connection_string_name = "PadraInsurancePrescriptionConnectionString";
        ////////////////////////////////////////////////////////////////////////// string length
        public static readonly int len_max_name = 250;
        public static readonly int len_max_multiple_names = 500;
        public static readonly int len_national_code = 10;
        public static readonly int len_max_phone_number = 100;
        public static readonly int len_max_english_title = 100;
        public static readonly int len_max_address = 1000;
        public static readonly int len_max_doctor_id = 10;
        public static readonly int len_TaminEjtemaei_pre_code = 18;
        public static readonly int len_TaminEjtemaei_page_number = 2;
        public static readonly int len_Salamat_code = 18;
        public static readonly int len_Salamat_code_part_one = 15;
        public static readonly int len_NirooMosalah_code = 10;
        public static readonly int len_KomitehEmdad_code = 16;
        public static readonly int len_min_Tejarat_code = 13;
        public static readonly int len_Tejarat_page_number = 2;
        public static readonly int len_Tejarat_other_part = 5;
        public static readonly int len_max_id_10 = 10;
        public static readonly int len_max_id_20 = 20;
        public static readonly int len_search_min_names_2 = 2;
        public static readonly int len_search_min_insured_code_3 = 3;
        ///////////////////////////////////////////////////////////////////////// char 
        public static readonly char char_let_ran_fir_sta = '\u0621';// start of first range of persian chars
        public static readonly char char_let_ran_fir_end = '\u063a';// end of first range of persian chars
        public static readonly char char_let_ran_sec_sta = '\u0641';// start of second range of persian chars
        public static readonly char char_let_ran_sec_end = '\u064a';// end of second range of persian chars
        public static readonly char char_let_pe = '\u067e';//پ
        public static readonly char char_let_che = '\u0686';//چ
        public static readonly char char_let_zhe = '\u0698';//ژ
        public static readonly char char_let_ke = '\u06a9';//ک
        public static readonly char char_let_ge = '\u06af';//گ
        public static readonly char char_let_hedonoghte = '\u06c0';//ة
        public static readonly char char_let_ye = '\u06cc';//ی
        public static readonly char char_space = (char)Keys.Space;
        public static readonly char char_slash = '/';
        public static readonly char char_dash = '-';
        public static readonly char char_underline = '_';
        ///////////////////////////////////////////////////////////////////////// string index
        public static readonly int index_TaminEjtemaei_page_number = 16;// zero based index

        ///////////////////////////////////////////////////////////////////////// strings
        public static readonly string str_empty_slash_date = new string(new char[] { char_underline, char_underline, char_underline, char_underline, char_slash, char_underline, char_underline, char_slash, char_underline, char_underline });
        public static readonly string str_empty_dash_date = new string(new char[] { char_underline, char_underline, char_underline, char_underline, char_dash, char_underline, char_underline, char_dash, char_underline, char_underline });
        public static readonly string str_clear = "@clear";
        public static readonly string str_main_table_layout_name = "main_tableLayoutPanel";
        public static readonly string str_main_tab_control_name = "main_tabControl";
        public static readonly string str_unchanged = "@unchanged";
        public static readonly string str_excel_type_filter = "Excel Files|*.xls;*.xlsx";
        public static readonly string str_excel_file_centers_dialog_title = "تعیین فایل اکسل برای انتقال اطلاعات مراکز درمانی به این کامپیوتر";
        public static readonly string str_excel_file_preses_dialog_title = "تعیین فایل اکسل برای انتقال اطلاعات نسخه ها به این کامپیوتر";
        public static readonly string str_excel_file_insureds_dialog_title = "تعیین فایل اکسل برای انتقال اطلاعات بیمه شده ها به این کامپیوتر";
        ///////////////////////////////////////////////////////////////////////// table columns str
        public static readonly string str_table_col_entity_id = "entity_id";
        public static readonly string str_table_col_service_tariff_seq = "service_tariff_seq";
        public static readonly string str_table_col_servicing_count = "servicing_count";
        public static readonly string str_table_col_month_id = "month_id";
        public static readonly string str_table_col_month_name = "month_name";
        public static readonly string str_table_col_year_id = "year_id";
        public static readonly string str_table_col_row_number = "row_number";
        public static readonly string str_table_col_ins_id = "id";
        public static readonly string str_table_col_ins_tag = "tag";
        public static readonly string str_table_col_ins_logo_image = "logo_image";
        public static readonly string str_table_insurance_col_logo_image = "logo_image";
        public static readonly string str_table_Pres_for_insurance_org = "Pres_";
        public static readonly string str_table_PresService_for_insurance_org = "PresService_";
        public static readonly string str_table_Insured_for_insurance_org = "Insured_";
        ///////////////////////////////////////////////////////////////////////// stored procedures
        public static readonly string sp_import_prescriptions_data_into_server = "import_prescriptions_data_into_server";
        public static readonly string sp_import_centers_data_into_user = "import_centers_data_into_user";
        public static readonly string sp_import_data_just_Insured = "import_data_just_Insured";
        public static readonly string sp_select_report_pres_stats_letter = "select_report_pres_stats_letter";
        ///////////////////////////////////////////////////////////////////////// backup settings
        public static readonly long backup_interval_time = (long)(1.5 * 60 * 60 * 1000);
        ////////////////////////////////////////////////////////////////////////// ints
        public static readonly int int_minus_11 = -11;
        ////////////////////////////////////////////////////////////////////////// regular expressions
        public static readonly string reg_small_name = @"^([\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|\s){0," + len_max_name.ToString() + "}$";
        public static readonly string reg_multiple_names = @"^([\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|-|\s){0," + len_max_multiple_names.ToString() + "}$";
        public static readonly string reg_name = @"^([\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|\s){1," + len_max_name.ToString() + "}$";
        public static readonly string reg_title = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|[a-z]|[A-Z]|-|\s|\.){0," + len_max_multiple_names.ToString() + "}$";
        public static readonly string reg_search_name = @"^([\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|\s){2," + len_max_name.ToString() + "}$";
        public static readonly string reg_english_title = @"^([a-z]|[A-Z]|[0-9]|_|-|\s|\.){2," + len_max_english_title.ToString() + "}$";
        public static readonly string reg_search_english_title = @"^([a-z]|[A-Z]|[0-9]|_|-|\s|\.){0," + len_max_english_title.ToString() + "}$";

        public static readonly string reg_address = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|\u0028|\u0029|-|\s|\.|\(|\)){0," + len_max_address.ToString() + "}$";
        public static readonly string reg_description = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|-|\.|\s|\(|\)|[a-z]|[A-Z]){0," + len_max_address.ToString() + "}$";
        public static readonly string reg_date_dash = "^((139[0-9]|14([0-9]{2}))-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1]))$";
        public static readonly string reg_date_slash = "^((139[0-9]|14([0-9]{2}))/(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1]))$";

        public static readonly string reg_phone = "^(([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|-){0," + len_max_phone_number.ToString() + "})$";
        
        public static readonly string reg_national_code = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){" + len_national_code.ToString() +","+(len_national_code+1).ToString()+ "}$";
        public static readonly string reg_search_id_10 = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){0," + (len_max_id_10).ToString() + "}$";
        public static readonly string reg_id = "^(([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9])+)$";
        //public static readonly string reg_medical_service_code = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){4," + (len_max_id_10).ToString() + "}$";
        public static readonly string reg_medical_service_code = "^D?([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){4," + (len_max_id_10).ToString() + "}$";
        public static readonly string reg_float_code = @"^((([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9])*)(((/|\.)(([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9])+)){0,1}))$";
        public static readonly string reg_number = "^(([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9])*)$";
        public static readonly string reg_search_insured_id = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|\u002D|\u002F){0," + len_max_id_20.ToString() + "}$";

        public static readonly string reg_doctor_medical_id = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){1,"+len_max_doctor_id.ToString()+"}$";
        public static readonly string reg_search_doctor_medical_id = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){0," + len_max_doctor_id.ToString() + "}$";

        public static readonly string reg_clinic_part_title_search = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|[a-z]|[A-Z]|-|\s|\.){0," + len_max_name.ToString() + "}$";
        public static readonly string reg_clinic_part_title = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|[a-z]|[A-Z]|-|\s|\.){2," + len_max_name.ToString() + "}$";

        public static readonly string reg_m_service_name_search = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|[a-z]|[A-Z]|-|\s|\.){0," + len_max_multiple_names.ToString() + "}$";
        public static readonly string reg_m_service_name = @"^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|[\u0621-\u063a]|[\u0641-\u064a]|\u067e|\u0686|\u0698|\u06a9|\u06af|\u06c0|\u06cc|[a-z]|[A-Z]|-|\s|\.){2," + len_max_multiple_names.ToString() + "}$";

        public static readonly string reg_pre_id_NationalCode = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){" + len_national_code.ToString() + "}$";
        public static readonly string reg_pre_id_NirooMosalah = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){" + len_national_code.ToString() +"}$";
        public static readonly string reg_pre_id_Salamat = "(^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){" +len_national_code.ToString() +"}$)|"+
                                                           "(^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){2," + len_Salamat_code_part_one.ToString() +"}(\u002D)([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){1,2}$)";
        public static readonly string reg_pre_id_TaminEjtemaei = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){" + len_TaminEjtemaei_pre_code.ToString() + "}$";
        public static readonly string reg_pre_id_KomitehEmdad = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){"+ len_KomitehEmdad_code.ToString() + "}$";
        public static readonly string reg_pre_id_Other = "^([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]|\u002D|\u002F){1," + len_max_id_20.ToString() + "}$";

        public static readonly string reg_exact_day_of_date = "^((\u0030([\u0031-\u0039]|[\u0661-\u0669]|[\u06f1-\u06f9]))|(([\u0031-\u0032]|[\u0661-\u0662]|[\u06f1-\u06f2])([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]))|((\u0033|\u0663|\u06f3)([\u0030-\u0031]|[\u0660-\u0661]|[\u06f0-\u06f1])))$";
        public static readonly string reg_exact_month_of_date = "^((\u0030([\u0031-\u0039]|[\u0661-\u0669]|[\u06f1-\u06f9]))|((\u0031|\u0661|\u06f1)([\u0030-\u0032]|[\u0660-\u0662]|[\u06f0-\u06f2])))$";
        public static readonly string reg_exact_year_of_date = "^(\u0031|\u0661|\u06f1)(((\u0033|\u0663|\u06f3)(\u0039|\u0669|\u06f9)([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]))|((\u0034|\u0664|\u06f4)([\u0030-\u0039]|[\u0660-\u0669]|[\u06f0-\u06f9]){2}))$";
        ////////////////////////////////////////////////////////////////////////// Mask for MaskedTextBox
        public static readonly string mask_doctor_id = "99999999999999999999";//20 characters maximum

        ////////////////////////////////////////////////////////////////////////// error text
        public static readonly string error_letters_only = "فقط حروف فارسی مجاز است.2 تا 250 حرف.";
        public static readonly string error_names = "فقط از حروف فارسی برای وارد کردن نام ها استفاده کنید.";
        public static readonly string error_multiple_names = "فقط از حروف فارسی برای وارد کردن نام ها استفاده کنید. برای جدا کردن نام ها از خط فاصله استفاده کنید.";
        public static readonly string error_title = "فقط از اعداد، حروف و خط فاصله برای وارد کردن عنوان استفاده کنید.";
        public static readonly string error_title_english = "فقط از اعداد، حروف انگلیسی و خط فاصله برای وارد کردن عنوان انگلیسی استفاده کنید.";
        public static readonly string error_medical_service_name = "فقط از حروف فارسی، انگلیسی، اعداد، خط فاصله و نقطه برای وارد کردن نام ها استفاده کنید.";
        public static readonly string error_id_just_number = "فقط از اعداد برای وارد کردن شناسه ها استفاده کنید.";
        public static readonly string error_id = "شناسه وارد شده نامعتبر است.";
        public static readonly string error_search_insured_id = "فقط از اعداد و خط فاصله برای وارد کردن شناسه استفاده نمایید.";
        public static readonly string error_numbers_int = "فقط از اعداد صحیح استفاده کنید.";
        public static readonly string error_numbers_float = "فقط از اعداد صحیح یا اعشاری استفاده کنید. برای اعداد اعشاری قسمت صحیح و اعشاری را به وسیله نقطه یا / از هم جدا کنید.";
        public static readonly string error_date = "تاریخ وارد شده نامعتبر است. تاریخ باید در محدوده 01/01/1390 الی 30/12/1499 باشد.";
        public static readonly string error_address = "فقط از اعداد، حروف و خط فاصله برای وارد کردن آدرس استفاده کنید.";
        public static readonly string error_description = "فقط از اعداد، حروف، خط فاصله و نقطه برای وارد کردن توضیحات استفاده کنید.";
        public static readonly string error_phone = "فقط از اعداد برای وارد کردن شماره تلفن استفاده کنید. برای جدا کردن شماره ها از خط فاصله استفاده کنید.";
        public static readonly string error_search_text_not_empty = "برای جستجو باید حداقل 2 کاراکتر وارد شود .";
        public static readonly string error_search_fields_not_empty = "برای انجام جستجو باید حداقل یکی از اطلاعات مورد جستجو وارد شوند.";
        public static readonly string error_cost_int = "فقط از اعداد صحیح برای وارد کردن هزینه ها استفاده کنید.هزینه ها باید بزرگتر از صفر باشند!";
        public static readonly string error_combo_province_not_selected = "هیچ استانی انتخاب نشده است.";
        public static readonly string error_combo_not_selected = "هیچ موردی انتخاب نشده است.";
        public static readonly string error_nothing_selected = "هیچ موردی انتخاب نشده است.حداقل یکی از موارد باید انتخاب شوند!";
        public static readonly string error_choose_one = "باید دقیقا یک مورد انتخاب شود!";
        public static readonly string error_choose_one_center = "باید دقیقا یک مرکز برای نمایش بخش های کاربر، انتخاب شود!";
        public static readonly string error_choose_at_least_center = "باید حداقل یک مرکز انتخاب شود!";
        public static readonly string error_choose_one_user = "باید دقیقا یک کاربر برای نمایش مراکز کاربر، انتخاب شود!";
        public static readonly string error_choose_one_part = "باید دقیقا یک بخش برای نمایش پزشک های مرکز، انتخاب شود!";
        public static readonly string error_choose_one_service = "باید دقیقا یک خدمت پزشکی انتخاب شود!";
        public static readonly string error_choose_at_least_services = "باید حداقل یک خدمت پزشکی انتخاب شود!";
        public static readonly string error_choose_one_service_for_tariff = "برای تعیین تعرفه به صورت خودکار باید یک خدمت پزشکی انتخاب شود!";
        public static readonly string error_has_error = "اطلاعات وارد شده نامعتبر هستند. لطفا خطاها را اصلاح کنید!";
        public static readonly string error_combo_insurance_not_selected = "هیچ سازمان بیمه گری انتخاب نشده است.";
        public static readonly string error_search_insureds_fields_not_empty = "برای انجام جستجو در اطلاعات بیمه شده ها باید حداقل 2 حرف از یکی از پارامترهای نام یا نام خانوادگی، یا حداقل 3 رقم از شماره شناسایی دفترچه بیمه شده را وارد نمایید.";
        public static readonly string error_search_pres_min_search_items_count = "برای انجام جستجو در اطلاعات بیمه شده ها باید حداقل 2 مورد از آیتم های جستجو(علاوه بر سازمان بیمه گر) مقداردهی شوند.";
        public static readonly string error_user_does_not_allow = "شما اجازه دسترسی به این عملیات/بخش را ندارید.";
        public static readonly string error_choose_checkedlistbox = "باید از هر کدام از لیست ها حداقل یک مورد انتخاب شوند !";
        public static readonly string error_create_import_export_file = "هنگام تولید فایل خطایی رخ داده است. ممکن است فایل دیگری با همین نام در حال اجرا باشد.";
        public static readonly string error_transfer_import_export_data = "هنگام انتقال اطلاعات خطایی رخ داده است. ممکن است رمز عبور وارد شده نامعتبر باشد یا فایل داده ها توسط نرم افزار دیگری در حال استفاده باشد.";
        public static readonly string error_choose_at_least_sector = "باید حداقل یک صندوق بیمه گر انتخاب شود!";
        public static readonly string error_year_month_not_choosed = ".باید ماه و سال تعیین شوند";
        public static readonly string error_year_not_choosed = ".باید سال تعیین شود";
        public static readonly string error_doctors_not_choosed = "هیچ پزشکی انتخاب نشده است!";
        public static readonly string error_not_valid = "عبارت وارد شده نامعتبر است!";
        ////////////////////////////////////////////////////////////////////////// error submit prescription 
        public static readonly string error_pres_vis_day = "روز انجام خدمت(ویزیت) تعیین نشده است!";
        public static readonly string error_pres_exp_date_less = "تاریخ اعتبار نسخه باید برابر یا بعد از تاریخ ویزیت باشد !";
        public static readonly string error_pres_page = "شماره صفحه نسخه نامعتبر است!";
        public static readonly string error_pres_fun_doctor = "پزشک انجام دهنده خدمت تعیین نشده/اشتباه است!";
        public static readonly string error_pres_prescriptor_date_greater = "تاریخ تجویز خدمت باید برابر یا قبل از تاریخ ویزیت باشد !";
        public static readonly string error_pres_service_count = "تعداد دفعات انجام خدمت نامعتبر است!";
        public static readonly string error_pres_service_code = "شناسه/شماره میانبر نا معتبر است!";
        public static readonly string error_pres_info_not_saved = "اطلاعات اصلی نسخه ثبت نشده اند. پس از ثبت اطلاعات نسخه اقدام به ثبت خدمت ها نمایید!";
        public static readonly string error_pres_no_dynamic_service = "باید حداقل یک خدمت متغیر(علاوه بر خدمت های انتخاب شده مرحله قبل) انتخاب شود!";
        public static readonly string error_pres_edit_info_no_insurance = "مرکز انتخاب شده جدید با سازمان بیمه گر فعلی قرارداد ندارد!";
        public static readonly string error_pres_service_category_not_choosed = "نوع خدمت انتخاب نشده است!";
        public static readonly string error_no_data_parameters = "پارامترهای مجاز و غیرمجاز جهت ثبت نسخه، برای این نوع از مرکز تعیین نشده اند.ابتدا باید پارامترهای مجاز تعیین شوند سپس برای ثبت نسخه اقدام شود.";
        public static readonly string error_pres_serial = "شماره سریال نسخه نامعتبر است!";
        ////////////////////////////////////////////////////////////////////////// special error text
        public static readonly string error_medical_center_not_selected = "برای جستجو باید یک مرکز درمانی انتخاب شود !";
        public static readonly string error_public_tariff = "مقدار تعرفه دولتی باید تعیین شود !";
        public static readonly string error_repetitive_service = "خدمت پزشکی تکراری(قبلا به لیست اضافه شده) انتخاب شده است!";
        public static readonly string error_service_count_zero = "تعداد دفعات انجام خدمت باید بزرگتر از صفر باشد!";
        public static readonly string error_not_static_dynamic_service = "حداقل یک خدمت به عنوان خدمت ثابت باید انتخاب گردد، در غیر اینصورت باید گزینه <نسخه ها دارای خدمت های متفاوت هستند> فعال شود!";
        public static readonly string error_not_dynamic_service = "همه خدمت ها در مرحله قبل انتخاب شده اند و هیچ خدمتی برای انتخاب به صورت پویا و متغیر وجود ندارد. به مرحله قبل بروید و گزینه<نسخه ها دارای خدمت های متفاوت هستند> را غیرفعال نمایید !";
        public static readonly string error_past_tariffs_start_date = "تاریخ شروع وارد شده برای تعرفه های گذشته مرکز نامعتبر است.باید حداقل یکی از فیلدهای روز ، ماه یا سال تعیین شوند.روز و ماه 2 رقمی و سال 4 رقمی هستند.";
        public static readonly string error_k_factors_not_matched = "باید مقدار ضریب K برابر با مجموع ضریب K حرفه ای و ضریب K فنی باشد !";
        public static readonly string error_logo_big_150KB = "حجم فایل تصویر لوگو/آرم نباید بیشتر از 150 کیلو بایت باشد !";
        public static readonly string error_edit_main_insurances = "امکان ویرایش یا حذف سازمان های بیمه ای اصلی(سلامت،تامین اجتماعی،نیروهای مسلح و کمیته امداد) وجود ندارد !";
        public static readonly string error_edit_main_ins_sectors = "امکان ویرایش یا حذف صندوق های سازمان های بیمه ای اصلی(سلامت،تامین اجتماعی،نیروهای مسلح و کمیته امداد) وجود ندارد !";
        public static readonly string error_tamin_ep_form_invalid_numbers = "مقادیر وارد شده نا معتبر هستند. باید حداقل تعداد کل نسخ و کل سهم سازمان درخواستی وارد شوند!";
        /////////////////////////////////////////////////////////////////////////// report error text
        public static readonly string error_not_ins_sector_for_report = "مرکز انتخاب شده با هیچکدام از صندوق های سازمان بیمه گر قرارداد ندارد!";
        public static readonly string error_uncompatible_letter = "نوع نامه انتخاب شده با نوع مرکز سازگار نیست!";
        public static readonly string error_uncompatible_list = "نوع فهرست انتخاب شده با نوع مرکز سازگار نیست!";
        public static readonly string error_create_report = "هنگام مقداردهی پارامترهای گزارش خطایی رخ داده است!";
        public static readonly string error_report_file_creating = "هنگام تولید فایل گزارش خطایی رخ داده است. ممکن است یکی از موارد زیر باعث بروز خطا شده باشند:\r\n" + "1-فایل های گزارش توسط سیستم یا نرم افزارهای دیگر در حال استفاده باشند.\r\n" + "2-فایل های هم نام تولید شده باشند.\r\n" + "3-نوع گزارش انتخاب شده با نوع مرکز و بخش های درمانی آن مرتبط نباشد.";
        public static readonly string error_report_folder_not_empty = "پوشه/مسیری را انتخاب کنید که دارای پوشه دیگری نباشد.";
        public static readonly string error_report_create_cd_files = " هنگام تولید فایل ها خطایی رخ داده است. ممکن است فایل یا پوشه ای هم نام با فایل های در حال تولید وجود داشته باشند.";
        public static readonly string error_report_no_parts_and_sectors = " باید حداقل یک صندوق بیمه و در صورت وجود بخش های درمانی، باید حداقل یک بخش انتخب شوند.";
        public static readonly string error_choose_one_report = "باید یکی از گزارش ها انتخاب شوند!";
        ////////////////////////////////////////////////////////////////////////// notice text
        public static readonly string notice_no_record_after_search = "موردی یافت نشد !";
        public static readonly string notice_no_record = "موردی برای نمایش وجود ندارد !";
        public static readonly string notice_no_record_medical_center_doctors = "پزشکی با این مشخصات برای این مرکز پزشکی ثبت نشده است !";
        public static readonly string notice_no_record_center_part_doctors = "هیچ پزشکی برای بخش انتخاب شده تعریف نشده است !";
        public static readonly string notice_no_center_part_for_doctor = "هیچ بخشی برای این مرکز تعریف نشده است. پزشک به خود مرکز اضافه می شود !";
        public static readonly string notice_no_center_part_for_report = "هیچ بخشی برای این مرکز تعریف نشده است.";
        public static readonly string notice_no_center_part_for_user = "مرکز انتخاب شده دارای بخش می باشد اما هیچ بخش قابل دسترسی برای کاربر تعریف نشده است.";
        public static readonly string notice_no_record_medical_center_services = "هیچ خدمتی برای این مرکز تعریف نشده است !";
        public static readonly string notice_pres_process_info_checking = "فرآیند بررسی وجود اطلاعات بیمه شده در حال انجام است، مجددا اقدام به ثبت نمایید !";
        public static readonly string notice_search_wait = "ممکن است فرآیند جستجو چند دقیقه زمان ببرد. جهت کمتر کردن این زمان از همه پارامترهای جستجو استفاده نمایید!";
        public static readonly string notice_load_wait = "ممکن است فرآیند بارگذاری داده ها چند دقیقه زمان ببرد!";
        public static readonly string notice_searched_tariffs_more_than_200 = "تعداد تعرفه های یافت شده بیشتر از 200 مورد می باشد. جهت نمایش تعرفه ها باید به وسیله ی ابزارهای جستجو، محدوده جستجو را کمتر کنید!";
        public static readonly string notice_repeat_load_data_after_changes = "به دلیل ایجاد تغییرات در اطلاعات، داده ها مجددا بارگذاری می شوند!";
        public static readonly string notice_evaluate_preses_have_not_services = "هیچ خدمتی انتخاب نشده است.نسخه هایی که هیچ خدمتی ندارند به عنوان نتیجه نمایش داده خواهند شد.این نسخه ها در هیچکدام از گزارش ها و فایل های سازمانی وجود نخواهند داشت!";
        public static readonly string notice_save_multiple_reports = "به دلیل اینکه چند گزارش تولید شده است، باید مسیری برای ذخیره همه گزارش ها تعیین شود. ممکن است فرآیند تولید گزارش ها چند دقیقه طول بکشد!";
        public static readonly string notice_run_program_again = "برنامه را مجددا اجرا نمایید.";
        public static readonly string notice_preses_sectors_services_in_choosed_grid="خدمت هایی از سایر صندوق ها، قبلا به جدول خدمات انتخاب شده، اضافه شده اند!";
        public static readonly string notice_preses_services_in_choosed_grid = "خدمت هایی قبلا به جدول خدمات انتخاب شده، اضافه شده اند!";
        public static readonly string notice_export_file_wait = "ممکن است فرآیند استخراج داده ها و تولید فایل چند دقیقه زمان ببرد!";
        public static readonly string notice_import_file_wait = "ممکن است فرآیند دریافت داده ها از فایل چند دقیقه زمان ببرد!";
        public static readonly string notice_transfer_data_wait = "ممکن است فرآیند انتقال داده ها به بانک اطلاعاتی چند دقیقه زمان ببرد!";
        public static readonly string notice_no_user_import_centers_data = "هیچ اطلاعاتی داخل بانک اطلاعاتی برای این کامپیوتر وجود ندارد. باید فایل اکسل برای انتقال اطلاعات به این کامپیوتر انتخاب شود!";
        public static readonly string notice_no_other_centers_for_comprehensive_report = "هیچ مرکز دیگری برای نمایش در گزارش جامع انتخاب نشده است. فقط اطلاعات مربوط به مرکز اصلی در گزارش نمایش داده خواهد شد !";
        public static readonly string notice_stats_report_wait = "ممکن است فرآیند تولید آمار چند دقیقه زمان ببرد!";
        public static readonly string notice_backup_waiting = "ممکن است فرآیند تولید نسخه پشتیبان چند دقیقه زمان ببرد!";
        ///////////////////////////////////////////////////////////////////////// questions
        public static readonly string question_save_edit = "آیا می خواهید اطلاعات ویرایش شوند ؟";
        public static readonly string question_save_new = "آیا می خواهید اطلاعات جدید به بانک اطلاعاتی اضافه شوند ؟";
        public static readonly string question_delete = "آیا می خواهید اطلاعات حذف شوند ؟";
        public static readonly string question_new_doctor_for_center = "آیا می خواهید پزشک های ذیل به مرکز درمانی انتخاب شده اضافه شوند ؟";
        public static readonly string question_delete_doctor_from_center = "آیا می خواهید پزشک های ذیل از مرکز درمانی انتخاب شده حذف شوند ؟";
        public static readonly string question_new_contract_for_center = "آیا می خواهید صندوق های ذیل به مرکز درمانی انتخاب شده اضافه شوند ؟";
        public static readonly string question_delete_contract_from_center = "آیا می خواهید صندوق های ذیل از مرکز درمانی انتخاب شده حذف شوند ؟";
        public static readonly string question_new_part_for_center = "آیا می خواهید بخش های ذیل به مرکز درمانی انتخاب شده اضافه شوند ؟";
        public static readonly string question_delete_part_from_center = "آیا می خواهید بخش های ذیل از مرکز درمانی انتخاب شده حذف شوند ؟";
        public static readonly string question_new_tariff_for_center = "آیا می خواهید تعرفه های ذیل به مرکز درمانی انتخاب شده اضافه شوند ؟";
        public static readonly string question_delete_tariff_from_center = "آیا می خواهید تعرفه های ذیل از مرکز درمانی انتخاب شده حذف شوند ؟";
        public static readonly string question_delete_service_from_prescription = "در صورت حذف همه خدمت های هر نسخه از نسخه های انتخاب شده، دیگر این نسخه ها در داخل گزارش های سازمانی وجود نخواهند داشت.آیا می خواهید خدمت های انتخاب شده از کلیه نسخه های مورد نظر حذف شوند؟"+"\n"+
                                                                "(در صورت تایید هر کدام از نسخه ها که دارای خدمت های انتخاب شده باشند، خدمت ها از آنها حذف می شوند)";
        public static readonly string question_edit_service_of_prescription = "آیا می خواهید خدمت های انتخاب شده در کلیه نسخه های مورد نظر ویرایش شوند؟" + "\n" +
                                                                "(در صورت تایید هر کدام از نسخه ها که دارای خدمت های انتخاب شده باشند، تعداد دفعات انجام خدمت در آنها تغییر می یابد)";
        public static readonly string question_add_service_to_prescription = "آیا می خواهید خدمت های انتخاب شده به کلیه نسخه های مورد نظر اضافه شوند؟" + "\n" +
                                                                "(در صورت تایید هر کدام از نسخه ها که خدمت های انتخاب شده را نداشته باشند، خدمت ها به آنها اضافه خواهند شد)";
        public static readonly string question_delete_all_services_from_prescription = "در صورت حذف همه خدمت های هر نسخه از نسخه های انتخاب شده، دیگر این نسخه ها در داخل گزارش های سازمانی وجود نخواهند داشت.آیا می خواهید همه خدمت های کلیه نسخه های مورد نظر حذف شوند؟";
        public static readonly string question_niroo_mosalah_cd_all_sectors_in_one_file = "اطلاعات کلیه نسخه ها و خدمت هایشان در صندوق های مختلف بیمه خدمات درمانی نیروهای مسلح در یک فایل قرار می گیرند! آیا می خواهید فایل مورد نظر تولید شود؟ ";
        public static readonly string question_insurance_cd_sectors_in_different_files = "آیا می خواهید اطلاعات نسخه های هر کدام از صندوق ها در فایل های جداگانه قرار گیرند؟ در صورت انتخاب گزینه خیر، همه اطلاعات در یک فایل ذخیره می شوند!";
        public static readonly string question_user_no_permission_with_show_errors = "بعضی از دسترسی ها به مراکز و بخش ها برای شما تعریف نشده است. آیا مایل هستید که فهرست این مراکز را مشاهده نمایید؟ ";
        public static readonly string question_show_more_100_searched_tariffs_records_for_submit = ".ممکن است نمایش تعرفه های یافت شده زمان بر باشد! آیا می خواهید تعرفه های یافت شده برای ثبت در نسخه ها استفاده شوند؟ در صورت انتخاب گزینه بله، نتایج یافت شده نمایش داده نمی شوند و تیک گزینه های (1) و (2) زده شده و به صورت خودکار مرحله بعد(ثبت نسخه ها) فعال می شود";
        public static readonly string question_show_searched_tariffs_records_for_eva_rep = ".ممکن است نمایش تعرفه های پیدا شده زمان بر باشد! آیا می خواهید تعرفه های پیدا شده استفاده شوند؟ در صورت انتخاب گزینه بله، تعرفه های پیدا شده نمایش داده نمی شوند و به صورت خودکار مرحله بعد فعال می شود";
        ///////////////////////////////////////////////////////////////////////// connection messages
        public static readonly string connection_success_message = "برقراری ارتباط با بانک اطلاعاتی با موفقیت انجام شد!";
        public static readonly string connection_error_and_reset_message = "خطایی هنگام برقراری ارتباط با بانک اطلاعاتی به وجود آمده است. آیا مایل هستید پارامترهای ارتباطی را مجددا مقداردهی نمایید؟!";
        public static readonly string connection_parameters_error_message = ".برقراری ارتباط با بانک اطلاعاتی ناموفق بود. پارامترهای ارتباطی را بر اساس مقادیر جدید مقداردهی نمایید";
        ///////////////////////////////////////////////////////////////////////// operation message
        public static readonly string op_message_success = "عملیلات با موفقیت انجام شد.";
        public static readonly string op_message_error = "خطایی در انجام عملیات اتفاق افتاده است! لطفا مجددا عملیات را تکرار کنید.";
        public static readonly string op_message_exist = "چنین اطلاعاتی قبلا ذخیره شده است.";
        
        public static readonly string op_message_province_subset = "استان ها دارای زیرمجموعه ای از شهرها هستند! ابتدا اطلاعات شهرها را اصلاح کنید سپس برای حذف اقدام کنید.";
        public static readonly string op_message_import_superset = "بعضی از اطلاعات موردنیاز ثبت نشده اند.";
        public static readonly string op_message_province_exist = "استانی با این نام قبلا ذخیره شده است.";

        public static readonly string op_message_city_subset = "از اطلاعات شهرها در سایر قسمت ها استفاده شده است! ابتدا اطلاعات سایر قسمت ها را اصلاح کنید و سپس برای حذف اقدام کنید.";
        public static readonly string op_message_subset = "از اطلاعات مورد نظر در سایر قسمت ها استفاده شده است! ابتدا اطلاعات سایر قسمت ها را اصلاح کنید و سپس برای حذف اقدام کنید.";
        public static readonly string op_message_city_exist = "شهری با این اطلاعات قبلا ذخیره شده است.";
        public static readonly string op_message_saved_prescription_in_current_sector = "قبلا نسخه هایی برای بیمه شده های انتخاب شده در صندوق فعلی ذخیره شده اند. تغییر صندوق برای بیمه شده ها امکان پذیر نمی باشد.";
        public static readonly string op_message_allow_just_one_doctor_in_center = "پزشک دیگری قبلا به این مرکز اضافه شده است. برای این نوع از مرکز، ثبت بیش از یک پزشک فعال امکانپذیر نیست.";

        public static readonly string op_msg_pres_inured_exist = "اطلاعات این بیمه شده قبلا ذخیره شده است.";
        public static readonly string op_msg_pres_pres_exist = "اطلاعات این نسخه قبلا ذخیره شده است.";
        public static readonly string op_msg_pres_service_exist = "این خدمت ها قبلا برای این نسخه ذخیره شده اند.";
        public static readonly string op_msg_pres_service_subset = "این خدمت ها دارای زیر مجموعه می باشند.";
        public static readonly string op_msg_pres_service_not_exist = "خدمت های نسخه ها در این مرکز و برای صندوق جدید تعریف نشده اند.";
        public static readonly string op_msg_pres_center_doctor = "پزشک/پزشک های معالج تعیین شده در مرکز انتخاب شده حضور ندارند. فقط پزشک هایی می توانند به عنوان معالج انتخاب شوند که در آن مرکز فعالیت داشته باشند.";
        public static readonly string op_msg_pres_visit_expiration = "در تعدادی از نسخه ها تاریخ انقضا قبل از تاریخ ویزیت می باشد.";
        public static readonly string op_msg_pres_prescription_visit = "در تعدادی از نسخه ها تاریخ ویزیت قبل از تاریخ تجویز خدمت/ارجاع می باشد.";
        ////////////////////////////////////////////////////////////////////////// public enums
        public enum enum_data_types { number_type, string_type, bool_type, other_type };
        public enum enum_password_types { user, db_empty };
        public enum enum_dialog_types { error, save_edit, save_new, delete, notice, warning,yes_no_question };
        public enum enum_dialog_options { yes, no, cancel, ok };
        public enum enum_operation_results { success, exist, error, subset, relation, saved_prescriptions, just_one_doctor, superset };
        public enum enum_information_part { province, city, other, other_sector };
        public enum enum_data_operation { new_data, edit_data, batch_edit, copy_data, batch_copy, just_edit };
        public enum enum_form_types { main, data, sub_data, dialog };
        public enum enum_clinic_group { Doctory = 1, Dentistry = 2, Paraclinical = 4 };
        public enum enum_tariff_ins_search_type { all, insurance, sector, nulls };
        public enum enum_clinic_types
        {
            CharityClinic, PublicClinic, PrivateClinic, CharityHospital, PrivateHospital, PublicHospital,
            DentistClinic, SpecialistDentistClinic,
            SpecialistClinic, SubspecialistClinic, GeneralPractitionerClinic,
            SonographyClinic, RadiologyClinic, MRIClinic, CTScanClinic, ImagingClinic,
            PhysiotherapyClinic,
            RadiotherapyClinic, NuclearClinic,
            LaboratoryClinic,
            PublicPharmacy, PrivatePharmacy
        };
        public enum enum_doctor_group { Doctor = 1, Dentist = 2, MidWife = 3, Paramedicine = 4 }
        public enum enum_medicine_degree_group
        {
            General = 1, Specialist = 2, Subspecialist = 3, Dentist = 4, SpecialistFellowship = 5,
            SubspecialistFellowship = 6, Pharmacists = 7, Associates = 8, Bachelors = 9, Masters = 10, PhD = 11
        };
        public enum enum_insurances { KomitehEmdad = 106, NirooMosalah = 104, Salamat = 105, TaminEjtemaei = 103, Other=107 };
        public enum enum_tag_of_insurances
        {
            SedaSima = 100,
            Naft = 101,
            BankMelli = 102,
            TaminEjtemaei = 103,
            NirooMosalah = 104,
            Salamat = 105,
            KomitehEmdad = 106,
            BankTejarat = 107,
            BankSepah = 108,
            BankSaderat = 109,
            BankMellat=110,
            BimehSina=111,
            AtiyehSazan=112,
            BimehDey=113,
            BankKeshavarzi=114,
            BimehDana=115,
            BimehMihan=116,
            HelalAhmar=117,
            BankSanatMaedan=118
        }
        public enum enum_other_insurances { BankTejarat, OTHER };
        public enum enum_salamat_sectors { Dowlat, Iranian, Aghshar, Roostaeian, SalamatHamegani, SalamatKhas, SalamatKhareji };
        public enum enum_tamin_sectors { BimarAadi, BimarKhas };
        public enum enum_mosalah_sectors { Aadi, Janbazan };
        public enum enum_sector_contract_status { is_contracted = 1, not_contracted = 2, both = 3 };
        public enum enum_user_tables_for_transfer
        {
            Month,
            UserType,
            Insurance,
            InsuranceSector,
            SystemUser,
            Province,
            City,
            ClinicGroup,
            ClinicType,
            ClinicPart,
            DoctorGroup,
            MedicineDegreeGroup,
            MedicineDegree,
            MedicineField,
            Doctor,
            MedicalCenter,
            MedicalCenterPart,
            MedicalCenterContract,
            MedicalCenterDoctor,
            MedicalServiceCategory,
            MedicalServiceSubCategory,
            MedicalService,
            KValue,
            MedicalServiceTariff,
            MedicalCenterTariff,
            PrescriptionDataParameters,
            StandardReport,
            UserPrescriptionPermission,
            ActivityType
        }

        //////////////////////////////////////////////////////////////////////// Prescription enums
        public enum enum_prescription_service_group { Visit = 21, OutpatientService = 22 };
        public enum enum_medical_service_group
        {
            Visit, LaboratoryService, DoctorService, DentistService, PhysiotherapyService, RadiologyService,
            SonographyService, MRIService, RadiotherapyService, CTScanService, NuclearService
        }
        public enum enum_service_status { Static, Dynamic, StaticDynamic };
        public enum enum_prescription_results { success, insured_exist, pres_exist, service_exist, subset, error, service_not_exist, center_doctor_error, visit_expiration_error, prescription_visit_error };
        
        ///////////////////////////////////////////////////////////////////////// Activity Enums
        public enum enum_activity_types { AddInsured = 1, EditInsured = 2, DeleteInsured = 3, EditInsuredExpiration = 4, AddInsuredWithUpdate = 5, AddInsuredUsingPresImport = 6, AddInsuredUsingImport = 7, AddPrescription = 21, EditPresInfo = 22, EditPresService = 23, AddPresService = 24, DeletePresService = 25, DeletePres = 26, AddPresUsingImport=27 };

        ///////////////////////////////////////////////////////////////////////// arrays
        public static int[] days_count_of_monthes = new int[] { 31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 30 };

        ///////////////////////////////////////////////////////////////////////// tamin ejtemaei excel file
        public static string[] tamin_excel_col_names = new string[] { "کد ملی", "تاریخ پذیرش", "نوع", "کد خدمت/کد ویزیت", "تعداد", "بیمار خاص", "شماره صفحه" };
        public static string tamin_excel_sheet_name = "Sheet1";

    }
}