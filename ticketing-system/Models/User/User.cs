namespace ticketing_system.Models.User
{
    public class User
    {
        public int UserId { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public int GroupId { get; set; } // fk
        public int UserType { get; set; } // fk
        public DateTime CreatedDate { get; set; }

        public User(int userId, string name, string lastName, string email, string password, string jobTitle, int groupId, int userType)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            JobTitle = jobTitle;
            GroupId = groupId;
            UserType = userType;
            CreatedDate = DateTime.Now;
        }
    }
}
