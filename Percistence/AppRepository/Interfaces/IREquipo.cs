using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IREquipo
    {
        public IEnumerable<Equipo> ListarEquiposAsIEnum();
        public List<Equipo> ListarEquiposAsList();
        public bool CrearEquipo(Equipo equipo);
        public bool ActualizarEquipo(Equipo equipo);
        public bool EliminarEquipo(int idEquipo);
        public Equipo BuscarEquipoByID(int idEquipo);
        public bool EquipoExiste(Equipo equipo);
    }
}