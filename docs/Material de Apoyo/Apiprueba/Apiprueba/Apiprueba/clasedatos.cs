using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apiprueba;

namespace Apiprueba
{
    public class clasedatos
    {

        Apiprueba.Tarea3PvEntities entities;

        public clasedatos()
        {
            entities = new Tarea3PvEntities();
        }
        //**********************************************
        public List<Productos> GetProductos()
        {
            return entities.Productos.ToList<Productos>();
        }
        //************************************************
        public List<Productos> GetProductosNombre(string nombreProducto)
        {
            try
            {
                var query = from c in entities.Productos
                            where c.NombreProducto == nombreProducto
                            select c;

                return query.ToList<Productos>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //*************************************************
  
        public string EliminarProducto(int idProducto)
        {
            try
            {
                Productos prod = entities.Productos.First<Productos>(x => x.CodigoProducto == idProducto);
                entities.Productos.Remove(prod);
                return Convert.ToString(entities.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}