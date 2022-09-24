using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class REntrenador : IREntrenador
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public REntrenador(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Entrenador> ListarEntrenadoresAsIEnum()
        {
            return this._appContext.Entrenadores;
        }

        public List<Entrenador> ListarEntrenadoresAsList()
        {
            return this._appContext.Entrenadores.ToList();
        }

        public bool CrearEntrenador(Entrenador entrenador)
        {
            bool resolve = false;
            if (EntrenadorExiste(entrenador) == false)
            {
                try
                {
                    this._appContext.Entrenadores.Add(entrenador);
                    this._appContext.SaveChanges();
                    resolve = EntrenadorExiste(entrenador) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarEntrenador(Entrenador entrenador)
        {
            bool resolve = false;
            var target = BuscarEntrenadorByID(entrenador.Id);
            if (target != null & !EntrenadorExisteNoKey(entrenador))
            {
                try
                {
                    target.Nombre = entrenador.Nombre;
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

        public bool EliminarEntrenador(int idEntrenador)
        {
            bool resolve = false;
            var target = BuscarEntrenadorByID(idEntrenador);
            if (target != null)
            {
                try
                {
                    this._appContext.Entrenadores.Remove(target);
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
        public Entrenador BuscarEntrenadorByID(int idEntrenador)
        {
            Entrenador entrenador = this._appContext.Entrenadores.Find(idEntrenador);
            return entrenador;
        }

        public bool EntrenadorExiste(Entrenador entrenador)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarEntrenadorByID(entrenador.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreEntrenador = 
            this._appContext.Entrenadores.FirstOrDefault(Columns => Columns.Nombre == entrenador.Nombre);
            targetFound |= (NombreEntrenador != null);

            return targetFound;
        }

        public bool EntrenadorExisteNoKey(Entrenador entrenador)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreEntrenador = 
            this._appContext.Entrenadores.FirstOrDefault(Columns => Columns.Nombre == entrenador.Nombre);
            targetFound |= (NombreEntrenador != null);

            return targetFound;
        }
    }
}