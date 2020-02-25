using Adm.Core.Domain.Interfaces;
using Adm.Core.Domain.Models;
using Adm.Core.infra.Context;
using Microsoft.EntityFrameworkCore;
using RA.School.Proj.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Core.infra.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {

        public FornecedorRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid Id)
        {
            return await _dataContext.Fornecedores.AsNoTracking().Include(c => c.Endereco)
                .FirstOrDefaultAsync(predicate: c => c.Id == Id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid Id)
        {
            return await _dataContext.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
