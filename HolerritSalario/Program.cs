using System;
using System.Globalization;
using Hollerrit.Entities;

namespace Hollerrit
{
    class Program
    {
        private static double atrazosEFalta;
        private static double horasExtra75;
        private static double horasExtra100;
        private static double adicionalnoturno;
        private static int dependente;
        private static int domingosEFeriados;

        static void Main(string[] args)
        {
            try
            {
                SalarioMensal pag = new SalarioMensal();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Digite o Nome do Funcionário: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string funcionario = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Quanto Você Ganha Por Hora: R$ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                double hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Você Tem Dependentes para Dedução do IRRF (s/n)?: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                char pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Quantos Dependentes são: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    dependente = int.Parse(Console.ReadLine());
                    pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                }
                else
                {
                    pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, funcionario);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Você Teve Hora Extra ou Atrazos e Faltas (s/n)?: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Você Tem Hora Extra à 75% (s/n)?: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Quantas Horas à 75% são: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        horasExtra75 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Você Tem Hora Extra à 100% (s/n)?: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Quantas Horas à 100% são: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        horasExtra100 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    if (horasExtra75 != 0.0 || horasExtra100 != 0.0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Digite a Quantidade de Domingos e Feriados do Mês: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        domingosEFeriados = int.Parse(Console.ReadLine());
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Você Tem Horas de Adicional Noturno (s/n)?: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Quantas Horas de Adicional Noturno são: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        adicionalnoturno = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" Você Tem Horas de Atrazos e Faltas (s/n)?: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" Quantas Horas de Atrazos ou Faltas são: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        atrazosEFalta = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine(pag.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
