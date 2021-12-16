using Microsoft.AspNetCore.Mvc;
using challengeCoodesh.DbConfig.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeCoodesh_CROM.Models.Entitie;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace challengeCoodesh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        public readonly IArticlesRepository articlesRepository;
        public ArticlesController(IArticlesRepository _articlesRepository)
        {
            articlesRepository = _articlesRepository;
        }


        // GET: api/Articles
        [HttpGet]
        public IEnumerable<Articles> Get()
        {
            return  articlesRepository.Buscar();
        }

        // GET api/Articles/5
        [HttpGet("{id}")]
        public Articles Get(int id)
        {
           return articlesRepository.Buscar(id);
         
        }

        // POST api/Articles
        [HttpPost]
        public void Post([FromBody] Articles value)
        {
            articlesRepository.Adicionar(value);
        }

        // PUT api/Articles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Articles value)
        {
            articlesRepository.Editar(id, value);
        }

        // DELETE api/Articles/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            articlesRepository.Remover(id);
        }
    }
}
