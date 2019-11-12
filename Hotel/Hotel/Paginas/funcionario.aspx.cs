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


                Funcionario funcionario = FuncionarioDB.Select(Convert.ToInt32(Session["ID"]));

                if (funcionario != null)
                {
                    txtID.Text = funcionario.id.ToString();
                    txtnome.Text = funcionario.nome;
                    txtemail.Text = funcionario.email;
                    txtsenha.Text = funcionario.senha;
                    txttelefone.Text = funcionario.telefone;
                    txtcelular.Text = funcionario.celular;
                    txtcomplemento.Text = funcionario.complemento;
                    txtcpf.Text = funcionario.cpf_cnpj;
                    txtrg.Text = funcionario.rg;
                    txtestadocivil.Text = funcionario.estado_civil;
                    txtdatanasc.Text = funcionario.nascimento;
                    
                    //txtEmail.txt = hotel.email;

                    txtendereco.Text = funcionario.endereco;
                    txtnumero.Text = funcionario.numero;
                    txtbairro.Text = funcionario.bairro;
                    
                    txtcomplemento.Text = funcionario.complemento;
                    txtcep.Text = funcionario.cep;


                    for (int i = 0; i < DdlUF.Items.Count; i++)
                    {
                        if (DdlUF.Items[i].Value == funcionario.estado.uf)
                            DdlUF.Items[i].Selected = true;
                    }

                    CarregaCidades(funcionario.estado.uf);

                    for (int i = 0; i < ddlCidade.Items.Count; i++)
                    {
                        if (ddlCidade.Items[i].Value == funcionario.cidade.codibge)
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
        Funcionario funcionario = new Funcionario();

        Hotel.Classes.Hotel hotel = new Hotel.Classes.Hotel();
        hotel = HotelDB.Select(1);

        funcionario.hotel = hotel;

        funcionario.nome = txtnome.Text;
        funcionario.email = txtemail.Text;
        funcionario.senha = txtsenha.Text;
        funcionario.telefone = txttelefone.Text;
        funcionario.celular = txtcelular.Text;
        funcionario.complemento = txtcomplemento.Text;
        funcionario.cpf_cnpj = txtcpf.Text;
        funcionario.rg = txtrg.Text;
        funcionario.estado_civil = txtestadocivil.Text;
        funcionario.nascimento = txtdatanasc.Text;
        funcionario.fisica_juridica = "F";
        funcionario.cep = txtcep.Text;

        funcionario.tipo = "0";

        //obj.complemento = Convert.ToString(objDataReader["htl_complemento"]);

        Cidade cidade = CidadeDB.Select(Convert.ToInt32(ddlCidade.SelectedItem.Value));
        funcionario.cidade = cidade;

        funcionario.estado = cidade.uf;

        funcionario.endereco = txtendereco.Text;
        funcionario.numero = txtnumero.Text;
        funcionario.bairro = txtbairro.Text;
        
        funcionario.ativo = 1;

        if (txtID.Text != "")
        {
            funcionario.id = Convert.ToInt32(txtID.Text);
        }

        int retorno = FuncionarioDB.Store(funcionario);

        switch (retorno)
        {
            case 0:
                Response.Redirect("listarFuncionario.aspx?store=true");
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