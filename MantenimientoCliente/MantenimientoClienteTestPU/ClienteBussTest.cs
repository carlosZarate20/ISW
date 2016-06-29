using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MantenimientoClienteDAO;
using System.Collections.Generic;
using MantenimientoCliente.Models;


namespace MantenimientoClienteTestPU
{
    [TestClass]
    public class ClienteBussTest
    {
        private Cliente clienteTest;

        [TestMethod]
        public void TestInsertarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "ClienteInsertar";
            cliente.Apellido = "ClienteApellidoa";
            cliente.DNI = "12345888";
            cliente.Edad = 21;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123458888";

            ClienteBuss business = new ClienteBuss();
            clienteTest = business.Insertar(cliente);
            Assert.AreNotEqual(0, clienteTest);
        }

        [TestMethod]
        public void TestListarCliente()
        {
            Cliente cliente = new Cliente();
            List<Cliente> lista = null;
            cliente.Nombre = "ClienteTestListar";
            cliente.Apellido = "ClienteApellido";
            cliente.DNI = "12345678";
            cliente.Edad = 20;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123456788";

            ClienteBuss buss = new ClienteBuss();

            clienteTest = buss.Insertar(cliente);
            lista = buss.Listar();

            Assert.IsNotNull(lista);
        }
        [TestMethod]
        public void TestObtenerCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "ClienteTest";
            cliente.Apellido = "ClienteApellido";
            cliente.DNI = "12345678";
            cliente.Edad = 20;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123456788";

            Cliente obtener;

            ClienteBuss buss = new ClienteBuss();
            clienteTest = buss.Insertar(cliente);
            obtener = buss.Obtener(clienteTest.ClienteId);

            Assert.IsNotNull(obtener);
          
        }
        [TestMethod]
        public void TestActualizarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "ClienteTest";
            cliente.Apellido = "ClienteApellido";
            cliente.DNI = "12345678";
            cliente.Edad = 20;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123456788";

            Cliente obtener = new Cliente();

            ClienteBuss business = new ClienteBuss();

            clienteTest = business.Insertar(cliente);
            cliente.ClienteId = clienteTest.ClienteId;
            cliente.Nombre = "TestActualizar2";
            business.Actualizar(cliente);
            obtener = business.Obtener(clienteTest.ClienteId);

            Assert.AreEqual(cliente.Nombre, obtener.Nombre);
        }
        [TestMethod]
        public void TestEliminarClienteCorrecto()
        {

        }
        [TestMethod]
        public void TestEliminarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "ClienteTestEliminar";
            cliente.Apellido = "ClienteApellido";
            cliente.DNI = "12345688";
            cliente.Edad = 20;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123456888";

            Cliente obtener = new Cliente();

            ClienteBuss business = new ClienteBuss();
            clienteTest = business.Insertar(cliente);
            business.Eliminar(cliente);
            obtener = business.Obtener(clienteTest.ClienteId);
            clienteTest.ClienteId = 0;
            Assert.IsNull(obtener);
        }

       

        [TestMethod]
        public void TestBuscarCliente()
        {
            Cliente cliente = new Cliente();
            Cliente obtener;
            cliente.Nombre = "ClienteInsertar";
            cliente.Apellido = "ClienteApellidoa";
            cliente.DNI = "12345888";
            cliente.Edad = 21;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123458888";
            ClienteBuss business = new ClienteBuss();

            clienteTest = business.Insertar(cliente);

            obtener = business.Buscar(clienteTest);
            Assert.IsNotNull(obtener);
        }

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    if (clienteTest.ClienteId != 0)
        //    {
        //        ClienteBuss businessCliente = new ClienteBuss();
          
        //        Cliente cliente;
              

        //        cliente = businessCliente.Obtener(clienteTest.ClienteId);
        //        businessCliente.Eliminar(cliente);
             

        //    }
        //    clienteTest.ClienteId = 0;
            
        //}


     
    }
}