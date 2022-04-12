using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public abstract class Bird
        {
            public int _wings;
            public Bird(int wings) => _wings = wings;
        }

        interface IFly
        {
            void Fly()
            {
                Console.WriteLine("Hola soy un metodo");
            }
        }

        interface IRun
        {
            int Legs { get; set; }
            void Run();
        }

        interface ISwim
        {
            void Swim();
        }

        public class Ostrich : Bird, IRun, ISwim
        {
            public int _legs;
            public int Legs
            {
                get
                {
                    return _legs;
                }
                set
                {
                    _legs = value;
                }
            
            }

            public Ostrich(int wing) : base(wing)
            {

            }

            public void Run()
            {
                Console.WriteLine("Corre pajarillo");
            }

            public void Swim()
            {
                Console.WriteLine("Nada pajarillo");
            }
        }

    }
}
