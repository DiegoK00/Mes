using MesApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace MesApi.Repository
{
    public class CommesseRepository(DataSourceContext context) : ICommesseRepository  // IMapper mapper) : ICommesseRepository
    {

        public async Task<IEnumerable<Commesse>> GetCommesseAsync()
        {
            return await context.Commesse.ToListAsync();
        }
        public async Task<Commesse?> GetCommessaAsync(int CommessaId)
        {
            return await context.Commesse.SingleOrDefaultAsync(x => x.Id == CommessaId);
        }
        public async Task<Commesse?> GetCommessaNomeAsync(string Commessa)
        {
            return await context.Commesse.SingleOrDefaultAsync(x => x.Name.Contains(Commessa));
        }

        public async Task<bool> SaveAllAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void UpdateRecord(Commesse comm)
        {
            context.Entry(comm).State = EntityState.Modified;
        }

        public async Task<bool> InsertAsync(Commesse comm)
        {
            context.Commesse.Add(new Commesse()
            {
                Name = comm.Name,
                Description = comm.Description,
                IdCliente = comm.IdCliente,
                Clienti = comm.Clienti,
            });
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Commesse comm)
        {
            context.Commesse.Update(comm);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Commesse comm)
        {
            context.Commesse.Remove(comm);
            return await context.SaveChangesAsync() > 0;
        }
    }
}