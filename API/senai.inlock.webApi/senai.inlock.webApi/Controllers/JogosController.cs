using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _JogoRepository { get; set; }

        public JogosController()
        {
            _JogoRepository = new JogoRepositorty();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List <JogoDomain> JogosListados = _JogoRepository.ListarTodos();

            return Ok(JogosListados);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            JogoDomain JogoBuscado = _JogoRepository.BuscarPorId(id);

            if (JogoBuscado == null)
            {
                return NotFound("Nehum Jogo encontrado");
            }
            return Ok(JogoBuscado);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]

        public IActionResult PutIdUrl(int id, JogoDomain NovoVeiculo)
        {
            JogoDomain VeiculoBuscado = _JogoRepository.BuscarPorId(id);

            if (VeiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Jogo Não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {
                _JogoRepository.AtualizarPorUrl(id, NovoVeiculo);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(JogoDomain NovoJogo)
        {
            _JogoRepository.Cadastrar(NovoJogo);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _JogoRepository.Deletar(id);

            return StatusCode(200);
        }
    }
}
