using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Hotel.Classes;

/// <summary>
/// Summary description for FuncionarioDB
/// </summary>
public class FuncionarioDB
{
    public static int Store(Funcionario funcionario)
    {
        int retorno = 0;

        try
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Conexao();

            if (funcionario.id == 0)
            {
                string sql = "INSERT INTO pes_pessoa(" +
                             "htl_id, pes_nome, pes_email, pes_cep, pes_endereco, pes_numero," +
                             "pes_bairro, pes_complemento, pes_fisica_juridica," +
                             "pes_cpf_cnpj, pes_rg, pes_datanasc, pes_estadocivil, " +
                             "pes_profissao, pes_telefone, pes_celular, pes_contato, " +
                             "uf_sigla, cid_codibge, pes_tipo, pes_ativo, pes_senha) " +
                             "VALUES " +
                             "(?htl_id, ?pes_nome, ?pes_email, ?pes_cep, ?pes_endereco, ?pes_numero," +
                             "?pes_bairro, ?pes_complemento, ?pes_fisica_juridica," +
                             "?pes_cpf_cnpj, ?pes_rg, ?pes_datanasc, ?pes_estadocivil, " +
                             "?pes_profissao, ?pes_telefone, ?pes_celular, ?pes_contato, " +
                             "?uf_sigla, ?cid_codibge,  ?pes_tipo, ?pes_ativo, ?pes_senha)";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?htl_id", funcionario.hotel.id));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_nome", funcionario.nome));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_email", funcionario.email));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_cep", funcionario.cep));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_endereco", funcionario.endereco));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_numero", funcionario.numero));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_bairro", funcionario.bairro));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_complemento", funcionario.complemento));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_fisica_juridica", funcionario.fisica_juridica));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_cpf_cnpj", funcionario.cpf_cnpj));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_rg", funcionario.rg));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_datanasc", Convert.ToDateTime(funcionario.nascimento)));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_estadocivil", funcionario.estado_civil));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_profissao", funcionario.profissao));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_telefone", funcionario.telefone));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_celular", funcionario.celular));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_contato", funcionario.contato));
                objCommand.Parameters.Add(Mapped.Parametro("?uf_sigla", funcionario.estado.uf));
                objCommand.Parameters.Add(Mapped.Parametro("?cid_codibge", funcionario.cidade.codibge));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_tipo", funcionario.tipo));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_ativo", Convert.ToString(funcionario.ativo)));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_senha", funcionario.senha));
            }
            else
            {
                string sql = "UPDATE pes_pessoa SET pes_nome = ?pes_nome, " +
                              "pes_email = ?pes_email, " +
                              "pes_senha = ?pes_senha, " +
                              "pes_cep = ?pes_cep, " +
                              "pes_endereco = ?pes_endereco, " +
                              "pes_numero = ?pes_numero, " +
                              "pes_bairro = ?pes_bairro, " +
                              "pes_complemento = ?pes_complemento, " +
                              "pes_fisica_juridica = ?pes_fisica_juridica, " +
                              "pes_cpf_cnpj = ?pes_cpf_cnpj, " +

                              "pes_rg = ?pes_rg, " +
                              "pes_datanasc = ?pes_datanasc, " +
                              "pes_estadocivil = ?pes_estadocivil, " +
                              "pes_profissao = ?pes_profissao, " +

                              "pes_telefone = ?pes_telefone, " +
                              "pes_celular = ?pes_celular, " +
                              "pes_contato = ?pes_contato, " +
                              "uf_sigla = ?uf_sigla, " +
                              "cid_codibge = ?cid_codibge," +
                              "pes_tipo = ?pes_tipo " +
                              "WHERE pes_id = ?id";

                objCommand = Mapped.Comando(sql, objConexao);

                objCommand.Parameters.Add(Mapped.Parametro("?pes_nome", funcionario.nome));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_email", funcionario.email));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_senha", funcionario.senha));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_cep", funcionario.cep));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_endereco", funcionario.endereco));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_numero", funcionario.numero));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_bairro", funcionario.bairro));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_complemento", funcionario.complemento));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_fisica_juridica", funcionario.fisica_juridica));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_cpf_cnpj", funcionario.cpf_cnpj));

                objCommand.Parameters.Add(Mapped.Parametro("?pes_rg", funcionario.rg));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_datanasc", Convert.ToDateTime(funcionario.nascimento)));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_estadocivil", funcionario.estado_civil));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_profissao", funcionario.profissao));

                objCommand.Parameters.Add(Mapped.Parametro("?pes_telefone", funcionario.telefone));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_celular", funcionario.celular));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_contato", funcionario.contato));
                objCommand.Parameters.Add(Mapped.Parametro("?uf_sigla", funcionario.estado.uf));
                objCommand.Parameters.Add(Mapped.Parametro("?cid_codibge", funcionario.cidade.codibge));
                objCommand.Parameters.Add(Mapped.Parametro("?pes_tipo", funcionario.tipo));

                objCommand.Parameters.Add(Mapped.Parametro("?id", funcionario.id));
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

    public static DataSet SelectAll()
    {
        DataSet ds = new DataSet();

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataAdapter objDataAdapter;

        objConexao = Mapped.Conexao();

        string sql = "SELECT * FROM pes_pessoa WHERE pes_tipo = ?pes_tipo";
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?pes_tipo", '0'));

        objDataAdapter = Mapped.Adapter(objCommand);
        objDataAdapter.Fill(ds);

        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return ds;
    }

    public static Funcionario Select(int id)
    {

        Funcionario obj = null;

        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        string sql = "SELECT * FROM pes_pessoa WHERE pes_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Funcionario();
            obj.id = Convert.ToInt32(objDataReader["pes_id"]);
            obj.nome = Convert.ToString(objDataReader["pes_nome"]);
            obj.email = Convert.ToString(objDataReader["pes_email"]);
            obj.email = Convert.ToString(objDataReader["pes_senha"]);
            obj.endereco = Convert.ToString(objDataReader["pes_endereco"]);
            obj.numero = Convert.ToString(objDataReader["pes_numero"]);
            obj.bairro = Convert.ToString(objDataReader["pes_bairro"]);
            obj.cep = Convert.ToString(objDataReader["pes_cep"]);
            obj.complemento = Convert.ToString(objDataReader["pes_complemento"]);
            obj.fisica_juridica = Convert.ToString(objDataReader["pes_fisica_juridica"]);
            obj.cpf_cnpj = Convert.ToString(objDataReader["pes_cpf_cnpj"]);
            obj.rg = Convert.ToString(objDataReader["pes_rg"]);
            obj.nascimento = Convert.ToString(objDataReader["pes_datanasc"]);
            obj.estado_civil = Convert.ToString(objDataReader["pes_estadocivil"]);
            obj.profissao = Convert.ToString(objDataReader["pes_profissao"]);
            obj.telefone = Convert.ToString(objDataReader["pes_telefone"]);
            obj.celular = Convert.ToString(objDataReader["pes_celular"]);
            obj.contato = Convert.ToString(objDataReader["pes_contato"]);
            obj.tipo = Convert.ToString(objDataReader["pes_tipo"]);
            obj.ativo = Convert.ToInt32(objDataReader["pes_ativo"]);
            obj.senha = Convert.ToString(objDataReader["pes_senha"]);

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

    public static Funcionario Autentica(string email, string senha)
    {
        Funcionario obj = null;
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        System.Data.IDataReader objDataReader;

        objConexao = Mapped.Conexao();

        objCommand = Mapped.Comando("SELECT * FROM pes_pessoa WHERE pes_email = ?email " +
                                    " and pes_senha = ?senha", objConexao);


        objCommand.Parameters.Add(Mapped.Parametro("?email", email));
        objCommand.Parameters.Add(Mapped.Parametro("?senha", senha));

        objDataReader = objCommand.ExecuteReader();

        while (objDataReader.Read())
        {
            obj = new Funcionario();
            obj.id = Convert.ToInt32(objDataReader["pes_id"]);
            obj.nome = Convert.ToString(objDataReader["pes_nome"]);
            obj.email = Convert.ToString(objDataReader["pes_email"]);
        }

        objDataReader.Close();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();
        objDataReader.Dispose();
        return obj;
    }

    public static bool Delete(int id)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;

        string sql = "DELETE FROM pes_pessoa WHERE pes_id = ?id";

        objConexao = Mapped.Conexao();
        objCommand = Mapped.Comando(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parametro("?id", id));

        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose();
        objConexao.Dispose();

        return true;
    }
}