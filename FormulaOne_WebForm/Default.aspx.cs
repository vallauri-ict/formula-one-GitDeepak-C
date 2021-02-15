using FormulaOne_Dll;
using System;
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
                cmbDb.DataSource = DbTools.getTables();
                cmbDb.DataBind();
            }
            else
            {
                //elaborazioni da eseguire tutte le volte che la pagina viene ricaricata
                //lblMessaggio.Text = "Benvenuto sig. " + txtUserName.Text;
                //lstNazioni.DataSource = DbTools.GetCountries();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attaching one onclick event for the entire row, so that it will
                // fire SelectedIndexChanged, while we click anywhere on the row.
                e.Row.Attributes["onclick"] =
                  ClientScript.GetPostBackClientHyperlink(this.GridViewDati, "Select$" + e.Row.RowIndex);
            }
        }

        protected void datagrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                //FillGrid();
                GridViewDati.PageIndex = e.NewPageIndex;
                GridViewDati.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void cmbDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbDb.Text.StartsWith("-"))
            {
                GridViewDati.DataSource = DbTools.GetDaTa(cmbDb.Text);
                GridViewDati.DataBind();
            }
        }
    }
}