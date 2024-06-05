using ProdutoAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace ProdutoAPI.DTO
{
    public class CategoriaRequest
    {
        [MinLength(5)]
        public string Nome { get; set; }

        public Categoria toModel()
            => new Categoria(Nome);
    }
}
