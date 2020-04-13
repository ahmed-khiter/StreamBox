using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public class StreamBouquets
    {
        public int StreamId { get; set; }

        public Stream Stream { get; set; }

        public int BouquetsId { get; set; }

        public Bouquet Bouquet { get; set; }

    }
}
