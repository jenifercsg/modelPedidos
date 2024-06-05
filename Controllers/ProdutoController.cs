
using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.Context;
using ProdutoAPI.DTO;
using ProdutoAPI.Model;

namespace Ecommerce3Ads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private DataContext _dataContext;

        public ProdutoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            var produtos = _dataContext.Produto.ToList<Produto>();
            return produtos;
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public ActionResult<Produto> Post([FromBody] ProdutoRequest produtoRequest)
        {
            if (ModelState.IsValid)
            {
                var produto = produtoRequest.toModel();
                _dataContext.Produto.Add(produto);
                _dataContext.SaveChanges();
                return produto;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public ActionResult<Produto> Put([FromBody] Produto produto)
        {
            var produtoENulo = _dataContext.Produto.FirstOrDefault(produto) == null;
            if (produtoENulo)
                ModelState.AddModelError("ProdutoId", "Id da Produto não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Produto.Update(produto);
                _dataContext.SaveChanges();
                return produto;
            }
            return BadRequest(ModelState);

        }

        // DELETE api/<produtoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var produto = _dataContext.Produto.Find(id);
            if (produto == null)
                ModelState.AddModelError("ProdutoId", "Id da Produto não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Produto.Remove(produto);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
