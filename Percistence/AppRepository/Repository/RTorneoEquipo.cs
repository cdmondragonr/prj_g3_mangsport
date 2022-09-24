using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RTorneoEquipo : IRTorneoEquipo
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RTorneoEquipo(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<TorneoEquipo> ListarTorneoEquiposAsIEnum()
        {
            return this._appContext.TorneoEquipos;
        }

        public List<TorneoEquipo> ListarTorneoEquiposAsList()
        {
            return this._appContext.TorneoEquipos.ToList();
        }

        public bool CrearTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool resolve = false;
            if (TorneoEquipoExiste(torneoEquipo) == false)
            {
                try
                {
                    this._appContext.TorneoEquipos.Add(torneoEquipo);
                    this._appContext.SaveChanges();
                    resolve = TorneoEquipoExiste(torneoEquipo) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            bool resolve = false;
            var target = BuscarTorneoEquipoByID(torneoEquipo.Id);
            if (target != null & !TorneoEquipoExisteNoKey(torneoEquipo))
            {
                try
                {
                    target.Nombre = torneoEquipo.Nombre;
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

        public bool EliminarTorneoEquipo(int idTorneoEquipo)
        {
            bool resolve = false;
            var target = BuscarTorneoEquipoByID(idTorneoEquipo);
            if (target != null)
            {
                try
                {
                    this._appContext.TorneoEquipos.Remove(target);
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
        public TorneoEquipo BuscarTorneoEquipoByID(int idTorneoEquipo)
        {
            TorneoEquipo torneoEquipo = this._appContext.TorneoEquipos.Find(idTorneoEquipo);
            return torneoEquipo;
        }

        public bool TorneoEquipoExiste(TorneoEquipo torneoEquipo)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarTorneoEquipoByID(torneoEquipo.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreTorneoEquipo = 
            this._appContext.TorneoEquipos.FirstOrDefault(Columns => Columns.Nombre == torneoEquipo.Nombre);
            targetFound |= (NombreTorneoEquipo != null);

            return targetFound;
        }

        public bool TorneoEquipoExisteNoKey(TorneoEquipo torneoEquipo)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreTorneoEquipo = 
            this._appContext.TorneoEquipos.FirstOrDefault(Columns => Columns.Nombre == torneoEquipo.Nombre);
            targetFound |= (NombreTorneoEquipo != null);

            return targetFound;
        }
    }
}