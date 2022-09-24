using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IREntrenador
    {
        public IEnumerable<Entrenador> ListarEntrenadoresAsIEnum();
        public List<Entrenador> ListarEntrenadoresAsList();
        public bool CrearEntrenador(Entrenador entrenador);
        public bool ActualizarEntrenador(Entrenador entrenador);
        public bool EliminarEntrenador(int idEntrenador);
        public Entrenador BuscarEntrenadorByID(int idEntrenador);
        public bool EntrenadorExiste(Entrenador entrenador);
    }
}