using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.Models.User
{
    public class User
    {
        [Column("user_id")]
        public int UserId { get; } // pk
        [Column("group_id")]
        public int GroupId { get; set; } // fk
        [Column("user_type_id")]
        public int UserTypeId { get; set; } // fk
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Column("job_title")]
        public string JobTitle { get; set; }
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        public User() { }
        public User(int groupId, int userTypeId, string firstName, string lastName, string email, string username, string password, string jobTitle, DateTime creationDate)
        {
            GroupId = groupId;
            UserTypeId = userTypeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            JobTitle = jobTitle;
            CreationDate = creationDate;
        }
    }
}
