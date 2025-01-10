using System.ComponentModel.DataAnnotations.Schema;

namespace ticketing_system.Models.Group
{
    [Table("groups")]
    public class Group
    {
        [Column("group_id")]
        public int GroupId { get; } // pk
        [Column("name")]
        public string Name { get; set; }
        [Column("head_of_the_group")]
        public int HeadOfTheGroup { get; set; } // user_id fk
    }
}
