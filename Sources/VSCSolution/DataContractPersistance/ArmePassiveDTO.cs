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
    public class ArmePassiveDTO
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
        public List<HashSet<StatDTO>> statsNiveau = new List<HashSet<StatDTO>>();
    }

    static class ArmePassiveExtensions
    {
        public static ArmePassive ToPOCO(this ArmePassiveDTO dto)
            => new ArmePassive(dto.Nom,
                               dto.Description,
                               dto.Image,
                               dto.particularites.ToPOCOs().ToHashSet(),
                               dto.statsNiveau.ToListHashSetPOCO());

        public static IEnumerable<ArmePassive> ToPOCOs(this IEnumerable<ArmePassiveDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static ArmePassiveDTO ToDTO(this ArmePassive poco)
            => new ArmePassiveDTO
                {
                    Nom = poco.Nom,
                    Description = poco.Description,
                    Image = poco.Image,
                    particularites = poco.particularites.ToDTOs().ToHashSet(),
                    statsNiveau = poco.statsNiveau.ToListHashSetDTO()
                };
        public static IEnumerable<ArmePassiveDTO> ToDTOs(this IEnumerable<ArmePassive> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
