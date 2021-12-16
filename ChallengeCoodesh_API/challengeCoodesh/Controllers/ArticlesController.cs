﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get(int? _init, int? _finish)
        {
            if (_init == null || _init < 0)
            {
                _init = 0;
            }
            if (_finish == null || _finish < 0)
            {
                _finish = 1;
            }
            if (_finish <= _init)
            {
                return BadRequest("_init parameter need be bigger that _finish parameter");
            }

            return new OkObjectResult(articlesRepository.Buscar(_init,_finish)); 
        }

        // GET api/Articles/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var article = articlesRepository.Buscar(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);

        }

        // POST api/Articles
        [HttpPost]
        public ActionResult Post([FromBody] Articles value)
        {
            try
            {
                articlesRepository.Adicionar(value);

                return Created("", value);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/Articles/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Articles value)
        {
            var article = articlesRepository.Buscar(id);
            if (article == null)
            {
                return NotFound();
            }
            try
            {
                articlesRepository.Editar(id, value);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/Articles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var article = articlesRepository.Buscar(id);
            if (article == null)
            {
                return NotFound();
            }
            try
            {
                articlesRepository.Remover(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           

        }
    }
}
