using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TP_Application.Services;
using TP_Domain.DTOs;

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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [HttpGet("userId/{usuarioId?}")]
        [Authorize]
        public IActionResult GetByUsuarioId(int usuarioId)
        {
            try
            {
                ResponsePacienteDTO paciente = _service.GetByUsuarioId(usuarioId);
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