using System;
using System.Collections.Generic;

namespace clientsApi2.domain
{
    public class Pedido
    {
        public long id {get; set;}
        public DateTime dataPedido {get; private set;}
        public long idCliente {get; private set;}
        public List<ItemPedido> items {get; private set;}
        public StatusPedido status {get; private set;}

        public Pedido(){
            this.items = new List<ItemPedido>();
        }

        // public override bool Equals(object obj)
        // {
        //     Pedido pedido = (Pedido)obj;
        //     return this.id == pedido.id;
        // }

        public Pedido(long id, DateTime dataPedido, long idCliente, ItemPedido item){
           this.id = id;
           this.dataPedido = dataPedido;
           this.idCliente = idCliente;
           this.items = new List<ItemPedido>();
           this.items.Add(item); 
           this.status = StatusPedido.Aberto;
        }

        public void AtualizarStatus(StatusPedido novoStatus)
        {
            this.status = novoStatus;
        }
    }
}