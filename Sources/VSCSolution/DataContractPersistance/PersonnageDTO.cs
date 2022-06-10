using BibliothequeClassesVSC;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace DataContractPersistanceVSC
{
    [DataContract]
    public class PersonnageDTO
    {
        /// <summary>
        /// Déclarations des attributs à sauvegarder dans l'élément DTO
        /// </summary>
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }
        [DataMember]
        public HashSet<StatDTO> particularites = new HashSet<StatDTO>();
        [DataMember]
        public string NomArme { get; set; }
    }

    static class PersonnageExtensions
    {
        /// <summary>
        /// Méthode transformant un élément DTO en POCO
        /// </summary>
        /// <param name="dto">Elément DTO à transformer</param>
        /// <returns></returns>
        public static Personnage ToPOCO(this PersonnageDTO dto)
            => new Personnage(dto.Nom, dto.Description, dto.Image, dto.particularites.ToPOCOs().ToHashSet(), dto.NomArme);

        /// <summary>
        /// Méthode transformant une collection d'élément DTO en collection de POCO
        /// </summary>
        /// <param name="dtos">Collection d'élément DTO à transformer</param>
        /// <returns></returns>
        public static IEnumerable<Personnage> ToPOCOs(this IEnumerable<PersonnageDTO> dtos)
            => dtos.Select(dto => dto.ToPOCO());

        /// <summary>
        /// Méthode transformant un élément POCO en DTO
        /// </summary>
        /// <param name="poco">Elément POCO à transformer</param>
        /// <returns></returns>
        public static PersonnageDTO ToDTO(this Personnage poco)
            => new PersonnageDTO
            {
                Nom = poco.Nom,
                Description = poco.Description,
                Image = poco.Image,
                particularites = poco.particularites.ToDTOs().ToHashSet(),
                NomArme = poco.Arme.Nom
            };

        /// <summary>
        /// Méthode transformant une collection d'élément POCO en collection de DTO
        /// </summary>
        /// <param name="pocos">Collection d'élément POCO à transformer</param>
        /// <returns></returns>
        public static IEnumerable<PersonnageDTO> ToDTOs(this IEnumerable<Personnage> pocos)
            => pocos.Select(poco => poco.ToDTO());
    }
}
