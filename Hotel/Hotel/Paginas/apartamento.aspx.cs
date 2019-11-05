using Hotel.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToString(Session["ID"]) != "")
            {
                Apartamento apt = ApartamentoDB.Select(Convert.ToInt32(Session["ID"]));

                if (apt != null)
                {
                    txtID.Text = apt.id.ToString();
                    txtDescricao.Text = apt.descricao;
                    txtNumero.Text = apt.numero;
                    txtRamal.Text = Convert.ToString(apt.ramal);
                    txtAcessibilidade.Text = Convert.ToString(apt.acessibilidade);
                    txtBerco.Text = Convert.ToString(apt.berco);
                    txtPosicao.Text = Convert.ToString(apt.posicao);
                    txtQtdCamaCasal.Text = Convert.ToString(apt.qtdCamaCasal);
                    txtQtdCamaSolteiro.Text = Convert.ToString(apt.qtdCamaSolteiro);
                    txtObservacoes.Text = apt.observacoes;
                    txtStatus.Text = apt.status;
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Apartamento apt = new Apartamento();

        Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(1));
        Andar andar = AndarDB.Select(1);

        Categoria categoria = CategoriaDB.Select(48);

        apt.hotel = hotel;
        apt.andar = andar;
        apt.categoria = categoria;
        apt.descricao = txtDescricao.Text;
        apt.numero = txtNumero.Text;
        apt.ramal = Convert.ToInt32(txtRamal.Text);
        apt.acessibilidade = Convert.ToInt32(txtAcessibilidade.Text);
        apt.berco = Convert.ToInt32(txtBerco.Text);
        apt.posicao = Convert.ToInt32(txtPosicao.Text);
        apt.qtdCamaCasal = Convert.ToInt32(txtQtdCamaCasal.Text);
        apt.qtdCamaSolteiro = Convert.ToInt32(txtQtdCamaSolteiro.Text);
        apt.observacoes = txtObservacoes.Text;
        apt.status = txtStatus.Text;
        apt.ativo = 1;

        if (txtID.Text != "")
        {
            apt.id = Convert.ToInt32(txtID.Text);


        }

        int retorno = ApartamentoDB.Store(apt);

        switch (retorno)
        {
            case 0:
                txtDescricao.Focus();
                lblMensagem.Visible = true;
                lblMensagem.Text = "Cadastro realizado com sucesso.";
                break;

            case 1:
                lblMensagem.Visible = true;
                lblMensagem.Text = "Não foi possível realizar o cadastro.";
                break;

            case 2:
                lblMensagem.Visible = true;
                lblMensagem.Text = "Não foi possível realizar o cadastro.";
                break;

            default:
                break;
        }
    }
}