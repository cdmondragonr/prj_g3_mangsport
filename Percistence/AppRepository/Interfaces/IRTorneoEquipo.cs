using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRTorneoEquipo
    {
        public IEnumerable<TorneoEquipo> ListarTorneoEquiposAsIEnum();
        public List<TorneoEquipo> ListarTorneoEquiposAsList();
        public bool CrearTorneoEquipo(TorneoEquipo torneoEquipo);
        public bool ActualizarTorneoEquipo(TorneoEquipo torneoEquipo);
        public bool EliminarTorneoEquipo(int idTorneoEquipo);
        public TorneoEquipo BuscarTorneoEquipoByID(int idTorneoEquipo);
        public bool TorneoEquipoExiste(TorneoEquipo torneoEquipo);
    }
}