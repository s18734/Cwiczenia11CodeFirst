using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wyklad11.Models;
using Wyklad11.Services;

namespace Wyklad11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDBService _dbService;
        public DoctorController(IDBService dBService)
        {
            _dbService = dBService;
        }
        [HttpGet]
        public IActionResult getDoctors()
        {
            try
            {
                return Ok(_dbService.GetDoctors());
            }catch(Exception e)
            {
                return Forbid();
            }
        }
        [Route("add")]
        [HttpPost]
        public IActionResult addDoctor(Doctor doc)
        {
            try
            {
                return Ok(_dbService.AddDoctor(doc));
            }
            catch (Exception e)
            {
                return Forbid();
            }
        }
        [Route("update")]
        [HttpPost]
        public IActionResult UpdateDoctor(Doctor doc)
        {
            try
            {
                return Ok(_dbService.UpdateDoctor(doc));
            }
            catch (Exception e)
            {
                return Forbid();
            }
        }
        [HttpDelete]
        public IActionResult RemoveDoctor(Doctor doc)
        {
            try
            {
                return Ok(_dbService.RemoveDoctor(doc));
            }
            catch (Exception e)
            {
                return Forbid();
            }
        }
    }
}