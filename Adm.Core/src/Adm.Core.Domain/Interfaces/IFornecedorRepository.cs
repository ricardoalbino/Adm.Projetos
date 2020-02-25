using Adm.Core.Domain.Interfaces;
using Adm.Core.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Adm.Core.Domain.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
   {
        Task<Fornecedor> ObterFornecedorEndereco(Guid Id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid Id);
    }
}
