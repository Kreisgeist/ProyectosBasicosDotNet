using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InyeccionDependenciasCORE5
{
    internal class Cantinero
    {
        IBebida bebida;

        //Constructor
        public Cantinero(IBebida bebida)
        {
            this.bebida = bebida;
        }

        public void Preparar()
        {
            this.bebida.Preparar();
        }
    }
}
