﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP2236903.Models;

namespace ASP2236903.Controllers
{
    public class Producto_ImagenController : Controller
    {
        // GET: Producto_Imagen
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.ToList());
            }
        }

        public static String NombreProducto(int idProducto)
        {
            using (var db = new inventario2021Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }

        public ActionResult ListarProductos()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto_imagen producto_Imagen)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_imagen.Add(producto_Imagen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_imagen.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_imagen findProductoImagen = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                    return View(findProductoImagen);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto_imagen editProductoImagen)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_imagen producto_imagen = db.producto_imagen.Find(editProductoImagen.id);

                    producto_imagen.imagen = editProductoImagen.imagen;
                    producto_imagen.id_producto = editProductoImagen.id_producto;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error " + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_imagen producto_imagen = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(producto_imagen);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error " + ex);
                return View();
            }
        }

        //public ActionResult CargarImagen()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult CargarImagen(int id_producto, HttpPostedFileBase imagen)
        //{
        //    try
        //    {
        //        string filePath = string.Empty;
        //        string nameFile = "";

        //        if (imagen != null)
        //        {
        //            string path = Server.MapPath("~/Uploads/Imagenes/");

        //            if (!Directory.Exists(path))
        //            {
        //                Directory.CreateDirectory(path);
        //            }

        //            nameFile = Path.GetFileName(imagen.FileName);

        //            filePath = path + Path.GetFileName(imagen.FileName);

        //            string extension = Path.GetExtension(imagen.FileName);

        //            imagen.SaveAs(filePath);
        //        }

        //        using (var bd = new inventario2021Entities())
        //        {
        //            var imagenProducto = new producto_imagen();
        //            imagenProducto.id_producto = id_producto;
        //            imagenProducto.imagen = "/Uploads/Imagenes/" + nameFile;
        //            bd.producto_imagen.Add(imagenProducto);
        //            bd.SaveChanges();
        //        }

        //        return View();
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", "Error " + ex);
        //        return View();
        //    }
        //}
    }

}