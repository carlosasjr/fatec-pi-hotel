using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Hotel
/// </summary>
/// 

namespace Hotel.Classes
{
    public class Hotel
    {
        public int id;
        public string razao;
        public string fantasia;
        public string cnpj;
        public string reponsavel;
        public string cep;
        public string endereco;
        public string numero;
        public string bairro;
        public string complemento;
        public string telefone;
        public string celular;
        public string ie;
        public string im;
        public string cnae;
        public int tipofaturamento;
        public int vagas_estacionamento;
        public int ativo;

        public Estado estado;
        public Cidade cidade;
            
    }
}