using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hotel.Classes;

public partial class Paginas_Default3 : System.Web.UI.Page
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

    private void CarregaHospedes()
    {
        DataSet ds = null;
        ds = HospedeDB.SelectAll();

        DdlHospede.Items.Clear();
        //vincula dados do ds ao componente ddl
        DdlHospede.DataSource = ds.Tables[0].DefaultView;
        DdlHospede.DataTextField = "pes_nome";
        DdlHospede.DataValueField = "pes_id";
        DdlHospede.DataBind();
        //adiciona item "Selecione" na primeira posição do ddl
        DdlHospede.Items.Insert(0, "Selecione");
    }

    private void CarregaApartamentos()
    {
        if (!IsPreenchido(txtDataEntrada.Text))
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = "Preencha a data de entrada";
            txtDataEntrada.Focus();
            return;
        }

        if (!IsPreenchido(txtDataSaida.Text))
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = "Preencha a data de saída";
            txtDataSaida.Focus();
            return;
        }



        DataSet ds = null;
        ds = ApartamentoDB.getDisponiveis(Convert.ToDateTime(txtDataEntrada.Text), Convert.ToDateTime(txtDataSaida.Text));

        int qtd = Funcoes.DSQuantidadesRegistros(ds);

        if (qtd == 0)
        {
            cblQuartosDisponiveis.Items.Clear();
            txtDisponiveis.Visible = true;
            txtDisponiveis.Text = "Nenhum apartamento disponível nesta data";
            return;
        }

        txtDisponiveis.Visible = false;

        cblQuartosDisponiveis.Items.Clear();
        //vincula dados do ds ao componente ddl
        cblQuartosDisponiveis.DataSource = ds.Tables[0].DefaultView;
        cblQuartosDisponiveis.DataTextField = "descricao";
        cblQuartosDisponiveis.DataValueField = "apt_id";
        cblQuartosDisponiveis.DataBind();

    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaHospedes();
        }
    }

    protected void lbAdicionarQuarto_Click(object sender, EventArgs e)
    {
        clbQuartosAdicionados.Items.Clear();

        List<ListItem> toBeRemoved = new List<ListItem>();

        for (int i = 0; i < cblQuartosDisponiveis.Items.Count; i++)
        {
            if (cblQuartosDisponiveis.Items[i].Selected)
            {
                clbQuartosAdicionados.Items.Add(cblQuartosDisponiveis.Items[i]);
                toBeRemoved.Add(cblQuartosDisponiveis.Items[i]);
            }
        }

        for (int i = 0; i < toBeRemoved.Count; i++)
        {
            cblQuartosDisponiveis.Items.Remove(toBeRemoved[i]);
        }
    }



    protected void lbReservar_Click(object sender, EventArgs e)
    {
        if (DdlHospede.SelectedItem.Value == "Selecione")
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = "Nenhum hospede foi selecionado!";
            return;
        }

        if (clbQuartosAdicionados.Items.Count == 0)
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = "Nenhum apartamento foi adicionado!";
            return;
        }



        Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(1));
        Hospede hospede = HospedeDB.Select(Convert.ToInt32(DdlHospede.SelectedItem.Value));

        Reserva reserva = new Reserva();

        reserva.hotel = hotel;
        reserva.hospede = hospede;
        reserva.dataInclusao = DateTime.Now;
        reserva.previsaoChegada = Convert.ToDateTime(txtDataEntrada.Text);
        reserva.previsaoSaida = Convert.ToDateTime(txtDataSaida.Text);
        reserva.observacoes = txtObservacoes.Text.Trim();
        reserva.valorLiquido = 0;

        int retornoReserva = ReservaDB.Store(reserva);

        reserva.id = ReservaDB.getInsertID();

        for (int i = 0; i < clbQuartosAdicionados.Items.Count; i++)
        {
            if (clbQuartosAdicionados.Items[i].Selected)
            {

                ReservaApartamento res_ap = new ReservaApartamento();
                res_ap.hotel = hotel;
                res_ap.reserva = reserva;

                Apartamento apt = ApartamentoDB.Select(Convert.ToInt32(clbQuartosAdicionados.Items[i].Value));
                res_ap.apartamento = apt;

                int retornoReservaApt = ReservaApartamentoDB.Store(res_ap);
            }
        }

        Response.Redirect("listarReserva.aspx");
    }



    protected void LbFiltrarApartamentos_Click(object sender, EventArgs e)
    {
        CarregaApartamentos();
    }

}