using System.ComponentModel.DataAnnotations.Schema;

namespace IS345_Lab10_API.Models
{
    [Table("book")]
    public class Book
    {
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("price")]
        public int? Price { get; set; }

        [Column("bookquantity")]
        public int? BookQuantity { get; set; }

        [Column("cata")]
        public int? Category { get; set; }

        [Column("image")]
        public string? Image { get; set; }
    }
}
