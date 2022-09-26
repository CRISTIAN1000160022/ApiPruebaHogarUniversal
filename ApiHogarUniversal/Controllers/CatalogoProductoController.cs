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
using System.Drawing;

namespace Api.Controllers
{
    public class CatalogoProductosController : ApiController
    {
        public IHttpActionResult GetLista()
        {
            List<CatalogoProductos> listaCatalogo = new List<CatalogoProductos>();
            using (var db = new HogarUniversalEntities())
            {
                listaCatalogo = db.CatalogoProductos.ToList();
            }
            return Ok(listaCatalogo);
        }
        public IHttpActionResult CreateProducto(Catalogo catalogo)
        {
            try
            {
                using (var db = new HogarUniversalEntities())
                {
                    CatalogoProductos newProducto = new CatalogoProductos
                    {
                        Nombre = catalogo.Nombre,
                        Descripcion = catalogo.Descripcion,
                        Categoria = catalogo.Categoria,
                        Stock = catalogo.Stock,
                        Precio = catalogo.Precio,
                        Fecha_registro = DateTime.Now,
                    };
                    db.CatalogoProductos.AddOrUpdate(newProducto);
                    db.SaveChanges();
                }
                return Ok("Producto creado correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
    public class Catalogo
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Stock { get; set; }
        public string Precio { get; set; }

    }

}
