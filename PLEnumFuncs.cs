
namespace PadraInsurancePrescription
{
    public class PLEnumFuncs
    {

        public static PLConstants.enum_operation_results opResultToEnum(string op_result)
        {
            if (op_result.Equals("success"))
            {
                return PLConstants.enum_operation_results.success;
            }
            else if (op_result.Equals("error"))
            {
                return PLConstants.enum_operation_results.error;
            }
            else if (op_result.Equals("exist"))
            {
                return PLConstants.enum_operation_results.exist;
            }
            else if (op_result.Equals("subset"))
            {
                return PLConstants.enum_operation_results.subset;
            }
            else if (op_result.Equals("saved_prescriptions"))
            {
                return PLConstants.enum_operation_results.saved_prescriptions;
            }
            else if (op_result.Equals("just_one_doctor"))
            {
                return PLConstants.enum_operation_results.just_one_doctor;
            }
            else if (op_result.Equals("superset"))
            {
                return PLConstants.enum_operation_results.superset;
            }
            return PLConstants.enum_operation_results.error;
        }

        public static PLConstants.enum_prescription_results prescriptionResultToEnum(string op_result)
        {
            if (op_result.Equals("success"))
            {
                return PLConstants.enum_prescription_results.success;
            }
            else if (op_result.Equals("insured_exist"))
            {
                return PLConstants.enum_prescription_results.insured_exist;
            }
            else if (op_result.Equals("pres_exist"))
            {
                return PLConstants.enum_prescription_results.pres_exist;
            }
            else if (op_result.Equals("service_exist"))
            {
                return PLConstants.enum_prescription_results.service_exist;
            }
            else if (op_result.Equals("service_not_exist"))
            {
                return PLConstants.enum_prescription_results.service_not_exist;
            }
            else if (op_result.Equals("center_doctor_error"))
            {
                return PLConstants.enum_prescription_results.center_doctor_error;
            }
            else if (op_result.Equals("visit_expiration_error"))
            {
                return PLConstants.enum_prescription_results.visit_expiration_error;
            }
            else if (op_result.Equals("prescription_visit_error"))
            {
                return PLConstants.enum_prescription_results.prescription_visit_error;
            }
            return PLConstants.enum_prescription_results.error;
        }
        
        public static PLConstants.enum_prescription_results presServiceResultToEnum(string op_result)
        {
            if (op_result.Equals("success"))
            {
                return PLConstants.enum_prescription_results.success;
            }
            else if (op_result.Equals("service_exist"))
            {
                return PLConstants.enum_prescription_results.service_exist;
            }
            else if (op_result.Equals("subset"))
            {
                return PLConstants.enum_prescription_results.subset;
            }
            return PLConstants.enum_prescription_results.error;
        }

        public static string presServiceGroupToString(PLConstants.enum_prescription_service_group group)
        {
            switch (group)
            {
                case PLConstants.enum_prescription_service_group.Visit:
                    return "21";
                    
                case PLConstants.enum_prescription_service_group.OutpatientService:
                    return "22";
                    
            }
            return "21";
        }

        public static string getRegexForInsurancePresID(PLConstants.enum_insurances ins_type)
        {
            switch (ins_type)
            {
                case PLConstants.enum_insurances.KomitehEmdad:
                    return PLConstants.reg_id;
                case PLConstants.enum_insurances.NirooMosalah:
                    return PLConstants.reg_pre_id_NirooMosalah;
                case PLConstants.enum_insurances.Salamat:
                    return PLConstants.reg_pre_id_Salamat;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    return PLConstants.reg_pre_id_TaminEjtemaei;
                default:
                    return PLConstants.reg_id;
            }
        }

        public static string getRegexForInsurancePresID(string ins_tag,out int min_len,out int max_len)
        {
            PLConstants.enum_insurances ins_type = PLEnumFuncs.convertInsuranceTagToEnum(ins_tag);
            switch (ins_type)
            {
                case PLConstants.enum_insurances.KomitehEmdad:
                    min_len = 2;
                    max_len = 20;
                    return PLConstants.reg_id;
                case PLConstants.enum_insurances.NirooMosalah:
                    min_len = PLConstants.len_national_code;
                    max_len = PLConstants.len_national_code+1;
                    return PLConstants.reg_pre_id_NirooMosalah;
                case PLConstants.enum_insurances.Salamat:
                    min_len = 4;
                    max_len = 13;
                    return PLConstants.reg_pre_id_Salamat;
                case PLConstants.enum_insurances.TaminEjtemaei:
                    min_len = PLConstants.len_TaminEjtemaei_pre_code;
                    max_len = PLConstants.len_TaminEjtemaei_pre_code;
                    return PLConstants.reg_pre_id_TaminEjtemaei;
                default:
                    min_len = 2;
                    max_len = 20;
                    return PLConstants.reg_id;
            }
        }

        public static PLConstants.enum_other_insurances convertOtherInsurancesTagToEnum(string tag)
        {
            if (tag.Equals(PLConstants.enum_other_insurances.BankTejarat.ToString()))
            {
                return PLConstants.enum_other_insurances.BankTejarat;
            }
            else
            {
                return PLConstants.enum_other_insurances.OTHER;
            }
        }

        public static PLConstants.enum_insurances convertInsuranceTagToEnum(string tag)
        {
            if (tag.Equals(PLConstants.enum_insurances.Salamat.ToString()))
            {
                return PLConstants.enum_insurances.Salamat;
            }
            else if (tag.Equals(PLConstants.enum_insurances.TaminEjtemaei.ToString()))
            {
                return PLConstants.enum_insurances.TaminEjtemaei;
            }
            else if (tag.Equals(PLConstants.enum_insurances.NirooMosalah.ToString()))
            {
                return PLConstants.enum_insurances.NirooMosalah;
            }
            else if (tag.Equals(PLConstants.enum_insurances.KomitehEmdad.ToString()))
            {
                return PLConstants.enum_insurances.KomitehEmdad;
            }
            else
            {
                return PLConstants.enum_insurances.Other;
            }
        }

        public static PLConstants.enum_salamat_sectors convertSalamatSectorTagToEnum(string tag)
        {
            if (tag.Equals(PLConstants.enum_salamat_sectors.Dowlat.ToString()))
            {
                return PLConstants.enum_salamat_sectors.Dowlat;
            }
            else if (tag.Equals(PLConstants.enum_salamat_sectors.Iranian.ToString()))
            {
                return PLConstants.enum_salamat_sectors.Iranian;
            }
            else if (tag.Equals(PLConstants.enum_salamat_sectors.Aghshar.ToString()))
            {
                return PLConstants.enum_salamat_sectors.Aghshar;
            }
            else if (tag.Equals(PLConstants.enum_salamat_sectors.Roostaeian.ToString()))
            {
                return PLConstants.enum_salamat_sectors.Roostaeian;
            }
            else
            {
                return PLConstants.enum_salamat_sectors.Iranian;
            }
        }

        public static PLConstants.enum_tamin_sectors convertTaminEjtemaeiSectorTagToEnum(string tag)
        {
            if (tag.Equals(PLConstants.enum_tamin_sectors.BimarAadi.ToString()))
            {
                return PLConstants.enum_tamin_sectors.BimarAadi;
            }
            else if (tag.Equals(PLConstants.enum_tamin_sectors.BimarKhas.ToString()))
            {
                return PLConstants.enum_tamin_sectors.BimarKhas;
            }
            else
            {
                return PLConstants.enum_tamin_sectors.BimarAadi;
            }
        }

    }
}
