

using Microsoft.EntityFrameworkCore;
using RevendaPlus.Data;
using RevendaPlus.Models;
using RevendaPlus.Repositories.Interfaces;

namespace RevendaPlus.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly RevendaPlusDBContext _dbContext;
        public VendaRepository(RevendaPlusDBContext revendaPlusDBContext)
        {
            _dbContext = revendaPlusDBContext;
        }
        public async Task<List<VendaModel>> AllVendas()
        {
            return await _dbContext.Vendas.ToListAsync();
        }
        public async Task<VendaModel> GetById(int id)
        {
            return await _dbContext.Vendas.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<VendaModel> Create(VendaModel venda)
        {
            var estoque = await _dbContext.ItensEstoque.FirstOrDefaultAsync(e => e.id == venda.id_produto);
            if (estoque != null)
            {
                estoque.quant_estoque -= venda.quant_vendida;
            }

            await _dbContext.Vendas.AddAsync(venda);
            await _dbContext.SaveChangesAsync();
            return venda;
        }

        public async Task<bool> Delete(int id)
        {
            VendaModel vendaById = await GetById(id);
            if (vendaById == null)
            {
                throw new Exception($"Venda para ID: {id} não encontrado!");
            }

            _dbContext.Vendas.Remove(vendaById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
