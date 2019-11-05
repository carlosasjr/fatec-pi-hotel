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

            if (Convert.ToString(Session["ID"]) != "")
            {


                Hospede hospede = HospedeDB.Select(Convert.ToInt32(Session["ID"]));

                if (hospede != null)
                {
                    txtID.Text = hospede.id.ToString();
                    txtnome.Text = hospede.nome;
                    txtemail.Text = hospede.email;
                    txttelefone.Text = hospede.telefone;
                    txtcelular.Text = hospede.celular;
                    txtcomplemento.Text = hospede.complemento;
                    txtcpf.Text = hospede.cpf_cnpj;
                    txtrg.Text = hospede.rg;
                    txtestadocivil.Text = hospede.estado_civil;
                    txtdatanasc.Text = hospede.nascimento;
                    
                    //txtEmail.txt = hotel.email;

                    txtendereco.Text = hospede.endereco;
                    txtnumero.Text = hospede.numero;
                    txtbairro.Text = hospede.bairro;


                    txtcomplemento.Text = hospede.complemento;
                    txtcep.Text = hospede.cep;


                    for (int i = 0; i < DdlUF.Items.Count; i++)
                    {
                        if (DdlUF.Items[i].Value == hospede.estado.uf)
                            DdlUF.Items[i].Selected = true;
                    }

                    CarregaCidades(hospede.estado.uf);

                    for (int i = 0; i < ddlCidade.Items.Count; i++)
                    {
                        if (ddlCidade.Items[i].Value == hospede.cidade.codibge)
                            ddlCidade.Items[i].Selected = true;
                    }

               
                }
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
        Hospede hospede = new Hospede();

        Hotel.Classes.Hotel hotel = new Hotel.Classes.Hotel();
        hotel = HotelDB.Select(1);

        hospede.hotel = hotel;

        hospede.nome = txtnome.Text;
        hospede.email = txtemail.Text;
        hospede.telefone = txttelefone.Text;
        hospede.celular = txtcelular.Text;
        hospede.complemento = txtcomplemento.Text;
        hospede.cpf_cnpj = txtcpf.Text;
        hospede.rg = txtrg.Text;
        hospede.estado_civil = txtestadocivil.Text;
        hospede.nascimento = txtdatanasc.Text;
        hospede.fisica_juridica = "F";
        hospede.cep = txtcep.Text;

        hospede.tipo = 1;

        //obj.complemento = Convert.ToString(objDataReader["htl_complemento"]);

        Cidade cidade = CidadeDB.Select(Convert.ToInt32(ddlCidade.SelectedItem.Value));
        hospede.cidade = cidade;

        hospede.estado = cidade.uf;

        hospede.endereco = txtendereco.Text;
        hospede.numero = txtnumero.Text;
        hospede.bairro = txtbairro.Text;
        
        hospede.ativo = 1;

        if (txtID.Text != "")
        {
            hospede.id = Convert.ToInt32(txtID.Text);
        }

        int retorno = HospedeDB.Store(hospede);

        switch (retorno)
        {
            case 0:
                txtnome.Focus();
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