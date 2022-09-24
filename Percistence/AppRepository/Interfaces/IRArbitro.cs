using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRArbitro
    {
        public IEnumerable<Arbitro> ListarArbitrosAsIEnum();
        public List<Arbitro> ListarArbitrosAsList();
        public bool CrearArbitro(Arbitro arbitro);
        public bool ActualizarArbitro(Arbitro arbitro);
        public bool EliminarArbitro(int idArbitro);
        public Arbitro BuscarArbitroByID(int idArbitro);
        public bool ArbitroExiste(Arbitro arbitro);
    }
}