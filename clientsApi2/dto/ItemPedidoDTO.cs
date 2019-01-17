using clientsApi2.domain;

namespace clientsApi2.dto
{
    public class ItemPedidoDTO
    {
        public long idPedido {get; set;}
        public long idCliente {get; set;}
        public ItemPedido item {get; set;}
    }
}