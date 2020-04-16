using System.ComponentModel.DataAnnotations;

namespace StreamBox.Models
{
    public class Server
    {
        internal object streams;

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
        [Display(Name = "Root Password")]
        public string RootPassword { get; set; }

        [Display(Name = "HTTP Port")]
        public int HTTPPort { get; set; }

        [Display(Name = "HTTPS Port")]
        public int HTTPSPort { get; set; }

        [Display(Name = "RTMP Port")]
        public int RTMPPort { get; set; }

        [Display(Name = "SSH Port")]
        public int SSHPort { get; set; }

        [Display(Name = "Is RTMP?")]
        public bool IsRTMP { get; set; }
    }
}
