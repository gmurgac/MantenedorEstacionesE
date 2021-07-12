using EstacionesElectricasDAL.DAL;
using EstacionesElectricasDAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionesElectricasWeb
{
    public partial class VerPuntos : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTabla(new PuntosDAL().GetAll());
            }
        }

        private void CargarTabla(List<Punto> puntos)
        {
            puntosGrid.DataSource = puntos;
            puntosGrid.DataBind();
        }
        protected void puntosGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                String idAEliminar = e.CommandArgument.ToString().Trim();
                PuntosDAL puntoDAL = new PuntosDAL();
                puntoDAL.Remove(Convert.ToInt32(idAEliminar));
                CargarTabla(new PuntosDAL().GetAll());
            }else if(e.CommandName == "modificar")
            {
                //Modificar registro
            }
        }
        protected void puntosGrid_RowEditing(object sender,GridViewEditEventArgs e)
        {
            puntosGrid.EditIndex = e.NewEditIndex;

            int id = Convert.ToInt32(puntosGrid.DataKeys[e.NewEditIndex].Value);
            PuntosDAL puntoDAL = new PuntosDAL();
            DataRow row = puntoDAL.GetPuntoByID(id);
            CargarTabla(new PuntosDAL().GetAll());
        }
        protected void puntosGrid_RowCancelingEdit(object sender,GridViewCancelEditEventArgs e)
        {
            puntosGrid.EditIndex = -1;
            CargarTabla(new PuntosDAL().GetAll());
        }
        protected void puntosGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Punto punto = new Punto();
            int id = Convert.ToInt32(puntosGrid.DataKeys[e.RowIndex].Value);
            TextBox idText = puntosGrid.Rows[e.RowIndex].Cells[1].Controls[0] as TextBox;
            TextBox tipoText = puntosGrid.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox;
            TextBox idEstacion = puntosGrid.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox;

            punto.Id = Convert.ToInt32(idText.Text);
            if(tipoText.Text == "Dual")
            {
                punto.Tipo = Tipo.Dual;
            }else if(tipoText.Text == "Electrico")
            {
                punto.Tipo = Tipo.Electrico;
            }
            punto.IdEstacion = Convert.ToInt32(idEstacion.Text);

            PuntosDAL pdal = new PuntosDAL();
            pdal.Modificar(punto);
            //UPDATE


            puntosGrid.EditIndex = -1;
            CargarTabla(new PuntosDAL().GetAll());
        }
    }
}