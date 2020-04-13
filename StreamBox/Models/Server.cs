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

        [Display(Name = "HTTP Port")]
        public int HttpPort { get; set; } = 80;

        [Display(Name = "HTTPS Port")]
        public int HttpsPort { get; set; } = 443;

        [Display(Name = "RTMP Port")]
        public int RtmpPort { get; set; } = 1935;

        [Display(Name = "SSH Port")]
        public int SshPort { get; set; } = 22;

        [Display(Name = "is RTMP?")]
        public bool IsRtmp { get; set; }

        [Required]
        [Display(Name = "Root password")]
        public string RootPassword { get; set; }
    }
}
