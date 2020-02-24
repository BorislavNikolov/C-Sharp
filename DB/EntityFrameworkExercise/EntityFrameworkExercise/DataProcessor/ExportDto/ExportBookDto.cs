namespace EntityFrameworkExercise.DataProcessor.ExportDto
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Books")]
    public class ExportBookDto
    {
        [XmlAttribute]
        public int Pages { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
