using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRTorneo
    {
        public IEnumerable<Torneo> ListarTorneosAsIEnum();
        public List<Torneo> ListarTorneosAsList();
        public bool CrearTorneo(Torneo torneo);
        public bool ActualizarTorneo(Torneo torneo);
        public bool EliminarTorneo(int idTorneo);
        public Torneo BuscarTorneoByID(int idTorneo);
        public bool TorneoExiste(Torneo torneo);
    }
}