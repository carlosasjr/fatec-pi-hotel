using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel.Classes;

public partial class Paginas_Default3 : System.Web.UI.Page
{
    private void CarregaApartamentos(int id_reserva)
    {
        DataSet ds = null;
        ds = ReservaDB.getApartamentosReservados(id_reserva);


        clbQuartosAdicionados.Items.Clear();
        //vincula dados do ds ao componente ddl
        clbQuartosAdicionados.DataSource = ds.Tables[0].DefaultView;
        clbQuartosAdicionados.DataTextField = "descricao";
        clbQuartosAdicionados.DataValueField = "apt_id";
        clbQuartosAdicionados.DataBind();

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToString(Session["ID"]) != "")
            {
                Reserva reserva = ReservaDB.Select(Convert.ToInt32(Session["ID"]));

                if (reserva != null)
                {
                    txtID.Text = reserva.id.ToString();
                    txtHospede.Text = reserva.hospede.nome;
                    txtDataEntrada.Text = reserva.previsaoChegada.ToString("dd/MM/yyyy");
                    txtDataSaida.Text = reserva.previsaoSaida.ToString("dd/MM/yyyy");
                    txtObservacoes.Text = reserva.observacoes;

                    CarregaApartamentos(reserva.id);
                }
            }
        }
    }

    protected void lbCheckIn_Click(object sender, EventArgs e)
    {
        int retornoCheckInt = ReservaDB.CheckOut(Convert.ToInt32(Session["ID"]));

        switch (retornoCheckInt)
        {
            case 0:

                for (int i = 0; i < clbQuartosAdicionados.Items.Count; i++)
                {
                    Apartamento apt = ApartamentoDB.Select(Convert.ToInt32(clbQuartosAdicionados.Items[i].Value));

                    int retornoStatus = ApartamentoDB.setStatus(apt.id, "Sujo");
                }



                Response.Redirect("listarReserva.aspx");
                break;

            default:
                break;
        }

    }
}