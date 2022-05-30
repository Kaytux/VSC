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
    public class CarteDTO
    {
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public List<string> NomsEnnemies = new List<string>();
        [DataMember]
        public List<string> NomsArmesPass = new List<string>();
    }

    static class CarteExtensions
    {
        public static Carte ToPOCO(this CarteDTO dto)
            => new Carte(dto.Nom,
                         dto.Description,
                         dto.Image,
                         dto.NomsEnnemies,
                         dto.NomsArmesPass);

        public static IEnumerable<Carte> ToPOCOs(this IEnumerable<CarteDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static CarteDTO ToDTO(this Carte poco)
            => new CarteDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                NomsEnnemies = poco.NomEnn,
                NomsArmesPass = poco.NomArmPass};
        public static IEnumerable<CarteDTO> ToDTOs(this IEnumerable<Carte> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
