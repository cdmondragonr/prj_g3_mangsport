using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRColegio
    {
        public IEnumerable<Colegio> ListarColegiosAsIEnum();
        public List<Colegio> ListarColegiosAsList();
        public bool CrearColegio(Colegio colegio);
        public bool ActualizarColegio(Colegio colegio);
        public bool EliminarColegio(int idColegio);
        public Colegio BuscarColegioByID(int idColegio);
        public bool ColegioExiste(Colegio colegio);
    }
}