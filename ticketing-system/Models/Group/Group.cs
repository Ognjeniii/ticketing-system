namespace ticketing_system.Models.Group
{
    public class Group
    {
        public int GroupId { get; } // pk
        public string Name { get; set; }
        public int HeadOfTheGroup { get; set; } // user_id fk
    }
}
