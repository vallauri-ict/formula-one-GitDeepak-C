using FormulaOne_Dll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOne_WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //elaborazioni da eseguire quando la pagina deve essere caricata
                //lblMessaggio.Text = "Digita username e password, poi premi Invia";
                //lblMessaggio.Text = "Benvenuto, per visualizzare le nazioni, premere il pulsante Mostra Nazioni!!";
            }
            else
            {
                //elaborazioni da eseguire tutte le volte che la pagina viene ricaricata
                //lblMessaggio.Text = "Benvenuto sig. " + txtUserName.Text;
                //lstNazioni.DataSource = DbTools.GetCountries();
            }
        }

        protected void btnLoadCountries_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = DbTools.GetCountries();
            GridView1.DataBind();
        }

        protected void btnLoadDrivers_Click(object sender, EventArgs e)
        {
            GridView2.DataSource = DbTools.GetDrivers();
            GridView2.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] =
                  ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
    }
}