using Registro_de_Inscripciones___Talleres_de_Tecnología.Models;

namespace Registro_de_Inscripciones___Talleres_de_Tecnología.Data
{
    public class InscripcionRepository
    {
        private static readonly List<Inscripcion> _inscripciones = new();

        private static int _nextId = 1;

        public static IReadOnlyList<Inscripcion> ObtenerInscripciones() => _inscripciones.AsReadOnly();

        public static void Agregar(Inscripcion p)
        {
            p.Id = _nextId++;
            _inscripciones.Add(p);
        }

    }
}
