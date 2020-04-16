using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreamBox.Models
{
    public class Stream
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Source { get; set; }

        public string Note { get; set; }

        [Required]
        public List<Server> Servers { get; set; }

        public Bouquet Bouquet { get; set; }

    }
}
