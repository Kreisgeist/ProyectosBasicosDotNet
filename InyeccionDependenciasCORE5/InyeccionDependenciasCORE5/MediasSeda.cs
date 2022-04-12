using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InyeccionDependenciasCORE5
{
    public class MediasSeda : IBebida
    {
        public string tipo { get; set; }
        public MediasSeda(string tipo)
        {
            this.tipo = tipo;
        }
        public void Preparar()
        {
            Console.WriteLine("Se hace una media de seda " + tipo);
        }
    }
}
