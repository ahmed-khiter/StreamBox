using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreamBox.Models
{
    public class Bouquet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<Stream> Streams { get; set; }

    }
}
