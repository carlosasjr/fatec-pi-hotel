using Hotel.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paginas_Default3 : System.Web.UI.Page
{
    private void CarregaAndar()
    {
        DataSet ds = null;
        ds = AndarDB.SelectAll();

        DdlAndar.Items.Clear();
        //vincula dados do ds ao componente ddl
        DdlAndar.DataSource = ds.Tables[0].DefaultView;
        DdlAndar.DataTextField = "and_numero";
        DdlAndar.DataValueField = "and_id";
        DdlAndar.DataBind();
        //adiciona item "Selecione" na primeira posição do ddl
        DdlAndar.Items.Insert(0, "Selecione");
    }
    private void CarregaCategoria()
    {
        DataSet ds = null;
        ds = CategoriaDB.SelectAll();

        DdlCategoria.Items.Clear();
        //vincula dados do ds ao componente ddl
        DdlCategoria.DataSource = ds.Tables[0].DefaultView;
        DdlCategoria.DataTextField = "cat_descricao";
        DdlCategoria.DataValueField = "cat_id";
        DdlCategoria.DataBind();
        //adiciona item "Selecione" na primeira posição do ddl
        DdlCategoria.Items.Insert(0, "Selecione");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaAndar();
            CarregaCategoria();

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

                    for (int i = 0; i < DdlAndar.Items.Count; i++)
                    {
                        if (DdlAndar.Items[i].Value == Convert.ToString(apt.andar.id))
                            DdlAndar.Items[i].Selected = true;
                    }
                    for (int i = 0; i < DdlCategoria.Items.Count; i++)
                    {
                        if (DdlCategoria.Items[i].Value == Convert.ToString(apt.categoria.id))
                            DdlCategoria.Items[i].Selected = true;
                    }
                }
            }
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Apartamento apt = new Apartamento();

        Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(1));
        Andar andar = AndarDB.Select(Convert.ToInt32(DdlAndar.SelectedItem.Value));

        Categoria categoria = CategoriaDB.Select(Convert.ToInt32(DdlCategoria.SelectedItem.Value));

        apt.hotel = hotel;
        apt.andar = andar;
        apt.categoria = categoria;
        apt.descricao = txtDescricao.Text;
        apt.numero = txtNumero.Text;
        apt.ramal = Convert.ToInt32(txtRamal.Text);
        apt.acessibilidade = Convert.ToString(txtAcessibilidade.Text);
        apt.berco = Convert.ToString(txtBerco.Text);
        apt.posicao = Convert.ToInt32(txtPosicao.Text);
        apt.qtdCamaCasal = Convert.ToInt32(txtQtdCamaCasal.Text);
        apt.qtdCamaSolteiro = Convert.ToInt32(txtQtdCamaSolteiro.Text);
        apt.observacoes = txtObservacoes.Text;
        apt.status = txtStatus.Text;
        apt.ativo = "1";

        if (txtID.Text != "")
        {
            apt.id = Convert.ToInt32(txtID.Text);


        }

        int retorno = ApartamentoDB.Store(apt);

        switch (retorno)
        {
            case 0:
                Response.Redirect("listarApartamentos.aspx");
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

    protected void DdlAndar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}