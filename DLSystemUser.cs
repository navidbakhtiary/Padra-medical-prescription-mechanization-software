
namespace PadraInsurancePrescription
{
    public class DLSystemUser
    {
        public int user_code;
        public string user_name;
        public string name;
        public string family_name;
        public string names_str;

        public DLSystemUser(int u_c, string u_n, string n_n, string n_f)
        {
            user_code = u_c;
            user_name = u_n;
            name = n_n;
            family_name = n_f;
            names_str = name + " " + family_name;
        }

    }
}
