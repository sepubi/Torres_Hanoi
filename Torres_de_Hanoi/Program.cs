using System;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine("3 torres\n");

            int n;

            // Pedir número de discos
            while (true)
            {
                Console.Write("Indica el número de discos... ");
                if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                    break;

                Console.WriteLine("Introduce un número válido mayor que 0.");
            }

            Console.WriteLine($"\nHas seleccionado {n} discos\n");

            // Elegir método
            char metodo;

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

            // Crear torres
            Pila ini = new Pila("Torre INI");
            Pila aux = new Pila("Torre AUX");
            Pila fin = new Pila("Torre FIN");

            // Inicializar discos
            for (int i = n; i >= 1; i--)
            {
                ini.push(new Disco(i));
            }

            Hanoi hanoi = new Hanoi();
            int movimientos = 0;

            // Mostrar situación inicial
            Console.WriteLine("Situación inicial");
            ini.Mostrar();
            aux.Mostrar();
            fin.Mostrar();
            Console.WriteLine();

            // Ejecutar método elegido
            if (metodo == 'I')
            {
                movimientos = hanoi.iterativo(n, ini, fin, aux);
            }
            else
            {
                movimientos = hanoi.recursivo(n, ini, fin, aux);
            }

            Console.WriteLine($"\nResuelto en {movimientos} movimientos");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
