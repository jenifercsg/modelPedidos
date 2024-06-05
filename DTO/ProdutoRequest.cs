using ProdutoAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.DTO
{
    public class ProdutoRequest
    {
        [MinLength(5)]
        public string Nome { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public Produto toModel()
            => new Produto(Nome, CategoriaId);
    }
}
