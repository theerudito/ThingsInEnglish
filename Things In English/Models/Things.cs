using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xamarin.Forms;

namespace ThingsInEnglish.Models
{
    public class Things
    {
        [Key]
        public int IdThing { get; set; }

        public string Name { get; set; }
        public string ImageBase64 { get; set; } = string.Empty;

        [NotMapped]
        public ImageSource Image { get; set; }
    }
}