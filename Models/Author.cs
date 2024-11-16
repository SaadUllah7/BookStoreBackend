using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreBackend.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = null!;

[       InverseProperty("Author")]
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}