using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Servicos
{
    public class FilialService : IFilialService
    {
        private readonly IFilialRepository _filialRepository;

        private readonly Contexto _contexto;

        public FilialService(IFilialRepository filialRepository, Contexto contexto)
        {
            _filialRepository = filialRepository;
            _contexto = contexto;
        }

        public void Atualizar(Filial filial)
        {
            try
            {
                _contexto.Filiais.Update(filial);
                _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filial filial)
        {
            try
            {
                _contexto.Filiais.AddAsync(filial);
                _contexto.SaveChanges();
                //_clienteRepository.Cadastrar(cliente);
            }
            catch (Exception ex)
            {
                //  await _contexto.Pessoas.AddAsync(pessoa);
                //  await _contexto.SaveChangesAsync();
                throw ex;
            }
        }

        public void CarregarDados()
        {
            _filialRepository.CarregarDados();
        }

        public void Excluir(int Filialid)
        {
            try
            {
                Filial filial = PesquisaPorId(Filialid);

                _contexto.Filiais.Remove(filial);
                _contexto.SaveChanges();
                //   _filialRepository.Excluir(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filial> Listar()
        {
            try
            {
                var cli = _contexto.Filiais.ToList();

                return cli;
                //_clienteRepository.Listar();  
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Filial PesquisaPorId(int Filialid)
        {
            try
            {
                return _contexto.Filiais.Find(Filialid);
              //  return _filialRepository.PesquisaPorId(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
