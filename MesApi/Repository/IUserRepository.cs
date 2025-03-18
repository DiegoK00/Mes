using MesApi.Models;

namespace MesApi.Repository
{
    public interface IUserRepository
    {

        Task<IEnumerable<Utenti>> GetUtentiAsync();
        // Task<Utenti?> GetUtenteAsync(int CommessaId);
        Task<Utenti?> GetUtenteAsync(string user);
        Task<bool> SaveAllAsync();
        Task<bool> InsertAsync(Utenti user);
        Task<bool> UpdateAsync(Utenti uUser);
        Task<bool> DeleteUtente(Utenti user);
    }

}
