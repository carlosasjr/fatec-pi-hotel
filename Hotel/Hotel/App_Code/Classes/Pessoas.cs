using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Pessoas
/// </summary>
namespace Hotel.Classes
{
    public class Pessoas
    {
        public Hotel hotel;
        public int id;
        public string nome;
        public string email;
        public string endereco;
        public string numero;
        public string bairro;
        public string cep;
        public string complemento;
        public string fisica_juridica;
        public string cpf_cnpj;
    
        public string rg;
        public string nascimento;
        public string estado_civil;
        public string profissao;
        public string observacao;
        public int    ativo;
        public string telefone;
        public string celular;
        public string contato;
        public int tipo;

       
        public Estado estado;
        public Cidade cidade;

    }
}