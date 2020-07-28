using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking_Lot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parking_Lot.DB.Confingurations
{
    public class EstacionamientoConfiguration : IEntityTypeConfiguration<Estacionamiento>
    {
        public void Configure(EntityTypeBuilder<Estacionamiento> builder)
        {
            builder.ToTable("Estacionamiento");
            builder.HasKey(o => o.Id);
        }
    }
}
