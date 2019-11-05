using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel.Classes;

public partial class Content_Master_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Verifica se fez login, senão redireciona para a pagina de login,
       if (Convert.ToString(Session["LOGIN"]) == "")
        {
            Response.Redirect("../Paginas/login.aspx");
        }

        Funcionario funcionario = FuncionarioDB.Select(Convert.ToInt32(Session["LOGIN"]));
        lbUsuarioLogado.Text = funcionario.nome;
    }

}
