using Microsoft.AspNetCore.Mvc;
using SW.Models;
using SW.Services;
using SW.Web.ViewModels; // Assurez-vous que le namespace est correct

namespace SW.Web.Controllers
{
    public class IndicateurController : Controller
    {
        private readonly IndicateurService _indicateurService;
        private readonly DivisionCitoyen _divisionCitoyen; // Assurez-vous d'avoir la classe DivisionCitoyen injectée

        public IndicateurController(IndicateurService indicateurService, DivisionCitoyen divisionCitoyen)
        {
            _indicateurService = indicateurService;
            _divisionCitoyen = divisionCitoyen;
        }

        public IActionResult Index()
        {
            // Obtenez vos citoyens (par exemple, à partir du service de division citoyen)
            var citoyens = _divisionCitoyen.GetCitoyens();

            var populationTotale = _indicateurService.CalculerPopulationTotale(citoyens);
            var bonheurMoyen = _indicateurService.CalculerBonheurMoyen(citoyens);
            var productionEconomique = _indicateurService.CalculerProductionEconomiqueTotale(citoyens);
            //var populationParDivision = _indicateurService.CalculerPopulationParDivision(citoyens, "DivisionX");
            var populationParDivision = _indicateurService.CalculerPopulationParDivision(citoyens, Division.Fonctionnaire);
            var bonheurMoyenParDivision = _indicateurService.CalculerBonheurMoyenParDivision(citoyens, Division.Professionnel);
            var productionEconomiqueParDivision = _indicateurService.CalculerProductionEconomiqueTotaleParDivision(citoyens, Division.Travailleur);
            //var bonheurMoyenParDivision = _indicateurService.CalculerBonheurMoyenParDivision(citoyens, "DivisionX");
            //var productionEconomiqueParDivision = _indicateurService.CalculerProductionEconomiqueTotaleParDivision(citoyens, "DivisionX");

            var model = new IndicateursViewModel
            {
                PopulationTotale = populationTotale,
                BonheurMoyen = bonheurMoyen,
                ProductionEconomique = productionEconomique,
                PopulationParDivision = populationParDivision,
                BonheurMoyenParDivision = bonheurMoyenParDivision,
                ProductionEconomiqueParDivision = productionEconomiqueParDivision
            };

            return View(model);
        }
    }
}
