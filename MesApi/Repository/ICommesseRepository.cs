using MesApi.Models;

namespace MesApi.Repository
{
    public interface ICommesseRepository
    {

        Task<IEnumerable<Commesse>> GetCommesseAsync();
        Task<Commesse?> GetCommessaAsync(int CommessaId);
        Task<Commesse?> GetCommessaNomeAsync(string Commessa);
        Task<bool> SaveAllAsync();
        Task<bool> Delete(Commesse comm);
        Task<bool> InsertCommessaAsync(Commesse comm);
        Task<bool> UpdateCommessaAsync(Commesse comm);
        Task<bool> DeleteCommessa(Commesse comm);
          
         
    }
}