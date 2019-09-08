using System;
using System.Globalization;
using System.Text;


namespace Hollerrit.Entities
{
    class SalarioMensal
    {
        public double Hora { get; set; }
        public double HorasExtra75 { get; set; }
        public double HorasExtra100 { get; set; }
        public double Adicionalnoturno { get; set; }
        public double AtrazosEFalta { get; set; }
        public int DomingosEFeriados { get; set; }
        public int Dependente { get; set; }
        public string Funcionario;

        public SalarioMensal()
        {
        }

        public SalarioMensal(double hora, double horasExtra75, double horasExtra100, double adicionalnoturno, double atrazosEFalta, int domingosEFeriados, int dependente, string funcionario)
        {
            Hora = hora;
            HorasExtra75 = horasExtra75;
            HorasExtra100 = horasExtra100;
            Adicionalnoturno = adicionalnoturno;
            AtrazosEFalta = atrazosEFalta;
            DomingosEFeriados = domingosEFeriados;
            Dependente = dependente;
            Funcionario = funcionario;
        }

        public double Salario()
        {
            return Hora * 220.00;
        }

        public double Adiantamento()
        {
            return Salario() * 0.40;
        }

        public double HExtra75()
        {
            return Hora * HorasExtra75 * 0.75 + Hora * HorasExtra75;
        }

        public double HExtra100()
        {
            return Hora * HorasExtra100 * 1 + Hora * HorasExtra100;
        }

        public double Dsr()
        {
            return (HExtra75() + HExtra100()) / (30 - DomingosEFeriados) * DomingosEFeriados;
        }

        public double AdicionalNoturno()
        {
            return Hora * 0.35 * Adicionalnoturno;
        }

        public double AtrazosEFaltas()
        {
            return Hora * AtrazosEFalta; 
        }

        public double Vencimentos()
        {
            return Salario() + HExtra75() + HExtra100() + AdicionalNoturno() + Dsr();
        }

        public double SalarioBaseInss()
        {
            return Vencimentos() - AtrazosEFaltas();
        }

        public double CalculoInss()
        {
            if (SalarioBaseInss() < 1751.82)
            {
                return SalarioBaseInss() * 0.08;
            }
            else if (SalarioBaseInss() < 2919.73)
            {
                return SalarioBaseInss() * 0.09;
            }
            else if (SalarioBaseInss() < 5839.46)
            {
                return SalarioBaseInss() * 0.11;
            }
            else
            {
                return 641.24;
            }
        }

        public double AliquotaInss()
        {
            if (SalarioBaseInss() < 1751.82)
            {
                return 8;
            }
            else if (SalarioBaseInss() < 2919.73)
            {
                return 9;
            }
            else if (SalarioBaseInss() < 5839.46)
            {
                return 11;
            }
            else
            {
                return 0.0;
            }
        }

        public double Dependentes()
        {
            return Dependente * 189.59;
        }

        public double SalarioBaseIrrf()
        {
            return SalarioBaseInss() - CalculoInss() - Dependentes();
        }

        public double CalculoIrrf()
        {
            if (SalarioBaseIrrf() < 1903.99)
            {
                return 0.0;
            }
            else if (SalarioBaseIrrf() < 2826.66)
            {
                return SalarioBaseIrrf() * 0.075 - 142.80;
            }
            else if (SalarioBaseIrrf() < 3751.06)
            {
                return SalarioBaseIrrf() * 0.15 - 354.80;
            }
            else if (SalarioBaseIrrf() < 4664.69)
            {
                return SalarioBaseIrrf() * 0.225 - 636.13;
            }
            else
            {
                return SalarioBaseIrrf() * 0.275 - 869.36;
            }
        }

        public double AliquotaIrrf()
        {
            if (SalarioBaseIrrf() < 1903.99)
            {
                return 0.0;
            }
            else if (SalarioBaseIrrf() < 2826.66)
            {
                return 7.5;
            }
            else if (SalarioBaseIrrf() < 3751.06)
            {
                return 15;
            }
            else if (SalarioBaseIrrf() < 4664.69)
            {
                return 22.5;
            }
            else
            {
                return 27.5;
            }
        }

        public double Fgts()
        {
            return SalarioBaseInss() * 0.08;
        }

        public double Descontos()
        {
            return  AtrazosEFaltas() + CalculoInss() + CalculoIrrf() + Adiantamento();
        }

        public double SalarioLiquido()
        {
            return Vencimentos() - Descontos();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Salário Mensal é: R$ " + Salario().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" Adiantamento de Sálario é: R$ " + Adiantamento().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine();
            if(HExtra75() != 0.0)
            { sb.AppendLine(" Horas Extras a 75% é: R$ " + HExtra75().ToString("F2", CultureInfo.InvariantCulture)); }
            else {}
            if(HExtra100() != 0.0)
            { sb.AppendLine(" Horas Extras a 100% é: R$ " + HExtra100().ToString("F2", CultureInfo.InvariantCulture)); }
            else {}
            if(Dsr() != 0.0)
            { sb.AppendLine(" Descanço Semanal Remunerado é: R$ " + Dsr().ToString("F2", CultureInfo.InvariantCulture)); }
            else {}
            if(AdicionalNoturno() != 0.0)
            { sb.AppendLine(" Adicional Noturno é: R$ " + AdicionalNoturno().ToString("F2", CultureInfo.InvariantCulture)); }
            else {}
            if(AtrazosEFaltas() != 0.0)
            { sb.AppendLine(" Atrazos e Faltas é: R$ " + AtrazosEFaltas().ToString("F2", CultureInfo.InvariantCulture)); }
            else {}
            sb.AppendLine();
            sb.AppendLine(" Salário Base para Cálculo do INSS é: R$ " + SalarioBaseInss().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" Desconto do INSS é: R$ " + CalculoInss().ToString("F2", CultureInfo.InvariantCulture));
            if (AliquotaInss() == 0.0)
            { sb.AppendLine(" Alíquota do INSS é: Fixa"); }
            else
            { sb.AppendLine(" Alíquota do INSS é: " + AliquotaInss() + "%"); }
            sb.AppendLine();    
            sb.AppendLine(" Salário Base para Cálculo do IRRF é: R$ " + SalarioBaseIrrf().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" Desconto do IRRF é: R$ " + CalculoIrrf().ToString("F2", CultureInfo.InvariantCulture));
            if (AliquotaIrrf() == 0.0)
            { sb.AppendLine(" Alíquota do IRRF é: Isenta"); }
            else
            { sb.AppendLine(" Alíquota do IRRF é: " + AliquotaIrrf() + "%"); }
            sb.AppendLine();
            sb.AppendLine(" Total dos Vencimentos é: R$ " + Vencimentos().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" Total dos Descontos é: R$ " + Descontos().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine();
            sb.AppendLine(" FGTS do Mês é: R$ " + Fgts().ToString("F2", CultureInfo.InvariantCulture));
            sb.AppendLine(" Salário Líquido a Receber é: R$ " + SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
