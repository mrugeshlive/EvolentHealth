using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Evolent.Service.Contract.DataContracts
{
    [DataContract]
    public class PersonDto
    {
        [DataMember]
        [Required]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        public string LastName { get; set; }

        [DataMember]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        [DataMember]
        [Required]
        public ContactInformationDto ContactInformation { get; set; }

        [DataMember]
        public bool IsActive { get; set; }
    }
}
