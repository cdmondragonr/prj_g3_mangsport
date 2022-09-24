using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RDeportista : IRDeportista
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RDeportista(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Deportista> ListarDeportistasAsIEnum()
        {
            return this._appContext.Deportistas;
        }

        public List<Deportista> ListarDeportistasAsList()
        {
            return this._appContext.Deportistas.ToList();
        }

        public bool CrearDeportista(Deportista deportista)
        {
            bool resolve = false;
            if (DeportistaExiste(deportista) == false)
            {
                try
                {
                    this._appContext.Deportistas.Add(deportista);
                    this._appContext.SaveChanges();
                    resolve = DeportistaExiste(deportista) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarDeportista(Deportista deportista)
        {
            bool resolve = false;
            var target = BuscarDeportistaByID(deportista.Id);
            if (target != null & !DeportistaExisteNoKey(deportista))
            {
                try
                {
                    target.Nombre = deportista.Nombre;
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

        public bool EliminarDeportista(int idDeportista)
        {
            bool resolve = false;
            var target = BuscarDeportistaByID(idDeportista);
            if (target != null)
            {
                try
                {
                    this._appContext.Deportistas.Remove(target);
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
        public Deportista BuscarDeportistaByID(int idDeportista)
        {
            Deportista deportista = this._appContext.Deportistas.Find(idDeportista);
            return deportista;
        }

        public bool DeportistaExiste(Deportista deportista)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarDeportistaByID(deportista.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreDeportista = 
            this._appContext.Deportistas.FirstOrDefault(Columns => Columns.Nombre == deportista.Nombre);
            targetFound |= (NombreDeportista != null);

            return targetFound;
        }

        public bool DeportistaExisteNoKey(Deportista deportista)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreDeportista = 
            this._appContext.Deportistas.FirstOrDefault(Columns => Columns.Nombre == deportista.Nombre);
            targetFound |= (NombreDeportista != null);

            return targetFound;
        }
    }
}