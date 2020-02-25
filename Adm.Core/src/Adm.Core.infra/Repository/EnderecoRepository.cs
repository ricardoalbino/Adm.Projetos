using Adm.Core.Domain.Interfaces;
using Adm.Core.Domain.Models;
using Adm.Core.infra.Context;
using Microsoft.EntityFrameworkCore;
using RA.School.Proj.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adm.Core.infra.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {

        public EnderecoRepository(DataContext dataContext) : base(dataContext) { }
    
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid id)
        {
            return await _dataContext.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(e => e.FornecedorId == id);
                   
        }
    }
}
