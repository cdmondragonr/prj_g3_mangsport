using Domain;
using System;
using System.Collections.Generic;

namespace Percistence
{
    public interface IREspacio
    {
        public IEnumerable<Espacio> ListarEspaciosAsIEnum();
        public List<Espacio> ListarEspaciosAsList();
        public bool CrearEspacio(Espacio espacio);
        public bool ActualizarEspacio(Espacio espacio);
        public bool EliminarEspacio(int idEspacio);
        public Espacio BuscarEspacioByID(int idEspacio);
        public bool EspacioExiste(Espacio espacio);
    }
}