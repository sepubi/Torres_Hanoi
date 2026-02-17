using System;

namespace Torres_de_Hanoi
{
    // Clase principal del programa.
    // Se encarga únicamente de la interacción con el usuario
    // y de coordinar las clases del modelo (Disco, Pila, Hanoi).
    class Program
    {
        static void Main(string[] args)
        {
            // Presentación inicial del programa
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine("3 torres\n");

            int n;

            // =========================
            // PEDIR NÚMERO DE DISCOS
            // =========================

            // Bucle de validación para asegurarnos de que el usuario
            // introduce un número entero mayor que 0.
            while (true)
            {
                Console.Write("Indica el número de discos... ");

                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;

                Console.WriteLine("Introduce un número válido mayor que 0.");
            }

            Console.WriteLine($"\nHas seleccionado {n} discos\n");

            // =========================
            // ELEGIR MÉTODO
            // =========================

            char metodo;

            // Bucle hasta que el usuario seleccione I o R.
            while (true)
            {
                Console.Write("Indica I para Iterativo o R para Recursivo... ");
                metodo = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (metodo == 'I' || metodo == 'R')
                    break;

                Console.WriteLine("Opción no válida.");
            }

            Console.WriteLine($"Has seleccionado el método {metodo}\n");

            // =========================
            // CREAR TORRES
            // =========================

            // Se crean las tres torres del juego.
            // Se les asigna nombre para mostrarlas correctamente por consola.
            Pila ini = new Pila("Torre INI");
            Pila aux = new Pila("Torre AUX");
            Pila fin = new Pila("Torre FIN");

            // =========================
            // INICIALIZAR DISCOS
            // =========================

            // Los discos se insertan de mayor a menor.
            // Esto garantiza que el más grande quede abajo
            // y el más pequeño arriba (estructura válida).
            for (int i = n; i >= 1; i--)
            {
                ini.push(new Disco(i));
            }

            Hanoi hanoi = new Hanoi();
            int movimientos = 0;

            // =========================
            // MOSTRAR ESTADO INICIAL
            // =========================

            Console.WriteLine("Situación inicial");
            ini.Mostrar();
            aux.Mostrar();
            fin.Mostrar();
            Console.WriteLine();

            // =========================
            // EJECUTAR MÉTODO ELEGIDO
            // =========================

            if (metodo == 'I')
            {
                movimientos = hanoi.iterativo(n, ini, fin, aux);
            }
            else
            {
                movimientos = hanoi.recursivo(n, ini, fin, aux);
            }

            // =========================
            // RESULTADO FINAL
            // =========================

            Console.WriteLine($"\nResuelto en {movimientos} movimientos");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
