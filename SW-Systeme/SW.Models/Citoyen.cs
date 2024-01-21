/*namespace SW.Models
{
    public class Citoyen
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public Espece Espece { get; set; }

       // Nouvelles propriétés pour les indicateurs
        public int Bonheur { get; set; }
        public int ProductionEconomique { get; set; }

        // Propriété pour représenter la division à laquelle le citoyen appartient
        //public string Division { get; set; }

        // sarra
        public Division division { get; set; }

        public int PereBiologiqueID { get; set; }

        public Citoyen? PereBiologique { get; set; }
        public int MereBiologiqueID { get; set; }
        public Citoyen? MereBiologique { get; set; }

    }
}*/

using SW.Models;

namespace SW.Models
{
    public class Citoyen
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public Sexe sexe { get; set; }
    public int Age { get; set; }
    public Espece Espece { get; set; }
    public Division? division { get; set; }
    public EventAleatoire? eventAleatoire { get; set; }
    public int Bonheur { get; set; }
    public int ProductionEconomique { get; set; }
    public int? PereBiologiqueID { get; set; }
    public Citoyen? PereBiologique { get; set; }
    public int? MereBiologiqueID { get; set; }
    public Citoyen? MereBiologique { get; set; }
    

}
}