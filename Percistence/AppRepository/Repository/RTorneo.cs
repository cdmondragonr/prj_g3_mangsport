using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RTorneo : IRTorneo
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RTorneo(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Torneo> ListarTorneosAsIEnum()
        {
            return this._appContext.Torneos;
        }

        public List<Torneo> ListarTorneosAsList()
        {
            return this._appContext.Torneos.ToList();
        }

        public bool CrearTorneo(Torneo torneo)
        {
            bool resolve = false;
            if (TorneoExiste(torneo) == false)
            {
                try
                {
                    this._appContext.Torneos.Add(torneo);
                    this._appContext.SaveChanges();
                    resolve = TorneoExiste(torneo) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarTorneo(Torneo torneo)
        {
            bool resolve = false;
            var target = BuscarTorneoByID(torneo.Id);
            if (target != null & !TorneoExisteNoKey(torneo))
            {
                try
                {
                    target.Nombre = torneo.Nombre;
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

        public bool EliminarTorneo(int idTorneo)
        {
            bool resolve = false;
            var target = BuscarTorneoByID(idTorneo);
            if (target != null)
            {
                try
                {
                    this._appContext.Torneos.Remove(target);
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
        public Torneo BuscarTorneoByID(int idTorneo)
        {
            Torneo torneo = this._appContext.Torneos.Find(idTorneo);
            return torneo;
        }

        public bool TorneoExiste(Torneo torneo)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarTorneoByID(torneo.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreTorneo = 
            this._appContext.Torneos.FirstOrDefault(Columns => Columns.Nombre == torneo.Nombre);
            targetFound |= (NombreTorneo != null);

            return targetFound;
        }

        public bool TorneoExisteNoKey(Torneo torneo)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreTorneo = 
            this._appContext.Torneos.FirstOrDefault(Columns => Columns.Nombre == torneo.Nombre);
            targetFound |= (NombreTorneo != null);

            return targetFound;
        }
    }
}