using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StreamBox.Models
{
    public class Server
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Server Name")]
        public string ServerName { get; set; }

        [Required]
        [Display(Name = "Server IP")]
        public string ServerIP { get; set; }

        [Required]
        [Display(Name = "Max Clients")]
        public int MaxClients { get; set; } 

        [Required]
        [Display(Name = "Superuser username (sudo)")]
        public string SudoUsername { get; set; }

        [Required]
        [Display(Name = "Superuser password (sudo)")]
        public string SudoPassword { get; set; }

        //One-To-Many RelationShip.
        public ICollection<Stream> streams { get; set; }
    }
}
