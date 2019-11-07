using Hotel.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ApartamentoDB
/// </summary>
public class ApartamentoDB
{
    public static int Store(Apartamento apartamento)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (apartamento.id == 0)
            {
                string sql = "INSERT INTO apt_apartamento(htl_id,and_id,cat_id,apt_descricao,apt_numero,apt_ramal,apt_acessibilidade," +
                    "apt_berco,apt_posicao,apt_qtd_cama_casal,apt_qtd_cama_solteiro,apt_observacoes,apt_status,apt_ativo) VALUES (?htl_id,?and_id,?cat_id,?apt_descricao,?apt_numero,?apt_ramal,?apt_acessibilidade," +
                    "?apt_berco,?apt_posicao,?apt_qtd_cama_casal,?apt_qtd_cama_solteiro,?apt_observacoes,?apt_status,?apt_ativo)";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", apartamento.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?and_id", apartamento.andar.id));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_id", apartamento.categoria.id));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_descricao", apartamento.descricao));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_numero", apartamento.numero));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_ramal", apartamento.ramal));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_acessibilidade", apartamento.acessibilidade));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_berco", apartamento.berco));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_posicao", apartamento.posicao));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_qtd_cama_casal", apartamento.qtdCamaCasal));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_qtd_cama_solteiro", apartamento.qtdCamaSolteiro));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_observacoes", apartamento.observacoes));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_status", apartamento.status));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_ativo", apartamento.ativo));




            }
            else
            {
                string sql = "UPDATE apt_apartamento SET " +
                             "htl_id = ?htl_id, " +
                             "and_id = ?and_id, " +
                             "cat_id = ?cat_id," +
                             "apt_descricao = ?apt_descricao, " +
                             "apt_numero = ?apt_numero, " +
                             "apt_ramal = ?apt_ramal, " +
                             "apt_acessibilidade = ?apt_acessibilidade, " +
                             "apt_berco = ?apt_berco, " +
                             "apt_posicao = ?apt_posicao, " +
                             "apt_qtd_cama_casal = ?apt_qtd_cama_casal, " +
                             "apt_qtd_cama_solteiro = ?apt_qtd_cama_solteiro, " +
                             "apt_observacoes = ?apt_observacoes, " +
                             "apt_status = ?apt_status, " +
                             "apt_ativo = ?apt_ativo " +
                             "WHERE apt_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", apartamento.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?and_id", apartamento.andar.id));
                objCommand.Parameters.Add(Mapped.Parametro("?cat_id", apartamento.categoria.id));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_descricao", apartamento.descricao));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_numero", apartamento.numero));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_ramal", apartamento.ramal));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_acessibilidade", apartamento.acessibilidade));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_berco", apartamento.berco));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_posicao", apartamento.posicao));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_qtd_cama_casal", apartamento.qtdCamaCasal));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_qtd_cama_solteiro", apartamento.qtdCamaSolteiro));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_observacoes", apartamento.observacoes));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_status", apartamento.status));
                objCommand.Parameters.Add(Mapped.Parametro("?apt_ativo", apartamento.ativo));

                objCommand.Parameters.Add(Mapped.Parametro("?id", apartamento.id));
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

        catch (Exception e )
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

        string sql = "DELETE FROM apt_apartamento WHERE apt_id = ?id";

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

        string sql = "SELECT * FROM apt_apartamento";
        objCommand = Mapped.Comando(sql, objConexao);

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }
    public static Apartamento Select(int id)
    {

        Apartamento obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM apt_apartamento WHERE apt_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Apartamento();

            Andar andar = AndarDB.Select(Convert.ToInt32(objDataReader["and_id"]));
            obj.andar = andar;
            Categoria categoria = CategoriaDB.Select(Convert.ToInt32(objDataReader["cat_id"]));
            obj.categoria = categoria;

            obj.hotel = obj.andar.hotel;
            
            obj.id = Convert.ToInt32(objDataReader["apt_id"]);
            obj.descricao = Convert.ToString(objDataReader["apt_descricao"]);
            obj.numero = Convert.ToString(objDataReader["apt_numero"]);
            obj.ramal = Convert.ToInt32(objDataReader["apt_ramal"]);
            obj.acessibilidade = Convert.ToString(objDataReader["apt_acessibilidade"]);
            obj.berco = Convert.ToString(objDataReader["apt_berco"]);
            obj.posicao = Convert.ToInt32(objDataReader["apt_posicao"]);
            obj.qtdCamaCasal = Convert.ToInt32(objDataReader["apt_qtd_cama_casal"]);
            obj.qtdCamaSolteiro = Convert.ToInt32(objDataReader["apt_qtd_cama_solteiro"]);
            obj.observacoes = Convert.ToString(objDataReader["apt_observacoes"]);
            obj.status = Convert.ToString(objDataReader["apt_status"]);
            obj.ativo = Convert.ToString(objDataReader["apt_ativo"]);
            
        }


        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();

        return obj;
    }
}
