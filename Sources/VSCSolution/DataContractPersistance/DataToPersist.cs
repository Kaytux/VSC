using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContractPersistanceVSC
{
    [DataContract]
    public class DataToPersist
    {
        /// <summary>
        /// Déclaration des collections d'éléments à serializer
        /// </summary>
        [DataMember]
        public List<ArmePassiveDTO> Ap { get; set; } = new List<ArmePassiveDTO>();
        [DataMember]
        public List<ArmeActiveDTO> Aa { get; set; } = new List<ArmeActiveDTO>();
        [DataMember]
        public List<AmeliorationDTO> Am { get; set; } = new List<AmeliorationDTO>();
        [DataMember]
        public List<PersonnageDTO> Pe { get; set; } = new List<PersonnageDTO>();
        [DataMember]
        public List<EnnemieDTO> En { get; set; } = new List<EnnemieDTO>();
        [DataMember]
        public List<CarteDTO> Ca { get; set; } = new List<CarteDTO>();
        [DataMember]
        public Dictionary<ulong, Dictionary<string, string>> No { get; set; } = new Dictionary<ulong, Dictionary<string, string>>();
    }
}
