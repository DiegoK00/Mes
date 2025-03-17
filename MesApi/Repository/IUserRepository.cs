using MesApi.Models;

namespace MesApi.Repository
{
    public interface IUserRepository
    {

        Task<IEnumerable<Utenti>> GetUtentiAsync();
        // Task<Utenti?> GetUtenteAsync(int CommessaId);
        Task<Utenti?> GetUtenteAsync(string Commessa);
        Task<bool> SaveAllAsync();
        Task<bool> InsertAsync(Utenti user);
        Task<bool> UpdateAsync(Utenti user);
        Task<bool> DeleteUtente(Utenti user);


    }
}