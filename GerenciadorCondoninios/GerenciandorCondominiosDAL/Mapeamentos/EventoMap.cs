﻿using GerenciandorCondominiosBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosDAL.Mapeamentos
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(e => e.EventoId);
            builder.Property(e => e.Nome).IsRequired();
            builder.Property(e => e.Data).IsRequired();
            builder.Property(e => e.UsuarioId).IsRequired();

            builder.HasOne(e => e.Usuario).WithMany(e => e.Eventos).HasForeignKey(e => e.UsuarioId);

            builder.ToTable("Eventos");
        }
    }
}