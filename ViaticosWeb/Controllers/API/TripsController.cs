using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Helpers;

namespace ViaticosWeb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public TripsController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            List<TripEntity> trips = await _context.Trips
            .Include(t => t.TripDetails)
            .ThenInclude(t => t.TypeExpense)
            .Include(t => t.City)
            .ThenInclude(t => t.Country)
            .Include (t=>t.User)
            .ToListAsync();

            return Ok(_converterHelper.ToTripResponse(trips));                      
        }
          
    }
}