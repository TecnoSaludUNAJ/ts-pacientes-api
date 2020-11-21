using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Application.Services
{
    public interface IPacienteService
    {
        ResponsePacienteDTO CreatePaciente(PacienteDTO paciente);
        List<ResponsePacienteDTO> GetAllPacientes();
        ResponsePacienteDTO GetById(int id);

        ResponsePacienteDTO GetByDNI(string dni);
        ResponsePacienteDTO GetByUsuarioId(int usuarioId);
    }
}
