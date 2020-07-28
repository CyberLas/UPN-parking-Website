using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking_Lot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.DB.Confingurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(o => o.Id);

            //Relacion con Tarjetas de Uno a Muchos
            builder.HasMany(o => o.Tarjetas)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.IdUser);

            //Relacion con Vehiculos de Uno a Muchos
            builder.HasMany(o => o.Vehiculos)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.IdUser);
        }
    }
}
