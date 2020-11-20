using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_AccessData;
using TP_Application.Services;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Template_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;
        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(PacienteDTO paciente)
        {
            try
            {
                return new JsonResult(_service.CreatePaciente(paciente)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(_service.GetAllPacientes()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }

        [HttpGet("{Id?}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                ResponsePacienteDTO paciente = _service.GetById(Id);
                if (paciente != null)
                {
                    return new JsonResult(paciente) { StatusCode = 200 };
                }
                return new JsonResult(paciente) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }
        [HttpGet("dni/{Dni?}")]
        public IActionResult GetById(string Dni)
        {
            try
            {
                ResponsePacienteDTO paciente = _service.GetByDNI(Dni);
                if (paciente != null)
                {
                    return new JsonResult(paciente) { StatusCode = 200 };
                }
                return new JsonResult(paciente) { StatusCode = 404 };
            }
            catch (Exception e)
            {
                return BadRequest(new { error = true, message = e.Message });
            }
        }
    }
}