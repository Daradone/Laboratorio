using poc.domain.entities;
using poc.domain.interfaces;
using poc.infrastructure.context;
using Microsoft.EntityFrameworkCore;

namespace poc.infrastructure.repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly pocDbContext _context;

        public PersonRepository(pocDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync() => await _context.TB001.ToListAsync();

        public async Task<Person?> GetByIdAsync(Int64 id) => await _context.TB001.FindAsync(id);

        public async Task AddAsync(Person person)
        {
            _context.TB001.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.TB001.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Int64 id)
        {
            var p = await _context.TB001.FindAsync(id);
            if (p != null)
            {
                _context.TB001.Remove(p);
                await _context.SaveChangesAsync();
            }
        }
    }
}