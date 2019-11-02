using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Hotel.Classes;

/// <summary>
/// Summary description for HotelDB
/// </summary>
public class HotelDB
{

    public static int Store(Hotel.Classes.Hotel hotel)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (hotel.id == 0)
            {
                 string sql = "INSERT INTO htl_hotel() VALUES ()";

                 objCommand = Mapped.Comando(sql, objConexao);

                 objCommand.Parameters.Add(Mapped.Parametro("?nome", hotel.razao));
            }
            else
            {
                string sql = "UPDATE htl_hotel SET " +
                             "htl_razao = ?htl_razao, " +
                             "htl_fantasia = ?htl_fantasia, " +
                             "htl_cnpj = ?htl_cnpj, " +
                             "htl_responsavel = ?htl_responsavel, " +
                             "htl_cep = ?htl_cep, " +
                             "htl_endereco = ?htl_endereco, " +
                             "htl_numero = ?htl_numero, " +
                             "htl_bairro = ?htl_bairro, " +
                             "uf_sigla = ?uf_sigla, " +
                             "cid_codibge = ?cid_codibge, " +
                             "htl_telefone = ?htl_telefone, " +
                             "htl_celular = ?htl_celular, " +
                             "htl_ie = ?htl_ie, " +
                             "htl_im = ?htl_im, " +
                             "htl_cnae = ?htl_cnae, " +
                             "htl_tipofaturamento = ?htl_tipofaturamento, " +
                             "htl_vagas_estacionamento = ?htl_vagas_estacionamento, " +
                             "htl_ativo = ?htl_ativo " +
                             "WHERE htl_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_razao", hotel.razao));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_fantasia", hotel.fantasia));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_cnpj", hotel.cnpj));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_responsavel", hotel.reponsavel));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_cep", hotel.cep));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_endereco", hotel.endereco));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_numero", hotel.numero));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_bairro", hotel.bairro));
                objCommand.Parameters.Add(Mapped.Parametro("?uf_sigla", hotel.estado.uf));
                objCommand.Parameters.Add(Mapped.Parametro("?cid_codibge", hotel.cidade.codibge));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_telefone", hotel.telefone));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_celular", hotel.celular));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_ie", hotel.ie));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_im", hotel.im));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_cnae", hotel.cnae));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_tipofaturamento", hotel.tipofaturamento));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_vagas_estacionamento", hotel.vagas_estacionamento));
                objCommand.Parameters.Add(Mapped.Parametro("?htl_ativo", Convert.ToString(hotel.ativo)));

                objCommand.Parameters.Add(Mapped.Parametro("?id", hotel.id));
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


    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = "SELECT * FROM htl_hotel";
        objCommand = Mapped.Comando(sql, objConexao);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }

    public static Hotel.Classes.Hotel Select(int id)
    {

        Hotel.Classes.Hotel obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM htl_hotel WHERE htl_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Hotel.Classes.Hotel();
            obj.id = Convert.ToInt32(objDataReader["htl_id"]);
            obj.razao = Convert.ToString(objDataReader["htl_razao"]);
            obj.fantasia = Convert.ToString(objDataReader["htl_fantasia"]);
            obj.cnpj = Convert.ToString(objDataReader["htl_cnpj"]);
            obj.reponsavel = Convert.ToString(objDataReader["htl_responsavel"]);
            obj.cep = Convert.ToString(objDataReader["htl_cep"]);
            obj.endereco = Convert.ToString(objDataReader["htl_endereco"]);
            obj.numero = Convert.ToString(objDataReader["htl_numero"]);
            obj.bairro = Convert.ToString(objDataReader["htl_bairro"]);
            //obj.complemento = Convert.ToString(objDataReader["htl_complemento"]);
            obj.telefone = Convert.ToString(objDataReader["htl_telefone"]);
            obj.celular = Convert.ToString(objDataReader["htl_celular"]);
            obj.ie = Convert.ToString(objDataReader["htl_ie"]);
            obj.im = Convert.ToString(objDataReader["htl_im"]);
            obj.cnae = Convert.ToString(objDataReader["htl_cnae"]);
            obj.tipofaturamento = Convert.ToInt32(objDataReader["htl_tipofaturamento"]);
            obj.vagas_estacionamento = Convert.ToInt32(objDataReader["htl_vagas_estacionamento"]);
            obj.ativo = Convert.ToInt32(objDataReader["htl_ativo"]);

            Cidade cidade = CidadeDB.Select(Convert.ToInt32(objDataReader["cid_codibge"]));
            obj.estado = cidade.uf;

            obj.cidade = cidade;
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}