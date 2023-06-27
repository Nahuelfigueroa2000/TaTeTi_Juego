using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_TaTeTi
{

        internal class Juego
        {
            private char[] tablero = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            private int player = 1;
            private int opcion;
            private bool gameOver = false;

            public void Start()
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Jugador 1: X  Jugador 2: O");
                    Console.WriteLine("\n");

                    Console.WriteLine($"Turno del Jugador {player}");
                    Console.WriteLine("\n");
                    Tablero_tateti();

                    // Comprobar el estado del juego
                    if (IsGameOver())
                    {
                        gameOver = true;
                        Console.WriteLine("¡Empate!");
                    }
                    else if (ganador('X'))
                    {
                        gameOver = true;
                        Console.WriteLine("¡El Jugador 1 ha ganado!");
                    }
                    else if (ganador('O'))
                    {
                        gameOver = true;
                        Console.WriteLine("¡El Jugador 2 ha ganado!");
                    }
                    else
                    {
                        player = (player == 1) ? 2 : 1;
                        Console.WriteLine("\n");
                        Movimiento();
                    }
                } while (!gameOver);
                // si desesa volver a jugar

                Console.WriteLine("¿Desean volver a jugar? (S/N)");
                string respuesta = Console.ReadLine();
                if (respuesta.ToUpper() == "S") // opcion que por mas como ponga la letra se a poner en mayus
                {
                    Repetir();
                    Start();
                }
            }

            private void Tablero_tateti()
            {
                //string modificados
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", tablero[0], tablero[1], tablero[2]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", tablero[3], tablero[4], tablero[5]);
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine("  {0}  |  {1}  |  {2}", tablero[6], tablero[7], tablero[8]);
                Console.WriteLine("     |     |      ");
            }

            private void Movimiento()
            {
                Console.WriteLine("Seleccione una posición (1-9): ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion < 1 || opcion > 9 || tablero[opcion - 1] == 'X' || tablero[opcion - 1] == 'O')
                {
                    Console.WriteLine("¡Posición inválida! Intente nuevamente.");
                    Movimiento();
                }
                else
                {
                    tablero[opcion - 1] = (player == 1) ? 'X' : 'O';
                }
            }

            private bool IsGameOver()
            {
                return tablero[0] != '1' && tablero[1] != '2' && tablero[2] != '3' &&
                       tablero[3] != '4' && tablero[4] != '5' && tablero[5] != '6' &&
                       tablero[6] != '7' && tablero[7] != '8' && tablero[8] != '9';
            }

            private bool ganador(char playerSymbol)
            {
                return (tablero[0] == playerSymbol && tablero[1] == playerSymbol && tablero[2] == playerSymbol) ||
                       (tablero[3] == playerSymbol && tablero[4] == playerSymbol && tablero[5] == playerSymbol) ||
                       (tablero[6] == playerSymbol && tablero[7] == playerSymbol && tablero[8] == playerSymbol) ||
                       (tablero[0] == playerSymbol && tablero[3] == playerSymbol && tablero[6] == playerSymbol) ||
                       (tablero[1] == playerSymbol && tablero[4] == playerSymbol && tablero[7] == playerSymbol) ||
                       (tablero[2] == playerSymbol && tablero[5] == playerSymbol && tablero[8] == playerSymbol) ||
                       (tablero[0] == playerSymbol && tablero[4] == playerSymbol && tablero[8] == playerSymbol) ||
                       (tablero[2] == playerSymbol && tablero[4] == playerSymbol && tablero[6] == playerSymbol);
            }

            private void Repetir()
            {
                tablero = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                player = 1;
                opcion = 0;
                gameOver = false;
            }
        }
}
