using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class REquipo : IREquipo
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public REquipo(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Equipo> ListarEquiposAsIEnum()
        {
            return this._appContext.Equipos;
        }

        public List<Equipo> ListarEquiposAsList()
        {
            return this._appContext.Equipos.ToList();
        }

        public bool CrearEquipo(Equipo equipo)
        {
            bool resolve = false;
            if (EquipoExiste(equipo) == false)
            {
                try
                {
                    this._appContext.Equipos.Add(equipo);
                    this._appContext.SaveChanges();
                    resolve = EquipoExiste(equipo) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarEquipo(Equipo equipo)
        {
            bool resolve = false;
            var target = BuscarEquipoByID(equipo.Id);
            if (target != null & !EquipoExisteNoKey(equipo))
            {
                try
                {
                    target.Nombre = equipo.Nombre;
                    this._appContext.SaveChanges();
                    resolve = true;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool EliminarEquipo(int idEquipo)
        {
            bool resolve = false;
            var target = BuscarEquipoByID(idEquipo);
            if (target != null)
            {
                try
                {
                    this._appContext.Equipos.Remove(target);
                    this._appContext.SaveChanges();
                    resolve = true;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }
        public Equipo BuscarEquipoByID(int idEquipo)
        {
            Equipo equipo = this._appContext.Equipos.Find(idEquipo);
            return equipo;
        }

        public bool EquipoExiste(Equipo equipo)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarEquipoByID(equipo.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreEquipo = 
            this._appContext.Equipos.FirstOrDefault(Columns => Columns.Nombre == equipo.Nombre);
            targetFound |= (NombreEquipo != null);

            return targetFound;
        }

        public bool EquipoExisteNoKey(Equipo equipo)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreEquipo = 
            this._appContext.Equipos.FirstOrDefault(Columns => Columns.Nombre == equipo.Nombre);
            targetFound |= (NombreEquipo != null);

            return targetFound;
        }
    }
}