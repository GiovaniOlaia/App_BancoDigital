using System;
using System.Collections.Generic;
using System.Text;

namespace App_BancoDigital.Model
{
    public class Correntista
    {
        public int id_correntista { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public DateTime data_nascimento { get; set; }

        public string cpf { get; set; }

        public string senha_correntista { get; set; }

        public bool ativo { get; set; } = true;
    }
}
