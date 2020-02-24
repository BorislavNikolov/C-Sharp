namespace EntityFrameworkExercise.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using EntityFrameworkExercise.Data.Models.Enums;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Range(typeof(decimal), "0.1", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Range(typeof(int), "50", "5000")]
        public int Pages { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; } = new HashSet<AuthorBook>();
    }
}
