namespace Capitec.Api.Models
{
    public class SecurityData
    {
        public Login login { get; set; }
    }

    public class Login
    {
        public string loginID { get; set; }
        public string password { get; set; }
    }
}
