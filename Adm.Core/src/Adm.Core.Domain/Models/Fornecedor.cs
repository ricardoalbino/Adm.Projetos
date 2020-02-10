using Adm.Core.Domain.Enum;
using RA.School.Proj.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adm.Core.Domain.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public  TipoFornecedor TipoFornecedor{ get; set; }
        public  Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* EF  - RELACIONAMENTOS - FORNECEDOR TEM  MUITOS PRODUTOS*/
        public IEnumerable<Produto> Produtos { get; set; }
    }

  
}
