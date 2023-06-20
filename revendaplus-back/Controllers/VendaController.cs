using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevendaPlus.Models;
using RevendaPlus.Repositories;
using RevendaPlus.Repositories.Interfaces;

namespace RevendaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaController(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<VendaModel>>> AllVendas()
        {
            List<VendaModel> vendas = await _vendaRepository.AllVendas();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<VendaModel>>> GetById(int id)
        {
            VendaModel vendas = await _vendaRepository.GetById(id);
            return Ok(vendas);
        }
        [HttpPost]
        public async Task<ActionResult<VendaModel>> Create([FromBody] VendaModel vendaModel)
        {
            VendaModel venda = await _vendaRepository.Create(vendaModel);
            return Ok(venda);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<VendaModel>> Delete(int id)
        {
            bool deleted = await _vendaRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
