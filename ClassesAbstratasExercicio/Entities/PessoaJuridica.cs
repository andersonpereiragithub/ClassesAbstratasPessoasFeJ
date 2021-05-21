using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAbstratasExercicio.Entities
{
    class PessoaJuridica : Pessoa
    {
        public int NumeroFuncionario { get; set; }

        public PessoaJuridica(string nome, double rendaAnual, int numeroFuncionario) 
            : base(nome, rendaAnual)

        {
            NumeroFuncionario = numeroFuncionario;
        }

        public override double CalculaImposto()
        {
            if (NumeroFuncionario > 10)
                return RendaAnual * 0.14;
            return RendaAnual * 0.16;
        }
    }
}
