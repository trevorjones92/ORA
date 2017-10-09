using ORA_DAL.Model;

namespace ORA_Data.Model
{
    public class LoginDM
    {
        public int LoginId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDM Employee { get; set; }
    }
}