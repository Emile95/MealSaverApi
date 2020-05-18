namespace Persistance.Entities
{
    public partial class Account
    {
        public Account() { }

        public Account(Account account)
        {
            Id = account.Id;
            FirstName = account.FirstName;
            LastName = account.LastName;
            Email = account.Email;
            Password = account.Password;
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
