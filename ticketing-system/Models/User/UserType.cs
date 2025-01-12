using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.Models.User
{
    [Table("user_types")]
    public class UserType
    {
        [Column("user_type_id")]
        public int UserTypeId { get; set; }

        [Column("user_type_description")]
        public string UserTypeDescription { get; set; }

        public UserType() { }
        public UserType(int UserTypeId, string UserTypeDescription)
        {
            this.UserTypeId = UserTypeId;
            this.UserTypeDescription = UserTypeDescription;
        }
    }
}
