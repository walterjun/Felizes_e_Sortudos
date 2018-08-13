using System;
using System.Collections.Generic;

namespace Felizes_sortudos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número para saber se ele é Feliz ou Sortudo: ");
            long numero;
            string numeroLido = Console.ReadLine();
            Console.WriteLine("");

            if (long.TryParse(numeroLido, out numero))
            {
                if (EFeliz(numero))
                    Console.WriteLine($"O número {numero} é feliz");
                else
                    Console.WriteLine($"O número {numero} não é feliz");

                if (ESortudo(numero))
                    Console.WriteLine($"O número {numero} é sortudo");
                else
                    Console.WriteLine($"O número {numero} não é sortudo");
            }
            else
            {
                Console.WriteLine("O número digitado não é um número!");
            }

            Console.WriteLine("Pressione qualquer tecla para terminar.");
            Console.ReadKey();
        }

        private static bool EFeliz(long numero)
        {
            for (int i = 1; i <= 100; i++)
            {
                var lista = numero.ToString().ToCharArray();
                double resultado = 0;

                foreach (var item in lista)
                {
                    resultado += Math.Pow(double.Parse(item.ToString()), 2);
                }

                if(resultado == 1)
                {
                    return true;
                }
                else
                {
                    numero = long.Parse(resultado.ToString());
                }
            }

            return false;
        }

        private static bool ESortudo(long numero)
        {
            List<long> lista = new List<long>();

            for (int i = 1; i <= numero; i++)
            {
                lista.Add(i);
            }

            lista.RemoveAll(x => (x % 2 == 0));

            for (int i = 1; i < lista.Count; i++)
            {
                long multiplo = lista[i];

                int j = 1;

                while (true)
                {
                    var quadrado = Math.Pow(multiplo, j);

                    if(quadrado < lista.Count)
                    {
                        lista.RemoveAt(int.Parse(quadrado.ToString()) - 1);
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return lista.Contains(numero);
        }
    }
}
