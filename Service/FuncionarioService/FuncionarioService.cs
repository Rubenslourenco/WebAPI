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

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionarios(FuncionarioModel novoFuncionario)
        {
           ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

           try
           {

            if (novoFuncionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Informa dados";
                serviceResponse.Sucesso = false;

                return serviceResponse;
                
            }

            _context.Add(novoFuncionario);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Funcionarios.ToList();
           }
           catch (Exception ex)
           {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
            
           }
           return serviceResponse;
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

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                
                FuncionarioModel funcionario =  _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if(funcionario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = funcionario;

                
            }
            catch (Exception ex)
            {
               serviceResponse.Mensagem = ex.Message;
               serviceResponse.Sucesso = false; 
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionarios(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if(funcionario == null) {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario nao localizado";
                    serviceResponse.Sucesso = false;
                }                

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
            catch (Exception ex)           
            {
                
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel editarFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}