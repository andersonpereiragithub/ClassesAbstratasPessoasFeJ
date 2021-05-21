using System;
using System.Collections.Generic;
using System.Globalization;
using ClassesAbstratasExercicio.Entities;

namespace ClassesAbstratasExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> lista = new List<Pessoa>();

            Console.Write("Insira o número de contribuintes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados do contribuinte nº {i}: ");
                Console.Write("Pessoa física ou jurídica (i/c)? ");
                char ch = char.Parse(Console.ReadLine().ToLower());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Renda Anual: ");
                double renda = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Despesas com saúde: ");
                    double gastosSaude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    lista.Add(new PessoaFisica(nome, renda, gastosSaude));
                }
                else
                {
                    Console.Write("Número de Empregrados: ");
                    int numEmpregados = int.Parse(Console.ReadLine());
                    lista.Add(new PessoaJuridica(nome, renda, numEmpregados));
                }
            }
            double soma = 0;
            Console.WriteLine("\nImpostos Pagos: ");
            foreach (Pessoa p in lista)
            {
                Console.WriteLine($"{p.Nome}: $ {p.CalculaImposto().ToString("F2", CultureInfo.InvariantCulture)}");
                soma += p.CalculaImposto();
            }

            Console.Write("\nIMPOSTOS TOTAIS: ");
            Console.Write(soma.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
