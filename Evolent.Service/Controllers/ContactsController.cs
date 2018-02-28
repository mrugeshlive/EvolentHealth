using Evolent.Application.Contract;
using Evolent.Service.Contract.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
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

        [Route("v1/GetContactById/")]
        [HttpGet]
        public async Task<HttpResponseMessage> GetContactById(int contactId)
        {
            PersonDto contact = new PersonDto();
            try
            {
                contact = await _applicationService.GetContactByIdAsync(contactId).ConfigureAwait(false);
                return contact != null ?
                      Request.CreateResponse(HttpStatusCode.OK, contact) :
                      Request.CreateResponse(HttpStatusCode.NotFound, "Contact doesnot exists.");
            }
            catch (Exception ex)
            {
                return HandleException(ex, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllContacts()
        {
            List<PersonDto> allContacts = new List<PersonDto>();
            try
            {
                var response = await _applicationService.GetAllContacts().ConfigureAwait(false);
                allContacts.AddRange(response);

                return allContacts.Any() ?
                       Request.CreateResponse(HttpStatusCode.OK, allContacts) :
                       Request.CreateResponse(HttpStatusCode.NotFound, "No contacts found.");
            }
            catch (Exception ex)
            {
                return HandleException(ex, HttpStatusCode.InternalServerError);
            }
        }

        [Route("v1/SaveContact/")]
        [HttpPost]
        public async Task<HttpResponseMessage> SaveContact(PersonDto contactToSave)
        {
            try
            {
                var errorMessage = string.Empty;
                if (!ModelState.IsValid || !ValidateSaveRequest(contactToSave, out errorMessage))
                {
                    return HandleException(new Exception(string.Format("{0}{1}{2}", "Bad or Invalid request.", Environment.NewLine, errorMessage)),
                        HttpStatusCode.BadRequest);
                }

                var result = await _applicationService.SaveContactAsync(contactToSave).ConfigureAwait(false);
                return result ?
                       Request.CreateResponse(HttpStatusCode.OK, "Contact added successfully.") :
                       Request.CreateResponse(HttpStatusCode.NotFound, "Error while adding contact.");
            }
            catch (ArgumentException ex)
            {
                return HandleException(ex, HttpStatusCode.BadRequest);
            }
            catch (InvalidDataException ex)
            {
                return HandleException(ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return HandleException(ex, HttpStatusCode.InternalServerError);
            }
        }

        [Route("v1/DeleteContact/")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteContact(int id)
        {
            bool IsOperationSuccessfull = false;
            try
            {
                IsOperationSuccessfull = await _applicationService.DeleteContactAsync(id).ConfigureAwait(false);
                return IsOperationSuccessfull ?
                      Request.CreateResponse(HttpStatusCode.OK, "Contact deleted successfully.") :
                      Request.CreateResponse(HttpStatusCode.NotFound, "Error while deleting contact.");
            }
            catch (Exception ex)
            {
                return HandleException(ex, HttpStatusCode.InternalServerError);
            }
        }

        [Route("v1/UpdateContact/")]
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateContact(PersonDto contactToUpdate)
        {
            bool IsOperationSuccessfull = false;
            try
            {
                IsOperationSuccessfull = await _applicationService.UpdateContactAsync(contactToUpdate).ConfigureAwait(false);
                return IsOperationSuccessfull ?
                      Request.CreateResponse(HttpStatusCode.OK, "Contact updated successfully.") :
                      Request.CreateResponse(HttpStatusCode.NotFound, "Error while updating contact.");
            }
            catch (Exception ex)
            {
                return HandleException(ex, HttpStatusCode.InternalServerError);
            }
        }

        #region Private Methods
        private HttpResponseMessage HandleException(Exception exception, HttpStatusCode statusCode)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, (exception.InnerException ?? exception).Message);
        }

        private bool ValidateSaveRequest(PersonDto contactToSave, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (contactToSave == null)
            {
                errorMessage = "Null request.";
                return false;
            }
            if (contactToSave.Id == 0)
            {
                errorMessage = "request parameter missing : Id";
                return false;
            }
            if (string.IsNullOrWhiteSpace(contactToSave.FirstName))
            {
                errorMessage = "request parameter missing : FirstName";
                return false;
            }
            if (string.IsNullOrWhiteSpace(contactToSave.LastName))
            {
                errorMessage = "request parameter missing : LastName";
                return false;
            }
            if (contactToSave.ContactInformation == null)
            {
                errorMessage = "request parameter missing : ContactInformation";
                return false;
            }
            if (string.IsNullOrWhiteSpace(contactToSave.ContactInformation.EmailId) || !ValidateEmail(contactToSave.ContactInformation.EmailId))
            {
                errorMessage = "request parameter missing or invalid : ContactInformation.EmailId";
                return false;
            }
            if (string.IsNullOrWhiteSpace(contactToSave.ContactInformation.MobileNumber) || !ValidateMobileNumbaer(contactToSave.ContactInformation.MobileNumber))
            {
                errorMessage = "request parameter missing or invalid : ContactInformation.MobileNumber";
                return false;
            }
            return true;
        }

        private bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        private bool ValidateMobileNumbaer(string mobileno)
        {
            Regex regex = new Regex(@"(\d{1,2})?\-?\d{10}");
            Match match = regex.Match(mobileno);
            return match.Success;
        }
        #endregion
    }
}
