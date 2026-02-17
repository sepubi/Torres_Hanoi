using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    // Esta clase representa una torre del juego.
    // Internamente funciona como una estructura de tipo Pila (Stack),
    // es decir, el último elemento en entrar es el primero en salir (LIFO).
    class Pila
    {
        // Nombre de la torre (INI, AUX o FIN).
        // Es de solo lectura para evitar modificaciones externas.
        public string Nombre { get; private set; }

        // Lista interna que almacena los discos.
        // Se mantiene privada para respetar el principio de encapsulación.
        private List<Disco> Elementos;

        // Propiedad que devuelve el número de discos actuales en la torre.
        public int Size
        {
            get { return Elementos.Count; }
        }

        // Propiedad que devuelve el disco superior (Top) de la pila.
        // Si está vacía devuelve null.
        public Disco Top
        {
            get
            {
                if (isEmpty())
                    return null;

                // El último elemento de la lista representa el tope de la pila.
                return Elementos[Elementos.Count - 1];
            }
        }

        // Constructor: inicializa la torre con un nombre y una lista vacía.
        public Pila(string nombre)
        {
            Nombre = nombre;
            Elementos = new List<Disco>();
        }

        // Método push: inserta un disco en la torre.
        // Solo permite insertarlo si respeta la regla del juego:
        // No se puede colocar un disco grande sobre uno pequeño.
        public void push(Disco d)
        {
            if (d == null)
                throw new ArgumentNullException("No se puede insertar un disco nulo.");

            // Se permite insertar si:
            // - La torre está vacía
            // - El disco superior es mayor que el nuevo disco
            if (isEmpty() || Top.Valor > d.Valor)
            {
                Elementos.Add(d);
            }
            else
            {
                // Si no se cumple la regla, lanzamos excepción
                // para evitar estados inválidos.
                throw new InvalidOperationException(
                    "No se puede colocar un disco más grande sobre uno más pequeño.");
            }
        }

        // Método pop: extrae el disco superior de la torre.
        // Sigue la lógica LIFO.
        public Disco pop()
        {
            if (isEmpty())
                throw new InvalidOperationException(
                    "No se puede extraer de una pila vacía.");

            Disco d = Top;
            Elementos.RemoveAt(Elementos.Count - 1);
            return d;
        }

        // Método que indica si la torre está vacía.
        public bool isEmpty()
        {
            return Elementos.Count == 0;
        }

        // Método auxiliar para mostrar el estado actual de la torre por consola.
        public void Mostrar()
        {
            Console.Write($"{Nombre}: ");

            if (isEmpty())
            {
                Console.WriteLine("(vacía)");
                return;
            }

            // Se imprimen los discos en el orden almacenado.
            foreach (var disco in Elementos)
                Console.Write(disco + " ");

            Console.WriteLine();
        }
    }
}
