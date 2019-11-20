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
    public class Perfil
    {
        public Hotel hotel;
        public int id;
        public string descricao;
        public int permissoes;
        public int per_ativo;

        public Perfil()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}