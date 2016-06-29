using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MantenimientoCliente.Models;


namespace MantenimientoClienteDAO
{
    public class ClienteBuss: Generico<Cliente>
    {
        public override Cliente Obtener(int id)
        {
            Cliente resultado = null;
            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    resultado = context.Cliente.Where(x => x.ClienteId == id).Select(x => x).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resultado;
        }
        public new List<Cliente> Listar()
        {
            //inicio
            List<Cliente> entidades = null;
            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    entidades = context.Set<Cliente>().Select(x => x).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return entidades;
            //fin
        }

        public override Cliente Buscar(Cliente entidad)
        {//inicio
            Cliente clienteTemp;

            using (var context = new MantenimientoClienteEntities())
            {
                try
                {
                    clienteTemp = context.Cliente.Where(x => x.Nombre == entidad.Nombre).Select(x => x).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return clienteTemp;
          //fin
        }
    }
}
