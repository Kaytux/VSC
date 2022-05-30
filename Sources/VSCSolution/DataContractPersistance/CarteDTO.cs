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
        public static Carte ToPOCO(this CarteDTO dto, IEnumerable<Ennemie> e, IEnumerable<ArmePassive> a)
            => new Carte(dto.Nom,
                         (from en in e
                         join nom in dto.NomsEnnemies on en.Nom equals nom
                         select en).ToList(),
                         (from ap in a
                         join nom in dto.NomsArmesPass on ap.Nom equals nom
                         select ap).ToList(),
                         dto.Description,
                         dto.Image);

        public static IEnumerable<Carte> ToPOCOs(this IEnumerable<CarteDTO> dtos, IEnumerable<Ennemie> e, IEnumerable<ArmePassive> a)
            => dtos.Select(dto => dto.ToPOCO(e,a));

        public static CarteDTO ToDTO(this Carte poco)
            => new CarteDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                NomsEnnemies = (from en in poco.LesEnnemies
                                select en.Nom).ToList(),
                NomsArmesPass = (from ap in poco.LesObjetsCaches
                                select ap.Nom).ToList(),
            };
        public static IEnumerable<CarteDTO> ToDTOs(this IEnumerable<Carte> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
