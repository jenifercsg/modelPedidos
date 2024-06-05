using ProdutoAPI.Model;
using ProdutoAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.DTO
{
    public class PedidoRequest
    {
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        public Pedido toModel()
            => new Pedido(Quantidade, Data, ProdutoId);
    }
}
