using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RColegio : IRColegio
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RColegio(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Colegio> ListarColegiosAsIEnum()
        {
            return this._appContext.Colegios;
        }

        public List<Colegio> ListarColegiosAsList()
        {
            return this._appContext.Colegios.ToList();
        }

        public bool CrearColegio(Colegio colegio)
        {
            bool resolve = false;
            if (ColegioExiste(colegio) == false)
            {
                try
                {
                    this._appContext.Colegios.Add(colegio);
                    this._appContext.SaveChanges();
                    resolve = ColegioExiste(colegio) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarColegio(Colegio colegio)
        {
            bool resolve = false;
            var target = BuscarColegioByID(colegio.Id);
            if (target != null & !ColegioExisteNoKey(colegio))
            {
                try
                {
                    target.Nombre = colegio.Nombre;
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

        public bool EliminarColegio(int idColegio)
        {
            bool resolve = false;
            var target = BuscarColegioByID(idColegio);
            if (target != null)
            {
                try
                {
                    this._appContext.Colegios.Remove(target);
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
        public Colegio BuscarColegioByID(int idColegio)
        {
            Colegio colegio = this._appContext.Colegios.Find(idColegio);
            return colegio;
        }

        public bool ColegioExiste(Colegio colegio)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarColegioByID(colegio.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreColegio = 
            this._appContext.Colegios.FirstOrDefault(Columns => Columns.Nombre == colegio.Nombre);
            targetFound |= (NombreColegio != null);

            return targetFound;
        }

        public bool ColegioExisteNoKey(Colegio colegio)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreColegio = 
            this._appContext.Colegios.FirstOrDefault(Columns => Columns.Nombre == colegio.Nombre);
            targetFound |= (NombreColegio != null);

            return targetFound;
        }
    }
}