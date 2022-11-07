using API.Src.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Src.Controles
{
    [ApiController]
    [Route("")]
    [Produces("application/json")]
    public class TransferenciaControle : ControllerBase
    {
        private readonly ITransferenciaServico _servico;

        public TransferenciaControle(ITransferenciaServico servico)
        {
            _servico = servico;
        }

        /// <response code="200">Retorna tranferencia realizada com Sucesso!</response>
        /// <response code="400">Não encontrado para transferencia</response>
        /// <response code="404">Informações inseridas estão incorretas</response>
        [HttpPost("TransferenciaPix/transferencia/{chavePixOrigem}/{chavePixDestino}/{saldo}")]
        public ActionResult TransferenciaPix([FromRoute]string chavePixOrigem, [FromRoute] string chavePixDestino, [FromRoute] double saldo)
        {
            try
            {
                return Ok(_servico.TransferenciaPix(chavePixOrigem, chavePixDestino, saldo));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound (new { Mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        //Criado para que possa ser depositado um valor para o cliente cadastrado utilizando a chavePix deste.
        //(todo cliente cadastrado inicia com 0 de Saldo)
        //Com valor depositado para este cliente, então é possível realizar a transferenciaPix para outro cliente cadastrado.
        [HttpPost("depositar/{chavePix}/{valor}")]
        public ActionResult DepositarValor([FromRoute] string chavePix, [FromRoute] double valor)
        {
            try
            {
                return Ok(_servico.DepositarValorContaCliente(chavePix, valor));

            }
            catch (Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
    }
}