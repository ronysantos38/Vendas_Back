using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Interface.Repositorio
{
    public interface IFilialRepository
    {
        void Cadastrar(Filial filial);
        List<Filial> Listar();
        Filial PesquisaPorId(int Id);
        void Atualizar(Filial filial);
        void Excluir(int Id);
        void CarregarDados();
    }
}
