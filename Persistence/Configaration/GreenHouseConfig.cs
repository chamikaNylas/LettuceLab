using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Entities;
using System.ComponentModel;


namespace Persistence.Configaration
{
    public class GreenHouseConfiguration : IEntityTypeConfiguration<GreenHouse>
    {
        public void Configure(EntityTypeBuilder<GreenHouse> builder)
        {
            builder.ToTable("GreenHouses");
            builder.HasKey(gh => gh.Id);

            builder.OwnsMany(typeof(Domain.ValueObjects.Container), "Containers", containersBuilder =>
            {
                containersBuilder.ToTable("Containers");
                containersBuilder.WithOwner().HasForeignKey("GreenHouseId");
                containersBuilder.Property<Guid>("Id").HasAnnotation("Relational:ColumnType", "uniqueidentifier");
                // containersBuilder.HasKey("id", "GreenHouseId");        
                containersBuilder.OwnsMany(typeof(Domain.ValueObjects.GrowBed), "GrowBeds", growBedBuilder =>
                 {
                     growBedBuilder.ToTable("GrowBeds");
                     growBedBuilder.WithOwner().HasForeignKey("GreenHouseId", "ContainerId");
                     growBedBuilder.Property<Guid>("Id").HasAnnotation("Relational:ColumnType", "uniqueidentifier");
                     growBedBuilder.OwnsMany(typeof(Domain.ValueObjects.Lettuce), "Lettuces", lettuceBuilder =>
                     {
                         lettuceBuilder.ToTable("Lettuces");
                         lettuceBuilder.WithOwner().HasForeignKey("GreenHouseId", "ContainerId", "GrowBedId");
                         lettuceBuilder.Property<Guid>("Id").HasAnnotation("Relational:ColumnType", "uniqueidentifier");
                     });
                });

            });
            builder.HasMany(typeof(Domain.Entities.GreenHouseManager), "GreenHouseManagers")
                .WithOne();
             // builder.Navigation(gh => gh.Containers).Metadata.SetField("_Containers");
             //  builder.Navigation(gh => gh.Containers).UsePropertyAccessMode(PropertyAccessMode.Field);
             //  builder.Metadata.FindNavigation(nameof(GreenHouse.Containers)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }


}





















//    public class GreenHouseConfiguration : IEntityTypeConfiguration<GreenHosue>
//    {
//        public void Configure(EntityTypeBuilder<GreenHosue> builder)
//        {
//            builder.ToTable("GreenHouses");
//            builder.HasKey(gh => gh.Id);

//            builder  .OwnsMany(gh => gh.containers, containersBuilder =>
//            {
//                    containersBuilder.HasKey(c => c.Length);
//                    containersBuilder.OwnsMany(c => c.GrowBeds, growBedBuilder =>
//                    {
//                        growBedBuilder.HasKey(gb => gb.Length);
//                        growBedBuilder.OwnsMany(gb => gb.Lettuce, lettuceBuilder =>
//                        {
//                            lettuceBuilder.HasKey(l => l.Type);
//                        });
//                    });
//                });

//                }
//            }
//}
