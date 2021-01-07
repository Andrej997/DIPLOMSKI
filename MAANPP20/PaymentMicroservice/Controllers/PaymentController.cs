using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentMicroservice.Data;

namespace PaymentMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly MAANPP20ContextPayment _context;
        public PaymentController(MAANPP20ContextPayment context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = _context.Payments.Where(x => x.id == id).FirstOrDefault();
            return payment;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Payment>>> GetPayments()
        {
            var payments = _context.Payments.ToList();
            return payments;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Payment>> AddPayment(Payment payment)
        {
            payment.Updated = DateTime.Now;
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return Ok();
        }
    }
}