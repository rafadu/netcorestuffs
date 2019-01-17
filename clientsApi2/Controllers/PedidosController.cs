using System;
using System.Collections.Generic;
using System.Linq;
using clientsApi2.domain;
using clientsApi2.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace clientsApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private static List<Pedido> pedidosMock = new List<Pedido>();
        private static long contadorErroCaotico;
        protected readonly ILogger<PedidosController> _logger;
        public PedidosController(ILogger<PedidosController> logger){
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Pedido>> buscarPedidos(){
            _logger.LogInformation("foram buscados todos os pedidos!");
            return Ok(pedidosMock);
        }

        [HttpGet("pedido/{id}")]
        public ActionResult<List<Pedido>> buscarPedidosPorCliente(long id){
            var result = pedidosMock.Where(p => p.idCliente == id).ToList();
            _logger.LogInformation($"cliente {id} possui {result.Count} pedidos");
            return Ok(result);
        }

        [HttpPost("item/adiciona")]
        public ActionResult adicionaItemPedido([FromBody]ItemPedidoDTO pedido){
            contadorErroCaotico++;
            if ((contadorErroCaotico) % 7 == 0)
                throw new ApplicationException("Ocorreu um erro caotico");
            if(pedidosMock.Any(p => p.id == pedido.idPedido))
                pedidosMock.FirstOrDefault(p => p.id == pedido.idCliente).items.Add(pedido.item);
            else{
                Pedido pedidoNovo = new Pedido(pedido.idPedido,DateTime.Now,pedido.idCliente,pedido.item);
                pedidosMock.Add(pedidoNovo);
            }

            _logger.LogInformation($"pedido {pedido.idPedido} do cliente {pedido.idCliente} adicionou o produto {pedido.item.idProduto}");
            return Ok();
        }   

        [HttpDelete("item/remove")]
        public ActionResult removeItemPedido([FromBody]ItemPedidoDTO item){
            if(pedidosMock.Any(p => p.id == item.idPedido))
            {
                pedidosMock.First(p => p.id == item.idPedido).items.Remove(item.item);
                _logger.LogInformation($"pedido {item.idPedido} do cliente {item.idCliente} removeu o produto {item.item.idProduto}");
            }

            return Ok();
        }

        [HttpPut("pedido/{id}")]
        public ActionResult pagaPedido(long id){
            if(pedidosMock.Any(p => p.id == id))
            {
                pedidosMock.First(p => p.id == id).AtualizarStatus(StatusPedido.Concluido);
                _logger.LogInformation($"pedido {id} efetivado");
                return Ok();
            }   
            else{
                return BadRequest("Pedido não existe.");
            } 
        }

        [HttpDelete("pedido/{id}")]
        public ActionResult cancelaPedido(long id){
            if(!pedidosMock.Any(p => p.id == id))
                return BadRequest("Pedido não existe");
            
            pedidosMock.First(p => p.id == id).AtualizarStatus(StatusPedido.Cancelado);
            _logger.LogInformation($"pedido {id} cancelado");
            return Ok();
        }
    }
}