﻿using CustomerOrderProduct.DTOS;
using CustomerOrderProduct.Interfaces;
using Generics.HelperClasses;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderProduct.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class CustomerController : ControllerBase
   {
      private readonly ICustomerRepository _customerService;

      public CustomerController(ICustomerRepository customerService)
      {
         _customerService = customerService;
      }

      [HttpGet]
      [Route("getAll")]
      public async Task<ActionResult> GetAll()
      {
         var result = await _customerService.GetAll();

         if (result.ErrorCode == ErrorCodes.Status404NotFound)
         {
            return NotFound(result);
         }
         else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
         }

         return Ok(result);
      }

      [HttpGet]
      [Route("get/{id}")]
      public async Task<ActionResult> GetById(Guid id)
      {
         var result = await _customerService.GetById(id);

         if (result.ErrorCode == ErrorCodes.Status404NotFound)
         {
            return NotFound(result);
         }
         else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
         }

         return Ok(result);
      }

      [HttpPost]
      [Route("add")]
      public async Task<ActionResult> Create([FromBody] CustomerDto customerDto)
      {
         if (customerDto == null)
         {
            return BadRequest();
         }

         var result = await _customerService.Create(customerDto);

         if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
         }

         return Ok(result);
      }

      [HttpPost]
      [Route("update")]
      public async Task<ActionResult> Update([FromBody] CustomerDto customerDto)
      {
         if (customerDto == null)
         {
            return BadRequest();
         }

         var result = await _customerService.Update(customerDto);

         if (result.ErrorCode == ErrorCodes.Status404NotFound)
         {
            return NotFound(result);
         }
         else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
         }

         return Ok(result);
      }

      [HttpDelete]
      [Route("delete/{id}")]
      public async Task<ActionResult> Delete(Guid id)
      {
         if (id == Guid.Empty)
         {
            return BadRequest();
         }

         var result = await _customerService.Delete(id);

         if (result.ErrorCode == ErrorCodes.Status404NotFound)
         {
            return NotFound(result);
         }
         else if (result.ErrorCode == ErrorCodes.Status500InternalServerError)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, result.Message);
         }

         return Ok(result);
      }
   }
}
