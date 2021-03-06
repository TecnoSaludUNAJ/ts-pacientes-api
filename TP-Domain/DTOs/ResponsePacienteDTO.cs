﻿using System;

namespace TP_Domain.DTOs
{
    public class ResponsePacienteDTO
    {
        public int Paciente_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacim { get; set; }
        public string Sexo { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Estado_Civil { get; set; }
        public string Nacionalidad { get; set; }
        public int ObraSocial_Id { get; set; }
        public string DNI { get; set; }
        public int Usuario_Id { get; set; }
    }
}
