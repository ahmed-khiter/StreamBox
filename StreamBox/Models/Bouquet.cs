using StreamBox.Models.RelationsShips;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public class Bouquet
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="You must enter name of bouquet .")]
        [Display(Name ="Bouquet")]
        public string NameOfBouquet { get; set; }

        //Many-To-Many Relationships.
        public ICollection<StreamBouquets> StreamBouquets { get; set; }


    }
}
