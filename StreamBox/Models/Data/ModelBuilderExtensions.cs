using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Configrations(this ModelBuilder modelBuilder)
        {
            //Configration Many-To-Many Relationships between Bouquets and stream
            modelBuilder.Entity<StreamBouquets>()
                .HasKey(hk => new { hk.BouquetsId, hk.StreamId });

            //Many-To-One relationship between StreamBouquets and Stream
            modelBuilder.Entity<StreamBouquets>()
                .HasOne(hm => hm.Stream)
                .WithMany(wm => wm.StreamBouquets)
                .HasForeignKey(fk => fk.StreamId);

            //Many-To-One relationship between StreamBouquets and Bouquet
            modelBuilder.Entity<StreamBouquets>()
                .HasOne(o => o.Bouquet)
                .WithMany(m => m.StreamBouquets)
                .HasForeignKey(fk => fk.BouquetsId);

        }
    }
}
