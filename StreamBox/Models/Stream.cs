using StreamBox.Models.RelationsShips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public class Stream
    {
        public int Id { get; set; }

        [DisplayName("Stream Name")]
        public string StreamName { get; set; }

        [Display(Name = "Source", Prompt = "URL here")]
        [Required(ErrorMessage = "You must enter URL")]
        public string Source { get; set; }

        public string Note { get; set; }

        //Many-To-One relationship 
        public Server server { get; set; }

        //Many-To-Many Relationships.
        public ICollection<StreamBouquets> StreamBouquets { get; set; }

    }
}
