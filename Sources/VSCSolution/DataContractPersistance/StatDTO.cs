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
    public class StatDTO
    {
        [DataMember]
        public Stat.NomStat Nom { get; set; }
        [DataMember]
        public int Valeur { get; set; }
    }

    static class StatExtensions
    {
        public static Stat ToPOCO(this StatDTO dto)
            => new Stat(dto.Nom,dto.Valeur);

        public static IEnumerable<Stat> ToPOCOs(this IEnumerable<StatDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        public static StatDTO ToDTO(this Stat poco)
            => new StatDTO
            {
                Nom = poco.Nom,
                Valeur = poco.Valeur,
            };
        public static IEnumerable<StatDTO> ToDTOs(this IEnumerable<Stat> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
