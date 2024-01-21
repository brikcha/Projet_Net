using Microsoft.AspNetCore.Mvc;
using SW.Models;
using SW.Services;



namespace SW.Web.Controllers

{

    public class CitoyenController : Controller

    {

        public readonly DivisionCitoyen _divisionCitoyen;

        public CitoyenController(DivisionCitoyen divisionCitoyen)

        {

            _divisionCitoyen = divisionCitoyen;

        }

        // GET: CitoyenController

        public ActionResult Index()

        {

            var enumValues = Enum.GetValues(typeof(Division)).Cast<Division>();

            return View(enumValues);

        }

        [HttpGet]

        public IActionResult GetCitoyensByDivision(Division selectedDivision)

        {

            // Utilisez le service pour obtenir les citoyens par division

            var citoyens = _divisionCitoyen.GetCitoyensByDivision(selectedDivision);

            // Passez la liste des citoyens à la vue

            return View(citoyens);

        }

        // GET: CitoyenController/Details/5

        public ActionResult Details(int id)

        {

            return View();

        }

        // GET: CitoyenController/Create

        public ActionResult Create()

        {

            return View();

        }

        // POST: CitoyenController/Create

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Create(IFormCollection collection)

        {

            try

            {

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

        // GET: CitoyenController/Edit/5

        public ActionResult Edit(int id)

        {

            return View();

        }

        // POST: CitoyenController/Edit/5

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Edit(int id, IFormCollection collection)

        {

            try

            {

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

        // GET: CitoyenController/Delete/5

        public ActionResult Delete(int id)

        {

            return View();

        }

        // POST: CitoyenController/Delete/5

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id, IFormCollection collection)

        {

            try

            {

                return RedirectToAction(nameof(Index));

            }

            catch

            {

                return View();

            }

        }

        [HttpGet]

        public IActionResult Search(int? citoyenId)

        {

            if (citoyenId.HasValue)

            {

                var citoyen = _divisionCitoyen.GetCitoyens().FirstOrDefault(c => c.Id == citoyenId);

                if (citoyen != null)

                {

                    ViewData["CitoyenDetails"] = _divisionCitoyen.GetInfosCitoyen(citoyen.Id);

                }

            }

            // Reste du code

            return View("Index");

        }




    }

}
