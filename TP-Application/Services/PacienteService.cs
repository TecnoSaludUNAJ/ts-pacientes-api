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
            if(paciente.Apellido == "" || paciente.Domicilio == "" || paciente.Email == "" || paciente.Estado_Civil == "" || paciente.Nacionalidad == "" || paciente.Nombre == "" || paciente.Sexo == "" || paciente.Telefono == "")
                throw new Exception("Error al ingresar parametros: Ningun parametro ingresado puede estar vacio.");
            if (paciente.DNI <= 0 || paciente.Usuario_Id <= 0|| paciente.ObraSocial_Id <= 0)
                throw new Exception("Error: Valor ingresado no válido: No se aceptan valores numeros menores a 1");
            if (paciente.Fecha_Nacim > DateTime.Today)
                throw new Exception("Error al ingresar parametros: La fecha de nacimiento no puede ser superior al dia actual.");
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
            if (id < 1)
                throw new Exception("Error: Valor ingresado no válido. El campo ID no acepta valores numericos menores a 1");
            return _query.GetById(id);
        }
    }
}
