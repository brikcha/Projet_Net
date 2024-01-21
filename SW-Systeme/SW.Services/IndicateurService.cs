using SW.Models;

public class IndicateurService
{
    public double CalculerBonheurMoyen(List<Citoyen> citoyens)
    {
        return citoyens.Any() ? citoyens.Average(c => c.Bonheur) : 0;
    }

    public int CalculerProductionEconomiqueTotale(List<Citoyen> citoyens)
    {
        return citoyens.Sum(c => c.ProductionEconomique);
    }

    public int CalculerPopulationTotale(List<Citoyen> citoyens)
    {
        return citoyens.Count;
    }

    /*public int CalculerPopulationParDivision(List<Citoyen> citoyens, string division)
    {
        return citoyens.Count(c => c.Division == division);
    }*/

    public int CalculerPopulationParDivision(List<Citoyen> citoyens, Division division)
    {
        return citoyens.Count(c => c.division == division);
    }

    /* public double CalculerBonheurMoyenParDivision(List<Citoyen> citoyens, string division)
     {
         var citoyensDivision = citoyens.Where(c => c.Division == division).ToList();
         return citoyensDivision.Any() ? citoyensDivision.Average(c => c.Bonheur) : 0;
     }*/
    public double CalculerBonheurMoyenParDivision(List<Citoyen> citoyens, Division division)
    {
        var citoyensDivision = citoyens.Where(c => c.division == division).ToList();
        return citoyensDivision.Any() ? citoyensDivision.Average(c => c.Bonheur) : 0;
    }

    /*public int CalculerProductionEconomiqueTotaleParDivision(List<Citoyen> citoyens, string division)
    {
        return citoyens.Where(c => c.Division == division).Sum(c => c.ProductionEconomique);
    }*/

    public int CalculerProductionEconomiqueTotaleParDivision(List<Citoyen> citoyens, Division division)
    {
        return citoyens.Where(c => c.division == division).Sum(c => c.ProductionEconomique);
    }
}
