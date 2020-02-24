namespace EntityFrameworkExercise.DataProcessor
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.Xml.Serialization;

    using EntityFrameworkExercise.Data;
    using EntityFrameworkExercise.DataProcessor.ExportDto;

    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAuthorsWithSameName(BookShopContext context, string name)
        {
            var authorsDtos = context
                .Authors
                .Where(a => a.FirstName + " " + a.LastName == name)
                .Select(author => new ExportAuthorDto
                {
                    Email = author.Email,
                    Name = author.FirstName + " " + author.LastName,
                    Phone = author.Phone
                }).ToArray();

            var jsonResult = JsonConvert.SerializeObject(authorsDtos, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var booksDtos = context
                .Books
                .Where(b => b.Genre.ToString() == "Science" && b.PublishedOn.Date > date.Date)
                .Select(b => new ExportBookDto
                {
                    Pages = b.Pages,
                    Name = b.Name,
                    Date = DateTime.ParseExact(b.PublishedOn.ToString(), "d", CultureInfo.InvariantCulture)
                })
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.Date)
                .Take(10)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportBookDto[]),
                            new XmlRootAttribute("Books"));

            var stringBuilder = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(stringBuilder), booksDtos, namespaces);

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
