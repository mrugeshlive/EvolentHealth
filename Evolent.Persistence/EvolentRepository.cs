using Evolent.DomainModel;
using Evolent.DomainModel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Evolent.Persistence
{
    public class EvolentRepository : IEvolentRepository
    {
        private string DataFile = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/Contacts.json");

        public EvolentRepository()
        {

        }

        public async Task<IEnumerable<Person>> GetAllContactsAsync()
        {
            var contacts = await GetContactsFromFile().ConfigureAwait(false);
            return contacts.OrderBy(cntc => cntc.Id).ToList() ?? new List<Person>();
        }

        public async Task<Person> GetContactByIdAsync(int contactId)
        {
            var contacts = await GetContactsFromFile().ConfigureAwait(false);
            var searchedContact = contacts.FirstOrDefault(cntc => cntc.Id == contactId);
            return searchedContact;
        }

        public async Task<bool> SaveContactAsync(Person contact)
        {
            var contacts = await GetContactsFromFile().ConfigureAwait(false);

            if (contacts.Any(cntc => cntc.Id == contact.Id))
                throw new ArgumentException("Contact already exsists.");
            contacts.Add(contact);
            return await WriteContactsToFile(contacts).ConfigureAwait(false);
        }

        public async Task<bool> UpdateContactAsync(Person contact)
        {
            var contacts = await GetContactsFromFile().ConfigureAwait(false);
            var contcatToUpdate = contacts.FirstOrDefault(cntc => cntc.Id == contact.Id);

            if (contcatToUpdate == null)
                throw new ArgumentException("Contact doesnot exsists.");

            var index = contacts.IndexOf(contcatToUpdate);
            contacts.RemoveAt(index);
            contacts.Insert(index, contact);
            return await WriteContactsToFile(contacts).ConfigureAwait(false);
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var contacts = await GetContactsFromFile().ConfigureAwait(false);
            var contcatToDelete = contacts.FirstOrDefault(cntc => cntc.Id == contactId);
            if (contcatToDelete == null)
                throw new ArgumentException("Contact doesnot exsists.");

            contacts.Remove(contcatToDelete);
            return await WriteContactsToFile(contacts).ConfigureAwait(false);
        }

        public void Dispose()
        {
            // To dispose of the context while working with database.
        }

        private Task<List<Person>> GetContactsFromFile()
        {
            var jsonRawData = File.ReadAllText(DataFile);
            return !string.IsNullOrWhiteSpace(jsonRawData) ?
                   Task.FromResult(JsonConvert.DeserializeObject<List<Person>>(jsonRawData)) :
                   Task.FromResult(new List<Person>());
        }

        private Task<bool> WriteContactsToFile(List<Person> contacts)
        {
            try
            {
                string jsonResult = JsonConvert.SerializeObject(contacts, Formatting.Indented);
                File.WriteAllText(DataFile, jsonResult);
                return Task.FromResult(true);
            }
            catch
            {

                return Task.FromResult(false);
            }

        }

    }
}
