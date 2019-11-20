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
        DataSet ds = ReservaDB.SelectAll();
        int qtd = Funcoes.DSQuantidadesRegistros(ds);


        if (qtd > 0)
        {
            gdvReserva.DataSource = ds.Tables[0].DefaultView;
            gdvReserva.DataBind();
            gdvReserva.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            Carrega();

        if (gdvReserva.Rows.Count > 0)
            gdvReserva.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void lbCadastrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reserva.aspx");
    }

    protected void gdvReserva_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;

        switch (e.CommandName)
        {
            case "CheckIn":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("checkIn.aspx");
                break;

            case "CheckOut":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("checkOut.aspx");
                break;

            case "Cancelar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("cancelarReserva.aspx");
                break;

            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["ID"] = codigo;
                Response.Redirect("alterarReserva.aspx");
                break;

            default:
                break;

        }
    }

    protected void gdvReserva_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}