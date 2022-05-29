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
        public string NomAmelioration { get; set; } = "";
    }

    static class ArmeActiveExtensions
    {
        public static ArmeActive ToPOCO(this ArmeActiveDTO dto, IEnumerable<Amelioration> a)
            => new ArmeActive(dto.Nom,
                               dto.particularites.ToPOCOs().ToHashSet(),
                               dto.Description,
                               dto.Image,
                               1,
                               a.SingleOrDefault(ame => ame.Nom == dto.NomAmelioration));

        public static IEnumerable<ArmeActive> ToPOCOs(this IEnumerable<ArmeActiveDTO> dtos, IEnumerable<Amelioration> a)
            => dtos.Select(dto => dto.ToPOCO(a));

        public static ArmeActiveDTO ToDTO(this ArmeActive poco)
            => new ArmeActiveDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet()
            };
        public static IEnumerable<ArmeActiveDTO> ToDTOs(this IEnumerable<ArmeActive> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
