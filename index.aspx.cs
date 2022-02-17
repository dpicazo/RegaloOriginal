using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegaloOriginal
{
    public partial class index : System.Web.UI.Page
    {
        
        [Serializable]
        public struct lstFavoritos
        {
            public string nombre;
            public double precio;            
        }

        [Serializable]
        public struct lstCarrito
        {
            public string nombre;
            public double precio;
            public int cantidad;
            public double subtotal;
        }

        List<lstFavoritos> tableFavoritos = new List<lstFavoritos>();
        List<lstCarrito> tableCarrito = new List<lstCarrito>();        
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["RegaloFav"] != null)
            {
                tableFavoritos = (List<lstFavoritos>)ViewState["RegaloFav"];             
            }
            if (ViewState["RegaloCarro"] != null)
            {   
                tableCarrito = (List<lstCarrito>)ViewState["RegaloCarro"];
            }

            if (Page.IsPostBack)
            {
                RellenarTablas();
            } else
            {
                RellenarDropdown();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strNombre = inpNombre.Text.Trim();
            double dblPrecio = System.Convert.ToDouble(inpPrecio.Text.Trim());
            int intCantidad = System.Convert.ToInt32(inpCantidad.Text.Trim());
            int intTipo = System.Convert.ToInt32(inpLista.SelectedValue);

            switch (intTipo)
            {
                case 1:
                    {
                        lstCarrito carro = new lstCarrito();
                        carro.nombre = strNombre;
                        carro.precio = dblPrecio;
                        carro.cantidad = intCantidad;
                        carro.subtotal = dblPrecio * intCantidad;
                        tableCarrito.Add(carro);
                        ViewState["RegaloCarro"] = tableCarrito;
                        break;
                    }

                case 2:
                    {
                        lstFavoritos fav = new lstFavoritos();
                        fav.nombre = strNombre;
                        fav.precio = dblPrecio;
                        tableFavoritos.Add(fav);
                        ViewState["RegaloFav"] = tableFavoritos;
                        break;
                    }
            }
            RellenarTablas();
            VaciarForm();
        }

        private void RellenarDropdown()
        {
            inpLista.Items.Add(new ListItem("Seleccionar item", "0"));
            inpLista.Items.Add(new ListItem("Carrito", "1"));
            inpLista.Items.Add(new ListItem("Favorito", "2"));
        }

        private void RellenarTablas()
        {
            LimpiarDatosTabla(TablaFavoritos);
            LimpiarDatosTabla(TablaCarrito);
            
            foreach (var fav in tableFavoritos)
            {
                TableRow row = new TableRow();

                TableCell cellNombre = new TableCell();
                cellNombre.Text = fav.nombre;
                row.Cells.Add(cellNombre);

                TableCell cellPrecio = new TableCell();
                cellPrecio.Text = System.Convert.ToString(fav.precio);
                row.Cells.Add(cellPrecio);

                TablaFavoritos.Rows.Add(row);
            }

            double subTotal = 0;
            foreach (var carro in tableCarrito)
            {
                TableRow row = new TableRow();

                TableCell cellCantidad = new TableCell();
                cellCantidad.Text = System.Convert.ToString(carro.cantidad);
                row.Cells.Add(cellCantidad);

                TableCell cellNombre = new TableCell();
                cellNombre.Text = carro.nombre;
                row.Cells.Add(cellNombre);

                TableCell cellPrecio = new TableCell();
                cellPrecio.Text = System.Convert.ToString(carro.precio);
                row.Cells.Add(cellPrecio);                

                TableCell cellTotal = new TableCell();
                cellTotal.Text = System.Convert.ToString(carro.subtotal);
                row.Cells.Add(cellTotal);
                
                TablaCarrito.Rows.Add(row);
                subTotal += carro.subtotal;
            }

            // SubTotal
            TableRow rwTotal = new TableRow();
            
            TableCell tdTotalTitle = new TableCell();
            tdTotalTitle.Text = "SUBTOTAL";
            tdTotalTitle.ColumnSpan = 3;
            rwTotal.Cells.Add(tdTotalTitle);

            TableCell tdTotal = new TableCell();
            tdTotal.Text = System.Convert.ToString(subTotal);
            rwTotal.Cells.Add(tdTotal);
            
            TablaCarrito.Rows.Add(rwTotal);
        }

        private void LimpiarDatosTabla(Table table)
        {
            if (table.Rows.Count <= 1) return;

            var rowCount = table.Rows.Count;
            for (var i = 1; i < rowCount; i++)
                table.Rows.RemoveAt(1);
        }

        private void VaciarForm()
        {
            inpNombre.Text = "";
            inpCantidad.Text = "1";
            inpPrecio.Text = "0";
            inpLista.SelectedValue = "0";
            inpNombre.Focus();
        }
    }
}