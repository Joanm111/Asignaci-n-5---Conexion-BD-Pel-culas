
using Asignación_5___Conexion_BD_Películas.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace Asignación_5___Conexion_BD_Películas
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            using (Models.peliculasContext DB = new peliculasContext())
            {


                string opcion = "";



                do
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine("** menu principal **" +
                        "\n 1. Agregar Pelicula" +
                        "\n 2. Mostrar la lista " +
                        "\n 3. Editar" +
                        "\n 4. Eliminar" +
                        "\n 5. Salir"
                         +
                        "\n"
                        );

                    opcion = Console.ReadLine();
                  

                    switch (opcion)
                    {
                        case "1":
                            {
                                Console.WriteLine("Escriba el nombre de la pelicula");
                                var nombre = Console.ReadLine();
                                Console.WriteLine("Seleccione el genero de la pelicula \n  \n accion = 1 \n comedia = 2 \n terror = 3 \n drama = 4 \n infantil = 5 ");
                                string genero = Console.ReadLine();
                                var x = new Pelicula();
                                x.Nombre = nombre;
                                x.Generoid = int.Parse(genero);
                                DB.Pelicula.Add(x);
                                DB.SaveChanges();
                               

                            }

                            break;

                        case "2":

                            var a = from s in DB.Pelicula
                                    from g in DB.Genero
                                    where s.Generoid == g.Id
                                    select new
                                    {
                                        s.Nombre,
                                        g.Genero1,
                                    };
                            Console.WriteLine("\n");
                            foreach (var x in a)
                            {
                                Console.WriteLine($"{x.Nombre} {x.Genero1} ");}
                            Console.Read();
                            break;

                        case "3":
                            var u = from s in DB.Pelicula
                                    from g in DB.Genero
                                    where s.Generoid == g.Id
                                    select new
                                    {
                                        s.Nombre,
                                        g.Genero1,
                                    };

                            foreach (var o in u)
                            {
                                Console.WriteLine($"{o.Nombre}{o.Genero1} ");
                            
                             }
                            Console.Read();
                            Console.WriteLine("");
                            Console.ReadLine();
                            Console.WriteLine(" escriba el nombre de la pelicula que quiere remplazar");
                            string nombre2 = Console.ReadLine();
         
                            var query = (from t in DB.Pelicula from e in DB.Genero
                                         where t.Generoid == e.Id && t.Nombre == nombre2 

                                         select t);


                            Console.WriteLine(" escriba el nombre de la nueva pelicula");
                            string nombre1 = Console.ReadLine();
                            Console.WriteLine("Seleccione el genero de la pelicula \n  \n accion = 1 \n comedia = 2 \n terror = 3 \n drama = 4 \n infantil = 5 ");
                            string genero1 = Console.ReadLine();

                            foreach (var ord in query)
                            {
                                ord.Nombre = nombre1;
                                ord.Generoid = int.Parse(genero1);
                               
                            }
                            try
                            {
                                DB.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }


                            Console.Read();
                            break;


                        case "4":

                            var y = from s in DB.Pelicula
                                    from g in DB.Genero
                                    where s.Generoid == g.Id
                                    select new
                                    {
                                        s.Nombre,
                                        g.Genero1,
                                    };

                            foreach (var o in y)
                            {
                                Console.WriteLine($"{o.Nombre}{o.Genero1} ");

                            }
                            Console.Read();
                            Console.WriteLine("");
                            Console.ReadLine();


                            Console.WriteLine("nombre de la pelicula que va a eliminar");
                            string eliminar = Console.ReadLine();


                            var query1 = (from t in DB.Pelicula
                                        
                                         where t.Nombre == eliminar

                                         select t);


                             foreach (var ord in query1)
                            {
                               DB.Remove(ord);

                            }
                            try
                            {
                                DB.SaveChanges();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                            Console.Read(); 



                            break;
                  

                          


                        case "5":
                            opcion = "5";
                            break;

                        default:
                            Console.WriteLine("elige una opcion del menu");
                            break;
                    }

                } while (opcion != "5");





           




            }

        }
    }
}
