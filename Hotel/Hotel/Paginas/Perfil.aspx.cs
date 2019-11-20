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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {   

            if (Convert.ToString(Session["ID"]) != "")
            {

                Perfil perfil = PerfilDB.Select(Convert.ToInt32(Session["ID"]));

                if (perfil != null)
                {
                    txtID.Text = perfil.id.ToString();
                    txtdescricao.Text = perfil.descricao;
               
                }
            }

        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Perfil perfil = new Perfil();

        Hotel.Classes.Hotel hotel = HotelDB.Select(Convert.ToInt32(1));

        perfil.hotel = hotel;
        perfil.descricao = txtdescricao.Text;
        perfil.per_ativo = 1;

        if (txtID.Text != "")
        {
            perfil.id = Convert.ToInt32(txtID.Text);
        }

        int retorno = PerfilDB.Store(perfil);

        switch (retorno)
        {
            case 0:
                Response.Redirect("listarPerfil.aspx?store=true");
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