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
            }
        }
        protected void puntosGrid_RowEditing(object sender,GridViewEditEventArgs e)
        {
            puntosGrid.EditIndex = e.NewEditIndex;
            
            int id = Convert.ToInt32(puntosGrid.DataKeys[e.NewEditIndex].Value);
            PuntosDAL puntoDAL = new PuntosDAL();
            DataRow row = puntoDAL.GetPuntoByID(id);
            CargarTabla(new PuntosDAL().GetAll());
            DropDownList combo1 = puntosGrid.Rows[e.NewEditIndex].FindControl("ddlTipo") as DropDownList;
            if (combo1 != null)
            {
                Tipo tipo = new Tipo();
                combo1.DataSource = System.Enum.GetNames(tipo.GetType());
                combo1.DataBind();
            }

            combo1.SelectedValue = Convert.ToString(row["tipo"]);

            DropDownList combo = puntosGrid.Rows[e.NewEditIndex].FindControl("ddlDirEstacion") as DropDownList;
            if (combo != null)
            {
                combo.DataSource = new EstacionesDAL().GetAll();
                combo.DataTextField = "direccion";
                combo.DataValueField = "id";
                combo.DataBind();
            }

           combo.SelectedValue = Convert.ToString(row["id"]);

           
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
            
            DropDownList tipoddl = puntosGrid.Rows[e.RowIndex].FindControl("ddlTipo") as DropDownList;
            DropDownList idEstacion = puntosGrid.Rows[e.RowIndex].FindControl("ddlDirEstacion") as DropDownList;

            //punto.Id = Convert.ToInt32(idText.Text);
           int idPunto = Convert.ToInt32(e.NewValues["id"]);
            punto.Id = id;
            if (tipoddl.SelectedValue == "Dual")
            {
                punto.Tipo = Tipo.Dual;
            }else if(tipoddl.SelectedValue == "Electrico")
            {
                punto.Tipo = Tipo.Electrico;
            }
            punto.IdEstacion = Convert.ToInt32(idEstacion.SelectedValue);

            PuntosDAL pdal = new PuntosDAL();
            pdal.Modificar(punto);
            //UPDATE


            puntosGrid.EditIndex = -1;
            CargarTabla(new PuntosDAL().GetAll());
        }
        protected void tipoDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoSeleccionado = tipoDdl.SelectedValue;
            if(tipoSeleccionado == "dual")
            {
                List<Punto> filtrada = new PuntosDAL().GetAll(Tipo.Dual);
                CargarTabla(filtrada);
            }else if (tipoSeleccionado == "electrico")
            {
                List<Punto> filtrada = new PuntosDAL().GetAll(Tipo.Electrico);
                CargarTabla(filtrada);
            }
            else if(tipoSeleccionado == "nulo")
            {
                CargarTabla(new PuntosDAL().GetAll());
            }
            
        }
    }
}