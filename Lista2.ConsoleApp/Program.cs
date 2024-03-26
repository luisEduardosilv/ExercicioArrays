using System.Collections.Immutable;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProgramaArray.ConsoleApp
{
    internal class Program
    {
        static byte verificador;

        static void Main(string[] args)
        {
            int[] valores = new int[] { -5, 3, 4, 5, 9, 6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -6 };

            ExibirTitulo();

            MostrarSequencia(valores);

            MaiorValor(valores);
            Console.WriteLine();

            MenorValor(valores);
            Console.WriteLine();

            ValorMedia(valores);
            Console.WriteLine();

            TresMaioresValores(ref valores);
            Console.WriteLine();

            ValoresNegativos(valores);
            Console.WriteLine();

            valores = ExcluindoValor(ref valores);

        }

        #region ExirbirTitulo
        private static void ExibirTitulo()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("| Array de Inteiros! |");
            Console.WriteLine("----------------------\n");
        }
        #endregion

        #region Maior Valor
        private static void MaiorValor(int[] valores)
        {
            int valorMax = valores.Max();
            Console.WriteLine($"O maior valor do Array é: {valorMax}");
        }
        #endregion

        #region Menor Valor
        private static void MenorValor(int[] valores)
        {
            int valorMin = valores.Min();
            Console.WriteLine($"O menor valor do Array é: {valorMin}");
        }
        #endregion

        #region Média dos Valores
        private static void ValorMedia(int[] valores)
        {
            double media = valores.Average();
            Console.WriteLine($"A Média é: {media.ToString("N2")}");
        }
        #endregion

        #region Três Maiores Valores
        private static void TresMaioresValores(ref int[] valores)
        {
            Console.WriteLine("Os Três Maiores valores são:");
            for (int i = 0; i < 3; i++)
            {
                Array.Sort(valores);
                Array.Reverse(valores);
                Console.Write($"{valores[i]} ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Valores Negativos
        private static void ValoresNegativos(int[] valores)
        {
            Console.WriteLine("Os números negativos são: ");
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] < 0)
                    Console.Write(valores[i] + " ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Mostrar Sequencia
        private static void MostrarSequencia(int[] valores)
        {
            Console.WriteLine("Sequencia do Array: ");
            Console.WriteLine("____________________________________");
            for (int i = 0; i < valores.Length; i++)
            {
                Console.Write(valores[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("____________________________________\n");

        }
        #endregion

        #region Excluindo Valor
        private static int[] ExcluindoValor(ref int[] valores)
        {
            #region Capturando o valor
            Console.WriteLine("Digite o número que dejesa Remover: ");
            int remover = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            #endregion

            //Verificando se o valor digitado é valido
            #region Verificando se o Valor é valido
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] == remover)
                {
                    verificador = 1;
                    break;
                }
                else
                {
                    verificador = 0;
                }
            }

            if (verificador == 1)
            {
                Console.WriteLine("Concluido\n");
            }
            else if (verificador == 0)
            {
                Console.WriteLine("Valor Invalido\n");
            }
            #endregion

            #region "Excluindo" o valor
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] == remover && remover != 6)
                {
                    valores[i] = valores[15];

                    valores[15] = 0;

                    Array.Resize(ref valores, valores.Length - 1);

                }
            }
            if (remover == 6)
            {
                valores[5] = valores[15];
                valores[11] = valores[14];
                Array.Resize(ref valores, valores.Length - 2);
            }
            #endregion

            MostrarSequencia(valores);
            return valores;
        }
        #endregion
    }
}
