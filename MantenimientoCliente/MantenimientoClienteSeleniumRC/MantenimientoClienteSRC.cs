using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace MantenimientoClienteSeleniumRC
{

    [TestFixture]
    public class aIniciarSesionCorrecto
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheIniciarSesionCorrectoTest()
        {
            selenium.Open("/");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Mantenimiento Cliente", selenium.GetText("link=Mantenimiento Cliente"));
        }
    }

    [TestFixture]
    public class bLoginFail_UsuarioFaltante
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheLoginFail_UsuarioFaltanteTest()
        {
            selenium.Open("/");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Ingrese Nombre de Usuario", selenium.GetText("css=div.validation-summary-errors"));
        }
    }

    [TestFixture]
    public class cLoginFail_CamposVacios
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheLoginFail_CamposVaciosTest()
        {
            selenium.Open("/");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Ingrese datos de campos faltantes", selenium.GetText("css=div.validation-summary-errors"));
        }
    }
    [TestFixture]
    public class dLoginFail_ContraseñaFaltante
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheLoginFail_ContraseñaFaltanteTest()
        {
            selenium.Open("/");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Ingrese Contraseña", selenium.GetText("css=div.validation-summary-errors"));
        }
    }
    [TestFixture]
    public class eRegistrar_Cancelar
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRegistrar_CancelarTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Mantenimiento Cliente", selenium.GetText("link=Mantenimiento Cliente"));
            selenium.Click("link=Agregar");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=Nombre", "Maria");
            selenium.Type("id=Apellidos", "Magdalena");
            selenium.Type("id=DNI", "12345677");
            selenium.Type("id=Edad", "20");
            selenium.Select("id=Sexo", "label=Femenino");
            selenium.Select("id=Nivel", "label=Universitario");
            selenium.Type("id=Telefono", "123456789");
            selenium.ChooseCancelOnNextConfirmation();
            selenium.Click("css=button.btn.btn-default");
            Assert.AreEqual("Desea Registrar", selenium.GetConfirmation());
            Assert.AreEqual("RegistrarCliente", selenium.GetText("css=h2"));
        }
    }


    [TestFixture]
    public class fRegistrarCamposVacios
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRegistrarCamposVaciosTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Mantenimiento Cliente", selenium.GetText("link=Mantenimiento Cliente"));
            selenium.Click("link=Agregar");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("RegistrarCliente", selenium.GetText("css=h2"));
            selenium.Click("css=button.btn.btn-default");
            Assert.AreEqual("Desea Registrar", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Ingresar Campos Faltantes", selenium.GetText("css=div.validation-summary-errors"));
        }
    }

    [TestFixture]
    public class gRegistrarDatosInvalidos
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRegistrarDatosInvalidosTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.Click("link=Agregar");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=Nombre", "1234561");
            selenium.Type("id=Apellidos", "123456");
            selenium.Type("id=DNI", "kkk");
            selenium.Type("id=Edad", "j");
            selenium.Select("id=Nivel", "label=Universitario");
            selenium.Type("id=Telefono", "kkl");
            selenium.Click("css=button.btn.btn-default");
            Assert.AreEqual("Desea Registrar", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Datos Incorrectos", selenium.GetText("css=div.validation-summary-errors"));
        }
    }
    [TestFixture]
    public class hRegistrarCorrecto
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRegistrarCorrectoTest()
        {
            selenium.Open("/");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Mantenimiento Cliente", selenium.GetText("link=Mantenimiento Cliente"));
            selenium.Click("link=Agregar");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=Nombre", "Maria");
            selenium.Type("id=Apellidos", "Magdalena");
            selenium.Type("id=DNI", "12345678");
            selenium.Type("id=Edad", "20");
            selenium.Select("id=Sexo", "label=Femenino");
            selenium.Select("id=Nivel", "label=Superior");
            selenium.Type("id=Telefono", "123456789");
            selenium.Click("css=button.btn.btn-default");
            Assert.AreEqual("Desea Registrar", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Se Registro satisfactoriamente el cliente", selenium.GetText("css=div.validation-summary-errors"));
        }
    }

  

    [TestFixture]
    public class jEditarCancelar////////////////////////////////
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheEditarCancelarTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("//a[contains(@href, '/Home/EditarCliente?ClienteId=130')]");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("link=Cancelar");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
        }
    }

    [TestFixture]
    public class kEditarCampoInvalido /////////////////////////////////////
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheEditarCampoInvalidoTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.Click("//a[contains(@href, '/Home/EditarCliente?ClienteId=130')]");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=Edad", "20");
            selenium.Click("css=button.btn.btn-default");
            Assert.AreEqual("Desea Editar al cliente", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Se Edito satisfactoriamente el cliente", selenium.GetText("css=div.validation-summary-errors"));
        }
    }

    [TestFixture]
    public class lEditarCampoVacio/////////////////////////////////////
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheEditarCampoVacioTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.Click("//a[contains(@href, '/Home/EditarCliente?ClienteId=130')]");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=Edad", "20");
            selenium.Type("id=Apellidos", "");
            selenium.Click("css=button.btn.btn-default");
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Desea Editar al cliente", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("EditarCliente", selenium.GetText("css=h2"));
        }
    }

    [TestFixture]
    public class mEditarCorrecto///////////////////////////////////////////
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheEditarCorrectoTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.Click("//a[contains(@href, '/Home/EditarCliente?ClienteId=130')]");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=DNI", "12345677");
            selenium.Click("css=button.btn.btn-default");
            Assert.AreEqual("Desea Editar al cliente", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Se Edito satisfactoriamente el cliente", selenium.GetText("css=div.validation-summary-errors"));
        }
    }

    [TestFixture]
    public class nEliminarCancelar
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheEliminarCancelarTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.ChooseCancelOnNextConfirmation();
            selenium.Click("xpath=(//a[@onclick=\"return confirm('Desea aliminar')\"])[13]");
            Assert.AreEqual("Desea aliminar", selenium.GetConfirmation());
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
        }
    }

    [TestFixture]
    public class oEliminarCorrecto
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheEliminarCorrectoTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.Click("xpath=(//a[@onclick=\"return confirm('Desea aliminar')\"])[13]");
            Assert.AreEqual("Desea aliminar", selenium.GetConfirmation());
            selenium.WaitForPageToLoad("3000");
            Assert.AreEqual("Se elimino satisfactoriamente el cliente", selenium.GetText("css=div.validation-summary-errors"));
        }
    }

    [TestFixture]
    public class pLogOut
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:32016/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheLogOutTest()
        {
            selenium.Open("/Home/Login");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
            selenium.Type("id=Codigo", "root");
            selenium.Type("id=Contrase_a", "root");
            selenium.Click("css=input[type=\"submit\"]");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("LstCliente", selenium.GetText("css=h2"));
            selenium.Click("id=logout");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("Log in", selenium.GetText("css=h2.login-header"));
        }
    }
}
