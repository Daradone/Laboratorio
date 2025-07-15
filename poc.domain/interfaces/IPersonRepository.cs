using poc.domain.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace poc.domain.interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllAsync();
        Task<Person?> GetByIdAsync(Int64 id);
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Int64 id);
    }
}