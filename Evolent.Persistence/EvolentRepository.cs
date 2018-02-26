using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evolent.DomainModel;
using Evolent.DomainModel.Models;

namespace Evolent.Persistence
{
    public class EvolentRepository : IEvolentRepository
    {
        public EvolentRepository()
        {

        }

        public Task<IEnumerable<Person>> GetAllContactsAsync()
        {
            //var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/file.txt"));
            var fileContents = System.IO.File.ReadAllText(@"~/App_Data/filename");

            throw new NotImplementedException();
        }

        public Task<Person> GetContactByIdAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<Person> SaveContactAsync(Person contact)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateContactAsync(Person contact)
        {
            throw new NotImplementedException();
        }

        public Task<Person> DeleteContactAsync(Person contact)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
