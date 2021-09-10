﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //---GET
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _customerService.GetByCustomerId(customerId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcustomerbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _customerService.GetByUserId(userId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }


        [HttpGet("getcustomerdetails")]
        public IActionResult GetCustomerDetails()
        {
            var result = _customerService.GetCustomerDetails();
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcustomerdetailsbyid")]
        public IActionResult GetCustomerDetailsById(int customerId)
        {
            var result = _customerService.GetCustomerDetailsById(customerId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

        [HttpGet("getcustomerdetailsbyuserid")]
        public IActionResult GetCustomerDetailsByUserId(int userId)
        {
            var result = _customerService.GetCustomerDetailsByUserId(userId);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }


        //---POST
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success) { return Ok(result); }
            return BadRequest(result);
        }

    }
}
