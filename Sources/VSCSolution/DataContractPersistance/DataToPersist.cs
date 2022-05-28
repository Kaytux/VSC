using BibliothequeClassesVSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataContractPersistanceVSC
{
    [DataContract]
    public class DataToPersist
    {
        [DataMember]
        public List<ArmePassive> Ap { get; set; } = new List<ArmePassive>();
        [DataMember]
        public List<ArmeActive> Aa { get; set; } = new List<ArmeActive>();
        [DataMember]
        public List<Amelioration> Am { get; set; } = new List<Amelioration>();
        [DataMember]
        public List<Personnage> Pe { get; set; } = new List<Personnage>();
        [DataMember]
        public List<Ennemie> En { get; set; } = new List<Ennemie>();
        [DataMember]
        public List<Carte> Ca { get; set; } = new List<Carte>();
    }
}
