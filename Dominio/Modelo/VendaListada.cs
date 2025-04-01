using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    
    public class VendaListada
    {
        public int Vendaid { get; set; }
        public int Clienteid { get; set; }
        public int FilialId { get; set; }
        public string NomeFilial { get; set; }
        public string NomeCliente { get; set; }
        public char statusVenda { get; set; }
        public DateTime dataVenda { get; set; }
    }
}
