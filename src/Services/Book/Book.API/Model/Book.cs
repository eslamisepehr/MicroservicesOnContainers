using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.API.Model
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
