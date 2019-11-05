using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Hospede
/// </summary>
/// 
namespace Hotel.Classes
{
    public class Hospede:Pessoas
    {
       
        public string desconto;
        public string valor_fixo_pernoite;
        public string bloqueado;
        
       
        public Hospede()
        {


        }
    }
}