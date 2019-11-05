using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Classes;

/// <summary>
/// Summary description for FuncionarioDB
/// </summary>
public class FuncionarioDB
{

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
            obj.tipo = Convert.ToInt32(objDataReader["pes_tipo"]);
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
}