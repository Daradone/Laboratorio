using poc.domain.entities;
using poc.domain.interfaces;
using poc.application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace poc.application.services
{
    public class PersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonDto>> ListAsync()
        {
            var people = await _repository.GetAllAsync();
            return people.Select(p => new PersonDto { Id = p.Id, Nome = p.Nome });
        }

        public async Task<PersonDto?> GetAsync(Int64 id)
        {
            var p = await _repository.GetByIdAsync(id);
            return p == null ? null : new PersonDto { Id = p.Id, Nome = p.Nome };
        }

        public async Task AddAsync(PersonDto dto)
        {
            await _repository.AddAsync(new Person { Nome = dto.Nome });
        }

        public async Task UpdateAsync(PersonDto dto)
        {
            await _repository.UpdateAsync(new Person { Id = dto.Id, Nome = dto.Nome });
        }

        public async Task DeleteAsync(Int64 id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}