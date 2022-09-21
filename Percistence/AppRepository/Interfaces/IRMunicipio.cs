using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IRMunicipio
    {
        public IEnumerable<Municipio> ListarMunicipiosAsIEnum();
        public List<Municipio> ListarMunicipiosAsList();
        public bool CrearMunicipio(Municipio municipio);
        public bool ActualizarMunicipio(Municipio municipio);
        public bool EliminarMunicipio(int idMunicipio);
        public Municipio BuscarMunicipioByID(int idMunicipio);
        public bool MunicipioExiste(Municipio municipio);
    }
}