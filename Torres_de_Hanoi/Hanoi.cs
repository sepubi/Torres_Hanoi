using System;

namespace Torres_de_Hanoi
{
    // Esta clase contiene la lógica del juego:
    // - Movimiento válido entre torres
    // - Algoritmo iterativo
    // - Algoritmo recursivo
    class Hanoi
    {
        // Variable usada únicamente para contar movimientos en la versión recursiva.
        // Se mantiene como atributo de clase para que pueda acumularse entre llamadas recursivas.
        private int movimientosRecursivo = 0;

        // =========================
        // MOVER DISCO
        // =========================

        // Este método recibe dos torres (a y b) y realiza el único movimiento válido posible entre ellas.
        // Devuelve 1 porque siempre realiza exactamente un movimiento.
        public int mover_disco(Pila a, Pila b)
        {
            Disco d;

            // Si la torre A está vacía, el movimiento solo puede ser de B hacia A.
            if (a.isEmpty())
            {
                d = b.pop();
                a.push(d);
                return 1;
            }

            // Si la torre B está vacía, el movimiento solo puede ser de A hacia B.
            if (b.isEmpty())
            {
                d = a.pop();
                b.push(d);
                return 1;
            }

            // Si ambas tienen discos, movemos el disco más pequeño.
            // Esto garantiza que nunca pongamos uno grande encima de uno pequeño.
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

        // Implementación del algoritmo iterativo mínimo.
        // Sigue el patrón descrito en el enunciado:
        // - Si n es impar: INI-FIN, INI-AUX, AUX-FIN
        // - Si n es par:   INI-AUX, INI-FIN, AUX-FIN
        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int movimientos = 0;

            // Se repite hasta que todos los discos estén en la torre final.
            while (fin.Size != n)
            {
                if (n % 2 != 0) // Caso n impar
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
                else // Caso n par
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

        // Método público que inicia la resolución recursiva.
        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            movimientosRecursivo = 0;
            RecursivoInterno(n, ini, fin, aux);
            return movimientosRecursivo;
        }

        // Método recursivo interno.
        // Divide el problema en tres pasos:
        // 1) Mover n-1 discos al auxiliar
        // 2) Mover el disco grande al destino
        // 3) Mover n-1 discos del auxiliar al destino
        private void RecursivoInterno(int n, Pila ini, Pila fin, Pila aux)
        {
            // Caso base: si solo hay un disco, se mueve directamente.
            if (n == 1)
            {
                movimientosRecursivo += mover_disco(ini, fin);
                MostrarEstado(movimientosRecursivo, ini, aux, fin);
                return;
            }

            // Paso 1
            RecursivoInterno(n - 1, ini, aux, fin);

            // Paso 2
            movimientosRecursivo += mover_disco(ini, fin);
            MostrarEstado(movimientosRecursivo, ini, aux, fin);

            // Paso 3
            RecursivoInterno(n - 1, aux, fin, ini);
        }

        // =========================
        // MOSTRAR ESTADO
        // =========================

        // Método auxiliar para mostrar el estado de las torres tras cada movimiento.
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
