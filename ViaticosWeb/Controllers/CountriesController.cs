using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Helpers;
using ViaticosWeb.Models;

namespace ViaticosWeb.Controllers
{
    public class CountriesController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public CountriesController(DataContext context , IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Countries.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CountryEntity countryEntity = await _context.Countries
                .Include(c => c.Cities).FirstOrDefaultAsync(m => m.Id == id);
                
            
            if (countryEntity == null)
            {
                return NotFound();
            }

            return View(countryEntity);
        }

        
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryEntity countryEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists the Country:{countryEntity.Name}");

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
            }
            return View(countryEntity);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryEntity = await _context.Countries.FindAsync(id);
            if (countryEntity == null)
            {
                return NotFound();
            }
            return View(countryEntity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CountryEntity countryEntity)
        {
            if (id != countryEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(countryEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, $"Already exists the team:{countryEntity.Name}");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }

                }
                
            }
            return View(countryEntity);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryEntity = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryEntity == null)
            {
                return NotFound();
            }

            return View(countryEntity);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryEntity = await _context.Countries.FindAsync(id);
            _context.Countries.Remove(countryEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryEntityExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddCity (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CountryEntity countryEntity = await _context.Countries.FindAsync(id);
            if (countryEntity == null)
            {
                return NotFound();
            }

            CityViewModel model = new CityViewModel
            {
                Country = countryEntity,
                CountryId = countryEntity.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCity (CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                CityEntity cityEntity = await _converterHelper.ToCityEntityAsync(model, true);
                _context.Add(cityEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.CountryId}");
            }

            return View(model);
        }

        public async Task<IActionResult> EditCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityEntity cityEntity = await _context.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (cityEntity == null)
            {
                return NotFound();
            }

            CityViewModel model = _converterHelper.ToCityViewModel(cityEntity);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCity(CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                CityEntity cityEntity = await _converterHelper.ToCityEntityAsync(model, false);
                _context.Update(cityEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction($"{nameof(Details)}/{model.CountryId}");

            }

            return View(model);
        }

        public async Task<IActionResult> DeleteCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityEntity cityEntity = await _context.Cities
                .Include(g => g.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityEntity == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(cityEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{cityEntity.Country.Id}");
        }


    }
}
