using SW.DataAccessLayer;
using SW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services
{
    public class DivisionCitoyen
    {
        public CitoyenRepository CitoyenRepository { get; set; }

        public DivisionCitoyen(CitoyenRepository repository)
        {
            CitoyenRepository = repository;
        }

        public void AddCitoyen(Citoyen c)
        {
            // Règles de gestion
            // Age des parents, présence des parents, espèce, etc
            CitoyenRepository.AddCitoyen(c);
        }

        public List<Citoyen> GetCitoyens()
        {
            return CitoyenRepository.GetCitoyens();
        }

        public List<Citoyen> GetCitoyensByDivision(Division division)
        {
            return CitoyenRepository.GetCitoyensByDivision(division);
        }


        public string GetInfosCitoyen(int id)
        {
            Citoyen? citoyen = CitoyenRepository.GetCitoyens().FirstOrDefault(c => c.Id == id);

            if (citoyen == null)
            {
                return "Non trouvé, vérifiez l'id";
            }

            string infos = $@"
<td>{citoyen.Id}</td>
<td>{citoyen.Nom}</td>
<td>{citoyen.Prenom}</td>
<td>{citoyen.Age}</td>
    ";

            return infos;
        }
    }
}