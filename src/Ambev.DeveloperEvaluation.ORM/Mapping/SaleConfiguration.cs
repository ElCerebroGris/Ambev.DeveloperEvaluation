﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.SaleNumber).IsRequired().HasMaxLength(50);
            builder.Property(s => s.SaleDate).IsRequired();
            builder.Property(s => s.CustomerId).IsRequired().HasMaxLength(50);
            builder.Property(s => s.CustomerName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.BranchId).IsRequired().HasMaxLength(50);
            builder.Property(s => s.BranchName).IsRequired().HasMaxLength(100);
            builder.Property(s => s.TotalAmount).IsRequired().HasColumnType("numeric(18,2)");
            builder.Property(s => s.IsCancelled).IsRequired().HasDefaultValue(false);

            builder.HasMany(s => s.Items)
                   .WithOne()
                   .HasForeignKey(si => si.SaleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }   
}
