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
        public void TestInsertarClienteCorrecto()
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
            business.Eliminar(cliente);
            Assert.AreNotEqual(0, clienteTest);
        }
        [TestMethod]
        public void TestInsertarClienteIncorrecto()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = "ClienteInsertar";
            cliente.Apellido = "ClienteApellidoa";
            cliente.DNI = "1234588855";
            cliente.Edad = 20;
            cliente.Sexo = "Masculino";
            cliente.Nivel_Estudio = "Universitario";
            cliente.Telefono = "123458888";

            ClienteBuss business = new ClienteBuss();
            clienteTest = business.Insertar(cliente);
            business.Eliminar(cliente);
            Assert.AreNotEqual(0, clienteTest);
        }

        [TestMethod]
        public void TestObtenerClienteCorrecto()
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

            ClienteBuss business = new ClienteBuss();
            clienteTest = business.Insertar(cliente);
            obtener = business.Obtener(clienteTest.ClienteId);
            business.Eliminar(cliente);
            Assert.IsNotNull(obtener);

        }
        [TestMethod]
        public void TestObtenerClienteInorrecto()
        {
            Cliente cliente = new Cliente();

            Cliente obtener;

            ClienteBuss business = new ClienteBuss();
            clienteTest = business.Insertar(cliente);
            obtener = business.Obtener(clienteTest.ClienteId);
            business.Eliminar(cliente);
            Assert.IsNotNull(obtener);

        }
        [TestMethod]
        public void TestActualizarClienteCorrecto()
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
            business.Eliminar(cliente);
            Assert.AreEqual(cliente.Nombre, obtener.Nombre);
        }
        [TestMethod]
        public void TestActualizarClienteInorrecto()
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
            cliente.Nombre = "TestActualizar201222222222222222222222222222222222222222222222222222222222222";
            business.Actualizar(cliente);
            obtener = business.Obtener(clienteTest.ClienteId);
            business.Eliminar(cliente);
            Assert.AreEqual(cliente.Nombre, obtener.Nombre);
        }

        [TestMethod]
        public void TestListarClienteCorrecto()
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

            ClienteBuss business = new ClienteBuss();

            clienteTest = business.Insertar(cliente);
            lista = business.Listar();
            business.Eliminar(cliente);
            Assert.IsNotNull(lista);
        }
        [TestMethod]
        public void TestListarClienteIncorrecto()
        {
            Cliente cliente = new Cliente();
            List<Cliente> lista = null;
            
            ClienteBuss business = new ClienteBuss();

            lista = business.Listar();
            business.Eliminar(cliente);
            Assert.IsNotNull(lista);
        }
       
        [TestMethod]
        public void TestBuscarClienteCorrecto()
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
            business.Eliminar(cliente);
            Assert.IsNotNull(obtener);
        }
        [TestMethod]
        public void TestBuscarClienteIncorrecto()
        {
            Cliente cliente = new Cliente();
            Cliente obtener;
            
            ClienteBuss business = new ClienteBuss();

            clienteTest = business.Insertar(cliente);
            obtener = business.Buscar(clienteTest);
            business.Eliminar(cliente);
            Assert.IsNotNull(obtener);
        }
       
        [TestMethod]
        public void TestEliminarClienteCorrecto()
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
        public void TestEliminarClienteIncorrecto()
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
            obtener = business.Obtener(clienteTest.ClienteId);
            clienteTest.ClienteId = 0;
            Assert.IsNull(obtener);
        }



     

       



    }
}