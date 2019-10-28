using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Estado
/// </summary>
/// 
namespace Hotel.Classes
{
    public class Estado
    {
        public string uf;
        public string descricao;

        public List<Cidade> Cidade;
    }
}