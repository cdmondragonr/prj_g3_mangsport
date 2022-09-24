using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RPatrocinador : IRPatrocinador
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RPatrocinador(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Patrocinador> ListarPatrocinadoresAsIEnum()
        {
            return this._appContext.Patrocinadores;
        }

        public List<Patrocinador> ListarPatrocinadoresAsList()
        {
            return this._appContext.Patrocinadores.ToList();
        }

        public bool CrearPatrocinador(Patrocinador patrocinador)
        {
            bool resolve = false;
            if (PatrocinadorExiste(patrocinador) == false)
            {
                try
                {
                    this._appContext.Patrocinadores.Add(patrocinador);
                    this._appContext.SaveChanges();
                    resolve = PatrocinadorExiste(patrocinador) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarPatrocinador(Patrocinador patrocinador)
        {
            bool resolve = false;
            var target = BuscarPatrocinadorByID(patrocinador.Id);
            if (target != null & !PatrocinadorExisteNoKey(patrocinador))
            {
                try
                {
                    target.Nombre = patrocinador.Nombre;
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

        public bool EliminarPatrocinador(int idPatrocinador)
        {
            bool resolve = false;
            var target = BuscarPatrocinadorByID(idPatrocinador);
            if (target != null)
            {
                try
                {
                    this._appContext.Patrocinadores.Remove(target);
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
        public Patrocinador BuscarPatrocinadorByID(int idPatrocinador)
        {
            Patrocinador patrocinador = this._appContext.Patrocinadores.Find(idPatrocinador);
            return patrocinador;
        }

        public bool PatrocinadorExiste(Patrocinador patrocinador)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarPatrocinadorByID(patrocinador.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombrePatrocinador = 
            this._appContext.Patrocinadores.FirstOrDefault(Columns => Columns.Nombre == patrocinador.Nombre);
            targetFound |= (NombrePatrocinador != null);

            return targetFound;
        }

        public bool PatrocinadorExisteNoKey(Patrocinador patrocinador)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombrePatrocinador = 
            this._appContext.Patrocinadores.FirstOrDefault(Columns => Columns.Nombre == patrocinador.Nombre);
            targetFound |= (NombrePatrocinador != null);

            return targetFound;
        }
    }
}