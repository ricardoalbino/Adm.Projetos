using Adm.Core.Domain.Interfaces;
using Adm.Core.Domain.Models;
using System.Threading.Tasks;

namespace Adm.Core.Domain.Interfaces
{
    public  interface IFornecedorRepository : IRepository<Fornecedor>
   {
        Task<Fornecedor> ObterCursoPorAluno(int CPF);
        Task<Fornecedor> ObterCursoPorProfesssor(int CPF);
    }
}
