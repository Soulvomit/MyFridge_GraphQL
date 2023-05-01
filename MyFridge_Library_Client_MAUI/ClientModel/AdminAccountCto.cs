using MyFridge_Library_Client_MAUI.ClientModel.Interface;

namespace MyFridge_Library_Client_MAUI.ClientModel
{
    public class AdminAccountCto : ICto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmployeeNumber { get; set; }
    }
}
