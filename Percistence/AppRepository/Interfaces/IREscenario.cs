using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IREscenario
    {
        public IEnumerable<Escenario> ListarEscenariosAsIEnum();
        public List<Escenario> ListarEscenariosAsList();
        public bool CrearEscenario(Escenario escenario);
        public bool ActualizarEscenario(Escenario escenario);
        public bool EliminarEscenario(int idEscenario);
        public Escenario BuscarEscenarioByID(int idEscenario);
        public bool EscenarioExiste(Escenario escenario);
    }
}