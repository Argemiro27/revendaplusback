using Microsoft.EntityFrameworkCore;
using RevendaPlus.Data;
using RevendaPlus.Models;
using RevendaPlus.Repositories.Interfaces;

namespace RevendaPlus.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly RevendaPlusDBContext _dbContext;
        public ProdutoRepository(RevendaPlusDBContext sistemaVendasDBContext)
        {
            _dbContext = sistemaVendasDBContext;
        }
        public async Task<List<ProdutoModel>> AllProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> GetById(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<ProdutoModel> Create(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }
        public async Task<ProdutoModel> Update(ProdutoModel produto, int id)
        {
            ProdutoModel produtoById = await GetById(id);
            if (produtoById == null)
            {
                throw new Exception($"Produto para ID: {id} não encontrado!");
            }
            produtoById.nome_produto = produto.nome_produto;
            produtoById.categoria = produto.categoria;
            produtoById.taxa_lucro = produto.taxa_lucro;
            produtoById.preco_unit_compra = produto.preco_venda;
            produtoById.preco_venda = produto.preco_venda;
            produtoById.sku = produto.sku;
            produtoById.quantidade = produto.quantidade;
            produtoById.preco_total_compra = produto.preco_total_compra;
            produtoById.data_hora = produto.data_hora;

            _dbContext.Produtos.Update(produtoById);
            await _dbContext.SaveChangesAsync();

            return produtoById;
        }

        public async Task<bool> Delete(int id)
        {
            ProdutoModel produtoById = await GetById(id);
            if (produtoById == null)
            {
                throw new Exception($"Produto para ID: {id} não encontrado!");
            }

            _dbContext.Produtos.Remove(produtoById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
