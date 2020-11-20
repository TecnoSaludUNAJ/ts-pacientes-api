using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;

namespace TP_Domain.Queries
{
    public interface IPacienteQuery
    {
        List<ResponsePacienteDTO> GetAllPacientes();
        ResponsePacienteDTO GetById(int id);
        ResponsePacienteDTO GetByDNI(string dni);
    }
}
