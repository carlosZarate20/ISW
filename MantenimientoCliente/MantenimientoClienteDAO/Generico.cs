using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;
using MantenimientoCliente.Models;


namespace MantenimientoClienteDAO
{
    public abstract class Generico<T> where T:class
    {
        public Generico() { }

        public T Insertar(T entidad)
        {
            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    context.Set<T>().Add(entidad);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return entidad;
        }

        public void Eliminar(T entidad)
        {
            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    context.Set<T>().Attach(entidad);
                    context.Set<T>().Remove(entidad);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<T> Listar()
        {
            List<T> entidades = null;

            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    entidades = context.Set<T>().Select(x => x).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return entidades;
        }

        public void Actualizar(T entidad)
        {
            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    context.Set<T>().Attach(entidad);
                    context.Entry(entidad).State = EntityState.Modified ;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public abstract T Obtener(int id);
        public abstract T Buscar(T entidad);
    }
}
