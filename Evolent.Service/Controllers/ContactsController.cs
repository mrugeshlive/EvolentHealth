using Evolent.Application;
using Evolent.Application.Contract;
using Evolent.Service.Contract.DataContracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;

namespace Evolent.Service.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IEvolentApplicationService _applicationService;


        public ContactsController(IEvolentApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<PersonDto> GetContactById(int contactId)
        {
            PersonDto contact = null;
            try
            {
                contact = await _applicationService.GetContactByIdAsync(contactId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return contact;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> GetAllContacts()
        {
            List<PersonDto> allContacts = null;
            try
            {
                var response = await _applicationService.GetAllContacts().ConfigureAwait(false);
                allContacts.AddRange(response);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return allContacts;
        }

        [HttpPost]
        public async Task<PersonDto> SaveContact(PersonDto contactToSave)
        {
            PersonDto contact = null;
            try
            {
                contact = await _applicationService.SaveContactAsync(contactToSave).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return contact;
        }

        [HttpDelete]
        public async Task<bool> DeleteContact(int id)
        {
            bool IsOperationSuccessfull = false;
            try
            {
                IsOperationSuccessfull = await _applicationService.DeleteContactAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return IsOperationSuccessfull;

        }

        [HttpPut]
        public async Task<PersonDto> UpdateContact(PersonDto contactToUpdate)
        {
            PersonDto contact = null;
            try
            {
                contact = await _applicationService.UpdateContactAsync(contactToUpdate).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return contact;
        }

        private void HandleException(Exception exception, [CallerMemberName]string methodName = "")
        {
            //TODO:logging exception.
            throw exception;
        }
    }
}
