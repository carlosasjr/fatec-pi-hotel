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
        DataSet ds = HospedeDB.SelectAll();
        int qtd = Funcoes.DSQuantidadesRegistros(ds);


        if (qtd > 0)
        {
            gdvHospede.DataSource = ds.Tables[0].DefaultView;
            gdvHospede.DataBind();
            gdvHospede.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            Carrega();

        if (gdvHospede.Rows.Count > 0)
            gdvHospede.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void gdvHospede_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;

        switch (e.CommandName)
        {
            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("Hospede.aspx");
                break;

            case "Deletar":
                codigo = Convert.ToInt32(e.CommandArgument);
                HospedeDB.Delete(codigo);
                Carrega();
                break;

            default:
                break;

        }
    }

    protected void lbCadastrar_Click(object sender, EventArgs e)
    {
        Session["ID"] = "";
        Response.Redirect("hospede.aspx");
    }
}