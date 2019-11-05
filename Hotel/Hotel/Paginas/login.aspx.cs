using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel.Classes;

public partial class Paginas_login : System.Web.UI.Page
{
    private bool IsPreenchido(string str)
    {
        bool retorno = false;
        if (str != string.Empty)
        {
            retorno = true;
        }
        return retorno;
    }

    private bool UsuarioEncontrado(Funcionario funcionario)
    {
        bool retorno = false;
        if (funcionario != null)
        {
            retorno = true;
        }
        return retorno;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensagem.Visible = false;
    }

    protected void lbLogar_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string senha = txtSenha.Text.Trim();
        if (!IsPreenchido(email))
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = "Preencha o email";
            txtEmail.Focus();
            return;
        }
        if (!IsPreenchido(senha))
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = "Preencha a senha";
            txtSenha.Focus();
            return;
        }

        Funcionario funcioario = new Funcionario();
        funcioario = FuncionarioDB.Autentica(email, senha);

        if (!UsuarioEncontrado(funcioario))
        {
            lblMensagem.Text = "Usuário não encontrado";
            txtEmail.Focus();
            return;
        }
        Session["LOGIN"] = funcioario.id;
        Response.Redirect("/Paginas/index.aspx");
    }
}