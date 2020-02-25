using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adm.Core.Domain.Models;
using Adm.Core.infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adm.Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        protected readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task <List<Produto>> Get()
        {

           return await _produtoRepository.ObterTodos();

        }

        // GET: api/Produto/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Produto
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
