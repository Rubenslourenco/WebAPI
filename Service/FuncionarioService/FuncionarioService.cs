using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataContext;
using WebAPI.Models;

namespace WebAPI.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {

        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionarios(FuncionarioModel novoFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nunhum dado encontrado!!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionarios(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel editarFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}