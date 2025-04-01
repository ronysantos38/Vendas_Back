using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infra.Repositorio
{
    public class FilialRepository : IFilialRepository
    {
        private readonly ContextoVenda contextoVenda = new ContextoVenda();

        public void Atualizar(Filial filial)
        {
            var objFiliais = PesquisaPorId(filial.Filialid);
            ContextoVenda.Filiais.Remove(objFiliais);

            objFiliais.Nome = filial.Nome;

            Cadastrar(objFiliais);
        }

        public void Cadastrar(Filial filial)
        {
            ContextoVenda.Filiais.Add(filial);
        }

        public void CarregarDados()
        {
            contextoVenda.inicializaDados();
        }

        public void Excluir(int Id)
        {
            var objCli = PesquisaPorId(Id);
            ContextoVenda.Filiais.Remove(objCli);
        }

        public List<Filial> Listar()
        {            
            var cli = ContextoVenda.Filiais;
            return cli.OrderBy(x => x.Nome).ToList();
        }

        public Filial PesquisaPorId(int Id)
        {
            var cli = ContextoVenda.Filiais.FirstOrDefault(p => p.Filialid == Id);
            return cli;
        }
    }
}
