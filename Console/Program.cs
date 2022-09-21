using Domain;
using Percistence;
using System;
using System.Collections.Generic;

namespace MyConsole
{
    class Program
    {
        //variables globales
        static int userInput;
        static List<string> menuList = new List<string>();
        static IRMunicipio _repoMunicipio = new RMunicipio(new Percistence.AppContext());

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        //Creacion de funciones
        private static void MenuPrincipal()
        {
            menuList.Add(" ");
            menuList.Add("*** Menu Principal ***");
            menuList.Add("1. Crear Municipio");
            menuList.Add("2. Buscar Municipio");
            menuList.Add("3. Actualiza Municipio");
            menuList.Add("4. Eliminar Municipio");
            menuList.Add("5. Listar Municipios");
            menuList.Add(" ");
            menuList.Add("Seleccione la accion que desea realizar (1..5)");

            menuList.ForEach(item => Console.WriteLine(item));

            userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        addMunicipio();
                        break;
                    }
                case 2:
                    {
                        buscarMunicipio();
                        break;
                    }
                case 3:
                    {
                        actualizarMunicipio();
                        break;
                    }
                case 4:
                    {
                        eliminarMunicipio();
                        break;
                    }
                case 5:
                    {
                        listarMunicipios();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("favor ingrese una userInputcion valida (1..5)");
                        recargar();
                        break;
                    }
            }
        }

        private static void addMunicipio()
        {
            Municipio objMunicipio = new Municipio();
            Console.WriteLine("Ingrese el nombre del nuevo municipio");
            objMunicipio.Nombre = Console.ReadLine();
            bool resolve = _repoMunicipio.CrearMunicipio(objMunicipio);

            if (resolve)
            {
                Console.WriteLine("Municipio adicionado correctamente...");
                recargar();
            }
            else
            {
                Console.WriteLine("Error en el proceso...");
                recargar();
            }
        }

        private static void buscarMunicipio()
        {
            Municipio target = null;
            Console.WriteLine("Ingrese el Id del municipio que desea buscar");
            target = _repoMunicipio.BuscarMunicipioByID(int.Parse(Console.ReadLine()));
            if (target != null)
            {
                Console.WriteLine(target.Id);
                Console.WriteLine(target.Nombre);
                recargar();
            }
            else
            {
                Console.WriteLine("Municipio no encontrado...");
                recargar();
            }
        }

        private static void actualizarMunicipio()
        {
            Municipio target = new Municipio();
            Console.WriteLine("Ingrese el codigo del municipio que desea modificar");
            target.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del municipio");
            target.Nombre = Console.ReadLine();

            bool resolve = _repoMunicipio.ActualizarMunicipio(target);
            if (resolve)
            {
                Console.WriteLine("Municipio actualizado con exito...");
                recargar();
            }
            else
            {
                Console.WriteLine("No fue posile aplicar la modificacion");
                recargar();
            }
        }

        private static void eliminarMunicipio()
        {
            Console.WriteLine("Ingrese el Id del Municipio a eliminar ");
            int id = int.Parse(Console.ReadLine());

            bool resolve = _repoMunicipio.EliminarMunicipio(id);
            if (resolve)
            {
                Console.WriteLine("Municipio eliminado con exito...");
                recargar();
            }
            else
            {
                Console.WriteLine("No fue posible eliminar el municipio");
                recargar();
            }
        }

        private static void listarMunicipios()
        {
            List<Municipio> listaMunicipios = _repoMunicipio.ListarMunicipiosAsList();
            foreach (var municipio in listaMunicipios)
            {
                Console.WriteLine(municipio.Id + " _ " + municipio.Nombre);
            }
            recargar();
        }

        private static void recargar()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadLine();
            Console.Clear();
            MenuPrincipal();
        }
    }
}
