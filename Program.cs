using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicando1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\algui\Downloads\C#\archivos practica\Lista.txt";
            if (File.Exists(path))
            {
                    Menu(path);
            }
            else
            {
                using (FileStream fs = File.Create(path))
                {
                    Console.WriteLine($"Se creo el archivo \"Lista.txt\" en la ubicación {path}");
                }
                Menu(path);
            }
        }
        static void Menu(string path)
        {
            GestorHerramientas gh = new GestorHerramientas(path);
            gh.CargarHerramientasDesdeArchivo();
            bool continuar = true;
            do
            {
                Console.WriteLine("Eliga una opción");
                Console.WriteLine("┌─────────────────────────┐");
                Console.WriteLine("│ a. Agregar Herramienta  │");
                Console.WriteLine("├─────────────────────────┤");
                Console.WriteLine("│ b. Quitar Herramienta   │");
                Console.WriteLine("├─────────────────────────┤");
                Console.WriteLine("│ c. Listar               │");
                Console.WriteLine("├─────────────────────────┤");
                Console.WriteLine("│ d. Buscar               │");
                Console.WriteLine("├─────────────────────────┤");
                Console.WriteLine("│ Z. Salir                │");
                Console.WriteLine("└─────────────────────────┘");

                char opcion = Console.ReadKey().KeyChar;
                Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case 'a': AgregarHerramienta(gh); break;
                    case 'b': QuitarHerramienta(gh);break;
                    case 'c': ListarHerramientas(gh); break;
                    case 'd': BuscarHerramienta(gh); break;
                    case 'z': Console.WriteLine("Hasta pronto!"); continuar = false; break;
                    default: Console.WriteLine("Ingrese una opción valida"); break;
                }
            } while (continuar);
        }
        public static void AgregarHerramienta(GestorHerramientas gh)
        {
            string nombre, descripcion, marca;
            int codigo, stockActual, stockMinimo;
            float precioUnitario;

            //│{h.Nombre,-8}│{h.Descripcion,-13}│{h.Marca,-7}│{s_A,-8}│{s_M,-8}│{p_U,-7}│");

            Console.WriteLine("Ingrese el nombre");
            nombre = ParseString(8);
            Console.WriteLine("Ingrese la descripción");
            descripcion = ParseString(13);
            Console.WriteLine("Ingrese la marca");
            marca = ParseString(7);
            Console.WriteLine("Ingrese el código");
            codigo = ParseInt(8);
            Console.WriteLine("Ingrese el stock actual");
            stockActual = ParseInt(8);
            Console.WriteLine("Ingrese el stock minimo");
            stockMinimo = ParseInt(8);
            Console.WriteLine("Precio unitario");
            precioUnitario = ParseFloat(7);
            Console.Clear();
            try
            {
                Herramienta e = new Herramienta(nombre, descripcion, marca, codigo, stockActual, stockMinimo, precioUnitario);
                gh.AgregarHerramienta(e);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public static int ParseInt(int max)
        { 
            int r;
            string s= Console.ReadLine();
            while (!int.TryParse(s, out r) || s.Length > max)
            {
                Console.WriteLine($"Ingrese un numero entero con longitud menor a {max}");
                s = Console.ReadLine();
            }
            return r;
        }
        public static float ParseFloat(int max)
        {
            float r;
            string s = Console.ReadLine();
            while (!float.TryParse(s, out r) || s.Length > max)
            {
                Console.WriteLine($"Ingrese un numero entero con longitud menor a {max}");
                s = Console.ReadLine();
            }
            return r;
        }
        public static string ParseString(int max)
        {
            string s = Console.ReadLine();
            while (string.IsNullOrEmpty(s) || s.Length > max)
            {
                Console.WriteLine($"Ingrese un valor valido con longitud menor a {max}");
                s = Console.ReadLine();
            }
            return s;
        }
        public static void ListarHerramientas(GestorHerramientas gh)
        {
            try
            {
                gh.ListarHerramientas();
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public static void BuscarHerramienta(GestorHerramientas gh)
        {
            Console.WriteLine("Ingrese el codigo de la herramienta");
            int b = ParseInt(8);

            gh.BuscarHerramienta(b);
        }
        public static void QuitarHerramienta(GestorHerramientas gh)
        {
            Console.WriteLine("Ingrese el codigo de la herramienta");
            int b = ParseInt(8);

            gh.QuitarHerramienta(b);
        }

    }
}
