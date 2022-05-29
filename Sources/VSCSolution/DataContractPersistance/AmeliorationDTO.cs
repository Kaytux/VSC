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
    public class AmeliorationDTO
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public HashSet<StatDTO> particularites = new HashSet<StatDTO>();
        [DataMember]
        public string NomArmeAct { get; set; } = "";
        [DataMember]
        public string NomArmePass { get; set; } = "";
    }

    static class AmeliorationExtensions
    {
        public static Amelioration ToPOCO(this AmeliorationDTO dto, IEnumerable<ArmeActive> a, IEnumerable<ArmePassive> p)
            => new Amelioration(dto.Nom, 
                                dto.particularites.ToPOCOs().ToHashSet(), 
                                dto.Description, 
                                dto.Image,
                                1,
                                a.SingleOrDefault(ame => ame.Nom == dto.NomArmeAct),
                                p.SingleOrDefault(ame => ame.Nom == dto.NomArmePass));

        public static IEnumerable<Amelioration> ToPOCOs(this IEnumerable<AmeliorationDTO> dtos, IEnumerable<ArmeActive> a, IEnumerable<ArmePassive> p)
            => dtos.Select(dto => dto.ToPOCO(a,p));

        public static AmeliorationDTO ToDTO(this Amelioration poco)
            => new AmeliorationDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet()
            };
        public static IEnumerable<AmeliorationDTO> ToDTOs(this IEnumerable<Amelioration> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
