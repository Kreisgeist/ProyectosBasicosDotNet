using System;

namespace InyeccionDependenciasCORE5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBebida oBebida = new MediasSeda("picante");
            Cantinero oCantinero = new Cantinero(oBebida);
            oCantinero.Preparar();
        }
    }
}
