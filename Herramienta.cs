using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicando1
{
    internal class Herramienta
    {
        public Herramienta() { }
        public Herramienta(string nom, string desc, string mar, int cod, int stA, int stM, float prUn)
        {
            if (stA >= stM)
            {
                this.StockActual = stA;
                this.StockMinimo = stM; 
            }
            else
            {
                throw new Exception("El stock ACTUAL no puede ser inferior al stock MINIMO");
            }
            this.Nombre = nom;
            this.Descripcion = desc;
            this.Marca = mar;
            this.Codigo = cod;
            this.PrecioUnitario = prUn;
        }

        //Metodos propiedades
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set ;  }
        public int Codigo { get; set ; }
        public int StockActual {  get; set; }
        public int StockMinimo { get; set; }
        public float PrecioUnitario { get; set; }
        //Metodos
        public override string ToString()
        {
            return $"{this.Nombre};{this.Descripcion};{this.Marca};{this.Codigo};{this.StockActual};{this.StockMinimo};{this.PrecioUnitario}";
        }
    }
}
