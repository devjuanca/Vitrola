using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_mimusica : System.Web.UI.Page
{
    DataClassesCuponDataContext dt = new DataClassesCuponDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadDatePicker1.MinDate = DateTime.Now.AddDays(1);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        int desde = Convert.ToInt16(TextBox2.Text);
        int hasta = Convert.ToInt16(TextBox3.Text);
        if (desde < hasta)
        {
            for (int i = desde; i <= hasta; i++)
            {
                Cupon c = new Cupon();
                c.Numero = i;
                c.Estado = 1;
                c.Descuento = Convert.ToInt16(TextBox4.Text);
                c.Distribuidor = Convert.ToInt16(DropDownList1.SelectedValue);
                c.Fecha_Expedido = DateTime.Now;
                c.Valido_Hasta = RadDatePicker1.SelectedDate;
                dt.Cupons.InsertOnSubmit(c);

            }
            dt.SubmitChanges();

            RadGrid1.DataBind();
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.DataBind();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(RadGrid1.SelectedValue);

        dt.Cupons.Where(a => a.Id == id).First().Estado = 3;
        dt.SubmitChanges();
        RadGrid1.DataBind();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(RadGrid1.SelectedValue);

        dt.Cupons.Where(a => a.Id == id).First().Estado = 1;
        dt.SubmitChanges();
        RadGrid1.DataBind();
    }
}