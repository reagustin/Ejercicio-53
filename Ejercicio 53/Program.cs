using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Ejercicio_53
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleKeyInfo cki;
            // Evita que se cierra con control C
            //Console.TreatControlCAsInput = true;
            string nom;
            string ape;
            
            //Estaba adentro del do.. !!!! (nota personal para no olvidar)
            Agenda AgendaInstanciada;
            AgendaInstanciada = new Agenda();
            //Estaba adentro del do.. !!!!

            ConsoleKeyInfo opcion;
            do
            {



                menu();
                opcion = Console.ReadKey();
                switch (opcion.KeyChar)
                {
                    case 'a':
                        Contacto Contact = new Contacto();
                        Console.WriteLine("Agrege un nombre");
                        Contact.Nombre = Console.ReadLine(); // LE MANDO EL NOMBRE
                        Console.WriteLine("Agrege un apellido");
                        Contact.Apellido = Console.ReadLine(); // LE MANDO EL APELLIDO
                        Console.WriteLine("Agrege un telefono");
                        Contact.Telefono = Console.ReadLine(); // LE MANDO EL TELEFONO
                                                               // YA TENGO UN OBJETO LLAMADO "contact"  Y LO TENGO QUE MANDAR A LA CLASE AGENDA 
                                                               //PARA QUE LA CLASE AGENDA LO GUARDE CON EL METODO CORRESPONDIENTE EN LA LISTA DE OBJETOS

                         //INSTANCIO LA CLASE AGENDA
                        AgendaInstanciada.AgregarContacto(Contact); // INVOCO LA ANGEDA . LLAMO AL METODO . (OBJETO QUE LE MANDO)


                        break;
                    case 'b':

                        Console.WriteLine("Ingrese el apellido que desea buscar");
                        ape = Console.ReadLine();


                          // tendria que invocarlo fuera del case?


                        List<Contacto> Contactos = AgendaInstanciada.BuscarApellido(ape); // devuelvo la lista encontrada

                        foreach (Contacto contacto in Contactos)
                        {
                            Console.WriteLine(contacto.Nombre + " " + contacto.Apellido + " " + contacto.Telefono);
                        }
                        //esta es la famosa linea con $ no me funcino como la dejamos, te escribo tal como la conozco yo con string .format
                        Console.WriteLine(string.Format("La cantidad de contactos {0}", Contactos.Count()));

                        Console.WriteLine("Presiona una tecla para continuar...");
                        Console.ReadKey();

                        break;

                    case 'c':

                        Console.WriteLine("Ingrese el nombre que desea buscar");
                        nom = Console.ReadLine();

                        List<Contacto> Contactos1 = AgendaInstanciada.BuscarNombre(nom);
                        
                        foreach (Contacto contacto in Contactos1)
                        {
                            Console.WriteLine(contacto.Nombre + " " + contacto.Apellido + " " + contacto.Telefono);
                        }
                        Console.WriteLine(string.Format("La cantidad de contactos {0}", Contactos1.Count()));

                        Console.WriteLine("Presiona una tecla para continuar...");
                        Console.ReadKey();

                        break;
                    case 'd':

                        AgendaInstanciada.GrabarContacto();
                        
                        Console.WriteLine("La operacion ha finalizado, presione una tecla para continuar");
                        Console.ReadKey();
                        break;
                    case 'e':

                        AgendaInstanciada.MostrarContacto();
                        Console.WriteLine("La operacion ha finalizado, presione una tecla para continuar");
                        Console.ReadKey();

                        break;
                    
                    case 'f':

                        Console.WriteLine("Ingrese nombre o apellido del contacto que desea buscar:");
                        string referencia = Console.ReadLine();
                        AgendaInstanciada.BorrarContacto(referencia);

                        break;
                    
                    case 'g':
                        break;
                    default:
                        break;
                }
            }
            while (opcion.KeyChar != 'g');
            
            
        }

        private static void menu()

        {

            Console.Clear();
            Console.WriteLine("Elija una de las opciones siguientes tipeando una tecla");
            Console.WriteLine("a.Ingresar datos (Apellido, Nombre, Teléfono");
            Console.WriteLine("b.Buscar por apellido");
            Console.WriteLine("c.Buscar por nombre");
            Console.WriteLine("d.Grabar datos");
            Console.WriteLine("e.Leer datos");
            Console.WriteLine("f.Borrar contacto");
            Console.WriteLine("g.Finalizar");



        }
    }
}
