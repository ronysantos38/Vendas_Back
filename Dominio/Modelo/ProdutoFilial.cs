using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
   
        public class ProdutoFilial
        {
            public int Produtoid { get; set; }
            public int Filialid { get; set; }
            public string NomeProduto { get; set; }
            public string NomeFilial { get; set; }
            public decimal valor { get; set; }
        }
     
}
