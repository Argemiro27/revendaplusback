using RevendaPlus.Models;

namespace RevendaPlus.Repositories.Interfaces
{
    public interface IVendaRepository
    {
        Task<List<VendaModel>> AllVendas();
        Task<VendaModel> GetById(int id);
        Task<VendaModel> Create(VendaModel produto);
        Task<bool> Delete(int id);
    }
}
