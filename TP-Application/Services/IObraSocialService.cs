using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.DTOs;
using TP_Domain.Entities;

namespace TP_Application.Services
{
    public interface IObraSocialService
    {
        ResponseObraSocialDTO CreateObraSocial(ObraSocialDTO obrasocial);
        List<ResponseObraSocialDTO> GetAllObrasSociales();
        ResponseObraSocialDTO GetById(int id);
    }
}
