using Evolent.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evolent.DomainModel
{
    public interface IEvolentRepository : IDisposable
    {
        Task<IEnumerable<Person>> GetAllContactsAsync();
        Task<Person> GetContactByIdAsync(int contactId);
        Task<Person> SaveContactAsync(Person contact);
        Task<Person> DeleteContactAsync(Person contact);
        Task<Person> UpdateContactAsync(Person contact);
    }
}
