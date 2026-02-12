using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    class Pila
    {
        public int Size { get { return Elementos.Count; } } // Cantidad de discos
        public Disco Top { get { return Elementos.Count > 0 ? Elementos[Elementos.Count - 1] : null; } } // Disco superior
        public List<Disco> Elementos { get; set; } // Conjunto de discos
        public string Nombre { get; set; } // Nombre de la pila

        public Pila(string nombre)
        {
            Nombre = nombre;
            Elementos = new List<Disco>();
        }

        public void push(Disco d)
        {
            if (Top == null || Top.Valor > d.Valor)
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
            if (Elementos.Count == 0) return null;
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
            foreach (var disco in Elementos)
                Console.Write(disco.Valor + " ");
            Console.WriteLine();
        }
    }
}
