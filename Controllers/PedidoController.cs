using ProdutoAPI.Context;
using ProdutoAPI.DTO;
using ProdutoAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProdutoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public PedidoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {
            var pedidos = _dataContext.Pedido.ToList<Pedido>();
            return pedidos;
        }

        // GET api/<PedidoaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PedidoController>
        [HttpPost]
        public ActionResult<Pedido> Post([FromBody] PedidoRequest pedidoRequest)
        {
            if (ModelState.IsValid)
            {
                var pedido = pedidoRequest.toModel();
                _dataContext.Pedido.Add(pedido);
                _dataContext.SaveChanges();
                return pedido;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<PedidoController>/5
        [HttpPut]
        public ActionResult<Pedido> Put([FromBody] Pedido pedido)
        {
            var pedidoENulo = _dataContext.Pedido.FirstOrDefault(pedido) == null;
            if (pedidoENulo)
                ModelState.AddModelError("PedidoId", "Id do pedido não encontrado");

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Update(pedido);
                _dataContext.SaveChanges();
                return pedido;
            }
            return BadRequest(ModelState);

        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pedido = _dataContext.Pedido.Find(id);
            if (pedido == null)
                ModelState.AddModelError("PedidoId", "Id do pedido não encontr");

            if (ModelState.IsValid)
            {
                _dataContext.Pedido.Remove(pedido);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
