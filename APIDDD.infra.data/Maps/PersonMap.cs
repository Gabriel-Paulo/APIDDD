﻿using APIDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace APIDDD.infra.data.Maps
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("pessoa");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("idpessoa").UseIdentityColumn();
            builder.Property(c => c.Document).HasColumnName("documento");
            builder.Property(c => c.Name).HasColumnName("nome");
            builder.Property(c => c.Phone).HasColumnName("celular");

            builder.HasMany(c => c.Purchases).WithOne(p => p.Person).HasForeignKey(c => c.PersonId);
        }
    }
}
