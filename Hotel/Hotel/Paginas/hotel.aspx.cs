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
    private void CarregaUFs()
    {
        DataSet ds = null;
        ds = EstadoDB.SelectAll();

        DdlUF.Items.Clear();
        //vincula dados do ds ao componente ddl
        DdlUF.DataSource = ds.Tables[0].DefaultView;
        DdlUF.DataTextField = "uf_descricao";
        DdlUF.DataValueField = "uf_sigla";
        DdlUF.DataBind();
        //adiciona item "Selecione" na primeira posição do ddl
        DdlUF.Items.Insert(0, "Selecione");
    }

    private void CarregaCidades(string uf)
    {
        DataSet ds = null;
        ds = CidadeDB.getMunicipiosUF(uf);

        ddlCidade.Items.Clear();
        //vincula dados do ds ao componente ddl
        ddlCidade.DataSource = ds.Tables[0].DefaultView;
        ddlCidade.DataTextField = "cid_nome";
        ddlCidade.DataValueField = "cid_codibge";
        ddlCidade.DataBind();
        //adiciona item "Selecione" na primeira posição do ddl
        ddlCidade.Items.Insert(0, "Selecione");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CarregaUFs();

            Hotel.Classes.Hotel hotel = HotelDB.Select(1);

            if (hotel != null)
            {
                txtID.Text = hotel.id.ToString();
                txtRazao.Text = hotel.razao;
                txtFantasia.Text = hotel.fantasia;
                txtResponsavel.Text = hotel.reponsavel;
                txtCNPJ.Text = hotel.cnpj;
                txtIE.Text = hotel.ie;
                txtIM.Text = hotel.im;
                txtTelefone.Text = hotel.telefone;
                txtCelular.Text = hotel.celular;
                //txtEmail.txt = hotel.email;

                txtEndereco.Text = hotel.endereco;
                txtNumero.Text = hotel.numero;
                txtBairro.Text = hotel.bairro;
                //txtComplemento.Text = hotel.complemento;
      

                for (int i = 0; i < DdlUF.Items.Count; i++)
                {
                    if (DdlUF.Items[i].Value == hotel.estado.uf)
                        DdlUF.Items[i].Selected = true;
                }

                CarregaCidades(hotel.estado.uf);

                for (int i = 0; i < ddlCidade.Items.Count; i++)
                {
                    if (ddlCidade.Items[i].Value == hotel.cidade.codibge)
                        ddlCidade.Items[i].Selected = true;
                }

                txtCep.Text = hotel.cep;
            }

        }
    }

    protected void DdlUF_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlUF.SelectedItem.Text != "Selecione")
        {
            string uf = Convert.ToString(DdlUF.SelectedItem.Value);

            CarregaCidades(uf);
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Hotel.Classes.Hotel hotel = new Hotel.Classes.Hotel();

        hotel.razao = txtRazao.Text;
        hotel.fantasia = txtFantasia.Text;
        hotel.cnpj = txtCNPJ.Text;
        hotel.reponsavel = txtResponsavel.Text;
        hotel.cep = txtCep.Text;
        hotel.endereco = txtEndereco.Text;
        hotel.numero = txtNumero.Text;
        hotel.bairro = txtBairro.Text;
        //obj.complemento = Convert.ToString(objDataReader["htl_complemento"]);

        Cidade cidade = CidadeDB.Select(Convert.ToInt32(ddlCidade.SelectedItem.Value));
        hotel.cidade = cidade;

        hotel.estado = cidade.uf;

        hotel.telefone = txtTelefone.Text;
        hotel.celular = txtCelular.Text;
        hotel.ie = txtIE.Text;
        hotel.im = txtIM.Text;
        hotel.cnae = "0";
        hotel.tipofaturamento = 0;
        hotel.vagas_estacionamento = 0;
        hotel.ativo = 0;

        if (txtID.Text != "")
        {
            hotel.id = Convert.ToInt32(txtID.Text);


        }

        int retorno = HotelDB.Store(hotel);

        switch (retorno)
        {
            case 0:                
                txtRazao.Focus();
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