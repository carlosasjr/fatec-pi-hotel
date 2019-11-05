using Hotel.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de CategoriaDB
/// </summary>
public class CategoriaDB
{
    public static int Store(Categoria categoria)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (categoria.id == 0)
            {
                string sql = "INSERT INTO cat_catapartamento(htl_id,cat_descricao,cat_qtdapartamento,cat_abreviacao,cat_qtdacomodacoes," +
                    "ativo) VALUES (?htl_id,?cat_descricao,?cat_qtdapartamento,?cat_abreviacao,?cat_qtdacomodacoes," +
                    "?ativo)";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", categoria.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_descricao", categoria.descricao));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_qtdapartamento", categoria.qtdapartamento));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_abreviacao", categoria.abreviacao));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_qtdacomodacoes", categoria.qtdacomodacoes));
                objCommand.Parameters.Add(Mapped.Parametro("?ativo", categoria.ativo));
            }
            else
            {
                string sql = "UPDATE cat_catapartamento SET " +
                             "htl_id = ?htl_id, " +
                             "cat_descricao = ?cat_descricao, " +
                             "cat_qtdapartamento = ?cat_qtdapartamento, " +
                             "cat_abreviacao = ?cat_abreviacao, " +
                             "cat_qtdacomodacoes = ?cat_qtdacomodacoes, " +
                             "ativo = ?ativo, " +

                             "WHERE cat_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", categoria.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_descricao", categoria.descricao));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_qtdapartamento", categoria.qtdapartamento));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_abreviacao", categoria.abreviacao));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_qtdacomodacoes", categoria.qtdacomodacoes));
                objCommand.Parameters.Add(Mapped.Parametro("?ativo", categoria.ativo));

                objCommand.Parameters.Add(Mapped.Parametro("?id", categoria.id));
            }

            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

        }
        catch (MySql.Data.MySqlClient.MySqlException e)
        {
            string erro = e.Message;
            retorno = -1;
        }

        catch (Exception)
        {
            retorno = -2;
        }

        return retorno;
    }

    public static bool Delete(int id)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;

        string sql = "DELETE FROM cat_categoria WHERE cat_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return true;
    }



    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = "SELECT * FROM cat_catapartamento WHERE ativo = ?ativo";
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?ativo", 1));

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }
    public static Categoria Select(int id)
    {

        Categoria obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM cat_catapartamento WHERE cat_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Categoria();

            Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(objDataReader["htl_id"]));
            obj.hotel = hotel;

            obj.id = Convert.ToInt32(objDataReader["cat_id"]);
            obj.descricao = Convert.ToString(objDataReader["cat_descricao"]);
            obj.qtdapartamento = Convert.ToInt32(objDataReader["cat_qtdapartamento"]);
            obj.abreviacao = Convert.ToString(objDataReader["cat_abreviacao"]);
            obj.qtdacomodacoes = Convert.ToInt32(objDataReader["cat`_qtdacomodacoes"]);

            obj.ativo = Convert.ToInt32(objDataReader["ativo"]);

        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}