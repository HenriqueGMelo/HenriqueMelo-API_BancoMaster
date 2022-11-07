using API.Src.Modelos;
using API.Src.Repositorios;
using API.Src.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Src.Controles
{
    [ApiController]
    [Route("")]
    [Produces("application/json")]
    public class ClienteControle : ControllerBase
    {
        private readonly IClienteServico _servico;

        public ClienteControle(IClienteServico servico)
        {
            _servico = servico;
        }

        /// <response code="200">Retorna cliente no qual buscou</response>
        /// <response code="401">Retorna cliente não encontrado</response>
        [HttpGet("ConsultarCliente/documento/{documento}")]
        public ActionResult ConsultarCliente([FromRoute]int documento)
        {
            try
            {
                return Ok(_servico.ConsultarCliente(documento)); 
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        /// <response code="201">Retorna o cliente cadastrado</response>
        /// <response code="404">Erro no cadastro</response>
        [HttpPost("CriarCliente/cliente/{chavePixAleatoria}")]
        public ActionResult CadastrarCliente([FromBody] ClienteModelo cliente, [FromRoute] bool chavePixAleatoria = true)
        {
            try
            {
                return Ok(_servico.CadastrarCliente(cliente, chavePixAleatoria));
            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
    }
}