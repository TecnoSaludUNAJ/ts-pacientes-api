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
            throw new NotImplementedException();
        }

        public List<ResponseObraSocialDTO> GetAllObrasSociales()
        {
            return _query.GetAllObrasSociales();
        }

        public ResponseObraSocialDTO GetById(int id)
        {
            return _query.GetById(id);
        }
    }
}
