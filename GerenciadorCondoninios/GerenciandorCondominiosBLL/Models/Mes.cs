using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciandorCondominiosBLL.Models
{
    public class Mes
    {
        public int MesId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Aluguel>Aluguels { get; set; }
        public virtual ICollection<HistoricoRecurso>HistoricoRecursos { get; set; }
    }
}
