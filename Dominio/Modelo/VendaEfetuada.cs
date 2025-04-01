using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
  
    public class VendaEfetuada
    {
        public int vendaEfetuadaid { get; set; }
        public int clienteid { get; set; }
        public int vendaid { get; set; }
        public int produtoid { get; set; }
        public DateTime dataVenda { get; set; }
        public decimal valor { get; set; }
        public decimal desconto { get; set; }        
        public int qtde { get; set; }
        public int filialid { get; set; }        
    }
}

