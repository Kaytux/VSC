using BibliothequeClassesVSC;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

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
            => new Stat(dto.Nom, dto.Valeur);

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

        public static List<HashSet<StatDTO>> ToListHashSetDTO(this List<HashSet<Stat>> l)
        {
            List<HashSet<StatDTO>> res = new List<HashSet<StatDTO>>();
            foreach (var item in l)
            {
                res.Add(item.ToDTOs().ToHashSet());
            }
            return res;
        }

        public static List<HashSet<Stat>> ToListHashSetPOCO(this List<HashSet<StatDTO>> l)
        {
            List<HashSet<Stat>> res = new List<HashSet<Stat>>();
            foreach (var item in l)
            {
                res.Add(item.ToPOCOs().ToHashSet());
            }
            return res;
        }
    }
}
