using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// Descrição resumida de Mapped
/// </summary>
public class Mapped
{
    //Toda classe precisa ter um construtor implicito ou explicito

    /// <summary>
    /// Método que gera a conexão com o BD MySQL, trazendo as credenciais do web Config, através
    /// da Key StrConexao de AppSettings
    /// </summary>
    /// <returns>Retorna a conexão MySQL IDbConnection</returns>
    public static  IDbConnection Conexao()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["StrConexao"] );

        objConexao.Open();

        return objConexao;
    }

    /// <summary>
    /// Responsável por executar os comentos SQL
    /// </summary>
    /// <param name="query">Comando SQL a ser executado</param>
    /// <param name="objConexao">Conexao aberta</param>
    /// <returns>Retorna o obj comando</returns>
    public static IDbCommand Comando(string query, IDbConnection objConexao)
    {
        IDbCommand com = objConexao.CreateCommand();
        com.CommandText = query;
        return com;
    }

    /// <summary>
    /// Para preenchimento em massa... Ex: DataSet
    /// </summary>
    /// <param name="comando">Obj Comando</param>
    /// <returns>Retorna obj Adapter</returns>
    public static IDbDataAdapter Adapter(IDbCommand comando)
    {
        
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = comando;
        return adap;
    }

    /// <summary>
    /// XSS
    /// SQL Injection
    /// </summary>
    /// <param name="nomeParametro">Nome esolhido do parametro</param>
    /// <param name="valorParametro"></param>
    /// <returns></returns>
    public static IDbDataParameter Parametro(string nomeParametro, object valorParametro)
    {
        return new MySqlParameter(nomeParametro, valorParametro);
    }


}