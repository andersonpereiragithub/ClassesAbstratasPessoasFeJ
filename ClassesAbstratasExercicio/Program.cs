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

                if (ch == 'i')
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Renda Anual: ");
                    double renda = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Despesas com saúde: ");
                    double gastosSaude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    lista.Add(new PessoaFisica(nome, renda, gastosSaude));
                }
                else if (ch == 'c')
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Renda Anual: ");
                    double renda = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Número de Empregrados: ");
                    int numEmpregados = int.Parse(Console.ReadLine());
                    lista.Add(new PessoaJuridica(nome, renda, numEmpregados));
                }
            }
            Console.WriteLine("\nImpostos Pagos: ");
            foreach (Pessoa p in lista)
            {
                Console.WriteLine($"{p.Nome}: $ {p.CalculaImposto().ToString("F2", CultureInfo.InvariantCulture)}");
            }

            Console.Write("\nIMPOSTOS TOTAIS: ");
            double soma = 0;
            foreach (Pessoa p in lista)
            {
                soma += p.CalculaImposto();
            }
            Console.Write(soma.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
