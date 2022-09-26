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
    public class EditarController : ApiController
    {
        public IHttpActionResult ChangeProducto(CatalogoEditar catalogo)
        {
            try
            {
                using (var db = new HogarUniversalEntities())
                {
                    var listaActualizarProducto = db.CatalogoProductos.Where(x => x.Id == catalogo.Id).OrderBy(p => p.Id).Select(s => s).ToList();
                    foreach (var item in listaActualizarProducto)
                    {
                        CatalogoProductos productoEncontrado = db.CatalogoProductos.Find(item.Id);
                        productoEncontrado.Nombre = catalogo.Nombre;
                        productoEncontrado.Descripcion = catalogo.Descripcion;
                        productoEncontrado.Categoria = catalogo.Categoria;
                        productoEncontrado.Stock = catalogo.Stock;
                        productoEncontrado.Precio = catalogo.Precio;
                        productoEncontrado.Fecha_registro = DateTime.Now;
                        db.CatalogoProductos.AddOrUpdate(productoEncontrado);
                    }
                    db.SaveChanges();
                }
                return Ok("Producto editado correctamente");
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
    public class CatalogoEditar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Stock { get; set; }
        public string Precio { get; set; }
    }
}