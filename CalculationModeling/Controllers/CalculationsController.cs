using CalculationModeling.Data;
using CalculationModeling.Models;
using CalculationModeling.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalculationModeling.Controllers
{
    public class CalculationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHeatExchangeCalculator _calculator;

        public CalculationsController(ApplicationDbContext context, IHeatExchangeCalculator calculator)
        {
            _context = context;
            _calculator = calculator;
        }

        public IActionResult Index()
        {
            return View(_context.CalculationParameters.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CalculationParameters parameters)
        {
            if (parameters.LayerHeightValue * 2 % 1 != 0)
            {
                ModelState.AddModelError(
                    "LayerHeightValue",
                    "Высота слоя должна быть целым числом или с шагом 0.5"
                );
            }

            if (!ModelState.IsValid)
                return View(parameters);

            _context.CalculationParameters.Add(parameters);
            _context.SaveChanges();

            var results = _calculator.CalculateDetailed(parameters);
            _context.CalculationResults.AddRange(results);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var parameters = _context.CalculationParameters.First(p => p.Id == id);

            var results = _context.CalculationResults
                .Where(r => r.ParametersId == id)
                .ToList();


            return View(new CalculationViewModel
            {
                Parameters = parameters,
                Results = results
            });
        }

        public IActionResult Delete(int id)
        {
            var p = _context.CalculationParameters.Find(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var results = _context.CalculationResults.Where(r => r.ParametersId == id);
            _context.CalculationResults.RemoveRange(results);

            var p = _context.CalculationParameters.Find(id);
            _context.CalculationParameters.Remove(p);

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(_context.CalculationParameters.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(CalculationParameters parameters)
        {
            if (!ModelState.IsValid) return View(parameters);

            var oldResults = _context.CalculationResults
                .Where(r => r.ParametersId == parameters.Id);
            _context.CalculationResults.RemoveRange(oldResults);

            _context.CalculationParameters.Update(parameters);
            _context.SaveChanges();

            var results = _calculator.CalculateDetailed(parameters);
            _context.CalculationResults.AddRange(results);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
