using GerenciandorCondominiosBLL.Models;
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
            builder.HasKey(a => a.EventoId);
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.UsuarioId).IsRequired();

            builder.HasOne(a => a.Usuario).WithMany(a => a.Eventos).HasForeignKey(a => a.UsuarioId);

            builder.ToTable("Eventos");
        }
    }
}
