using Microsoft.EntityFrameworkCore;
using SegundoRegistroDetalle.DAL;
using SegundoRegistroDetalle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SegundoRegistroDetalle.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (orden.OrdenId > 0)
                    paso = Modificar(orden);
                else
                    paso = Guardar(orden);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Ordenes orden) 
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Ordenes.Add(orden);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {

                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenId={orden.OrdenId}");
                foreach (var item in orden.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var orden = contexto.Ordenes.Find(id);
                if (orden != null)
                {
                    contexto.Ordenes.Remove(orden);
                    paso = (contexto.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes Compra = new Ordenes();
            try
            {
                Compra = contexto.Ordenes.Include(x => x.Detalle)
                    .Where(x => x.OrdenId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Compra;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Ordenes> Lista = new List<Ordenes>();
            try
            {
                Lista = contexto.Ordenes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        public static List<Suplidores> GetSuplidores()
        {
            Contexto contexto = new Contexto();
            List<Suplidores> Lista = new List<Suplidores>();
            try
            {
                Lista = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }
    }
}
