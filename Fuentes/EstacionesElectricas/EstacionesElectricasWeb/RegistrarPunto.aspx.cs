using EstacionesElectricasDAL.DAL;
using EstacionesElectricasDAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstacionesElectricasWeb
{
    public partial class RegistrarPunto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Estacion> estaciones = new EstacionesDAL().GetAll();
                estacionesDdl.DataSource = estaciones;
                estacionesDdl.DataTextField = "Direccion";
                estacionesDdl.DataValueField = "Id";
                estacionesDdl.DataBind();
            }
        }
        private void Limpiar()
        {
            idPunto.Text = "";
            tipoRbl.SelectedValue = "Dual";
            estacionesDdl.SelectedIndex = 0;
        }
        protected void ingresarBtn_click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int id = Convert.ToInt16(idPunto.Text.Trim());
                string tipo = tipoRbl.SelectedValue;
                int idEstacion = Convert.ToInt16(estacionesDdl.SelectedValue);

                Punto punto = new Punto();
                punto.Id = id;
                punto.IdEstacion = idEstacion;
                if(tipo == "Dual")
                {
                    punto.Tipo = Tipo.Dual;
                }else if(tipo == "Electrico")
                {
                    punto.Tipo = Tipo.Electrico;
                }
                PuntosDAL puntos = new PuntosDAL();
                puntos.Guardar(punto);
                Limpiar();
            }
        }

    }
}