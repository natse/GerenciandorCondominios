using GerenciandorCondominiosBLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosDAL.Mapeamentos
{
    public class HistoricoRecursoMap : IEntityTypeConfiguration<HistoricoRecursos>
    {
        public void Configure(EntityTypeBuilder<HistoricoRecursos> builder)
        {
            builder.HasKey(hr => hr.HistoricoRecursosId);
            builder.Property(hr => hr.Valor).IsRequired();
            builder.Property(hr => hr.Tipo).IsRequired();
            builder.Property(hr => hr.Ano).IsRequired();
            builder.Property(hr => hr.Dia).IsRequired();
            builder.Property(hr => hr.MesId).IsRequired();

            builder.HasOne(hr => hr.Mes).WithMany(hr => hr.HistoricoRecursos).HasForeignKey(hr => hr.MesId);

            builder.ToTable("HistoricoRecursos");
        }
    }
}
