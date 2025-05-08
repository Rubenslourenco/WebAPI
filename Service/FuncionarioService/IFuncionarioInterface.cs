using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionarios(FuncionarioModel novoFuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionariosById(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionarios(FuncionarioModel editarFuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionarios(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> InativarFuncionarios(int id);
    }
}