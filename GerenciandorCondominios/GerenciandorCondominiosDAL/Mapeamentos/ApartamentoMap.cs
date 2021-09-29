using GerenciandorCondominiosBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosDAL.Mapeamentos
{
    public class ApartamentoMap : IEntityTypeConfiguration<Apartamento>
    {
        public void Configure(EntityTypeBuilder<Apartamento> builder)
        {
            builder.HasKey(a => a.ApartamentoId);
            builder.Property(a => a.Numero).IsRequired();
            builder.Property(a => a.Andar).IsRequired();
            builder.Property(a => a.Foto).IsRequired();

            builder.HasOne(a => a.Proprietario).WithMany(a => a.ProprietariosApartamentos).HasForeignKey(a => a.ProprietarioId);
            builder.HasOne(a => a.Morador).WithMany(a => a.MoradoresApartamentos).HasForeignKey(a => a.MoradorId);

            builder.ToTable("Apartamentos");
        }
    }
}
