

using Microsoft.EntityFrameworkCore;
using RevendaPlus.Data;
using RevendaPlus.Models;
using RevendaPlus.Repositories.Interfaces;

namespace RevendaPlus.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly RevendaPlusDBContext _dbContext;
        public EstoqueRepository(RevendaPlusDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<EstoqueModel>> AllItensEstoque()
        {
            return await _dbContext.ItensEstoque.ToListAsync();
        }
        public async Task<EstoqueModel> GetById(int id)
        {
            return await _dbContext.ItensEstoque.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<EstoqueModel> Create(EstoqueModel estoque)
        {
            await _dbContext.ItensEstoque.AddAsync(estoque);
            await _dbContext.SaveChangesAsync();
            return estoque;
        }
        public async Task<EstoqueModel> Update(EstoqueModel estoque, int id)
        {
            EstoqueModel estoqueById = await GetById(id);
            if (estoqueById == null)
            {
                throw new Exception($"Estoque para ID: {id} não encontrado!");
            }
            estoqueById.id_produto = estoque.id_produto;
            estoqueById.quant_estoque = estoque.quant_estoque;

            _dbContext.ItensEstoque.Update(estoqueById);
            await _dbContext.SaveChangesAsync();

            return estoqueById;
        }

        public async Task<bool> Delete(int id)
        {
            EstoqueModel estoqueById = await GetById(id);
            if (estoqueById == null)
            {
                throw new Exception($"Estoque para ID: {id} não encontrado!");
            }

            _dbContext.ItensEstoque.Remove(estoqueById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
