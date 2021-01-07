using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarMicroservice.Data;
using Common.Models.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobileController : ControllerBase
    {
        private readonly MAANPP20ContextCar _context;
        public AutomobileController(MAANPP20ContextCar context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Automobile>> GetAutomobile(int id)
        {
            var automobile = _context.Automobiles.Where(x => x.id == id).FirstOrDefault();
            return automobile;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Automobile>>> GetAutomobiles()
        {
            var automobiles = _context.Automobiles.ToList();
            return automobiles;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Automobile>> AddAutomobile(Automobile automobile)
        {
            automobile.Updated = DateTime.Now;
            _context.Automobiles.Add(automobile);
            _context.SaveChanges();
            return Ok();
        }
    }
}