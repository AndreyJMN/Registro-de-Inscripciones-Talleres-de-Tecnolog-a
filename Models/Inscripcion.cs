using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_de_Inscripciones___Talleres_de_Tecnología.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }

        
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [MinLength(2, ErrorMessage = "Los apellidos deben tener al menos 2 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string Email { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "El teléfono es requerido")]
        [Range(10000000, 999999999, ErrorMessage = "El teléfono debe tener al menos 8 dígitos")]
        public int Telefono { get; set; }

        
        [Required(ErrorMessage = "Debe seleccionar un taller")]
        [RegularExpression(@"^(?!Seleccione).*", ErrorMessage = "Debe seleccionar un taller válido")]
        public string Taller { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "Debe seleccionar su nivel de experiencia")]
        public string NivelExperiencia { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "La fecha del taller es obligatoria")]
        [DataType(DataType.Date)]
        [FechaNoPasada(ErrorMessage = "La fecha del taller no puede ser pasada")]
        public DateTime FechaTaller { get; set; }

        
        [Required(ErrorMessage = "Debe aceptar los términos y condiciones para completar la inscripción")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos y condiciones para completar la inscripción")]
        public bool AceptaTerminos { get; set; }
    }

    // Fechas no pasadas
    public class FechaNoPasadaAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime fecha)
            {
                return fecha.Date >= DateTime.Now.Date;
            }

            return false;
        }
    }
}

