using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRDeportista
    {
        public IEnumerable<Deportista> ListarDeportistasAsIEnum();
        public List<Deportista> ListarDeportistasAsList();
        public bool CrearDeportista(Deportista deportista);
        public bool ActualizarDeportista(Deportista deportista);
        public bool EliminarDeportista(int idDeportista);
        public Deportista BuscarDeportistaByID(int idDeportista);
        public bool DeportistaExiste(Deportista deportista);
    }
}