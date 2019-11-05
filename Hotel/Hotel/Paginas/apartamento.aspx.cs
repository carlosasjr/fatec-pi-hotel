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
                   /* txtID.Text = apt.Codigo.ToString();
                    txtNome.Text = apt.Nome;
                    txtSalario.Text = fun.Salario.ToString();
                    txtCracha.Text = fun.Cracha;*/
                }
            }
        }
    }
}