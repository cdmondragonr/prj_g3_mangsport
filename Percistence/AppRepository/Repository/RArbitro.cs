using Domain;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Percistence
{
    public class RArbitro : IRArbitro
    {
        //Atributos
        private readonly AppContext _appContext;

        //Metodos

        //Constructor por defecto
        public RArbitro(AppContext appContext)
        {
            this._appContext = appContext;
        }

        public IEnumerable<Arbitro> ListarArbitrosAsIEnum()
        {
            return this._appContext.Arbitros;
        }

        public List<Arbitro> ListarArbitrosAsList()
        {
            return this._appContext.Arbitros.ToList();
        }

        public bool CrearArbitro(Arbitro arbitro)
        {
            bool resolve = false;
            if (ArbitroExiste(arbitro) == false)
            {
                try
                {
                    this._appContext.Arbitros.Add(arbitro);
                    this._appContext.SaveChanges();
                    resolve = ArbitroExiste(arbitro) ? true : false;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return resolve;
        }

        public bool ActualizarArbitro(Arbitro arbitro)
        {
            bool resolve = false;
            var target = BuscarArbitroByID(arbitro.Id);
            if (target != null & !ArbitroExisteNoKey(arbitro))
            {
                try
                {
                    target.Nombre = arbitro.Nombre;
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

        public bool EliminarArbitro(int idArbitro)
        {
            bool resolve = false;
            var target = BuscarArbitroByID(idArbitro);
            if (target != null)
            {
                try
                {
                    this._appContext.Arbitros.Remove(target);
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
        public Arbitro BuscarArbitroByID(int idArbitro)
        {
            Arbitro arbitro = this._appContext.Arbitros.Find(idArbitro);
            return arbitro;
        }

        public bool ArbitroExiste(Arbitro arbitro)
        {
            bool targetFound = false;

            //Verificar si exixte por ID
            targetFound |= (BuscarArbitroByID(arbitro.Id) != null);

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreArbitro = 
            this._appContext.Arbitros.FirstOrDefault(Columns => Columns.Nombre == arbitro.Nombre);
            targetFound |= (NombreArbitro != null);

            return targetFound;
        }

        public bool ArbitroExisteNoKey(Arbitro arbitro)
        {
            bool targetFound = false;

            //Aqui todos las otras columnas que se requieran comparar existencia
            var NombreArbitro = 
            this._appContext.Arbitros.FirstOrDefault(Columns => Columns.Nombre == arbitro.Nombre);
            targetFound |= (NombreArbitro != null);

            return targetFound;
        }
    }
}