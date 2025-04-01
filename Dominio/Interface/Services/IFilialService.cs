using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Interface.Services
{
        public interface IFilialService
        {
            void Cadastrar(Filial filial);
            List<Filial> Listar();
            Filial PesquisaPorId(int Filialid);
            void Atualizar(Filial filial);
            void Excluir(int Filialid);
            void CarregarDados();
        }
   
}
