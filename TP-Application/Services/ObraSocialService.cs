using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Commands;
using TP_Domain.DTOs;
using TP_Domain.Entities;
using TP_Domain.Queries;

namespace TP_Application.Services
{
    public class ObraSocialService : IObraSocialService
    {
        private readonly IGenericRepository _repository;
        private readonly IObraSocialQuery _query;
        public ObraSocialService(IGenericRepository repository, IObraSocialQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public ObraSocial CreateObraSocial(ObraSocialDTO obrasocial)
        {
            if (obrasocial.ObraSocial_Nombre == "" || obrasocial.ObraSocial_Sigla == "")
                throw new Exception("Error: Los parametros ingresados no pueden estar vacios.");
            ObraSocial entity = new ObraSocial
            {
                ObraSocial_Nombre = obrasocial.ObraSocial_Nombre,
                ObraSocial_Sigla = obrasocial.ObraSocial_Sigla
            };

            _repository.Add<ObraSocial>(entity);

            return entity;
        }

        public List<ResponseObraSocialDTO> GetAllObrasSociales()
        {
            return _query.GetAllObrasSociales();
        }

        public ResponseObraSocialDTO GetById(int id)
        {
            if (id <= 1)
                throw new Exception("Error: Valor ingresado no válido. El campo ID no acepta valores numericos menores a 1");
            return _query.GetById(id);
        }
    }
}
