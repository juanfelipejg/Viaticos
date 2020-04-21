using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Viaticos.Common.Models;
using Viaticos.Web.Data.Entities;
using ViaticosWeb.Data;
using ViaticosWeb.Data.Entities;
using ViaticosWeb.Helpers;
using ViaticosWeb.Resources;

namespace ViaticosWeb.Controllers.API
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public TripsController(DataContext context, IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        [Route("GetTripsForUser")]
        public async Task<IActionResult> GetTripsForUser([FromBody] TripForUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Resource.UserDoesntExists);
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);
            Resource.Culture = cultureInfo;


            UserEntity userEntity = await _context.Users
                .Include(u => u.Trips)                
                .ThenInclude(t => t.TripDetails)
                .ThenInclude(td => td.TypeExpense)
                .Include(u => u.Trips)
                .ThenInclude(cy => cy.City)
                .ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(u => u.Id == request.UserId.ToString());

            if (userEntity == null)
            {
                return BadRequest(Resource.UserDoesntExists);
            }

            //Add trips already done
            List<TripResponse> tripResponses = new List<TripResponse>();
            foreach (TripEntity tripEntity in userEntity.Trips)
            {
                tripResponses.Add(_converterHelper.ToTripResponse(tripEntity));
                
            }

           return Ok(tripResponses.OrderBy(t => t.StartDateLocal));
        }

        /*[HttpGet]
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
        }*/
          
    }
}