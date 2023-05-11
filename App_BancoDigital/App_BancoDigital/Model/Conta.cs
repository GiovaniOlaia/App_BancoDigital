using System;
using System.Collections.Generic;
using System.Text;

namespace App_BancoDigital.Model
{
    public class Conta
    {
        public int Id_Conta { get; set; }

        public int numero { get; set; }

        public string tipo { get; set; }

        public string senha_conta { get; set; }

        public bool ativa { get; set; }
    }
}
