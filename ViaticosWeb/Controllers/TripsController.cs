using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;

namespace ViaticosWeb.Controllers
{
    public class TripsController : Controller
    {
        private readonly DataContext _context;

        public TripsController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context
                .Trips
                .Include(t => t.TripDetails)
                .Include(t=> t.City)
                .ThenInclude(t=>t.Country)
                .Include(t=>t.User)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TripEntity tripEntity = (await _context
            .Trips
            .Include(t => t.TripDetails)
            .ThenInclude(t => t.TypeExpense)
            .Include(t=> t.TripDetails)
            .Include(t => t.City)
            .FirstOrDefaultAsync(m => m.Id == id));
            
            if (tripEntity == null)
            {
                return NotFound();
            }
            return View(tripEntity);

        }
}
}
