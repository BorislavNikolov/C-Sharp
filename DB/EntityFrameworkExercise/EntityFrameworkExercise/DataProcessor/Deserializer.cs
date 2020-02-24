namespace EntityFrameworkExercise.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using EntityFrameworkExercise.Data;
    using EntityFrameworkExercise.Data.Models;
    using EntityFrameworkExercise.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0}.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportBookDto[]),
                new XmlRootAttribute("Books"));

            var booksDtos = (ImportBookDto[])(xmlSerializer.Deserialize(new StringReader(xmlString)));
            var books = new HashSet<Book>();

            var sb = new StringBuilder();

            foreach (var bookDto in booksDtos)
            {
                if (!IsValid(bookDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = bookDto.Name,
                    Genre = bookDto.Genre,
                    Price = bookDto.Price,
                    Pages = bookDto.Pages,
                    PublishedOn = DateTime.ParseExact(bookDto.PublishedOn.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture)
                };

                books.Add(book);
                sb.AppendLine(string.Format(
                        SuccessfullyImportedBook,
                        book.Name,
                        book.Price));
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var authorsDtos = JsonConvert.DeserializeObject<ImportAuthorDto[]>(jsonString);
            var authors = new HashSet<Author>();
            var sb = new StringBuilder();

            foreach (var authorDto in authorsDtos)
            {
                if (IsValid(authorDto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author
                {
                    FirstName = authorDto.FirstName,
                    LastName = authorDto.LastName,
                    Phone = authorDto.Phone,
                    Email = authorDto.Email
                };

                var databaseContainsEmail = context.Authors.Any(a => a.Email == author.Email);

                if (databaseContainsEmail)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authors.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor,
                                author.FirstName + " " + author.LastName));
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}