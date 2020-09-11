using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model,
            [FromServices] IClienteRepository repository,
            [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = mapper.Map<Cliente>(model);
                    repository.Inserir(cliente);

                    return Ok("Cliente cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model,
            [FromServices] IClienteRepository repository,
            [FromServices] IMapper mapper)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = mapper.Map<Cliente>(model);
                    repository.Atualizar(cliente);

                    return Ok("Cliente atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IClienteRepository repository)
        {
            try
            {
                var cliente = repository.ObterPorId(id);
                repository.Excluir(cliente);

                return Ok("Cliente excluido com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IClienteRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var lista = mapper.Map<List<ClienteConsultaModel>>(repository.ObterTodos());

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id,
            [FromServices] IClienteRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var model = mapper.Map<ClienteConsultaModel>(repository.ObterPorId(id));

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
