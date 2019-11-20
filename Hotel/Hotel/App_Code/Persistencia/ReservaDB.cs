using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Hotel.Classes;

/// <summary>
/// Summary description for ReservaDB
/// </summary>
public class ReservaDB
{
    public static int Store(Reserva reserva)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (reserva.id == 0)
            {
                string sql = "INSERT INTO res_reserva(htl_id, pes_id, res_previsao_chegada, res_previsao_saida,  " +
                             " res_datainclusao, res_observacoes,res_valorliquido) VALUES (?htl_id, ?pes_id, ?res_previsao_chegada, ?res_previsao_saida, " +
                             " ?res_datainclusao, ?res_observacoes, ?res_valorliquido)";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", reserva.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_id", reserva.hospede.id));
                objCommand.Parameters.Add(Mapped.Parametro("?res_previsao_chegada", reserva.previsaoChegada));
                objCommand.Parameters.Add(Mapped.Parametro("?res_previsao_saida", reserva.previsaoSaida));
                objCommand.Parameters.Add(Mapped.Parametro("?res_datainclusao", reserva.dataInclusao));
                objCommand.Parameters.Add(Mapped.Parametro("?res_observacoes", reserva.observacoes));
                objCommand.Parameters.Add(Mapped.Parametro("?res_valorliquido", reserva.valorLiquido));
            }
            else
            {
                string sql = "UPDATE res_reserva SET " +
                             "htl_id = ?htl_id, " +
                             "pes_id = ?pes_id, " +
                             "res_previsao_chegada = ?res_previsao_chegada, " +
                             "res_previsao_saida = ?res_previsao_saida, " +
                             "res_checkin = ?res_checkin, " +
                             "res_checkout = ?res_checkout, " +
                             "res_datainclusao = ?res_datainclusao, " +
                             "res_dataalteracao = ?res_dataalteracao, " +
                             "res_datacancelamento = ?res_datacancelamento, " +
                             "res_motivo_cancelamento = ?res_motivo_cancelamento, " +
                             "res_observacoes = ?res_observacoes, " +
                             "res_valorliquido = ?res_valorliquido " +
                             "WHERE res_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", reserva.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_id", reserva.hospede.id));
                objCommand.Parameters.Add(Mapped.Parametro("?res_previsao_chegada", reserva.previsaoChegada));
                objCommand.Parameters.Add(Mapped.Parametro("?res_previsao_saida", reserva.previsaoSaida));
                objCommand.Parameters.Add(Mapped.Parametro("?res_checkin", reserva.checkin));
                objCommand.Parameters.Add(Mapped.Parametro("?res_checkout", reserva.checkout));
                objCommand.Parameters.Add(Mapped.Parametro("?res_datainclusao", reserva.dataInclusao));
                objCommand.Parameters.Add(Mapped.Parametro("?res_dataalteracao", reserva.dataAlteracao));
                objCommand.Parameters.Add(Mapped.Parametro("?res_datacancelamento", reserva.dataCancelamento));
                objCommand.Parameters.Add(Mapped.Parametro("?res_motivo_cancelamento", reserva.motivoCancelamento));
                objCommand.Parameters.Add(Mapped.Parametro("?res_observacoes", reserva.observacoes));
                objCommand.Parameters.Add(Mapped.Parametro("?res_valorliquido", reserva.valorLiquido));

                objCommand.Parameters.Add(Mapped.Parametro("?id", reserva.id));
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

    public static int CheckIn(int id)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            string sql = "UPDATE res_reserva SET " +
                         "res_checkin = ?res_checkin " +
                         "WHERE res_id = ?id";

            objCommand = Mapped.Comando(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parametro("?res_checkin", DateTime.Now));
            objCommand.Parameters.Add(Mapped.Parametro("?id", id));

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

    public static int CheckOut(int id)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            string sql = "UPDATE res_reserva SET " +
                         "res_checkout = ?res_checkout " +
                         "WHERE res_id = ?id";

            objCommand = Mapped.Comando(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parametro("?res_checkout", DateTime.Now));
            objCommand.Parameters.Add(Mapped.Parametro("?id", id));

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

    public static int Cancelar(int id, string motivo)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            string sql = "UPDATE res_reserva SET " +
                         "res_datacancelamento = ?res_datacancelamento, " +
                         "res_motivo_cancelamento = ?res_motivo_cancelamento " +
                         "WHERE res_id = ?id";

            objCommand = Mapped.Comando(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parametro("?res_datacancelamento", DateTime.Now));
            objCommand.Parameters.Add(Mapped.Parametro("?res_motivo_cancelamento", motivo.Trim()));
            objCommand.Parameters.Add(Mapped.Parametro("?id", id));

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

        string sql = "DELETE FROM res_reserva WHERE res_id = ?id";

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

        string sql = "SELECT res.*, pes.pes_nome FROM res_reserva res " +
            " LEFT JOIN pes_pessoa pes ON " +
            " (res.htl_id = pes.htl_id " +
            " AND res.pes_id = pes.pes_id) " +
            " ORDER BY res_datainclusao ASC";
        objCommand = Mapped.Comando(sql, objConexao);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }

    public static int CountReservasAtivas()
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = " SELECT * FROM res_reserva res " +
                     " WHERE res.res_checkin is null " +
                     " AND res.res_datacancelamento is null ";

        objCommand = Mapped.Comando(sql, objConexao);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds.Tables[0].Rows.Count;
    }

    public static int CountReservasCanceladas()
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = " SELECT * FROM res_reserva res " +
                     " WHERE res.res_datacancelamento is not null ";

        objCommand = Mapped.Comando(sql, objConexao);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds.Tables[0].Rows.Count;
    }

    public static Reserva Select(int id)
    {
        Reserva obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM res_reserva WHERE res_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Reserva();

            Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(objDataReader["htl_id"]));
            obj.hotel = hotel;

            Hospede hospede = HospedeDB.Select(Convert.ToInt32(objDataReader["pes_id"]));
            obj.hospede = hospede;

            obj.id = Convert.ToInt32(objDataReader["res_id"]);
            obj.motivoCancelamento = Convert.ToString(objDataReader["res_motivo_cancelamento"]);
            obj.observacoes = Convert.ToString(objDataReader["res_observacoes"]);
            obj.previsaoChegada = Convert.ToDateTime(objDataReader["res_previsao_chegada"]);
            obj.previsaoSaida = Convert.ToDateTime(objDataReader["res_previsao_saida"]);


            if (objDataReader["res_checkin"] != DBNull.Value)
                obj.checkin = Convert.ToDateTime(objDataReader["res_checkin"]);

            if (objDataReader["res_checkout"] != DBNull.Value)
                obj.checkout = Convert.ToDateTime(objDataReader["res_checkout"]);


            if (objDataReader["res_dataalteracao"] != DBNull.Value)
                obj.dataAlteracao = Convert.ToDateTime(objDataReader["res_dataalteracao"]);

            if (objDataReader["res_datacancelamento"] != DBNull.Value)
                obj.dataCancelamento = Convert.ToDateTime(objDataReader["res_datacancelamento"]);

            obj.dataInclusao = Convert.ToDateTime(objDataReader["res_datainclusao"]);
            obj.valorLiquido = Convert.ToDecimal(objDataReader["res_valorliquido"]);
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }

    public static int getInsertID()
    {
        int id = 0;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT max(res_id) id FROM res_reserva";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            id = Convert.ToInt32(objDataReader["id"]);
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return id;
    }

    public static DataSet getApartamentosReservados(int idReserva)
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = " SELECT rap.apt_id, concat(apt.apt_numero, ' / ', apt.apt_descricao) as descricao FROM rap_reserva_apartamento rap " +

                     " LEFT JOIN apt_apartamento apt ON " +
                     " (apt.htl_id = rap.htl_id" +
                     " AND apt.apt_id = rap.apt_id) " +

                     " WHERE rap.res_id = ?res_id";

        objCommand = Mapped.Comando(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parametro("?res_id", idReserva));

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }

}