using BibliothequeClassesVSC;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataContractPersistanceVSC
{
    [DataContract]
    public class EnnemieDTO
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public HashSet<StatDTO> particularites = new HashSet<StatDTO>();
    }

    static class EnnemieExtensions
    {
        public static Ennemie ToPOCO(this EnnemieDTO dto)
            => new Ennemie(dto.Nom, dto.Description, dto.Image, dto.particularites.ToPOCOs().ToHashSet());

        public static IEnumerable<Ennemie> ToPOCOs(this IEnumerable<EnnemieDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static EnnemieDTO ToDTO(this Ennemie poco)
            => new EnnemieDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet()
            };
        public static IEnumerable<EnnemieDTO> ToDTOs(this IEnumerable<Ennemie> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
