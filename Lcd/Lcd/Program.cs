using System;
using System.Collections.Generic;

//Objetivo: Crear un programa que imprime números en estilo de una pantalla LCD
/*Entrada: La entrada contiene varias líneas.Cada línea contiene 2 números separados por coma.El primer
número representa el tamaño de la impresión (entre 1 y 10 – esta variable se llama “size”). El segundo número
es el número a mostrar en la pantalla.Para terminar, se debe digitar 0,0. Esto terminará la aplicación.
Salida: Imprimir los números especificados usando el carácter “-“ para los caracteres horizontales, y “|” para
los verticales.Cada dígito debe ocupar exactamente size+2 columnas y 2*size + 3 filas.
Entre cada impresión debe haber una línea blanca.*/

namespace Lcd
{
    class Program
    {
        static void Main(string[] args)
        {
            string numeroIngresado = "";
            while (numeroIngresado != "0.0")
            {
                Console.Write("Ingrese número:");
                numeroIngresado = Console.ReadLine();

                var valor = numeroIngresado.Split(",");

                int n = Convert.ToInt32(valor[0]);
                var numerosIngresado = valor[1];

                for (int m = 0; m < numerosIngresado.Length; m++)
                {
                    numeroIngresado = numerosIngresado[m].ToString();

                    //Los segmentos de la pantalla se componen en 7, a continuacion se generan codigos de segmentos que se necesitan
                    //mostrar de acuerdo al numero ingresado.

                    string codigoCero = "145673";
                    string codigoUno = "57";
                    string codigoDos = "15263";
                    string codigoTres = "15273";
                    string codigoCuatro = "4257";
                    string codigoCinco = "14273";
                    string codigoSeis = "146273";
                    string codigoSiete = "1527";
                    string codigoOcho = "1452673";
                    string codigoNueve = "14527";

                    //Formula para calcular Filas y columnas de acuerdo al numero n ingreasdo


                    int[,] matriz = new int[(n * 2) + 3, n + 2];

                    int filaPintar = 0;
                    int columnaPintarInicio = 0;
                    int columnaPintarFin = 0;
                    int columnaPintar = 0;
                    int filasPintarInicio = 0;
                    int filasPintarFin = 0;
                    bool esFila = false;
                    string codigoNumero = "";
                    //Se le lleva a codigoNumero, el numero ingresado.
                    switch (numeroIngresado)

                        
                    {
                        
                        case "0":
                            codigoNumero = codigoCero;
                            break;
                        case "1":
                            codigoNumero = codigoUno;
                            break;
                        case "2":
                            codigoNumero = codigoDos;
                            break;
                        case "3":
                            codigoNumero = codigoTres;
                            break;
                        case "4":
                            codigoNumero = codigoCuatro;
                            break;
                        case "5":
                            codigoNumero = codigoCinco;
                            break;
                        case "6":
                            codigoNumero = codigoSeis;
                            break;
                        case "7":
                            codigoNumero = codigoSiete;
                            break;
                        case "8":
                            codigoNumero = codigoOcho;
                            break;
                        case "9":
                            codigoNumero = codigoNueve;
                            break;
                        default:
                            Console.Write("Número incorrecto.");
                            break;
                    }
                    //Formulas para pintar los segmentos 
                    for (int i = 0; i < codigoNumero.Length; i++)
                    {
                        esFila = false;
                        string segmento = codigoNumero[i].ToString();
                        switch (segmento)
                        {
                            case "1":
                                esFila = true;
                                filaPintar = 0;
                                columnaPintarInicio = 1;
                                columnaPintarFin =  n;
                                break;
                            case "2":
                                esFila = true;
                                filaPintar = n + 1;
                                columnaPintarInicio = 1;
                                columnaPintarFin = n;
                                break;
                            case "3":
                                esFila = true;
                                filaPintar = (2 * n) + 2;
                                columnaPintarInicio = 1;
                                columnaPintarFin = n;
                                break;
                            case "4":
                                columnaPintar = 0;
                                filasPintarInicio = 1;
                                filasPintarFin = n;
                                break;
                            case "5":
                                columnaPintar = n + 1;
                                filasPintarInicio = 1;
                                filasPintarFin = n;
                                break;
                            case "6":
                                columnaPintar = 0;
                                filasPintarInicio = n + 2;
                                filasPintarFin = (2 * n) + 1;
                                break;
                            case "7":
                                columnaPintar = n + 1;
                                filasPintarInicio = n + 2;
                                filasPintarFin = (2 * n) + 1;
                                break;
                        }

                        if (esFila == true)
                        {
                            for (int fila = 0; fila <= filaPintar; fila++)
                            {
                                for (int columna = columnaPintarInicio; columna <= columnaPintarFin; columna++)
                                {
                                    if (filaPintar == fila)
                                        matriz[fila, columna] = 1;
                                }
                            }
                        }
                        else
                        {
                            for (int fila = filasPintarInicio; fila <= filasPintarFin; fila++)
                            {
                                for (int columna = 0; columna <= columnaPintar; columna++)
                                {
                                    if (columnaPintar == columna)
                                    {
                                        matriz[fila, columna] = 2;
                                    }
                                }
                            }
                        }
                    }

                    //Pintamos matriz:
                    int filaLongitudMatriz = matriz.GetLength(0);
                    int columnaLongitudMatriz = matriz.GetLength(1);

                    for (int fila = 0; fila < filaLongitudMatriz; fila++)
                    {
                        for (int columna = 0; columna < columnaLongitudMatriz; columna++)
                        {
                            {
                                if (matriz[fila, columna] == 1)
                                {
                                    Console.Write("-");
                                }
                                else if (matriz[fila, columna] == 2)
                                {
                                    Console.Write("|");
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
            Environment.Exit(0);
        }
    }
}