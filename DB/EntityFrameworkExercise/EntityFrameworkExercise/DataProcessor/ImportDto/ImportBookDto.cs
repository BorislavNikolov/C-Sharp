namespace EntityFrameworkExercise.DataProcessor.ImportDto
{
    using System;

    using EntityFrameworkExercise.Data.Models.Enums;
    public class ImportBookDto
    {
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public decimal Price { get; set; }

        public int Pages { get; set; }

        public DateTime PublishedOn { get; set; }

    }
}
