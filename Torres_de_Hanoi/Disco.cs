using System;

namespace Torres_de_Hanoi
{
    // Esta clase representa un disco individual del juego.
    // Cada disco se diferencia únicamente por su tamaño (Valor).
    class Disco
    {
        // Propiedad que representa el tamaño del disco.
        // Tiene "private set" para que no pueda modificarse desde fuera
        // una vez creado el objeto (inmutabilidad básica).
        public int Valor { get; private set; }

        // Constructor del disco.
        // Recibe el tamaño como parámetro.
        public Disco(int valor)
        {
            // Validación básica para evitar crear discos inválidos.
            // En el problema matemático no existen discos de tamaño 0 o negativo.
            if (valor <= 0)
                throw new ArgumentException("El valor del disco debe ser mayor que 0.");

            Valor = valor;
        }

        // Sobreescribimos ToString() para que cuando imprimamos un disco
        // en consola, se muestre directamente su tamaño.
        // Esto facilita la visualización del estado de las torres.
        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}
