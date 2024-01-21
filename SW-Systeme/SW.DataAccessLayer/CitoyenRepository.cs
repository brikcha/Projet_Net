using Microsoft.EntityFrameworkCore;
using SW.Models;

namespace SW.DataAccessLayer
{
    public class CitoyenRepository
    {
        public StarWarsDBContext SWDbContext { get; set; }
        public CitoyenRepository(
            StarWarsDBContext starWarsDBContext // Le StarWarsDBContext est injecté grâce au program.cs
        )
        {
            SWDbContext = starWarsDBContext;
        }

        public void AddCitoyen(Citoyen citoyen)
        {
            // Ajout du citoyen dans le contexte des citoyens
            SWDbContext.Citoyens.Add(citoyen);

            // Sauvegarde des changements en base
            SWDbContext.SaveChanges();
        }

        public List<Citoyen> GetCitoyens()
        {
            return SWDbContext.Citoyens.ToList();
        }

        // Nouvelle méthode pour récupérer les citoyens avec les informations nécessaires
        public List<Citoyen> GetCitoyensWithIndicators()
        {
            return SWDbContext.Citoyens
                .Include(c => c.Espece)
                .Include(c => c.PereBiologique)
                .Include(c => c.MereBiologique)
                .ToList();
        }

        // sarra affichage des citoyens par division

        public List<Citoyen> GetCitoyensByDivision(Division division)
        {
            var citoyens = SWDbContext.Citoyens
             .Where(c => c.division == division)
             .ToList();

            return citoyens;
        }
    }
}