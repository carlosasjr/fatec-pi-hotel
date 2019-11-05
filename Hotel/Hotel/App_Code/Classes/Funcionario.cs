using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Funcionario
/// </summary>
/// 
namespace Hotel.Classes
{
    public class Funcionario : Pessoas
    {
        public int confereCaixa;
        public int permiteCortesia;
        public string senha;
    }
}