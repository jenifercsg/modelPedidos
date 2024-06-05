using ProdutoAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.Model
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }



        public Pedido(int quantidade, DateTime data, int produtoId)
        {
            Quantidade = quantidade;
            Data = data;
            ProdutoId = produtoId;
        }
    }
}
