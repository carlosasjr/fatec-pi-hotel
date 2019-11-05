using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            Carrega();

        if (gdvApartamento.Rows.Count > 1)
            gdvApartamento.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    private void Carrega()
    {
        DataSet ds = ApartamentoDB.SelectAll();
        int qtd = Funcoes.DSQuantidadesRegistros(ds);
        if (qtd > 0)
        {

            gdvApartamento.DataSource = ds.Tables[0].DefaultView;
            gdvApartamento.DataBind();
            gdvApartamento.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void lbCadastrar_Click(object sender, EventArgs e)
    {
        Session["ID"] = "";
        Response.Redirect("Apartamento.aspx");
    }







    protected void gdvApartamento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;

        switch (e.CommandName)
        {
            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("Apartamento.aspx");
                break;

            case "Deletar":
                codigo = Convert.ToInt32(e.CommandArgument);
                ApartamentoDB.Delete(codigo);
                Carrega();
                break;

            default:
                break;

        }
    }

}

