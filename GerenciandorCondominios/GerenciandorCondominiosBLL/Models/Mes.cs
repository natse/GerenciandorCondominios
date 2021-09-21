using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosBLL.Models
{
   public class Mes
    {
        public int MesId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Aluguel>Alugueis { get; set; }
        public virtual ICollection<HistoriaRecurso>HistoriaRecursos { get; set; }

    }
}
