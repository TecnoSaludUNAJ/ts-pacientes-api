using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TP_Application.Services;
using TP_Domain.DTOs;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObrasSocialesController : ControllerBase
    {
        private readonly IObraSocialService _service;
        public ObrasSocialesController(IObraSocialService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(ObraSocialDTO obrasocial)
        {
            try
            {
                return new JsonResult(_service.CreateObraSocial(obrasocial)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_service.GetAllObrasSociales()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        [HttpGet("{Id?}")]
        [Authorize]
        public IActionResult GetById(int Id)
        {
            try
            {
                ResponseObraSocialDTO obrasocial = _service.GetById(Id);
                if (obrasocial != null)
                {
                    return new JsonResult(obrasocial) { StatusCode = 200 };
                }
                return new JsonResult(obrasocial) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }
    }
}