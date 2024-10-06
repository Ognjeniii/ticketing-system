using System.ComponentModel.DataAnnotations;

namespace ticketing_system.Models.User
{
    public class User
    {
        [Key]
        public int UserId { get; }
        public int GroupId { get; set; } // fk
        public int UserTypeId { get; set; } // fk
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public DateTime CreatedDate { get; set; }

        public User() { }
        public User(int groupId, int userTypeId, string firstName, string lastName, string email, string username, string password, string jobTitle, DateTime createdDate)
        {
            GroupId = groupId;
            UserTypeId = userTypeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            JobTitle = jobTitle;
            CreatedDate = createdDate;
        }
    }
}
