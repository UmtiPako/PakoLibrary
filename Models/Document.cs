using System.ComponentModel.DataAnnotations;

namespace PakoLibrary.Models
{
    public class Document
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? ShortDescription { get; set; }
        public required string PicturePath { get; set; }
        public required string PDF_Link { get; set; }
    }
}
