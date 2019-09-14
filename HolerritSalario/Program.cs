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

                Console.Write(" Digite o Nome do Funcionário: ");
                string funcionario = Console.ReadLine();
                Console.Write(" " + funcionario + " Quanto Você Ganha Por Hora: R$ ");
                double hora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write(" " + funcionario + " Você Teve Hora Extra ou Atrazos e Faltas (s/n)?: ");
                char pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" " + funcionario + " Você Tem Hora Extra à 75% (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" Quantas Horas à 75% são: ");
                        horasExtra75 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    Console.Write(" " + funcionario + " Você Tem Hora Extra à 100% (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" Quantas Horas à 100% são: ");
                        horasExtra100 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    Console.Write(" " + funcionario + " Você Tem Horas de Adicional Noturno (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" Quantas Horas de Adicional Noturno são: ");
                        adicionalnoturno = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    Console.Write(" " + funcionario + " Você Tem Horas de Atrazos e Faltas (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" Quantas Horas de Atrazos ou Faltas são: ");
                        atrazosEFalta = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                    Console.Write(" " + funcionario + " Você Teve Horas Extra no Mês (s/n)?: ");
                    pergunta = char.Parse(Console.ReadLine());
                    if (pergunta == 's' || pergunta == 'S')
                    {
                        Console.Write(" Digite a Quantidade de Domingos e Feriados do Mês: ");
                        domingosEFeriados = int.Parse(Console.ReadLine());
                        pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                    }
                }
                Console.Write(" " + funcionario + " Você Tem Dependentes para Dedução do IRRF (s/n)?: ");
                pergunta = char.Parse(Console.ReadLine());
                if (pergunta == 's' || pergunta == 'S')
                {
                    Console.Write(" Quantos Dependentes são: ");
                    dependente = int.Parse(Console.ReadLine());
                    pag = new SalarioMensal(hora, horasExtra75, horasExtra100, adicionalnoturno, atrazosEFalta, domingosEFeriados, dependente, funcionario);
                }
                Console.WriteLine();
                Console.WriteLine(pag.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
 