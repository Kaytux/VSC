using System.Diagnostics.CodeAnalysis;

namespace BibliothequeClassesVSC
{
    public abstract class Element
    {
        /// <summary>
        /// constructeur de la classe abstraite Element
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="desc"></param>
        /// <param name="image"></param>
        public Element(string nom, string desc, string image)
        {
            Nom = nom;
            Description = desc;
            Image = image;
        }

        /// <summary>
        /// declaration de l'attribut Nom avec son getter et setter
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// declaration de l'attribut Description avec son getter et setter
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// declaration de l'attribut Image (chemin d'acces vers l'image) avec getter et setter
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// fonction de protocole d'égalité entre deux Element
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals([AllowNull] Element other)
        {
            return this.GetType().Equals(other.GetType()) && this.Nom.Equals(other.Nom);
        }
        /// <summary>
        /// surcharge du Equal de Element
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals(obj as Stat);
        }
        /// <summary>
        /// surcharge du GetHashCode de Element
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode() * this.GetType().GetHashCode();
        }
        /// <summary>
        /// surcharge du ToString de Element
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Nom.ToString();
        }
    }
}
