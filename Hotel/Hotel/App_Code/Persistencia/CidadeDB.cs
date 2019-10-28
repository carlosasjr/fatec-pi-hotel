using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MunicipioDB
/// </summary>
/// 

namespace Hotel.Classes
{

    public class CidadeDB
    {
        public static DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConexao = Mapped.Conexao();

            string sql = "SELECT * FROM cid_cidade";
            objCommand = Mapped.Comando(sql, objConexao);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }

        public static Cidade Select(int codibge)
        {

            Cidade obj = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            string sql = "SELECT * FROM cid_cidade WHERE cid_codibge = ?codibge";

            objConexao = Mapped.Conexao();
            objCommand = Mapped.Comando(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?codibge", codibge));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Cidade();

                Estado uf = EstadoDB.Select(Convert.ToString(objDataReader["uf_sigla"]));
                obj.uf = uf;

                obj.codibge = Convert.ToString(objDataReader["cid_codibge"]);
                obj.nome = Convert.ToString(objDataReader["cid_nome"]);
            }


            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        public static DataSet getMunicipiosUF(String uf)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConexao = Mapped.Conexao();

            string sql = "SELECT * FROM cid_cidade WHERE uf_sigla = ?uf";
            objCommand = Mapped.Comando(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parametro("?uf", uf));

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return ds;
        }
    }
}