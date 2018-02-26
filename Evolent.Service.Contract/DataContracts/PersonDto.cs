using System.Runtime.Serialization;

namespace Evolent.Service.Contract.DataContracts
{
    [DataContract]
    public class PersonDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FullName
        {
            get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        [DataMember]
        public ContactInformationDto ContactInformation { get; set; }

        [DataMember] 
        public bool IsActive { get; set; }
    }
}
