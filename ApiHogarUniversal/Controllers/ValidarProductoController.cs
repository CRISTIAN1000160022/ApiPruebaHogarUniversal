using ApiHogarUniversal.Data;
using ApiHogarUniversal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace ApiHogarUniversal.Controllers
{
    public class ValidarProductoController : ApiController
    {
        public IHttpActionResult ValidarProducto(Producto Buscar)
        {
            try
            {
                var respuesta = false;
                using (var db = new HogarUniversalEntities())
                {
                    var validarProducto = db.CatalogoProductos.Where(x => x.Nombre == Buscar.Nombre).OrderBy(p => p.Id).Select(s => s).ToList();
                    if(validarProducto.Count == 0)
                    {
                        respuesta = true;
                        return Ok(respuesta);
                    }
                    else
                    {
                        return Ok(respuesta);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
    public class Producto
    {
        public string Nombre { get; set; }

    }
}