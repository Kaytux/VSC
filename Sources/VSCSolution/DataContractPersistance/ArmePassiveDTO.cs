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
        public string NomAmelioration { get; set; } = "";
    }

    static class ArmePassiveExtensions
    {
        public static ArmePassive ToPOCO(this ArmePassiveDTO dto, IEnumerable<Amelioration> a)
            => new ArmePassive(dto.Nom,
                               dto.particularites.ToPOCOs().ToHashSet(),
                               dto.Description,
                               dto.Image,
                               1,
                               a.SingleOrDefault(ame => ame.Nom == dto.NomAmelioration));

        public static IEnumerable<ArmePassive> ToPOCOs(this IEnumerable<ArmePassiveDTO> dtos, IEnumerable<Amelioration> a)
            => dtos.Select(dto => dto.ToPOCO(a));

        public static ArmePassiveDTO ToDTO(this ArmePassive poco)
            => new ArmePassiveDTO
                {
                    Nom = poco.Nom,
                    Description = poco.Description,
                    Image = poco.Image,
                    particularites = poco.particularites.ToDTOs().ToHashSet()
                };
        public static IEnumerable<ArmePassiveDTO> ToDTOs(this IEnumerable<ArmePassive> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
