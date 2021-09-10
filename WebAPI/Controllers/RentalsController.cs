using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int rentalId)
        {
            var result = _rentalService.Get(rentalId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetailsbycarid")]
        public IActionResult GetRentalDetailsByCarId(int carId)
        {
            var result = _rentalService.GetRentalDetailsByCarId(carId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpGet("getrentaldetailsbycustomerid")]
        public IActionResult GetRentalDetailsByCustomerId(int customerId)
        {
            var result = _rentalService.GetRentalDetailsByCustomerId(customerId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        //---POST
        [HttpPost("rent")]
        public IActionResult Rent(Rental rental)
        {
            var result = _rentalService.Rent(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("deliver")]
        public IActionResult Deliver(int rentId, DateTime dateTime)
        {
            dateTime = DateTime.Now;
            var result = _rentalService.Deliver(rentId, dateTime);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpPost("checkcarstatus")]
        public IActionResult CheckCarStatus(Rental rental)
        {
            var result = _rentalService.CheckCarStatus(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
