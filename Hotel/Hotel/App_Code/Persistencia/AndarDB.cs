using Hotel.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de AndarDB
/// </summary>
public class AndarDB
{
    public static Andar Select(int id)
    {

        Andar obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM and_andar WHERE and_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Andar();

            Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(objDataReader["htl_id"]));
            obj.hotel = hotel;

            obj.numero = Convert.ToInt32(objDataReader["and_numero"]);
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}