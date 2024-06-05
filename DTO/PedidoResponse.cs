using ProdutoAPI.Model;

namespace ProdutoAPI.DTO
{
    public class PedidoResponse
    {
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }

        public PedidoResponse(Pedido pedido)
        {
            Quantidade = pedido.Quantidade;
            Produto = pedido.Produto;
        }
    }
}
