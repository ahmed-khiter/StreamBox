using System.ComponentModel.DataAnnotations;

namespace StreamBox.Models
{
    public class Server
    {
        internal object streams;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        [Display(Name = "Max Clients")]
        public int MaxClients { get; set; } 

        [Required]
        [Display(Name = "Root Password")]
        public string RootPassword { get; set; }

        [Display(Name = "HTTP Port")]
        public int HTTPPort { get; set; } = 80;

        [Display(Name = "HTTPS Port")]
        public int HTTPSPort { get; set; } = 443;

        [Display(Name = "RTMP Port")]
        public int RTMPPort { get; set; } = 1935;

        [Display(Name = "SSH Port")]
        public int SSHPort { get; set; } = 22;

        [Display(Name = "Is RTMP?")]
        public bool IsRTMP { get; set; } = false;

        public bool State { get; set; } = false;
    }
}
