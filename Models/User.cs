namespace Payment.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int Name { get; set; }
        public int Surname { get; set; }
        public string FullName => $"{Name} {Surname}";
        public Country Country { get; set; } = new();
    }

}
