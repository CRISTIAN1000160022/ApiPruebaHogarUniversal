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
    public class EliminarProductoController : ApiController
    {
        public IHttpActionResult EliminarProduct(ProductoBuscar producto)
        {
            try
            {
                using (var db = new HogarUniversalEntities())
                {

                    CatalogoProductos foundProducto = db.CatalogoProductos.Find(producto.Id);
                    db.CatalogoProductos.Remove(foundProducto);
                    db.SaveChanges();
                    return Ok(producto.Id);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

    }
    public class ProductoBuscar
    {
        public int Id { get; set; }

    }
}