using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Companias.Models
{
    public class Compania
    {
        [Display(Name = "Compañia")]
        [Required(ErrorMessage = "La  Compañia es obligatorio")]
        public string NombreCompania { get; set; }

        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "El Contacto es obligatorio")]
        public string NombreContacto { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El correo no es valido")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public string Telefono { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Seleccione el aviso de privacidad.")]
        public bool Aviso { get; set; }

    }
}
