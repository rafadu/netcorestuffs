namespace clientsApi2.domain
{
    public class ItemPedido
    {
        public long idProduto {get; set;}
        public long quantidade {get; set;}

        // public override bool Equals(object obj){
        //     ItemPedido item = (ItemPedido)obj;
        //     return this.idProduto == item.idProduto;
        // }
    }
}