using System.ComponentModel.DataAnnotations.Schema;

namespace IS345_Lab10_API.Models
{
    [Table("usertable")]
    public class User
    {
        public int Id { get; set; }

        [Column("username")]
        public string? Username { get; set; }

        [Column("userpass")]
        public string? Userpass { get; set; }
    }
}
