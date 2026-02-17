using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    class Pila
    {
        public string Nombre { get; private set; }

        private List<Disco> Elementos;

        public int Size
        {
            get { return Elementos.Count; }
        }

        public Disco Top
        {
            get
            {
                if (isEmpty())
                    return null;

                return Elementos[Elementos.Count - 1];
            }
        }

        public Pila(string nombre)
        {
            Nombre = nombre;
            Elementos = new List<Disco>();
        }

        public void push(Disco d)
        {
            if (d == null)
                throw new ArgumentNullException("No se puede insertar un disco nulo.");

            if (isEmpty() || Top.Valor > d.Valor)
            {
                Elementos.Add(d);
            }
            else
            {
                throw new InvalidOperationException("No se puede colocar un disco más grande sobre uno más pequeño.");
            }
        }

        public Disco pop()
        {
            if (isEmpty())
                throw new InvalidOperationException("No se puede extraer de una pila vacía.");

            Disco d = Top;
            Elementos.RemoveAt(Elementos.Count - 1);
            return d;
        }

        public bool isEmpty()
        {
            return Elementos.Count == 0;
        }

        public void Mostrar()
        {
            Console.Write($"{Nombre}: ");

            if (isEmpty())
            {
                Console.WriteLine("(vacía)");
                return;
            }

            foreach (var disco in Elementos)
                Console.Write(disco + " ");

            Console.WriteLine();
        }
    }
}
