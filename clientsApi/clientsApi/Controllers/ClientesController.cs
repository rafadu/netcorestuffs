using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace clientsApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private ILogger logger;
        public ClientesController(ILogger<ClientesController> logger){
            this.logger = logger;
        }

        [HttpGet]
        public JsonResult GetCliente(){
            logger.LogInformation($"Foram buscados {ClientesDB.GetDBAmount()}");
            List<Cliente> clientes = (List<Cliente>)ClientesDB.GetAll();
            return new JsonResult(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente(long id){
            Cliente cliente = ClientesDB.GetById(id);
            if(cliente == null)
                return NotFound();
                
            logger.LogInformation($"Foi buscado o cliente {cliente.nome}");
            return new JsonResult(cliente);
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody]Cliente cliente){
            logger.LogWarning($"O cliente ${cliente.id} doi inserido!");
            ClientesDB.AddCliente(cliente);
            return Ok();
        }

        [HttpPut]
        public IActionResult updateCliente([FromBody]Cliente cliente){
            Cliente temp = ClientesDB.GetById(cliente.id);
            if(temp == null)
                return NotFound();
            
            temp.nome = cliente.nome;
            temp.email = cliente.email;

            logger.LogInformation($"O cliente {temp.id} foi alterado!");
            return new JsonResult(temp);
        }

        public IActionResult deleteCliente(long id){
            Cliente temp = ClientesDB.GetById(id);
            if(temp == null)
                return NotFound();

            ClientesDB.deleteCliente(id);
            logger.LogInformation($"O cliente {id} foi excluido!");
            return Ok();
        }
    }
}