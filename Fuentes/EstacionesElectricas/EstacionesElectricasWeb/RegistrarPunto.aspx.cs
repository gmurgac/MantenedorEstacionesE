
using MantenedorEstacionesDB;
using MantenedorEstacionesDB.DAL;
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
                estacionesDdl.DataTextField = "direccion";
                estacionesDdl.DataValueField = "id";
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
                int id = Convert.ToInt32(idPunto.Text.Trim());
                string tipo = tipoRbl.SelectedValue;
                int idEstacion = Convert.ToInt32(estacionesDdl.SelectedValue);

                Punto punto = new Punto();
                punto.id = id;
                punto.idEstacion = idEstacion;
                if(tipo == "Dual")
                {
                    punto.idTipo = 1;
                }else if(tipo == "Electrico")
                {
                    punto.idTipo = 2;
                }
                PuntosDAL puntos = new PuntosDAL();
                puntos.Save(punto);
                Limpiar();
            }
        }

    }
}