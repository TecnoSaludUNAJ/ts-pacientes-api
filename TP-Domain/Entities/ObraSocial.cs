using System.Collections.Generic;

namespace TP_Domain.Entities
{
    public class ObraSocial
    {
        public int ObraSocial_Id { get; set; }
        public string ObraSocial_Nombre { get; set; }

        public string ObraSocial_Sigla { get; set; }

        public List<Paciente> Pacientes { get; set; }
    }
}
