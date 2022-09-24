using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRPatrocinador
    {
        public IEnumerable<Patrocinador> ListarPatrocinadoresAsIEnum();
        public List<Patrocinador> ListarPatrocinadoresAsList();
        public bool CrearPatrocinador(Patrocinador patrocinador);
        public bool ActualizarPatrocinador(Patrocinador patrocinador);
        public bool EliminarPatrocinador(int idPatrocinador);
        public Patrocinador BuscarPatrocinadorByID(int idPatrocinador);
        public bool PatrocinadorExiste(Patrocinador patrocinador);
    }
}