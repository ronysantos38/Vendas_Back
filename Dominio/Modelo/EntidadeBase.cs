using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Infra.Contexto;

namespace Dominio.Modelo
{
    public class EntidadeBase
    {

        public int ID { get; set; }

        public EntidadeBase()
        {
            
            //ID = ContextoVenda.Clientes.Count + 1;


        }
    }
}
