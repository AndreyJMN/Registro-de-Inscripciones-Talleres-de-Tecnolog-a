using System.Collections.Generic;
using Registro_de_Inscripciones___Talleres_de_Tecnología.Models;

namespace Registro_de_Inscripciones___Talleres_de_Tecnología.Data
{
    public static class InscripcionRepository
    {
        private static List<Inscripcion> _inscripciones = new List<Inscripcion>();
        private static int _nextId = 1;

        public static void AgregarInscripcion(Inscripcion inscripcion)
        {
            inscripcion.Id = _nextId++;
            _inscripciones.Add(inscripcion);
        }

        public static List<Inscripcion> ObtenerInscripciones()
        {
            return _inscripciones;
        }
    }
}
