using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InyeccionDependenciasCORE5
{
    public class PinaColada : IBebida
    {
        public void Preparar()
        {
            Console.WriteLine("Se hace una piña colada");
        }
    }
}
