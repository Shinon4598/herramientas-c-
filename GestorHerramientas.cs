using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Practicando1
{
    internal class GestorHerramientas
    {
        public List<Herramienta> herramientas;
        public GestorHerramientas(string path) {
            this.Path = path;
            herramientas = new List<Herramienta>();
        }
        public string Path {  get; set; }
        //Métodos 
        public void CargarHerramientasDesdeArchivo()
        {
            try
            {
                string herramientasS = File.ReadAllText(this.Path);
                herramientas = JsonSerializer.Deserialize <List<Herramienta>>(herramientasS);
            }catch (IOException ex)
            {
                Console.WriteLine($"Error al cargar herramientas desde el archivo: {ex.Message}");
            }
        }
        public void AgregarHerramienta(Herramienta e)
        {
            try
            {
                herramientas.Add(e);
                string miJosn = JsonSerializer.Serialize(herramientas);
                File.WriteAllText(Path, miJosn);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al agregar herramienta: {ex.Message}");
            } 
        }
        public void ListarHerramientas()
        {
            ListarHerramientas(herramientas);
        }
        private void ListarHerramientas(List<Herramienta> lisH)
        {
            if (File.Exists(this.Path))
            {

                Console.WriteLine("┌────────┬────────┬─────────────┬───────┬────────┬────────┬───────┐");
                Console.WriteLine("│ Codigo │ Nombre │ Descripción │ Marca │ St.Act │ St.Min │  P.U  │");
                Console.WriteLine("├────────┼────────┼─────────────┼───────┼────────┼────────┼───────┤");

                foreach (var h in lisH)
                {
                    string s_A= h.StockActual.ToString();
                    string s_M= h.StockMinimo.ToString();
                    string p_U= h.PrecioUnitario.ToString();
                    Console.Write($"│{h.Codigo, -8}│{h.Nombre,-8}│{h.Descripcion,-13}│{h.Marca,-7}│{s_A,-8}│{s_M,-8}│{p_U,-7}│");
                    Console.WriteLine("\n├────────├────────┼─────────────┼───────┼────────┼────────┼───────┤");
                }
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                throw new FileNotFoundException($"No se ha encontrado el archivo {this.Path}");
            }
        }
        public void BuscarHerramienta(int c)
        {
            List<Herramienta> herramientasEncontradas = herramientas.FindAll(h => h.Codigo == c);
            if (herramientasEncontradas.Count > 0)
            {
                ListarHerramientas(herramientasEncontradas);
            }
            else
            {
                Console.WriteLine("Ninguna herramienta fue encontrada");
            }
        }
        public void QuitarHerramienta(int c)
        {
            try
            {
                herramientas.RemoveAll(h => h.Codigo == c);
                Console.WriteLine($"Elementos eliminados con el código {c}");
                string miJosn = JsonSerializer.Serialize(herramientas);
                File.WriteAllText(this.Path, miJosn);
                ListarHerramientas(herramientas);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
