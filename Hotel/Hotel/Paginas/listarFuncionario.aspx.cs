using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default3 : System.Web.UI.Page
{
    private void Carrega()
    {
        DataSet ds = FuncionarioDB.SelectAll();
        int qtd = Funcoes.DSQuantidadesRegistros(ds);


        if (qtd > 0)
        {
            gdvFuncionario.DataSource = ds.Tables[0].DefaultView;
            gdvFuncionario.DataBind();
            gdvFuncionario.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            Carrega();

        if (gdvFuncionario.Rows.Count > 0)
            gdvFuncionario.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void gdvFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;

        switch (e.CommandName)
        {
            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("Funcionario.aspx");
                break;

            case "Deletar":
                codigo = Convert.ToInt32(e.CommandArgument);
                FuncionarioDB.Delete(codigo);
                Carrega();
                break;

            default:
                break;

        }
    }

    protected void lbCadastrar_Click(object sender, EventArgs e)
    {
        Session["ID"] = "";
        Response.Redirect("Funcionario.aspx");
    }
}