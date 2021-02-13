using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Application.Services;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Queries;

namespace TP_UnitTest
{
    public class ObraSocialServiceTest
    {
        /*
         * CreateObraSocial
         *******************************************************/
        [Test]
        public void CreateObraSocial_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = new ResponseObraSocialDTO { ObraSocial_Id = 0, ObraSocial_Nombre = "Obra social ABC", ObraSocial_Sigla = "ABC" };

            // Act
            var response = Service.CreateObraSocial(new ObraSocialDTO{ ObraSocial_Nombre = "Obra social ABC", ObraSocial_Sigla = "ABC" });
            // Assert
            Assert.IsTrue(expected.ObraSocial_Id == response.ObraSocial_Id);
            Assert.IsTrue(expected.ObraSocial_Nombre == response.ObraSocial_Nombre);
            Assert.IsTrue(expected.ObraSocial_Sigla == response.ObraSocial_Sigla);
        }

        [Test]
        public void CreateObraSocial_Invalid_ObraSocial_Nombre_Empty()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = "El campo Nombre no puede estar vacío.";

            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreateObraSocial(new ObraSocialDTO { ObraSocial_Nombre = "", ObraSocial_Sigla = "ABC"}));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }
        [Test]
        public void CreateObraSocial_Invalid_ObraSocial_Sigla_Empty()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = "El campo Sigla no puede estar vacío.";

            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.CreateObraSocial(new ObraSocialDTO { ObraSocial_Nombre = "Obra Social", ObraSocial_Sigla = "" }));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }
        /*
         * GetAllObrasSociales
         *******************************************************/
        [Test]
        public void GetAllPacientes_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = new List<ResponseObraSocialDTO>();
            expected.Add(new ResponseObraSocialDTO { ObraSocial_Id = 1, ObraSocial_Nombre = "Obra social ABC", ObraSocial_Sigla = "ABC" });
            expected.Add(new ResponseObraSocialDTO { ObraSocial_Id = 2, ObraSocial_Nombre = "Obra social de OBDC", ObraSocial_Sigla = "OBDC" });

            _query.Setup(_ => _.GetAllObrasSociales()).Returns(expected);
            // Act
            var response = Service.GetAllObrasSociales();
            // Assert
            Assert.AreEqual(expected, response);
        }
        [Test]
        public void GetAllPacientes_Null_Exception()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = "Error: No se encuentran obras sociales.";

            _query.Setup(_ => _.GetAllObrasSociales()).Returns(new List<ResponseObraSocialDTO>());
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetAllObrasSociales());
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        /*
         * GetById
         *******************************************************/
        [Test]
        public void GetById_Valid()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = new ResponseObraSocialDTO { ObraSocial_Id = 1, ObraSocial_Nombre = "Obra social ABC", ObraSocial_Sigla = "ABC" };

            _query.Setup(_ => _.GetById(It.Is<int>(s => s == 1))).Returns(expected);
            // Act
            var response = Service.GetById(1);
            // Assert
            Assert.AreEqual(expected, response);
        }
        [Test]
        public void GetById_InvalidValue()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = "Error: Valor ingresado no válido. El campo ID no acepta valores numericos menores a 1";

            _query.Setup(_ => _.GetById(It.IsAny<int>())).Returns(new ResponseObraSocialDTO());
            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetById(-2));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

        [Test]
        public void GetById_NotFound()
        {
            // Arrange
            Mock<IGenericRepository> _repository = new Mock<IGenericRepository>();
            Mock<IObraSocialQuery> _query = new Mock<IObraSocialQuery>();
            var Service = new ObraSocialService(_repository.Object, _query.Object);
            var expected = "Error: No se encontro obra social con id 5";

            // Act
            var ex = Assert.Throws<System.Exception>(() => Service.GetById(5));
            // Assert
            Assert.AreEqual(expected, ex.Message);
        }

    }
}
