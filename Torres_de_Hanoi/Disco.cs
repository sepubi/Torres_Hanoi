using System;

namespace Torres_de_Hanoi
{
    class Disco
    {
        // Tamaño del disco
        public int Valor { get; private set; }

        public Disco(int valor)
        {
            if (valor <= 0)
                throw new ArgumentException("El valor del disco debe ser mayor que 0.");

            Valor = valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
