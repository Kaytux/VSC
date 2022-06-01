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
        public string NomArmeAct { get; set; }
        [DataMember]
        public string NomArmePass { get; set; }
        [DataMember]
        public List<HashSet<StatDTO>> statsNiveau = new List<HashSet<StatDTO>>();
    }

    static class AmeliorationExtensions
    {
        public static Amelioration ToPOCO(this AmeliorationDTO dto)
            => new Amelioration(dto.Nom,
                                dto.Description,
                                dto.Image,
                                dto.particularites.ToPOCOs().ToHashSet(), 
                                dto.NomArmeAct,
                                dto.NomArmePass,
                                dto.statsNiveau.ToListHashSetPOCO());

        

        public static IEnumerable<Amelioration> ToPOCOs(this IEnumerable<AmeliorationDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static AmeliorationDTO ToDTO(this Amelioration poco)
            => new AmeliorationDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet(),
                NomArmeAct = poco.NomArmeAct,
                NomArmePass = poco.NomArmePass,
                statsNiveau = poco.statsNiveau.ToListHashSetDTO()
            };

        
        public static IEnumerable<AmeliorationDTO> ToDTOs(this IEnumerable<Amelioration> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
