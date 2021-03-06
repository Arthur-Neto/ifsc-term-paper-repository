﻿using ifsc.tcc.Portal.Domain.AreaModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ifsc.tcc.Portal.Infra.Data.EF.Configurations.AreaModule
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Areas");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID)
                .HasColumnName("AreaID")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
