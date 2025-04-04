using MesApi.Dto;
using MesApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MesApi.Repository
{
    public class UserRepository(DataSourceContext context) : IUserRepository  // IMapper mapper) : IUserRepository
    {

        public async Task<List<Utenti>> GetUtentiAsync()
        {
            return await context.Utenti.ToListAsync();
        }
        public async Task<Utenti?> GetUtenteAsync(string user)
        {
            return await context.Utenti.AsNoTracking().SingleOrDefaultAsync(
                x => x.Username.ToLower().Equals(user.ToLower()));
        }
        public async Task<Utenti?> GetUtenteAsync(int Id)
        {
            return await context.Utenti.AsNoTracking().SingleOrDefaultAsync(
                x => x.Id == Id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateRecord(Utenti user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public async Task<bool> Delete(Utenti user)
        {
            context.Utenti.Remove(user);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertAsync(Utenti user)
        {
            context.Utenti.Add(user);
            return await context.SaveChangesAsync() > 0;
        }

        // public async Task<bool> UpdateAsync(Utenti user)
        // {
        //     context.Utenti.Update();

        //     return await context.SaveChangesAsync() > 0;            
        // }

        public async Task<bool> UpdateAsync(Utenti user)
        {
            context.Utenti.Update(user);

            return await context.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteUtente(Utenti user)
        {
            context.Utenti.Remove(user);
            return await context.SaveChangesAsync() > 0;
        }
    }
}