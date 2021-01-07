using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.Hotels;
using HotelMicroservice.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly MAANPP20ContextHotel _context;
        public HotelController(MAANPP20ContextHotel context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = _context.Hotels.Where(x => x.id == id).FirstOrDefault();
            return hotel;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {
            var hotels = _context.Hotels.ToList();
            return hotels;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Hotel>> AddHotel(Hotel hotel)
        {
            hotel.Updated = DateTime.Now;
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return Ok();
        }
    }
}