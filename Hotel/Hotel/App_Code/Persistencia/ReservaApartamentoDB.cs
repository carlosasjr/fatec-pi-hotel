using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Hotel.Classes;

/// <summary>
/// Summary description for ReservaApartamentoDB
/// </summary>
public class ReservaApartamentoDB
{
    public static int Store(ReservaApartamento reservaApartamento)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (reservaApartamento.id == 0)
            {
                string sql = "INSERT INTO rap_reserva_apartamento(htl_id, res_id, apt_id, rap_valor, res_informacoes)" +
                             " VALUES (?htl_id, ?res_id, ?apt_id, ?rap_valor, ?res_informacoes)";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", reservaApartamento.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?res_id", reservaApartamento.reserva.id));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_id", reservaApartamento.apartamento.id));
                objCommand.Parameters.Add(Mapped.Parametro("?rap_valor", reservaApartamento.valor));
                objCommand.Parameters.Add(Mapped.Parametro("?res_informacoes", reservaApartamento.informacoes));
                
            }
            else
            {
                string sql = "UPDATE res_reserva_apartamento SET " +
                             "htl_id = ?htl_id, " +
                             "res_id = ?res_id, " +
                             "apt_id = ?apt_id, " +
                             "rap_valor = ?rap_valor, " +
                             "res_informacoes, ?res_informacoes " +
                             "WHERE rap_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", reservaApartamento.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?res_id", reservaApartamento.reserva.id));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_id", reservaApartamento.apartamento.id));
                objCommand.Parameters.Add(Mapped.Parametro("?rap_valor", reservaApartamento.valor));
                objCommand.Parameters.Add(Mapped.Parametro("?res_informacoes", reservaApartamento.informacoes));

                objCommand.Parameters.Add(Mapped.Parametro("?id", reservaApartamento.id));
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

        catch (Exception e)
        {
            string erro = e.Message;
            retorno = -2;
        }

        return retorno;
    }

    public static bool Delete(int id)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;

        string sql = "DELETE FROM res_reserva_apartamento WHERE rap_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return true;
    }


    public static DataSet GetReservaApartamento(Reserva reserva)
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = "SELECT * FROM res_reserva_apartamento where res_id = ?res_id";
        objCommand = Mapped.Comando(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parametro("?res_id", reserva.id));


        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }


    public static ReservaApartamento Select(Reserva reserva, int id)
    {

        ReservaApartamento obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM res_reserva_apartamento WHERE rap_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new ReservaApartamento();

            obj.hotel = reserva.hotel;

            obj.reserva = reserva;

            Apartamento apartamento = ApartamentoDB.Select(Convert.ToInt32(objDataReader["apt_id"]));
            obj.apartamento = apartamento;

            obj.id = Convert.ToInt32(objDataReader["rap_id"]);
            obj.valor = Convert.ToDecimal(objDataReader["rap_valor"]);
            obj.informacoes = Convert.ToString(objDataReader["res_informacoes"]);
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}