
namespace PadraInsurancePrescription
{
    public class PLReportConstants
    {
        ////////////////////////////////////////////////////////////////////////// page size
        float A4_width_cm = 21f, A4_height_cm = 29.7f, A4_width_inch = 8.27f, A4_height_inch = 11.69f;
        ///////////////////////////////////////////////////////////////////////// letter rdlc file string
        public static readonly string str_tamin_doctor_letter_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_doctor_letter.rdlc";
        public static readonly string str_tamin_EP_doctor_letter_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_EP_doctor_letter.rdlc";
        public static readonly string str_tamin_doctor_service_letter_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_doctor_service_letter.rdlc";
        public static readonly string str_tamin_clinic_visit_letter_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_clinic_visit_letter.rdlc";
        public static readonly string str_tamin_clinic_service_letter_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_clinic_service_letter.rdlc";
        public static readonly string str_tamin_dentist_letter_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_dentist_letter.rdlc";
        public static readonly string str_salamat_private_clinic_letter_rdlc = "PadraInsurancePrescription.CR_Salamat.salamat_private_clinic_letter.rdlc";
        public static readonly string str_salamat_paraclinic_letter_rdlc = "PadraInsurancePrescription.CR_Salamat.salamat_paraclinic_letter.rdlc";
        public static readonly string str_public_letter_rdlc = "PadraInsurancePrescription.CR_Other.public_letter.rdlc";
        public static readonly string str_public_clinic_comp_letter_rdlc = "PadraInsurancePrescription.CR_Other.public_clinic_comp_letter.rdlc";
        public static readonly string str_komiteh_letter_rdlc = "PadraInsurancePrescription.CR_KomitehEmdad.komiteh_letter.rdlc";
        public static readonly string str_mosalah_letter_rdlc = "PadraInsurancePrescription.CR_NirooMosalah.mosalah_letter.rdlc";

        public static readonly string str_prescriptions_stats_letter_rdlc = "PadraInsurancePrescription.CR_stats.prescriptions_stats_letter.rdlc";
        ///////////////////////////////////////////////////////////////////////// list rdlc file string
        public static readonly string str_public_list_rdlc = "PadraInsurancePrescription.CR_Other.public_list.rdlc";
        public static readonly string str_public_complete_list_rdlc = "PadraInsurancePrescription.CR_Other.public_complete_list.rdlc";
        public static readonly string str_public_list_with_serial_rdlc = "PadraInsurancePrescription.CR_Other.public_list_with_serial.rdlc";
        public static readonly string str_public_complete_list_with_serial_rdlc = "PadraInsurancePrescription.CR_Other.public_complete_list_with_serial.rdlc";
        public static readonly string str_public_simple_list_with_service_rdlc = "PadraInsurancePrescription.CR_Other.public_simple_list_with_service.rdlc";
        public static readonly string str_tamin_doctor_list_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_doctor_list.rdlc";
        public static readonly string str_tamin_doctor_complete_list_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_doctor_complete_list.rdlc";
        public static readonly string str_tamin_clinic_list_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_clinic_list.rdlc";
        public static readonly string str_tamin_clinic_complete_list_rdlc = "PadraInsurancePrescription.CR_TaminEjtemaei.tamin_clinic_complete_list.rdlc";
        
        ////////////////////////////////////////////////////////////////////////// report dataset name string
        public static readonly string str_reports_datasource = "PIPDataSet";
        public static readonly string str_public_letter_dataset = "LetterReportDataTable";
        public static readonly string str_public_price_list_dataset = "PresListDataTable";
        public static readonly string str_public_complete_list_dataset = "PresAndServiceListDataTable";
        public static readonly string str_public_temp_dataset = "temp_datatable";
        
        ///////////////////////////////////////////////////////////////////////// letter pdf string
        public static readonly string str_salamat_letter_pdf = "salamat_letter.pdf";
        public static readonly string str_salamat_paraclinic_letter_pdf = "salamat_paraclinic_letter.pdf";
        public static readonly string str_tamin_doctor_letter_pdf = "tamin_doctor_letter.pdf";
        public static readonly string str_tamin_EP_doctor_letter_pdf = "tamin_EP_doctor_letter.pdf";
        public static readonly string str_tamin_doctor_service_letter_pdf = "tamin_doctor_service_letter.pdf";
        public static readonly string str_tamin_dentist_letter_pdf = "tamin_dentist_letter.pdf";
        public static readonly string str_tamin_clinic_visit_letter_pdf = "tamin_clinic_visit_letter.pdf";
        public static readonly string str_tamin_clinic_service_letter_pdf = "tamin_clinic_service_letter.pdf";
        public static readonly string str_komiteh_letter_pdf = "komiteh_letter.pdf";
        public static readonly string str_public_letter_pdf = "public_letter.pdf";
        public static readonly string str_public_clinic_comp_letter_pdf = "public_clinic_comp_letter.pdf";
        public static readonly string str_mosalah_letter_pdf = "mosalah_letter.pdf";

        public static readonly string str_prescriptions_stats_letter_pdf = "prescriptions_stats_letter.pdf";
        ///////////////////////////////////////////////////////////////////////// list pdf string
        public static readonly string str_tamin_doctor_list_pdf = "tamin_doctor_list.pdf";
        public static readonly string str_tamin_doctor_complete_list_pdf = "tamin_doctor_complete_list.pdf";
        public static readonly string str_tamin_clinic_list_pdf = "tamin_clinic_list.pdf";
        public static readonly string str_tamin_clinic_complete_list_pdf = "tamin_clinic_complete_list.pdf";
        public static readonly string str_public_list_pdf = "public_list.pdf";
        public static readonly string str_public_complete_list_pdf = "public_complete_list.pdf";
        public static readonly string str_public_list_with_serial_pdf = "public_list_with_serial.pdf";
        public static readonly string str_public_complete_list_with_serial_pdf = "public_complete_list_with_serial.pdf";
        public static readonly string str_public_simple_list_with_service_pdf = "public_simple_list_with_service.pdf";

        ///////////////////////////////////////////////////////////////////////// details pdf strings
        public static readonly string str_public_details_pdf = "public_details.pdf";

        ///////////////////////////////////////////////////////////////////////// Report Enums
        public enum enum_report_letter_types 
        { 
            TaminDoctor = 1, TaminEPDoctor = 12, TaminDentist = 2, TaminOutpatientService = 3,
            TaminClinicVisit = 10, TaminClinicService = 11,
            SalamatDocDen = 4, Salamat = 5, SalamatParaclinic = 6,
            SalamatClinicDoctor=14, SalamatClinicService=15, SalamatClinicSeparateAll=16,
            KomitehEmdad = 7, 
            PublicLetter = 8, PublicDetailsLetter = 9,PublicClinicComprehensiveLetter=17,
            NirooMosalah = 13 
        };
        public enum enum_report_list_types { TaminPrice = 2, TaminComplete = 3, TaminUserComplete = 4, KomitehEmdad = 5, Public = 6, PublicComplete = 7, PublicUserComplete = 8, PublicSerial = 9, PublicCompleteSerial = 10, PublicUserCompleteSerial = 11, TaminClinic = 12, TaminClinicComplete = 13, TaminUserClinicComplete = 14, PublicClinic = 15, PublicClinicComplete = 16, PublicUserClinicComplete = 17, PublicClinicSerial = 18, PublicClinicCompleteSerial = 19, PublicUserClinicCompleteSerial = 20, PublicSimpleService=21 };
        public enum enum_report_output_types { TaminCD = 1, SalamatCD = 2, MosalahCD = 3, KomitehCD = 4, OtherCD = 5, TaminExcel = 6 };
        public enum enum_web_service_types { TaminParaclinicWS = 1, SalamatWS = 2 };

        /////////////////////////////////////////////////////////////////////////report parameters enum
        public enum enum_salamat_params
        {
            request_date,
            province,
            month, year,
            center_type, center_name, center_part_id,
            padra_title, padra_website, padra_phone_numbers, padra_description,
            company_title, company_website, company_phone_numbers, company_logo,
            doctor_names, service_title
        };
        public enum enum_tamin_doctor_params
        {
            org_title,
            request_date,
            province, city,
            month, year,
            doctor_names, doc_medical_id, doc_field, doc_degree, doctor_type_number,
            aadi_vis_count, khas_vis_count,
            aadi_vis_price, khas_vis_price,
            aadi_service_count, khas_service_count,
            aadi_service_price, khas_service_price,
            padra_title, padra_website, padra_phone_numbers, padra_description,
            company_title, company_website, company_phone_numbers, company_logo,
            service_title,
            pres_count, service_count, page_service_count,
            sector_name,
            ep_aadi_vis_count, ep_khas_vis_count,
            ep_aadi_vis_price, ep_khas_vis_price,
            ep_aadi_service_count, ep_khas_service_count,
            ep_aadi_service_price, ep_khas_service_price,
            ep_aadi_tot_count, ep_khas_tot_count,
            ep_aadi_tot_price, ep_khas_tot_price,
            ep_total_count, ep_total_price
        };
        public enum enum_public_params
        {
            insurance_name, sector_name, insurance_boss,
            request_date,
            province, city,
            center_type, center_name, center_part, center_id,
            doctor_names,
            year, month,
            logo,
            padra_title, padra_website, padra_phone_numbers, padra_description,
            company_title, company_website, company_phone_numbers, company_logo,
            org_title,service_title,
            pres_count, service_count, page_service_count
        };
        public enum enum_komiteh_params
        {
            request_date,
            province, city,
            center_name, center_part, center_id,
            year, month,
            padra_title, padra_website, padra_phone_numbers, padra_description,
            company_title, company_website, company_phone_numbers, company_logo,
        };
        public enum enum_mosalah_params
        {
            request_date,
            province,
            center_name, center_part, center_id,
            doctor_names, doc_medical_id,
            year, month,
            padra_title, padra_website, padra_phone_numbers, padra_description,
            company_title, company_website, company_phone_numbers, company_logo,
        };
        public enum enum_stats_params
        {
            insurance, sector,
            request_date,
            province, city,
            center, part,
            year,
            padra_title, padra_website, padra_phone_numbers, padra_description,
            company_title, company_website, company_phone_numbers, company_logo,
        };
    }
}