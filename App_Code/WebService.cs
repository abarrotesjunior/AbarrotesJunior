using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

/// <summary>
/// Descripción breve de WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Producto> MostrarProductos()
    {
        List<Producto> result = new List<Producto>();
        DataTable tblItems = new DataTable();
        tblItems = db_SQLDatabase.ExecuteReaderSP("MOSTRAR_PRODUCTO").Tables[0];
        foreach (DataRow Producto in tblItems.AsEnumerable())
        {
            result.Add(new Producto()
            {
                Id = Convert.ToInt32(Producto["IdProduct"]),
                Nombre_Producto = Convert.ToString(Producto["Nombre_Producto"]),
                Cantidad_Por_Unidad = Convert.ToString(Producto["Cantida_Por_Producto"]),
                Cantidad_Existente = Convert.ToString(Producto["Cantidad_Existente"]),
                Precio = Convert.ToDouble(Producto["Precio"]),
                Marca = Convert.ToString(Producto["Marca"])
            });
        }
        return result;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] EliminarProducto(int IdProduct)
    {
        string[] result = new string[] { };
        result = db_SQLDatabase.ExecuteSPWithParameters(
            "ELIMINAR_PRODUCTO",
            new string[] { "@in_ID" },
            new object[] { IdProduct },
            new string[] { "@out_MESSAGE" });
        return result;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] ModificarAdmin(int IdProducto, string NombreProducto, int CantidadExistente, double Precio, string CantidadPorUnidad, string Marca)
    {
        string[] result = new string[] { };
        result = db_SQLDatabase.ExecuteSPWithParameters("MODIFICAR_PRODUCTOS_ADMIN",
            new string[] { "@in_ID", "@in_Nombre_Producto", "@in_Cantidad_Existente", "@in_Precio", "@in_Cantidad_Por_Unidad", "@in_Marca" },
            new object[] { IdProducto, NombreProducto, CantidadExistente, Precio, CantidadPorUnidad, Marca },
            new string[] { "@out_MESSAGE" }
            );
        return result;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] ModificarEmpleado(int IdProduct, int CantidadExistente)
    {
        string[] result = new string[] { };
        result = db_SQLDatabase.ExecuteSPWithParameters("MODIFICAR_PRODUCTO_EMPLEADO",
            new string[] { "@in_ID", "@in_Cantidad_Existente" },
            new object[] { IdProduct, CantidadExistente},
            new string[] { "@out_MESSAGE" }
            );
        return result;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] AñadirProducto(string nombreproducto, string cantidadproducto, int cantidadexistente, double precioproducto, string marcaproducto)
    {
        string[] result = new string[] { };
        result = db_SQLDatabase.ExecuteSPWithParameters(
            "AGREGAR_PRODUCTOS",
            new string[] { "@in_Nombre_Producto", "@in_Cantidad_Existente", "@in_Precio", "@in_Cantidad_Por_Unidad", "@in_Marca" },
            new object[] { nombreproducto, cantidadproducto, cantidadexistente, precioproducto, marcaproducto },
            new string[] { "@out_MESSAGE", "@out_ID" });
        return result;
    }

    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public string[] AddItem(string itemName, string itemDescription)
    //{
    //    string[] result = new string[] { };
    //    result = db_SQLDatabase.ExecuteSPWithParameters(
    //        "PRO_ADD_NEW_ITEM",
    //        new string[] { "@in_ITEM_NAME", "@in_ITEM_DESCRIPTION" },
    //        new string[] { itemName, itemDescription },
    //        new string[] { "@out_MESSAGE", "@out_ITEM_ID" });
    //    return result;
    //}
}
