using Hotel.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de PerfilDB
/// </summary>
public class PerfilDB
{
    public static int Store(Perfil perfil)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (perfil.id == 0)
            {
                string sql = "INSERT INTO per_perfil(htl_id,per_descricao," +
                    "per_ativo) VALUES (?per_id,?htl_id,?per_descricao," +
                    "?per_ativo)";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", perfil.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?per_descricao", perfil.descricao));
               // objCommand.Parameters.Add(Mapped.Parametro("?per_qtdapartamento", perfil.permissoes));
                objCommand.Parameters.Add(Mapped.Parametro("?per_ativo", perfil.per_ativo));

            }
            else
            {
                string sql = "UPDATE per_perfil SET " +
                             "per_id = ?per_id, " +
                             "htl_id = ?htl_id, " +
                             "per_descricao = ?per_descricao, " +
                      //       "per_permissoes = ?per_permissoes, " +
                             "per_ativo = ?per_ativo " +

                             "WHERE per_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?per_id", perfil.id));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", perfil.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?per_descricao", perfil.descricao));
              //  objCommand.Parameters.Add(Mapped.Parametro("?per_permissoes", perfil.permissoes));
                objCommand.Parameters.Add(Mapped.Parametro("?per_ativo", perfil.per_ativo));


                objCommand.Parameters.Add(Mapped.Parametro("?id", perfil.id));
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

        string sql = "DELETE FROM per_perfil WHERE per_id = ?id";

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

        string sql = "SELECT * FROM per_perfil";
        objCommand = Mapped.Comando(sql, objConexao);
        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }
    public static Perfil Select(int id)
    {

        Perfil obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM per_perfil WHERE per_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Perfil();

            Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(objDataReader["htl_id"]));
            obj.hotel = hotel;

            obj.id = Convert.ToInt32(objDataReader["per_id"]);
            obj.descricao = Convert.ToString(objDataReader["per_descricao"]);
            obj.permissoes = Convert.ToInt32(objDataReader["per_permissoes"]);
            obj.per_ativo = Convert.ToInt32(objDataReader["per_ativo"]);

        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}