using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
        class Disco
        {
            public int Valor { get; set; } // Tamaño del disco

            public Disco(int valor)
            {
                Valor = valor;
            }

            public override string ToString()
            {
            return Valor.ToString();
            }
        }
    }