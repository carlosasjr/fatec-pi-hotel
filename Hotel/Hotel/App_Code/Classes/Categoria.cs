using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Categoria
/// </summary>
/// 
namespace Hotel.Classes
{
    public class Categoria
    {
        public Hotel hotel;
        public int id;
        public string descricao;
        public int qtdapartamento;
        public string abreviacao;
        public int qtdacomodacoes;
        public int ativo;

        public Categoria()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}