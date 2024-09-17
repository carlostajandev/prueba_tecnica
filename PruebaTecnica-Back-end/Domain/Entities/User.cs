namespace PruebaTecnica_Back_end.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, Supervisor, Employee

    }

    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Supervisor = "Supervisor";
        public const string Employee = "Employee";
    }
}
