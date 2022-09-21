using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RMunicipio : IRMunicipio
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RMunicipio(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Municipio> ListarMunicipiosAsIEnum()
        {
            return this._appContext.Municipios;
        }

        public List<Municipio> ListarMunicipiosAsList()
        {
            return this._appContext.Municipios.ToList();
        }

        public bool CrearMunicipio(Municipio municipio)
        {
            bool resolve = false;
            if (MunicipioExiste(municipio) == false)
            {
                try
                {
                    this._appContext.Municipios.Add(municipio);
                    this._appContext.SaveChanges();
                    resolve = MunicipioExiste(municipio) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarMunicipio(Municipio municipio)
        {
            bool resolve = false;
            var target = BuscarMunicipioByID(municipio.Id);
            if (target != null & !MunicipioExisteNoKey(municipio))
            {
                try
                {
                    target.Nombre = municipio.Nombre;
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

        public bool EliminarMunicipio(int idMunicipio)
        {
            bool resolve = false;
            var target = BuscarMunicipioByID(idMunicipio);
            if (target != null)
            {
                try
                {
                    this._appContext.Municipios.Remove(target);
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
        public Municipio BuscarMunicipioByID(int idMunicipio)
        {
            Municipio municipio = this._appContext.Municipios.Find(idMunicipio);
            return municipio;
        }

        public bool MunicipioExiste(Municipio municipio)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarMunicipioByID(municipio.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreMunicipio = 
            this._appContext.Municipios.FirstOrDefault(Columns => Columns.Nombre == municipio.Nombre);
            targetFound |= (NombreMunicipio != null);

            return targetFound;
        }

        public bool MunicipioExisteNoKey(Municipio municipio)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreMunicipio = 
            this._appContext.Municipios.FirstOrDefault(Columns => Columns.Nombre == municipio.Nombre);
            targetFound |= (NombreMunicipio != null);

            return targetFound;
        }
    }
}