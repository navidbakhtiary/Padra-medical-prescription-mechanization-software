using System.Configuration;

namespace PadraInsurancePrescription
{
    public class PLPadraConstants
    {
        public static readonly string cd_padra_str = ConfigurationManager.AppSettings.Get(PLConstants.config_padra_website_setting_name) + " " +
            ConfigurationManager.AppSettings.Get(PLConstants.config_padra_phone_number_setting_name);
        public static readonly string report_padra_title_str = ConfigurationManager.AppSettings.Get(PLConstants.config_padra_title_setting_name) + "   " +
            ConfigurationManager.AppSettings.Get(PLConstants.config_padra_phone_number_setting_name);
        public static readonly string report_padra_website_str = ConfigurationManager.AppSettings.Get(PLConstants.config_padra_website_setting_name);
        public static readonly string report_padra_phone_numbers_str = ConfigurationManager.AppSettings.Get(PLConstants.config_padra_phone_number_setting_name);
    }
}