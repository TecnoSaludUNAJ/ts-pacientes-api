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
            Paciente entity = new Paciente
            {
                Apellido = paciente.Apellido,
                DNI = paciente.DNI,
                Domicilio = paciente.Domicilio,
                Email = paciente.Email,
                Estado_Civil = paciente.Estado_Civil,
                Fecha_Nacim = paciente.Fecha_Nacim,
                Nacionalidad = paciente.Nacionalidad,
                Nombre = paciente.Nombre,
                ObraSocial_Id = paciente.ObraSocial_Id,
                Sexo = paciente.Sexo,
                Telefono = paciente.Telefono,
                Usuario_Id = paciente.Usuario_Id
            };

            _repository.Add<Paciente>(entity);

            return entity;
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
