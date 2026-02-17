using System;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        private int movimientosRecursivo = 0;

        // =========================
        // MOVER DISCO
        // =========================
        public int mover_disco(Pila a, Pila b)
        {
            Disco d;

            if (a.isEmpty())
            {
                d = b.pop();
                a.push(d);
                return 1;
            }

            if (b.isEmpty())
            {
                d = a.pop();
                b.push(d);
                return 1;
            }

            if (a.Top.Valor < b.Top.Valor)
            {
                d = a.pop();
                b.push(d);
            }
            else
            {
                d = b.pop();
                a.push(d);
            }

            return 1;
        }

        // =========================
        // ITERATIVO
        // =========================
        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int movimientos = 0;

            while (fin.Size != n)
            {
                if (n % 2 != 0)
                {
                    movimientos += mover_disco(ini, fin);
                    MostrarEstado(movimientos, ini, aux, fin);
                    if (fin.Size == n) break;

                    movimientos += mover_disco(ini, aux);
                    MostrarEstado(movimientos, ini, aux, fin);
                    if (fin.Size == n) break;

                    movimientos += mover_disco(aux, fin);
                    MostrarEstado(movimientos, ini, aux, fin);
                }
                else
                {
                    movimientos += mover_disco(ini, aux);
                    MostrarEstado(movimientos, ini, aux, fin);
                    if (fin.Size == n) break;

                    movimientos += mover_disco(ini, fin);
                    MostrarEstado(movimientos, ini, aux, fin);
                    if (fin.Size == n) break;

                    movimientos += mover_disco(aux, fin);
                    MostrarEstado(movimientos, ini, aux, fin);
                }
            }

            return movimientos;
        }

        // =========================
        // RECURSIVO
        // =========================
        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            movimientosRecursivo = 0;
            RecursivoInterno(n, ini, fin, aux);
            return movimientosRecursivo;
        }

        private void RecursivoInterno(int n, Pila ini, Pila fin, Pila aux)
        {
            if (n == 1)
            {
                movimientosRecursivo += mover_disco(ini, fin);
                MostrarEstado(movimientosRecursivo, ini, aux, fin);
                return;
            }

            RecursivoInterno(n - 1, ini, aux, fin);

            movimientosRecursivo += mover_disco(ini, fin);
            MostrarEstado(movimientosRecursivo, ini, aux, fin);

            RecursivoInterno(n - 1, aux, fin, ini);
        }

        // =========================
        // MOSTRAR ESTADO
        // =========================
        private void MostrarEstado(int movimiento, Pila ini, Pila aux, Pila fin)
        {
            Console.WriteLine($"Situación tras el movimiento {movimiento}");
            ini.Mostrar();
            aux.Mostrar();
            fin.Mostrar();
            Console.WriteLine();
        }
    }
}
