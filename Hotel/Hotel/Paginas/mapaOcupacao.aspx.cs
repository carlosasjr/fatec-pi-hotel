using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default3 : System.Web.UI.Page
{
    private void gerarBotoes(string status, string fa_icon)
    {
        DataSet ds;
        if (status.Equals("Reservado"))
            ds = ApartamentoDB.getReservadosNow("Disponível");
        else
            ds = ApartamentoDB.getStatusNow(status);


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            Panel pnlPrincipal = new Panel();
            pnlPrincipal.CssClass = "col-12 col-sm-4";

            Panel pnlInfo = new Panel();
            pnlInfo.CssClass = "info-box bg-aqua";
            pnlPrincipal.Controls.Add(pnlInfo);

            Panel pnlInfoBox = new Panel();
            pnlInfoBox.CssClass = "info-box-content ap";
            pnlInfo.Controls.Add(pnlInfoBox);

            Panel span = new Panel();
            span.CssClass = "info-box-icon";
            pnlInfo.Controls.Add(span);

            Panel icon = new Panel();
            icon.CssClass = "fa " + fa_icon; //
            span.Controls.Add(icon);

            Label lblDescricao = new Label();
            lblDescricao.CssClass = "info-box-text text-center lb";
            lblDescricao.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            pnlInfo.Controls.Add(lblDescricao);

            Label lblNumero = new Label();
            lblNumero.CssClass = "info-box-number text-center lb";
            lblNumero.Text = "Nº " + ds.Tables[0].Rows[i].ItemArray[1].ToString();
            pnlInfo.Controls.Add(lblNumero);

            panel1.Controls.Add(pnlPrincipal);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int qtdReservas = ReservaDB.CountReservasAtivas();
            lbNovasReservas.Text = Convert.ToString(qtdReservas);

            int qtdCancelas = ReservaDB.CountReservasCanceladas();
            lbCancelamentos.Text = Convert.ToString(qtdCancelas);

            int qtdHospedes = HospedeDB.Count();
            lbHospedes.Text = Convert.ToString(qtdHospedes);

            int qtdApartamentos = ApartamentoDB.Count();
            int qtdReservados = ApartamentoDB.CountReservados();

            decimal taxaOcupcao = (Convert.ToDecimal(qtdApartamentos) * Convert.ToDecimal(qtdReservados)) / 100;
            lbTaxaOcupacao.Text = Convert.ToString(taxaOcupcao);

        }
    }

    protected void lbDisponiveis_Click(object sender, EventArgs e)
    {
        gerarBotoes("Disponível", "fa-thumbs-o-up");
    }

    protected void lbCheckin_Click(object sender, EventArgs e)
    {
        gerarBotoes("Ocupado", "fa-bed");
    }

    protected void lbSujo_Click(object sender, EventArgs e)
    {
        gerarBotoes("Sujo", "fa-bookmark");
    }

    protected void lbBloqueado_Click(object sender, EventArgs e)
    {
        gerarBotoes("Bloqueado", "fa-calendar-times-o");
    }

    protected void lbLimpo_Click(object sender, EventArgs e)
    {
        gerarBotoes("Limpo", "fa-bookmark-o");
    }

    protected void lbReservados_Click(object sender, EventArgs e)
    {
        gerarBotoes("Reservado", "fa-calendar-check-o");
    }
}