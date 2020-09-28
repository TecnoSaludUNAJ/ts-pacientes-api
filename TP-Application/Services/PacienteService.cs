using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IGenericRepository _repository;
        private readonly IPacienteQuery _query;
        public PacienteService(IGenericRepository repository, IPacienteQuery query)
        {
            _repository = repository;
            _query = query;
        }


        public Paciente CreatePaciente(PacienteDTO paciente)
        {
            throw new NotImplementedException();
        }

        public List<ResponsePacienteDTO> GetAllPacientes()
        {
            return _query.GetAllPacientes();
        }

        public ResponsePacienteDTO GetById(int id)
        {
            return _query.GetById(id);
        }
    }
}
