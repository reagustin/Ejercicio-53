using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_53
{
    public class Agenda
    {
        private List<Contacto> _ContactosAgenda;  // ESTO ES LA PARTE PRIVADA DE LA CLASE +++

        public List<Contacto> ContactosAgenda // ESTO ES LA PARTE PUBLICA DE LA CLASE DONDE DEFINIMOS GET Y SET (FUNCIONES DE LOS METODOS)
        {
            get
            {
                return _ContactosAgenda;
            }


            set
            {
                _ContactosAgenda = value;
            }
        }

        public Agenda()
        {
            _ContactosAgenda = new List<Contacto>(); //ES EL CONSTRUCTOR -- TERMINA DE CREAR EL OBJETO +++

        }

        public void AgregarContacto(Contacto contact)

        {            
            _ContactosAgenda.Add(contact); // VOY A AGREGAR EL NUEVO OBJETO CREADO A LA LISTA ContactosAgenda           
            
        }
        
        /// <summary>
        /// EN EL METODO SIGUIENTE AL PRINCIPIO COMETI EL ERROR DE USAR Public Void QUE NO DEVUELVE NADA, TUVE QUE CORREGIR A PUBLIC "NOMBRE DEL OBJETO"
        /// PARA QUE PUEDA FUNCIONAR CONSIDERANDO QUE EL METODO DEVUELVE ALGO, QUE ES UN OBJETO DE LA LISTA DE OBJETOS CONTACTO.
        /// </summary>
        /// <param name="NombreBuscado"></param>
        /// <param name="ApellidoBuscado"></param>
        /// <returns></returns>
        public List<Contacto> BuscarApellido(string ApellidoBuscado)
        {
            List<Contacto> contactosReturn = new List<Contacto>();
            //cambiamos le metodo where por el metodo findall ya que lo que devolvia where en caso que no encuentre nada 
            //no te han explicado otros temas como para aplicarlo, la logica del findall es igual fijate de debuggearlo
            var buscape = _ContactosAgenda.FindAll(x => x.Apellido.Contains(ApellidoBuscado));
            contactosReturn = (List<Contacto>)buscape; // ESTOY CASTEANDO UN OBJETO VAR A UN OBJETO LIST

            return contactosReturn;
        }


        public List<Contacto> BuscarNombre(string NombreBuscado)
        {
            //List<Contacto> contactoReturn = new List<Contacto>();
            
            //contactoReturn = (List<Contacto>)_ContactosAgenda.Where(x => x.Nombre.Contains(NombreBuscado));



            return (List<Contacto>)_ContactosAgenda.FindAll(x => x.Nombre.Contains(NombreBuscado));
        }




        public void GrabarContacto()                   
        {
            string path = @"c:\temp\Ejercicio53.txt";

            if (!File.Exists(path))         //Verifica que no exista la ruta con anteriorirdad.
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("CAI Ejercicio 53:"); //Lo escribe en txt de la ruta.
                }
            }
            else
            {
                if (_ContactosAgenda.Count > 0)
                {
                    foreach (Contacto contacto in _ContactosAgenda)
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(contacto.Nombre + " " + contacto.Apellido + " " + contacto.Telefono);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No hay contactos en la lista para grabar");
                }
            }

            
        }







        public void BorrarContacto(string referencia)
        {  


            //Quiero mostrar todos los contactos
            foreach (Contacto contacto in (_ContactosAgenda.FindAll(x => x.Nombre.Contains(referencia) || x.Apellido.Contains(referencia))))
            {
                Console.WriteLine(contacto.Nombre);
                Console.WriteLine(contacto.Apellido);
                Console.WriteLine(contacto.Telefono);
                Console.WriteLine("El indice es:");
                Console.WriteLine(_ContactosAgenda.IndexOf(contacto));
                
            }

            Console.WriteLine("Ingrese el nro de indice de contacto que desea borrar");

            //El metodo borrar contacto debe recibir la ubicacion del contact segun indice.
            int indice;
            string ingreso;
            
            do
            {
                ingreso = Console.ReadLine();
                if (!Int32.TryParse(ingreso, out indice))
                {
                    Console.WriteLine("Ingresa el numero correcto");
                }

            }
            while (!Int32.TryParse(ingreso, out indice));

            
            _ContactosAgenda.RemoveAt(indice); // ESTA OPCION?
            
            
        }




        public void MostrarContacto()
        {
            string path = @"c:\temp\Ejercicio53.txt";

            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            //Console.WriteLine("Presione una tecla para continuar...");
            //Console.ReadKey();
        }

        

        

    }
}
