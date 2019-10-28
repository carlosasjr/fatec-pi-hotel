using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Hotel.Classes;

/// <summary>
/// Summary description for EstadoDB
/// </summary>
public class EstadoDB
{

    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = "SELECT * FROM uf_estado";
        objCommand = Mapped.Comando(sql, objConexao);
        
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }

    public static Estado Select(string uf)
    {

        Estado obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM uf_estado WHERE uf_sigla = ?sigla";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?sigla", uf));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Estado();
            obj.uf = Convert.ToString(objDataReader["uf_sigla"]);
            obj.descricao = Convert.ToString(objDataReader["uf_descricao"]);            
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}