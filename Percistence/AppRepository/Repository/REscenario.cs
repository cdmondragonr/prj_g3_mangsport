using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class REscenario : IREscenario
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public REscenario(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Escenario> ListarEscenariosAsIEnum()
        {
            return this._appContext.Escenarios;
        }

        public List<Escenario> ListarEscenariosAsList()
        {
            return this._appContext.Escenarios.ToList();
        }

        public bool CrearEscenario(Escenario escenario)
        {
            bool resolve = false;
            if (EscenarioExiste(escenario) == false)
            {
                try
                {
                    this._appContext.Escenarios.Add(escenario);
                    this._appContext.SaveChanges();
                    resolve = EscenarioExiste(escenario) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarEscenario(Escenario escenario)
        {
            bool resolve = false;
            var target = BuscarEscenarioByID(escenario.Id);
            if (target != null & !EscenarioExisteNoKey(escenario))
            {
                try
                {
                    target.Nombre = escenario.Nombre;
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

        public bool EliminarEscenario(int idEscenario)
        {
            bool resolve = false;
            var target = BuscarEscenarioByID(idEscenario);
            if (target != null)
            {
                try
                {
                    this._appContext.Escenarios.Remove(target);
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
        public Escenario BuscarEscenarioByID(int idEscenario)
        {
            Escenario escenario = this._appContext.Escenarios.Find(idEscenario);
            return escenario;
        }

        public bool EscenarioExiste(Escenario escenario)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarEscenarioByID(escenario.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreEscenario = 
            this._appContext.Escenarios.FirstOrDefault(Columns => Columns.Nombre == escenario.Nombre);
            targetFound |= (NombreEscenario != null);

            return targetFound;
        }

        public bool EscenarioExisteNoKey(Escenario escenario)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreEscenario = 
            this._appContext.Escenarios.FirstOrDefault(Columns => Columns.Nombre == escenario.Nombre);
            targetFound |= (NombreEscenario != null);

            return targetFound;
        }
    }
}