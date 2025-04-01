using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class VendaRealizada
    {
        public int VendaRealizadaid { get; set; }        
        public int Vendaid { get; set; }
        public int Produtoid { get; set; }
        public decimal desconto { get; set; }        
        public DateTime dataVenda { get; set; }
        public int qtde { get; set; }
    }
}



 