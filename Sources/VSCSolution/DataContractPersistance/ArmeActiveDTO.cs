using BibliothequeClassesVSC;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataContractPersistanceVSC
{
    [DataContract]
    public class ArmeActiveDTO
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

    static class ArmeActiveExtensions
    {
        public static ArmeActive ToPOCO(this ArmeActiveDTO dto)
            => new ArmeActive(dto.Nom,
                               dto.Description,
                               dto.Image,
                               dto.particularites.ToPOCOs().ToHashSet(),
                               dto.statsNiveau.ToListHashSetPOCO());
        public static IEnumerable<ArmeActive> ToPOCOs(this IEnumerable<ArmeActiveDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static ArmeActiveDTO ToDTO(this ArmeActive poco)
            => new ArmeActiveDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet(),
                statsNiveau = poco.statsNiveau.ToListHashSetDTO()
            };
        public static IEnumerable<ArmeActiveDTO> ToDTOs(this IEnumerable<ArmeActive> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
