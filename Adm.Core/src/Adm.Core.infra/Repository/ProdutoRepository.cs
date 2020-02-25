using Adm.Core.Domain.Interfaces;
using Adm.Core.Domain.Models;
using Adm.Core.infra.Context;
using Microsoft.EntityFrameworkCore;
using RA.School.Proj.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Core.infra.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataContext dataContext): base(dataContext){}

        /*Relacionamento 1 - 1*/
        public async Task<Produto> ObterProdutoPorFornecedor(Guid id)
        {
            return await _dataContext.Produtos.AsNoTracking()
                 .Include(f => f.FornecedorId)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            /*Relacionamento 1 - N*/
            return await _dataContext.Produtos.AsNoTracking()
                .Include(f => f.FornecedorId)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
