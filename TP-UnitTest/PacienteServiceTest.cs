using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TP_Application.Services;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_UnitTest
{
    public class PacienteServiceTest
    {
        /*
         * GetByID
         *****************************************************/
        [Test]
        public void GetByID_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = new ResponsePacienteDTO
            {
                Paciente_Id = 148,
                DNI = "12345678"
            };

            _query.Setup(x => x.GetById(It.IsAny<int>())).Returns(
                (int s) => new ResponsePacienteDTO { Paciente_Id = s, DNI = "12345678" }
            );
            // Act
            var result = Service.GetById(148);
            // Assert
            Assert.AreEqual(expected.Paciente_Id, result.Paciente_Id);
        }

        [Test]
        public void GetByID_Invalid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: Valor ingresado no válido. El campo ID no acepta valores numericos menores a 1";

            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetById(-1));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        /*
         * GetByDNI
         *****************************************************/
        [Test]
        public void GetByDNI_EmptyString()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: el dni ingresado es vacio";

            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetByDNI(""));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void GetByDNI_NotFound()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: No se encontro paciente con dni 12345678";
            _query.Setup(x => x.GetByDNI(It.IsAny<string>())).Returns((ResponsePacienteDTO)null);
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetByDNI("12345678"));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void GetByDNI_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            ResponsePacienteDTO expected = new ResponsePacienteDTO
            {
                Paciente_Id = 102,
                DNI = "40123458"
            };

            _query.Setup(x => x.GetByDNI(It.IsAny<string>())).Returns(
                 (string s) => new ResponsePacienteDTO { Paciente_Id = 102, DNI = s }
             );
            // Act
            var result = Service.GetByDNI("40123458");
            // Assert
            Assert.AreEqual(expected.DNI, result.DNI); // TODO: Fix error when compare Equal Object
        }


        /**
         * CreatePaciente
         * ****************************************************************/
        [Test]
        public void CreatePaciente_NullField()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error al ingresar parametros: Ningun parametro ingresado puede estar vacio.";
            var paciente = new PacienteDTO
            {
                Apellido = "",
                DNI = "12345678",
                Domicilio = "paciente.Domicilio",
                Email = "paciente.Email@mail.com",
                Estado_Civil = "paciente.Estado_Civil",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "paciente.Nacionalidad",
                Nombre = "paciente.Nombre",
                ObraSocial_Id = 10,
                Sexo = "paciente.Sexo",
                Telefono = "paciente.Telefono",
                Usuario_Id = 1
            };
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreatePaciente(paciente));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }
        [Test]
        public void CreatePaciente_InvalidDate()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error al ingresar parametros: La fecha de nacimiento no puede ser superior al dia actual.";

            var paciente = new PacienteDTO
            {
                Apellido = "paciente.Apellido",
                DNI = "12345678",
                Domicilio = "paciente.Domicilio",
                Email = "paciente.Email@mail.com",
                Estado_Civil = "paciente.Estado_Civil",
                Fecha_Nacim = new DateTime(2030, 2, 1),
                Nacionalidad = "paciente.Nacionalidad",
                Nombre = "paciente.Nombre",
                ObraSocial_Id = 10,
                Sexo = "paciente.Sexo",
                Telefono = "paciente.Telefono",
                Usuario_Id = 1
            };
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreatePaciente(paciente));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }
        [Test]
        public void CreatePaciente_InvalidMail()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "El campo Email no es válido.";

            var paciente = new PacienteDTO
            {
                Apellido = "paciente.Apellido",
                DNI = "12345678",
                Domicilio = "paciente.Domicilio",
                Email = "invalid@mail",
                Estado_Civil = "paciente.Estado_Civil",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "paciente.Nacionalidad",
                Nombre = "paciente.Nombre",
                ObraSocial_Id = 10,
                Sexo = "paciente.Sexo",
                Telefono = "paciente.Telefono",
                Usuario_Id = 1
            };
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreatePaciente(paciente));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }
        [Test]
        public void CreatePaciente_InvalidDNI()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Campo DNI solo acepta valores numericos con mínimo de 7 dígitos.";

            var paciente = new PacienteDTO
            {
                Apellido = "paciente.Apellido",
                DNI = "123",
                Domicilio = "paciente.Domicilio",
                Email = "valid@mail.com",
                Estado_Civil = "paciente.Estado_Civil",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "paciente.Nacionalidad",
                Nombre = "paciente.Nombre",
                ObraSocial_Id = 10,
                Sexo = "paciente.Sexo",
                Telefono = "paciente.Telefono",
                Usuario_Id = 1
            };
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreatePaciente(paciente));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void CreatePaciente_InvalidUsuario_Id()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: Campo Usuario_Id no valido, no puede ser menor a 0.";

            var paciente = new PacienteDTO
            {
                Apellido = "paciente.Apellido",
                DNI = "12345678",
                Domicilio = "paciente.Domicilio",
                Email = "valid@mail.com",
                Estado_Civil = "paciente.Estado_Civil",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "paciente.Nacionalidad",
                Nombre = "paciente.Nombre",
                ObraSocial_Id = 123,
                Sexo = "paciente.Sexo",
                Telefono = "paciente.Telefono",
                Usuario_Id = 0
            };
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreatePaciente(paciente));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void CreatePaciente_InvalidObraSocial_Id()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: Campo ObraSocial_Id no valido, no puede ser menor a 0.";

            var paciente = new PacienteDTO
            {
                Apellido = "paciente.Apellido",
                DNI = "12345678",
                Domicilio = "paciente.Domicilio",
                Email = "valid@mail.com",
                Estado_Civil = "paciente.Estado_Civil",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "paciente.Nacionalidad",
                Nombre = "paciente.Nombre",
                ObraSocial_Id = -66,
                Sexo = "paciente.Sexo",
                Telefono = "paciente.Telefono",
                Usuario_Id = 4
            };
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreatePaciente(paciente));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }


        [Test]
        public void CreatePaciente_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = new ResponsePacienteDTO
            {
                Apellido = "Perez",
                DNI = "12345678",
                Domicilio = "Calle 123, Ciudad",
                Email = "juanperez@mail.com",
                Estado_Civil = "Soltero",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "Argentina",
                Nombre = "Juan",
                ObraSocial_Id = 2,
                Sexo = "Masculino",
                Telefono = "45458789",
                Usuario_Id = 10,
                Paciente_Id = 0
            };

            var pacienteEntry = new PacienteDTO
            {
                Apellido = "Perez",
                DNI = "12345678",
                Domicilio = "Calle 123, Ciudad",
                Email = "juanperez@mail.com",
                Estado_Civil = "Soltero",
                Fecha_Nacim = new DateTime(1997, 2, 1),
                Nacionalidad = "Argentina",
                Nombre = "Juan",
                ObraSocial_Id = 2,
                Sexo = "Masculino",
                Telefono = "45458789",
                Usuario_Id = 10
            };
            // Act
            var result = Service.CreatePaciente(pacienteEntry);
            // Assert
            Assert.IsTrue(expected.Apellido == result.Apellido);
            Assert.IsTrue(expected.Paciente_Id == result.Paciente_Id);
        }

        // TODO: Create Test valid Paciente
        /**
         * GetByUsuarioId
         ***************************************************************/
        [Test]
        public void GetByUsuarioId_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            int id = 789;
            ResponsePacienteDTO expected = new ResponsePacienteDTO
            {
                Paciente_Id = 1,
                DNI = "12345678",
                Usuario_Id = id
            };

            _query.Setup(x => x.GetByUsuarioId(It.IsAny<int>())).Returns(
                (int s) => new ResponsePacienteDTO { Paciente_Id = 1, DNI = "12345678", Usuario_Id = s }
            );
            // Act
            var result = Service.GetByUsuarioId(id);
            // Assert
            Assert.IsTrue(result.Usuario_Id == id);
        }

        [Test]
        public void GetByUsuarioId_Invalid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: Valor numero no valido. ";

            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetByUsuarioId(-1));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        /****************************
         * GetAllPacientes
         * *********************************/
        [Test]
        public void GetAllPacientes_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = new List<ResponsePacienteDTO>();
            expected.Add(new ResponsePacienteDTO { Paciente_Id = 1, Nombre = "Juan", Apellido = "Perez", DNI = "12345678" });
            expected.Add(new ResponsePacienteDTO { Paciente_Id = 1, Nombre = "Ana", Apellido = "Lopez", DNI = "87654321" });

            _query.Setup(_ => _.GetAllPacientes()).Returns(expected);
            // Act
            var response = Service.GetAllPacientes();
            // Assert
            Assert.AreEqual(expected, response);
        }
        [Test]
        public void GetAllPacientes_Null_Exception()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IPacienteQuery> _query = new Mock<IPacienteQuery>();
            var Service = new PacienteService(_repository.Object, _query.Object);
            var expected = "Error: No se encontraron pacientes.";

            _query.Setup(_ => _.GetAllPacientes()).Returns(new List<ResponsePacienteDTO>());
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetAllPacientes());
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }
    }
}