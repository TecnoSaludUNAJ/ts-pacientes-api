using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TP_Domain.Entities
{
    public class ObraSocial
    {
        [Key]
        public int ObraSocial_Id { get; set; }
        public string ObraSocial_Nombre { get; set; }
    }
}
