using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RevendaPlus.Models;
using RevendaPlus.Repositories;
using RevendaPlus.Repositories.Interfaces;

namespace RevendaPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueController(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<EstoqueModel>>> AllItensEstoque()
        {
            List<EstoqueModel> itensestoque = await _estoqueRepository.AllItensEstoque();
            return Ok(itensestoque);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EstoqueModel>>> GetById(int id)
        {
            EstoqueModel itensestoque = await _estoqueRepository.GetById(id);
            return Ok(itensestoque);
        }
        [HttpPost]
        public async Task<ActionResult<EstoqueModel>> Create([FromBody] EstoqueModel estoqueModel)
        {
            EstoqueModel estoque = await _estoqueRepository.Create(estoqueModel);
            return Ok(estoque);
        }

        [HttpPut("id")]
        public async Task<ActionResult<EstoqueModel>> Update([FromBody] EstoqueModel estoqueModel, int id)
        {
            estoqueModel.id = id;
            EstoqueModel estoque = await _estoqueRepository.Update(estoqueModel, id);
            return Ok(estoque);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<EstoqueModel>> Delete(int id)
        {
            bool deleted = await _estoqueRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
