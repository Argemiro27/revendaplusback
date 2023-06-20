using RevendaPlus.Models;

namespace RevendaPlus.Repositories.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<List<EstoqueModel>> AllItensEstoque();
        Task<EstoqueModel> GetById(int id);
        Task<EstoqueModel> Create(EstoqueModel produto);
        Task<EstoqueModel> Update(EstoqueModel produto, int id);
        Task<bool> Delete(int id);
    }
}
